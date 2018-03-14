 ' System.Net.WebPermission.AddPermission(NetworkAccess, regex);
' System.Net.WebPermission.IsSubsetOf;
'*
' This program shows how to use the  AddPermission(NetworkAccess, regex) and 
' IsSubset methods of WebPermission class.
' It creates two WebPermission instances with the Connect access rights for the 
' specified URIs.
' For he first WebPermission instance, a Connect access right is given to the 
' URLs with the host fragment www.microsoft.com. This is done by using
' the AddPermission(NetworkAccess, regex) method. 
' Then, a third WebPermission instance is created with the Connect access right to 
' the URLs of the first and second WebPermission instances. 
' Finally, the attributes, values and children of that instance are displayed.
'


Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic
 _

Class WebPermissionIsSubset
   
   
   Shared Sub Main(Args() As [String])
      Try
         Dim myWebPermissionIsSubset As New WebPermissionIsSubset()
         myWebPermissionIsSubset.CheckSubset()
      
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message))
      
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.Message))
      End Try
   End Sub 'Main
   
   
   Public Sub CheckSubset()
' <Snippet1>
      ' Create a WebPermission.
      Dim myWebPermission1 As New WebPermission()
      
      ' Allow Connect access to the specified URLs.
      myWebPermission1.AddPermission(NetworkAccess.Connect, New Regex("http://www\.contoso\.com/.*", RegexOptions.Compiled Or RegexOptions.IgnoreCase Or RegexOptions.Singleline))
      
      myWebPermission1.Demand()
      
' </Snippet1>
      ' Create another WebPermission with the specified URL.  
      Dim myWebPermission2 As New WebPermission(NetworkAccess.Connect, "http://www.contoso.com")
      ' Check whether all callers higher in the call stack have been granted the permission.
      myWebPermission2.Demand()
      
' <Snippet2>
      Dim myWebPermission3 As WebPermission = Nothing
      ' Check which permissions have the Connect access to more number of URLs.
      If myWebPermission2.IsSubsetOf(myWebPermission1) Then
         Console.WriteLine(ControlChars.Cr + " WebPermission2 is the Subset of WebPermission1" + ControlChars.Cr)
         myWebPermission3 = myWebPermission1
      Else
         If myWebPermission1.IsSubsetOf(myWebPermission2) Then
            Console.WriteLine(ControlChars.Cr + " WebPermission1 is the Subset of WebPermission2")
            myWebPermission3 = myWebPermission2
         Else
            ' Create the third permission.
            myWebPermission3 = CType(myWebPermission1.Union(myWebPermission2), WebPermission)
         End If
      End If 
' </Snippet2>  
      ' Prints the attributes , values and childrens of XML encoded instances.
      Console.WriteLine(ControlChars.Cr + "Attributes and Values of third WebPermission instance are : ")
      PrintKeysAndValues(myWebPermission3.ToXml().Attributes, myWebPermission3.ToXml().Children)
   End Sub 'CheckSubset
   
   
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
End Class 'WebPermissionIsSubset