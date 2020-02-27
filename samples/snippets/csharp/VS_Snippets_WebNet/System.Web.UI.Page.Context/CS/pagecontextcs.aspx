<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
// <Snippet1>  
// <Snippet2>
      void Page_Load(Object sender,EventArgs e) 
      {
         Response.Write("<h3>Page.Context Example:</h3>");

         // Add three custom exceptions.
         Context.AddError(new Exception(
             "<h3 style='color: red'>New Exception #1.</h3>"));
         Context.AddError(new Exception(
             "<h3 style='color: red'>New Exception #2.</h3>"));
         Context.AddError(new Exception(
             "<h3 style='color: red'>New Exception #3.</h3>"));
 
         // Capture all the new Exceptions in an array.
         Exception[] errs = Context.AllErrors;
 
         foreach (Exception ex in errs)
         {
            Response.Write("<p style='text-align:center; ");
            Response.Write("font-weight:bold'>");
            Response.Write(Server.HtmlEncode(ex.ToString()) + "</p>"); 
         }
 
         // Clear the exceptions so ASP.NET won't handle them.
         Context.ClearError();
      }
// </Snippet2>  
// </Snippet1> 
 
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Page.Context Example:</title>
</head>
<body>
</body>
</html>
