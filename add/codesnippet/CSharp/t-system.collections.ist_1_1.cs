using System;
using System.Collections;
using System.Collections.Generic;

public class NanComparer : IEqualityComparer
{
   public new bool Equals(object x, object y)
   {
      if (x is float)
         return (float) x == (float) y;
      else if (x is double)
         return (double) x == (double) y;
      else
         return EqualityComparer<object>.Default.Equals(x, y);
   }
   
   public int GetHashCode(object obj)
   {
      return EqualityComparer<object>.Default.GetHashCode(obj);
   }
}