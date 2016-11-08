    class SelectSample2
    {
        // Define some classes
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
            public ContactInfo GetContactInfo(SelectSample2 app, int id)
            {
                ContactInfo cInfo =
                    (from ci in app.contactList
                    where ci.ID == id
                    select ci)
                    .FirstOrDefault();
                    
                return cInfo;
            }

            public override string ToString()
            {
                return First + " " + Last + ":" + ID;
            }
        }

        public class ContactInfo
        {
            public int ID { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public override string ToString() { return Email + "," + Phone; }
        }

        public class ScoreInfo
        {
            public double Average { get; set; }
            public int ID { get; set; }
        }

        // The primary data source
        List<Student> students = new List<Student>()
        {
             new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int>() {97, 92, 81, 60}},
             new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int>() {75, 84, 91, 39}},
             new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int>() {88, 94, 65, 91}},
             new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int>() {97, 89, 85, 82}},
        };

        // Separate data source for contact info.
        List<ContactInfo> contactList = new List<ContactInfo>()
        {
            new ContactInfo {ID=111, Email="SvetlanO@Contoso.com", Phone="206-555-0108"},
            new ContactInfo {ID=112, Email="ClaireO@Contoso.com", Phone="206-555-0298"},
            new ContactInfo {ID=113, Email="SvenMort@Contoso.com", Phone="206-555-1130"},
            new ContactInfo {ID=114, Email="CesarGar@Contoso.com", Phone="206-555-0521"}
        };


        static void Main(string[] args)
        {
            SelectSample2 app = new SelectSample2();

            // Produce a filtered sequence of unmodified Students.
            IEnumerable<Student> studentQuery1 =
                from student in app.students
                where student.ID > 111
                select student;

            Console.WriteLine("Query1: select range_variable");
            foreach (Student s in studentQuery1)
            {
                Console.WriteLine(s.ToString());
            }

            // Produce a filtered sequence of elements that contain
            // only one property of each Student.
            IEnumerable<String> studentQuery2 =
                from student in app.students
                where student.ID > 111
                select student.Last;

            Console.WriteLine("\r\n studentQuery2: select range_variable.Property");
            foreach (string s in studentQuery2)
            {
                Console.WriteLine(s);
            }

            // Produce a filtered sequence of objects created by
            // a method call on each Student.
            IEnumerable<ContactInfo> studentQuery3 =
                from student in app.students
                where student.ID > 111
                select student.GetContactInfo(app, student.ID);

            Console.WriteLine("\r\n studentQuery3: select range_variable.Method");
            foreach (ContactInfo ci in studentQuery3)
            {
                Console.WriteLine(ci.ToString());
            }

            // Produce a filtered sequence of ints from
            // the internal array inside each Student.
            IEnumerable<int> studentQuery4 =
                from student in app.students
                where student.ID > 111
                select student.Scores[0];

            Console.WriteLine("\r\n studentQuery4: select range_variable[index]");
            foreach (int i in studentQuery4)
            {
                Console.WriteLine("First score = {0}", i);
            }

            // Produce a filtered sequence of doubles 
            // that are the result of an expression.
            IEnumerable<double> studentQuery5 =
                from student in app.students
                where student.ID > 111
                select student.Scores[0] * 1.1;

            Console.WriteLine("\r\n studentQuery5: select expression");
            foreach (double d in studentQuery5)
            {
                Console.WriteLine("Adjusted first score = {0}", d);
            }

            // Produce a filtered sequence of doubles that are
            // the result of a method call.
            IEnumerable<double> studentQuery6 =
                from student in app.students
                where student.ID > 111
                select student.Scores.Average();

            Console.WriteLine("\r\n studentQuery6: select expression2");
            foreach (double d in studentQuery6)
            {
                Console.WriteLine("Average = {0}", d);
            }

            // Produce a filtered sequence of anonymous types
            // that contain only two properties from each Student.
            var studentQuery7 =
                from student in app.students
                where student.ID > 111
                select new { student.First, student.Last };

            Console.WriteLine("\r\n studentQuery7: select new anonymous type");
            foreach (var item in studentQuery7)
            {
                Console.WriteLine("{0}, {1}", item.Last, item.First);
            }

            // Produce a filtered sequence of named objects that contain
            // a method return value and a property from each Student.
            // Use named types if you need to pass the query variable 
            // across a method boundary.
            IEnumerable<ScoreInfo> studentQuery8 =
                from student in app.students
                where student.ID > 111
                select new ScoreInfo
                {
                    Average = student.Scores.Average(),
                    ID = student.ID
                };

            Console.WriteLine("\r\n studentQuery8: select new named type");
            foreach (ScoreInfo si in studentQuery8)
            {
                Console.WriteLine("ID = {0}, Average = {1}", si.ID, si.Average);
            }

            // Produce a filtered sequence of students who appear on a contact list
            // and whose average is greater than 85.
            IEnumerable<ContactInfo> studentQuery9 =
                from student in app.students
                where student.Scores.Average() > 85
                join ci in app.contactList on student.ID equals ci.ID
                select ci;

            Console.WriteLine("\r\n studentQuery9: select result of join clause");
            foreach (ContactInfo ci in studentQuery9)
            {
                Console.WriteLine("ID = {0}, Email = {1}", ci.ID, ci.Email);
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            }
        }
    /* Output
        Query1: select range_variable
        Claire O'Donnell:112
        Sven Mortensen:113
        Cesar Garcia:114

        studentQuery2: select range_variable.Property
        O'Donnell
        Mortensen
        Garcia

        studentQuery3: select range_variable.Method
        ClaireO@Contoso.com,206-555-0298
        SvenMort@Contoso.com,206-555-1130
        CesarGar@Contoso.com,206-555-0521

        studentQuery4: select range_variable[index]
        First score = 75
        First score = 88
        First score = 97

        studentQuery5: select expression
        Adjusted first score = 82.5
        Adjusted first score = 96.8
        Adjusted first score = 106.7

        studentQuery6: select expression2
        Average = 72.25
        Average = 84.5
        Average = 88.25

        studentQuery7: select new anonymous type
        O'Donnell, Claire
        Mortensen, Sven
        Garcia, Cesar

        studentQuery8: select new named type
        ID = 112, Average = 72.25
        ID = 113, Average = 84.5
        ID = 114, Average = 88.25

        studentQuery9: select result of join clause
        ID = 114, Email = CesarGar@Contoso.com
*/