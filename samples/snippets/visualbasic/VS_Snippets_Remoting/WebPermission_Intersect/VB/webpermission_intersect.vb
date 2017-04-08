' System.Net.WebPermission.WebPermission();
' System.Net.WebPermission.AddPermission(NetworkAccess,stringuri);
' System.Net.WebPermission.Intersect;
'
' This program shows the use of the WebPermission() constructor, the AddPermission,  
' and Intersect' methods of the WebPermission' class.
' It first creates two WebPermission objects with no arguments, with each of them 
' setting the access rights to one pair of URLs.
' Then it displays the attributes , values and childrens of the XML encoded instances.
' Finally, it creates a third WebPermission object using the logical intersection of the 
' first two objects. It does so by using the Intersect method.
' It then displays the attributes , values and childrens of the related XML encoded 
' instances.
'
 

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic
 _

Class WebPermissionIntersect
   
   Shared Sub Main(Args() As [String])
      Try
         Dim myWebPermissionIntersect As New WebPermissionIntersect()
         myWebPermissionIntersect.CreateIntersect()
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message))
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.Message))
      End Try
   End Sub 'Main
   
   
   Public Sub CreateIntersect()
      ' <Snippet1>
      ' Create two WebPermission instances.
      Dim myWebPermission1 As New WebPermission()
      Dim myWebPermission2 As New WebPermission()
      
      ' <Snippet2>
      ' Allow access to the first set of resources.
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.contoso.com/default.htm")
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.adventure-works.com/default.htm")
      
      ' Check whether if the callers higher in the call stack have been granted 
      ' access permissions.
      myWebPermission1.Demand()
      
      ' </Snippet2>
      ' Allow access right to the second set of resources.
      myWebPermission2.AddPermission(NetworkAccess.Connect, "http://www.alpineskihouse.com/default.htm")
      myWebPermission2.AddPermission(NetworkAccess.Connect, "http://www.baldwinmuseumofscience.com/default.htm")
      myWebPermission2.Demand()
      
      ' </Snippet1>
      ' Display the attributes , values and childrens of the XML encoded instances.
      Console.WriteLine("Attributes and values of  first 'WebPermission' instance are :")
      PrintKeysAndValues(myWebPermission1.ToXml().Attributes, myWebPermission2.ToXml().Children)
      
      Console.WriteLine(ControlChars.Cr + "Attributes and values of second 'WebPermission' instance are : ")
      PrintKeysAndValues(myWebPermission2.ToXml().Attributes, myWebPermission2.ToXml().Children)
      
      ' <Snippet3>
      ' Create a third WebPermission instance via the logical intersection of the previous
      ' two WebPermission instances.
      Dim myWebPermission3 As WebPermission = CType(myWebPermission1.Intersect(myWebPermission2), WebPermission)
      
      Console.WriteLine(ControlChars.Cr + "Attributes and Values of  the WebPermission instance after the Intersect are:" + ControlChars.Cr)
      Console.WriteLine(myWebPermission3.ToXml().ToString())
   End Sub 'CreateIntersect
    
   ' </Snippet3>
   
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
End Class 'WebPermissionIntersect