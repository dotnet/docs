    class MyBaseClass
    {
        // virtual auto-implemented property. Overrides can only
        // provide specialized behavior if they implement get and set accessors.
        public virtual string Name { get; set; }

        // ordinary virtual property with backing field
        private int num;
        public virtual int Number
        {
            get { return num; }
            set { num = value; }
        }
    }

   
    class MyDerivedClass : MyBaseClass
    {
        private string name;

       // Override auto-implemented property with ordinary property
       // to provide specialized accessor behavior.
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != String.Empty)
                {
                    name = value;
                }
                else
                {
                    name = "Unknown";
                }
            }
        }
 
    }