<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Button.ValidationGroup Example</title>
</head>
<body>
  <form id="form1" runat="server">
  
    <h3>Button.ValidationGroup Example</h3>

    <asp:label id="NameLabel" 
      text="Enter your name:"
      runat="Server"
      AssociatedControlID="NameTextBox">
    </asp:label>

    &nbsp;
    
    <asp:textbox id="NameTextBox" 
      runat="Server">
    </asp:textbox>

    &nbsp;

    <asp:requiredfieldvalidator id="RequiredFieldValidator1"
      controltovalidate="NameTextBox"
      validationgroup="PersonalInfoGroup"
      errormessage="Enter your name."
      runat="Server">
    </asp:requiredfieldvalidator>
    
    <br /><br />
    
    <asp:label id="AgeLabel" 
      text="Enter your age:"
      runat="Server"
      AssociatedControlID="AgeTextbox">
    </asp:label>

    &nbsp;
    
    <asp:textbox id="AgeTextbox" 
      runat="Server">
    </asp:textbox>

    &nbsp;

    <asp:requiredfieldvalidator id="RequiredFieldValidator2"
      controltovalidate="AgeTextBox"
      validationgroup="PersonalInfoGroup"
      errormessage="Enter your age."
      runat="Server">
    </asp:requiredfieldvalidator>
    
    <br /><br />

    <!--When Button1 is clicked, only validation
    controls that are a part of PersonalInfoGroup
    are validated.-->
    <asp:button id="Button1" 
      text="Validate" 
      causesvalidation="true"
      validationgroup="PersonalInfoGroup"
      runat="Server" />
      
    <br /><br />
      
    <asp:label id="CityLabel" 
      text="Enter your city of residence:"
      runat="Server"
       AssociatedControlID="CityTextbox">
    </asp:label>

    &nbsp;
    
    <asp:textbox id="CityTextbox" 
      runat="Server">
    </asp:textbox>

    &nbsp;

    <asp:requiredfieldvalidator id="RequiredFieldValidator3"
      controltovalidate="CityTextBox"
      validationgroup="LocationInfoGroup"
      errormessage="Enter a city name."
      runat="Server">
    </asp:requiredfieldvalidator>
    
    <br /><br />

    <!--When Button2 is clicked, only validation
    controls that are a part of LocationInfoGroup
    are validated.-->
    <asp:button id="Button2" 
      text="Validate" 
      causesvalidation="true"
      validationgroup="LocationInfoGroup"
      runat="Server" />

  </form>
</body>
</html>
<!--</Snippet1>-->
