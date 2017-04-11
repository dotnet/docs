<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"  >
  <script language="C#" runat="server">

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
      if (Basketball.Checked)
      {
        // You like basketball
      }
      
      if (Football.Checked)
      {
        // You like football
      }
      
      if (Soccer.Checked)
      {
        // You like soccer
      }
    
    }
</script>
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
       <form id="Form1" method="post" runat="server">
         Enter Interests:  
         <input id="Basketball" checked="checked" type="checkbox" runat="server" /> Basketball
         <input id="Football" type="checkbox" runat="server" /> Football
         <input id="Soccer" type="checkbox" runat="server" /> Soccer
                 
         <input id="Button1" type="button" value="Enter" onserverclick="SubmitBtn_Click" runat="server" />
        </form>
    </body>
 </html>
   
<!--</Snippet1>-->
