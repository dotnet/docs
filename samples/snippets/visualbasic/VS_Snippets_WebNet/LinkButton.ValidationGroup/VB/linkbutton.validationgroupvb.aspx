<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>LinkButton.ValidationGroup Example</title>
</head>
<body>
  <form id="form1" runat="server">
  
    <h3>LinkButton.ValidationGroup Example</h3>

    <asp:label id="NameLabel" 
      text="Enter your name:"
      runat="Server"
      AssociatedControlID="NameTextBox">
    </asp:label>

    &nbsp
    
    <asp:textbox id="NameTextBox" 
      runat="Server">
    </asp:textbox>

    &nbsp

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
      AssociatedControlID="AgeTextBox">
    </asp:label>

    &nbsp
    
    <asp:textbox id="AgeTextBox" 
      runat="Server">
    </asp:textbox>

    &nbsp

    <asp:requiredfieldvalidator id="RequiredFieldValidator2"
      controltovalidate="AgeTextBox"
      validationgroup="PersonalInfoGroup"
      errormessage="Enter your age."
      runat="Server">
    </asp:requiredfieldvalidator>
    
    <br /><br />

    <!--When LinkButton1 is clicked, only validation
    controls that are a part of PersonalInfoGroup
    are validated.-->
    <asp:linkbutton id="LinkButton1" 
      text="Validate" 
      causesvalidation="true"
      validationgroup="PersonalInfoGroup"
      runat="Server">
    </asp:linkbutton>
      
    <br /><br />
      
    <asp:label id="CityLabel" 
      text="Enter your city of residence:"
      runat="Server"
      AssociatedControlID="CityTextBox">
    </asp:label>

    &nbsp
    
    <asp:textbox id="CityTextBox" 
      runat="Server">
    </asp:textbox>

    &nbsp

    <asp:requiredfieldvalidator id="RequiredFieldValidator3"
      controltovalidate="CityTextBox"
      validationgroup="LocationInfoGroup"
      errormessage="Enter a city name."
      runat="Server">
    </asp:requiredfieldvalidator>
    
    <br /><br />

    <!--When LinkButton2 is clicked, only validation
    controls that are a part of LocationInfoGroup
    are validated.-->
    <asp:linkbutton id="LinkButton2" 
      text="Validate" 
      causesvalidation="true"
      validationgroup="LocationInfoGroup"
      runat="Server">
    </asp:linkbutton>

  </form>
</body>
</html>
<!--</Snippet1>-->
