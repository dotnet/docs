//<Snippet1>
using System;
//</Snippet1>

namespace namespaces
{
    class Program
    {
        static void Main(string[] args)
        {
		//<Snippet22>
        System.Console.WriteLine("Hello World!");
		//</Snippet22>

		//<Snippet23>
        Console.WriteLine("Hello World!");
		//</Snippet23>
        }
    }
}

//<Snippet6>
namespace SampleNamespace
{
    class SampleClass
    {
        public void SampleMethod()
        {
            System.Console.WriteLine(
                "SampleMethod inside SampleNamespace");
        }
    }
}
//</Snippet6>

