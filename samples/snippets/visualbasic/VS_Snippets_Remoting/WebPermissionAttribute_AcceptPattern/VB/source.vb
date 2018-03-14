 ' System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;
'This program demonstrates the 'Connect' and 'Accept' properties of the class 'WebPermissionAttribute'.
'The program uses declarative security for calling the code in 'Connect' method.
'By using the 'Accept' and 'Connect' properties of 'WebPermissionAttribute' accept and connect access 
'has been given to the uri www.contoso.com.



Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.IO
Imports System.Text.RegularExpressions

 
Public Class WebPermissionAttribute_AcceptConnect
   
   '<Snippet1>	
 <WebPermission(SecurityAction.Deny, AcceptPattern := "http://www\.contoso\.com/Private/.*")> _
   Public Shared Sub       CheckAcceptPermission(uriToCheck As String)
      Dim re As New Regex("http://www\.contoso\.com/Public/.*")
      Dim con As New WebPermission(NetworkAccess.Connect, re)
      con.Assert()
      Dim permissionToCheck As New WebPermission()
      permissionToCheck.AddPermission(NetworkAccess.Accept, uriToCheck)
      permissionToCheck.Demand()
   End Sub 'CheckAcceptPermission
   
   
   Public Shared Sub demoDenySite()
      'Passes a security check.
      CheckAcceptPermission("http://www.contoso.com/Public/page.htm")
      Console.WriteLine("Public page has passed Accept permission check")
      
      Try
         'Throws a SecurityException.
         CheckAcceptPermission("http://www.contoso.com/Private/page.htm")
         Console.WriteLine("This line will not be printed")
      Catch e As SecurityException
         Console.WriteLine(("Expected exception" + e.Message))
      End Try
   End Sub 'demoDenySite
    
   
   '</Snippet1>
   Shared Sub Main()
      demoDenySite()
   End Sub 'Main 
End Class 'WebPermissionAttribute_AcceptConnect
