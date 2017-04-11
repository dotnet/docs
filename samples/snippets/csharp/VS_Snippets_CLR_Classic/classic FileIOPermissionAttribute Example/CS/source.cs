using System;
using System.Security.Permissions;

namespace Snippet1 {
// <Snippet1>
[FileIOPermissionAttribute(SecurityAction.PermitOnly, ViewAndModify = "C:\\example\\sample.txt")]
// </Snippet1>
    public class SampleClass {}
}

namespace Snippet2 {
// <Snippet2>
 [FileIOPermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
// </Snippet2>
    public class SampleClass {}
}

namespace Snippet3 {
// <Snippet3>
 //[FileIOPermissionAttribute(SecurityAction.Assert, Unrestricted=true)]
// </Snippet3>
    public class SampleClass {}
}
