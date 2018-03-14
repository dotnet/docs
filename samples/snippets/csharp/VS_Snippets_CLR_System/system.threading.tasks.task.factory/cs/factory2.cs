// <Snippet2>
using System;
using System.IO;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Task<string[]>[] tasks = new Task<string[]>[2];
      String docsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      tasks[0] = Task<string[]>.Factory.StartNew( () => Directory.GetFiles(docsDirectory));
      tasks[1] = Task<string[]>.Factory.StartNew( () => Directory.GetDirectories(docsDirectory));

      Task.Factory.ContinueWhenAll(tasks, completedTasks => {
                                             Console.WriteLine("{0} contains: ", docsDirectory);
                                             Console.WriteLine("   {0} subdirectories", tasks[1].Result.Length);
                                             Console.WriteLine("   {0} files", tasks[0].Result.Length);
                                          } );
   }
}
// The example displays output like the following:
//       C:\Users\<username>\Documents contains:
//          24 subdirectories
//          16 files
// </Snippet2>
