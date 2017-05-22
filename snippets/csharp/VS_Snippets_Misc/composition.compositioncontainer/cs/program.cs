using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CompositionContainerExample
{
    //<snippet1>
    [Export]
    class MyAddin
    {
        public String myData { get { return "The data!"; } }
    }

    class MyProgram
    {
        [Import]
        public MyAddin myAddin { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyAddin).Assembly));
            CompositionContainer _container = new CompositionContainer(catalog);
            MyProgram myProgram = new MyProgram();
            _container.SatisfyImportsOnce(myProgram);
            Console.WriteLine(myProgram.myAddin.myData);
            Console.ReadLine();

            _container.Dispose();
        }
    }
    //</snippet1>
}
