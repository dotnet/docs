// <snippet12>
public static partial class Program
{
    public static void TaskException()
    {
        // This should throw an UnauthorizedAccessException.
        try
        {
            if (GetAllFiles(@"C:\") is { Length: > 0 } files)
            {
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                Console.WriteLine(
                    "{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
        Console.WriteLine();

        // This should throw an ArgumentException.
        try
        {
            foreach (var s in GetAllFiles(""))
            {
                Console.WriteLine(s);
            }
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
                Console.WriteLine(
                    "{0}: {1}", ex.GetType().Name, ex.Message);
        }
    }

    static string[] GetAllFiles(string path)
    {
        var task1 =
            Task.Run(() => Directory.GetFiles(
                path, "*.txt",
                SearchOption.AllDirectories));

        try
        {
            return task1.Result;
        }
        catch (AggregateException ae)
        {
            ae.Handle(x =>
            {
                // Handle an UnauthorizedAccessException
                if (x is UnauthorizedAccessException)
                {
                    Console.WriteLine(
                        "You do not have permission to access all folders in this path.");
                    Console.WriteLine(
                        "See your network administrator or try another path.");
                }
                return x is UnauthorizedAccessException;
            });
            return Array.Empty<string>();
        }
    }
}
// The example displays the following output:
//       You do not have permission to access all folders in this path.
//       See your network administrator or try another path.
//
//       ArgumentException: The path is not of a legal form.
// </snippet12>
