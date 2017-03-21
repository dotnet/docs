            Dim identity As PassportIdentity = Me.Context.User.Identity
            ' Determine whether the user is already signed in with a valid
            ' and current ticket. Passing -1 for the parameter values 
            ' indicates the default values will be used.
            If (identity.GetIsAuthenticated(-1, -1, -1)) Then
                Me.Response.Write("Welcome to the site.<br /><br />")
                ' Print the Passport sign in button on the screen.
                Me.Response.Write(identity.LogoTag2())
                ' Make sure the user has core profile information before
                ' trying to access it.
                If (identity.HasProfile("core")) Then
                    Me.Response.Write("<b>You have been authenticated as " & _ 
                    "Passport identity:" & identity.Name & "</b></p>")
                End If
    
            ' Determine whether the user has a ticket.
            ElseIf identity.HasTicket Then
                ' If the user has a ticket but wasn't authenticated, that 
                ' means the ticket is stale, so the login needs to be refreshed.
                ' Passing true as the fForceLogin parameter value indicates that 
                ' silent refresh will be accepted.
                identity.LoginUser(Nothing, -1, True, Nothing, -1, Nothing, _
                    -1, True, Nothing)