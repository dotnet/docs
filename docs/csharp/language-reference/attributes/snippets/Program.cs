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
        }
    }
}
