    Protected Overrides Sub RenderBody(ByVal writer As _
      HtmlTextWriter)
      writer.WriteLine("<hr />")
      MyBase.RenderBody(writer)
    End Sub