using System;

class Base {}
class Derived : Base {}

class Example
{
    static void Main()
    {
        //<Snippet1>
        Action<Base> b = (target) => { Console.WriteLine(target.GetType().Name); };
        Action<Derived> d = b;
        d(new Derived());
        //</Snippet1>
    }
}
