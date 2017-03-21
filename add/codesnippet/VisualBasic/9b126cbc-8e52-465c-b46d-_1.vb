         ' Get an array instance of 'MimeTextMatch' class.
         Dim myMimeTextMatch(3) As MimeTextMatch
         myMimeTextMatchCollection = myMimeTextBinding.Matches
         ' Initialize properties of 'MimeTextMatch' class.
         For myInt = 0 To 3
            ' Create the 'MimeTextMatch' instance.
            myMimeTextMatch(myInt) = New MimeTextMatch()
            myMimeTextMatch(myInt).Name = "Title"
            myMimeTextMatch(myInt).Type = "*/*"
            myMimeTextMatch(myInt).IgnoreCase = True

            If True = myMimeTextMatchCollection.Contains(myMimeTextMatch(0)) Then
               myMimeTextMatch(myInt).Name = "Title" + Convert.ToString(myInt)
               myMimeTextMatch(myInt).Capture = 2
               myMimeTextMatch(myInt).Group = 2
               myMimeTextMatchCollection.Add(myMimeTextMatch(myInt))
            Else
               myMimeTextMatchCollection.Add(myMimeTextMatch(myInt))
               myMimeTextMatchCollection(myInt).RepeatsString = "2"
            End If
         Next myInt
         myMimeTextMatchCollection = myMimeTextBinding.Matches
         ' Copy collection to 'MimeTextMatch' array instance.
         myMimeTextMatchCollection.CopyTo(myMimeTextMatch, 0)