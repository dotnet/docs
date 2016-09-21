using System.Collections;
using System.Collections.Generic;

namespace NewStyle
{
    public class Enrollment : IEnumerable<Student>
    {
        private List<Student> allStudents = new List<Student>();

        public void Enroll(Student s)
        {
            allStudents.Add(s);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return ((IEnumerable<Student>)allStudents).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Student>)allStudents).GetEnumerator();
        }
    }
}