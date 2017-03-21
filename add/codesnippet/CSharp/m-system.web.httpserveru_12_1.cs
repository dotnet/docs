StringWriter writer = new StringWriter();
Server.Execute("Login.aspx", writer);
Response.Write("<H3>Please Login:</H3><br>"+ writer.ToString());
   