// <snippet10>
using System;
using System.Runtime.Remoting;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;

public class Remotable : MarshalByRefObject
{

    // A method to call remotely.
    [SecurityPermission(SecurityAction.LinkDemand)]
    public string GetMessage()
    {
        // Create a message.
        StringBuilder message = new StringBuilder("call");
        
        // Identity the calling principal.
        IIdentity remoteIdentity =
            System.Runtime.Remoting.Messaging.CallContext.GetData("__remotePrincipal") as IIdentity;
        if (remoteIdentity == null)
        {
            message.Append(" by an unknown caller");
        }
        else
        {
            message.AppendFormat(" by {0}", remoteIdentity.Name); 
        }

        // Identify the executing principal.
        IIdentity localIdentity = (IIdentity) WindowsIdentity.GetCurrent();
        message.AppendFormat(" was executed as {0}.", localIdentity.Name);

        // Return the message.
        return(message.ToString());
    }
}
// </snippet10>
