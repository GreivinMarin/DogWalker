using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DogWalker.Core.Helpers
{
    public static class WalkSearchHelper
    {
        public static List<T> SortList<T>(IEnumerable<T> source, string propertyName, bool ascending)
        {
            if (string.IsNullOrWhiteSpace(propertyName) || source == null)
                return source?.ToList() ?? new List<T>();

            var propInfo = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (propInfo == null)
                throw new ArgumentException($"Property '{propertyName}' not found on type {typeof(T).Name}");

            return ascending
                ? source.OrderBy(x => propInfo.GetValue(x, null)).ToList()
                : source.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
        }
    }
}
