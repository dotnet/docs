      Dim myMimeMultipartRelatedBinding As MimeMultipartRelatedBinding = Nothing
      Dim myIEnumerator As IEnumerator = myOutputBinding.Extensions.GetEnumerator()
      While myIEnumerator.MoveNext()
         myMimeMultipartRelatedBinding = CType(myIEnumerator.Current, MimeMultipartRelatedBinding)
      End While
      ' Create an instance of 'MimePartCollection'.
      Dim myMimePartCollection As New MimePartCollection()
      myMimePartCollection = myMimeMultipartRelatedBinding.Parts
      Console.WriteLine("Total number of mimepart elements in the collection initially" + _
                                                   " is: " + myMimePartCollection.Count.ToString())
      ' Get the type of first 'Item' in collection.
      Console.WriteLine("The first object in collection is of type: " + _
                                                            myMimePartCollection.Item(0).ToString())
      Dim myMimePart1 As New MimePart()
      ' Create an instance of 'MimeXmlBinding'.
      Dim myMimeXmlBinding1 As New MimeXmlBinding()
      myMimeXmlBinding1.Part = "body"
      myMimePart1.Extensions.Add(myMimeXmlBinding1)
      '  a mimepart at first position.
      myMimePartCollection.Insert(0, myMimePart1)
      Console.WriteLine("Inserting a mimepart object...")
      ' Check whether 'Insert' was successful or not.
      If myMimePartCollection.Contains(myMimePart1) Then
         ' Display the index of inserted 'MimePart'.
         Console.WriteLine("'MimePart' is succesfully inserted at position: " + _
                                            myMimePartCollection.IndexOf(myMimePart1).ToString())
      End If