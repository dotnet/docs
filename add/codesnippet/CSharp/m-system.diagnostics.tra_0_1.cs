    public class MyTraceSource : TraceSource
    {
        string firstAttribute = "";
        string secondAttribute = "";
        public MyTraceSource(string n) : base(n) {}

        public string FirstTraceSourceAttribute
        {
            get {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "firsttracesourceattribute")
                        firstAttribute = de.Value.ToString() ; 
                return firstAttribute;
            }
            set { firstAttribute = value; }
        }

        public string SecondTraceSourceAttribute
        {
            get {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "secondtracesourceattribute")
                        secondAttribute = de.Value.ToString();
                return secondAttribute; }
            set { secondAttribute = value; }
        }

        protected override string[] GetSupportedAttributes()
        {
            // Allow the use of the attributes in the configuration file.
            return new string[] { "FirstTraceSourceAttribute", "SecondTraceSourceAttribute" };
        }
    }