using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abeced.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the reset request.
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns></returns>
        PasswordReset GetResetRequest(string gid);
        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns></returns>
        IList<Person> GetAllPersons();
        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        Person GetPerson(string userid); //more deatils
        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="init">if set to <c>true</c> [initialize].</param>
        /// <returns></returns>
        Person GetPerson(string userid, bool init); //no init

        /// <summary>
        /// Saves the or update.
        /// </summary>
        /// <param name="obj">The object.</param>
        void SaveOrUpdate(Object obj);
        /// <summary>
        /// Saves the or update.
        /// </summary>
        /// <param name="obj">The object.</param>
        void SaveOrUpdate(object[] obj);
        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Save(object obj);
        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Save(object[] obj);
        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void DeleteObject(Object obj);
        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="t">if set to <c>true</c> [t].</param>
        /// <returns></returns>
        bool DeleteObject(Object obj, bool t=false);
        /// <summary>
        /// Deletes the cards.
        /// </summary>
        /// <param name="catg">The catg.</param>
        void DeleteCards(string catg);

        /// <summary>
        /// Gets the flash card.
        /// </summary>
        /// <param name="cardid">The cardid.</param>
        /// <returns></returns>
        Flashcard GetFlashCard(string cardid);
        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <param name="sessionid">The sessionid.</param>
        /// <returns></returns>
        IList<Flashcard> GetFlashCardList(string sessionid);

        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        IList<Flashcard> GetFlashCardList(string[] ids);
        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <param name="numb">The numb.</param>
        /// <param name="catg">The catg.</param>
        /// <returns></returns>
        IList<Flashcard> GetFlashCardList(int numb, string catg);
        /// <summary>
        /// Gets all flash card list.
        /// </summary>
        /// <param name="catg">The catg.</param>
        /// <returns></returns>
        IList<Flashcard> GetAllFlashCardList(string catg);
        /// <summary>
        /// Gets all flash card list.
        /// </summary>
        /// <param name="catg">The catg.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        IList<Flashcard> GetAllFlashCardList(string catg, List<string> ids);

        /// <summary>
        /// Gets my flash cards.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="catg">The catg.</param>
        /// <returns></returns>
        IList<Flashcard> GetMyFlashCards(string userid, string catg);
        /// <summary>
        /// Gets my flash cards.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        IList<Flashcard> GetMyFlashCards(string userid);

        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <returns></returns>
        IList<Flashcard> GetFlashCardList();
        /// <summary>
        /// Gets the pending flash card list.
        /// </summary>
        /// <returns></returns>
        IList<Flashcard> GetPendingFlashCardList();
        /// <summary>
        /// Gets the category list.
        /// </summary>
        /// <returns></returns>
        IList<LookupCategory> GetCategoryList();
        /// <summary>
        /// Gets the category list.
        /// </summary>
        /// <param name="init">if set to <c>true</c> [initialize].</param>
        /// <returns></returns>
        IList<LookupCategory> GetCategoryList(bool init);

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        LookupCategory GetCategory(string id);
        //LookupCategory GetCategoryName(string id);
        /// <summary>
        /// Gets the parent category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="obj">if set to <c>true</c> [object].</param>
        /// <returns></returns>
        LookupCategory GetParentCategory(string id, bool obj);
        /// <summary>
        /// Gets the parent category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        String GetParentCategory(string id);
        ///// <summary>
        ///// Gets the sub category.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        //LookupSubcategory GetSubCategory(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        LookupSubcategory GetSubCategory(string id, bool parent = false);

        /// <summary>
        /// Gets the sub category list.
        /// </summary>
        /// <param name="catid">The catid.</param>
        /// <returns></returns>
        IList<LookupSubcategory> GetSubCategoryList(string catid);

        /// <summary>
        /// Gets the revision time list.
        /// </summary>
        /// <returns></returns>
        IList<LookupRevisetime> GetRevisionTimeList();
        /// <summary>
        /// Gets the revision time.
        /// </summary>
        /// <param name="rtime">The rtime.</param>
        /// <returns></returns>
        LookupRevisetime GetRevisionTime(string rtime);
        /// <summary>
        /// Gets the revision time.
        /// </summary>
        /// <param name="rtime">The rtime.</param>
        /// <returns></returns>
        LookupRevisetime GetRevisionTime(int rtime);


        /// <summary>
        /// Gets the sub category list.
        /// </summary>
        /// <param name="init">if set to <c>true</c> [initialize].</param>
        /// <returns></returns>
        IList<LookupSubcategory> GetSubCategoryList(bool init);
        /// <summary>
        /// Gets the flash card count.
        /// </summary>
        /// <param name="catid">The catid.</param>
        /// <returns></returns>
        int GetFlashCardCount(string catid);

        /// <summary>
        /// Gets the revision.
        /// </summary>
        /// <param name="csession">The csession.</param>
        /// <returns></returns>
        CardRevision GetRevision(string csession);
        /// <summary>
        /// Gets the card session.
        /// </summary>
        /// <param name="csession">The csession.</param>
        /// <returns></returns>
        Cardsession GetCardSession(string csession);

        /// <summary>
        /// Gets the user session list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        IList<Cardsession> GetUserSessionList(string userid);
        /// <summary>
        /// Gets the user session list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        IList<Cardsession> GetUserSessionList(string userid, string category);

        /// <summary>
        /// Gets the user revision list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        IList<CardRevision> GetUserRevisionList(string userid);
        /// <summary>
        /// Gets the user revision list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="catg">The catg.</param>
        /// <returns></returns>
        IList<CardRevision> GetUserRevisionList(string userid, string catg);
        /// <summary>
        /// Gets the message of day.
        /// </summary>
        /// <returns></returns>
        string GetMessageOfDay();
        /// <summary>
        /// Messages the of day list.
        /// </summary>
        /// <returns></returns>
        IList<Messageofday> MessageOfDayList();
        /// <summary>
        /// Gets the message of day.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        Messageofday GetMessageOfDay(DateTime dt);
        /// <summary>
        /// Gets the message of day.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Messageofday GetMessageOfDay(string id);
        //Cardsession GetUserSession(string sessid);

    }
}
