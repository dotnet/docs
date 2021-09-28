using System;
using System.Collections.Generic;

class Base {}
class Derived : Base {}

class C
{
    public static void Main()
    {
        //<Snippet1>
        IEnumerable<Derived> d = new List<Derived>();
        IEnumerable<Base> b = d;
        //</Snippet1>
    }
}
