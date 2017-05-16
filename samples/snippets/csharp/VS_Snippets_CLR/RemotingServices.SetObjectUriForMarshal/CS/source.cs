// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Security.Permissions;

public class SetObjectUriForMarshalTest  {

    class TestClass : MarshalByRefObject {
    }

    [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.RemotingConfiguration)] 
    public static void Main()  {

        TestClass obj = new TestClass();    

        RemotingServices.SetObjectUriForMarshal(obj, "testUri");
        RemotingServices.Marshal(obj);

        Console.WriteLine(RemotingServices.GetObjectUri(obj));
    }
}
// </Snippet1>