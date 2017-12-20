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
    [System.Diagnostics.DebuggerDisplay("Identification: {Identification}")]
    public partial class QuizScore : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="QuizScore"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static QuizScore()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="QuizScore"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public QuizScore()
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
        private System.String _identification;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Identification
        {
            get { return _identification; }
            set
            {
                OnIdentificationChanging(value, _identification);
                SendPropertyChanging("Identification");
                _identification = value;
                SendPropertyChanged("Identification");
                OnIdentificationChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _username;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Username
        {
            get { return _username; }
            set
            {
                OnUsernameChanging(value, _username);
                SendPropertyChanging("Username");
                _username = value;
                SendPropertyChanged("Username");
                OnUsernameChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _catId;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? CatId
        {
            get { return _catId; }
            set
            {
                OnCatIdChanging(value, _catId);
                SendPropertyChanging("CatId");
                _catId = value;
                SendPropertyChanged("CatId");
                OnCatIdChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _numberOfQuestions;
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? NumberOfQuestions
        {
            get { return _numberOfQuestions; }
            set
            {
                OnNumberOfQuestionsChanging(value, _numberOfQuestions);
                SendPropertyChanging("NumberOfQuestions");
                _numberOfQuestions = value;
                SendPropertyChanged("NumberOfQuestions");
                OnNumberOfQuestionsChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Decimal? _points;
        
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Decimal? Points
        {
            get { return _points; }
            set
            {
                OnPointsChanging(value, _points);
                SendPropertyChanging("Points");
                _points = value;
                SendPropertyChanged("Points");
                OnPointsChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _dateTaken;
        
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? DateTaken
        {
            get { return _dateTaken; }
            set
            {
                OnDateTakenChanging(value, _dateTaken);
                SendPropertyChanging("DateTaken");
                _dateTaken = value;
                SendPropertyChanged("DateTaken");
                OnDateTakenChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _timeTaken;
        
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? TimeTaken
        {
            get { return _timeTaken; }
            set
            {
                OnTimeTakenChanging(value, _timeTaken);
                SendPropertyChanging("TimeTaken");
                _timeTaken = value;
                SendPropertyChanged("TimeTaken");
                OnTimeTakenChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnIdentificationChanging(System.String newValue, System.String oldValue);
        
        partial void OnIdentificationChanged(System.String value);
        
        partial void OnUsernameChanging(System.String newValue, System.String oldValue);
        
        partial void OnUsernameChanged(System.String value);
        
        partial void OnCatIdChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnCatIdChanged(System.Int32? value);
        
        partial void OnNumberOfQuestionsChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnNumberOfQuestionsChanged(System.Int32? value);
        
        partial void OnPointsChanging(System.Decimal? newValue, System.Decimal? oldValue);
        
        partial void OnPointsChanged(System.Decimal? value);
        
        partial void OnDateTakenChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnDateTakenChanged(System.DateTime? value);
        
        partial void OnTimeTakenChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnTimeTakenChanged(System.DateTime? value);
        
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual QuizScore Clone()
        {
            return (QuizScore)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="QuizScore"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="QuizScore"/> instance.</param>
        /// <returns>An instance of <see cref="QuizScore"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static QuizScore FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(QuizScore));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as QuizScore;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="QuizScore"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="QuizScore"/> instance.</param>
        /// <returns>An instance of <see cref="QuizScore"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static QuizScore FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(QuizScore));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as QuizScore;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414