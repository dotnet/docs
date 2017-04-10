<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" id="Script1" runat="server">      

public void submitButton_Click(object sender, System.EventArgs e)
{
// <Snippet1>
// <Snippet2>
// <Snippet3>
   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection1 = Page.Validators;

   // Get 'IsReadOnly' property of 'ValidatorCollection'.
   bool readOnly_bool = myCollection1.IsReadOnly;

   // Get 'IsSynchronized' property of 'ValidatorCollection'.
   bool synchronized_bool = myCollection1.IsSynchronized;

   // Get a synchronized object of the 'ValidatorCollection'.
   ValidatorCollection myCollection2 = (ValidatorCollection)myCollection1.SyncRoot;
   myCollection1.Add(myCollection1[0]);
// </Snippet1>
// </Snippet2>
// </Snippet3>

   messageLabel1.Text = "IsReadOnly property of the ValidatorCollection is: "+ 
                        readOnly_bool.ToString();
   messageLabel2.Text = "IsSynchronized property of the ValidatorCollection is: "+ 
                        synchronized_bool.ToString();
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<!--
// System.Web.UI.ValidatorCollection.IsReadOnly
// System.Web.UI.ValidatorCollection.IsSynchronized
// System.Web.UI.ValidatorCollection.SyncRoot
-->
      <!-- 
     The following program demonstrates the 'IsReadOnly', 
     'IsSynchronized' and 'SyncRoot' properties of the 
     'ValidatorCollection' class in 'System.Web.UI'. The 
     Validators of the page are assigned to the variable of 
     'ValidatorCollection'. The 'IsReadOnly', 'IsSynchronized'
     properties are displayed.
     'SyncRoot' is used to make access to the 'ValidatorCollection' 
     in a thread-safe manner. It returns a synchronized object. The 
     object is cast to a 'ValidatorCollection' class and a item of
     the collection and added back to the 'ValidatorCollection' 
     object.
      
-->
   </head>
   <body>
      <form id="Form1" method="post" runat="server">
      <asp:label id="Label4" style="LEFT: 15px; POSITION: absolute; TOP: 19px" runat="server" 
        Font-Size="Medium" Height="19px" Width="442px" Font-Bold="True">ValidatorCollection Example
      </asp:label>
      <asp:label id="infoLabel" style="LEFT: 15px; POSITION: absolute; TOP: 64px" runat="server" 
        Font-Size="Small" Height="19px" Width="226px">Enter Personal Information</asp:label>
      <asp:label id="Label3" style="LEFT: 265px; POSITION: absolute; TOP: 108px" runat="server" 
        ForeColor="Red">*</asp:label>
      <asp:label id="nameLabel" style="LEFT: 18px; POSITION: absolute; TOP: 109px" runat="server"
        AssociatedControlID="userName">Name</asp:label>
      <asp:textbox id="userName" style="LEFT: 77px; POSITION: absolute; TOP: 112px" runat="server" 
        Height="24px" Width="177px"></asp:textbox>
      <asp:requiredfieldvalidator id="RequiredFieldValidator1" 
        style="LEFT: 291px; POSITION: absolute; TOP: 115px" runat="server" ControlToValidate="userName" 
        ErrorMessage="RequiredFieldValidator"> Required.</asp:requiredfieldvalidator>
      <asp:label id="Label2" style="LEFT: 269px; POSITION: absolute; TOP: 147px" runat="server" 
        ForeColor="Red">*</asp:label>
      <asp:label id="addressLabel" style="LEFT: 19px; POSITION: absolute; TOP: 150px" runat="server"
        AssociatedControlID="addressTextBox">Address</asp:label>
      <asp:textbox id="addressTextBox" style="LEFT: 78px; POSITION: absolute; TOP: 150px" 
        runat="server" TextMode="MultiLine"></asp:textbox>
      <asp:requiredfieldvalidator id="RequiredFieldValidator2" 
        style="LEFT: 290px; POSITION: absolute; TOP: 159px" runat="server" 
        ControlToValidate="addressTextBox" ErrorMessage="RequiredFieldValidator"> Required.
      </asp:requiredfieldvalidator>
      <asp:label id="Label1" style="LEFT: 267px; POSITION: absolute; TOP: 202px" runat="server" 
        ForeColor="Red">*</asp:label>
      <asp:requiredfieldvalidator id="RequiredFieldValidator3" 
        style="LEFT: 290px; POSITION: absolute; TOP: 202px" runat="server" 
        ControlToValidate="ageTextBox" ErrorMessage="RequiredFieldValidator"> Required.
      </asp:requiredfieldvalidator>
      <asp:textbox id="ageTextBox" style="LEFT: 82px; POSITION: absolute; TOP: 203px" 
        runat="server" Height="24px" Width="181px"></asp:textbox>
      <asp:label id="ageLabel" style="LEFT: 25px; POSITION: absolute; TOP: 205px" runat="server"
        AssociatedControlID="ageTextBox">Age</asp:label>
      <asp:rangevalidator id="RangeValidator1" runat="server"
        style="LEFT: 290px; POSITION: absolute; TOP: 222px" Height="19px" Width="148px"
        ControlToValidate="ageTextBox" ErrorMessage="RangeValidator" Type="Integer" MaximumValue="100" 
        MinimumValue="18"> Valid age(18-100).</asp:rangevalidator>
      <asp:button id="submitButton" style="LEFT: 125px; POSITION: absolute; TOP: 252px"
        onclick="submitButton_Click" runat="server" Text="Submit"></asp:button>
      <asp:label id="messageLabel1" style="LEFT: 31px; POSITION: absolute; TOP: 301px" 
        runat="server" Height="19px" Width="526px"></asp:label>
      <asp:label id="messageLabel2" style="LEFT: 31px; POSITION: absolute; TOP: 340px" 
        runat="server" Height="19px" Width="537px"></asp:label>
      </form>
   </body>
</html>
