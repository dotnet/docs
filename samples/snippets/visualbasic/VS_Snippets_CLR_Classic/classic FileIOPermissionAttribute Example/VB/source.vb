Imports System
Imports System.Security.Permissions

Namespace Snippet1

' <Snippet1>
<FileIOPermissionAttribute(SecurityAction.PermitOnly, _
ViewAndModify:="C:\example\sample.txt")> Public Class SampleClass
' </Snippet1>
 End Class
End Namespace

Namespace Snippet2

' <Snippet2>
<FileIOPermissionAttribute(SecurityAction.Demand, _
 Unrestricted := True)> Public Class SampleClass
' </Snippet2>
     ' Insert class members here
 End Class


End Namespace

Namespace Snippet3
    
' <Snippet3>
'<FileIOPermissionAttribute(SecurityAction.Assert, _
 'Unrestricted := True)>
 Public Class SampleClass
' </Snippet3>
     ' Insert class members here
 End Class


End Namespace
