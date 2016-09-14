using System.Collections.Generic;

namespace OldStyle
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<double> Grades { get; private set;}

        public Student()
        {
            Grades = new List<double>();
        }
    }
}

namespace ReadOnlyOldStyle
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}