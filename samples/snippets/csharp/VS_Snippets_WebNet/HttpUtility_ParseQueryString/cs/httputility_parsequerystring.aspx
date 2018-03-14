<!-- <Snippet1> -->
<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    String currurl = HttpContext.Current.Request.RawUrl;
    String querystring = null ;

    // Check to make sure some query string variables
    // exist and if not add some and redirect.
    int iqs = currurl.IndexOf('?');
    if (iqs == -1)
    {
      String redirecturl = currurl + "?var1=1&var2=2+2%2f3&var1=3";
      Response.Redirect(redirecturl, true); 
    }
    // If query string variables exist, put them in
    // a string.
    else if (iqs >= 0)
    {
      querystring = (iqs < currurl.Length - 1) ? currurl.Substring(iqs + 1) : String.Empty;
    }
   
    // Parse the query string variables into a NameValueCollection.
    NameValueCollection qscoll = HttpUtility.ParseQueryString(querystring);
    
    // Iterate through the collection.
    StringBuilder sb = new StringBuilder("<br />");
    foreach (String s in qscoll.AllKeys)
    {
      sb.Append(s + " - " + qscoll[s] + "<br />");
    }
    
    // Write the result to a label.
    ParseOutput.Text = sb.ToString();

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpUtility ParseQueryString Example</title>
</head>
<body>
    <form id="form1" runat="server">
      Query string variables are:
      <asp:Label  id="ParseOutput"
                  runat="server" />
    </form>
</body>
</html>
<!-- </Snippet1> -->
