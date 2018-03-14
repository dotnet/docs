' System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;

' Demonstrate how to use the WebPermissionAttribute to specify an allowable ConnectPattern.

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.IO
Imports Microsoft.VisualBasic



Public Class WebPermissionAttribute_AcceptConnect

' <Snippet1>
' <Snippet2>      

    ' Deny access to a specific resource by setting the ConnectPattern property. 
    <WebPermission(SecurityAction.Deny, ConnectPattern := "http://www\.contoso\.com/.*")> Public Sub Connect()
    
    ' Create a Connection.	 
    Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
    Console.WriteLine("This line should never be printed")
       
' </Snippet2>
' </Snippet1>

    End Sub 
      
    
    Shared Sub Main()
        
        Try
            
            Dim myWebAttrib As New WebPermissionAttribute_AcceptConnect()
            myWebAttrib.Connect()
        
        Catch e As SecurityException
            Console.WriteLine(("Security Exception raised : " + e.Message))
        Catch e As Exception
            Console.WriteLine(("Exception raised : " + e.Message))
        End Try
    End Sub ' Main
End Class ' WebPermissionAttribute_AcceptConnect
