using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.ComponentModel;

namespace N1
{
    class Program
    {
        static void Test(string[] args)
        {
            //<Snippet1>
            dynamic sampleObject = new ExpandoObject();
            //</Snippet1>

            //<Snippet2>
            sampleObject.test = "Dynamic Property";
            Console.WriteLine(sampleObject.test);
            Console.WriteLine(sampleObject.test.GetType());
            // This code example produces the following output:
            // Dynamic Property
            // System.String
            //</Snippet2>

            //<Snippet3>
            sampleObject.number = 10;
            sampleObject.Increment = (Action)(() => { sampleObject.number++; });

            // Before calling the Increment method.
            Console.WriteLine(sampleObject.number);

            sampleObject.Increment();

            // After calling the Increment method.
            Console.WriteLine(sampleObject.number);
            // This code example produces the following output:
            // 10
            // 11
            //</Snippet3>

            //<Snippet5>
            dynamic employee = new ExpandoObject();
            employee.Name = "John Smith";
            employee.Age = 33;

            foreach (var property in (IDictionary<String, Object>)employee)
            {
                Console.WriteLine(property.Key + ": " + property.Value);
            }
            // This code example produces the following output:
            // Name: John Smith
            // Age: 33
            //</Snippet5>
        }

        static void Test2()
        {
            //<Snippet6>
            dynamic employee = new ExpandoObject();
            employee.Name = "John Smith";
            ((IDictionary<String, Object>)employee).Remove("Name");
            //</Snippet6>
        }
    }
}

namespace n2
{
    //<Snippet4>
    class Program
    {
        static void Main(string[] args)
        {
            dynamic employee, manager;

            employee = new ExpandoObject();
            employee.Name = "John Smith";
            employee.Age = 33;

            manager = new ExpandoObject();
            manager.Name = "Allison Brown";
            manager.Age = 42;
            manager.TeamSize = 10;

            WritePerson(manager);
            WritePerson(employee);
        }
        private static void WritePerson(dynamic person)
        {
            Console.WriteLine($"{person.Name} is {person.Age} years old.");
            // The following statement causes an exception
            // if you pass the employee object.
            // Console.WriteLine($"Manages {person.TeamSize} people");
        }
    }
    // This code example produces the following output:
    // John Smith is 33 years old.
    // Allison Brown is 42 years old.
    //</Snippet4>
}

namespace n3
{
    //<Snippet7>
    // Add "using System.ComponentModel;" line
    // to the beginning of the file.
    class Program
    {
        static void Test()
        {
            dynamic employee = new ExpandoObject();
            ((INotifyPropertyChanged)employee).PropertyChanged +=
                new PropertyChangedEventHandler(HandlePropertyChanges);
            employee.Name = "John Smith";
        }

        private static void HandlePropertyChanges(
            object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"{e.PropertyName} has changed.");
        }
    }
    //</Snippet7>
}
