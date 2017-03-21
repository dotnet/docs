      Dim myArray(myMimePartCollection.Count-1) As MimePart
      ' Copy the mimepartcollection to an array.
      myMimePartCollection.CopyTo(myArray, 0)
      Console.WriteLine("Displaying the array copied from mimepartcollection")
      Dim j As Integer
      For j = 0 To myMimePartCollection.Count - 1
         Console.WriteLine("Mimepart object at position : " + j.ToString())
         For i = 0 To (myArray(j).Extensions.Count) - 1
            Dim myMimeXmlBinding3 As MimeXmlBinding = CType(myArray(j).Extensions(i), _
                                                                           MimeXmlBinding)
            Console.WriteLine("Part: " + myMimeXmlBinding3.Part)
         Next i
      Next j