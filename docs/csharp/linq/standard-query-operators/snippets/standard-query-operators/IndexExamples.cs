using System.Xml.Linq;

namespace StandardQueryOperators;

internal class IndexExamples
{
    private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Sentences();
        PartsOfAQuery();
        Transformations();
        XmlTransformation();
        Properties();
        QueryMethod();
    }

    private static void Sentences()
    {
        // <FirstSentence>
        string sentence = "the quick brown fox jumps over the lazy dog";
        // Split the string into individual words to create a collection.
        string[] words = sentence.Split(' ');

        // Using query expression syntax.
        var query = from word in words
                    group word.ToUpper() by word.Length into gr
                    orderby gr.Key
                    select new { Length = gr.Key, Words = gr };

        // Using method-based query syntax.
        var query2 = words.
            GroupBy(w => w.Length, w => w.ToUpper()).
            Select(g => new { Length = g.Key, Words = g }).
            OrderBy(o => o.Length);

        foreach (var obj in query)
        {
            Console.WriteLine("Words of length {0}:", obj.Length);
            foreach (string word in obj.Words)
                Console.WriteLine(word);
        }

        // This code example produces the following output:
        //
        // Words of length 3:
        // THE
        // FOX
        // THE
        // DOG
        // Words of length 4:
        // OVER
        // LAZY
        // Words of length 5:
        // QUICK
        // BROWN
        // JUMPS
        // </FirstSentence>
    }

    private static void PartsOfAQuery()
    {
        //<ObtainDataSource>
        //queryAllStudents is an IEnumerable<Student>
        var queryAllStudents = from student in students
                                select student;
        //</ObtainDataSource>

        //<CityFilter>
        var queryStudentSeniors = from student in students
                                  where student.Year == GradeLevel.FourthYear
                                   select student;
        //</CityFilter>

        /* Thinking these are two complicated for the index file. Next commit
         * may remove them.
        IEnumerable<Customer> queryLondonCustomers2 =
                                  from cust in customers
                                  //<AndFilter>
                                  where cust.City == "London" && cust.Name == "Devon"
                                  //</AndFilter>
                                  //<OrFilter>
                                  where cust.City == "London" || cust.City == "Paris"
                                  //</OrFilter>
                                  select cust;
        //<Ordering>
        var queryLondonCustomers3 =
            from cust in customers
            where cust.City == "London"
            orderby cust.Name ascending
            select cust;
        //</Ordering>

        //<Grouping>
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
        //</Grouping>

        //<GroupInto>
        // custQuery is an IEnumerable<IGrouping<string, Customer>>
        var custQuery =
            from cust in customers
            group cust by cust.City into custGroup
            where custGroup.Count() > 2
            orderby custGroup.Key
            select custGroup;
        //</GroupInto>

        //<Join>
        var innerJoinQuery =
            from cust in customers
            join dist in distributors on cust.City equals dist.City
            select new { CustomerName = cust.Name, DistributorName = dist.Name };
        //</Join>
        */
    }

    private static void Transformations()
    {
        // <Transformations>
        // Create the query.
        var peopleInSeattle = (from student in students
                               select student.LastName)
                               .Concat(from teacher in teachers
                                       where teacher.City == "Seattle"
                                       select teacher.Last);

        Console.WriteLine("The following students and teachers live in Seattle:");
        // Execute the query.
        foreach (var person in peopleInSeattle)
        {
            Console.WriteLine(person);
        }
        /* Output:
            The following students and teachers live in Seattle:
            Omelchenko
            O'Donnell
            ...
            Feng
            Svensson
            */
        // </Transformations>
    }

    private static void XmlTransformation()
    {
        // <XmlTransformation>

        // Create the query.
        var studentsToXML = new XElement("Root",
            from student in students
            let scores = string.Join(",", student.Scores)
            select new XElement("student",
                        new XElement("First", student.FirstName),
                        new XElement("Last", student.LastName),
                        new XElement("Scores", scores)
                    ) // end "student"
                ); // end "Root"

        // Execute the query.
        Console.WriteLine(studentsToXML);
        // </XmlTransformation>
        /* Output:
          // <XmlTransformationOutput>
          <Root>
            <student>
              <First>Svetlana</First>
              <Last>Omelchenko</Last>
              <Scores>97,90,73,54</Scores>
            </student>
            <student>
              <First>Claire</First>
              <Last>O'Donnell</Last>
              <Scores>56,78,95,95</Scores>
            </student>
            ...
            <student>
              <First>Max</First>
              <Last>Lindgren</Last>
              <Scores>86,88,96,63</Scores>
            </student>
            <student>
              <First>Arina</First>
              <Last>Ivanova</Last>
              <Scores>93,63,70,80</Scores>
            </student>
          </Root>
          // </XmlTransformationOutput>
        */
    }

    private static void Properties()
    {
        // <Properties>
        var query = from teacher in teachers
                    select teacher.City;
        // </Properties>

        // <AnonymousTypes>
        var query2 = from teacher in teachers
                    select new { Name = teacher.Last, City = teacher.City };
        // </AnonymousTypes>
    }

    //<MethodQuery>
    private static void QueryMethod()
    {
        // Data source.
        double[] radii = [1, 2, 3];

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

        /* Output:
            Area for a circle with a radius of '1' = 3.14
            Area for a circle with a radius of '2' = 12.57
            Area for a circle with a radius of '3' = 28.27
        */
        // </MethodQuery>
    }
}
