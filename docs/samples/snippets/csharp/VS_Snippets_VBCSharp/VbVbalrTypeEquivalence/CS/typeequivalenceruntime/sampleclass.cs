//<Snippet5>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeEquivalenceInterface;

namespace TypeEquivalenceRuntime
{
    public class SampleClass : ISampleInterface
    {
        private string p_UserInput;
        public string UserInput { get { return p_UserInput; } }

        public void GetUserInput()
        {
            Console.WriteLine("Please enter a value:");
            p_UserInput = Console.ReadLine();
        }
//</Snippet5>
//<Snippet7>
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
//</Snippet7>
//<Snippet6>
    }
}
//</Snippet6>
