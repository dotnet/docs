namespace NewStyle
{
    public class ClassList
    {
        public void method()
        {
            var classList = new Enrollment()
            {
                new Student("Bill", "Wagner"),
                new Student("First", "Last")
            };
        }           
    }

    public static class StudentExtensions
    {
        public static void Add(this Enrollment e, Student s) => e.Enroll(s);
    }
}