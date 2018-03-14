<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  
    ' Write the form's UniqueID to the specified Label control.
    Label1.Text = "The HtmlForm control's UniqueID is " _
                  & Form1.UniqueID + "."
  End Sub
    
  Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  
    ' Write the button's UniqueID to the specified Label control.
    Label2.Text = "This Button control's UniqueID is " _
                  & Button2.UniqueID & "."
  End Sub
  
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

    &nbsp    ;
  
    <asp:label id="Label2"
               runat="server">
    </asp:label>
    
  </form>

</body>

</html>
<!--</Snippet1>-->
