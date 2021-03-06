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
    [System.Diagnostics.DebuggerDisplay("RevisionId: {RevisionId}")]
    public partial class CardRevision : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="CardRevision"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static CardRevision()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CardRevision"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public CardRevision()
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
        private System.String _revisionId;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String RevisionId
        {
            get { return _revisionId; }
            set
            {
                OnRevisionIdChanging(value, _revisionId);
                SendPropertyChanging("RevisionId");
                _revisionId = value;
                SendPropertyChanged("RevisionId");
                OnRevisionIdChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _xmlCarddetails;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String XmlCarddetails
        {
            get { return _xmlCarddetails; }
            set
            {
                OnXmlCarddetailsChanging(value, _xmlCarddetails);
                SendPropertyChanging("XmlCarddetails");
                _xmlCarddetails = value;
                SendPropertyChanged("XmlCarddetails");
                OnXmlCarddetailsChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _updateDate;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? UpdateDate
        {
            get { return _updateDate; }
            set
            {
                OnUpdateDateChanging(value, _updateDate);
                SendPropertyChanging("UpdateDate");
                _updateDate = value;
                SendPropertyChanged("UpdateDate");
                OnUpdateDateChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Boolean? _completed;
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Boolean? Completed
        {
            get { return _completed; }
            set
            {
                OnCompletedChanging(value, _completed);
                SendPropertyChanging("Completed");
                _completed = value;
                SendPropertyChanged("Completed");
                OnCompletedChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _completedDate;
        
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? CompletedDate
        {
            get { return _completedDate; }
            set
            {
                OnCompletedDateChanging(value, _completedDate);
                SendPropertyChanging("CompletedDate");
                _completedDate = value;
                SendPropertyChanged("CompletedDate");
                OnCompletedDateChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _timeIn;
        
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? TimeIn
        {
            get { return _timeIn; }
            set
            {
                OnTimeInChanging(value, _timeIn);
                SendPropertyChanging("TimeIn");
                _timeIn = value;
                SendPropertyChanged("TimeIn");
                OnTimeInChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _correctCards;
        
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String CorrectCards
        {
            get { return _correctCards; }
            set
            {
                OnCorrectCardsChanging(value, _correctCards);
                SendPropertyChanging("CorrectCards");
                _correctCards = value;
                SendPropertyChanged("CorrectCards");
                OnCorrectCardsChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _wrongCards;
        
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String WrongCards
        {
            get { return _wrongCards; }
            set
            {
                OnWrongCardsChanging(value, _wrongCards);
                SendPropertyChanging("WrongCards");
                _wrongCards = value;
                SendPropertyChanged("WrongCards");
                OnWrongCardsChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _revisionslist;
        
        [System.Runtime.Serialization.DataMember(Order = 9)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Revisionslist
        {
            get { return _revisionslist; }
            set
            {
                OnRevisionslistChanging(value, _revisionslist);
                SendPropertyChanging("Revisionslist");
                _revisionslist = value;
                SendPropertyChanged("Revisionslist");
                OnRevisionslistChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _userid;
        
        [System.Runtime.Serialization.DataMember(Order = 10)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Userid
        {
            get { return _userid; }
            set
            {
                OnUseridChanging(value, _userid);
                SendPropertyChanging("Userid");
                _userid = value;
                SendPropertyChanged("Userid");
                OnUseridChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _category;
        
        [System.Runtime.Serialization.DataMember(Order = 11)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Category
        {
            get { return _category; }
            set
            {
                OnCategoryChanging(value, _category);
                SendPropertyChanging("Category");
                _category = value;
                SendPropertyChanged("Category");
                OnCategoryChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _askLater;
        
        [System.Runtime.Serialization.DataMember(Order = 12)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String AskLater
        {
            get { return _askLater; }
            set
            {
                OnAskLaterChanging(value, _askLater);
                SendPropertyChanging("AskLater");
                _askLater = value;
                SendPropertyChanged("AskLater");
                OnAskLaterChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Cardsession _cardsession;
        
        [System.Runtime.Serialization.DataMember(Order = 13, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual Cardsession Cardsession
        {
            get { return _cardsession; }
            set
            {
                OnCardsessionChanging(value, _cardsession);
                SendPropertyChanging("Cardsession");
                _cardsession = value;
                SendPropertyChanged("Cardsession");
                OnCardsessionChanged(value);
            }
        }
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnRevisionIdChanging(System.String newValue, System.String oldValue);
        
        partial void OnRevisionIdChanged(System.String value);
        
        partial void OnXmlCarddetailsChanging(System.String newValue, System.String oldValue);
        
        partial void OnXmlCarddetailsChanged(System.String value);
        
        partial void OnUpdateDateChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnUpdateDateChanged(System.DateTime? value);
        
        partial void OnCompletedChanging(System.Boolean? newValue, System.Boolean? oldValue);
        
        partial void OnCompletedChanged(System.Boolean? value);
        
        partial void OnCompletedDateChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnCompletedDateChanged(System.DateTime? value);
        
        partial void OnTimeInChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnTimeInChanged(System.DateTime? value);
        
        partial void OnCorrectCardsChanging(System.String newValue, System.String oldValue);
        
        partial void OnCorrectCardsChanged(System.String value);
        
        partial void OnWrongCardsChanging(System.String newValue, System.String oldValue);
        
        partial void OnWrongCardsChanged(System.String value);
        
        partial void OnRevisionslistChanging(System.String newValue, System.String oldValue);
        
        partial void OnRevisionslistChanged(System.String value);
        
        partial void OnUseridChanging(System.String newValue, System.String oldValue);
        
        partial void OnUseridChanged(System.String value);
        
        partial void OnCategoryChanging(System.String newValue, System.String oldValue);
        
        partial void OnCategoryChanged(System.String value);
        
        partial void OnAskLaterChanging(System.String newValue, System.String oldValue);
        
        partial void OnAskLaterChanged(System.String value);
        
        
        partial void OnCardsessionChanging(Cardsession newValue, Cardsession oldValue);
        
        partial void OnCardsessionChanged(Cardsession value);
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual CardRevision Clone()
        {
            return (CardRevision)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="CardRevision"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="CardRevision"/> instance.</param>
        /// <returns>An instance of <see cref="CardRevision"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static CardRevision FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(CardRevision));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as CardRevision;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="CardRevision"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="CardRevision"/> instance.</param>
        /// <returns>An instance of <see cref="CardRevision"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static CardRevision FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(CardRevision));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as CardRevision;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414
