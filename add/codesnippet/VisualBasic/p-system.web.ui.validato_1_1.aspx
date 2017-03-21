      ' Get 'Validators' of the page to myCollection.
      Dim myCollection As ValidatorCollection = Page.Validators
      ' Print the values of Collection using 'Item' property.
      Dim myStr As String = " "
      Dim i As Integer
      For i = 0 To myCollection.Count - 1
         myStr = mystr & CType(myCollection(i),BaseValidator).ToString() & "<br />"
      Next i
      msgLabel.Text = myStr