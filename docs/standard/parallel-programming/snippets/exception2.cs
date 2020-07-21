// <example>
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class ExceptionTwoExample
{
    public static async Task Main()
    {
        var task = Task.Run(
            () =>
            {
                string fileText = File.ReadAllText(@"C:\NonexistentFile.txt");
                return fileText;
            });

        Task continuation = task.ContinueWith(
            antecedent =>
            {
                var fileNotFound =
                    antecedent.Exception
                        ?.InnerExceptions
                        ?.FirstOrDefault(e => e is FileNotFoundException) as FileNotFoundException;

                if (fileNotFound != null)
                {
                    Console.WriteLine(fileNotFound.Message);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

        await continuation;

        Console.ReadLine();
    }
}
// The example displays the following output:
//        Could not find file 'C:\NonexistentFile.txt'.
// </example>

public class Example2
{
    public static void ShowTaskException()
    {
        var task = Task.Run(
            () =>
            {
                string fileText = File.ReadAllText(@"C:\NonexistentFile.txt");
                return fileText;
            });

        Task continuation = task.ContinueWith(
            antecedent =>
            {
                // <exception>
                var fileNotFound =
                    antecedent.Exception
                        ?.InnerExceptions
                        ?.FirstOrDefault(e => e is FileNotFoundException) as FileNotFoundException;

                if (fileNotFound != null)
                {
                    Console.WriteLine(fileNotFound.Message);
                }
                // </exception>
            }, TaskContinuationOptions.OnlyOnFaulted);
    }
}