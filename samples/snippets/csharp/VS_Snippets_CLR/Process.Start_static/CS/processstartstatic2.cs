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
