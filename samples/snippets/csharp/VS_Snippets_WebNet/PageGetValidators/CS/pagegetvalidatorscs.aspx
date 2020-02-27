<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" id="Script1">
 
void submitButton_Click(object sender, System.EventArgs e)
{
    message.Visible = true;
// <Snippet1>
    // Get 'Validators' of the page to myCollection.
    ValidatorCollection myCollection = Page.GetValidators(null);

    // Get the Enumerator.
    IEnumerator myEnumerator = myCollection.GetEnumerator();
    // Print the values in the ValidatorCollection.
    string myStr = " ";
    while ( myEnumerator.MoveNext() )
    {
        myStr += myEnumerator.Current.ToString();
        myStr += " ";
    }
    messageLabel.Text = myStr;
// </Snippet1>
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<!--
// System.Web.UI.ValidatorCollection.GetEnumerator
-->
      <!-- 
     The following program demonstrates the 'GetEnumerator' method 
     of the 'ValidatorCollection' class in 'System.Web.UI'. The 
     Validators are assigned to a variable of 'ValidatorCollection'
     class. The Validators are retrieved from the Collection using
     the GetEnumerator method.     
-->
</head>
<body>
    <form id="Form1" runat="server">

    <asp:Label id="Label4" Height="19px" Width="337px" 
        Font-Size="Medium" Font-Bold="True" 
        style="LEFT: 8px; POSITION: absolute; TOP: 
        8px" runat="server">ValidatorCollection Example:
    </asp:Label>
    <asp:Label id="infoLabel" runat="server" Width="226px" 
        Height="19px" Font-Size="Small" 
        style="LEFT: 15px; POSITION: absolute; TOP: 52px">
        Enter Personal Information</asp:Label>
    <asp:Label id="Label3" runat="server" ForeColor="Red" 
        style="LEFT: 262px;POSITION: absolute; TOP: 86px">
        *</asp:Label>
    <asp:Label id="nameLabel" runat="server" 
        AssociatedControlID="userName" 
        style="LEFT: 20px;POSITION: absolute; TOP: 87px">
        Name </asp:Label>
    <asp:TextBox id="userName" runat="server" Width="177px" 
        Height="24px" 
        style="LEFT: 79px; POSITION: absolute; TOP: 90px" />
    <asp:RequiredFieldValidator id="RequiredFieldValidator1" 
        runat="server" ControlToValidate="userName" 
        ErrorMessage="RequiredFieldValidator" 
        style="LEFT: 289px; POSITION: absolute; TOP: 93px">
        Required.</asp:RequiredFieldValidator>
    <asp:Label id="Label2" runat="server" ForeColor="Red" 
        style="LEFT: 267px;POSITION: absolute; TOP: 125px">
        *</asp:Label>
    <asp:Label id="addressLabel" runat="server" 
        style="LEFT: 22px; POSITION: absolute; TOP: 128px"
        AssociatedControlID="addressTextBox">Address</asp:Label>
    <asp:TextBox id="addressTextBox" runat="server" 
        TextMode="MultiLine" 
        style="LEFT: 81px; POSITION: absolute; TOP: 128px" />
    <asp:RequiredFieldValidator id="RequiredFieldValidator2" 
        runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate="addressTextBox" 
        style="LEFT: 288px; POSITION: absolute; TOP: 137px"> 
        Required.</asp:RequiredFieldValidator>
    <asp:Label id="Label1" runat="server" ForeColor="Red" 
        style="LEFT: 265px; POSITION: absolute; TOP: 180px">
        *</asp:Label>
    <asp:RequiredFieldValidator id="RequiredFieldValidator3" 
        runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate="AgeTextBox" 
        style="LEFT: 288px; POSITION: absolute; TOP: 180px"> 
        Required.</asp:RequiredFieldValidator>
    <asp:TextBox id="AgeTextBox" runat="server" Width="181px" 
        Height="24px" style="LEFT: 82px; POSITION: absolute; TOP: 181px" />
    <asp:Label id="ageLabel" runat="server" 
        AssociatedControlID="AgeTextBox"
        style="LEFT: 23px; POSITION: absolute; TOP: 183px">
        Age</asp:Label>
    <asp:RangeValidator id="RangeValidator1" runat="server" 
        ErrorMessage="RangeValidator" ControlToValidate="AgeTextBox" 
        MinimumValue="18" MaximumValue="100" Type="Integer" 
        Height="19px" Width="170px" 
        style="LEFT: 288px; POSITION: absolute; TOP: 200px"> 
        Valid age(18-100).</asp:RangeValidator>
    <asp:Button id="submitButton" runat="server" Text="Submit" 
        OnClick="submitButton_Click" 
        style="LEFT: 123px; POSITION: absolute; TOP: 230px" />
    <asp:Label id="message" runat="server" Height="19px" 
        Width="528px" Visible="False" Font-Size="Small" 
        style="LEFT: 47px; POSITION: absolute; TOP: 271px">
        Validators on this page:</asp:Label>
    <asp:Label id="messageLabel" runat="server" Height="86px" 
        Width="548px" 
        style="LEFT: 47px; POSITION: absolute; TOP: 312px" />

    </form>
</body>
</html>
