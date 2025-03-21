using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace MapCLRFunctionToStoreFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //<snippet4>
            using (SchoolEntities context = new SchoolEntities())
            {
                var students = from s in context.People
                               where s.EnrollmentDate != null
                               select new
                               {
                                   name = s.LastName,
                                   avgGrade = AvgStudentGrade(s.PersonID)
                               };

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.name}: {student.avgGrade}");
                }
            }
            //</snippet4>
        }
        //<snippet3>
        [EdmFunction("SchoolModel.Store", "AvgStudentGrade")]
        public static decimal? AvgStudentGrade(int studentId)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
        //</snippet3>
    }
}
