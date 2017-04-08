<!-- <snippet2> -->
<%@ Control Language="vb" %>
<%@ Import Namespace="Samples.AspNet.VB.Controls" %>
    
<script runat="server">

  Private _textContent As String

  <Personalizable()> _
  Public Property TextContent() As String
    Get
      Return _textContent
    End Get
    Set(ByVal value As String)
      _textContent = Value
    End Set
  End Property
 
  Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
    Label1.Text = Me.TextContent
    Dim viewIndex As Integer = 0
      
    Dim wpmg As WebPartManager = _
      WebPartManager.GetCurrentWebPartManager(Me.Page)
    Dim myNewWpmg As NewWebPartManager = _
      CType(wpmg, NewWebPartManager)
    If Not (myNewWpmg Is Nothing) Then
      Dim mode As WebPartDisplayMode = _
        myNewWpmg.SupportedDisplayModes(myNewWpmg.InLineEditDisplayMode.Name)
      If Not (mode Is Nothing) AndAlso _
        myNewWpmg.DisplayMode Is mode Then
        viewIndex = 1
      End If
    End If
    Me.MultiView1.ActiveViewIndex = viewIndex

  End Sub

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    
    Me.TextContent = TextBox1.Text
    Dim wpmg As WebPartManager = _
      WebPartManager.GetCurrentWebPartManager(Me.Page)
    Dim mode As WebPartDisplayMode = _
      wpmg.SupportedDisplayModes(WebPartManager.BrowseDisplayMode.Name)
    If Not (mode Is Nothing) Then
      wpmg.DisplayMode = mode
    End If

  End Sub
  
</script>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label" />
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" OnClick="Button1_Click" 
          runat="server" Text="Button" />
    </asp:View>
</asp:MultiView>
<!-- </snippet2> -->