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
    [System.Diagnostics.DebuggerDisplay("Userid: {Userid}")]
    public partial class Person : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Person"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static Person()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Person()
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
        private System.String _userid;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
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
        private System.String _lastname;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Lastname
        {
            get { return _lastname; }
            set
            {
                OnLastnameChanging(value, _lastname);
                SendPropertyChanging("Lastname");
                _lastname = value;
                SendPropertyChanged("Lastname");
                OnLastnameChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _firstname;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Firstname
        {
            get { return _firstname; }
            set
            {
                OnFirstnameChanging(value, _firstname);
                SendPropertyChanging("Firstname");
                _firstname = value;
                SendPropertyChanged("Firstname");
                OnFirstnameChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _address;
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Address
        {
            get { return _address; }
            set
            {
                OnAddressChanging(value, _address);
                SendPropertyChanging("Address");
                _address = value;
                SendPropertyChanged("Address");
                OnAddressChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _email;
        
        [System.Runtime.Serialization.DataMember(Order = 5)]
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
        private System.String _title;
        
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Title
        {
            get { return _title; }
            set
            {
                OnTitleChanging(value, _title);
                SendPropertyChanging("Title");
                _title = value;
                SendPropertyChanged("Title");
                OnTitleChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _ageGroup;
        
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String AgeGroup
        {
            get { return _ageGroup; }
            set
            {
                OnAgeGroupChanging(value, _ageGroup);
                SendPropertyChanging("AgeGroup");
                _ageGroup = value;
                SendPropertyChanged("AgeGroup");
                OnAgeGroupChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _occupation;
        
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Occupation
        {
            get { return _occupation; }
            set
            {
                OnOccupationChanging(value, _occupation);
                SendPropertyChanging("Occupation");
                _occupation = value;
                SendPropertyChanged("Occupation");
                OnOccupationChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _educLevel;
        
        [System.Runtime.Serialization.DataMember(Order = 9)]
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
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _sex;
        
        [System.Runtime.Serialization.DataMember(Order = 10)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Sex
        {
            get { return _sex; }
            set
            {
                OnSexChanging(value, _sex);
                SendPropertyChanging("Sex");
                _sex = value;
                SendPropertyChanged("Sex");
                OnSexChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _userPreferencesXml;
        
        [System.Runtime.Serialization.DataMember(Order = 11)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String UserPreferencesXml
        {
            get { return _userPreferencesXml; }
            set
            {
                OnUserPreferencesXmlChanging(value, _userPreferencesXml);
                SendPropertyChanging("UserPreferencesXml");
                _userPreferencesXml = value;
                SendPropertyChanged("UserPreferencesXml");
                OnUserPreferencesXmlChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnUseridChanging(System.String newValue, System.String oldValue);
        
        partial void OnUseridChanged(System.String value);
        
        partial void OnLastnameChanging(System.String newValue, System.String oldValue);
        
        partial void OnLastnameChanged(System.String value);
        
        partial void OnFirstnameChanging(System.String newValue, System.String oldValue);
        
        partial void OnFirstnameChanged(System.String value);
        
        partial void OnAddressChanging(System.String newValue, System.String oldValue);
        
        partial void OnAddressChanged(System.String value);
        
        partial void OnEmailChanging(System.String newValue, System.String oldValue);
        
        partial void OnEmailChanged(System.String value);
        
        partial void OnTitleChanging(System.String newValue, System.String oldValue);
        
        partial void OnTitleChanged(System.String value);
        
        partial void OnAgeGroupChanging(System.String newValue, System.String oldValue);
        
        partial void OnAgeGroupChanged(System.String value);
        
        partial void OnOccupationChanging(System.String newValue, System.String oldValue);
        
        partial void OnOccupationChanged(System.String value);
        
        partial void OnEducLevelChanging(System.String newValue, System.String oldValue);
        
        partial void OnEducLevelChanged(System.String value);
        
        partial void OnSexChanging(System.String newValue, System.String oldValue);
        
        partial void OnSexChanged(System.String value);
        
        partial void OnUserPreferencesXmlChanging(System.String newValue, System.String oldValue);
        
        partial void OnUserPreferencesXmlChanged(System.String value);
        
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual Person Clone()
        {
            return (Person)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Person"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Person"/> instance.</param>
        /// <returns>An instance of <see cref="Person"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Person FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Person));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as Person;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Person"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Person"/> instance.</param>
        /// <returns>An instance of <see cref="Person"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Person FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Person));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as Person;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414
