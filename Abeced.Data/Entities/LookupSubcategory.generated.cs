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
    [System.Diagnostics.DebuggerDisplay("Subcatid: {Subcatid}")]
    public partial class LookupSubcategory : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="LookupSubcategory"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static LookupSubcategory()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupSubcategory"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public LookupSubcategory()
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
        private System.String _subcatid;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Subcatid
        {
            get { return _subcatid; }
            set
            {
                OnSubcatidChanging(value, _subcatid);
                SendPropertyChanging("Subcatid");
                _subcatid = value;
                SendPropertyChanged("Subcatid");
                OnSubcatidChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _catTitle;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String CatTitle
        {
            get { return _catTitle; }
            set
            {
                OnCatTitleChanging(value, _catTitle);
                SendPropertyChanging("CatTitle");
                _catTitle = value;
                SendPropertyChanged("CatTitle");
                OnCatTitleChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _lastupdate;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? Lastupdate
        {
            get { return _lastupdate; }
            set
            {
                OnLastupdateChanging(value, _lastupdate);
                SendPropertyChanging("Lastupdate");
                _lastupdate = value;
                SendPropertyChanged("Lastupdate");
                OnLastupdateChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _catLevel;
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? CatLevel
        {
            get { return _catLevel; }
            set
            {
                OnCatLevelChanging(value, _catLevel);
                SendPropertyChanging("CatLevel");
                _catLevel = value;
                SendPropertyChanged("CatLevel");
                OnCatLevelChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _tags;
        
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Tags
        {
            get { return _tags; }
            set
            {
                OnTagsChanging(value, _tags);
                SendPropertyChanging("Tags");
                _tags = value;
                SendPropertyChanged("Tags");
                OnTagsChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int64? _learnerCount;
        
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int64? LearnerCount
        {
            get { return _learnerCount; }
            set
            {
                OnLearnerCountChanging(value, _learnerCount);
                SendPropertyChanging("LearnerCount");
                _learnerCount = value;
                SendPropertyChanged("LearnerCount");
                OnLearnerCountChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Double? _courseLength;
        
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Double? CourseLength
        {
            get { return _courseLength; }
            set
            {
                OnCourseLengthChanging(value, _courseLength);
                SendPropertyChanging("CourseLength");
                _courseLength = value;
                SendPropertyChanged("CourseLength");
                OnCourseLengthChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _catImage;
        
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String CatImage
        {
            get { return _catImage; }
            set
            {
                OnCatImageChanging(value, _catImage);
                SendPropertyChanging("CatImage");
                _catImage = value;
                SendPropertyChanged("CatImage");
                OnCatImageChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private LookupSubcategory _lookupSubcategoryMember;
        
        [System.Runtime.Serialization.DataMember(Order = 9, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual LookupSubcategory LookupSubcategoryMember
        {
            get { return _lookupSubcategoryMember; }
            set
            {
                OnLookupSubcategoryMemberChanging(value, _lookupSubcategoryMember);
                SendPropertyChanging("LookupSubcategoryMember");
                _lookupSubcategoryMember = value;
                SendPropertyChanged("LookupSubcategoryMember");
                OnLookupSubcategoryMemberChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private LookupCategory _lookupCategory;
        
        [System.Runtime.Serialization.DataMember(Order = 10, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual LookupCategory LookupCategory
        {
            get { return _lookupCategory; }
            set
            {
                OnLookupCategoryChanging(value, _lookupCategory);
                SendPropertyChanging("LookupCategory");
                _lookupCategory = value;
                SendPropertyChanged("LookupCategory");
                OnLookupCategoryChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private IList<LookupSubcategory> _lookupSubcategoryList;
        
        [System.Runtime.Serialization.DataMember(Order = 11, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual IList<LookupSubcategory> LookupSubcategoryList
        {
            get { return _lookupSubcategoryList; }
            set
            {
                OnLookupSubcategoryListChanging(value, _lookupSubcategoryList);
                SendPropertyChanging("LookupSubcategoryList");
                _lookupSubcategoryList = value;
                SendPropertyChanged("LookupSubcategoryList");
                OnLookupSubcategoryListChanged(value);
            }
        }
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnSubcatidChanging(System.String newValue, System.String oldValue);
        
        partial void OnSubcatidChanged(System.String value);
        
        partial void OnCatTitleChanging(System.String newValue, System.String oldValue);
        
        partial void OnCatTitleChanged(System.String value);
        
        partial void OnLastupdateChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnLastupdateChanged(System.DateTime? value);
        
        partial void OnCatLevelChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnCatLevelChanged(System.Int32? value);
        
        partial void OnTagsChanging(System.String newValue, System.String oldValue);
        
        partial void OnTagsChanged(System.String value);
        
        partial void OnLearnerCountChanging(System.Int64? newValue, System.Int64? oldValue);
        
        partial void OnLearnerCountChanged(System.Int64? value);
        
        partial void OnCourseLengthChanging(System.Double? newValue, System.Double? oldValue);
        
        partial void OnCourseLengthChanged(System.Double? value);
        
        partial void OnCatImageChanging(System.String newValue, System.String oldValue);
        
        partial void OnCatImageChanged(System.String value);
        
        
        partial void OnLookupSubcategoryMemberChanging(LookupSubcategory newValue, LookupSubcategory oldValue);
        
        partial void OnLookupSubcategoryMemberChanged(LookupSubcategory value);
        
        partial void OnLookupCategoryChanging(LookupCategory newValue, LookupCategory oldValue);
        
        partial void OnLookupCategoryChanged(LookupCategory value);
        
        partial void OnLookupSubcategoryListChanging(IList<LookupSubcategory> newValue, IList<LookupSubcategory> oldValue);
        
        partial void OnLookupSubcategoryListChanged(IList<LookupSubcategory> value);
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual LookupSubcategory Clone()
        {
            return (LookupSubcategory)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="LookupSubcategory"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="LookupSubcategory"/> instance.</param>
        /// <returns>An instance of <see cref="LookupSubcategory"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static LookupSubcategory FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(LookupSubcategory));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as LookupSubcategory;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="LookupSubcategory"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="LookupSubcategory"/> instance.</param>
        /// <returns>An instance of <see cref="LookupSubcategory"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static LookupSubcategory FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(LookupSubcategory));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as LookupSubcategory;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414
