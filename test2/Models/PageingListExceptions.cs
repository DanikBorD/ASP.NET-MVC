using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2.Models
{
    public static class PagedListExtentions
    {
        //public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        //{
        //    return new PagedList<T>(source, index, pageSize);
        //}

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }
}