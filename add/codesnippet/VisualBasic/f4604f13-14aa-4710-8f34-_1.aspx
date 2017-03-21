   Sub CopyTo_Clicked(Sender As Object, e As EventArgs)
      labelDisplay.Text = "Invoking CopyTo method.<br />"
      labelDisplay.Text += "The Items collection contains: <br />"
      
      ' Display the elements of the RepeaterItemCollection using the CopyTo method.
      Dim myItemCollection As RepeaterItemCollection = myRepeater.Items
      Dim myItemArray(myItemCollection.Count-1) As RepeaterItem
      myItemCollection.CopyTo(myItemArray, 0)
      Dim index As Integer
      For index = 0 To myItemArray.Length - 1
         Dim myItem As RepeaterItem = CType(myItemArray.GetValue(index), RepeaterItem)
         labelDisplay.Text += CType(myItem.Controls(0), DataBoundLiteralControl).Text + "<br />"
      Next index
   End Sub 'CopyTo_Clicked