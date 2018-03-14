using System;
using System.Security.Permissions;

// <Snippet1>
 [assembly:FileDialogPermissionAttribute(SecurityAction.RequestMinimum, Unrestricted=true)]
 //In C#, you must specify that you are using the assembly scope when making a request.
// </Snippet1>

namespace Snippet2 {
// <Snippet2>
 [FileDialogPermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
// </Snippet2>
    public class SampleClass {}
}

namespace Snippet3 {
// <Snippet3>
// [FileDialogPermissionAttribute(SecurityAction.Assert, Unrestricted=true)]
// </Snippet3>
    public class SampleClass {}
}
