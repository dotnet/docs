//<snippet3>
using System;
using System.Security;
using System.Security.Permissions;

public class RemoteObject : MarshalByRefObject
{
    public RemoteObject()
    {
        Console.WriteLine("You have called the constructor.");
    }

    public void Hello()
    {
        Console.WriteLine("You have called Hello().");
    }
}
//</snippet3>