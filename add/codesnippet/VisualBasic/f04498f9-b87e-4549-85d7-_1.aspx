        Sub DisplayUserName(Sender As Object, e As EventArgs) 
           Response.Write("Welcome to " + Server.HtmlEncode(userName.Text))
        End Sub

       Sub MyRaiseEvent(Sender As Object, e As EventArgs)
           'Raises a post back event for a control.
            Me.RaisePostBackEvent(userButton, "")
       End Sub 
        
        Sub Page_Load(Sender As Object, e As EventArgs)
    
          'Registers a control as one that requires postback handling
          Me.RegisterRequiresRaiseEvent(userButton)
      End Sub