using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NHibernate;

namespace Abeced.Data
{
    /// <summary>
    /// Abeced Data Context
    /// </summary>
    public partial class AbecedDataContext
    {
        // Place your custom code here.
        
        #region Override Methods

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns></returns>
        protected override string GetConnectionString(string databaseName)
        {
            return base.GetConnectionString(databaseName);
        }

        #endregion
    }
}