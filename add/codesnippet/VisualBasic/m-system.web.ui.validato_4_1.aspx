      ' Get 'Validators' of the page to myCollection.
      Dim myCollection As ValidatorCollection = Page.Validators
      Dim myObjArray() As Object = New Object(4){0, 0, 0, 0, 0}
      ' Copy the 'Collection' to 'Array'. 
      myCollection.CopyTo(myObjArray, 0)
      ' Print the values in the Array.
      Dim myStr As String = " "
      Dim i As Integer
      For i = 0 To myCollection.Count - 1
         myStr += myObjArray(i).ToString()
         myStr += " "
      Next i
      msgLabel.Text = myStr