using System;
using System.Collections.Generic;

namespace Equality
{
    // This comparer is used to perform case insensitive string comparison 
    // in the comparer samples. See:
    //    SequenceEqual-Comparer-Sample-1.cs
    public class CaseInsensitiveComparer : IEqualityComparer<string>
    { 
        bool IEqualityComparer<string>.Equals(string x, string y)
        {
             return string.Equals(x, y, StringComparison.OrdinalIgnoreCase); 
        }

        int IEqualityComparer<string>.GetHashCode(string obj)
        {
            if (obj == null) return 0;
            return obj.ToLower().GetHashCode();
        }
    }
}
