foreach (string s in Session.Contents)
  Response.Write(s + " = " + Session[s].ToString() + "<br />");