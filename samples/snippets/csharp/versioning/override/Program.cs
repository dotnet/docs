using System;

class Program
{
#region sample
    public class MyBaseClass
    {
        public virtual string MethodOne()
        {
            return "Method One";
        }
    }

    public class MyDerivedClass : MyBaseClass
    {
        public override string MethodOne()
        {
            return "Derived Method One";
        }
    }

    public static void Main()
    {
        MyBaseClass b = new MyBaseClass();
        MyDerivedClass d = new MyDerivedClass();

        Console.WriteLine($"Base Method One: {b.MethodOne()}");
        Console.WriteLine($"Derived Method One: {d.MethodOne()}");
    }
#endregion
}
