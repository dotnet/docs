<!-- <Snippet3> -->
<%@ Control Language="C#" Inherits="System.Web.DynamicData.FieldTemplateUserControl" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e) {
        TextBox1.ToolTip = Column.Description;

        SetUpValidator(RequiredFieldValidator1);
        SetUpValidator(RegularExpressionValidator1);
        SetUpValidator(DynamicValidator1);
    }

    protected override void ExtractValues(IOrderedDictionary dictionary) {
      dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
    }

    public override Control DataControl
    {
      get
      {
        return TextBox1;
      }
    }  

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      TextBox1.Text = Calendar1.SelectedDate.ToString("d");
    }

    string GetDateString()
    {
      if (FieldValue != null)
      {
        DateTime dt = (DateTime)FieldValue;
        return dt.ToShortDateString();
      }
      else
      {
        return string.Empty;
      }
    }
</script>

<asp:TextBox ID="TextBox1" runat="server" 
  Text='<%# GetDateString() %>' 
  MaxLength="10">
</asp:TextBox>

<asp:Calendar ID="Calendar1" runat="server" 
  VisibleDate='<%# (FieldValue != null) ? FieldValue : DateTime.Now %>'
  SelectedDate='<%# (FieldValue != null) ? FieldValue : DateTime.Now %>'
  OnSelectionChanged="Calendar1_SelectionChanged" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" 
  CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" 
  CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />  
<asp:DynamicValidator runat="server" ID="DynamicValidator1" 
  CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" />
<!-- </Snippet3> -->