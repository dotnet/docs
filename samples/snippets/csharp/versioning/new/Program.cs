using System;

class Program
{
    #region sample
    public class BaseClass
    {
        public void MyMethod()
        {
            Console.WriteLine("A base method");
        }
    }

    public class DerivedClass : BaseClass
    {
        public new void MyMethod()
        {
            Console.WriteLine("A derived method");
        }
    }

    public static void Main()
    {
        BaseClass b = new BaseClass();
        DerivedClass d = new DerivedClass();

        b.MyMethod();
        d.MyMethod();
    }
    #endregion
}
