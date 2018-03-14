<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubmitButton.Click
 
    If Page.IsValid Then
    
      MessageLabel.Text = "Page submitted successfully."
    
    Else
    
      MessageLabel.Text = "There is an error on the page."
    
    End If
    
  End Sub
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Validator Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>Validator Example</h3>
     
      Enter a number from 1 to 10.
      <asp:textbox id="NumberTextBox" 
        runat="server"/>

      <asp:rangevalidator id="NumberCompareValidator" 
        controltovalidate="NumberTextBox"
        enableclientscript="False"  
        type="Integer"
        display="Dynamic" 
        errormessage="Please enter a value from 1 to 10."
        maximumvalue="10"
        minimumvalue="1"  
        text="*"
        runat="server"/>

      <asp:requiredfieldvalidator id="TextBoxRequiredValidator" 
        controltovalidate="NumberTextBox"
        enableclientscript="False"
        display="Dynamic" 
        errormessage="Please enter a value."
        text="*"
        runat="server"/>

      <br /><br />

      <asp:button id="SubmitButton"
        text="Submit"
        runat="server"/>
 
      <br /><br />
       
      <asp:label id="MessageLabel" 
        runat="server"/>

      <br /><br />

      <asp:validationsummary
        id="ErrorSummary"
        runat="server"/>
 
    </form>
  </body>
</html>

<!--</Snippet1>-->
