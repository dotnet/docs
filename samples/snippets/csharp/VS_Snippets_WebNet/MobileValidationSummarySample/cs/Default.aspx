<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    private void Page_Load(Object sender, EventArgs e)
    {
        // Define validation expressions.
        UserNameExprValidator.ValidationExpression = 
            "^[a-zA-Z](.{1,9})$";
        PhoneExprValidator.ValidationExpression =
            "((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}";
        UserNameReqValidator.Text = "User name required";
        UserNameExprValidator.Text = 
            "Must be 2-10 characters";
        PhoneExprValidator.Text = 
            "Requires a valid number: 425-555-0187";
        // ErrorMessages appear in ValidationSummary.
        UserNameExprValidator.ErrorMessage = 
            "User name must be 2-10 characters";
        UserNameReqValidator.ErrorMessage = 
            "User name required";
        PhoneExprValidator.ErrorMessage = 
            "Valid number required: 425-555-0187";
    }

    //<Snippet2>
    private void OnCmdClick(Object sender, EventArgs e)
    {
        if (Page.IsValid)
            ActiveForm = Form2;
        else
        {
            ValSummary.BackLabel = "Return to Form";
            ActiveForm = Form3;
        }
    }
    //</Snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1">
        <mobile:Label runat="server" id="HeadingLabel" 
            Text="Provide your name and number" 
            StyleReference="title" />
        <mobile:Label runat="server" id="UserNameLabel" 
            Text="User Name (req'd)" />
        <mobile:Textbox  runat="server" id="UserNameTextBox"/>
        <mobile:RequiredFieldValidator runat="server" 
            id="UserNameReqValidator" 
            ControlToValidate="UserNameTextBox" />
        <mobile:RegularExpressionValidator runat="server" 
            id="UserNameExprValidator" 
            ControlToValidate="UserNameTextBox" />
        <mobile:Label runat="server" id="PhoneLabel" 
            Text="Phone" />
        <mobile:Textbox  runat="server" id="PhoneTextBox"/>
        <mobile:RegularExpressionValidator runat="server" 
            id="PhoneExprValidator" 
            ControlToValidate="PhoneTextBox" />
        <mobile:Command runat="server" id="Cmd1" 
            text="Submit" OnClick="OnCmdClick"/>
    </mobile:Form>
    <mobile:Form runat="server" id="Form2" >
        <mobile:Label ID="Label1" runat="server" 
            Text="Thank You." />
    </mobile:Form>
    <mobile:Form ID="Form3" Runat="server">
        <mobile:ValidationSummary ID="ValSummary" 
            FormToValidate="Form1" 
            HeaderText="Error Summary:" 
            runat="server" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
