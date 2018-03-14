using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            //Northwnd db = new Northwnd(@"c:\northwnd.mdf");


        }

        // <Snippet1>
        void OnValidate(ChangeAction action)
        {
            if (action == ChangeAction.Insert)
            {
                Console.WriteLine("Notify billing office.");
            }
        }
        // </Snippet1>
        
    }
}
