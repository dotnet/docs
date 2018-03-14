' System.Net.WebPermission.WebPermission(NetworkAccess, uriString);System.Net.WebPermission.Union;
'*
' This program shows the use of the WebPermission(NetworkAccess access,string uriString) 
' constructor and Union method of the WebPermission' class.
' It creates two instance of the WebPermission class with the  specified access 
' rights to the predefined URIs.
' It displays the attributes , values and childrens of those XML encoded instances. 
' Then, using the Union method, it creates a third WebPermission instance 
' via a logical union of the first two.
' Finally, it displays the attributes , values and childrens of those XML encoded 
' instances.

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic
 _

Class WebPermissionUnion
   
   
   Shared Sub Main()
      Try
         Dim myWebPermissionUnion As New WebPermissionUnion()
         myWebPermissionUnion.CreateUnion()
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message))
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.Message))
      End Try
   End Sub 'Main
   
   
   Public Sub CreateUnion()
      ' <Snippet1>
      ' Create a WebPermission.instance.
      Dim myWebPermission1 As New WebPermission(NetworkAccess.Connect, "http://www.contoso.com/default.htm")
      myWebPermission1.Demand()
      
      ' </Snippet1>
      ' Create another WebPermission instance.
      Dim myWebPermission2 As New WebPermission(NetworkAccess.Connect, "http://www.adventure-works.com")
      myWebPermission2.Demand()
      
      ' Print the attributes, values and childrens of the XML encoded instances.
      Console.WriteLine("Attributes and values of the first WebPermission are : ")
      PrintKeysAndValues(myWebPermission1.ToXml().Attributes, myWebPermission1.ToXml().Children)
      
      Console.WriteLine(ControlChars.Cr + "Attributes and values of the second WebPermission are : ")
      PrintKeysAndValues(myWebPermission2.ToXml().Attributes, myWebPermission2.ToXml().Children)
      
      ' <Snippet2>
      ' Create another WebPermission that is the Union of previous two WebPermission 
      ' instances.
      Dim myWebPermission3 As WebPermission = CType(myWebPermission1.Union(myWebPermission2), WebPermission)
      Console.WriteLine(ControlChars.Cr + "Attributes and values of the WebPermission after the Union are : ")
      ' Display the attributes,values and children.
      Console.WriteLine(myWebPermission3.ToXml().ToString())
   End Sub 'CreateUnion
    
   ' </Snippet2>
   
   Private Sub PrintKeysAndValues(myHashtable As Hashtable, myList As IEnumerable)
      ' Get the enumerator that can iterate through Hashtable.
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
End Class 'WebPermissionUnion