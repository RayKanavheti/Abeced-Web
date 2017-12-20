using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Net.Mail;

using System.Data;


namespace Abeced.UI.Helpers
{
    /// <summary>
    /// Helper functions
    /// </summary>
    public static class StringCipher
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        //private const string initVector = "tu89geji340t89u2";
        /// <summary>
        /// The initialize vector
        /// </summary>
        private const string initVector = "tu79geji940t89u9";
        // This constant is used to determine the keysize of the encryption algorithm.
        /// <summary>
        /// The keysize
        /// </summary>
        private const int keysize = 256;

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns> encypted text</returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            //symmetricKey.BlockSize = 64; // for mono
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.ISO10126;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>descrypt</returns>
        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            //byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText.Replace(" ","+")); //replace spaces with place to fix error
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            //symmetricKey.BlockSize = 64;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.ISO10126;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }


    /// <summary>
    /// Mailer functions
    /// </summary>
    public class Mailer
    {
        
        //private void SendMail()
        //{
        //    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

        //    mailMessage.From = new MailAddress("YOUR EMAIL ADDRESS HERE");
        //    mailMessage.To.Add(new MailAddress("YOUR EMAIL ADDRESS HERE"));

        //    mailMessage.Subject = txtSubject.Text.Trim();
        //    mailMessage.Body = txtBody.Text.Trim();

        //    SmtpClient smtpClient = new SmtpClient();
        //    Object userState = mailMessage;

        //    //Attach event handler for async callback
        //    smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);

        //    try
        //    {
        //        //Send the email asynchronously
        //        smtpClient.SendAsync(mailMessage, userState);
        //    }
        //    catch (SmtpException smtpEx)
        //    {
        //        //Error handling here
        //    }
        //    catch (Exception ex)
        //    {
        //        //Error handling here
        //    }
        //}
        
        /// <summary>
        /// Sends email asynchronously.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="mailTo">The mail to.</param>

        public void SendMail(string mailSubject, string mailBody, string mailFrom, string mailTo )
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(mailTo));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();

            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;

            //Attach event handler for async callback
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);

            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception )
            {
                //Error handling here
            }
        }

        /// <summary>
        /// Sends the mail in HTML.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="mailTo">The mail to.</param>
        public void SendMailHtml(string mailSubject, string mailBody, string mailFrom, string mailTo)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.Default;
            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(mailTo));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();

            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;

            //Attach event handler for async callback
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);

            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception)
            {
                //Error handling here
            }
        }

        /// <summary>
        /// Sends the mail with attachment.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="mailTo">The mail to.</param>
        /// <param name="fileName">Name of the file.</param>
        public void SendMailWithAttachment(string mailSubject, string mailBody, string mailFrom, string mailTo, string fileName)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.BodyEncoding = Encoding.Default;


            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(mailTo));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();



            Attachment messageAttachment = new Attachment(fileName);
            mailMessage.Attachments.Add(messageAttachment);

            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;



            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            //smtpClient.EnableSsl = true;
            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception)
            {
                //Error handling here
            }



        }
        /// <summary>
        /// Sends the mail with attachment cc.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="mailTo">The mail to.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="cc_emails">The cc_emails.</param>
        /// <param name="memStr">The memory string.</param>
        /// <param name="pdfName">Name of the PDF.</param>
        public void SendMailWithAttachmentCC(string mailSubject, string mailBody, string mailFrom,
            string mailTo, IList<string> fileName, IList<string> cc_emails, MemoryStream memStr, string pdfName)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.BodyEncoding = Encoding.Default;


            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(mailTo));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();

            foreach (var fileA in fileName)
            {
                //Attachment messageAttachment = new Attachment(fileA);
                mailMessage.Attachments.Add(new Attachment(fileA));
            }
            mailMessage.Attachments.Add(new Attachment(memStr, pdfName));

            foreach (var em in cc_emails)
            {
                mailMessage.CC.Add(em);
            }
            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;



            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            //smtpClient.EnableSsl = true;
            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception )
            {
                //Error handling here
            }



        }

        /// <summary>
        /// Sends the mail cc.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="mailTo">The mail to.</param>
        /// <param name="cc_emails">The cc_emails.</param>
        public void SendMailCC(string mailSubject, string mailBody, string mailFrom,
          string mailTo, IList<string> cc_emails)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.BodyEncoding = Encoding.Default;


            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(mailTo));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();

          
           

            foreach (var em in cc_emails)
            {
                mailMessage.CC.Add(em);
            }
            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;



            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            //smtpClient.EnableSsl = true;
            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception)
            {
                //Error handling here
            }



        }

        /// <summary>
        /// Sends the multiple mail.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="cc_emails">The cc_emails.</param>
        public void SendMultipleMail(string mailSubject, string mailBody, string mailFrom,
           IList<string> cc_emails)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.BodyEncoding = Encoding.Default;


            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(cc_emails.First()));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();




            foreach (var em in cc_emails)
            {
                if(em !=cc_emails.First())
                {
                    mailMessage.CC.Add(em);
                }
            }
            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;



            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            //smtpClient.EnableSsl = true;
            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception)
            {
                //Error handling here
            }



        }

        /// <summary>
        /// Sends the mail HTML cc.
        /// </summary>
        /// <param name="mailSubject">The mail subject.</param>
        /// <param name="mailBody">The mail body.</param>
        /// <param name="mailFrom">The mail from.</param>
        /// <param name="mailTo">The mail to.</param>
        /// <param name="cc_emails">The cc_emails.</param>
        public void SendMailHtmlCC(string mailSubject, string mailBody, string mailFrom,
           string mailTo, IList<string> cc_emails)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.Default;
            mailMessage.From = new MailAddress(mailFrom);
            mailMessage.To.Add(new MailAddress(mailTo));

            mailMessage.Subject = mailSubject.Trim();
            mailMessage.Body = mailBody.Trim();

            foreach (var em in cc_emails)
            {
                mailMessage.CC.Add(em);
            }
            SmtpClient smtpClient = new SmtpClient();
            Object userState = mailMessage;

            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            //smtpClient.EnableSsl = true;
            try
            {
                //Send the email asynchronously
                smtpClient.SendAsync(mailMessage, userState);
            }
            catch (SmtpException)
            {
                //Error handling here
            }
            catch (Exception)
            {
                //Error handling here
            }



        }

        /// <summary>
        /// Event handler for processing completion information after asynchronous email sent.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.AsyncCompletedEventArgs"/> instance containing the event data.</param>
        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string feedback;

            //Get UserState as MailMessage instance from SendMail()
            MailMessage mailMessage = e.UserState as MailMessage;

            if (e.Cancelled)
            {
                feedback = "Sending of email message was cancelled. Address=" + mailMessage.To[0].Address;
            }

            if (e.Error != null)
            {
                feedback = "Error occured, info=" + e.Error.Message;
            }
            else
            {
                feedback = "Mail sent successfully";
            }

            //return feedback;
        }
    }

    /// <summary>
    /// Extentions
    /// </summary>
    public static class Ext
    {
        /// <summary>
        /// Shuffles the specified list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            var provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                var box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                var k = (box[0] % n);
                n--;
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Quicks the shuffle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        public static void QuickShuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }  
    }
}