' System.Web.Services.Description.PortTypeCollection.Contains()
' System.Web.Services.Description.PortTypeCollection.Insert()
' System.Web.Services.Description.PortTypeCollection.IndexOf()
' System.Web.Services.Description.PortTypeCollection.Item[string]

' The following sample demonstrates the methods 'IndexOf()','Insert()','Contains' and
' indexer 'Item[string]' of class 'PortTypeCollection'. This sample reads the contents 
' of 'MathService.wsdl' into a 'ServiceDescription' instance. It gets the collection of 
' 'PortType' instances from 'ServiceDescription'. It removes a 'PortType' with the name 
' 'MathServiceSoap' and adds the same later. Then it checks whether the collection contains 
' the added 'PortType'.The sample writes a new web service description file 'MathService_New.wsdl'.

Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyPortTypeCollectionClass
   
   Public Shared Sub Main()
      Try
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         
         Dim myPortTypeCollection As PortTypeCollection = _
            myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes: " & noOfPortTypes.ToString())
         
         Dim myNewPortType As PortType = myPortTypeCollection("MathServiceSoap")
' </Snippet4>
         ' Get the index in the collection.
         Dim index As Integer = myPortTypeCollection.IndexOf(myNewPortType)
' </Snippet3>
         Console.WriteLine("Removing the PortType named " & _
            myNewPortType.Name)

         ' Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType)
         noOfPortTypes = myServiceDescription.PortTypes.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes: " & noOfPortTypes.ToString())

         ' Check whether the PortType exists in the collection.
         Dim bContains As Boolean = myPortTypeCollection.Contains(myNewPortType)
         Console.WriteLine("Port Type'" & myNewPortType.Name & _
            "' exists: " & bContains.ToString())
         
         Console.WriteLine("Adding the 'PortType'")
         ' Insert a new portType at the index location.
         myPortTypeCollection.Insert(index, myNewPortType)
' </Snippet2>

         ' Display the number of portTypes after adding a port.
         Console.WriteLine("Total number of PortTypes after " & _
            "adding a new port: " & _
            myServiceDescription.PortTypes.Count.ToString())

         bContains = myPortTypeCollection.Contains(myNewPortType)
         Console.WriteLine("Port Type'" & myNewPortType.Name & "' exists: " _
            & bContains.ToString())
         myServiceDescription.Write("MathService_New.wsdl")
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception: " + e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyPortTypeCollectionClass
