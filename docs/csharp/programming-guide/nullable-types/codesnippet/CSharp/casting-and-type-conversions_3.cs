    
    using System;

    class Animal
    {
        public void Eat() { Console.WriteLine("Eating."); }
        public override string ToString()
        {
            return "I am an animal.";
        }
    }
    class Reptile : Animal { }
    class Mammal : Animal { }

    class UnSafeCast
    {
        static void Main()
        {            
            Test(new Mammal());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        static void Test(Animal a)
        {
            // Cause InvalidCastException at run time 
            // because Mammal is not convertible to Reptile.
            Reptile r = (Reptile)a;
        }

    }