 ' System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Connect;

 ' Demonstrate how to use the WebPermissionAttribute  ConnectPattern property.



Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.IO
Imports System.Text.RegularExpressions
 
Public Class WebPermissionAttribute_Connect
   
   '<Snippet1>	

   ' Set the WebPermissionAttribute  ConnectPattern property.
 <WebPermission(SecurityAction.Deny, ConnectPattern := "http://www\.contoso\.com/Private/.*")> _
     Public Shared Sub CheckConnectPermission(uriToCheck As String)
      Dim re As New Regex("http://www\.contoso\.com/Public/.*")
      Dim con As New WebPermission(NetworkAccess.Connect, re)
      con.Assert()
      Dim permissionToCheck As New WebPermission()
      permissionToCheck.AddPermission(NetworkAccess.Connect, uriToCheck)
      permissionToCheck.Demand()
   End Sub 'CheckConnectPermission
   
   
   Public Shared Sub demoDenySite()
      'Pass the security check.
      CheckConnectPermission("http://www.contoso.com/Public/page.htm")
      Console.WriteLine("Public page has passed Connect permission check")
      
      Try
         'Throw a SecurityException.
         CheckConnectPermission("http://www.contoso.com/Private/page.htm")
         Console.WriteLine("This line will not be printed")
      Catch e As SecurityException
         Console.WriteLine(("Expected exception" + e.Message))
      End Try
   End Sub 'demoDenySite
    
   
   '</Snippet1>
   Shared Sub Main()
      demoDenySite()
   End Sub 'Main 
End Class 'WebPermissionAttribute_ConnectConnect
