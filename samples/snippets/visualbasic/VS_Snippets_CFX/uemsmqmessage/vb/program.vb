Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.MsmqIntegration
Imports System.Messaging

Namespace UEMsmqMessage
    Friend Class Program

        Shared Sub Main(ByVal args() As String)
            ' <Snippet1>
            Dim message As New MsmqMessage(Of String)("Hello, world")
            ' </Snippet1>

            ' <Snippet2>
            Dim message2 As New MsmqMessage(Of String)(message.Body)
            ' </Snippet2>

            ' <Snippet3>
            message.AcknowledgeType = AcknowledgeTypes.PositiveArrival
            ' </Snippet3>

            ' <Snippet4>
            If message.Acknowledgment = Acknowledgment.Receive Then
                Console.WriteLine("Message sent with Receive acknowledgment")
            End If
            ' </Snippet4>

            ' <Snippet5>
            message.AdministrationQueue = New Uri(".\private$\MyAdminQueue")
            ' </Snippet5>

            ' <Snippet6>
            message.AppSpecific = 5
            ' </Snippet6>

            ' <Snippet7>
            Console.WriteLine("Message arrived at the destination queue at {0}", message.ArrivedTime.ToString())
            ' </Snippet7>

            ' <Snippet8>
            If message.Authenticated = True Then
                Console.WriteLine("Message was authenticated")
            End If
            ' </Snippet8>

            ' <Snippet9>
            Dim body = message.Body
            ' </Snippet9>

            ' <Snippet10>
            message.BodyType = 23
            ' </Snippet10>

            ' <Snippet11>
            message.CorrelationId = "This message"
            ' </Snippet11>

            ' <Snippet12>
            Console.WriteLine("The destination queue is {0}", message.DestinationQueue.ToString())
            ' </Snippet12>

            ' <Snippet13>
            Dim buffer() As Byte = {&H10, &H11, &H12, &H14}
            message.Extension = buffer
            ' </Snippet13>

            ' <Snippet14>
            Dim MessageId = message.Id
            ' </Snippet14>

            ' <Snippet15>
            message.Label = "Message1 Label"
            ' </Snippet15>

            ' <Snippet16>
            Console.WriteLine("The message type is {0}", message.MessageType)
            ' </Snippet16>

            ' <Snippet17>
            message.Priority = MessagePriority.Normal
            ' </Snippet17>

            ' <Snippet18>
            message.ResponseQueue = New Uri(".\private$\MyResponseQueue")
            ' </Snippet18>

            ' <Snippet19>
            Console.WriteLine("SenderID is {0}", message.SenderId)
            ' </Snippet19>

            ' <Snippet20>
            Console.WriteLine("Message was sent at {0}", message.SentTime)
            ' </Snippet20>

            ' <Snippet21>
            message.TimeToReachQueue = New TimeSpan(0, 10, 0)
            ' </Snippet21>
        End Sub
    End Class
End Namespace
