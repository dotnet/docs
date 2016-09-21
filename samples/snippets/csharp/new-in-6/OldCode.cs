using System.Collections.Generic;

namespace OldStyle
{
    public class Student
    {
        // <ClassicAutoProperties>
        public string FirstName { get; set; }
        // </ClassicAutoProperties>
        public string LastName { get; set; }
        public ICollection<double> Grades { get; private set;}

        public Student()
        {
            Grades = new List<double>();
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
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