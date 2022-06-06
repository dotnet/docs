// <snippet13>
public static partial class Program
{
    public static void TaskExceptionTwo()
    {
        try
        {
            ExecuteTasks();
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.InnerExceptions)
            {
                Console.WriteLine(
                    "{0}:\n   {1}", e.GetType().Name, e.Message);
            }
        }
    }

    static void ExecuteTasks()
    {
        // Assume this is a user-entered String.
        string path = @"C:\";
        List<Task> tasks = new();

        tasks.Add(Task.Run(() =>
        {
            // This should throw an UnauthorizedAccessException.
            return Directory.GetFiles(
                path, "*.txt",
                SearchOption.AllDirectories);
        }));

        tasks.Add(Task.Run(() =>
        {
            if (path == @"C:\")
            {
                throw new ArgumentException(
                    "The system root is not a valid path.");
            }
            return new string[] { ".txt", ".dll", ".exe", ".bin", ".dat" };
        }));

        tasks.Add(Task.Run(() =>
        {
            throw new NotImplementedException(
                "This operation has not been implemented.");
        }));

        try
        {
            Task.WaitAll(tasks.ToArray());
        }
        catch (AggregateException ae)
        {
            throw ae.Flatten();
        }
    }
}
// The example displays the following output:
//       UnauthorizedAccessException:
//          Access to the path 'C:\Documents and Settings' is denied.
//       ArgumentException:
//          The system root is not a valid path.
//       NotImplementedException:
//          This operation has not been implemented.
// </Snippet13>
