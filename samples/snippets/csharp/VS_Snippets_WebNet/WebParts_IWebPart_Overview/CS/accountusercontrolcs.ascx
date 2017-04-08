<!-- <snippet2> -->
<%@ control language="C#" classname="AccountUserControlCS"%>
<%@ implements interface="System.Web.UI.WebControls.WebParts.IWebPart" %>

<script runat="server">

  private string m_Description;
  private string m_Title;
  private string m_TitleIconImageUrl;
  private string m_TitleUrl;
  private string m_CatalogIconImageUrl;
  
  [Personalizable]
  public string UserName
  {
    get
    {
      if(String.IsNullOrEmpty(Textbox1.Text))
        return String.Empty;
      else
        return Textbox1.Text;
    }
    
    set
    {
      Textbox1.Text = value;
    }
  }
    
  [Personalizable]
  public string Phone
  {
    get
    {
      if(String.IsNullOrEmpty(Textbox2.Text))
        return String.Empty;
      else
        return Textbox2.Text;
    }
    
    set
    {
      Textbox2.Text = value;
    }
  }

  // <snippet3>
  public string Description
  {
    get
    {
      object objTitle = ViewState["Description"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["Description"] = value;
    }
  }
  // </snippet3>

  // <snippet4>
  public string Title
  {
    get
    {
      object objTitle = ViewState["Title"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["Title"] = value;
    }
  }
  // </snippet4>

  // <snippet5>
  public string Subtitle
  {
    get
    {
      object objSubTitle = ViewState["Subtitle"];
      if (objSubTitle == null)
        return "My Subtitle";

      return (string)objSubTitle;
    }

  }
  // </snippet5>

  // <snippet6>
  public string TitleIconImageUrl
  {
    get
    {
      object objTitle = ViewState["TitleIconImageUrl"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["TitleIconImageUrl"] = value;
    }
  }
  // </snippet6>

  // <snippet7>
  public string TitleUrl
  {
    get
    {
      object objTitle = ViewState["TitleUrl"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["TitleUrl"] = value;
    }
  }
  // </snippet7>

  // <snippet8>
  public string CatalogIconImageUrl
  {
    get
    {
      object objTitle = ViewState["CatalogIconImageUrl"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["CatalogIconImageUrl"] = value;
    }
  }
  // </snippet8>
  
  // <snippet9>
  // Update the selected IWebPart property value.
  void Button1_Click(object sender, EventArgs e)
  {
    String propertyValue = Server.HtmlEncode(TextBox3.Text);
    TextBox3.Text = String.Empty;

    switch (RadioButtonList1.SelectedValue)
    {
      case "title":
        this.Title = propertyValue;
        break;
      case "description":
        this.Description = propertyValue;
        break;
      case "catalogiconimageurl":
        this.CatalogIconImageUrl = propertyValue;
        break;
      case "titleiconimageurl":
        this.TitleIconImageUrl = propertyValue;
        break;
      case "titleurl":
        this.TitleUrl = propertyValue;
        break;
      default:
        break;
    }
  }
  // </snippet9>
  
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
<asp:Label ID="Label3" Runat="server" Text="Label" 
  AssociatedControlID="RadioButtonList1">
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
<asp:Label ID="Label4" runat="server" Text="Label"
  AssociatedControlID="TextBox3">
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