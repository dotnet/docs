<%@ Page language="c#"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server" id="Script1">

void submitButton_Click(object sender, System.EventArgs e)
{
// <Snippet1>
// <Snippet2>      
   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection = Page.Validators;
   // Show the number of validators of the page.
   int count = myCollection.Count;
// </Snippet1>                  
// </Snippet2>         
   messageLabel1.Text="Number of Validators on this page: "+ count.ToString();
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<!--
// System.Web.UI.ValidatorCollection.ValidatorCollection
// System.Web.UI.ValidatorCollection.Count
-->
      <!-- 
     The following program demonstrates the constructor and the 
     'Count' property of the 'ValidatorCollection' class of 
     'System.Web.UI'. Validators are assigned for the controls on 
     the page. On submit of the form, the constructor is created and
     the Validators of the page are assigned to a variable of 
     'ValidatorCollection' class. The number of Validation Controls
     are displyed with the 'Count' property.
-->
   </head>
   <body>
      <form id="Form1" method="post" runat="server">
      <asp:Label id="Label4" runat="server" Height="19px" Width="390px" Font-Size="Medium" 
        Font-Bold="True" style="LEFT: 8px; POSITION: absolute; TOP: 8px">
        ValidatorCollection Example</asp:Label>
      <asp:Label id="infoLabel" runat="server" Width="248px" Height="20px" Font-Size="Small" 
        style="LEFT: 2px; POSITION: absolute; TOP: 54px"> Enter Personal Information</asp:Label>
      <asp:Label id="nameLabel" runat="server" Height="19px" Width="38px" 
        style="LEFT: 20px; POSITION: absolute; TOP: 94px" AssociatedControlID="userName">
        Name </asp:Label>
      <asp:TextBox id="userName" runat="server" Width="178px" Height="26px" 
        style="LEFT: 79px; POSITION: absolute; TOP: 97px"></asp:TextBox>
      <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="userName" 
        Height="19px" Width="60px" style="LEFT: 291px; POSITION: absolute; TOP: 100px">
        Required.</asp:RequiredFieldValidator>
      <asp:Label id="Label3" runat="server" ForeColor="Red" Height="19px" Width="9px" 
        style="LEFT: 264px; POSITION: absolute; TOP: 105px">*</asp:Label>
      <asp:Label id="addressLabel" runat="server" Height="19px" Width="52px" 
        style="LEFT: 23px; POSITION: absolute; TOP: 135px" AssociatedControlID="addressTextBox">
        Address</asp:Label>
      <asp:TextBox id="addressTextBox" runat="server" TextMode="MultiLine" Height="40px" 
        Width="183px" style="LEFT: 81px; POSITION: absolute; TOP: 135px"></asp:TextBox>
      <asp:Label id="Label2" runat="server" ForeColor="Red" Height="19px" Width="9px" 
        style="LEFT: 269px; POSITION: absolute; TOP: 144px">*</asp:Label>
      <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="addressTextBox" 
        Height="19px" Width="60px" style="LEFT: 290px; POSITION: absolute; TOP: 144px">
        Required.</asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="ageTextBox" 
        Height="19px" Width="60px" style="LEFT: 290px; POSITION: absolute; TOP: 187px">
        Required.</asp:RequiredFieldValidator>
      <asp:TextBox id="ageTextBox" runat="server" Width="182px" Height="26px" 
        style="LEFT: 82px; POSITION: absolute; TOP: 188px"></asp:TextBox>
      <asp:Label id="ageLabel" runat="server" Height="19px" Width="34px" 
        style="LEFT: 25px; POSITION: absolute; TOP: 190px"  AssociatedControlID="ageTextBox">
        Age</asp:Label>
      <asp:Label id="Label1" runat="server" ForeColor="Red" Height="19px" Width="9px" 
        style="LEFT: 267px; POSITION: absolute; TOP: 199px">*</asp:Label>
      <asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="RangeValidator" 
        ControlToValidate="ageTextBox" MinimumValue="18" MaximumValue="100" 
        Type="Integer" Height="19px" Width="146px" 
        style="LEFT: 290px; POSITION: absolute; TOP: 207px"> Valid age(18-100).</asp:RangeValidator>
      <asp:Button id="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" 
        style="LEFT: 125px; POSITION: absolute; TOP: 237px"></asp:Button>
      <asp:Label id="messageLabel1" runat="server" Height="19px" Width="425px" 
        style="LEFT: 28px; POSITION: absolute; TOP: 289px"></asp:Label>
      </form>
   </body>
</html>
