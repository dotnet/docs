// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[Transaction]
public class TransactionAttribute_Ctor : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[Transaction(TransactionOption.Supported)]
public class TransactionAttribute_Ctor_TransactionOption : ServicedComponent
{
}

[Transaction(TransactionOption.Supported,
     Isolation=TransactionIsolationLevel.Serializable)]
public class TransactionAttribute_Ctor_TransactionOption_Isolation :
    ServicedComponent
{
}

[Transaction(TransactionOption.Supported,
     Isolation=TransactionIsolationLevel.Serializable,
     Timeout=30)]
public class TransactionAttribute_Ctor_TransactionOption_Isolation_Timeout :
     ServicedComponent
{
}
// </snippet2>

// <snippet3>
[Transaction(Isolation=TransactionIsolationLevel.Serializable)]
public class TransactionAttribute_Isolation : ServicedComponent
{
    public void IsolationExample()
    {
        // Get the TransactionAttribute applied to the class.
        TransactionAttribute attribute =
            (TransactionAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(TransactionAttribute),
            false);

        // Display the current value of the attribute's Isolation property.
        Console.WriteLine("TransactionAttribute.Isolation: {0}",
            attribute.Isolation);

        // Set the Isolation property value of the attribute.
        attribute.Isolation = TransactionIsolationLevel.RepeatableRead;

        // Display the new value of the attribute's Isolation property.
        Console.WriteLine("TransactionAttribute.Isolation: {0}",
            attribute.Isolation);
    }
}
// </snippet3>

// <snippet4>
[Transaction(Timeout=30)]
public class TransactionAttribute_Timeout : ServicedComponent
{
    public void TimeoutExample()
    {
        // Get the TransactionAttribute applied to the class.
        TransactionAttribute attribute =
            (TransactionAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(TransactionAttribute),
            false);

        // Display the current value of the attribute's Timeout property.
        Console.WriteLine("TransactionAttribute.Timeout: {0}",
            attribute.Timeout);

        // Set the Timeout property value of the attribute to sixty
        // seconds.
        attribute.Timeout = 60;

        // Display the new value of the attribute's Timeout property.
        Console.WriteLine("TransactionAttribute.Timeout: {0}",
            attribute.Timeout);
    }
}
// </snippet4>

// <snippet5>
[Transaction(TransactionOption.RequiresNew)]
public class TransactionAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the TransactionAttribute applied to the class.
        TransactionAttribute attribute =
            (TransactionAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(TransactionAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("TransactionAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet5>

// </snippet0>

/*
// Test client.
public class TransactionAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        TransactionAttribute_Isolation isolationExample =
            new TransactionAttribute_Isolation();
        TransactionAttribute_Timeout timeoutExample =
            new TransactionAttribute_Timeout();
        TransactionAttribute_Value valueExample =
            new TransactionAttribute_Value();

        // Demonstrate the TransactionAttribute properties.
        isolationExample.IsolationExample();
        timeoutExample.TimeoutExample();
        valueExample.ValueExample();
    }
}
*/