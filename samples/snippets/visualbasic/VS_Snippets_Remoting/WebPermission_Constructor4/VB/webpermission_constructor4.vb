'   System.Net.WebPermission.WebPermission(NetworkAccess,Regex);

'   This program demonstrates the  'WebPermission(NetworkAccess,Regex)' constructor of 'WebPermission' class.
'   First  a 'Regex' object is created that will accept all the urls which is having the hostfragment of
'   'www.microsoft.com'.Then a 'WebPermission' object created by passing the 'NetworkAccess' permission and 
'   'Regex' object as parameters. It  checks the 'WebPermission' for all the url's having the host fragment 
'   as 'www.microsoft.com'.
'

Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Text.RegularExpressions
Imports System.Collections
Imports Microsoft.VisualBasic


Class WebPermission_regexConstructor
  
  
  Shared Sub Main()
  Try
    
    Dim myWebPermissionRegex As New WebPermission_regexConstructor()
    myWebPermissionRegex.CreateRegexConstructor()
  
  Catch e As SecurityException
    Console.WriteLine(("SecurityException raised: " + e.Message))
  Catch e As Exception
    Console.WriteLine(("Exception raised: " + e.Message))
  End Try
  End Sub 'Main
  
  
  Public Sub CreateRegexConstructor()
  
' <Snippet1>
  '  Creates an instance of 'Regex' that accepts all  URL's containing the host fragment 'www.contoso.com'.
  Dim myRegex As New Regex("http://www\.contoso\.com/.*")
    
     ' Creates a 'WebPermission' that gives the permissions to all the hosts containing same host fragment.
     Dim myWebPermission As New WebPermission(NetworkAccess.Connect, myRegex)
     
    '  Checks all callers higher in the call stack have been granted the permission.
    myWebPermission.Demand()

' </Snippet1> 
    Console.WriteLine("Attribute and Values of WebPermission are : " + ControlChars.Cr)
    ' Display the Attributes,Values and Children of the XML encoded copied instance.
    PrintKeysAndValues(myWebPermission.ToXml().Attributes, myWebPermission.ToXml().Children)


   End Sub 'CreateRegexConstructor
   
  
  Private Sub PrintKeysAndValues(myHashtable As Hashtable, myList As IEnumerable)
    ' Get the enumerator that can iterate through Hashtabel.
    Dim myEnumerator As IDictionaryEnumerator = myHashtable.GetEnumerator()
    Console.WriteLine(ControlChars.Tab + "-ATTRIBUTES-" + ControlChars.Tab + "-VALUE-")
    While myEnumerator.MoveNext()
      Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
    End While
    Console.WriteLine()
    
    Dim myEnumerator1 As IEnumerator = myList.GetEnumerator()
    Console.WriteLine(ControlChars.Cr + "The Children are : ")
    While myEnumerator1.MoveNext()
      Console.Write(ControlChars.Tab + "{0}", myEnumerator1.Current)
    End While
  End Sub 'PrintKeysAndValues
End Class 'WebPermission_regexConstructor
