using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Security;


namespace Abeced.UI.Models
{
    /// <summary>
    /// Flash Card Model
    /// </summary>
    public class FlashCardModel
    {
        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        [Required]
        [Display(Name = "CardId")]
        public string CardId { get; set; }

        /// <summary>
        /// Gets or sets the subject area.
        /// </summary>
        /// <value>
        /// The subject area.
        /// </value>
        [Required]
        public string SubjectArea { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the question image.
        /// </summary>
        /// <value>
        /// The question image.
        /// </value>
        public string QuestionImage { get; set; }
        /// <summary>
        /// Gets or sets the question audio.
        /// </summary>
        /// <value>
        /// The question audio.
        /// </value>
        public string QuestionAudio { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        [Required]
        public string Answer { get; set; }
        /// <summary>
        /// Gets or sets the answer image.
        /// </summary>
        /// <value>
        /// The answer image.
        /// </value>
        public string AnswerImage { get; set; }
        /// <summary>
        /// Gets or sets the answer audio.
        /// </summary>
        /// <value>
        /// The answer audio.
        /// </value>
        public string AnswerAudio { get; set; }

        /// <summary>
        /// Gets or sets the fact sheet.
        /// </summary>
        /// <value>
        /// The fact sheet.
        /// </value>
        [Required]
        [Display(Name = "Fact Sheet")]
        public string FactSheet { get; set; }

        //[Required]
        /// <summary>
        /// Gets or sets the fact image.
        /// </summary>
        /// <value>
        /// The fact image.
        /// </value>
        [Display(Name = "Fact Image")]
        public string FactImage { get; set; }

        //[Required]
        /// <summary>
        /// Gets or sets the fact audio.
        /// </summary>
        /// <value>
        /// The fact audio.
        /// </value>
        [Display(Name = "Fact Audio")]
        public string FactAudio { get; set; }

        //[Required]
        /// <summary>
        /// Gets or sets the uploaded by.
        /// </summary>
        /// <value>
        /// The uploaded by.
        /// </value>
        public string UploadedBy { get; set; }

        /// <summary>
        /// Gets or sets the size of the fact audio.
        /// </summary>
        /// <value>
        /// The size of the fact audio.
        /// </value>
        public string FactAudioSize { get; set; }


        /// <summary>
        /// Gets or sets the include ex.
        /// </summary>
        /// <value>
        /// The include ex.
        /// </value>
        public string IncludeEx { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FlashCardModel" /> is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if approved; otherwise, <c>false</c>.
        /// </value>
        public bool Approved { set; get; }
    }

    /// <summary>
    /// Flash Card Session Model
    /// </summary>
    public class FlashCardSessionModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlashCardSessionModel"/> class.
        /// </summary>
        public FlashCardSessionModel()
        {
            FlashCards = new List<FlashCardModel>();
        }

        /// <summary>
        /// Gets or sets the msess identifier.
        /// </summary>
        /// <value>
        /// The msess identifier.
        /// </value>
        [Display(Name = "MSessionId")]
        public string MsessId { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        [Display(Name = "SessionId")]           //card revision
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the time in.
        /// </summary>
        /// <value>
        /// The time in.
        /// </value>
        [Display(Name = "Time In")]
        public DateTime? TimeIn { get; set; }

        /// <summary>
        /// Gets or sets the time out.
        /// </summary>
        /// <value>
        /// The time out.
        /// </value>
        [Display(Name = "Time Out")]
        public DateTime? TimeOut { get; set; }

        /// <summary>
        /// Gets or sets the completed.
        /// </summary>
        /// <value>
        /// The completed.
        /// </value>
        [Display(Name = "Completed")]
        public bool? Completed { get; set; }

        /// <summary>
        /// Gets or sets the flash cards.
        /// </summary>
        /// <value>
        /// The flash cards.
        /// </value>
        public IList<FlashCardModel> FlashCards { get; set; }

        /// <summary>
        /// Gets or sets the refill flash cards.
        /// </summary>
        /// <value>
        /// The refill flash cards.
        /// </value>
        public IList<FlashCardModel> RefillFlashCards { get; set; }

        /// <summary>
        /// Gets or sets the completed cards.
        /// </summary>
        /// <value>
        /// The completed cards.
        /// </value>
        public int CompletedCards { get; set; }

        /// <summary>
        /// Gets or sets the catid.
        /// </summary>
        /// <value>
        /// The category id.
        /// </value>
        public string catid { set; get; }

        /// <summary>
        /// Gets or sets the percent complete.
        /// </summary>
        /// <value>
        /// The percent complete.
        /// </value>
        public double PercentComplete { set; get; }

        /// <summary>
        /// Gets or sets the finished cards.
        /// </summary>
        /// <value>
        /// The finished cards.
        /// </value>
        public int finishedCards { set; get; }

        /// <summary>
        /// Gets or sets the repeat cards.
        /// </summary>
        /// <value>
        /// The repeat cards.
        /// </value>
        public int RepeatCards { set; get; }

        /// <summary>
        /// Gets or sets the repeat cycle time.
        /// </summary>
        /// <value>
        /// The repeat cycle time.
        /// </value>
        public string RepeatCycleTime { set; get; }

        /// <summary>
        /// Gets or sets the FLSH status.
        /// </summary>
        /// <value>
        /// The FLSH status.
        /// </value>
        public string FlshStatus { set; get; }

        /// <summary>
        /// Gets or sets a value indicating whether [scheduled revise].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [scheduled revise]; otherwise, <c>false</c>.
        /// </value>
        public bool ScheduledRevise { set; get; }

     
    }

    /// <summary>
    /// FlashCard Revision Model
    /// </summary>
    public class FlashCardRevisionModel
    {
        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        [Required]
        [Display(Name = "CardId")]
        public string CardId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [correct answer].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [correct answer]; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool CorrectAnswer { get; set; }

        /// <summary>
        /// Gets or sets the elapse time.
        /// </summary>
        /// <value>
        /// The elapse time.
        /// </value>
        [Required]
        public double? ElapseTime { get; set; }

        /// <summary>
        /// Gets or sets the revision order.
        /// </summary>
        /// <value>
        /// The revision order.
        /// </value>
        [Required]
        public string RevisionOrder { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public string SessionId { get; set; }

    }

    /// <summary>
    /// Category List Model
    /// </summary>
    public class CategoryListModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryListModel"/> class.
        /// </summary>
        public CategoryListModel()
        {
            Categories = new List<CategoryModel>();
            UserCardSession = new List<Abeced.Data.Cardsession>();
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public IList<CategoryModel> Categories { get; set; }
        /// <summary>
        /// Gets or sets the main category identifier.
        /// </summary>
        /// <value>
        /// The mcat identifier.
        /// </value>
        public string McatId { get; set; }
        /// <summary>
        /// Gets or sets the revision count.
        /// </summary>
        /// <value>
        /// The revision count.
        /// </value>
        public int RevisionCount { set; get; }
        /// <summary>
        /// Gets or sets the pending sesson count.
        /// </summary>
        /// <value>
        /// The pending sesson count.
        /// </value>
        public int PendingSessonCount { set; get; }
        /// <summary>
        /// Gets or sets my card count.
        /// </summary>
        /// <value>
        /// My card count.
        /// </value>
        public int MyCardCount { set; get; }

        /// <summary>
        /// Gets or sets app Type .
        /// </summary>
        /// <value>
        /// App Type
        /// </value>
        public string AppType { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Abeced.Data.Cardsession> UserCardSession { set; get;  }
        /// <summary>
        /// 
        /// </summary>
        public Abeced.Data.Cardsession UserReviseSession { set; get; }
    }

    /// <summary>
    /// Category Model
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// Gets or sets the cat identifier.
        /// </summary>
        /// <value>
        /// The cat identifier.
        /// </value>
        public string CatId { get; set; }
        /// <summary>
        /// Gets or sets the sub cat identifier.
        /// </summary>
        /// <value>
        /// The sub cat identifier.
        /// </value>
        public string SubCatId { get; set; }
        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        [Required]
        [Display(Name = "Parent Category")]
        public string ParentId { get; set; }
        
        /// <summary>
        /// Gets or sets the Parent category title.
        /// </summary>
        /// <value>
        /// The Parent category title.
        /// </value>
        public string ParentCatTile{ get; set; }

        /// <summary>
        /// Gets or sets the category title.
        /// </summary>
        /// <value>
        /// The category title.
        /// </value>
        [Required]
        [Display(Name = "Category Title")]
        public string CategoryTitle{ get; set; }

        /// <summary>
        /// Gets or sets the sub category title.
        /// </summary>
        /// <value>
        /// The sub category title.
        /// </value>
        public string SubCategoryTitle { get; set; }

        /// <summary>
        /// Gets or sets the sub categories.
        /// </summary>
        /// <value>
        /// The sub categories.
        /// </value>
        public IList<CategoryModel> subCategories { get; set; }

        /// <summary>
        /// Gets or sets the number of cards.
        /// </summary>
        /// <value>
        /// The number of cards.
        /// </value>
        public int NumOfCards { set; get; }

        /// <summary>
        /// Gets or sets the category image.
        /// </summary>
        /// <value>
        /// The category image.
        /// </value>
        public string CategoryImage { get; set; }

        /// <summary>
        /// Gets or sets the category tags.
        /// </summary>
        /// <value>
        /// The category tags.
        /// </value>
        public string CategoryTags { get; set; }

        /// <summary>
        /// Gets or sets the Course Duration
        /// </summary>
        /// <value>
        /// The Course Duration
        /// </value>
        public double? CourseDuration { get; set; }
        /// <summary>
        /// Gets or sets the Num. Of Learners
        /// </summary>
        /// <value>
        /// The Num. Of Learners
        /// </value>
        public long? NumOfLearners { get; set; }
        /// <summary>
        /// Gets or sets the CatType
        /// </summary>
        /// <value>
        /// The type of Cat
        /// </value>
        public int CatType { get; set; }

        /// <summary>
        /// Gets or sets the CatLevel
        /// </summary>
        /// <value>
        /// The Category Level
        /// </value>
        public int CatLevel { get; set; }

        /// <summary>
        /// Gets or sets the category Description.
        /// </summary>
        /// <value>
        /// The category Description.
        /// </value>
        public string CategoryDescribe { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class CardStatsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string StudyType { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FinishTime { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfCards { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int CorrectCards { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int WrongCards { set; get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MyStatsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public MyStatsModel()
        {
            CardStats = new List<CardStatsModel>();
        }
        /// <summary>
        /// 
        /// </summary>
        public IList<CardStatsModel> CardStats {set; get;}
        /// <summary>
        /// 
        /// </summary>
        public int RevisionCount { set; get; }
        /// <summary>
        /// Gets or sets the pending sesson count.
        /// </summary>
        /// <value>
        /// The pending sesson count.
        /// </value>
        public int PendingSessonCount { set; get; }
        /// <summary>
        /// Gets or sets my card count.
        /// </summary>
        /// <value>
        /// My card count.
        /// </value>
        public int MyCardCount { set; get; }
    }

}

/*

<session id >
 <flashcards>
	<flashcard id=1 correct_answer=yes/no elapse_time="" revision_order />
 </flashcard>
</session>';

*/