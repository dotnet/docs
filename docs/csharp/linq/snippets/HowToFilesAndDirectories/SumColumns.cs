namespace HowToFilesAndDirectories;

// <SumColumns>
public static class SumColumns
{
    public static void ProcessColumns(string filePath, string seperator)
    {
        // Divide each exam into a group
        var exams = from line in MatrixFrom(filePath, seperator)
                    from score in line

                    // Identify the column number
                    let colNumber = Array.FindIndex(line, t => ReferenceEquals(score, t))

                    // The first column is the student ID, not the exam score
                    // so it needs to be excluded
                    where colNumber > 0

                    // Convert the score from string to int
                    // Group by column number, i.e. one group per exam
                    group double.Parse(score) by colNumber into g
                    select new
                    {
                        Title = $"Exam#{g.Key}",
                        Min = g.Min(),
                        Max = g.Max(),
                        Avg = Math.Round(g.Average(), 2),
                        Total = g.Sum()
                    };

        foreach (var exam in exams)
        {
            Console.WriteLine($"{exam.Title}\t"
            + $"Average:{exam.Avg,6}\t"
            + $"High Score:{exam.Max,3}\t"
            + $"Low Score:{exam.Min,3}\t"
            + $"Total:{exam.Total,5}");
        }
    }

    // Transform the file content to an IEnumerable of string arrays
    // like a matrix
    private static IEnumerable<string[]> MatrixFrom(string filePath, string seperator)
    {
        using StreamReader reader = File.OpenText(filePath);

        for (string? line = reader.ReadLine(); line is not null; line = reader.ReadLine())
        {
            yield return line.Split(seperator, StringSplitOptions.TrimEntries);
        }
    }
}

// Output:
// Exam#1  Average: 86.08  High Score: 99  Low Score: 35   Total: 1033
// Exam#2  Average: 86.42  High Score: 94  Low Score: 72   Total: 1037
// Exam#3  Average: 84.75  High Score: 91  Low Score: 65   Total: 1017
// Exam#4  Average: 76.92  High Score: 94  Low Score: 39   Total:  923
// </SumColumns>
