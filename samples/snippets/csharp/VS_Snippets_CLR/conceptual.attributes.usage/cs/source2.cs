using System;

namespace CustomCodeAttributes
{
    //<snippet4>
    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperAttribute : Attribute
    {
        // Private fields.
        private string name;
        private string level;
        private bool reviewed;

        // This constructor defines two required parameters: name and level.

        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }

        // Define Name property.
        // This is a read-only attribute.

        public virtual string Name
        {
            get {return name;}
        }

        // Define Level property.
        // This is a read-only attribute.

        public virtual string Level
        {
            get {return level;}
        }

        // Define Reviewed property.
        // This is a read/write attribute.

        public virtual bool Reviewed
        {
            get {return reviewed;}
            set {reviewed = value;}
        }
    }
    //</snippet4>
}

namespace CustomCodeAttributes_Examples1
{
    //<snippet5>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    //</snippet5>
    public class DummyAttribute1 : Attribute
    {
    }

    //<snippet6>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //</snippet6>
    public class DummyAttribute2 : Attribute
    {
    }

    //<snippet7>
    // This defaults to Inherited = true.
    public class MyAttribute : Attribute
    {
        //...
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class YourAttribute : Attribute
    {
        //...
    }
    //</snippet7>

    //<snippet9>
    public class MyClass
    {
        [MyAttribute]
        [YourAttribute]
        public virtual void MyMethod()
        {
            //...
        }
    }
    //</snippet9>

    //<snippet10>
    public class YourClass : MyClass
    {
        // MyMethod will have MyAttribute but not YourAttribute.
        public override void MyMethod()
        {
            //...
        }

    }
    //</snippet10>
}

namespace CustomCodeAttributes_Examples2
{
    //<snippet11>
    //This defaults to AllowMultiple = false.
    public class MyAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class YourAttribute : Attribute
    {
    }
    //</snippet11>

// #if'd out since MyClass will intentionally not compile
#if false
    //<snippet12>
    [Developer("Joan Smith", "1")]
    
    -or-
    
    [Developer("Joan Smith", "1", Reviewed = true)]
    //</snippet12>

    //<snippet13>
    public class MyClass
    {
        // This produces an error.
        // Duplicates are not allowed.
        [MyAttribute]
        [MyAttribute]
        public void MyMethod()
        {
            //...
        }

        // This is valid.
        [YourAttribute]
        [YourAttribute]
        public void YourMethod()
        {
            //...
        }
    }
    //</snippet13>
#endif
}

namespace CustomCodeAttributes_Examples3
{
    //<snippet14>
    [AttributeUsage(AttributeTargets.Method)]
    public class MyAttribute : Attribute
    {
        // . . .
    }
    //</snippet14>
}

namespace CustomCodeAttributes_Examples4
{
    public class MyAttribute : Attribute
    {
        private bool myvalue;
        private string myoptional;

        //<snippet15>
        public MyAttribute(bool myvalue)
        {
            this.myvalue = myvalue;
        }
        //</snippet15>

        //<snippet16>
        public bool MyProperty
        {
            get {return this.myvalue;}
            set {this.myvalue = value;}
        }
        //</snippet16>

        public string OptionalParameter
        {
            get {return this.myoptional;}
            set {this.myoptional = value;}
        }
    }

    //<snippet17>
    // One required (positional) and one optional (named) parameter are applied.
    [MyAttribute(false, OptionalParameter = "optional data")]
    public class SomeClass
    {
        //...
    }
    // One required (positional) parameter is applied.
    [MyAttribute(false)]
    public class SomeOtherClass
    {
        //...
    }
    //</snippet17>
}

