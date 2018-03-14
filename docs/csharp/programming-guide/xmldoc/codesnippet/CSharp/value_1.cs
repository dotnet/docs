    // compile with: /doc:DocFileName.xml 

    /// text for class Employee
    public class Employee
    {
        private string _name;

        /// <summary>The Name property represents the employee's name.</summary>
        /// <value>The Name property gets/sets the value of the string field, _name.</value>

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }

    /// text for class MainClass
    public class MainClass
    {
        /// text for Main
        static void Main()
        {
        }
    }