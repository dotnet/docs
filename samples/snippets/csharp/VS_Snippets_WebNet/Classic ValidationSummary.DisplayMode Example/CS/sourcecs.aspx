<!--<Snippet1>-->

<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      Name:<br/>
      <asp:textbox id="NameTextBox"
        runat="server"/>
        
      <asp:requiredfieldvalidator id="NameTextBoxRequiredValidator"
        controltovalidate="NameTextBox"
        errormessage="Name field."
        text="Please enter your name"
        runat="server"/>     
        
      <br/>  
      
      City:<br/>
      <asp:textbox id="CityTextBox"
        runat="server"/>
        
      <asp:requiredfieldvalidator id="CityTextBoxRequiredValidator"
        controltovalidate="CityTextBox"
        errormessage="City field."
        text="Please enter the city."
        runat="server"/> 
        
      <br/>
      
      <asp:Button id="SubmitButton"
        text="Submit"
        runat="server"/>
      
      <hr/>
      
      <asp:ValidationSummary 
        id="valSum" 
        displaymode="BulletList" 
        headertext="You must enter a value in the following fields:"
        runat="server"/>
    
    </form>
  </body>
</html>
 
<!--</Snippet1>-->
