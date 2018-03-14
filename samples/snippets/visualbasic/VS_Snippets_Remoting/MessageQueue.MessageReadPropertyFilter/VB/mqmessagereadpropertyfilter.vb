' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example retrieves specific groups of Message
        ' properties.
        

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Retrieve specific sets of Message properties.
            myNewQueue.RetrieveDefaultProperties()
            myNewQueue.RetrieveAllProperties()
            myNewQueue.RetrieveSelectedProperties()

            Return

        End Sub 'Main


        
        ' Retrieves the default properties for a Message.
        

        Public Sub RetrieveDefaultProperties()

            ' Connect to a message queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Specify to retrieve the default properties only.
            myQueue.MessageReadPropertyFilter.SetDefaults()

            ' Set the formatter for the Message.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            ' Receive the first message in the queue.
            Dim myMessage As Message = myQueue.Receive()

            ' Display selected properties.
            Console.WriteLine(("Label: " + myMessage.Label))
            Console.WriteLine(("Body: " + CType(myMessage.Body, _
                [String])))

            Return

        End Sub 'RetrieveDefaultProperties


        
        ' Retrieves all properties for a Message.
        

        Public Sub RetrieveAllProperties()

            ' Connect to a message queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Specify to retrieve all properties.
            myQueue.MessageReadPropertyFilter.SetAll()

            ' Set the formatter for the Message.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            ' Receive the first message in the queue.
            Dim myMessage As Message = myQueue.Receive()

            ' Display selected properties.
            Console.WriteLine(("Encryption algorithm: " + _
                myMessage.EncryptionAlgorithm.ToString()))
            Console.WriteLine(("Body: " + CType(myMessage.Body, _
                [String])))

            Return

        End Sub 'RetrieveAllProperties


        
        ' Retrieves application-specific properties for a
        ' Message.
        

        Public Sub RetrieveSelectedProperties()

            ' Connect to a message queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Specify to retrieve selected properties.
            Dim myFilter As New MessagePropertyFilter()
            myFilter.ClearAll()
            ' The following list is a random subset of properties.
            myFilter.Body = True
            myFilter.Label = True
            myFilter.MessageType = True
            myFilter.Priority = True
            myQueue.MessageReadPropertyFilter = myFilter

            ' Set the formatter for the Message.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            ' Receive the first message in the queue.
            Dim myMessage As Message = myQueue.Receive()

            ' Display selected properties.
            Console.WriteLine(("Message type: " + _
                myMessage.MessageType.ToString()))
            Console.WriteLine(("Priority: " + _
                myMessage.Priority.ToString()))

            Return

        End Sub 'RetrieveSelectedProperties

End Class 'MyNewQueue

' </Snippet1>