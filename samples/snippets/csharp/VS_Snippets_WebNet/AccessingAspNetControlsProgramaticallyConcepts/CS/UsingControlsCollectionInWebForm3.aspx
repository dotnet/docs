<!--<Snippet3>-->
<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="head1" runat="server">
    <title>Using the Controls Collection in a Web Form</title>
    
<script language="c#" runat="server">

  private void ChangeBtn_Click(object sender, EventArgs e)
  {
     foreach(Control c in Page.Controls)
     {
       if (c.Controls.Count > 0)
       {
         foreach(Control c2 in c.Controls)
         {
            if (c2.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
            {
                myspan.InnerHtml = ((TextBox)c2).Text;
               ((TextBox)c2).Text = "";
            }
         }
      }
   }
}

</script>

</head>
<body>
  <form id="form1" runat="server">
    <table width="80%"
           border="1" 
           cellpadding="1" 
           cellspacing="1">
      <tr>
        <td align="center" style="width:50%;">
        <asp:TextBox id="MyTextBox" 
                     text="Type something here" 
                     runat="server"/>
        </td>
        <td align="center" style="width:50%;">
        <span id="myspan" runat="server">&nbsp;</span>
        </td>
      </tr>
      
      <tr>
        <td colspan="2" align="center">
        <input id="changebtn"
               type="submit"  
               onserverclick="ChangeBtn_Click" 
               value="move your text"
               runat="server" />
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
<!--</Snippet3>-->