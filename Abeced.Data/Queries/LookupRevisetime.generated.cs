﻿#pragma warning disable 1591
// <auto-generated>
//     This code was generated from a CodeSmith Generator template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using CodeSmith.Data.Linq;
using CodeSmith.Data.Linq.Dynamic;

namespace Abeced.Data
{
    /// <summary>
    /// The query extension class for LookupRevisetime.
    /// </summary>
    public static partial class LookupRevisetimeExtensions
    {
        #region Unique Results
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Abeced.Data.LookupRevisetime GetByKey(this IQueryable<Abeced.Data.LookupRevisetime> queryable
            , System.String lkuprevisetime
            )
        {
            return queryable
                .Where(l => l.Lkuprevisetime == lkuprevisetime)
                .FirstOrDefault();
        }
        
        #endregion
        
        #region By Property
        

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.Lkuprevisetime"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="lkuprevisetime">Lkuprevisetime to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByLkuprevisetime(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.String lkuprevisetime)
        {
            return queryable.Where(l => l.Lkuprevisetime == lkuprevisetime);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.Lkuprevisetime"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="lkuprevisetime">Lkuprevisetime to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByLkuprevisetime(this IQueryable<Abeced.Data.LookupRevisetime> queryable, ContainmentOperator containmentOperator, System.String lkuprevisetime)
        {
            if (lkuprevisetime == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("lkuprevisetime", "Parameter 'lkuprevisetime' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(l => l.Lkuprevisetime.Contains(lkuprevisetime));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(l => l.Lkuprevisetime.StartsWith(lkuprevisetime));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(l => l.Lkuprevisetime.EndsWith(lkuprevisetime));
                case ContainmentOperator.NotContains:
                    return queryable.Where(l => l.Lkuprevisetime.Contains(lkuprevisetime) == false);
                case ContainmentOperator.NotEquals:
                    return queryable.Where(l => l.Lkuprevisetime != lkuprevisetime);
                default:
                    return queryable.Where(l => l.Lkuprevisetime == lkuprevisetime);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.Lkuprevisetime"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="lkuprevisetime">Lkuprevisetime to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByLkuprevisetime(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.String lkuprevisetime, params System.String[] additionalValues)
        {
            var lkuprevisetimeList = new List<System.String> { lkuprevisetime };

            if (additionalValues != null)
                lkuprevisetimeList.AddRange(additionalValues);

            if (lkuprevisetimeList.Count == 1)
                return queryable.ByLkuprevisetime(lkuprevisetimeList[0]);

            return queryable.ByLkuprevisetime(lkuprevisetimeList);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.Lkuprevisetime"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByLkuprevisetime(this IQueryable<Abeced.Data.LookupRevisetime> queryable, IEnumerable<System.String> values)
        {
            return queryable.Where(l => values.Contains(l.Lkuprevisetime));
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatAfter"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="repeatAfter">RepeatAfter to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatAfter(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.Int32 repeatAfter)
        {
            return queryable.Where(l => l.RepeatAfter == repeatAfter);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatAfter"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="repeatAfter">RepeatAfter to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatAfter(this IQueryable<Abeced.Data.LookupRevisetime> queryable, ComparisonOperator comparisonOperator, System.Int32 repeatAfter)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(l => l.RepeatAfter > repeatAfter);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(l => l.RepeatAfter >= repeatAfter);
                case ComparisonOperator.LessThan:
                    return queryable.Where(l => l.RepeatAfter < repeatAfter);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(l => l.RepeatAfter <= repeatAfter);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(l => l.RepeatAfter != repeatAfter);
                default:
                    return queryable.Where(l => l.RepeatAfter == repeatAfter);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatAfter"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="repeatAfter">RepeatAfter to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatAfter(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.Int32 repeatAfter, params System.Int32[] additionalValues)
        {
            var repeatAfterList = new List<System.Int32> { repeatAfter };

            if (additionalValues != null)
                repeatAfterList.AddRange(additionalValues);

            if (repeatAfterList.Count == 1)
                return queryable.ByRepeatAfter(repeatAfterList[0]);

            return queryable.ByRepeatAfter(repeatAfterList);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatAfter"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatAfter(this IQueryable<Abeced.Data.LookupRevisetime> queryable, IEnumerable<System.Int32> values)
        {
            return queryable.Where(l => values.Contains(l.RepeatAfter));
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatCode"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="repeatCode">RepeatCode to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatCode(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.String repeatCode)
        {
            return queryable.Where(l => l.RepeatCode == repeatCode);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatCode"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="repeatCode">RepeatCode to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatCode(this IQueryable<Abeced.Data.LookupRevisetime> queryable, ContainmentOperator containmentOperator, System.String repeatCode)
        {
            if (repeatCode == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("repeatCode", "Parameter 'repeatCode' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(l => l.RepeatCode.Contains(repeatCode));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(l => l.RepeatCode.StartsWith(repeatCode));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(l => l.RepeatCode.EndsWith(repeatCode));
                case ContainmentOperator.NotContains:
                    return queryable.Where(l => l.RepeatCode.Contains(repeatCode) == false);
                case ContainmentOperator.NotEquals:
                    return queryable.Where(l => l.RepeatCode != repeatCode);
                default:
                    return queryable.Where(l => l.RepeatCode == repeatCode);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatCode"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="repeatCode">RepeatCode to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatCode(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.String repeatCode, params System.String[] additionalValues)
        {
            var repeatCodeList = new List<System.String> { repeatCode };

            if (additionalValues != null)
                repeatCodeList.AddRange(additionalValues);

            if (repeatCodeList.Count == 1)
                return queryable.ByRepeatCode(repeatCodeList[0]);

            return queryable.ByRepeatCode(repeatCodeList);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RepeatCode"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRepeatCode(this IQueryable<Abeced.Data.LookupRevisetime> queryable, IEnumerable<System.String> values)
        {
            return queryable.Where(l => values.Contains(l.RepeatCode));
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RptDescription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="rptDescription">RptDescription to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRptDescription(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.String rptDescription)
        {
            // support nulls
            return rptDescription == null 
                ? queryable.Where(l => l.RptDescription == null) 
                : queryable.Where(l => l.RptDescription == rptDescription);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RptDescription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="rptDescription">RptDescription to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRptDescription(this IQueryable<Abeced.Data.LookupRevisetime> queryable, ContainmentOperator containmentOperator, System.String rptDescription)
        {
            if (rptDescription == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("rptDescription", "Parameter 'rptDescription' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(l => l.RptDescription.Contains(rptDescription));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(l => l.RptDescription.StartsWith(rptDescription));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(l => l.RptDescription.EndsWith(rptDescription));
                case ContainmentOperator.NotContains:
                    return queryable.Where(l => l.RptDescription.Contains(rptDescription) == false);
                case ContainmentOperator.NotEquals:
                    return rptDescription == null 
                        ? queryable.Where(l => l.RptDescription != null) 
                        : queryable.Where(l => l.RptDescription != rptDescription);
                default:
                    return rptDescription == null 
                        ? queryable.Where(l => l.RptDescription == null) 
                        : queryable.Where(l => l.RptDescription == rptDescription);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RptDescription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="rptDescription">RptDescription to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRptDescription(this IQueryable<Abeced.Data.LookupRevisetime> queryable, System.String rptDescription, params System.String[] additionalValues)
        {
            var rptDescriptionList = new List<System.String> { rptDescription };

            if (additionalValues != null)
                rptDescriptionList.AddRange(additionalValues);
            else
                rptDescriptionList.Add(null);

            if (rptDescriptionList.Count == 1)
                return queryable.ByRptDescription(rptDescriptionList[0]);

            return queryable.ByRptDescription(rptDescriptionList);
        }

        /// <summary>
        /// Gets a query for <see cref="Abeced.Data.LookupRevisetime.RptDescription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<Abeced.Data.LookupRevisetime> ByRptDescription(this IQueryable<Abeced.Data.LookupRevisetime> queryable, IEnumerable<System.String> values)
        {
            // creating dynmic expression to support nulls
            var expression = DynamicExpression.BuildExpression<Abeced.Data.LookupRevisetime, bool>("RptDescription", values);
            return queryable.Where(expression);
        }
    
        #endregion
        
        #region By Association
        
        #endregion
    }
}

#pragma warning restore 1591