// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[ObjectPooling(true)]
public class ObjectPoolingAttribute_Ctor_Bool : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[ObjectPooling(true, 1, 10)]
public class ObjectPoolingAttribute_Ctor_Bool_Int_Int : ServicedComponent
{
}
// </snippet2>

// <snippet3>
[ObjectPooling(1, 10)]
public class ObjectPoolingAttribute_Ctor_Int_Int : ServicedComponent
{
}
// </snippet3>

// <snippet4>
[ObjectPooling(false)]
public class ObjectPoolingAttribute_Enabled : ServicedComponent
{
    public void EnabledExample()
    {
        // Get the ObjectPoolingAttribute applied to the class.
        ObjectPoolingAttribute attribute =
            (ObjectPoolingAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(ObjectPoolingAttribute),
            false);

        // Display the current value of the attribute's Enabled property.
        Console.WriteLine("ObjectPoolingAttribute.Enabled: {0}",
            attribute.Enabled);

        // Set the Enabled property value of the attribute.
        attribute.Enabled = true;

        // Display the new value of the attribute's Enabled property.
        Console.WriteLine("ObjectPoolingAttribute.Enabled: {0}",
            attribute.Enabled);
    }
}
// </snippet4>

// </snippet0>

/*
// Test client.
public class ObjectPoolingAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        ObjectPoolingAttribute_Enabled enabledExample =
            new ObjectPoolingAttribute_Enabled();

        // Demonstrate the ObjectPoolingAttribute properties.
        enabledExample.EnabledExample();
    }
}
*/