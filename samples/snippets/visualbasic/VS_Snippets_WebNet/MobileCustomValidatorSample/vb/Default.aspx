<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    ' If the page validates, go to page 2
    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (Page.IsValid) Then
            ActiveForm = Form2
        End If
    End Sub
    
    ' Validate whether the number is even
    Private Sub ServerValidate(ByVal source As Object, _
        ByVal args As ServerValidateEventArgs)
    
        ' Convert the text to a number
        Dim num As Integer
        Integer.TryParse(numberBox.Text, num)
        ' Test for an even number
        If (num > 0) Then
            args.IsValid = ((num Mod 2) = 0)
        Else
            args.IsValid = False
        End If
    End Sub

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
