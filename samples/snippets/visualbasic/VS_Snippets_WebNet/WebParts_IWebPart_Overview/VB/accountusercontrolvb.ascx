<!-- <snippet2> -->
<%@ control language="VB" classname="AccountUserControlVB"%>
<%@ implements interface="System.Web.UI.WebControls.WebParts.IWebPart" %>

<script runat="server">

  Private m_Description As String
  Private m_Title As String
  Private m_TitleIconImageUrl As String
  Private m_TitleUrl As String
  Private m_CatalogIconImageUrl As String


  <Personalizable()> _
  Public Property UserName() As String
    Get
      If String.IsNullOrEmpty(Textbox1.Text) Then
        Return String.Empty
      Else
        Return Textbox1.Text
      End If
    End Get
    Set(ByVal value As String)
      Textbox1.Text = Value
    End Set
  End Property

  <Personalizable()> _
  Public Property Phone() As String
    Get
      If String.IsNullOrEmpty(Textbox2.Text) Then
        Return String.Empty
      Else
        Return Textbox2.Text
      End If
    End Get
    Set(ByVal value As String)
      Textbox2.Text = Value
    End Set
  End Property

  ' <snippet3>
  Public Property Description() As String _
    Implements IWebPart.Description
    Get
      Dim objTitle As Object = ViewState("Description")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("Description") = value
    End Set
  End Property
  ' </snippet3>
  
  ' <snippet4>
  Public Property Title() As String _
    Implements IWebPart.Title
    Get
      Dim objTitle As Object = ViewState("Title")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("Title") = value
    End Set
  End Property
  ' </snippet4>
  
  ' <snippet5>
  ReadOnly Property Subtitle() As String _
    Implements IWebPart.Subtitle
    Get
      Dim objSubTitle As Object = ViewState("Subtitle")
      If objSubTitle Is Nothing Then
        Return "My Subtitle"
      End If
      Return CStr(objSubTitle)
    End Get
  End Property
  ' </snippet5>
  
  ' <snippet6>
  Public Property TitleIconImageUrl() As String _
    Implements IWebPart.TitleIconImageUrl
    Get
      Dim objTitle As Object = ViewState("TitleIconImageUrl")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("TitleIconImageUrl") = value
    End Set
  End Property
  ' </snippet6>
  
  ' <snippet7>
  Public Property TitleUrl() As String _
    Implements IWebPart.TitleUrl
    Get
      Dim objTitle As Object = ViewState("TitleUrl")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("TitleUrl") = value
    End Set
  End Property
  ' </snippet7>
  
  ' <snippet8>
  Public Property CatalogIconImageUrl() As String _
    Implements IWebPart.CatalogIconImageUrl
    Get
      Dim objTitle As Object = ViewState("CatalogIconImageUrl")
      If objTitle Is Nothing Then
        Return String.Empty
      End If
      Return CStr(objTitle)
    End Get
    Set(ByVal value As String)
      ViewState("CatalogIconImageUrl") = value
    End Set
  End Property
  ' </snippet8>
  
  ' <snippet9>
  ' Update the selected IWebPart property value.
  Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim propertyValue As String = Server.HtmlEncode(TextBox3.Text)
    TextBox3.Text = String.Empty
      
    Select Case RadioButtonList1.SelectedValue
      Case "title"
        Me.Title = propertyValue
      Case "description"
        Me.Description = propertyValue
      Case "catalogiconimageurl"
        Me.CatalogIconImageUrl = propertyValue
      Case "titleiconimageurl"
        Me.TitleIconImageUrl = propertyValue
      Case "titleurl"
        Me.TitleUrl = propertyValue
      Case Else
    End Select

  End Sub 'Button1_Click
  ' </snippet9>
  
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
<asp:Label ID="Label3" Runat="server" AssociatedControlID="RadioButtonList1">
  <h3>Update selected IWebPart property values.</h3>
</asp:Label>
<asp:RadioButtonList ID="RadioButtonList1" Runat="server">
  <asp:ListItem Value="title">Title</asp:ListItem>
  <asp:ListItem Value="description">Description</asp:ListItem>
  <asp:ListItem Value="catalogiconimageurl">CatalogIconImageUrl</asp:ListItem>
  <asp:ListItem Value="titleiconimageurl">TitleIconImageUrl</asp:ListItem>
  <asp:ListItem Value="titleurl">TitleUrl</asp:ListItem>
</asp:RadioButtonList>
<br />
<asp:Label ID="Label4" runat="server" AssociatedControlID="TextBox3">
Property Value:  
</asp:Label>
<asp:TextBox ID="TextBox3" runat="server">
</asp:TextBox>  
<br />  
<asp:Button ID="Button1" runat="server" 
  Text="Update Property" 
  OnClick="Button1_Click">
</asp:Button>
<!-- </snippet2> -->