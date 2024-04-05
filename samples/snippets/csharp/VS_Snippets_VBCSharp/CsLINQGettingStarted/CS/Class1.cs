using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LINQGettingStarted_1;

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
    }
}
