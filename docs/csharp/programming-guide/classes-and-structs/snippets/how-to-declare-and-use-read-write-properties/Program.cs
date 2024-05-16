using System;

namespace Properties
{
    //<Snippet1>
    class Person
    {
        private string _name = "N/A";
        private int _age = 0;

        // Declare a Name property of type string:
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                //<Snippet4>
                _name = value;
                //</Snippet4>
            }
        }

        // Declare an Age property of type int:
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        //<Snippet6>
        public override string ToString()
        {
            return "Name = " + Name + ", Age = " + Age;
        }
        //</Snippet6>
    }

    public class Wrapper
    {
        private string _name = "N/A";
        //<Snippet2>
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                //<Snippet4>
                _name = value;
                //</Snippet4>
            }
        }
        //</Snippet2>

    }

    class TestPerson
    {
        static void Main()
        {
            // Create a new Person object:
            Person person = new Person();

            // Print out the name and the age associated with the person:
            Console.WriteLine("Person details - {0}", person);

            // Set some values on the person object:
            //<Snippet3>
            person.Name = "Joe";
            person.Age = 99;
            //</Snippet3>
            Console.WriteLine("Person details - {0}", person);

            // Increment the Age property:
            //<Snippet5>
            person.Age += 1;
            //</Snippet5>
            Console.WriteLine("Person details - {0}", person);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Person details - Name = N/A, Age = 0
        Person details - Name = Joe, Age = 99
        Person details - Name = Joe, Age = 100
    */
    //</Snippet1>
}
