<!-- <snippet2> -->
<%@ control language="vb" classname="AccountUserControlVB" %>
<%@ implements 
  interface="System.Web.UI.WebControls.WebParts.IWebActionable" %>
<%@ Import Namespace="System.ComponentModel" %>

<script runat="server">

  Private m_Verbs As WebPartVerbCollection

  <Personalizable()> _
  Public Property UserName() As String
    Get
      If String.IsNullOrEmpty(Textbox1.Text) OrElse _
        Textbox1.Text.Length < 0 Then
        Return String.Empty
      Else
        Return Textbox1.Text
      End If
    End Get
    Set(ByVal value As String)
      Textbox1.Text = value
    End Set
  End Property


  <Personalizable()> _
  Public Property Phone() As String
    Get
      If String.IsNullOrEmpty(Textbox2.Text) OrElse _
        Textbox2.Text.Length < 0 Then
        Return String.Empty
      Else
        Return Textbox2.Text
      End If
    End Get
    Set(ByVal value As String)
      Textbox2.Text = value
    End Set
  End Property

  ' The following code handles the verbs.
  <Personalizable()> _
  Public Property VerbCounterClicks() As Integer
    Get
      Dim objVerbCounter As Object = _
        ViewState("VerbCounterClicks")
      VerbCounterClicks = 0
      If Not (objVerbCounter Is Nothing) Then
        VerbCounterClicks = CType(objVerbCounter, Int32)
      End If
      Return VerbCounterClicks
    End Get
    Set(ByVal value As Integer)
      ViewState("VerbCounterClicks") = value
    End Set
  End Property


  Private Sub IncrementVerbCounterClicks _
    (ByVal sender As Object, ByVal e As WebPartEventArgs)
    VerbCounterClicks += 1
    Label4.Text = "Custom Verbs Click Count: " + _
      Me.VerbCounterClicks.ToString()
  End Sub

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    Label3.Text = "Custom Verb Count:  " + _
      WebPartManager.GetCurrentWebPartManager(Page). _
      WebParts(0).Verbs.Count.ToString()
  End Sub

  ' <snippet3>
  ' This property implements the IWebActionable interface.
  ReadOnly Property Verbs() As WebPartVerbCollection _
    Implements IWebActionable.Verbs
    Get
      If (m_Verbs Is Nothing) Then
        Dim verbsList As New ArrayList()
        Dim onlyVerb As New WebPartVerb _
          ("customVerb1", New WebPartEventHandler(AddressOf IncrementVerbCounterClicks))
        onlyVerb.Text = "My Verb"
        onlyVerb.Description = "VerbTooltip"
        onlyVerb.Visible = True
        onlyVerb.Enabled = True
        verbsList.Add(onlyVerb)
        Dim otherVerb As New WebPartVerb _
          ("customVerb2", New WebPartEventHandler(AddressOf IncrementVerbCounterClicks))
        otherVerb.Text = "My other Verb"
        otherVerb.Description = "Other VerbTooltip"
        otherVerb.Visible = True
        otherVerb.Enabled = True
        verbsList.Add(otherVerb)
        m_Verbs = New WebPartVerbCollection(verbsList)
      End If
      Return m_Verbs
    End Get
  End Property
  ' </snippet3>

</script>
<div>
<asp:label id="Label1" runat="server" AssociatedControlID="Textbox1">
  Name</asp:label>
<asp:textbox id="Textbox1" runat="server" />
</div>
<div>
<asp:label id="Label2" runat="server" AssociatedControlID="Textbox2">
  Phone</asp:label>
<asp:textbox id="Textbox2" runat="server"></asp:textbox>
</div>
<div>
<asp:button id="Button2" runat="server" text="Save Form Values" />
</div>
<hr />
<br />
<asp:Label ID="Label3" runat="server" Text="" />
<br />
<asp:Label ID="Label4" runat="server" Text="" />
<!-- </snippet2> -->