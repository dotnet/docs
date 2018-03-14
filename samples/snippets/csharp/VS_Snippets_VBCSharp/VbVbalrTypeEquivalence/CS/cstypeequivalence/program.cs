//<Snippet8>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeEquivalenceInterface;
using System.Reflection;

namespace TypeEquivalenceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly sampleAssembly = Assembly.Load("TypeEquivalenceRuntime");
            ISampleInterface sampleClass = 
                (ISampleInterface)sampleAssembly.CreateInstance("TypeEquivalenceRuntime.SampleClass");
            sampleClass.GetUserInput();
            Console.WriteLine(sampleClass.UserInput);
            Console.WriteLine(sampleAssembly.GetName().Version.ToString());
            Console.ReadLine();
        }
    }
}
//</Snippet8>
