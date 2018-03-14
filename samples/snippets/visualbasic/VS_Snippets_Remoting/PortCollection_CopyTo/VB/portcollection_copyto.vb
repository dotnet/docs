' System.Web.Services.Description.PortCollection.Insert
' System.Web.Services.Description.PortCollection.IndexOf
' System.Web.Services.Description.PortCollection.CopyTo

' The following sample reads the contents of a file 'MathServiceCopyTo_vb.wsdl'
' into a 'ServiceDescription' instance. It gets the collection of Service
' instances from 'ServiceDescription'. It instantiates 'PortCollection' for
' each service in the collection. 'CopyTo' is called to copy
' the contents into an array.Calls 'IndexOf' for a given port.
' 'Insert' method is called to insert a new port in the collection.

Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class PortCollection_3
   Public Shared Sub Main()
      Try
         Dim myService As Service
         Dim myPortCollection As PortCollection
         Dim myServiceDescription As ServiceDescription = _
                        ServiceDescription.Read("MathServiceCopyTo_vb.wsdl")

         Console.WriteLine("Total Number of Services :" + _
                           myServiceDescription.Services.Count.ToString)

         Dim i As Integer
         For i =0 to myServiceDescription.Services.Count -1
            myService = myServiceDescription.Services(i)
            Console.WriteLine("Name : " + myService.Name)

' <Snippet1>
' <Snippet2>
' <Snippet3>
            myPortCollection = myService.Ports

            ' Create an array of Port objects.
            Console.WriteLine(ControlChars.NewLine & "Port collection :")
            Dim myPortArray(myService.Ports.Count) As Port
            myPortCollection.CopyTo(myPortArray, 0)
            Dim i1 As Integer
            For i1 = 0 to myService.Ports.Count -1
               Console.WriteLine("Port[" & i1.ToString + "] : " & _
                  myPortArray(i1).Name)
            Next
' </Snippet3>
            Dim myIndexPort As Port = myPortCollection(0)
            Console.WriteLine(ControlChars.NewLine + ControlChars.NewLine + _
                              "The index of port '" + myIndexPort.Name + "' is : " + _
                              myPortCollection.IndexOf(myIndexPort).ToString)
' </Snippet2>
            Dim myPortTestInsert As Port = myPortCollection(0)
            myPortCollection.Remove(myPortTestInsert)
            myPortCollection.Insert(0, myPortTestInsert)
            Console.WriteLine(ControlChars.NewLine + ControlChars.NewLine + _
                  "Total Number of Ports after inserting " + "a new port '" + _
                  myPortTestInsert.Name + "' is : " + myService.Ports.Count.ToString)
            While i1 < myService.Ports.Count
               Console.WriteLine("Port[" + i1.ToString + "]  : " + myPortArray(i1).Name)
            End While
            myServiceDescription.Write("MathServiceCopyToNew_vb.wsdl")
' </Snippet1>
      Next
      Catch ex As Exception
         Console.WriteLine("Exception:" + ex.Message)
      End Try
   End Sub 'Main
End Class 'PortCollection_3
