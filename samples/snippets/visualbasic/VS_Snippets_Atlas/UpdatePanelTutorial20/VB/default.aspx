<%-- <Snippet1> --%>

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    '<Snippet2>
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox1.Text = Calendar1.SelectedDate.ToShortDateString()
        Label1.Text = ""
    End Sub
    '</Snippet2>
    '<Snippet3>
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Label1.Text = "Tickets are available as of " & DateTime.Now.ToString() & "."
    End Sub
    '</Snippet3>
    ' <Snippet4>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString()
    End Sub
    ' </Snippet4>

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UpdatePanel with Validators Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <%--<Snippet5> --%>
            <script type="text/javascript">
            function ClearLastMessage(elem)
            {
               $get(elem).innerHTML = '';
            }
            </script>
            <%--</Snippet5> --%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Select a date below or enter a date:
                <asp:TextBox ID="TextBox1" runat="server" Width="70px"></asp:TextBox><br />
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" />
                <br />
                Specify number of tickets (1-10):
                <asp:TextBox ID="TextBox2" runat="server" Width="40px"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" OnClientClick="ClearLastMessage('Label1')" Text="Check Availability" OnClick="Button1_Click" />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="Pick a date in the future." Operator="GreaterThanEqual" Type="Date" Display="None">
                </asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="Date is required." Display="None">
                </asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="Number of tickets out of range." MaximumValue="10"
                    MinimumValue="1" Type="Integer" Display="None">
                </asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                     ErrorMessage="Number of tickets is required." Display="None">
                </asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
<%-- </Snippet1> --%>

