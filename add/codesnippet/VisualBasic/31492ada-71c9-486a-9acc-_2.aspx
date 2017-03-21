<%@ Page language="VB" AutoEventWireup="true" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Runtime.InteropServices" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Private Sub Page_Load(sender As Object, e As System.EventArgs)
        Try 
            ' Determine whether Passport is the type of authentication
            ' this page is set to use. (Authentication information
            ' is set in the Web.config file.)
            If Not TypeOf(Me.Context.User.Identity) Is PassportIdentity Then
                ' If this page isn't set to use Passport authentication,
                ' quit now.
                 Me.Response.Write("Error: Passport authentication failed. " & _
                     "Make sure that the Passport SDK is installed and your " & _
                     "Web.config file is configured correctly.")
                Return
            End If

            ' Expire the page to avoid the browser's cache.
            Response.Cache.SetNoStore()
            
            ' Get a version of the Identity value that is cast as type
            ' PassportIdentity. 
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

            ' If the user does not already have a ticket, ask the user
            ' to sign in.
            Else
                Me.Response.Write("Please sign in using the link below.<br /><br />")
                ' Print the Passport sign in button on the screen.
                Me.Response.Write(identity.LogoTag2())
            End If

        Catch comError As System.Runtime.InteropServices.COMException
            Me.Response.Write("An error occured while working with the " & _
                "Passport SDK. The following result was returned: " & _
                comError.ErrorCode)
        End Try
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>ASP.NET Example</title>
</head>

    <body>
        <form id="form1" runat="server">
        </form>
    </body>
</html>