﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LINQGettingStarted_1
{
    class Customer { } //so that Table<Customer> compiles below

    class IntroToLINQ
    {
        static void Main()
        {
        }
    }

    class DummyClass
    {
        //The Three Parts of a LINQ Query
        static void CreateDataSources()
        {

        }
    }

    //<snippet7>
    class Student
    {
        public string First { get; set; }
        public string Last {get; set;}
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<int> Scores;
    }

    class Teacher
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
    }
    //</snippet7>

    //<snippet8>
    class DataTransformations
    {
        static void Main()
        {
            // Create the first data source.
            List<Student> students = 
            [
                new Student { First="Svetlana",
                    Last="Omelchenko",
                    ID=111,
                    Street="123 Main Street",
                    City="Seattle",
                    Scores= new List<int> { 97, 92, 81, 60 } },
                new Student { First="Claire",
                    Last="O’Donnell",
                    ID=112,
                    Street="124 Main Street",
                    City="Redmond",
                    Scores= new List<int> { 75, 84, 91, 39 } },
                new Student { First="Sven",
                    Last="Mortensen",
                    ID=113,
                    Street="125 Main Street",
                    City="Lake City",
                    Scores= new List<int> { 88, 94, 65, 91 } },
            ];

            // Create the second data source.
            List<Teacher> teachers =
            [
                new Teacher { First="Ann", Last="Beebe", ID=945, City="Seattle" },
                new Teacher { First="Alex", Last="Robinson", ID=956, City="Redmond" },
                new Teacher { First="Michiyo", Last="Sato", ID=972, City="Tacoma" }
            ];

            // Create the query.
            var peopleInSeattle = (from student in students
                        where student.City == "Seattle"
                        select student.Last)
                        .Concat(from teacher in teachers
                                where teacher.City == "Seattle"
                                select teacher.Last);

            Console.WriteLine("The following students and teachers live in Seattle:");
            // Execute the query.
            foreach (var person in peopleInSeattle)
            {
                Console.WriteLine(person);
            }

        }
    }
    /* Output:
        The following students and teachers live in Seattle:
        Omelchenko
        Beebe
     */
    // </snippet8>

    // <snippet9>
    class XMLTransform
    {
        static void Main()
        {
            // Create the data source by using a collection initializer.
            // The Student class was defined previously in this topic.
            List<Student> students =
            [
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int>{97, 92, 81, 60}},
                new Student {First="Claire", Last="O’Donnell", ID=112, Scores = new List<int>{75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores = new List<int>{88, 94, 65, 91}},
            ];

            // Create the query.
            var studentsToXML = new XElement("Root",
                from student in students
                let scores = string.Join(",", student.Scores)
                select new XElement("student",
                           new XElement("First", student.First),
                           new XElement("Last", student.Last),
                           new XElement("Scores", scores)
                        ) // end "student"
                    ); // end "Root"

            // Execute the query.
            Console.WriteLine(studentsToXML);

        }
    }
    // </snippet9>
    /* Output:
      <Root>
          <student>
            <First>Svetlana</First>
            <Last>Omelchenko</Last>
            <Scores>97,92,81,60</Scores>
          </student>
          <student>
            <First>Claire</First>
            <Last>O'Donnell</Last>
            <Scores>75,84,91,39</Scores>
          </student>
          <student>
            <First>Sven</First>
            <Last>Mortensen</Last>
            <Scores>88,94,65,91</Scores>
          </student>
       </Root>
    */

    //<snippet10>
    class FormatQuery
    {
        static void Main()
        {
            // Data source.
            double[] radii = [ 1, 2, 3 ];

            // LINQ query using method syntax.
            IEnumerable<string> output = 
                radii.Select(r => $"Area for a circle with a radius of '{r}' = {r * r * Math.PI:F2}");

            /*
            // LINQ query using query syntax.
            IEnumerable<string> output =
                from rad in radii
                select $"Area for a circle with a radius of '{rad}' = {rad * rad * Math.PI:F2}";
            */

            foreach (string s in output)
            {
                Console.WriteLine(s);
            }
                
        }
    }
    /* Output:
        Area for a circle with a radius of '1' = 3.14
        Area for a circle with a radius of '2' = 12.57
        Area for a circle with a radius of '3' = 28.27
    */
    // </snippet10>

    class Program //for the Walkthrough topic
    {
        //<snippet11>
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = 
        [
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        ];
        //</snippet11>

        static void Main()
        {
            //<snippet12>
            // Create the query.
            // The first line could also be written as "var studentQuery ="
            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90
                select student;
            //</snippet12>

            Console.WriteLine("\nExecuting Query 1.............");
            //<snippet13>
            // Execute the query.
            // var could be used here also.
            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1}", student.Last, student.First);
            }

            // Output:
            // Omelchenko, Svetlana
            // Garcia, Cesar
            // Fakhouri, Fadi
            // Feng, Hanying
            // Garcia, Hugo
            // Adams, Terry
            // Zabokritski, Eugene
            // Tucker, Michael
            //</snippet13>

            //<snippet14>
            IEnumerable<IGrouping<char, Student>> studentQuery2 =
                from student in students
                group student by student.Last[0];
            //</snippet14>

            Console.WriteLine("\nExecuting Query 2..............");
            //<snippet15>
            foreach (IGrouping<char, Student> studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }

            // Output:
            // O
            //   Omelchenko, Svetlana
            //   O'Donnell, Claire
            // M
            //   Mortensen, Sven
            // G
            //   Garcia, Cesar
            //   Garcia, Debra
            //   Garcia, Hugo
            // F
            //   Fakhouri, Fadi
            //   Feng, Hanying
            // T
            //   Tucker, Lance
            //   Tucker, Michael
            // A
            //   Adams, Terry
            // Z
            //   Zabokritski, Eugene
            //</snippet15>

            Console.WriteLine("\nExecuting Query 3..............");
            //<snippet16>
            var studentQuery3 =
                from student in students
                group student by student.Last[0];

            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

            // Output:
            // O
            //   Omelchenko, Svetlana
            //   O'Donnell, Claire
            // M
            //   Mortensen, Sven
            // G
            //   Garcia, Cesar
            //   Garcia, Debra
            //   Garcia, Hugo
            // F
            //   Fakhouri, Fadi
            //   Feng, Hanying
            // T
            //   Tucker, Lance
            //   Tucker, Michael
            // A
            //   Adams, Terry
            // Z
            //   Zabokritski, Eugene
            //</snippet16>

            Console.WriteLine("\nExecuting Query 4..............");
            //<snippet17>
            var studentQuery4 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

            // Output:
            //A
            //   Adams, Terry
            //F
            //   Fakhouri, Fadi
            //   Feng, Hanying
            //G
            //   Garcia, Cesar
            //   Garcia, Debra
            //   Garcia, Hugo
            //M
            //   Mortensen, Sven
            //O
            //   Omelchenko, Svetlana
            //   O'Donnell, Claire
            //T
            //   Tucker, Lance
            //   Tucker, Michael
            //Z
            //   Zabokritski, Eugene
            //</snippet17>

            Console.WriteLine("\nExecuting Query 5..............");
            //<snippet18>
            // studentQuery5 is an IEnumerable<string>
            // This query returns those students whose
            // first test score was higher than their
            // average score.
            var studentQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }

            // Output:
            // Omelchenko Svetlana
            // O'Donnell Claire
            // Mortensen Sven
            // Garcia Cesar
            // Fakhouri Fadi
            // Feng Hanying
            // Garcia Hugo
            // Adams Terry
            // Zabokritski Eugene
            // Tucker Michael
            //</snippet18>

            Console.WriteLine("\nExecuting Query 6..............");

            //<snippet19>
            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                select totalScore;

            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);

            // Output:
            // Class average score = 334.166666666667
            //</snippet19>

            Console.WriteLine("\nExecuting Query 7..............");
            //<snippet20>
            IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Garcia"
                select student.First;

            Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }

            // Output:
            // The Garcias in the class are:
            // Cesar
            // Debra
            // Hugo
            //</snippet20>

            //<snippet21>
            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

            // Output:
            // Student ID: 113, Score: 338
            // Student ID: 114, Score: 353
            // Student ID: 116, Score: 369
            // Student ID: 117, Score: 352
            // Student ID: 118, Score: 343
            // Student ID: 120, Score: 341
            // Student ID: 122, Score: 368
            //</snippet21>
        }

        //<snippet31>
        // Lightweight class with auto-implemented properties
        class NamePhone
        {
            public string Name { get; set; }
            public string Phone{ get; set; }
        }
        //</snippet31>

        class BasicQueryOperations
        {
            class Customer
            {
                public string City { get; set; }
                public string Name { get; set; }
                public string Phone {get; set; }
            }

            public class Distributor
            {
                public string Name { get; set; }
                public string City { get; set; }
                public int ID { get; set; }
            }

            static void Main()
            {
                List<Customer> customers = new List<Customer>();
                List<Distributor> distributors = new List<Distributor>();

                //<snippet23>
                //queryAllCustomers is an IEnumerable<Customer>
                var queryAllCustomers = from cust in customers
                                        select cust;
              //</snippet23>

              //<snippet24>
              var queryLondonCustomers = from cust in customers
                                         where cust.City == "London"
                                         select cust;
              //</snippet24>

              IEnumerable<Customer> queryLondonCustomers2 =
                                        from cust in customers
              //<snippet25>
                  where cust.City == "London" && cust.Name == "Devon"
              //</snippet25>
              //<snippet26>
                  where cust.City == "London" || cust.City == "Paris"
              //</snippet26>
              select cust;

              //<snippet27>
              var queryLondonCustomers3 =
                  from cust in customers
                  where cust.City == "London"
                  orderby cust.Name ascending
                  select cust;
              //</snippet27>

               //<snippet28>
              // queryCustomersByCity is an IEnumerable<IGrouping<string, Customer>>
                var queryCustomersByCity =
                    from cust in customers
                    group cust by cust.City;

                // customerGroup is an IGrouping<string, Customer>
                foreach (var customerGroup in queryCustomersByCity)
                {
                    Console.WriteLine(customerGroup.Key);
                    foreach (Customer customer in customerGroup)
                    {
                        Console.WriteLine("    {0}", customer.Name);
                    }
                }
                //</snippet28>

                 //<snippet29>
                // custQuery is an IEnumerable<IGrouping<string, Customer>>
                var custQuery =
                    from cust in customers
                    group cust by cust.City into custGroup
                    where custGroup.Count() > 2
                    orderby custGroup.Key
                    select custGroup;
                 //</snippet29>

                 //<snippet30>
                // queryNamesInLondon is an IEnumerable<String>
                var queryNamesInLondon =
                    from cust in customers
                    where cust.City == "London"
                    orderby cust.Name ascending
                    select cust.Name;
                //</snippet30>

              //number 31 is the NamePhone struct before this class
             //<snippet32>
                // var could also be used here
                IEnumerable<NamePhone> queryLondonNamesPhones =
                    from cust in customers
                    where cust.City == "London"
                    orderby cust.Name ascending
                    select new NamePhone {Name = cust.Name, Phone = cust.Phone};
            //</snippet32>

             //<snippet33>
                // var must be used here because of the anonymous type
                var queryNamesPhones =
                    from cust in customers
                    where cust.City == "London"
                    orderby cust.Name ascending
                    select new { Name = cust.Name, Phone = cust.Phone };

                foreach (var item in queryNamesPhones)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.Phone);
                }
            //</snippet33>

            //<snippet36>
                var innerJoinQuery =
                    from cust in customers
                    join dist in distributors on cust.City equals dist.City
                    select new { CustomerName = cust.Name, DistributorName = dist.Name };
            //</snippet36>
           }
        }

        class LINQAndGenericTypes
        {

        }
    }
}
