 ' System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;


Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.IO

Public Class WebPermissionAttribute_AcceptConnect

' <Snippet1>
   
   ' Set the declarative security for the URI.
   <WebPermission(SecurityAction.Deny, Connect := "http://www.contoso.com/")> _
   Public Sub Connect()
      ' Throw an exception.	 
      Try
         Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.ToString()))
      End Try
   End Sub 'Connect
 
' </Snippet1>
   
   
   
   
   Shared Sub Main()
      
      Try
         
         Dim myWebAttrib As New WebPermissionAttribute_AcceptConnect()
         myWebAttrib.Connect()
      
      Catch e As SecurityException
         Console.WriteLine(("Security Exception raised : " + e.Message))
      Catch e As Exception
         Console.WriteLine(("Exception raised : " + e.Message))
      End Try
   End Sub 'Main
   
End Class 'WebPermissionAttribute_AcceptConnect
