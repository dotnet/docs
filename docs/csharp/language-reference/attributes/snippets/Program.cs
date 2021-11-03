using System;
using attributes;

namespace AttributeExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceExample.Main();
            ObsoleteProgram.Main();
            ModuleInitializerExampleMain.Main();
            SkipLocalsInitExample.Main();

            var info = new CallerInformation();
            Console.WriteLine("To see these messages, run in the debugger");
            info.DoProcessing();

            try
            {

                info.Operation(null!);
            } catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var sample = Enumerable.Range(0, 100).Sample(10);
                foreach(var item in sample)
                    Console.WriteLine(item);

                // <ShortSequence>
                sample = Enumerable.Range(0, 10).Sample(100);
                // </ShortSequence>
                foreach (var item in sample)
                    Console.WriteLine(item);
            } catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
