      ' Get the message part collection for each message.
      Dim i As Integer
      For i =0 to myMessageCollection.Count-1
         Console.WriteLine("Message      : " & myMessageCollection(i).Name)

         ' Get the message part collection.
         Dim myMessagePartCollection As MessagePartCollection = _
            myMessageCollection(i).Parts

         ' Display the part collection.
         Dim k As Integer
         For k = 0 To myMessagePartCollection.Count - 1
            Console.WriteLine(ControlChars.Tab & "       Part Name     : " & _
               myMessagePartCollection(k).Name)
            Console.WriteLine(ControlChars.Tab & "       Message Name  : " & _
               myMessagePartCollection(k).Message.Name)
         Next k
         Console.WriteLine("")
      Next