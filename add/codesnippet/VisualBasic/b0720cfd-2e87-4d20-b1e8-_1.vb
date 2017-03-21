      Dim myMimePart2 As New MimePart()
      Dim myMimeXmlBinding2 As New MimeXmlBinding()
      myMimeXmlBinding2.Part = "body"
      myMimePart2.Extensions.Add(myMimeXmlBinding2)
      ' Add a mimepart to the mimepartcollection.
      myMimePartCollection.Add(myMimePart2)
      Console.WriteLine("Adding a mimepart object...")
      ' Check if collection contains added mimepart object.
      If myMimePartCollection.Contains(myMimePart2) Then
         Console.WriteLine("'MimePart' is succesfully added at position: " + _
                        myMimePartCollection.IndexOf(myMimePart2).ToString())
      End If