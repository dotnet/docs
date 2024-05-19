using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            SerializationCountExample.RunIt();
            Console.WriteLine();
            PrivateFieldsExample.RunIt();
            Console.WriteLine();
            IgnoreTypeExample.RunIt();
            Console.WriteLine();
            AllowIntsAsStringsExample.RunIt();
        }
    }
}
