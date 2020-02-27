<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" id="Script1" runat="server">     

void submitButton_Click(object sender, System.EventArgs e)
{
   message.Visible = true;
// <Snippet1>
   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection = Page.Validators;

   // Print the values of Collection using 'Item' property.
   string myStr = " ";         
   for(int i = 0; i<myCollection.Count; i++)
   {
      myStr += myCollection[i].ToString();
      myStr += " ";
   }
   msgLabel.Text = myStr;        
// </Snippet1>
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<!--
// System.Web.UI.ValidatorCollection.Item
-->
      <!-- 
     The following program demonstrates the 'Item' property of
     the 'ValidatorCollection' class of 'System.Web.UI'. The 
     Validators are assigned to a variable of 'ValidatorCollection'
     class. The Validators are displayed using the 'Item' property.     
-->
   </head>
   <body>
      <form id="Form1" method="post" runat="server">
      <asp:Label id="myLabel1" runat="server" Width="456px" Height="20px" Font-Size="Medium" 
        Font-Bold="True" style="LEFT: 11px; POSITION: absolute; TOP: 15px">
        ValidatorCollection Example </asp:Label>
      <asp:label id="infoLabel" runat="server" Font-Size="Small" Height="19px" Width="226px" 
        style="LEFT: 22px; POSITION: absolute; TOP: 50px">Enter Personal Information </asp:label>
      <asp:label id="Label3" runat="server" ForeColor="Red" style="LEFT: 262px; 
        POSITION: absolute; TOP: 86px">*</asp:label>
      <asp:label id="nameLabel" runat="server" style="LEFT: 20px; POSITION: absolute; TOP: 87px"
        AssociatedControlID="userName">Name </asp:label>
      <asp:textbox id="userName" runat="server" Height="24px" Width="177px" 
        style="LEFT: 79px; POSITION: absolute; TOP: 90px"></asp:textbox>
      <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" 
        ControlToValidate="userName" ErrorMessage="RequiredFieldValidator" 
        style="LEFT: 289px; POSITION: absolute; TOP: 93px"> Required.</asp:requiredfieldvalidator>
      <asp:label id="Label2" runat="server" ForeColor="Red" 
        style="LEFT: 267px; POSITION: absolute; TOP: 125px">*</asp:label>
      <asp:label id="addressLabel" runat="server" 
        style="LEFT: 22px; POSITION: absolute; TOP: 128px" AssociatedControlID="addressTextBox">
        Address</asp:label>
      <asp:textbox id="addressTextBox" runat="server" TextMode="MultiLine" 
        style="LEFT: 81px; POSITION: absolute; TOP: 128px"></asp:textbox>
      <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" 
        ControlToValidate="addressTextBox" ErrorMessage="RequiredFieldValidator" 
        style="LEFT: 288px; POSITION: absolute; TOP: 137px"> Required.</asp:requiredfieldvalidator>
      <asp:label id="Label1" runat="server" ForeColor="Red" 
        style="LEFT: 265px; POSITION: absolute; TOP: 180px">*</asp:label>
      <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" 
        ControlToValidate="ageTextBox" ErrorMessage="RequiredFieldValidator" 
        style="LEFT: 288px; POSITION: absolute; TOP: 180px"> Required.</asp:requiredfieldvalidator>
      <asp:textbox id="ageTextBox" runat="server" Height="24px" Width="181px" 
        style="LEFT: 82px; POSITION: absolute; TOP: 181px"></asp:textbox>
      <asp:label id="ageLabel" runat="server" style="LEFT: 23px; POSITION: absolute; TOP: 183px"
        AssociatedControlID="ageTextBox">Age</asp:label>
      <asp:rangevalidator id="RangeValidator1" runat="server" Height="19px" Width="181px" 
        ControlToValidate="ageTextBox" ErrorMessage="RangeValidator" Type="Integer" 
        MaximumValue="100" MinimumValue="18" style="LEFT: 288px; POSITION: absolute; TOP: 200px"> 
        Valid age(18-100).</asp:rangevalidator>
      <asp:button id="submitButton" onclick="submitButton_Click" runat="server" Text="Submit" 
        style="LEFT: 123px; POSITION: absolute; TOP: 230px"></asp:button>
      <asp:Label id="message" runat="server" Width="508px" Height="19px" Visible="False" 
        style="LEFT: 38px; POSITION: absolute; TOP: 276px">Validators on this page:</asp:Label>
      <asp:Label id="msgLabel" runat="server" Width="520px" Height="83px" 
        style="LEFT: 48px; POSITION: absolute; TOP: 315px"></asp:Label>
      </form>
   </body>
</html>
