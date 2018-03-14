using System;

namespace DesignLibrary
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class GoodCustomAttribute : Attribute
    {
        string mandatory;
        string optional;

        public GoodCustomAttribute(string mandatoryData)
        {
            mandatory = mandatoryData;
        }

        public string MandatoryData
        {
            get { return mandatory; }
        }

        public string OptionalData
        {
            get { return optional; }
            set { optional = value; }
        }
    }
}

namespace DesignLibrary
{
    public class MyClass
    {
        string myProperty = "Hello";
        string myOtherProperty = "World";

        //<Snippet1>
        [GoodCustomAttribute("ThisIsSomeMandatoryData", OptionalData = "ThisIsSomeOptionalData")]
        public string MyProperty
        {
            get { return myProperty; }
            set { myProperty = value; }
        }

        [GoodCustomAttribute("ThisIsSomeMoreMandatoryData")]
        public string MyOtherProperty
        {
            get { return myOtherProperty; }
            set { myOtherProperty = value; }
        }
        //</Snippet1>
    }
}