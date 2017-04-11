Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Text.RegularExpressions
Imports System.Collections
Imports Microsoft.VisualBasic


Class MyWebPermissionExample
   
   
   Public Shared Sub MySample()
      
'<Snippet1>
    ' Create a Regex that accepts all the URLs contianing the host fragment www.contoso.com.
    Dim myRegex As New Regex("http://www\.contoso\.com/.*")
      
    ' Create a WebPermission that gives permission to all the hosts containing same host fragment.
    Dim myWebPermission As New WebPermission(NetworkAccess.Connect, myRegex)
    ' Add connect privileges for a www.adventure-works.com.
    myWebPermission.AddPermission(NetworkAccess.Connect, "http://www.adventure-works.com")
    ' Add accept privileges for www.alpineskihouse.com.
    myWebPermission.AddPermission(NetworkAccess.Accept, "http://www.alpineskihouse.com/")
    ' Check whether all callers higher in the call stack have been granted the permission.
    myWebPermission.Demand()
      
    ' Get all the URIs with Connect permission.
    Dim myConnectEnum As IEnumerator = myWebPermission.ConnectList
    Console.WriteLine(ControlChars.NewLine + "The 'URIs' with 'Connect' permission are :" + ControlChars.NewLine)
    While myConnectEnum.MoveNext()
      Console.WriteLine((ControlChars.Tab + myConnectEnum.Current.ToString()))
    End While 
    
    ' Get all the URIs with Accept permission.	  
    Dim myAcceptEnum As IEnumerator = myWebPermission.AcceptList
    Console.WriteLine(ControlChars.NewLine + ControlChars.NewLine + "The 'URIs' with 'Accept' permission is :" + ControlChars.NewLine)
  
    While myAcceptEnum.MoveNext()
      Console.WriteLine((ControlChars.Tab + myAcceptEnum.Current))
    End While
'</Snippet1>
 
  End Sub 'MySample
    
  Public Shared Sub Main()
    MySample()
  End Sub 'Main

End Class 'WebPermission_regexConstructor 