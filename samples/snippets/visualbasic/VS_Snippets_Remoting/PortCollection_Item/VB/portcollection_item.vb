' System.Web.Services.Description.PortCollection
' System.Web.Services.Description.PortCollection.Remove
' System.Web.Services.Description.PortCollection.Item(String)
' System.Web.Services.Description.PortCollection.Item(Int32)

' The following sample reads the contents of a file 'MathServiceItem_vb.wsdl'
' into a 'ServiceDescription' instance. It gets the collection of Service
' instances from 'ServiceDescription'. It instantiates 'PortCollection' for
' each service in the collection. It access the ports from the collection and
' displays them.It accesses  a port by its name from the collection  and
' displays its index.It adds a new port and calls 'Remove'
' to remove the newly added port.The programs writes a new web service
' description file.

Imports System
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic

Class PortCollection_Item
    Public Shared Sub Main()
      Try
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
         Dim myService As Service
         Dim myPortCollection As PortCollection

         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathServiceItem_vb.wsdl")

         Console.WriteLine("Total number of services : " & _
            myServiceDescription.Services.Count.ToString)

         Dim i As Integer
         For i = 0 to myServiceDescription.Services.Count - 1
            myService = myServiceDescription.Services(i)
            Console.WriteLine("Name : " & myService.Name)

            myPortCollection = myService.Ports

            ' Create an array of ports.
            Console.WriteLine(ControlChars.NewLine & "Port collection :")
            Dim i1 As Integer
            For i1 = 0 to myService.Ports.Count - 1
               Console.WriteLine("Port[" & i1.ToString & "] : " & _
                  myPortCollection(i1).Name)
            Next
' </Snippet4>
            Dim strPort As String = myPortCollection(0).Name
            Dim myPort As Port = myPortCollection(strPort)
            Console.WriteLine(ControlChars.NewLine & _
               "Index of Port[" & strPort & "] : " & _
               myPortCollection.IndexOf(myPort).ToString)

' </Snippet3>
            Dim myPortTestRemove As Port = myPortCollection(0)

            Console.WriteLine(ControlChars.NewLine & _
               "Total number of ports before removing " & _
               "a port '" & myPortTestRemove.Name & "' is : " & _
               myService.Ports.Count.ToString)
            myPortCollection.Remove(myPortTestRemove)
            Console.WriteLine("Total number of ports after removing " & _
               "a port '" & myPortTestRemove.Name & "' is : " & _
               myService.Ports.Count.ToString)

            ' Create the WSDL file.
            myPortCollection.Insert(0, myPortTestRemove)
            myServiceDescription.Write("MathServiceItemNew_vb.wsdl")
         Next
' </Snippet2>
' </Snippet1>
      Catch ex As Exception
         Console.WriteLine("Exception: " & ex.Message)
      End Try
   End Sub 'Main
End Class 'PortCollection_Item
