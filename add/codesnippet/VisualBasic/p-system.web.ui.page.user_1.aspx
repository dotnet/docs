Sub UserInfo(sender As Object, e As EventArgs)         
   Dim myPrincipal As IPrincipal = Me.User
   Dim tableString As  String 
        tableString = "<table border=""1""><tr><td>Name</td><td>"
   tableString &= Server.HtmlEncode(myPrincipal.Identity.Name) + "</td></tr><tr><td>"
   tableString &= "AuthenticationType</td><td>" + myPrincipal.Identity.AuthenticationType
   tableString &= "</td></tr><tr><td>IsAuthenticated</td><td>"
   tableString &= myPrincipal.Identity.IsAuthenticated.ToString() + "</td></tr></table>"
   Response.Write(tableString)
End Sub