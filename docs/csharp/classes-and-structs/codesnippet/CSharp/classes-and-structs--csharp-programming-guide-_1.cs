    namespace ProgrammingGuide
    {
        // Class definition.
        public class MyCustomClass
        {
            // Class members:
            // Property.
            public int Number { get; set; }

            // Method.
            public int Multiply(int num)
            {
                return num * Number;
            }

            // Instance Constructor.
            public MyCustomClass()
            {
                Number = 0;
            }
        }
        // Another class definition. This one contains
        // the Main method, the entry point for the program.
        class Program
        {
            static void Main(string[] args)
            {
                // Create an object of type MyCustomClass.
                MyCustomClass myClass = new MyCustomClass();

                // Set the value of a public property.
                myClass.Number = 27;

                // Call a public method.
                int result = myClass.Multiply(4);
            }
        }
    }
