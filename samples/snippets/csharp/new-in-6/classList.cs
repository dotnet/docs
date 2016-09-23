namespace NewStyle
{
    // <ExtensionAddSample>
    public class ClassList
    {
        public Enrollment CreateEnrollment()
        {
            // <InitializeEnrollment>
            var classList = new Enrollment()
            {
                new Student("Lessie", "Crosby"),
                new Student("Vicki", "Petty"),
                new Student("Ofelia", "Hobbs"),
                new Student("Leah", "Kinney"),
                new Student("Alton", "Stoker"),
                new Student("Luella", "Ferrell"),
                new Student("Marcy", "Riggs"),
                new Student("Ida", "Bean"),
                new Student("Ollie", "Cottle"),
                new Student("Tommy", "Broadnax"),
                new Student("Jody", "Yates"),
                new Student("Marguerite", "Dawson"),
                new Student("Francisca", "Barnett"),
                new Student("Arlene", "Velasquez"),
                new Student("Jodi", "Green"),
                new Student("Fran", "Mosley"),
                new Student("Taylor", "Nesmith"),
                new Student("Ernesto", "Greathouse"),
                new Student("Margret", "Albert"),
                new Student("Pansy", "House"),
                new Student("Sharon", "Byrd"),
                new Student("Keith", "Roldan"),
                new Student("Martha", "Miranda"),
                new Student("Kari", "Campos"),
                new Student("Muriel", "Middleton"),
                new Student("Georgette", "Jarvis"),
                new Student("Pam", "Boyle"),
                new Student("Deena", "Travis"),
                new Student("Cary", "Totten"),
                new Student("Althea", "Goodwin")
            };
            // </InitializeEnrollment>
            return classList;
        }           
    }

    // <ExtensionAdd>
    public static class StudentExtensions
    {
        public static void Add(this Enrollment e, Student s) => e.Enroll(s);
    }
    // </ExtensionAdd>
    // </ExtensionAddSample>
}