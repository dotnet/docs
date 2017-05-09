' System.Net.WebPermission.ConnectList;System.Net.WebPermission.AcceptList;
' This program demonstrates the the use of the ConnectList and AcceptList WebPermission
' class prerties.
' It first creates a WebPermission object with Permissionstate set to None and then 
' sets the Connect and Accept access right to some predefined URLs. 
' The using the AcceptList and ConnectList properties it displays the URLs that have 
' the Accept and Connect permission set, respectively.


Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic

 _

Class WebPermission_AcceptConnectList
   
   Shared Sub Main()
      Try
         Dim myWebPermission_AcceptConnectList As New WebPermission_AcceptConnectList()
         myWebPermission_AcceptConnectList.DisplayAcceptConnect()
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message))
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.Message))
      End Try
   End Sub 'Main
   
   
   Public Sub DisplayAcceptConnect()
      ' Create a 'WebPermission' object with permission state set to 'None'.
      Dim myWebPermission1 As New WebPermission(PermissionState.None)
      
      ' Allow 'Connect' access right to first set of URL's.
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.contoso.com")
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.adventure-works.com")
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.alpineskihouse.com")
      
      ' Allow 'Accept' access right to second set of URL's.
      myWebPermission1.AddPermission(NetworkAccess.Accept, "http://www.contoso.com")
      myWebPermission1.AddPermission(NetworkAccess.Accept, "http://www.adventure-works.com")
      myWebPermission1.AddPermission(NetworkAccess.Accept, "http://www.alpineskihouse.com")
      
      ' Check whether all callers higher in the call stack have been granted the permission or not.
      myWebPermission1.Demand()
      
      Console.WriteLine("The Attributes,Values and Children of the 'WebPermission' object are :" + ControlChars.Cr)
      ' Display the Attributes,Values and Children of the XML encoded instance.
      PrintKeysAndValues(myWebPermission1.ToXml().Attributes, myWebPermission1.ToXml().Children)
      
' <Snippet1>
      ' Gets all URIs with Connect permission.
      Dim myEnum As IEnumerator = myWebPermission1.ConnectList
      Console.WriteLine(ControlChars.Cr + "The URIs with Connect permission are :" + ControlChars.Cr)
      While myEnum.MoveNext()
         Console.WriteLine((ControlChars.Tab + "The URI is : " + myEnum.Current))
      End While 
' </Snippet1>
      
' <Snippet2>
      ' Get all URI's with Accept permission.  
      Dim myEnum1 As IEnumerator = myWebPermission1.AcceptList
      Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "The URIs with Accept permission are :" + ControlChars.Cr)
      While myEnum1.MoveNext()
         Console.WriteLine((ControlChars.Tab + "The URI is : " + myEnum1.Current))
      End While 
 ' </Snippet2>
 
   End Sub 'DisplayAcceptConnect

   
   Private Sub PrintKeysAndValues(myHashtable As Hashtable, myList As IEnumerable)
      ' Get the enumerator that can iterate through Hashtabel.
      Dim myEnumerator As IDictionaryEnumerator = myHashtable.GetEnumerator()
      Console.WriteLine(ControlChars.Tab + "-Attribute-" + ControlChars.Tab + "-Value-")
      While myEnumerator.MoveNext()
         Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
      End While
      Console.WriteLine()
      
      Dim myEnumerator1 As IEnumerator = myList.GetEnumerator()
      Console.WriteLine("The Children are : " + ControlChars.Cr)
      While myEnumerator1.MoveNext()
         Console.Write(myEnumerator1.Current)
      End While
   End Sub 'PrintKeysAndValues

End Class 'WebPermission_AcceptConnectList