<!-- <Snippet3> -->
<%@ Control Language="VB" Inherits="System.Web.DynamicData.FieldTemplateUserControl" %>

<script runat="server">
  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    TextBox1.ToolTip = Column.Description
    
    SetUpValidator(RequiredFieldValidator1)
    SetUpValidator(RegularExpressionValidator1)
    SetUpValidator(DynamicValidator1)
  End Sub

  Protected Overrides Sub ExtractValues(ByVal dictionary As IOrderedDictionary)
    dictionary(Column.Name) = ConvertEditedValue(TextBox1.Text)
  End Sub
  
  Public Overrides ReadOnly Property DataControl() As Control
    Get
      Return TextBox1
    End Get
  End Property

  Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    TextBox1.Text = Calendar1.SelectedDate.ToString("d")
  End Sub
  
  Function GetDateString() As String
    If Not (FieldValue Is Nothing) Then
      Dim dt As DateTime = CType(FieldValue, DateTime)
      Return dt.ToShortDateString()
    Else
      Return String.Empty
    End If
  End Function
  
</script>

<asp:TextBox ID="TextBox1" runat="server" 
  Text='<%# GetDateString() %>' 
  MaxLength="10">
</asp:TextBox>

<asp:Calendar ID="Calendar1" runat="server" 
  VisibleDate='<%# IIf(FieldValue Is Nothing, DateTime.Now, FieldValue) %>'
  SelectedDate='<%# IIf(FieldValue Is Nothing, DateTime.Now, FieldValue) %>' 
  OnSelectionChanged="Calendar1_SelectionChanged" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" 
  CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" 
  CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />  
<asp:DynamicValidator runat="server" ID="DynamicValidator1" 
  CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" />
<!-- </Snippet3> -->