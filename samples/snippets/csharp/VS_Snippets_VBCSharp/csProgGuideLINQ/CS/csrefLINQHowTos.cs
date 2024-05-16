using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//test
// This file contains all the code examples for LINQ-related topics
// throughout the C# Programming Guide
namespace csrefLINQExamples
{
    //<snippet15>
    public class StudentClass
    {
        #region data
        protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;
        }

        protected static List<Student> students = new List<Student>
        {
            new Student {FirstName = "Terry", LastName = "Adams", Id = 120,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 99, 82, 81, 79}},
            new Student {FirstName = "Fadi", LastName = "Fakhouri", Id = 116,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 99, 86, 90, 94}},
            new Student {FirstName = "Hanying", LastName = "Feng", Id = 117,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 93, 92, 80, 87}},
            new Student {FirstName = "Cesar", LastName = "Garcia", Id = 114,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 97, 89, 85, 82}},
            new Student {FirstName = "Debra", LastName = "Garcia", Id = 115,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 35, 72, 91, 70}},
            new Student {FirstName = "Hugo", LastName = "Garcia", Id = 118,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 92, 90, 83, 78}},
            new Student {FirstName = "Sven", LastName = "Mortensen", Id = 113,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 88, 94, 65, 91}},
            new Student {FirstName = "Claire", LastName = "O'Donnell", Id = 112,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 75, 84, 91, 39}},
            new Student {FirstName = "Svetlana", LastName = "Omelchenko", Id = 111,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 97, 92, 81, 60}},
            new Student {FirstName = "Lance", LastName = "Tucker", Id = 119,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 68, 79, 88, 92}},
            new Student {FirstName = "Michael", LastName = "Tucker", Id = 122,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 94, 92, 91, 91}},
            new Student {FirstName = "Eugene", LastName = "Zabokritski", Id = 121,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 96, 85, 91, 60}}
        };
        #endregion

        //<snippet50>
        //Helper method, used in GroupByRange.
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }
        //</snippet50>

        public void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new {Name = student.FirstName, Score = student.ExamScores[exam]};

            foreach (var item in highScores)
            {
                Console.WriteLine("{0,-15}{1}", item.Name, item.Score);
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            StudentClass sc = new StudentClass();
            sc.QueryHighScores(1, 90);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    //</snippet15>

    class ReusableQueryDemo : StudentClass
    {
        static void Main()
        {
            ReuseQuery();
            Console.ReadKey();
        }

        //<snippet3>
        private static void ReuseQuery()
        {
            //Create the query. The use of var is optional here.
            var reusableQuery =
                from student in students
                where student.Id > 115
                select student;

            // Execute the query. Note that enumerating over a query
            // with foreach does not cause the results to be stored
            // in the query variable.
            Console.WriteLine("Execute first query:");
            foreach (var item in reusableQuery)
            {
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }

            // This query filters on the results of the first query.
            // NOTE: In real-world code, use new variables with
            // helpful names instead of reusing old query variables.
            reusableQuery =
                from student in reusableQuery
                where student.Id < 117
                select student;

            Console.WriteLine(System.Environment.NewLine + "Reuse query variable as data source:");

            // Execute the query after it has been reused
            // Note that only one student is returned,
            // the Id that is > 115 and < 117.

            foreach (var item in reusableQuery)
            {
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }

            // Reuse query variable for a completely new query. Note that
            // the original students collection is once again the data source.
            reusableQuery =
                from student in students
                orderby student.LastName
                select student;

            Console.WriteLine(System.Environment.NewLine + "Reuse query variable for a new query:");
            foreach (var item in reusableQuery)
            {
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }
        }
        /* Output:
               Execute first query:
               Adams Terry
               Fakhouri Fadi
               Feng Hanying
               Garcia Hugo
               Tucker Lance
               Tucker Michael
               Zabokritski Eugene

               Reuse query variable as data source:
               Fakhouri Fadi

               Reuse query variable for a new query:
               Garcia Cesar
               O'Donnell Claire
               Garcia Debra
               Zabokritski Eugene
               Fakhouri Fadi
               Feng Hanying
               Garcia Hugo
               Tucker Lance
               Tucker Michael
               Mortensen Sven
               Omelchenko Svetlana
               Adams Terry
           */
        //</snippet3>
    }

    class GroupByExample : StudentClass
    {
        static void Main()
        {
            GroupByLast();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        //<snippet4>
        private static void GroupByLast()
        {
            // Implicit typing is convenient but not required
            // for queries that produce groups
            var query = from student in students
                        group student by student.LastName[0];

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);
                foreach (var i2 in item)
                {
                    Console.WriteLine(i2.LastName + " " + i2.FirstName);
                }
            }
        }
        /*  Outputs:
            T
            Terry Adams
            F
            Fadi Fakhouri
            H
            Hanying Feng
            Hugo Garcia
            C
            Cesar Garcia
            Claire O'Donnell
            D
            Debra Garcia
            S
            Sven Mortensen
            Svetlana Omelchenko
            L
            Lance Tucker
            M
            Michael Tucker
            E
            Eugene Zabokritski
       */
        //</snippet4>
    }

    //How to Write LINQ Queries in C# 45e47fcc-cfa1-4b72-b161-d038ae87bd23
    class HowToWriteLINQQueries
    {
        static void Main()
        {
            //<snippet5>
            // Query #1.
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // The query variable can also be implicitly typed by using var
            IEnumerable<int> filteringQuery =
                from num in numbers
                where num < 3 || num > 7
                select num;

            // Query #2.
            IEnumerable<int> orderingQuery =
                from num in numbers
                where num < 3 || num > 7
                orderby num ascending
                select num;

            // Query #3.
            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];
            //</snippet5>
        }
        static void Method1()
        {
            //<snippet6>
            List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
            // Query #4.
            double average = numbers1.Average();

            // Query #5.
            IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);
            //</snippet6>

            //<snippet7>
            // Query #6.
            IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);
            //</snippet7>
        }
        static void Method2()
        {
            List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

            //<snippet8>
            // var is used for convenience in these queries
            var average = numbers1.Average();
            var concatenationQuery = numbers1.Concat(numbers2);
            var largeNumbersQuery = numbers2.Where(c => c > 15);
            //</snippet8>

            //<snippet9>
            // Query #7.

            // Using a query expression with method syntax
            int numCount1 =
                (from num in numbers1
                 where num < 3 || num > 7
                 select num).Count();

            // Better: Create a new variable to store
            // the method call result
            IEnumerable<int> numbersQuery =
                from num in numbers1
                where num < 3 || num > 7
                select num;

            int numCount2 = numbersQuery.Count();
            //</snippet9>
        }
    }

    //How To: Handle Exceptions in Query Expressions 4ce6c081-7731-4b8f-b4fa-d947f165a18a
    //<snippet10>
    class ExceptionsOutsideQuery
    {
        static void Main()
        {
            // DO THIS with a datasource that might
            // throw an exception. It is easier to deal with
            // outside of the query expression.
            IEnumerable<int> dataSource;
            try
            {
                dataSource = GetData();
            }
            catch (InvalidOperationException)
            {
                // Handle (or don't handle) the exception
                // in the way that is appropriate for your application.
                Console.WriteLine("Invalid operation");
                goto Exit;
            }

            // If we get here, it is safe to proceed.
            var query = from i in dataSource
                        select i * i;

            foreach (var i in query)
                Console.WriteLine(i.ToString());

            //Keep the console window open in debug mode
            Exit:
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // A data source that is very likely to throw an exception!
        static IEnumerable<int> GetData()
        {
            throw new InvalidOperationException();
        }
    }
    //</snippet10>

    #region oldcode
    //       // Change this value to a nonexistent folder on your machine
    //       // or to a folder with restricted permissions
    //       string root = @"c:\";

    //       // DON'T DO THIS! GetFiles can throw an exception.
    //       // Uncomment this query and press F5 to see the results
    //       // var queryFiles1 =
    //       //    from file in Directory.GetFiles(root)
    //       //    where file.Substring(file.Length - 3) == ".txt"
    //       //    select file;

    //       // DO THIS. Create data source outside of query
    //       // and handle exceptions or other error conditions there.
    //       // Change root to "C:\" as an experiment.
    //       if (!Directory.Exists(root))
    //       {
    //           Console.WriteLine("Directory does not exist");

    //           //Keep the console window open in debug mode
    //           Console.WriteLine("Press any key to exit");
    //           Console.ReadKey();
    //           return;
    //       }
    //       string[] files = null;
    //       try
    //       {
    //           files = Directory.GetFiles(root, "*.htm", SearchOption.AllDirectories);
    //       }
    //       catch (UnauthorizedAccessException)
    //       {
    //           Console.WriteLine("You are not authorized to view one or more subfolders.");
    //           Console.WriteLine("Press any key to exit");
    //           Console.ReadKey();
    //           return;
    //       }

    //       // var is used for convenience
    //       var queryFiles2 =
    //           from file in files
    //           let fileInfo = new FileInfo(file)
    //           where fileInfo.LastAccessTime < DateTime.Today
    //           select file;

    //       foreach (var file in queryFiles2)
    //       {
    //           Console.WriteLine(file);
    //       }
    #endregion

    //LINQ Query Expressions (C# Programming Guide)	40638f19-fb46-4d26-a2d9-a383b48f5ed4
    //<snippet11>
    class LINQQueryExpressions
    {
        static void Main()
        {

            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }
    }
    // Output: 97 92 81
    //</snippet11>

    //How To: Handle Exceptions in Query Expressions 4ce6c081-7731-4b8f-b4fa-d947f165a18a
    //this snippet is out of order. ok.

    //removing as just too error-prone
    //<snippet 22>
    //class CatchAndContinue
    //{
    //    static void Main()
    //    {

    //        foreach (var file in queryLargeFiles)
    //        {
    //            Console.WriteLine(file);
    //        }

    //        //Keep the console window open in debug mode
    //        Console.WriteLine("Press any key to exit");
    //        Console.ReadKey();
    //    }

    //}
    //</snippet 22>

#region moreOldCode
    //// Create a list of filenames.
    //        string[] files = Directory.GetFiles(System.Environment.CurrentDirectory);

    //        // DON'T DO THIS. The FileInfo.Length property
    //        // will attempt to access the file record on first use
    //        var queryLargeFiles =
    //            from file in files
    //            where file.Length > 100 // potential exception
    //            select file;

    //        // DO THIS. Access the FileInfo.Length property
    //        // in a method that handles the exception in a way
    //        // that is perfectly safe in the context of this app.
    //        var queryTotalBytes =
    //            from file in files
    //            where GetFileLength(file) > 100
    //            select file;
    //static long GetFileLength(string fileName)
    //    {
    //        long retval;
    //        FileInfo fi;
    //        try
    //        {
    //            fi = new FileInfo(fileName);
    //            retval = fi.Length;
    //        }
    //        catch (FileNotFoundException)
    //        {
    //            // For this particular query, returning
    //            // zero is the right thing to do.
    //            retval = 0;
    //        }
    //        return retval;
    //    }
#endregion

    //How To: Handle Exceptions in Query Expressions 4ce6c081-7731-4b8f-b4fa-d947f165a18a
    //<snippet12>
    class QueryThatThrows
    {
        static void Main()
        {
            // Data source.
            string[] files = { "fileA.txt", "fileB.txt", "fileC.txt" };

            // Demonstration query that throws.
            var exceptionDemoQuery =
                from file in files
                let n = SomeMethodThatMightThrow(file)
                select n;

            // Runtime exceptions are thrown when query is executed.
            // Therefore they must be handled in the foreach loop.
            try
            {
                foreach (var item in exceptionDemoQuery)
                {
                    Console.WriteLine("Processing {0}", item);
                }
            }

            // Catch whatever exception you expect to raise
            // and/or do any necessary cleanup in a finally block
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            //Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // Not very useful as a general purpose method.
        static string SomeMethodThatMightThrow(string s)
        {
            if (s[4] == 'C')
                throw new InvalidOperationException();
            return @"C:\newFolder\" + s;
        }
    }
    /* Output:
        Processing C:\newFolder\fileA.txt
        Processing C:\newFolder\fileB.txt
        Operation is not valid due to the current state of the object.
     */
    //</snippet12>

    //<snippet13>
    class MergeTwoCSVFiles
    {
        static void Main()
        {
            // See section Compiling the Code for information about the data files.
            string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

            // Merge the data sources using a named type.
            // You could use var instead of an explicit type for the query.
            IEnumerable<Student> queryNamesScores =
                // Split each line in the data files into an array of strings.
                from name in names
                let x = name.Split(',')
                from score in scores
                let s = score.Split(',')
                // Look for matching Ids from the two data files.
                where x[2] == s[0]
                // If the Ids match, build a Student object.
                select new Student()
                {
                    FirstName = x[0],
                    LastName = x[1],
                    Id = Convert.ToInt32(x[2]),
                    ExamScores = (from scoreAsText in s.Skip(1)
                                  select Convert.ToInt32(scoreAsText)).
                                  ToList()
                };

            // Optional. Store the newly created student objects in memory
            // for faster access in future queries
            List<Student> students = queryNamesScores.ToList();

            foreach (var student in students)
            {
                Console.WriteLine("The average score of {0} {1} is {2}.",
                    student.FirstName, student.LastName, student.ExamScores.Average());
            }

            //Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public List<int> ExamScores { get; set; }
    }

    /* Output:
        The average score of Omelchenko Svetlana is 82.5.
        The average score of O'Donnell Claire is 72.25.
        The average score of Mortensen Sven is 84.5.
        The average score of Garcia Cesar is 88.25.
        The average score of Garcia Debra is 67.
        The average score of Fakhouri Fadi is 92.25.
        The average score of Feng Hanying is 88.
        The average score of Garcia Hugo is 85.75.
        The average score of Tucker Lance is 81.75.
        The average score of Adams Terry is 85.25.
        The average score of Zabokritski Eugene is 83.
        The average score of Tucker Michael is 92.
     */
    //</snippet13>

    class MergeCSVData2
    {
        static void Method2(List<string> names, List<int[]> scores)
        {
            //<snippet14>
            //Merge the data sources using an anonymous type
            var queryNamesWithScores =
                from name in names
                from score in scores
                where score[0].ToString() == name.Substring(name.Length - 3, 3)
                select new { Name = name, TestScores = score.Skip(1).ToList() };

            foreach (var item in queryNamesWithScores)
            {
                Console.WriteLine("Name and Id: {0}, Average Score: {1}", item.Name, item.TestScores.Average());
            }
            //</snippet14>

            //Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    // How To: Group Results in Various Ways (LINQ) ee981053-3392-4245-a8c2-b3730211da0d

    class GroupExamples : StudentClass
    {
        //<snippet17>
        public void GroupBySingleProperty()
        {
            Console.WriteLine("Group by a single property in an object:");

            // Variable queryLastNames is an IEnumerable<IGrouping<string,
            // DataClass.Student>>.
            var queryLastNames =
                from student in students
                group student by student.LastName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine("Key: {0}", nameGroup.Key);
                foreach (var student in nameGroup)
                {
                    Console.WriteLine("\t{0}, {1}", student.LastName, student.FirstName);
                }
            }
        }
        /* Output:
            Group by a single property in an object:
            Key: Adams
                    Adams, Terry
            Key: Fakhouri
                    Fakhouri, Fadi
            Key: Feng
                    Feng, Hanying
            Key: Garcia
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: Mortensen
                    Mortensen, Sven
            Key: O'Donnell
                    O'Donnell, Claire
            Key: Omelchenko
                    Omelchenko, Svetlana
            Key: Tucker
                    Tucker, Lance
                    Tucker, Michael
            Key: Zabokritski
                    Zabokritski, Eugene
        */
        //</snippet17>

        //<snippet21>
        public void GroupByCompositeKey()
        {

            var queryHighScoreGroups =
                from student in students
                group student by new { FirstLetter = student.LastName[0],
                    Score = student.ExamScores[0] > 85 } into studentGroup
                orderby studentGroup.Key.FirstLetter
                select studentGroup;

            Console.WriteLine("\r\nGroup and order by a compound key:");
            foreach (var scoreGroup in queryHighScoreGroups)
            {
                string s = scoreGroup.Key.Score == true ? "more than" : "less than";
                Console.WriteLine("Name starts with {0} who scored {1} 85", scoreGroup.Key.FirstLetter, s);
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine("\t{0} {1}", item.FirstName, item.LastName);
                }
            }
        }
        /* Output:
            Group and order by a compound key:
            Name starts with A who scored more than 85
                    Terry Adams
            Name starts with F who scored more than 85
                    Fadi Fakhouri
                    Hanying Feng
            Name starts with G who scored more than 85
                    Cesar Garcia
                    Hugo Garcia
            Name starts with G who scored less than 85
                    Debra Garcia
            Name starts with M who scored more than 85
                    Sven Mortensen
            Name starts with O who scored less than 85
                    Claire O'Donnell
            Name starts with O who scored more than 85
                    Svetlana Omelchenko
            Name starts with T who scored less than 85
                    Lance Tucker
            Name starts with T who scored more than 85
                    Michael Tucker
            Name starts with Z who scored more than 85
                    Eugene Zabokritski
        */
        //</snippet21>

        //<snippet20>
        public void GroupByBoolean()
        {
            Console.WriteLine("\r\nGroup by a Boolean into two groups with string keys");
            Console.WriteLine("\"True\" and \"False\" and project into a new anonymous type:");
            var queryGroupByAverages = from student in students
                                       group new { student.FirstName, student.LastName }
                                            by student.ExamScores.Average() > 75 into studentGroup
                                       select studentGroup;

            foreach (var studentGroup in queryGroupByAverages)
            {
                Console.WriteLine("Key: {0}", studentGroup.Key);
                foreach (var student in studentGroup)
                    Console.WriteLine("\t{0} {1}", student.FirstName, student.LastName);
            }
        }
        /* Output:
            Group by a Boolean into two groups with string keys
            "True" and "False" and project into a new anonymous type:
            Key: True
                    Terry Adams
                    Fadi Fakhouri
                    Hanying Feng
                    Cesar Garcia
                    Hugo Garcia
                    Sven Mortensen
                    Svetlana Omelchenko
                    Lance Tucker
                    Michael Tucker
                    Eugene Zabokritski
            Key: False
                    Debra Garcia
                    Claire O'Donnell
        */
        //</snippet20>

        //<snippet19>
        public void GroupByRange()
        {
            Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

            var queryNumericRange =
                from student in students
                let percentile = GetPercentile(student)
                group new { student.FirstName, student.LastName } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items.
            foreach (var studentGroup in queryNumericRange)
            {
                Console.WriteLine("Key: {0}", (studentGroup.Key * 10));
                foreach (var item in studentGroup)
                {
                    Console.WriteLine("\t{0}, {1}", item.LastName, item.FirstName);
                }
            }
        }
        /* Output:
            Group by numeric range and project into a new anonymous type:
            Key: 60
                    Garcia, Debra
            Key: 70
                    O'Donnell, Claire
            Key: 80
                    Adams, Terry
                    Feng, Hanying
                    Garcia, Cesar
                    Garcia, Hugo
                    Mortensen, Sven
                    Omelchenko, Svetlana
                    Tucker, Lance
                    Zabokritski, Eugene
            Key: 90
                    Fakhouri, Fadi
                    Tucker, Michael
        */
        //</snippet19>

        //<snippet18>
        public void GroupBySubstring()
        {
            Console.WriteLine("\r\nGroup by something other than a property of the object:");

            var queryFirstLetters =
                from student in students
                group student by student.LastName[0];

            foreach (var studentGroup in queryFirstLetters)
            {
                Console.WriteLine("Key: {0}", studentGroup.Key);
                // Nested foreach is required to access group items.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t{0}, {1}", student.LastName, student.FirstName);
                }
            }
        }
        /* Output:
            Group by something other than a property of the object:
            Key: A
                    Adams, Terry
            Key: F
                    Fakhouri, Fadi
                    Feng, Hanying
            Key: G
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: M
                    Mortensen, Sven
            Key: O
                    O'Donnell, Claire
                    Omelchenko, Svetlana
            Key: T
                    Tucker, Lance
                    Tucker, Michael
            Key: Z
                    Zabokritski, Eugene
        */
        //</snippet18>
    } // end class GroupExamples

    //Snippet22 is used up above out of sequence

    class HowToSubqueryAGroup : StudentClass
    {
        static void Main(string[] args)
        {
            // Adding this object just to allow me to make QueryMax public
            // and call it like other methods in these how-to topics.
            var testObj = new HowToSubqueryAGroup();
            testObj.QueryMax();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        //<snippet23>
        public void QueryMax()
        {
            var queryGroupMax =
                from student in students
                group student by student.Year into studentGroup
                select new
                {
                    Level = studentGroup.Key,
                    HighestScore =
                    (from student2 in studentGroup
                     select student2.ExamScores.Average()).Max()
                };

            int count = queryGroupMax.Count();
            Console.WriteLine("Number of groups = {0}", count);

            foreach (var item in queryGroupMax)
            {
                Console.WriteLine("  {0} Highest Score={1}", item.Level, item.HighestScore);
            }
        }
        //</snippet23>
    }

    //How to: Group a Group
    class NestedGroups : StudentClass
    {
        static void Main()
        {
            //can't actually call this without screwing up other snippets.
            // but it needs to be public instance method for this example to make it easier to just
            // paste into student class and call it.
            // StudentClass sc = new StudentClass();
            //sc.QueryNestedGroups();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        //<snippet24>
        public void QueryNestedGroups()
        {
            var queryNestedGroups =
                from student in students
                group student by student.Year into newGroup1
                from newGroup2 in
                    (from student in newGroup1
                     group student by student.LastName)
                group newGroup2 by newGroup1.Key;

            // Three nested foreach loops are required to iterate
            // over all elements of a grouped group. Hover the mouse
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    }
                }
            }
        }
        /*
         Output:
        DataClass.Student Level = SecondYear
                Names that begin with: Adams
                        Adams Terry
                Names that begin with: Garcia
                        Garcia Hugo
                Names that begin with: Omelchenko
                        Omelchenko Svetlana
        DataClass.Student Level = ThirdYear
                Names that begin with: Fakhouri
                        Fakhouri Fadi
                Names that begin with: Garcia
                        Garcia Debra
                Names that begin with: Tucker
                        Tucker Lance
        DataClass.Student Level = FirstYear
                Names that begin with: Feng
                        Feng Hanying
                Names that begin with: Mortensen
                        Mortensen Sven
                Names that begin with: Tucker
                        Tucker Michael
        DataClass.Student Level = FourthYear
                Names that begin with: Garcia
                        Garcia Cesar
                Names that begin with: O'Donnell
                        O'Donnell Claire
                Names that begin with: Zabokritski
                        Zabokritski Eugene
         */
        //</snippet24>
    }

    //<snippet25>
    class StoreQueryResults
    {
        static List<int> numbers = new List<int>() { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        static void Main()
        {

            IEnumerable<int> queryFactorsOfFour =
                from num in numbers
                where num % 4 == 0
                select num;

            // Store the results in a new variable
            // without executing a foreach loop.
            List<int> factorsofFourList = queryFactorsOfFour.ToList();

            // Iterate the list just to prove it holds data.
            foreach (int n in factorsofFourList)
            {
                Console.WriteLine(n);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
    //</snippet25>

    //<snippet26>
    class DynamicPredicates : StudentClass
    {
        static void Main(string[] args)
        {
            string[] ids = { "111", "114", "112" };

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void QueryById(string[] ids)
        {
            var queryNames =
                from student in students
                let i = student.Id.ToString()
                where ids.Contains(i)
                select new { student.LastName, student.Id };

            foreach (var name in queryNames)
            {
                Console.WriteLine("{0}: {1}", name.LastName, name.Id);
            }
        }
    }
    //</snippet26>

    class DynamicPredicates2 : StudentClass
    {
        static void Main(string[] args)
        {
            // Run the query
            QueryByYear(args[0]);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        //<snippet27>
        // To run this sample, first specify an integer value of 1 to 4 for the command
        // line. This number will be converted to a GradeLevel value that specifies which
        // set of students to query.
        // Call the method: QueryByYear(args[0]);

        static void QueryByYear(string level)
        {
            GradeLevel year = (GradeLevel)Convert.ToInt32(level);
            IEnumerable<Student> studentQuery = null;
            switch (year)
            {
                case GradeLevel.FirstYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.FirstYear
                                   select student;
                    break;
                case GradeLevel.SecondYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.SecondYear
                                   select student;
                    break;
                case GradeLevel.ThirdYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.ThirdYear
                                   select student;
                    break;
                case GradeLevel.FourthYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.FourthYear
                                   select student;
                    break;

                default:
                    break;
            }
            Console.WriteLine("The following students are at level {0}", year.ToString());
            foreach (Student name in studentQuery)
            {
                Console.WriteLine("{0}: {1}", name.LastName, name.Id);
            }
        }
        //</snippet27>

        //<snippet29>
        public class ActionTest
        {
            static void Main()
            {
                (from i in new[] { 1, 2, 3, 4, 5 }
                 select i * i)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
            }
        }
        //</snippet29>
    }
}
