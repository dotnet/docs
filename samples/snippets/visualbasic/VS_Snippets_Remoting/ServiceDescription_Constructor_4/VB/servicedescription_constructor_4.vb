' System.Web.Services.Description.ServiceDescription.ServiceDescription()
' System.Web.Services.Description.ServiceDescription.Read(string)
' System.Web.Services.Description.ServiceDescription.Messages
' System.Web.Services.Description.ServiceDescription.Name

' The following example demonstrates the constructor 'ServiceDescription()', 
' 'Messages','Name'  properties and 'Read'  method of 'ServiceDescription'
' class.The input to the program is a WSDL file 'MyWsdl.wsdl'.
' This program removes one message from the existing WSDL.
' A new Message is defined and added to the ServiceDescription.
' A new wsdl with modified ServiceDescription is written in 'MyOutWsdl.wsdl'.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Xml

Namespace ServiceDescription1
   Class MyService
      
      Shared Sub Main()
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
         Dim myDescription As New ServiceDescription()
         myDescription = ServiceDescription.Read("MyWsdl_VB.wsdl")
         myDescription.Name = "MyServiceDescription"
         Console.WriteLine("Name: " & myDescription.Name)
         Dim myMessageCollection As MessageCollection = myDescription.Messages
         
         ' Remove the message at index 0 from the message collection.
         myMessageCollection.Remove(myDescription.Messages(0))
         
         ' Build a new Message.
         Dim myMessage As New Message()
         myMessage.Name = "AddSoapIn"
         
         ' Build a new MessagePart.
         Dim myMessagePart As New MessagePart()
         myMessagePart.Name = "parameters"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:Add")
         myMessagePart.Element = myXmlQualifiedName
         
         ' Add MessageParts to the message.
         myMessage.Parts.Add(myMessagePart)

         ' Add the message to the ServiceDescription.
         myDescription.Messages.Add(myMessage)
         myDescription.Write("MyOutWsdl.wsdl")
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>
      End Sub 'Main 
   End Class 'MyService 
End Namespace 'ServiceDescription1 
