using System;

namespace ca1019
{
    //<snippet1>
    // Violates rule: DefineAccessorsForAttributeArguments.
    [AttributeUsage(AttributeTargets.All)]
    public sealed class BadCustomAttribute : Attribute
    {
        string _data;

        // Missing the property that corresponds to 
        // the someStringData constructor parameter.

        public BadCustomAttribute(string someStringData)
        {
            _data = someStringData;
        }
    }

    // Satisfies rule: Attributes should have accessors for all arguments.
    [AttributeUsage(AttributeTargets.All)]
    public sealed class GoodCustomAttribute : Attribute
    {
        public GoodCustomAttribute(string someStringData)
        {
            SomeStringData = someStringData;
        }

        //The constructor parameter and property
        //name are the same except for case.

        public string SomeStringData { get; }
    }
    //</snippet1>
}

namespace ca1019_2
{
    //<snippet2>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class GoodCustomAttribute : Attribute
    {
        public GoodCustomAttribute(string mandatoryData)
        {
            MandatoryData = mandatoryData;
        }

        public string MandatoryData { get; }

        public string OptionalData { get; set; }
    }
    //</snippet2>

    class Class1
    {
        //<snippet3>
        [GoodCustomAttribute("ThisIsSomeMandatoryData", OptionalData = "ThisIsSomeOptionalData")]
        public string MyProperty { get; set; }

        [GoodCustomAttribute("ThisIsSomeMoreMandatoryData")]
        public string MyOtherProperty { get; set; }
        //</snippet3>
    }
}
