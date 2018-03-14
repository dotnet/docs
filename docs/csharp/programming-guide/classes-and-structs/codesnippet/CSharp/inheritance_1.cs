        // WorkItem implicitly inherits from the Object class.
        public class WorkItem
        {
            // Static field currentID stores the job ID of the last WorkItem that
            // has been created.
            private static int currentID;

            //Properties.
            protected int ID { get; set; }
            protected string Title { get; set; }
            protected string Description { get; set; }
            protected TimeSpan jobLength { get; set; }

            // Default constructor. If a derived class does not invoke a base-
            // class constructor explicitly, the default constructor is called
            // implicitly. 
            public WorkItem()
            {
                ID = 0;
                Title = "Default title";
                Description = "Default description.";
                jobLength = new TimeSpan();
            }

            // Instance constructor that has three parameters.
            public WorkItem(string title, string desc, TimeSpan joblen)
            {
                this.ID = GetNextID();
                this.Title = title;
                this.Description = desc;
                this.jobLength = joblen;
            }

            // Static constructor to initialize the static member, currentID. This
            // constructor is called one time, automatically, before any instance
            // of WorkItem or ChangeRequest is created, or currentID is referenced.
            static WorkItem()
            {
                currentID = 0;
            }


            protected int GetNextID()
            {
                // currentID is a static field. It is incremented each time a new
                // instance of WorkItem is created.
                return ++currentID;
            }

            // Method Update enables you to update the title and job length of an
            // existing WorkItem object.
            public void Update(string title, TimeSpan joblen)
            {
                this.Title = title;
                this.jobLength = joblen;
            }

            // Virtual method override of the ToString method that is inherited
            // from System.Object.
            public override string ToString()
            {
                return String.Format("{0} - {1}", this.ID, this.Title);
            }
        }

        // ChangeRequest derives from WorkItem and adds a property (originalItemID) 
        // and two constructors.
        public class ChangeRequest : WorkItem
        {
            protected int originalItemID { get; set; }

            // Constructors. Because neither constructor calls a base-class 
            // constructor explicitly, the default constructor in the base class
            // is called implicitly. The base class must contain a default 
            // constructor.

            // Default constructor for the derived class.
            public ChangeRequest() { }

            // Instance constructor that has four parameters.
            public ChangeRequest(string title, string desc, TimeSpan jobLen,
                                 int originalID)
            {
                // The following properties and the GetNexID method are inherited 
                // from WorkItem.
                this.ID = GetNextID();
                this.Title = title;
                this.Description = desc;
                this.jobLength = jobLen;

                // Property originalItemId is a member of ChangeRequest, but not 
                // of WorkItem.
                this.originalItemID = originalID;
            }
        }

        class Program
        {
            static void Main()
            {
                // Create an instance of WorkItem by using the constructor in the 
                // base class that takes three arguments.
                WorkItem item = new WorkItem("Fix Bugs",
                                             "Fix all bugs in my code branch",
                                             new TimeSpan(3, 4, 0, 0));

                // Create an instance of ChangeRequest by using the constructor in
                // the derived class that takes four arguments.
                ChangeRequest change = new ChangeRequest("Change Base Class Design",
                                                         "Add members to the class",
                                                         new TimeSpan(4, 0, 0),
                                                         1);

                // Use the ToString method defined in WorkItem.
                Console.WriteLine(item.ToString());

                // Use the inherited Update method to change the title of the 
                // ChangeRequest object.
                change.Update("Change the Design of the Base Class",
                    new TimeSpan(4, 0, 0));

                // ChangeRequest inherits WorkItem's override of ToString.
                Console.WriteLine(change.ToString());

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /* Output:
            1 - Fix Bugs
            2 - Change the Design of the Base Class
        */