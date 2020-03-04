using System;

namespace patternmatching
{
    // <SnippetPatternMatchingIs>
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
            Giraffe g = new Giraffe();
            FeedMammals(g);

            TestForMammals(g);

            SuperNova sn = new SuperNova();
            TestForMammals(sn);
        }

        static void FeedMammals(Animal a)
        {
            // Use the is operator to verify the type
            // before performing a cast.
            if (a is Mammal m)
            {
                m.Eat();
            }
        }

        static void TestForMammals(object o)
        {
            // Alternatively, use the as operator and test for null
            // before referencing the variable.
            if (o is Mammal m)
            {
                Console.WriteLine(m.ToString());
            }
            else
            {
                // variable 'm' is not in scope here, and can't be used.
                Console.WriteLine($"{o.GetType().Name} is not a Mammal");
            }
        }
    }
    // </SnippetPatternMatchingIs>
}
