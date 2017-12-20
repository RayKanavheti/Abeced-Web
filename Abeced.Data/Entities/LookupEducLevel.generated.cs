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
    [System.Diagnostics.DebuggerDisplay("EducLevelId: {EducLevelId}")]
    public partial class LookupEducLevel : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="LookupEducLevel"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static LookupEducLevel()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupEducLevel"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public LookupEducLevel()
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
        private System.Int32 _educLevelId;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32 EducLevelId
        {
            get { return _educLevelId; }
            set
            {
                OnEducLevelIdChanging(value, _educLevelId);
                SendPropertyChanging("EducLevelId");
                _educLevelId = value;
                SendPropertyChanged("EducLevelId");
                OnEducLevelIdChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _educLevel;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String EducLevel
        {
            get { return _educLevel; }
            set
            {
                OnEducLevelChanging(value, _educLevel);
                SendPropertyChanging("EducLevel");
                _educLevel = value;
                SendPropertyChanged("EducLevel");
                OnEducLevelChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnEducLevelIdChanging(System.Int32 newValue, System.Int32 oldValue);
        
        partial void OnEducLevelIdChanged(System.Int32 value);
        
        partial void OnEducLevelChanging(System.String newValue, System.String oldValue);
        
        partial void OnEducLevelChanged(System.String value);
        
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual LookupEducLevel Clone()
        {
            return (LookupEducLevel)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="LookupEducLevel"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="LookupEducLevel"/> instance.</param>
        /// <returns>An instance of <see cref="LookupEducLevel"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static LookupEducLevel FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(LookupEducLevel));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as LookupEducLevel;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="LookupEducLevel"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="LookupEducLevel"/> instance.</param>
        /// <returns>An instance of <see cref="LookupEducLevel"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static LookupEducLevel FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(LookupEducLevel));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as LookupEducLevel;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414
