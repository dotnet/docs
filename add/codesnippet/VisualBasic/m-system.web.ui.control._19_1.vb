      ' Override the OnLoad method to check if the 
      ' page that uses this control has posted back.
      ' If so, check whether this controls contains
      ' only literal content, and if it does,
      ' it gets the UniqueID property and writes it
      ' to the page. Otherwise, it writes a message
      ' that the control contains more than literal content.
      Overrides Protected Sub OnLoad(ByVal e As EventArgs)

         If Page.IsPostBack = True Then
            Dim s As String

            If Me.IsLiteralContent() = True Then
               s = Controls(0).UniqueID
               Context.Response.Write(s)
            Else
               Context.Response.Write( _
               "The control contains more than literal content.")
            End If
         End If
      End Sub