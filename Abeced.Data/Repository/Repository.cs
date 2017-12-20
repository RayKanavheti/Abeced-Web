using System;
using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Transform;
using NHibernate.Criterion;
using Abeced.Data;
using System.Text;

namespace Abeced.Data.Repository
{

    /// <summary>
    /// Data Repository
    /// </summary>
    public class Repository : AbecedDataContext, IRepository
    {
        /// <summary>
        /// Gets the reset request.
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns></returns>
        public PasswordReset GetResetRequest(string gid)
        {
            using (ISession session = CreateSession())
            {
                return session.Get<PasswordReset>(gid);
            }

        }

        public string GetMessageOfDay()
        {
            string msg = "";
            using (ISession session = CreateSession())
            {
                IList<Messageofday> m = session.QueryOver<Messageofday>().List();// SingleOrDefault();
                if (m.Count() != 0)
                {
                    msg = m.Where(x => x.Msgdate.Date == DateTime.Now.Date).FirstOrDefault() != null ? m.Where(x => x.Msgdate.Date == DateTime.Now.Date).FirstOrDefault().Msgtext : "";
                }
            }
            return msg;
        }

        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns></returns>
        public IList<Person> GetAllPersons()
        {
            IList<Person> _persons;
            using (ISession session = CreateSession())
            {
                _persons = session.QueryOver<Person>().List();
            }
            return _persons;
        }

        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public Person GetPerson(string userid)
        {
            Person person = null;
            using (ISession session = CreateSession())
            {
                //person = session.Get<Person>(staffid);
                person = session.QueryOver<Person>()
                   .WhereRestrictionOn(x => x.Userid).IsInsensitiveLike(userid)
                   .SingleOrDefault();
                return person;
            }

        }

        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="init">if set to <c>true</c> [initialize].</param>
        /// <returns></returns>
        public Person GetPerson(string userid, bool init)
        {
            Person person = null;
            using (ISession session = CreateSession())
            {
                //person = session.Get<Person>(staffid);
                person = session.QueryOver<Person>()
                   .WhereRestrictionOn(x => x.Userid).IsInsensitiveLike(userid)
                   .SingleOrDefault();
                return person;
            }

        }

