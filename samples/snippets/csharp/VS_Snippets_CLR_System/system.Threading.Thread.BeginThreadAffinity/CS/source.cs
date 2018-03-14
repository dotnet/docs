//<Snippet1>
using System.Threading;
using System.Security.Permissions;

[SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlThread)]
public class MyUtility
{
    [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlThread)]
    public void PerformTask()
    {
        // Code that does not have thread affinity goes here.
        //
        Thread.BeginThreadAffinity();
        //
        // Code that has thread affinity goes here.
        //
        Thread.EndThreadAffinity();
        //
        // More code that does not have thread affinity.
    }
}
//</Snippet1>

public class Dummy
{
    public static void Main() {}
}