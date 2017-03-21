         ' Get an instance of 'MimeTextMatchCollection'.
         Dim myMimeTextMatchCollection1 As New MimeTextMatchCollection()
         Dim myMimeTextMatch1(4) As MimeTextMatch
         myMimeTextMatchCollection1 = myMimeTextBinding1.Matches
         For myInt = 0 To 3
            myMimeTextMatch1(myInt) = New MimeTextMatch()
            myMimeTextMatch1(myInt).Name = "Title" + Convert.ToString(myInt)
            If myInt <> 0 Then
               myMimeTextMatch1(myInt).RepeatsString = "7"
            End If
            myMimeTextMatchCollection1.Add(myMimeTextMatch1(myInt))
         Next myInt
         myMimeTextMatch1(4) = New MimeTextMatch()
         ' Remove 'MimeTextMatch' instance from collection.
         myMimeTextMatchCollection1.Remove(myMimeTextMatch1(1))
         ' Using MimeTextMatchCollection.Item indexer to comapre. 
         If myMimeTextMatch1(2) Is myMimeTextMatchCollection1(1) Then
            ' Check whether 'MimeTextMatch' instance exists. 
            myInt = myMimeTextMatchCollection1.IndexOf(myMimeTextMatch1(2))
            ' Insert 'MimeTextMatch' instance at a desired position.
            myMimeTextMatchCollection1.Insert(1, myMimeTextMatch1(myInt))
            myMimeTextMatchCollection1(1).RepeatsString = "5"
            myMimeTextMatchCollection1.Insert(4, myMimeTextMatch1(myInt))
         End If