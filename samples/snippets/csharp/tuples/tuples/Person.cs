using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuples
{
    #region 12_TypeWithDeconstructMethod
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
    #endregion

    #region 13_ExtensionDeconstructMethod
    public class Student : Person
    {
        public double GPA { get; }
        public Student(string first, string last, double gpa) :
            base(first, last)
        {
            GPA = gpa;
        }
    }

    public static class Extensions
    {
        public static void Deconstruct(this Student s, out string first, out string last, out double gpa)
        {
            first = s.FirstName;
            last = s.LastName;
            gpa = s.GPA;
        }
    }
    #endregion
}
