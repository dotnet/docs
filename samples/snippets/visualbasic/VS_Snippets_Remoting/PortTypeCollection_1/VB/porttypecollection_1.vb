' System.Web.Services.Description.PortTypeCollection.Item[int]
' System.Web.Services.Description.PortTypeCollection.Remove()
' System.Web.Services.Description.PortTypeCollection.Add()

' The following sample demonstrates the indexer 'Item[int]', methods
' 'Remove()' and 'Add()' of class 'PortTypeCollection'. It reads the
' contents of a file 'MathService.wsdl'into a 'ServiceDescription' instance.
' It gets the collection of 'PortType' from 'ServiceDescription' and adds
' a new PortType and writes a new web service description file into 
' 'MathService_New.wsdl'.

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
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
            myServiceDescription.PortTypes
         
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.Newline & "Total number of PortTypes: " & _
            myServiceDescription.PortTypes.Count.ToString())
         
         ' Get the first PortType in the collection.
         Dim myNewPortType As PortType = myPortTypeCollection(0)
         Console.WriteLine( _
            "The PortType at index 0 is: " & myNewPortType.Name)
         Console.WriteLine("Removing the PortType " & myNewPortType.Name)
         
         ' Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType)

         ' Display the number of PortTypes.
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes after removing: " & _
            myServiceDescription.PortTypes.Count.ToString())
         
         Console.WriteLine("Adding a PortType " & myNewPortType.Name)

         ' Add a new PortType from the collection.
         myPortTypeCollection.Add(myNewPortType)

         ' Display the number of PortTypes after adding a port.
         Console.WriteLine( _
            "Total Number of PortTypes after adding a new port: " & _
            myServiceDescription.PortTypes.Count.ToString())
         
         myServiceDescription.Write("MathService_New.wsdl")
' </Snippet3>
' </Snippet2>
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception: " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyPortTypeCollectionClass
