// <Snippet1>
using System;
using System.Web.Compilation;
using System.IO;

namespace Samples.Process
{
    public class postProcessTest : IAssemblyPostProcessor
    {
        public static void Main(String[] args)
        {
        }

        public void PostProcessAssembly(string path)
        {
            StreamWriter sw = File.CreateText(@"c:\compile\MyTest.txt");
            sw.WriteLine("Compiled assembly:");
            sw.WriteLine(path);
            sw.Close();
        }

        public void Dispose()
        {

        }
    }
}
// </Snippet1>
