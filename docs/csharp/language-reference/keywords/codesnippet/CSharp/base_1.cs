    public class Person
    {
        protected string ssn = "444-55-6666";
        protected string name = "John L. Malgraine";

        public virtual void GetInfo()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("SSN: {0}", ssn);
        }
    }
    class Employee : Person
    {
        public string id = "ABC567EFG";
        public override void GetInfo()
        {
            // Calling the base class GetInfo method:
            base.GetInfo();
            Console.WriteLine("Employee ID: {0}", id);
        }
    }

    class TestClass
    {
        static void Main()
        {
            Employee E = new Employee();
            E.GetInfo();
        }
    }
    /*
    Output
    Name: John L. Malgraine
    SSN: 444-55-6666
    Employee ID: ABC567EFG
    */
