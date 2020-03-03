<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ import Namespace="Samples.AspNet.CS.Controls"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Page_Load(object sender, EventArgs e)
    {

      // Filter the text to be rendered as all uppercase.
      Response.Filter = new UpperCaseFilterStream(Response.Filter);

      // Convert a virtual path to a fully qualified physical path.
      string fullpath = Request.MapPath("~\\TestFile.txt");

      try
      {
        // Read the contents of the file using a StreamReader.
        using (StreamReader sr = new StreamReader(fullpath))
        while (sr.Peek() >= 0)
        {
          Response.Write((char)sr.Read());
        }
        Message.Text = "Reading the file was successful.";
        
      }
      catch (Exception ex)
      {
        Message.Text = "The process failed.";
      }    
     }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpResponse.MapPath Example</title>
  </head>
  <body>
    <form id="form1" runat="server">

      <asp:Label id="Message" 
                 runat="server"/>

    </form>
  </body>
</html>
<!-- </snippet1> -->