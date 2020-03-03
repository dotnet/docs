'<Snippet1>
' To run this sample you must create a strong-name key named snkey.snk 
' using the Strong Name tool (sn.exe).  Both the library assembly and the 
' application assembly that calls it must be signed with that key.  
' To run successfully, the application assembly must be in the global 
' assembly cache.
' This console application can be created using the following code.

'Imports System.Security
'Imports System.Security.Policy
'Imports System.Security.Principal
'Imports System.Security.Permissions
'Imports ClassLibraryVB

'Class [MyClass]
'
'    Overloads Shared Sub Main(ByVal args() As String)
'        Try
'           Dim myLib As New Class1
'            myLib.DoNothing()
'
'            Console.WriteLine("Exiting the sample.")
'        Catch e As Exception
'            Console.WriteLine(e.Message)
'        End Try
'    End Sub
'End Class
Imports System.Security.Permissions

'<Snippet2>
' Demand that the calling program be in the global assembly cache.
<GacIdentityPermissionAttribute(SecurityAction.Demand)> _
Public Class Class1
'</Snippet2>
    Public Sub DoNothing()
        Console.WriteLine("Exiting the library program.")
    End Sub
End Class

'</Snippet1>
