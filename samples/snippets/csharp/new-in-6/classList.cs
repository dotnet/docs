namespace NewStyle
{
    public class ClassList
    {
        public void method()
        {
            // <InitializeEnrollment>
            var classList = new Enrollment()
            {
                new Student("Bill", "Wagner"),
                new Student("First", "Last")
            };
            // </InitializeEnrollment>
        }           
    }

    // <ExtensionAdd>
    public static class StudentExtensions
    {
        public static void Add(this Enrollment e, Student s) => e.Enroll(s);
    }
    // </ExtensionAdd>
}