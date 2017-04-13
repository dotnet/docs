' System.Net.WebPermission.ToXml;System.Net.WebPermission.FromXml;
'
' This program shows the use of the ToXml and FromXml methods of the WebPermission class.
' It creates a WebPermission instance with the Permissionstate set to None and 
' displays the attributes and the values of the XML encoded instance .
' Then a SecurityElement instance is created and it's attributes are set.
' Finally, using the FromXml method the WebPermission instance is reconstructed from 
' the above SecurityElement instance and the attributes are displayed.
'



Imports System
Imports System.Net
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic
 _

Class WebPermission_FromToXml
   
   
   Shared Sub Main()
      Try
         Dim myWebPermission_FromToXml As New WebPermission_FromToXml()
         myWebPermission_FromToXml.CallXml()
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message))
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.Message))
      End Try
   End Sub 'Main
    
   
   Public Sub CallXml()
  
' <Snippet1>
      ' Create  a WebPermission without permission on the protected resource.
      Dim myWebPermission1 As New WebPermission(PermissionState.None)
      
      ' Create a SecurityElement by calling the ToXml method on the WebPermission 
      ' instance and display its attributes (which hold the XML encoding of 
      ' the WebPermission).
      Console.WriteLine("Attributes and Values of the WebPermission are :")
      myWebPermission1.ToXml().ToString()
      
      ' Create another WebPermission with no permission on the protected resource.
      Dim myWebPermission2 As New WebPermission(PermissionState.None)
      
      'Converts the new WebPermission from XML using myWebPermission1.
      myWebPermission2.FromXml(myWebPermission1.ToXml())
      
' </Snippet1>

      Console.WriteLine("The Attributes and Values of 'WebPermission' instance after reconstruction are: " + ControlChars.Cr)
      ' Display the Attributes and values of the XML encoded instances.
      PrintKeysAndValues(myWebPermission2.ToXml().Attributes)
   End Sub 'CallXml
   
   
   Private Sub PrintKeysAndValues(myHashtable As Hashtable)
      ' Get the enumerator to iterate through Hashtable.
      Dim myEnumerator As IDictionaryEnumerator = myHashtable.GetEnumerator()
      Console.WriteLine(ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
      While myEnumerator.MoveNext()
         Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
      End While
      Console.WriteLine()
   End Sub 'PrintKeysAndValues
End Class 'WebPermission_FromToXml