<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="Server">
 
  void Button1_Click(object sender, System.EventArgs e)
  {
    
    // Write the form's UniqueID to the specified Label control.
    Label1.Text = "The HtmlForm control's UniqueID is "
                  + Form1.UniqueID + ".";
  }

  void Button2_Click(object sender, System.EventArgs e)
  {
    
    // Write the button's UniqueID to the specified Label control.
    Label2.Text = "This Button control's UniqueID is "
                 + Button2.UniqueID + ".";
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>

    <title>HtmlForm UniqueID Property Example</title>

</head>

<body>

    <form id="Form1"
          runat="server">
    
    <h3>HtmlForm UniqueID Property Example</h3>        
  
    <asp:button id="Button1"
                text="Get the form's UniqueID" 
                onclick="Button1_Click"
                runat="server">
    </asp:button>
    
    <asp:label id="Label1"
               runat="Server">
    </asp:label>
    
    <br />
    
    <asp:button id="Button2" 
                text="Get this button's UniqueID"
                onclick="Button2_Click"
                runat="server">
    </asp:button>

    &nbsp;
  
    <asp:label id="Label2"
               runat="server">
    </asp:label>
    
  </form>

</body>

</html>
<!--</Snippet1>-->
