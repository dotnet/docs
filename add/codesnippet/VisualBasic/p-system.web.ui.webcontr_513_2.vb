  Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

    Label2.Text = _
      "<h3>Calendar GenericWebPart Properties</h3>" & _
      "<em>Title: </em>" & calendarPart.Title & _
      "<br />" & _
      "<em>CatalogIconImageUrl:  </em>" & calendarPart.CatalogIconImageUrl & _
      "<br />" & _
      "<em>TitleUrl: </em>" & calendarPart.TitleUrl & _
      "<br />" & _
      "<em>Decription: </em>" & calendarPart.Description & _
      "<br />" & _
      "<em>TitleIconImageUrl: </em>" & calendarPart.TitleIconImageUrl & _
      "<br />" & _
      "<em>ChildControl ID: </em>" & calendarPart.ChildControl.ID & _
      "<br />" & _
      "<em>ChildControl Type: </em>" & calendarPart.ChildControl.GetType().Name & _
      "<br />" & _
      "<em>GenericWebPart ID: </em>" & calendarPart.ID & _
      "<br />" & _
      "<em>GenericWebPart Type: </em>" & calendarPart.GetType().Name & _
      "<br />" & _
      "<em>GenericWebPart Parent ID: </em>" & calendarPart.Parent.ID

    Label3.Text = _
      "<h3>BulletedList GenericWebPart Properties</h3>" & _
      "<em>Title: </em>" & listPart.Title & _
      "<br />" & _
      "<em>CatalogIconImageUrl:  </em>" & listPart.CatalogIconImageUrl & _
      "<br />" & _
      "<em>TitleUrl: </em>" & listPart.TitleUrl & _
      "<br />" & _
      "<em>Decription: </em>" & listPart.Description & _
      "<br />" & _
      "<em>TitleIconImageUrl: </em>" & listPart.TitleIconImageUrl & _
      "<br />" & _
      "<em>ChildControl ID: </em>" & listPart.ChildControl.ID & _
      "<br />" & _
      "<em>ChildControl Type: </em>" & listPart.ChildControl.GetType().Name & _
      "<br />" & _
      "<em>GenericWebPart ID: </em>" & listPart.ID & _
      "<br />" & _
      "<em>GenericWebPart Type: </em>" & listPart.GetType().Name & _
      "<br />" & _
      "<em>GenericWebPart Parent ID: </em>" & listPart.Parent.ID
  End Sub

End Class
