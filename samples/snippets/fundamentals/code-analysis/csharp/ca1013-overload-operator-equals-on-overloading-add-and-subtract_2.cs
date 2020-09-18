using System;

namespace DesignLibrary
{
    public class TestAddableTypes
    {
       public static void Main()
       {
          BadAddableType a = new BadAddableType(2,2);
          BadAddableType b = new BadAddableType(2,2);
          BadAddableType x = new BadAddableType(9,9);
          GoodAddableType c = new GoodAddableType(3,3);
          GoodAddableType d = new GoodAddableType(3,3);
          GoodAddableType y = new GoodAddableType(9,9);
    
          Console.WriteLine("Bad type:  {0} {1} are equal? {2}", a,b, a.Equals(b)? "Yes":"No");
          Console.WriteLine("Good type: {0} {1} are equal? {2}", c,d, c.Equals(d)? "Yes":"No");
          Console.WriteLine("Good type: {0} {1} are == ?   {2}", c,d, c==d? "Yes":"No");
          Console.WriteLine("Bad type:  {0} {1} are equal? {2}", a,x, a.Equals(x)? "Yes":"No");
          Console.WriteLine("Good type: {0} {1} are == ?   {2}", c,y, c==y? "Yes":"No");
       }
    }
}