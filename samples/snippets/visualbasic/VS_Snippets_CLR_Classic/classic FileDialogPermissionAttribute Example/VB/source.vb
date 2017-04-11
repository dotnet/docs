Imports System
Imports System.Security.Permissions

' <Snippet1>
 <Assembly: FileDialogPermissionAttribute(SecurityAction.RequestMinimum, _
 Unrestricted := True)>
'In Visual Basic, you must specify that you are using the assembly scope when making a request.
' </Snippet1>

Namespace Snippet2
    
' <Snippet2>
<FileDialogPermissionAttribute(SecurityAction.Demand, _
 Unrestricted := True)> Public Class SampleClass
' </Snippet2>
     ' Insert class members here
 End Class


End Namespace

Namespace Snippet3
    
' <Snippet3>
'<FileDialogPermissionAttribute(SecurityAction.Assert, _
' Unrestricted := True)> 
Public Class SampleClass
' </Snippet3>
     ' Insert class members here
 End Class


End Namespace
