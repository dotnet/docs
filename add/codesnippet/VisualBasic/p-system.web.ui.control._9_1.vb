      Protected Overrides Sub Render(output As HtmlTextWriter)
         output.Write("Welcome to Control Development!<br>")
         
         ' Test if the page is loaded for the first time
         If Not Page.IsPostBack Then
            output.Write("Page has just been loaded")
         Else
            output.Write("Postback has occured")
         End If
      End Sub 