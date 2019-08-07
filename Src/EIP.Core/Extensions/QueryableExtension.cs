using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Core.Extensions
{
    public static class QueryableExtension
    {
        public static PageResult<TSource> ToPagedList<TSource>(this IQueryable<TSource> source,
            int draw,
            int skipCount,
            int pageSize) where TSource : class
        {
            var result = new PageResult<TSource>
            {
                Draw = draw,
                RecordsTotal = source.Count(),
            };

            if (pageSize <= 0)
            {
                result.Data = source.ToList();
                return result;
            }

            result.Data = source.Skip(skipCount).Take(pageSize).ToList();

            return result;
        }

        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source,
            string filter, Expression<Func<TSource, bool>> predicate)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                source = source.Where(predicate);
            }

            return source;
        }
    }
}
