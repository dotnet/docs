      ' Get 'Validators' of the page to myCollection.
      Dim myCollection As ValidatorCollection = Page.Validators
      ' Get the Enumerator.
      Dim myEnumerator As IEnumerator = myCollection.GetEnumerator()
      ' Print the values in the ValidatorCollection.
      Dim myStr As String = " "
      While myEnumerator.MoveNext()
         myStr += myEnumerator.Current.ToString()
         myStr += " "
      End While
      messageLabel.Text = myStr