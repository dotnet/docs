         ' Create the 'InputBinding' object.
         Dim myInputBinding As New InputBinding()
         Dim myMimeTextBinding As New MimeTextBinding()
         Dim myMimeTextMatchCollection As MimeTextMatchCollection
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
         myInputBinding.Extensions.Add(myMimeTextBinding)
         ' Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding

         ' Create the 'OutputBinding' instance.
         Dim myOutputBinding As New OutputBinding()
         ' Create the 'MimeTextBinding' instance.
         Dim myMimeTextBinding1 As New MimeTextBinding()
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