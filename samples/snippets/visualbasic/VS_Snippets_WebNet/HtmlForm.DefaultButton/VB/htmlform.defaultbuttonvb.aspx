<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="Server">
       
  Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Set the text of the two label controls.
    Label1.Text = "The DefaultButton property is set to " _
                  & Form1.DefaultButton.ToString & "<br/>"
    Label2.Text = "The DefaultFocus property is set to " _
                  & Form1.DefaultFocus.ToString
  End Sub
     
 </script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>

    <title>HtmlForm DefaultButton and DefaultFocus Properties Example</title>

</head>

<body>

  <form id="Form1"
        defaultbutton="SubmitButton"
        defaultfocus="TextBox1"
        runat="server">
    
    <h3>HtmlForm DefaultButton and DefaultFocus Properties Example</h3>        
  
    TextBox1:
    <asp:textbox id="TextBox1"
                 autopostback="true" 
                 runat="server">
    </asp:textbox>
  
    <br />
  
    TextBox2:
    <asp:textbox id="TextBox2"
                 autopostback="true" 
                 runat="server">
    </asp:textbox>
  
    <br /><br />
  
    <asp:button id="SubmitButton"
                text="Submit" 
                runat="server">
    </asp:button>
  
    <asp:button id="CancelButton" 
                text="Cancel"
                runat="server">
    </asp:button>
  
    <hr />
  
    <asp:label id="Label1"
               runat="Server">
    </asp:label>
  
    <asp:label id="Label2"
               runat="Server">
    </asp:label>

  </form>

</body>

</html>
<!--</Snippet1>-->
