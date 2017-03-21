         Dim myString As String = Nothing
         Dim myOperation As New Operation()
         myDescription = ServiceDescription.Read("Operation_2_Input_VB.wsdl")
         Dim myMessage(myDescription.Messages.Count) As Message

         ' Copy the messages from the service description.
         myDescription.Messages.CopyTo(myMessage, 0)
         Dim i As Integer
         For i = 0 To myDescription.Messages.Count - 1
            Dim myMessagePart(myMessage(i).Parts.Count) As MessagePart

            ' Copy the message parts into a MessagePart.
            myMessage(i).Parts.CopyTo(myMessagePart, 0)
            Dim j As Integer
            For j = 0 To (myMessage(i).Parts.Count) - 1
               myString += myMessagePart(j).Name
               myString += " "
            Next j
         Next i

         ' Set the ParameterOrderString equal to the list of 
         ' message part names.
         myOperation.ParameterOrderString = myString
         Dim myString1 As String() = myOperation.ParameterOrder
         Dim k As Integer = 0
         Console.WriteLine("The list of message part names is as follows:")
         While k < 5
            Console.WriteLine(myString1(k))
            k += 1
         End While