using System;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Basic.Example.Main();
            IsA_Namespace.Example.Main();
            AccessExample.Main(args);
            Example.Example.Main();
            ClassNameExample.Main();
            ClassExample.Main();
        }
    }
}
