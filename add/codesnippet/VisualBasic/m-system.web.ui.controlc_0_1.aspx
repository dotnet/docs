       ' Create a LiteralControl and use the Add method to add it
       ' to a button's ControlCollection, then use the AddAt method
       ' to add another LiteralControl to the collection at the
       ' index location of 1.
       Dim myLiteralControl As LiteralControl =  _
           new LiteralControl("ChildControl1")
       myButton.Controls.Add(myLiteralControl)
       myButton.Controls.AddAt(1,new LiteralControl("ChildControl2"))
       Response.Write("<b>ChildControl2 is added at index 1</b>")
       
       ' Get the Index location of the myLiteralControl LiteralControl
       ' and write it to the page.
       Response.Write("<br /><b>Index of the ChildControl myLiteralControl is </b>" & _
                        myButton.Controls.IndexOf(myLiteralControl))