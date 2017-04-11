' System.Web.Services.Description.MessageCollection.CopyTo;
' System.Web.Services.Description.MessageCollection.Item Property(Int32);
' System.Web.Services.Description.MessageCollection.Item Property (String);
' System.Web.Services.Description.MessageCollection.Contains;
' System.Web.Services.Description.MessageCollection.IndexOf;
' System.Web.Services.Description.MessageCollection.Remove;

' The program reads a WSDL document "MathService.wsdl" and gets a
' ServiceDescription instance. A MessageCollection instance is then retrieved
' from this ServiceDescription instance and it's members are demonstrated.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyClass1
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = _
                              ServiceDescription.Read("MathService_1.wsdl")
      Console.WriteLine("")
      Console.WriteLine("MessageCollection Sample")
      Console.WriteLine("========================")
      Console.WriteLine("")
' <Snippet2>
      ' Get Message Collection.
      Dim myMessageCollection As MessageCollection = myServiceDescription.Messages
      Console.WriteLine("Total Messages in the document = " + _
                              myServiceDescription.Messages.Count.ToString)
      Console.WriteLine("")
      Console.WriteLine("Enumerating Messages...")
      Console.WriteLine("")
      ' Print messages to console.
      Dim i As Integer
      For i = 0 To myMessageCollection.Count - 1
         Console.WriteLine("Message Name : " + myMessageCollection(i).Name)
      Next
' </Snippet2>
' <Snippet1>
      ' Create a Message Array.
      Dim myMessages(myServiceDescription.Messages.Count) As Message
      ' Copy MessageCollection to an array.
      myServiceDescription.Messages.CopyTo(myMessages, 0)
      Console.WriteLine("")
      Console.WriteLine("Displaying Messages that were copied to Messagearray ...")
      Console.WriteLine("")
      For i = 0 To myMessageCollection.Count - 1
         Console.WriteLine("Message Name : " + myMessages(i).Name)
      Next
' </Snippet1>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
      ' Get Message by Name = "AddSoapIn".
      Dim myMessage As Message = myServiceDescription.Messages("AddSoapIn")
      Console.WriteLine("")
      Console.WriteLine("Getting Message = 'AddSoapIn' {by Name}")
      If myMessageCollection.Contains(myMessage) Then
         Console.WriteLine("")
         ' Get Message Name = "AddSoapIn" Index.
         Console.WriteLine("Message 'AddSoapIn' was found in Message Collection.")
         Console.WriteLine("Index of 'AddSoapIn' in Message Collection = " + _
                           myMessageCollection.IndexOf(myMessage).ToString)
         Console.WriteLine("Deleting Message from Message Collection...")
         myMessageCollection.Remove(myMessage)
         If myMessageCollection.IndexOf(myMessage) = -1 Then
            Console.WriteLine("Message 'AddSoapIn' was successfully " + _
                              " removed from Message Collection.")
         End If
      End If
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
   End Sub 'Main
End Class '[MyClass]
