using System;
using System.Collections.Generic;

namespace OldStyle
{
    public class Student
    {
        // <ClassicAutoProperty>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // </ClassicAutoProperty>
        public ICollection<double> Grades { get; private set;}

        public Student()
        {
            Grades = new List<double>();
        }

        // <stringFormat>
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        // </stringFormat>
    }
}

namespace ReadOnlyOldStyle
{
    public class Student
    {
        // <ClassicReadOnlyAutoProperty>
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        // </ClassicReadOnlyAutoProperty>

        // <Construction>
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        // </Construction>
    }
}