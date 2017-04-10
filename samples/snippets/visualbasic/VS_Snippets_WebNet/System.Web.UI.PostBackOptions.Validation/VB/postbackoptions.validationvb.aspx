<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
  
    Dim myPostBackOptions As PostBackOptions = New PostBackOptions(FruitRadioButtonList)

    myPostBackOptions.RequiresJavaScriptProtocol = True
    myPostBackOptions.PerformValidation = True
    myPostBackOptions.ValidationGroup = "PersonalInfoGroup"

    Dim reference As String = Page.ClientScript.GetPostBackEventReference(myPostBackOptions)
    FruitRadioButtonList.Attributes.Add("onclick", reference)
    
  End Sub


</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PerformValidation and ValidationGroup Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <h3>PostBackOptions PerformValidation and ValidationGroup Example</h3>
      
      <asp:label id="NameLabel" 
        text="Enter your name:"
        runat="server"
        AssociatedControlID="NameTextBox">
      </asp:label>

      &nbsp
      
      <asp:textbox id="NameTextBox" 
        runat="server">
      </asp:textbox>

      &nbsp

      <asp:requiredfieldvalidator id="RequiredFieldValidator1"
        controltovalidate="NameTextBox"
        validationgroup="PersonalInfoGroup"
        errormessage="Enter your name."
        runat="server">
      </asp:requiredfieldvalidator>
      
      <br /><br />
      
      <asp:label id="AgeLabel" 
        text="Enter your age:"
        runat="server"
        AssociatedControlID="AgeTextBox">
      </asp:label>

      &nbsp
      
      <asp:textbox id="AgeTextBox" 
        runat="server">
      </asp:textbox>

      &nbsp

      <asp:requiredfieldvalidator id="RequiredFieldValidator2"
        controltovalidate="AgeTextBox"
        validationgroup="PersonalInfoGroup"
        errormessage="Enter your age."
        runat="server">
      </asp:requiredfieldvalidator>
      
      <br /><br />
      
      <asp:label id="State" 
        text="Enter the state where you live:"
        runat="server"
        AssociatedControlID="State">
      </asp:label>

      &nbsp
      
      <asp:textbox id="StateTextBox" 
        runat="server">
      </asp:textbox>

      &nbsp
      
      <br /><br />
    
    
      <asp:Label id="FruitLabel" 
        text="Please select your preferred fruit:" 
        runat="server"
        AssociatedControlID="FruitRadioButtonList">
      </asp:Label>
      
      <asp:RadioButtonList ID="FruitRadioButtonList" runat="server" >
        <asp:ListItem>Apples</asp:ListItem>
        <asp:ListItem>Oranges</asp:ListItem>
        <asp:ListItem>Pears</asp:ListItem>
        <asp:ListItem>Peaches</asp:ListItem>
        <asp:ListItem>Grapes</asp:ListItem>
        <asp:ListItem>Lemons</asp:ListItem>
        <asp:ListItem>Limes</asp:ListItem>
        <asp:ListItem>Plums</asp:ListItem>
      </asp:RadioButtonList>
      
    </form>
  </body>
</html>
<!-- </snippet1> -->
