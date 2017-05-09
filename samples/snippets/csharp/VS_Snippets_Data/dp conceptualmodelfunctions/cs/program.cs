using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace ConceptualModelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            A();
            B();
        }

        //<snippet2>
        [EdmFunction("SchoolModel", "YearsSince")]
        public static int YearsSince(DateTime date)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
        //</snippet2>

        [EdmFunction("SchoolModel", "GetYearsEmployed")]
        public static int GetYearsEmployed(Person person)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }

        public static void A()
        {
            //<snippet3>
            using (SchoolEntities context = new SchoolEntities())
            {
                // Retrieve instructors hired more than 10 years ago.
                var instructors = from p in context.People
                                  where YearsSince((DateTime)p.HireDate) > 10
                                  select p;

                foreach (var instructor in instructors)
                {
                    Console.WriteLine(instructor.LastName);
                }
            }
            //</snippet3>
        }

        public static void B()
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                // Retrieve instructors hired more than 10 years ago.
                var instructors = from p in context.People
                                  where GetYearsEmployed(p) > 10
                                  select p;

                foreach (var instructor in instructors)
                {
                    Console.WriteLine(instructor.LastName);
                }
            }
        }
    }
}
