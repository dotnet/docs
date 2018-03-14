// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

public class AutoCompleteAttribute_Example : ServicedComponent
{
    // <snippet1>
    [AutoComplete]
    public void AutoCompleteAttribute_Ctor()
    {
    }
    // </snippet1>

    // <snippet2>
    [AutoComplete(true)]
    public void AutoCompleteAttribute_Ctor_Bool()
    {
    }
    // </snippet2>

    // <snippet3>
    [AutoComplete(false)]
    public void AutoCompleteAttribute_Value()
    {
        // Get information on the member.
        System.Reflection.MemberInfo[] memberinfo = 
            this.GetType().GetMember(
            "AutoCompleteAttribute_Value");

        // Get the AutoCompleteAttribute applied to the member.
        AutoCompleteAttribute attribute =
            (AutoCompleteAttribute)System.Attribute.GetCustomAttribute(
            memberinfo[0],
            typeof(AutoCompleteAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("AutoCompleteAttribute.Value: {0}", attribute.Value);
    }
    // </snippet3>
}

// </snippet0>

/*
// Test client.
public class TestClient
{
    public static void Main()
    {
        // Create a new instance of the class.
        AutoCompleteAttribute_Example example =
            new AutoCompleteAttribute_Example();

        // Demonstrate the AutoCompleteAttribute properties.
        example.AutoCompleteAttribute_Value();
    }
}
*/