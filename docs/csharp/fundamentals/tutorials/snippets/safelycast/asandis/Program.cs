using System;

namespace asandis
{
    // <SnippetIsAndAs>
    class Animal
    {
        public void Eat() { Console.WriteLine("Eating."); }
        public override string ToString()
        {
            return "I am an animal.";
        }
    }
    class Mammal : Animal { }
    class Giraffe : Mammal { }

    class SuperNova { }

    class Program
    {
        static void Main(string[] args)
        {
            // Use the is operator to verify the type.
            // before performing a cast.
            Giraffe g = new Giraffe();
            UseIsOperator(g);

            // Use the as operator and test for null
            // before referencing the variable.
            UseAsOperator(g);

            // Use the as operator to test
            // an incompatible type.
            SuperNova sn = new SuperNova();
            UseAsOperator(sn);

            // Use the as operator with a value type.
            // Note the implicit conversion to int? in
            // the method body.
            int i = 5;
            UseAsWithNullable(i);

            double d = 9.78654;
            UseAsWithNullable(d);
        }

        static void UseIsOperator(Animal a)
        {
            if (a is Mammal)
            {
                Mammal m = (Mammal)a;
                m.Eat();
            }
        }

        static void UsePatternMatchingIs(Animal a)
        {
            if (a is Mammal m)
            {
                m.Eat();
            }
        }

        static void UseAsOperator(object o)
        {
            Mammal m = o as Mammal;
            if (m != null)
            {
                Console.WriteLine(m.ToString());
            }
            else
            {
                Console.WriteLine($"{o.GetType().Name} is not a Mammal");
            }
        }

        static void UseAsWithNullable(System.ValueType val)
        {
            int? j = val as int?;
            if (j != null)
            {
                Console.WriteLine(j);
            }
            else
            {
                Console.WriteLine("Could not convert " + val.ToString());
            }
        }
    }
    // </SnippetIsAndAs>
}
