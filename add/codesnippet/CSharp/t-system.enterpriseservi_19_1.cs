using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

public class AutoCompleteAttribute_Example : ServicedComponent
{
    [AutoComplete]
    public void AutoCompleteAttribute_Ctor()
    {
    }

    [AutoComplete(true)]
    public void AutoCompleteAttribute_Ctor_Bool()
    {
    }

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
}
