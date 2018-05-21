    public class BaseClass
    {
        private string name = "Name-BaseClass";
        private string id = "ID-BaseClass";

        public string Name
        {
            get { return name; }
            set { }
        }

        public string Id
        {
            get { return id; }
            set { }
        }
    }

    public class DerivedClass : BaseClass
    {
        private string name = "Name-DerivedClass";
        private string id = "ID-DerivedClass";

        new public string Name
        {
            get
            {
                return name;
            }

            // Using "protected" would make the set accessor not accessible. 
            set
            {
                name = value;
            }
        }

        // Using private on the following property hides it in the Main Class.
        // Any assignment to the property will use Id in BaseClass.
        new private string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }

    class MainClass
    {
        static void Main()
        {
            BaseClass b1 = new BaseClass();
            DerivedClass d1 = new DerivedClass();

            b1.Name = "Mary";
            d1.Name = "John";

            b1.Id = "Mary123";
            d1.Id = "John123";  // The BaseClass.Id property is called.

            System.Console.WriteLine("Base: {0}, {1}", b1.Name, b1.Id);
            System.Console.WriteLine("Derived: {0}, {1}", d1.Name, d1.Id);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
        Base: Name-BaseClass, ID-BaseClass
        Derived: John, ID-BaseClass
    */