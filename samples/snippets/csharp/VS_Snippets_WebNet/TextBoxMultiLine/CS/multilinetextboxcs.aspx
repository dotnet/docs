<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> MultiLine TextBox Example </title>
<script runat="server">

      protected void SubmitButton_Click(Object sender, EventArgs e)
      {
         
         Message.Text = "Thank you for your comment: <br />" + Comment.Text;

      }

      protected void Check_Change(Object sender, EventArgs e)
      {
         
         Comment.Wrap = WrapCheckBox.Checked;
         Comment.ReadOnly = ReadOnlyCheckBox.Checked;

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> MultiLine TextBox Example </h3>

      
      Please enter a comment and click the submit button. 

      <br /><br /> 
            
      <asp:TextBox ID="Comment"
           TextMode="MultiLine"
           Columns="50"
           Rows="5"
           runat="server"/>

      <br />

      <asp:RequiredFieldValidator
           ID="Value1RequiredValidator"
           ControlToValidate="Comment"
           ErrorMessage="Please enter a comment.<br />"
           Display="Dynamic"
           runat="server"/>                         

      <asp:CheckBox ID="WrapCheckBox"
           Text="Wrap Text"
           Checked="True"
           AutoPostBack="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>

      &nbsp;&nbsp;

      <asp:CheckBox ID="ReadOnlyCheckBox"
           Text="ReadOnly"
           Checked="False"
           AutoPostBack="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>

      &nbsp;&nbsp;

      <asp:Button ID="SubmitButton"
           Text="Submit"
           OnClick="SubmitButton_Click"
           runat="server"/>

      <hr />

      <asp:Label ID="Message"
           runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->