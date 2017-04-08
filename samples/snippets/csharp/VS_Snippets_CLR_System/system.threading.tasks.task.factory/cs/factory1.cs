// <Snippet1>
using System;
using System.IO;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Task[] tasks = new Task[2];
      String[] files = null;
      String[] dirs = null;
      String docsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      tasks[0] = Task.Factory.StartNew( () => files = Directory.GetFiles(docsDirectory));
      tasks[1] = Task.Factory.StartNew( () => dirs = Directory.GetDirectories(docsDirectory));

      Task.Factory.ContinueWhenAll(tasks, completedTasks => {
                                             Console.WriteLine("{0} contains: ", docsDirectory);
                                             Console.WriteLine("   {0} subdirectories", dirs.Length);
                                             Console.WriteLine("   {0} files", files.Length);
                                          } );
   }
}
// The example displays output like the following:
//       C:\Users\<username>\Documents contains:
//          24 subdirectories
//          16 files
// </Snippet1>
