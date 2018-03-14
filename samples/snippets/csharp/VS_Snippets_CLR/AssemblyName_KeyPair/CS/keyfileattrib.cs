//<snippet20>
using System;
using System.Reflection;

//<snippet21>
[assembly:AssemblyKeyFileAttribute("keyfile.snk")]
//</snippet21>
namespace KeyFileAttrib
{
    public class Dummy
    {
        public static void Main()
        {
            Console.WriteLine("KeyFileAttrib.Dummy.Main()");
        }
    }
}
//</snippet20>
