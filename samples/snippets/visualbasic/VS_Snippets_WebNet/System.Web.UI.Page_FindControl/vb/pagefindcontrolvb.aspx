<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Private Class RepeaterObject
    
    Private _string As String
    
    Public Sub New(ByVal label As String)
      _string = label
    End Sub
    
    Public Property RepeaterLabel() As String
      Get
        Return _string
      End Get
      Set(ByVal value As String)
        _string = value
      End Set
    End Property
  
  End Class
    
    
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    If (Not IsPostBack) Then
    
      Dim al As New ArrayList()
      al.Add(New RepeaterObject("RepeaterObject1"))
      al.Add(New RepeaterObject("RepeaterObject2"))
      al.Add(New RepeaterObject("RepeaterObject3"))
      Repeater1.DataSource = al
      Repeater2.DataSource = al
      DataBind()
    End If
    
  End Sub


  ' This occurs for Repeater1 and originates from LinkButton onClick.
  Protected Sub OnMyCommand1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
    Dim b As LinkButton = sender
    If Not (b Is Nothing) Then
      Dim c As Label = CType(b.Parent.FindControl("Label1"), Label)
      If Not (c Is Nothing) Then
        c.Text = "text changed in handler"
        c.ForeColor = System.Drawing.Color.Green
      End If
    End If
    
  End Sub
  
  ' This occurs for Repeater2 and comes from the Repeater onItemCommand.
  Protected Sub OnMyCommand2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
    Dim l As Label = CType(e.Item.FindControl("Label1"), Label)
    If Not (l Is Nothing) Then
      l.Text = "text changed in handler"
      l.ForeColor = System.Drawing.Color.Red
    End If
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page FindControl Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <asp:Panel ID="Panel1" runat="server" >
        This repeater sample shows the bubbled event and FindControl when the repeater item OnCommand event occurs.<br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <asp:Label runat="server" ID="Label1" Text='<%#Eval("RepeaterLabel")%>' />&nbsp;
                <asp:LinkButton ID="LinkButton1" Text="Change" runat="server" OnCommand="OnMyCommand1" /> <br />
            </ItemTemplate>
        </asp:Repeater>
        <hr />

        This repeater shows the bubbled event and FindControl when the repeater OnItemCommand event occurs. <br />
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="OnMyCommand2">
            <ItemTemplate>
                <asp:Label runat="server" ID="Label1" Text='<%#Eval("RepeaterLabel")%>' />&nbsp;
                <asp:LinkButton ID="LinkButton2" Text="Change" runat="server" /> <br />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
