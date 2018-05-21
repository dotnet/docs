    
    class csrefKeywordsOperators
    {
        class Base
        {
            public override string  ToString()
            {
 	             return "Base";
            }
        }
        class Derived : Base 
        { }

        class Program
        {
            static void Main()
            {

                Derived d = new Derived();

                Base b = d as Base;
                if (b != null)
                {
                    Console.WriteLine(b.ToString());
                }

            }
        }
    }