using System;

// Remote object.
public class RemoteObject : MarshalByRefObject
{
    private int callCount = 0;

    public int GetCount()
    {
        Console.WriteLine("GetCount has been called.");
        callCount++;
        return(callCount);
    }
}
