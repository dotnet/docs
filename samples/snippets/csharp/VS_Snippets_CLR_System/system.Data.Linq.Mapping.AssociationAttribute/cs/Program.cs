using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Common;

namespace cs_testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            

            
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            Console.ReadLine();
        }

        
    }
}