        /// <summary>
        /// Saves the or update.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void SaveOrUpdate(object obj)
        {
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                session.SaveOrUpdate(obj);
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Save(object obj)
        {
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                session.Save(obj);
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void DeleteObject(Object obj)
        {
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                session.Delete(obj);
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="t">if set to <c>true</c> [t].</param>
        /// <returns></returns>
        public bool DeleteObject(Object obj, bool t = false)
        {
            bool res = false;
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                session.Delete(obj);
                session.Transaction.Commit();
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Deletes the cards.
        /// </summary>
        /// <param name="catg">The category.</param>
        public void DeleteCards(string catg)
        {
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                IList<Flashcard> cards = session.QueryOver<Flashcard>().Where(x => x.Category == catg).List();
                foreach (var flsh in cards)
                    session.Delete(flsh);
                //session.Delete("from FlashCards o where o.Category= "+ catg);
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Saves the or update.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void SaveOrUpdate(object[] obj)
        {
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                foreach (var o in obj)
                {
                    session.SaveOrUpdate(o);
                }
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Save(object[] obj)
        {
            using (ISession session = CreateSession())
            {
                session.BeginTransaction();
                foreach (var o in obj)
                {
                    session.Save(o);
                }
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Gets the flash card.
        /// </summary>
        /// <param name="cardid">The card id.</param>
        /// <returns></returns>
        public Flashcard GetFlashCard(string cardid)
        {
            Flashcard flashcard = null;
            using (ISession session = CreateSession())
            {
                flashcard = session.Get<Flashcard>(cardid);

                return flashcard;
            }
        }

        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <param name="sessionid">The session id.</param>
        /// <returns></returns>
        public IList<Flashcard> GetFlashCardList(string sessionid)
        {
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>().Where(x => x.UploadedBy == sessionid).List();
            }
            return _flash;
        }

        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <returns></returns>
        public IList<Flashcard> GetFlashCardList()
        {
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>().List();
            }
            return _flash;
        }

        /// <summary>
        /// Gets the pending flash card list.
        /// </summary>
        /// <returns></returns>
        public IList<Flashcard> GetPendingFlashCardList()
        {
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>().Where(x => x.Approved != true).List();
            }
            return _flash;
        }

        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <param name="numb">The number of cards to fetch.</param>
        /// <param name="catg">The category.</param>
        /// <returns></returns>
        public IList<Flashcard> GetFlashCardList(int numb, string catg)
        {
            /*  Select Random rows
             * 
             * var query = 
            "SELECT TOP 5 u.UserId, u.UserName, p.ImageFileName " +
            "FROM users as u, profiles as p " +
            "WHERE u.UserId = p.UserId ORDER BY NEWID()";

                ISQLQuery qry = session.CreateSQLQuery(query).AddEntity(typeof(User));
                List<User> rndUsers = qry.List<User>();
             * 
             * */
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                if (numb != 0)
                {
                    _flash = session.QueryOver<Flashcard>()
                        .Where(x => x.Category == catg).Take(numb).List();
                }
                else
                {
                    _flash = session.QueryOver<Flashcard>()
                                            .Where(x => x.Category == catg).List();
                }
            }
            return _flash;
        }

        /// <summary>
        /// Gets the flash card list.
        /// </summary>
        /// <param name="ids">The card ids.</param>
        /// <returns></returns>
        public IList<Flashcard> GetFlashCardList(string[] ids)
        {
            /*  Select Random rows
             * 
                List<Book> books = session.CreateCriteria(typeof(Book)).
               Add(Restrictions.In("Title", titles)).
               List<Book>().ToList<Book>();
               return books; 
             * */
            IList<Flashcard> _flash = null;
            using (ISession session = CreateSession())
            {
                _flash = session.CreateCriteria(typeof(Flashcard))
                    .Add(Restrictions.In("Identification", ids))
                    .List<Flashcard>().ToList<Flashcard>();
            }
            return _flash;
        }

        /// <summary>
        /// Gets all flash card list.
        /// </summary>
        /// <param name="catg">The category.</param>
        /// <returns></returns>
        public IList<Flashcard> GetAllFlashCardList(string catg)
        {
            /*  Select Random rows
             * 
             * var query = 
            "SELECT TOP 5 u.UserId, u.UserName, p.ImageFileName " +
            "FROM users as u, profiles as p " +
            "WHERE u.UserId = p.UserId ORDER BY NEWID()";

                ISQLQuery qry = session.CreateSQLQuery(query).AddEntity(typeof(User));
                List<User> rndUsers = qry.List<User>();
             * 
             * */
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>()
                    .Where(x => x.Category == catg).List();
            }
            return _flash;
        }

        /// <summary>
        /// Gets my flash cards.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="catg">The category.</param>
        /// <returns></returns>
        public IList<Flashcard> GetMyFlashCards(string userid, string catg)
        {
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>()
                    .Where(x => x.UploadedBy == userid && x.Category == catg).List();
            }
            return _flash;
        }

        /// <summary>
        /// Gets my flash cards.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public IList<Flashcard> GetMyFlashCards(string userid)
        {
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>()
                    .Where(x => x.UploadedBy == userid).List();
            }
            return _flash;
        }

        /// <summary>
        /// Gets all flash card list.
        /// </summary>
        /// <param name="catg">The category.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public IList<Flashcard> GetAllFlashCardList(string catg, List<string> ids)
        {
            /*  Select Random rows
             * 
             * var query = 
            "SELECT TOP 5 u.UserId, u.UserName, p.ImageFileName " +
            "FROM users as u, profiles as p " +
            "WHERE u.UserId = p.UserId ORDER BY NEWID()";

                ISQLQuery qry = session.CreateSQLQuery(query).AddEntity(typeof(User));
                List<User> rndUsers = qry.List<User>();
             * 
             * */
            //Colors.Where(c => Dogs.Any(d => d.Color.Id == c.Id))
            IList<Flashcard> _flash;
            using (ISession session = CreateSession())
            {
                _flash = session.QueryOver<Flashcard>()
                    .Where(x => x.Category == catg).List();
            }

            _flash = (from card in _flash
                      where (ids.Contains(card.Identification))
                      select card).ToList();

            return _flash;
        }

        /// <summary>
        /// Gets the category list.
        /// </summary>
        /// <returns></returns>
        public IList<LookupCategory> GetCategoryList()
        {
            IList<LookupCategory> _cat;
            using (ISession session = CreateSession())
            {
                _cat = session.QueryOver<LookupCategory>().List();
                foreach (var catg in _cat)
                {
                    NHibernateUtil.Initialize(catg.LookupSubcategoryList);
                    foreach(var c in catg.LookupSubcategoryList)
                    {
                        NHibernateUtil.Initialize(c.LookupSubcategoryList);
                    }
                }
            }
            return _cat;
        }

        /// <summary>
        /// Gets the category list.
        /// </summary>
        /// <param name="init">if set to <c>true</c> [initialize].</param>
        /// <returns></returns>
        public IList<LookupCategory> GetCategoryList(bool init)
        {
            IList<LookupCategory> _cat;
            using (ISession session = CreateSession())
            {
                _cat = session.QueryOver<LookupCategory>().List();
            }
            return _cat;
        }

        /// <summary>
        /// Gets the sub category list.
        /// </summary>
        /// <param name="init">if set to <c>true</c> [initialize].</param>
        /// <returns></returns>
        public IList<LookupSubcategory> GetSubCategoryList(bool init)
        {
            IList<LookupSubcategory> _cat;
            using (ISession session = CreateSession())
            {
                _cat = session.QueryOver<LookupSubcategory>().List();
            }
            return _cat;
        }

        /// <summary>
        /// Gets the sub category list.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <returns></returns>
        public IList<LookupSubcategory> GetSubCategoryList(string catid)
        {
            IList<LookupSubcategory> _cat;
            using (ISession session = CreateSession())
            {
                if(catid=="0")
                {
                    _cat = session.QueryOver<LookupSubcategory>().OrderBy(m=>m.LookupCategory).Asc.List();
                    foreach (var cc in _cat)
                    {
                        NHibernateUtil.Initialize(cc.LookupCategory);
                    }
                }
                else {
                    _cat = session.QueryOver<LookupSubcategory>()
                        .Where(x => x.LookupCategory.Catid == catid || x.LookupSubcategoryMember.Subcatid==catid).List();
                    foreach (var cc in _cat)
                    {
                        NHibernateUtil.Initialize(cc.LookupCategory);
                    }
                }
            }
            return _cat;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public LookupCategory GetCategory(string id)
        {
            LookupCategory lkup = new LookupCategory();
            using (ISession session = CreateSession())
            {
                lkup = session.Get<LookupCategory>(id);

            }
            return lkup;
        }

        /// <summary>
        /// Gets the parent category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="obj">if set to <c>true</c> [object].</param>
        /// <returns></returns>
        public LookupCategory GetParentCategory(string id, bool obj)
        {
            LookupSubcategory lkup = new LookupSubcategory();
            using (ISession session = CreateSession())
            {
                lkup = session.Get<LookupSubcategory>(id);

            }
            NHibernateUtil.Initialize(lkup.LookupCategory);
            return lkup.LookupCategory;
        }

        /// <summary>
        /// Gets the parent category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public String GetParentCategory(string id)
        {
            LookupSubcategory lkup = new LookupSubcategory();
            using (ISession session = CreateSession())
            {
                lkup = session.Get<LookupSubcategory>(id);

            }
            return lkup.LookupCategory.Catid;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public LookupSubcategory GetSubCategory(string id, bool parent=false)
        {
            LookupSubcategory lkup = new LookupSubcategory();
            using (ISession session = CreateSession())
            {
                lkup = session.Get<LookupSubcategory>(id);
                if(parent==true && lkup !=null)
                {
                    NHibernateUtil.Initialize(lkup.LookupCategory);
                }

            }

            return lkup;
        }

        /// <summary>
        /// Gets the revision.
        /// </summary>
        /// <param name="csession">The card session.</param>
        /// <returns></returns>
        public CardRevision GetRevision(string csession)
        {
            CardRevision _revise = new CardRevision();
            using (ISession session = CreateSession())
            {
                _revise = session.Get<CardRevision>(csession);

                if (_revise != null)
                    NHibernateUtil.Initialize(_revise.Cardsession);
            }
            return _revise;

        }

        /// <summary>
        /// Gets the card session.
        /// </summary>
        /// <param name="csession">The card session.</param>
        /// <returns></returns>
        public Cardsession GetCardSession(string csession)
        {
            Cardsession _revise = new Cardsession();
            using (ISession session = CreateSession())
            {
                _revise = session.Get<Cardsession>(csession);
                if (_revise != null)
                    NHibernateUtil.Initialize(_revise.CardRevisionList);
            }
            return _revise;

        }

        /// <summary>
        /// Gets the user session list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public IList<Cardsession> GetUserSessionList(string userid)
        {
            IList<Cardsession> _sess = new List<Cardsession>();
            using (ISession session = CreateSession())
            {
                _sess = session.QueryOver<Cardsession>()
                    .Where(x => x.Userid == userid).List();
                foreach (var rev in _sess)
                    NHibernateUtil.Initialize(rev.CardRevisionList);
            }
            return _sess;
        }

        /// <summary>
        /// Gets the user revision list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public IList<CardRevision> GetUserRevisionList(string userid)
        {
            IList<CardRevision> _sess;
            using (ISession session = CreateSession())
            {
                _sess = session.QueryOver<CardRevision>()
                    .Where(x => x.Userid == userid).List();
            }
            return _sess;
        }

        /// <summary>
        /// Gets the user revision list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="catg">The category.</param>
        /// <returns></returns>
        public IList<CardRevision> GetUserRevisionList(string userid, string catg)
        {
            IList<CardRevision> _sess;
            using (ISession session = CreateSession())
            {
                _sess = session.QueryOver<CardRevision>()
                    .Where(x => x.Userid == userid && x.Category == catg).List();
            }
            return _sess;
        }

        /// <summary>
        /// Gets the user session list.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public IList<Cardsession> GetUserSessionList(string userid, string category)
        {
            IList<Cardsession> _sess;
            using (ISession session = CreateSession())
            {
                _sess = session.QueryOver<Cardsession>()
                    .Where(x => x.Userid == userid && x.Category == category).List();
                foreach (var rev in _sess)
                    NHibernateUtil.Initialize(rev.CardRevisionList);
            }
            return _sess;
        }

        /// <summary>
        /// Gets the flash card count.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <returns></returns>
        public int GetFlashCardCount(string catid)
        {
            using (ISession session = CreateSession())
            {
                return session.QueryOver<Flashcard>().Where(x => x.Category == catid).RowCount();
            }
        }

        /// <summary>
        /// Gets the revision time list.
        /// </summary>
        /// <returns></returns>
        public IList<LookupRevisetime> GetRevisionTimeList()
        {
            using (ISession session = CreateSession())
            {
                return session.QueryOver<LookupRevisetime>().List();
            }
        }

        /// <summary>
        /// Gets the revision time.
        /// </summary>
        /// <param name="rtime">The revision time.</param>
        /// <returns></returns>
        public LookupRevisetime GetRevisionTime(string rtime)
        {
            LookupRevisetime rt = null;
            using (ISession session = CreateSession())
            {
                rt = session.Get<LookupRevisetime>(rtime);
            }
            return rt;
        }

        /// <summary>
        /// Gets the revision time.
        /// </summary>
        /// <param name="rtime">The revision time.</param>
        /// <returns></returns>
        public LookupRevisetime GetRevisionTime(int rtime)
        {
            string id = rtime < 0 ? "-" + Math.Abs(rtime).ToString() : rtime.ToString();
            LookupRevisetime rt = null;
            using (ISession session = CreateSession())
            {
                rt = session.Get<LookupRevisetime>(id);
            }
            return rt;
        }


        /// <summary>
        /// Messages the of day list.
        /// </summary>
        /// <returns></returns>
        public IList<Messageofday> MessageOfDayList()
        {
            using (ISession session = CreateSession())
            {
                return session.QueryOver<Messageofday>().List();
            }
        }

        /// <summary>
        /// Gets the message of day.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public Messageofday GetMessageOfDay(DateTime dt)
        {
            Messageofday mod = null;
            using (ISession session = CreateSession())
            {
                IList<Messageofday> mm = session.QueryOver<Messageofday>().Where(x => x.Msgdate.Date == dt.Date).List();
                if (mm.Count() > 0)
                {
                    mod = mm.SingleOrDefault();
                }
            }
            return mod;
        }

        /// <summary>
        /// Gets the message of day.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Messageofday GetMessageOfDay(string id)
        {
            Messageofday mod = null;
            using (ISession session = CreateSession())
            {
                mod = session.Get<Messageofday>(id);

            }
            return mod;
        }

        //public IEnumerable<> GetAllTree()
        //{
        //    var query = from row in db.Categories

        //                select new Category

        //                {

        //                    CatID = row.CatID,

        //                    PatID = row.PatID,

        //                    CategoryN = row.CategoryN,

        //                    Children = (from cat in db.Categories

        //                                where cat.PatID == row.CatID

        //                                select cat)

        //                };

        //}


    }

    //public class RandomOrder : Order
    //{
    //    public RandomOrder() : base("", true) { }
    //    public override SqlString ToSqlString(
    //        ICriteria criteria, ICriteriaQuery criteriaQuery)
    //    {
    //        return new SqlString("RAND()");
    //    }

    //    public IList<CmsTestimonial> GetRandomTestimonials(int count)
    //    {
    //        ICriteria criteria = Session
    //          .CreateCriteria(typeof(CmsTestimonial))
    //          .AddOrder(new RandomOrder())
    //          .SetMaxResults(count);
    //        return criteria.List<CmsTestimonial>();
    //    }
    //    public CmsTestimonial GetRandomTestimonial()
    //    {
    //        ICriteria criteria = Session
    //          .CreateCriteria(typeof(CmsTestimonial))
    //          .AddOrder(new RandomOrder())
    //          .SetMaxResults(1);
    //        return criteria.UniqueResult<CmsTestimonial>();
    //    }
    //}

    //public static class NHibernateExtensions
    //{
    //    public static IQueryOver<TRoot, TSubType>
    //        OrderByRandom<TRoot, TSubType>(
    //          this IQueryOver<TRoot, TSubType> query)
    //    {
    //        query.UnderlyingCriteria.AddOrder(new RandomOrder());
    //        return query;
    //    }
    //}

    //public IList<CmsTestimonial> GetRandomTestimonials(int count) {  
    //return Session  
    //.QueryOver<CmsTestimonial>()  
    //.OrderByRandom()  
    //.Take(count)  
    //.List();  } 


}
