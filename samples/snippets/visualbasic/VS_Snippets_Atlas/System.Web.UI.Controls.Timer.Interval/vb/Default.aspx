<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Timer Example Page</title>
    <script runat="server">
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            OriginalTime.Text = DateTime.Now.ToLongTimeString()
        End Sub

        Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            StockPrice.Text = GetStockPrice()
            TimeOfPrice.Text = DateTime.Now.ToLongTimeString()
        End Sub

        Private Function GetStockPrice() As String
            Dim randomStockPrice As Double = 50 + New Random().NextDouble()
            Return randomStockPrice.ToString("C")
        End Function
            
        Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Timer1.Interval = 10000
            Timer1.Enabled = True
        End Sub

        Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Timer1.Interval = 60000
            Timer1.Enabled = True
        End Sub

        Protected Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Timer1.Enabled = False
        End Sub
</script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="10000" />
      
        <asp:UpdatePanel ID="StockPricePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
            Stock price is <asp:Label id="StockPrice" runat="server"></asp:Label><BR />
            as of <asp:Label id="TimeOfPrice" runat="server"></asp:Label>  
        </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <asp:RadioButton ID="RadioButton1" AutoPostBack="true" GroupName="TimerFrequency" runat="server" Text="10 seconds" OnCheckedChanged="RadioButton1_CheckedChanged" /><br />
            <asp:RadioButton ID="RadioButton2" AutoPostBack="true" GroupName="TimerFrequency" runat="server" Text="60 seconds" OnCheckedChanged="RadioButton2_CheckedChanged" /><br />
            <asp:RadioButton ID="RadioButton3" AutoPostBack="true" GroupName="TimerFrequency" runat="server" Text="Never" OnCheckedChanged="RadioButton3_CheckedChanged" /><br />
            <br />
        Page originally created at <asp:Label ID="OriginalTime" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
