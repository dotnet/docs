   void UserInfo(Object sender, EventArgs e) 
   {
      IPrincipal myPrincipal = this.User;
      String tableString = "<table border=\"1\"><tr><td>Name</td><td>";
      tableString += Server.HtmlEncode(myPrincipal.Identity.Name) + "</td></tr><tr><td>";
      tableString += "AuthenticationType</td><td>" + myPrincipal.Identity.AuthenticationType;
      tableString += "</td></tr><tr><td>IsAuthenticated</td><td>";
      tableString += myPrincipal.Identity.IsAuthenticated + "</td></tr></table>";
      Response.Write(tableString);
   }