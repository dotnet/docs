   Sub Item_Clicked(Sender As [Object], e As EventArgs)
      labelDisplay.Text = "Using item indexer.<br />"
      labelDisplay.Text += "The Items collection contains: <br />"
      
      ' Display the elements of the RepeaterItemCollection using the indexer.
      Dim myItemCollection As RepeaterItemCollection = myRepeater.Items
      Dim index As Integer
      For index = 0 To myItemCollection.Count - 1
         labelDisplay.Text += CType(myItemCollection(index).Controls(0), DataBoundLiteralControl).Text + "<br />"
      Next index
   End Sub 'Item_Clicked
