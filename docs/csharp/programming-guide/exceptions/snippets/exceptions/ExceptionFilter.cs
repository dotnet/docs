using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptions
{
    public class ExceptionFilter
    {
        public static void Main()
        {
            try
            {
                string s = null;
                Console.WriteLine(s.Length);

            }
            catch (Exception e) when (LogException(e))
            {
            }
            Console.WriteLine("Exception must have been handled");
        }

        private static bool LogException(Exception e)
        {
            Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
            Console.WriteLine($"\tMessage: {e.Message}");
            return false;
        }
    }
}
}
