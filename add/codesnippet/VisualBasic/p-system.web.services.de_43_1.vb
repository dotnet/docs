         ' Create an InputBinding.
         Dim myInputBinding As New InputBinding()
         Dim myMimeTextBinding As New MimeTextBinding()
         Dim myMimeTextMatchCollection1 As New MimeTextMatchCollection()
         Dim myMimeTextMatch(2) As MimeTextMatch
         myMimeTextMatchCollection1 = myMimeTextBinding.Matches

         ' Intialize the MimeTextMatch. 
         For myInt = 0 To 2

            ' Get a new MimeTextMatch.
            myMimeTextMatch(myInt) = New MimeTextMatch()

            ' Assign values to properties of the MimeTextMatch.
            myMimeTextMatch(myInt).Name = "Title" + Convert.ToString(myInt)
            myMimeTextMatch(myInt).Type = "*/*"
            myMimeTextMatch(myInt).Pattern = "TITLE&gt;(.*?)&lt;"
            myMimeTextMatch(myInt).IgnoreCase = True
            myMimeTextMatch(myInt).Capture = 2
            myMimeTextMatch(myInt).Group = 2
            If myInt <> 0 Then

               ' Assign the Repeats property if the index is not 0.
               myMimeTextMatch(myInt).Repeats = 2
            Else

               ' Assign the RepeatsString property if the index is 0.
               myMimeTextMatch(myInt).RepeatsString = "4"
            End If

            ' Add 'MimeTextMatch' instance to collection.
            myMimeTextMatchCollection1.Add(myMimeTextMatch(myInt))
         Next myInt