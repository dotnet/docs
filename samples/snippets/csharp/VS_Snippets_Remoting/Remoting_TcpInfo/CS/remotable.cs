// <snippet10>
using System;
using System.Runtime.Remoting;

public class Remotable : MarshalByRefObject
{

    private int callCount = 0;

    public int GetCount()
    {
        callCount++;
        return(callCount);
    }

}
// </snippet10>
