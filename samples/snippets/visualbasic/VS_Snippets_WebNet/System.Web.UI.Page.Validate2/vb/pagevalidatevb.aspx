<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Select Case CType(sender, Button).ID
      Case "Button1"
        If TextBoxValidator1.IsValid Then
          Label1.Text = "TextBox validates."
        Else
          Label1.Text = ""
          Label4.Text = ""
        End If
      Case "Button2"
        ' Must explicitly cause Validate here because 
        ' Button2 has CausesValidation set to false.
        Validate("Group2")
        If CustomValidator.IsValid Then
          Label2.Text = "CheckBox validates."
        Else
          Label2.Text = ""
          Label4.Text = ""
        End If
      Case Else
        Label1.Text = ""
        Label2.Text = ""
    End Select

  End Sub
  
  Protected Sub CustomValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
     
    args.IsValid = (CheckBox1.Checked)

  End Sub
  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    If (IsPostBack) Then
      
    ' Handle AutoPostBack TextBox.
      Validate("Group3")
      If (Page.IsValid) Then
        Label3.Text = "AutoPostBack TextBox validates."
      Else
        Label3.Text = ""
        Label4.Text = ""
      End If
    End If
    
  End Sub

  Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  
    Validate()
    If (Page.IsValid) Then
      Label4.Text = "All controls valid."
    Else
      Label1.Text = ""
      Label2.Text = ""
      Label3.Text = ""
      Label4.Text = ""
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page Validate</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      TextBox
      <asp:TextBox ID="TextBox1" ValidationGroup="Group1" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator Display="Static" ID="TextBoxValidator1" ValidationGroup="Group1" runat="server" ControlToValidate="TextBox1" ErrorMessage="(please enter some text)" EnableClientScript="False"></asp:RequiredFieldValidator>
      <br />
      CheckBox
      <asp:CheckBox ID="CheckBox1" ValidationGroup="Group2" runat="server" />
      <asp:CustomValidator ID="CustomValidator" ValidationGroup="Group2" runat="server" Text="(this option required)" OnServerValidate="CustomValidator_ServerValidate" EnableClientScript="False"></asp:CustomValidator>
      <br />
      <asp:Button ID="Button1" ValidationGroup="Group1" CausesValidation="true" runat="server" Text="Validate Group1 Controls" OnClick="Button_Click" />
      <asp:Label ID="Label1" runat="server"></asp:Label>
      <br />
      <asp:Button ID="Button2" ValidationGroup="Group2" CausesValidation="false" runat="server" Text="Validate Group2 Controls" OnClick="Button_Click" />
      <asp:Label ID="Label2" runat="server"></asp:Label>
      <br />
      <br />
      AutoPostBack TextBox
      <asp:TextBox AutoPostBack="true" ID="TextBox2" ValidationGroup="Group3" runat="server" CausesValidation="true"></asp:TextBox>
      <asp:RequiredFieldValidator ID="TextBoxValidator2" ValidationGroup="Group3" runat="server" ControlToValidate="TextBox2" ErrorMessage="(please enter some text)" EnableClientScript="False"></asp:RequiredFieldValidator>
      <asp:Label ID="Label3" runat="server"></asp:Label>
      <br />
      <br />
      <asp:Button ID="Button3" CausesValidation="true" runat="server" Text="Validate All Controls" OnClick="Button3_Click" />
      <asp:Label ID="Label4" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
