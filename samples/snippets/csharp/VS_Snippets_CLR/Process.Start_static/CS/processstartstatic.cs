// <Snippet1>
using System;
using System.Diagnostics;
using System.ComponentModel;

namespace MyProcessSample
{
    class MyProcess
    {
        // Opens the Internet Explorer application.
        void OpenApplication(string myFavoritesPath)
        {
            // Start Internet Explorer. Defaults to the home page.
            Process.Start("IExplore.exe");

            // Display the contents of the favorites folder in the browser.
            Process.Start(myFavoritesPath);
        }
        
        // Opens urls and .html documents using Internet Explorer.
        void OpenWithArguments()
        {
            // url's are not considered documents. They can only be opened
            // by passing them as arguments.
            Process.Start("IExplore.exe", "www.northwindtraders.com");

            // Start a Web page using a browser associated with .html and .asp files.
            Process.Start("IExplore.exe", "C:\\myPath\\myFile.htm");
            Process.Start("IExplore.exe", "C:\\myPath\\myFile.asp");
        }

        // Uses the ProcessStartInfo class to start new processes,
        // both in a minimized mode.
        void OpenWithStartInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Process.Start(startInfo);

            startInfo.Arguments = "www.northwindtraders.com";

            Process.Start(startInfo);
        }

        static void Main()
        {
            // Get the path that stores favorite links.
            string myFavoritesPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

            MyProcess myProcess = new MyProcess();

            myProcess.OpenApplication(myFavoritesPath);
            myProcess.OpenWithArguments();
            myProcess.OpenWithStartInfo();
        }
    }
}
// </Snippet1>
// <Snippet2>
// Place this code into a console project called StartArgsEcho. It depends on the
// console application named argsecho.exe.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StartArgsEcho
{
    class Program
    {
        static void Main()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("argsecho.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;

            // Start with one argument.
            // Output of ArgsEcho:
            //  [0]=/a            
            startInfo.Arguments = "/a";
            Process.Start(startInfo);

            // Start with multiple arguments separated by spaces.
            // Output of ArgsEcho:
            //  [0] = /a
            //  [1] = /b
            //  [2] = c:\temp
            startInfo.Arguments = "/a /b c:\\temp";
            Process.Start(startInfo);

            // An argument with spaces inside quotes is interpreted as multiple arguments.
            // Output of ArgsEcho:
            //  [0] = /a
            //  [1] = literal string arg
            startInfo.Arguments = "/a \"literal string arg\"";
            Process.Start(startInfo);

            // An argument inside double quotes is interpreted as if the quote weren't there,
            // that is, as separate arguments. Equivalent verbatim string is @"/a /b:""string with quotes"""
            // Output of ArgsEcho:
            //  [0] = /a
            //  [1] = /b:string
            //  [2] = in
            //  [3] = double
            //  [4] = quotes
            startInfo.Arguments = "/a /b:\"\"string in double quotes\"\"";
            Process.Start(startInfo);

            // Triple-escape quotation marks to include the character in the final argument received
            // by the target process. Equivalent verbatim string: @"/a /b:""""""quoted string""""""";
            //  [0] = /a
            //  [1] = /b:"quoted string"
            startInfo.Arguments = "/a /b:\"\"\"quoted string\"\"\"";
            Process.Start(startInfo);
        }
    }
}
// </Snippet2>
// <Snippet3>
// Place this code into a console project called ArgsEcho to build the argsecho.exe target

using System;

namespace StartArgs
{
    class ArgsEcho
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Received the following arguments:\n");

            for (var i = 0; i < args.Length; i++)
            {
                Console.WriteLine("[" + i + "] = " + args[i]);
            }
            
            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
// </Snippet3>