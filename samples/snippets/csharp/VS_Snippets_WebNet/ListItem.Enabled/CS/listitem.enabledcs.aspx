<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ListItem.Enabled Property Example</title>
<script runat="server">         
  
    protected void  Index_Changed(object sender, EventArgs e)
    {

        // if the user is not a developer, do not
        // ask the user to select a programming language.
        if (RadioButtonList1.SelectedIndex == 2)
        {   
            // Clear any previously selected list 
            // items in the second question.
            RadioButtonList2.SelectedIndex = -1;

            // Disable all the list items in the second question.
            for (int i = 0; i < RadioButtonList2.Items.Count; i++)
            {
                RadioButtonList2.Items[i].Enabled = false;
            }
        }          
        else
        // Enable all the list items in the second question.
            for (int i = 0; i < RadioButtonList2.Items.Count; i++)
        {
            RadioButtonList2.Items[i].Enabled = true;
        }
    }
</script>
  </head>

  <body>
    <form id="form1" runat="server">
        
      <h3>ListItem.Enabled Property Example</h3>
      
      Select your occupation:
      <asp:radiobuttonlist id="RadioButtonList1"
        autopostback="true"
        onselectedindexchanged="Index_Changed" 
    runat="server">             
      <asp:ListItem>Web developer</asp:ListItem>
      <asp:ListItem>Windows developer</asp:ListItem>
      <asp:ListItem>Occupation other than developer</asp:ListItem>
        </asp:radiobuttonlist>
          
    <br /><br />
          
    Select your primary programming language:
        <asp:radiobuttonlist id="RadioButtonList2" 
      runat="server">             
       <asp:ListItem>Visual Basic .NET</asp:ListItem>
       <asp:ListItem>C#</asp:ListItem>
       <asp:ListItem>C++</asp:ListItem>
       <asp:ListItem>Other</asp:ListItem>
    </asp:radiobuttonlist> 
                  
    </form>      
  </body>
</html>
<!--</Snippet1>-->
