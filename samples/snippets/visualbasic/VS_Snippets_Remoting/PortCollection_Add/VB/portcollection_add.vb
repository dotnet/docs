' System.Web.Services.Description.PortCollection.Contains
' System.Web.Services.Description.PortCollection.Add

' The following sample reads the contents of a file 'MathServiceAdd_vb.wsdl'
' into a 'ServiceDescription' instance. It gets the collection of Service
' instances from 'ServiceDescription'. It then adds a new port and checks
' whether a port exists.  The programs writes a new web service description
' file.

Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class PortCollection_2
   Public Shared Sub Main()
      Try
         Dim myService As Service
         Dim myPortCollection As PortCollection
         Dim myServiceDescription As ServiceDescription = _
                           ServiceDescription.Read("MathServiceAdd_vb.wsdl")

         Console.WriteLine(ControlChars.NewLine + _
                           "Total Number of Services :" + _
                            myServiceDescription.Services.Count.ToString)

         Dim i As Integer
         For i =0 To myServiceDescription.Services.Count - 1
            myService = myServiceDescription.Services(i)
            Console.WriteLine("Name : " + myService.Name)
' <Snippet1>
' <Snippet2>
            myPortCollection = myService.Ports
            Dim myNewPort As Port = myPortCollection(0)
            myPortCollection.Remove(myNewPort)

            ' Display the number of ports.
            Console.WriteLine(ControlChars.NewLine & _
               "Total number of ports before " & _
               "adding a new port : " & _
               myService.Ports.Count.ToString)

            ' Add a new port.
            myPortCollection.Add(myNewPort)

            ' Display the number of ports after adding a port.
            Console.WriteLine("Total number of ports after " & _
               "adding a new port : " & _
               myService.Ports.Count.ToString)

' </Snippet2>
            Dim bContain As Boolean = myPortCollection.Contains(myNewPort)

            Console.WriteLine(ControlChars.NewLine + "Port '" + _
                              myNewPort.Name + "' exists : " + bContain.ToString)

            ' Remove a port from the collection.
            myPortCollection.Remove(myPortCollection(myNewPort.Name))

            bContain = myPortCollection.Contains(myNewPort)

            Console.WriteLine("Port '" + myNewPort.Name + "' exists : " + _
                              bContain.ToString)

            ' Create the description file.
            myPortCollection.Insert(0, myNewPort)
            myServiceDescription.Write("MathServiceAddNew_vb.wsdl")
' </Snippet1>

         Next
      Catch ex As Exception
         Console.WriteLine("Exception:" + ex.Message)
      End Try
   End Sub 'Main
End Class 'PortCollection_2
