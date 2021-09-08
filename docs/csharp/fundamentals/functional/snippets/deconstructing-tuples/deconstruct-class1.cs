namespace Deconstruction
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Person(string fname, string mname, string lname)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
        }
        // <Snippet1>
        public void Deconstruct(out string fname, out string mname, out string lname)
        // </Snippet1>
        {
            fname = FirstName;
            mname = MiddleName;
            lname = LastName;
        }
    }

    public class Example
    {
        public static void Main()
        {
            var p = new Person("John", "Quincy", "Adams");
            // <Snippet2>
            var (fName, mName, lName) = p;
            // </Snippet2>
        }
    }
}
