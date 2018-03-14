    class SafeCasting
    {
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

        static void Main()
        {
            SafeCasting app = new SafeCasting();

            // Use the is operator to verify the type.
            // before performing a cast.
            Giraffe g = new Giraffe();
            app.UseIsOperator(g);

            // Use the as operator and test for null
            // before referencing the variable.
            app.UseAsOperator(g);

            // Use the as operator to test
            // an incompatible type.
            SuperNova sn = new SuperNova();
            app.UseAsOperator(sn);

            // Use the as operator with a value type.
            // Note the implicit conversion to int? in 
            // the method body.
            int i = 5;
            app.UseAsWithNullable(i);


            double d = 9.78654;
            app.UseAsWithNullable(d);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        void UseIsOperator(Animal a)
        {
            if (a is Mammal)
            {
                Mammal m = (Mammal)a;
                m.Eat();
            }
        }

        void UseAsOperator(object o)
        {
            Mammal m = o as Mammal;
            if (m != null)
            {
                Console.WriteLine(m.ToString());
            }
            else
            {
                Console.WriteLine("{0} is not a Mammal", o.GetType().Name);
            }
        }

        void UseAsWithNullable(System.ValueType val)
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