using System;
using System.Collections.Generic;

namespace Ordering
{
    // This comparer is used to perform case insensitive string comparison 
    // in the comparer samples. See:
    //    OrderBy-Comparer-Sample-1.cs
    //    OrderByDescending-Comparer-Sample-1.cs
    //    ThenBy-Comparer-Sample-1.cs
    //    ThenByDescending-Comparer-Sample-2.cs
    public class CaseInsensitiveComparer : IComparer<string> 
    { 
        public int Compare(string x, string y) 
        { 
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase); 
        } 
    }
}
