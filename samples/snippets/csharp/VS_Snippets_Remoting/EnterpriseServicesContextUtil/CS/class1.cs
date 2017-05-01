// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[Synchronization(SynchronizationOption.Required)]
public class ContextUtil_ActivityId : ServicedComponent
{
    public void Example()
    {
        // Display the ActivityID associated with the current COM+ context.
        Console.WriteLine("Activity ID: {0}", ContextUtil.ActivityId);
    }
}
// </snippet1>

// <snippet2>
[Synchronization(SynchronizationOption.Required)]
public class ContextUtil_ApplicationInstanceId : ServicedComponent
{
    public void Example()
    {
        // Display the ApplicationInstanceId associated with the current COM+
        // context.
        Console.WriteLine("Application Instance ID: {0}",
            ContextUtil.ApplicationInstanceId);
    }
}
// </snippet2>

// <snippet3>
[Transaction(TransactionOption.Required)]
public class ContextUtil_DisableCommit : ServicedComponent
{
    public void Example()
    {
        // Set both the consistent bit and the done bit to false for the
        // current COM+ context.
        ContextUtil.DisableCommit();
    }
}
// </snippet3>

// <snippet4>
[Transaction(TransactionOption.Required)]
public class ContextUtil_EnableCommit : ServicedComponent
{
    public void Example()
    {
        // Set the consistent bit to true and the done bit to false for the
        // current COM+ context.
        ContextUtil.EnableCommit();
    }
}
// </snippet4>

// <snippet5>
[Transaction(TransactionOption.Required)]
public class ContextUtil_IsInTransaction : ServicedComponent
{
    public void Example()
    {
        // Display whether the current COM+ context is enlisted in a
        // transaction.
        Console.WriteLine("Current context enlisted in transaction: {0}",
            ContextUtil.IsInTransaction);
    }
}
// </snippet5>

// <snippet6>
[SecurityRole("Role1")]
public class ContextUtil_IsSecurityEnabled : ServicedComponent
{
    public void Example()
    {
        // Display whether role-based security is active for the current COM+
        // context.
        Console.WriteLine("Role-based security active in current context: {0}",
            ContextUtil.IsSecurityEnabled);
    }
}
// </snippet6>

// <snippet7>
[Transaction(TransactionOption.Required)]
public class ContextUtil_TransactionId : ServicedComponent
{
    public void Example()
    {
        // Display the ID of the transaction in which the current COM+ context
        // is enlisted.
        Console.WriteLine("Transaction ID: {0}", ContextUtil.TransactionId);
    }
}
// </snippet7>

// </snippet0>
