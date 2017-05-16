' System.web.Services.Discovery.DiscoveryClientProtocol.Errors

' The following example demonstrates the usage of the 'Errors' property
' of the class 'DiscoveryClientProtocol'. The input to the program is
' a discovery file 'MathService_vb.vsdisco', which holds reference 
' related to 'MathService_vb.asmx' web service. The program is 
' excecuted first time with existence of the file 
' 'MathService_vb.asmx' in the location as specified in the discovery
' file. The file 'MathService_vb.asmx' is removed from the referred 
' location in a way to simulate a scenario wherein the file related 
' to web service is missing, and the program is excecuted the second time
' to show the exception occuring.
Option Strict On
Imports System
Imports System.Web.Services.Discovery
Imports System.Collections

Public Class DiscoveryClientProtocol_Errors
   
   Public Shared Sub Main()
' <Snippet1>
      Dim myDiscoFile As String = "http://localhost/MathService_vb.vsdisco"
      Dim myUrlKey As String = "http://localhost/MathService_vb.asmx?wsdl"
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      
      ' Get the discovery document.
      Dim myDiscoveryDocument As DiscoveryDocument = myDiscoveryClientProtocol.Discover(myDiscoFile)
      Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
      While myEnumerator.MoveNext()
        Dim myContractReference As ContractReference = CType(myEnumerator.Current, ContractReference)
         
        ' Get the DiscoveryClientProtocol from the ContractReference.
         myDiscoveryClientProtocol = myContractReference.ClientProtocol
         myDiscoveryClientProtocol.ResolveAll()

         Dim myExceptionDictionary As DiscoveryExceptionDictionary = myDiscoveryClientProtocol.Errors

         If myExceptionDictionary.Contains(myUrlKey) Then
            Console.WriteLine("System generated exceptions.")
            
            ' Get the exception from the DiscoveryExceptionDictionary.
            Dim myException As Exception = myExceptionDictionary(myUrlKey)
            
            Console.WriteLine(" Source : " & myException.Source)
            Console.WriteLine(" Exception : " & myException.Message)
            Console.WriteLine()
         End If
      End While
' </Snippet1>
   End Sub 'Main 
End Class 'DiscoveryClientProtocol_Errors