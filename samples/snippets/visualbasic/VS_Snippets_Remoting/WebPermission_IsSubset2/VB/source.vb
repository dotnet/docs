 ' System.Net.WebPermission.AddPermission(NetworkAccess, regex);System.Net.WebPermission.IsSubsetOf;
'
' This program shows the use of the AddPermission(NetworkAccess, regex) and 
' IsSubset methods of the WebPermission class.
' It creates two WebPermission instances with the Connect access rights for the specified
' URIs. The second URI being a subset of the first one.
' Then the IsSubsetOf method is called to verify that the second URI is indeed a subset
' of the firts one. The result of the call to the IsSubsetOf is then displayed.
'


Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports System.Text.RegularExpressions

 _

Public Class Sample
   
   
   Public Shared Sub myIsSubsetExample()
'<Snippet1>
      ' Create the target permission.
      Dim targetPermission As New WebPermission()
      targetPermission.AddPermission(NetworkAccess.Connect, New Regex("www\.contoso\.com/Public/.*"))
      
      ' Create the permission for a URI matching target.
      Dim connectPermission As New WebPermission()
      connectPermission.AddPermission(NetworkAccess.Connect, "www.contoso.com/Public/default.htm")
      
      'The following statement prints true.
      Console.WriteLine(("Is the second URI a subset of the first one?: " & connectPermission.IsSubsetOf(targetPermission)))
   End Sub 'myIsSubsetExample

'</Snippet1>
 
   Public Shared Sub Main()
      ' Verify that the second URI is a subset of the first one.
      myIsSubsetExample()
   End Sub 'Main
   
End Class 'Sample