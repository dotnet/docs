 ' System.Net.WebPermission.WebPermission(PermissionState);System.Net.WebPermission.Copy;

' This program demonstrates the  WebPermission(PermissionState) constructor and 
' Copy method of the WebPermission class .
' It creates a WebPermission instance with Permissionstate set to None and 
' sets the access right to one pair of URLs. 
' Then it uses the Copy method  to create another instance of WebPermission class 
' Finally, the attributes , values and childrens  of both the XML encoded instances 
' are displayed.
'


Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic
 _

Class CopyWebPermission
   
   
   Shared Sub Main()
      Try
         Dim myCopyWebPermission As New CopyWebPermission()
         myCopyWebPermission.CreateCopy()
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message))
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.Message))
      End Try
   End Sub 'Main
   
   
   Public Sub CreateCopy()
      
' <Snippet1>
      ' Create a WebPermission instance.  
      Dim myWebPermission1 As New WebPermission(PermissionState.None)
      
      ' Allow access to the first set of URL's.
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.microsoft.com/default.htm")
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.msn.com")
      
      ' Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission1.Demand()
      
' </Snippet1>

' <Snippet2>
      ' Create another WebPermission instance that is the copy of the above WebPermission instance.
      Dim myWebPermission2 As WebPermission = CType(myWebPermission1.Copy(), WebPermission)
      
      ' Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission2.Demand()
      
' </Snippet2>
      Console.WriteLine("The Attributes and Values are :" + ControlChars.Cr)
      ' Display the Attributes,Values and Children of the XML encoded instance.
      PrintKeysAndValues(myWebPermission1.ToXml().Attributes, myWebPermission1.ToXml().Children)
      
      Console.WriteLine(ControlChars.Cr + "Copied Instance Attributes and Values are :" + ControlChars.Cr)
      ' Display the Attributes,Values and Children of the XML encoded copied instance.
      PrintKeysAndValues(myWebPermission2.ToXml().Attributes, myWebPermission2.ToXml().Children)
   End Sub 'CreateCopy
   
   
   Private Sub PrintKeysAndValues(myHashtable As Hashtable, myList As IEnumerable)
      
      ' Gets the enumerator that can iterate through Hashtable.
      Dim myEnumerator As IDictionaryEnumerator = myHashtable.GetEnumerator()
      Console.WriteLine(ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
      While myEnumerator.MoveNext()
         Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
      End While
      Console.WriteLine()
      
      Dim myEnumerator1 As IEnumerator = myList.GetEnumerator()
      Console.WriteLine("The Children are : ")
      While myEnumerator1.MoveNext()
         Console.Write(ControlChars.Tab + "{0}", myEnumerator1.Current)
      End While
   End Sub 'PrintKeysAndValues
End Class 'CopyWebPermission