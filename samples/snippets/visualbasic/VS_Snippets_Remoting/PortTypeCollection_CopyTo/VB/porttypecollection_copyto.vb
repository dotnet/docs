' System.Web.Services.Description.PortTypeCollection.CopyTo()

' The following sample demonstrates the 'CopyTo()' method of the class
' 'PortTypeCollection'.This sample reads the contents of a file 'MathService.wsdl'
' into a 'ServiceDescription' instance. It gets the collection of 'PortType'
' from 'ServiceDescription'. It copies the collection into an array of 'PortType' 
' and displays their names.

Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyPortTypeCollectionClass   
   Public Shared Sub Main()
      Try
' <Snippet1>
         Dim myPortTypeCollection As PortTypeCollection
         
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         myPortTypeCollection = myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.NewLine + "Total number of PortTypes: " & _
            myServiceDescription.PortTypes.Count.ToString())

         ' Copy the collection into an array.
         Dim myPortTypeArray(noOfPortTypes-1) As PortType
         myPortTypeCollection.CopyTo(myPortTypeArray, 0)

         ' Display names of all PortTypes.
         Dim i As Integer
         For i = 0 To noOfPortTypes - 1
            Console.WriteLine("PortType Name: " + myPortTypeArray(i).Name)
         Next i
         myServiceDescription.Write("MathService_New.wsdl")
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception: " + e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyPortTypeCollectionClass