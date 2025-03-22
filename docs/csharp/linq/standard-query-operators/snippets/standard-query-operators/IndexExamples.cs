using System.Xml.Linq;

namespace StandardQueryOperators;

internal class IndexExamples
{
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Sentences();
        PartsOfAQuery();
        XmlTransformation();
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
            Console.WriteLine($"Words of length {obj.Length}:");
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
}
