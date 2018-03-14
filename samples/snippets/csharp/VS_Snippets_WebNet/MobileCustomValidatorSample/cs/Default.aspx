<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    // If the page validates, go to page 2
    protected void Submit_Click(Object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ActiveForm = Form2;
        }
    }
    
    // Validate whether the number is even
    private void ServerValidate(object source, 
        ServerValidateEventArgs args)
    {
        // Convert the text to a number
        int num;
        Int32.TryParse(numberBox.Text, out num);
        // Test for an even number
        if (num > 0)
            args.IsValid = ((num % 2) == 0);
        else
            args.IsValid = false;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="Form1" runat="server">
        <mobile:Label ID="Label1" runat="server">
            Please enter an even number greater than zero.
        </mobile:Label>
        <mobile:TextBox ID="numberBox" Runat="server" 
            Numeric="true" MaxLength="2" />
        <mobile:CustomValidator ID="CustomValidator1" 
            ControlToValidate="numberBox"
            OnServerValidate="ServerValidate" runat="server">
            Your number is not an even number.
        </mobile:CustomValidator>
        <mobile:Command ID="Command1" runat="server" 
            OnClick="Submit_Click">
            Submit
        </mobile:Command>
    </mobile:form>
    <mobile:Form id="Form2" runat="server">
        <mobile:Label ID="Label2" runat="server">
            Your number is an even number.
        </mobile:Label>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
