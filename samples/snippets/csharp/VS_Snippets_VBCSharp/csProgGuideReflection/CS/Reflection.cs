
using System;

namespace CsCsrefProgrammingReflection
{
    class TestReflection
    {
        static void Main()
        {
            //<Snippet1>
            // Using GetType to obtain type information:
            int i = 42;
            System.Type type = i.GetType();
            System.Console.WriteLine(type);
            //</Snippet1>


            //<Snippet2>
            // Using Reflection to get information from an Assembly:
            System.Reflection.Assembly info = typeof(System.Int32).Assembly;
            System.Console.WriteLine(info);
            //</Snippet2>
        }
    }
}
