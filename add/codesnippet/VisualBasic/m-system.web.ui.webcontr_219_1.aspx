   Sub GetEnumerator_Clicked(Sender As [Object], e As EventArgs)
      labelDisplay.Text = "Invoking GetEnumerator method.<br />"
      labelDisplay.Text += "The Items collection contains: <br />"
      
      ' Display the elements of the RepeaterItemCollection using GetEnumerator.
      Dim myItemCollection As RepeaterItemCollection = myRepeater.Items
      Dim myEnumertor As IEnumerator = myItemCollection.GetEnumerator()
      While myEnumertor.MoveNext()
         Dim myItem As RepeaterItem = CType(myEnumertor.Current, RepeaterItem)
         labelDisplay.Text += CType(myItem.Controls(0), DataBoundLiteralControl).Text + "<br />"
      End While
   End Sub 'GetEnumerator_Clicked