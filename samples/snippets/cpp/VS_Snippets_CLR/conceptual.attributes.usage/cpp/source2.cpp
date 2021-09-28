using namespace System;

namespace CustomCodeAttributes
{
    //<snippet4>
    [AttributeUsage(AttributeTargets::All)]
    public ref class DeveloperAttribute : Attribute
    {
        // Private fields.
    private:
        String^ name;
        String^ level;
        bool reviewed;

    public:
        // This constructor defines two required parameters: name and level.

        DeveloperAttribute(String^ name, String^ level)
        {
            this->name = name;
            this->level = level;
            this->reviewed = false;
        }

        // Define Name property.
        // This is a read-only attribute.

        virtual property String^ Name
        {
            String^ get() {return name;}
        }

        // Define Level property.
        // This is a read-only attribute.

        virtual property String^ Level
        {
            String^ get() {return level;}
        }

        // Define Reviewed property.
        // This is a read/write attribute.

        virtual property bool Reviewed
        {
            bool get() {return reviewed;}
            void set(bool value) {reviewed = value;}
        }
    };
    //</snippet4>
}

namespace CustomCodeAttributes_Examples1
{
    //<snippet5>
    [AttributeUsage(AttributeTargets::All, Inherited = false, AllowMultiple = true)]
    //</snippet5>
    public ref class DummyAttribute1 : Attribute
    {
    };

    //<snippet6>
    [AttributeUsage(AttributeTargets::Class | AttributeTargets::Method)]
    //</snippet6>
    public ref class DummyAttribute2 : Attribute
    {
    };

    //<snippet7>
    // This defaults to Inherited = true.
    public ref class MyAttribute : Attribute
    {
        //...
    };

    [AttributeUsage(AttributeTargets::Method, Inherited = false)]
    public ref class YourAttribute : Attribute
    {
        //...
    };
    //</snippet7>

    //<snippet9>
    public ref class MyClass
    {
    public:
        [MyAttribute]
        [YourAttribute]
        virtual void MyMethod()
        {
            //...
        }
    };
    //</snippet9>

    //<snippet10>
    public ref class YourClass : MyClass
    {
    public:
        // MyMethod will have MyAttribute but not YourAttribute.
        virtual void MyMethod() override
        {
            //...
        }

    };
    //</snippet10>
}

namespace CustomCodeAttributes_Examples2
{
    //<snippet11>
    //This defaults to AllowMultiple = false.
    public ref class MyAttribute : Attribute
    {
    };

    [AttributeUsage(AttributeTargets::Method, AllowMultiple = true)]
    public ref class YourAttribute : Attribute
    {
    };
    //</snippet11>

// #if'd out since MyClass will intentionally not compile
#if 0
    //<snippet12>
    [Developer("Joan Smith", "1")]

    -or-

    [Developer("Joan Smith", "1", Reviewed = true)]
    //</snippet12>

    //<snippet13>
    public ref class MyClass
    {
    public:
        // This produces an error.
        // Duplicates are not allowed.
        [MyAttribute]
        [MyAttribute]
        void MyMethod()
        {
            //...
        }

        // This is valid.
        [YourAttribute]
        [YourAttribute]
        void YourMethod()
        {
            //...
        }
    };
    //</snippet13>
#endif
}

namespace CustomCodeAttributes_Examples3
{
    //<snippet14>
    [AttributeUsage(AttributeTargets::Method)]
    public ref class MyAttribute : Attribute
    {
        // . . .
    };
    //</snippet14>
}

namespace CustomCodeAttributes_Examples4
{
    public ref class MyAttribute : Attribute
    {
    private:
        bool myvalue;
        String^ myoptional;

    public:
        //<snippet15>
        MyAttribute(bool myvalue)
        {
            this->myvalue = myvalue;
        }
        //</snippet15>

        //<snippet16>
        property bool MyProperty
        {
            bool get() {return this->myvalue;}
            void set(bool value) {this->myvalue = value;}
        }
        //</snippet16>

        property String^ OptionalParameter
        {
            String^ get() {return this->myoptional;}
            void set(String^ value) {this->myoptional = value;}
        }
    };

    //<snippet17>
    // One required (positional) and one optional (named) parameter are applied.
    [MyAttribute(false, OptionalParameter = "optional data")]
    public ref class SomeClass
    {
        //...
    };
    // One required (positional) parameter is applied.
    [MyAttribute(false)]
    public ref class SomeOtherClass
    {
        //...
    };
    //</snippet17>
}

