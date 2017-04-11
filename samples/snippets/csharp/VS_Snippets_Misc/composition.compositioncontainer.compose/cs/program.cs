using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace ConsoleApplication5
{
    //<snippet1>
    [Export]
    class Part1
    {
        public String data = "This is the example data!";
    }

    [Export]
    class Part2
    {
        [Import]
        public Part1 data { get; set; }

    }

    [Export]
    class Part3
    {
        [Import]
        public Part2 data { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CompositionContainer container = new CompositionContainer();
            CompositionBatch batch = new CompositionBatch();
            batch.AddPart(AttributedModelServices.CreatePart(new Part1()));
            batch.AddPart(AttributedModelServices.CreatePart(new Part2()));
            batch.AddPart(AttributedModelServices.CreatePart(new Part3()));
            container.Compose(batch);
            Part3 _part = container.GetExportedValue<Part3>();
            Console.WriteLine(_part.data.data.data);
            Console.ReadLine();
        }
    }
    //</snippet1>
}
