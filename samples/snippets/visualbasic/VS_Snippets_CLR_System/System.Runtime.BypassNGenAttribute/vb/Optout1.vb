' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Imports System.Runtime

Public Class ExampleClass
   <BypassNGen>
   Public Sub ToJITCompile()
   End Sub
End Class
' </Snippet2>


' <Snippet1>
Namespace System.Runtime
   Public Class BypassNGenAttribute : Inherits Attribute 
   End Class   
End Namespace
' </Snippet1>
