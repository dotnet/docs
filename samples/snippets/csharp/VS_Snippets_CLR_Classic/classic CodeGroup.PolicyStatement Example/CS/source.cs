using System;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;

public class Sample {
    void Method() {
        FirstMatchCodeGroup codeGroup = new FirstMatchCodeGroup(null, new PolicyStatement(new PermissionSet(PermissionState.None)));
        // <Snippet1>
        codeGroup.PolicyStatement = new PolicyStatement(new NamedPermissionSet("MyPermissionSet"));
        // </Snippet1>
    }
}
