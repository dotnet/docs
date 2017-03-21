using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ClassLibrary1;

namespace ConsoleApplication7
{
    //<snippet1>
    public class Test2
    {
        [Import]
        public Test1 data { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryCatalog catalog = new DirectoryCatalog(".");
            CompositionContainer container = new CompositionContainer(catalog);
            Test2 test = new Test2();
            container.SatisfyImportsOnce(test);
            Console.WriteLine(test.data.data);
            Console.ReadLine();
        }
    }
    //</snippet1>
}
