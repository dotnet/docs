<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Public Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        If Not IsPostBack Then
            RangeVal.ControlToValidate = "TextBox1"
            RangeVal.Type = ValidationDataType.Integer
            RangeVal.MaximumValue = "23"
            RangeVal.MinimumValue = "1"
        End If
    End Sub
    
    Protected Sub Submit_Click(ByVal sender As Object, _
        ByVal e As EventArgs)
        If Page.IsValid Then
            ActiveForm = Form2
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server">
        <mobile:Label ID="Label1" runat="server">
            Please enter an integer from 1 through 23
        </mobile:Label>
        <mobile:TextBox id="TextBox1" runat="server" Numeric="True"/>
        <mobile:RangeValidator id="RangeVal" runat="server">
            Invalid number
        </mobile:RangeValidator>
        <mobile:RequiredFieldValidator id="RequiredVal" 
            ControlToValidate="TextBox1" runat="server">
            A number is required
        </mobile:RequiredFieldValidator>
        <mobile:Command ID="Command1" runat="server" 
            OnClick="Submit_Click">Submit</mobile:Command>
    </mobile:Form>
    <mobile:Form id="Form2" runat="server">
        <mobile:Label ID="Label2" runat="server">
        Number is successfully submitted</mobile:Label>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
