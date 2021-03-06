﻿#pragma warning disable 1591
#pragma warning disable 0414        
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using Abeced.Data;

namespace Abeced.Data
{
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.Diagnostics.DebuggerDisplay("Requestid: {Requestid}")]
    public partial class PasswordReset : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="PasswordReset"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static PasswordReset()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordReset"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public PasswordReset()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        protected override void Initialize()
        {
            OnCreated();
        }
        
        #endregion
        
        #region Column Mapped Properties
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _requestid;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Requestid
        {
            get { return _requestid; }
            set
            {
                OnRequestidChanging(value, _requestid);
                SendPropertyChanging("Requestid");
                _requestid = value;
                SendPropertyChanged("Requestid");
                OnRequestidChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _email;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Email
        {
            get { return _email; }
            set
            {
                OnEmailChanging(value, _email);
                SendPropertyChanging("Email");
                _email = value;
                SendPropertyChanged("Email");
                OnEmailChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime _reqtime;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime Reqtime
        {
            get { return _reqtime; }
            set
            {
                OnReqtimeChanging(value, _reqtime);
                SendPropertyChanging("Reqtime");
                _reqtime = value;
                SendPropertyChanged("Reqtime");
                OnReqtimeChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Boolean _isvalid;
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Boolean Isvalid
        {
            get { return _isvalid; }
            set
            {
                OnIsvalidChanging(value, _isvalid);
                SendPropertyChanging("Isvalid");
                _isvalid = value;
                SendPropertyChanged("Isvalid");
                OnIsvalidChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnRequestidChanging(System.String newValue, System.String oldValue);
        
        partial void OnRequestidChanged(System.String value);
        
        partial void OnEmailChanging(System.String newValue, System.String oldValue);
        
        partial void OnEmailChanged(System.String value);
        
        partial void OnReqtimeChanging(System.DateTime newValue, System.DateTime oldValue);
        
        partial void OnReqtimeChanged(System.DateTime value);
        
        partial void OnIsvalidChanging(System.Boolean newValue, System.Boolean oldValue);
        
        partial void OnIsvalidChanged(System.Boolean value);
        
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual PasswordReset Clone()
        {
            return (PasswordReset)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="PasswordReset"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="PasswordReset"/> instance.</param>
        /// <returns>An instance of <see cref="PasswordReset"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static PasswordReset FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(PasswordReset));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as PasswordReset;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="PasswordReset"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="PasswordReset"/> instance.</param>
        /// <returns>An instance of <see cref="PasswordReset"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static PasswordReset FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(PasswordReset));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as PasswordReset;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414
