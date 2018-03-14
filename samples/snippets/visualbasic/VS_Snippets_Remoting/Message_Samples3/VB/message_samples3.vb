' System.Web.Services.Description.Message.FindPartsByName
' System.Web.Services.Description.Message.ServiceDescription
' System.Web.Services.Description.Message.FindPartByName

'   The following program demonstrates the property ' ServiceDescription' and
'   methods 'FindPartsByName','FindPartByName' of class 'Message'. The program
'   reads a wsdl document "MathService_vb.wsdl" and instantiates a 
'   ServiceDescription instance from WSDL document. 
'   The program invokes 'FindPartsByName' to obtain an array of MessagePart's 
'   and also invokes 'FindPartByName' to retrieve a specific 'MessagePart'.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Namespace MyMessage
   Class MyClass1
      Public Shared Sub Main()
         Try
' <Snippet2>
            Dim myServiceDescription As ServiceDescription = _
                                    ServiceDescription.Read("MathService_vb.wsdl")
' <Snippet1>
            ' Get message from ServiceDescription.
            Dim myMessage1 As Message = myServiceDescription.Messages("AddHttpPostIn")
            Console.WriteLine("ServiceDescription :" + _
                              myMessage1.ServiceDescription.ToString())
' </Snippet2>
            Dim myParts(1) As String
            myParts(0) = "a"
            myParts(1) = "b"
            Dim myMessageParts As MessagePart() = myMessage1.FindPartsByName(myParts)
            Console.WriteLine("Results of FindPartsByName operation:")
            Dim i As Integer
            For i = 0 To myMessageParts.Length - 1
               Console.WriteLine("Part Name: " + myMessageParts(i).Name)
               Console.WriteLine("Part Type: " + myMessageParts(i).Type.ToString())
            Next i
' </Snippet1>

' <Snippet3>
            ' Get another message from ServiceDescription.
            Dim myMessage2 As Message = myServiceDescription.Messages("DivideHttpGetOut")
            Dim myMessagePart As MessagePart = myMessage2.FindPartByName("Body")
            Console.WriteLine("Results of FindPartByName operation:")
            Console.WriteLine("Part Name: " + myMessagePart.Name)
            Console.WriteLine("Part Element: " + myMessagePart.Element.ToString())
' </Snippet3>
         Catch e As Exception
            Console.WriteLine("Exception: " + e.Message)
         End Try
      End Sub 'Main
   End Class 'MyClass1
End Namespace 'MyMessage