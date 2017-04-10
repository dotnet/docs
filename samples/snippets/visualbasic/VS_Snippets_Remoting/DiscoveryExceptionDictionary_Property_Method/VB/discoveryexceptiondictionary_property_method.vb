' System.Web.Services.Discovery.DiscoveryExceptionDictionary
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.Contains
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.Item
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.Remove
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.DiscoveryExceptionDictionary
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.Add
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.Keys
' System.Web.Services.Discovery.DiscoveryExceptionDictionary.Values

' The following example demonstrates the usage of the 
' 'DiscoveryExceptionDictionary' class, the constructor
' 'DiscoveryExceptionDictionary()', the properties 'Item', 'Keys',
' 'Values' and the methods 'Contains', 'Add' and 'Remove' of the class.
' The input to the program is a discovery file 'MathService_vb.disco'
' which holds reference related to 'MathService_cs.asmx' web service.
' The program is executed first with the file 'MathService_vb.asmx' in
' the location as specified in the discovery file. The file
' 'MathService_vb.asmx' is removed from the referred location in a way to
' simulate a scenario wherein the file related to web service is missing,
' and the program is excecuted second time to show the exception occuring.

' <Snippet1>
Imports System
Imports System.Web.Services.Discovery
Imports System.Xml
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Net

Public Class MySample
   
   Shared Sub Main()
      Dim myDiscoFile As String = "http://localhost/MathService_vb.disco"
      Dim myUrlKey As String = "http://localhost/MathService_vb.asmx?wsdl"
      Dim myDiscoveryClientProtocol1 As New DiscoveryClientProtocol()
      Dim myDiscoveryDocument As DiscoveryDocument = myDiscoveryClientProtocol1.Discover(myDiscoFile)
      Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
      While myEnumerator.MoveNext()
         Dim myContractReference As ContractReference = CType(myEnumerator.Current, ContractReference)
         Dim myDiscoveryClientProtocol2 As DiscoveryClientProtocol = myContractReference.ClientProtocol
         myDiscoveryClientProtocol2.ResolveAll()
' <Snippet2>
         Dim myExceptionDictionary As DiscoveryExceptionDictionary = myDiscoveryClientProtocol2.Errors
         If myExceptionDictionary.Contains(myUrlKey) = True Then
            Console.WriteLine("'myExceptionDictionary' contains " + _
                 "a discovery exception for the key '" + myUrlKey + "'")
         Else
            Console.WriteLine("'myExceptionDictionary' does not contain" + _
                 " a discovery exception for the key '" + myUrlKey + "'")
         End If
' </Snippet2>
         If myExceptionDictionary.Contains(myUrlKey) = True Then
            Console.WriteLine("System generated exceptions.")
            
' <Snippet3>
            Dim myException As Exception = myExceptionDictionary(myUrlKey)
            Console.WriteLine(" Source : " + myException.Source)
            Console.WriteLine(" Exception : " + myException.Message)
' </Snippet3>
            Console.WriteLine()
            
' <Snippet4>
            ' Remove the discovery exception.for the key 'myUrlKey'.
            myExceptionDictionary.Remove(myUrlKey)
' </Snippet4>
' <Snippet5>
' <Snippet6>
            Dim myNewExceptionDictionary As New DiscoveryExceptionDictionary()
            ' Add an exception with the custom error message.
            Dim myNewException As New Exception("The requested service is not available.")
            myNewExceptionDictionary.Add(myUrlKey, myNewException)
            myExceptionDictionary = myNewExceptionDictionary
' </Snippet6>
' </Snippet5>
            Console.WriteLine("Added exceptions.")
            
' <Snippet7>
            Dim myArray(myExceptionDictionary.Count -1 ) As Object
            myExceptionDictionary.Keys.CopyTo(CType(myArray, Array), 0)
            Console.WriteLine(" Keys are :")
            Dim myObj As Object
            For Each myObj In  myArray
               Console.WriteLine(" " + myObj.ToString())
            Next myObj
' </Snippet7>
            Console.WriteLine()
            
' <Snippet8>
            Dim myCollectionArray(myExceptionDictionary.Count -1 ) As Object
            myExceptionDictionary.Values.CopyTo(CType(myCollectionArray, Array), 0)
            Console.WriteLine(" Values are :")
            For Each myObj In  myCollectionArray
               Console.WriteLine(" " + myObj.ToString())
            Next myObj
' </Snippet8>
         End If 
      End While
   End Sub 'Main
End Class 'MySample
' </Snippet1>
