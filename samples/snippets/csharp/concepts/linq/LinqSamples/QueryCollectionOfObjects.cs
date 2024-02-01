using static LinqSamples.Student;

namespace LinqSamples;

public static class QueryCollectionOfObjects
{
    public static void QueryCollectionOfObjects1()
    {
        // <query_a_collection_of_objects_2>
        void QueryHighScores(int exam, int score)
        {
            var highScores =
                from student in students
                where student.ExamScores[exam] > score
                select new
                {
                    Name = student.FirstName,
                    Score = student.ExamScores[exam]
                };

            foreach (var item in highScores)
            {
                Console.WriteLine($"{item.Name,-15}{item.Score}");
            }
        }

        QueryHighScores(0, 90);
        // </query_a_collection_of_objects_2>
    }
}
