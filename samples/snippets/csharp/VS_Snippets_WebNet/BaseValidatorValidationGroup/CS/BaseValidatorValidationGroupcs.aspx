<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>BaseValidator ValidationGroup Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>BaseValidator ValidationGroup Example</h3>
     
      Please enter your name:<br/>
      <asp:textbox id="NameTextBox" 
        runat="server"/>

      <asp:requiredfieldvalidator id="NameTextBoxRequiredValidator" 
        controltovalidate="NameTextBox"
        display="Dynamic" 
        text="Please enter your name."
        validationgroup="UserInfoGroup" 
        runat="server"/>

      <br /><br />

      <asp:button id="SubmitButton"
        text="Submit"
        validationgroup="UserInfoGroup" 
        runat="server"/>
        
      <hr/>
      
      Please enter a search topic:<br/>
      <asp:textbox id="SearchTextBox" 
        runat="server"/>

      <asp:requiredfieldvalidator id="SearchTextBoxRequiredValidator" 
        controltovalidate="SearchTextBox"
        display="Dynamic" 
        text="Please enter a topic."
        validationgroup="SearchGroup"
        runat="server"/>

      <br /><br />

      <asp:button id="SearchButton"
        text="Search"
        validationgroup="SearchGroup"
        runat="server"/>
 
    </form>
  </body>
</html>

<!--</Snippet1>-->
