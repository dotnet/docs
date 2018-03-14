' System.Web.Services.Description.PortTypeCollection

'  The following sample demonstrates the class 'PortTypeCollection'. It reads the
'  contents of  WSDL document 'MathService.wsdl'into a 'ServiceDescription' instance.
'  It gets the collection of 'PortType'from 'ServiceDescription'. It copies the
'  collection into an array of 'PortType' and displays their names. Then it removes a
'  'PortType', checks whether the collection contains the removed 'PortType'.
'  It adds the same 'PortType' and writes a new web service description file into
'  'MathService_New.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports System.Collections
Imports Microsoft.VisualBasic

Class MyPortTypeCollectionClass
   Public Shared Sub Main()
      Try
         ' Read the existing Web service description file.
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
            myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = _
            myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.Newline & "Total number of PortTypes: " & _
            myServiceDescription.PortTypes.Count.ToString())

         ' Get the first PortType in the collection.
         Dim myNewPortType As PortType = _
            myPortTypeCollection("MathServiceSoap")
         Dim index As Integer = myPortTypeCollection.IndexOf(myNewPortType)
         Console.WriteLine("The PortType with the name " & _
            myNewPortType.Name & " is at index: " & (index + 1).ToString())

         Console.WriteLine("Removing the PortType: " & myNewPortType.Name)

         ' Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType)
         Dim bContains As Boolean = _
            myPortTypeCollection.Contains(myNewPortType)
         Console.WriteLine("The PortType with the Name " & _
            myNewPortType.Name & " exists: " & bContains.ToString())

         Console.WriteLine("Total Number of PortTypes after removing: " & _
            myServiceDescription.PortTypes.Count.ToString())

         Console.WriteLine("Adding a PortType: " & myNewPortType.Name)

         ' Add a new portType from the collection.
         myPortTypeCollection.Add(myNewPortType)

         ' Display the number of portTypes after adding a port.
         Console.WriteLine( _
            "Total Number of PortTypes after adding a new port: " & _
            myServiceDescription.PortTypes.Count.ToString())

         ' List the PortTypes available in the WSDL document.
         Dim myPortType As PortType
         For Each myPortType In  myPortTypeCollection
            Console.WriteLine("The PortType name is: " & myPortType.Name)
         Next myPortType
         myServiceDescription.Write("MathService_New.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception: " & e.Message)
      End Try
   End Sub 'Main
End Class 'MyPortTypeCollectionClass
' </Snippet1>
