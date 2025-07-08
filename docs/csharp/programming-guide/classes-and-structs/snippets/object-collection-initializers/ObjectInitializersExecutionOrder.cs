using System;

namespace object_collection_initializers;

// <ObjectInitializersExecutionOrder>
public class ObjectInitializersExecutionOrder
{
    public static void Main()
    {
        new Person { FirstName = "Paisley", LastName = "Smith", City = "Dallas" };
        new Dog(2) { Name = "Mike" };
    }

    public class Dog
    {
        private int age;
        private string name;

        public Dog(int age)
        {
            Console.WriteLine("Hello from Dog's non-parameterless constructor");
            this.age = age;
        }

        public required string Name
        {
            get { return name; }

            set
            {
                Console.WriteLine("Hello from setter of Dog's required property 'Name'");
                name = value;
            }
        }
    }

    public class Person
    {
        private string firstName;
        private string lastName;
        private string city;

        public Person()
        {
            Console.WriteLine("Hello from Person's parameterless constructor");
        }

        public required string FirstName
        {
            get { return firstName; }

            set
            {
                Console.WriteLine("Hello from setter of Person's required property 'FirstName'");
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }

            init
            {
                Console.WriteLine("Hello from setter of Person's init property 'LastName'");
                lastName = value;
            }
        }

        public string City
        {
            get { return city; }

            set
            {
                Console.WriteLine("Hello from setter of Person's property 'City'");
                city = value;
            }
        }
    }

    // Output:
    // Hello from Person's parameterless constructor
    // Hello from setter of Person's required property 'FirstName'
    // Hello from setter of Person's init property 'LastName'
    // Hello from setter of Person's property 'City'
    // Hello from Dog's non-parameterless constructor
    // Hello from setter of Dog's required property 'Name'
}
// </ObjectInitializersExecutionOrder>
