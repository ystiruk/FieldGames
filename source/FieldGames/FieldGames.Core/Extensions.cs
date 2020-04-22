using System;
using System.Collections.Generic;

namespace FieldGames.Core
{
    public static class Extensions
    {
        public static IEnumerable<T> Switch<T>(this IList<T> source)
        {
            int i = 0;
            while(true)
            {
                if (source.Count == 0) throw new Exception(nameof(source));
                
                if (i == source.Count) i = 0;
                yield return source[i++];
            }
        }
    }
}
