using System;
using System.Collections.Generic;

namespace inheritance
{
    //<SnippetClasses>
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
        static WorkItem() => currentID = 0;

        // currentID is a static field. It is incremented each time a new
        // instance of WorkItem is created.
        protected int GetNextID() => ++currentID;

        // Method Update enables you to update the title and job length of an
        // existing WorkItem object.
        public void Update(string title, TimeSpan joblen)
        {
            this.Title = title;
            this.jobLength = joblen;
        }

        // Virtual method override of the ToString method that is inherited
        // from System.Object.
        public override string ToString() =>
            $"{this.ID} - {this.Title}";
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
    // </SnippetClasses>

    // <SnippetPolymorphismOverview>
    public class Shape
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }
    public class Triangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }
    // </SnippetPolymorphismOverview>

    public static class Polymorphism
    {
        public static void Example()
        {
            // <SnippetUsePolymorphism>
            // Polymorphism at work #1: a Rectangle, Triangle and Circle
            // can all be used whereever a Shape is expected. No cast is
            // required because an implicit conversion exists from a derived
            // class to its base class.
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // Polymorphism at work #2: the virtual method Draw is
            // invoked on each of the derived classes, not the base class.
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
            /* Output:
                Drawing a rectangle
                Performing base class drawing tasks
                Drawing a triangle
                Performing base class drawing tasks
                Drawing a circle
                Performing base class drawing tasks
            */
            // </SnippetUsePolymorphism>
        }

        public static void VirtualExamples()
        {
            //<SnippetTestVirtualMethods>
            DerivedClass B = new DerivedClass();
            B.DoWork();  // Calls the new method.

            BaseClass A = B;
            A.DoWork();  // Also calls the new method.
            //</SnippetTestVirtualMethods>
        }
    }

    //<SnippetVirtualMethods>
    public class BaseClass
    {
        public virtual void DoWork() { }
        public virtual int WorkProperty
        {
            get { return 0; }
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void DoWork() { }
        public override int WorkProperty
        {
            get { return 0; }
        }
    }
    //</SnippetVirtualMethods>

    namespace NewMethodHierarchy
    {
        //<SnippetNewMethods>
        public class BaseClass
        {
            public void DoWork() { WorkField++; }
            public int WorkField;
            public int WorkProperty
            {
                get { return 0; }
            }
        }

        public class DerivedClass : BaseClass
        {
            public new void DoWork() { WorkField++; }
            public new int WorkField;
            public new int WorkProperty
            {
                get { return 0; }
            }
        }
        //</SnippetNewMethods>

        public static class NewMethods
        {
            public static void Example()
            {
                //<SnippetUseNewMethods>
                DerivedClass B = new DerivedClass();
                B.DoWork();  // Calls the new method.

                BaseClass A = (BaseClass)B;
                A.DoWork();  // Calls the old method.
                //</SnippetUseNewMethods>
            }
        }
    }

}
