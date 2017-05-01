<!-- <snippet2> -->
<%@ control language="C#" classname="AccountUserControl" %>
<%@ implements 
    interface="System.Web.UI.WebControls.WebParts.IWebActionable" %>
<%@ Import Namespace="System.ComponentModel" %>

<script runat="server">

  private WebPartVerbCollection m_Verbs;
  
  [Personalizable]
  public string UserName
  {
    get
    {
      if (String.IsNullOrEmpty(Textbox1.Text) || 
        Textbox1.Text.Length < 0)
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
      if(String.IsNullOrEmpty(Textbox2.Text) || 
        Textbox2.Text.Length < 0)
        return String.Empty;
      else
        return Textbox2.Text;
    }
    
    set
    {
      Textbox2.Text = value;
    }
  }

  // The following code handles the verbs.
  [Personalizable]
  public int VerbCounterClicks
  {
    get
    {
      object objVerbCounter = ViewState["VerbCounterClicks"];
      int VerbCounterClicks = 0;
      if (objVerbCounter != null)
        VerbCounterClicks = (int)objVerbCounter;

      return VerbCounterClicks;
    }
    set
    {
      ViewState["VerbCounterClicks"] = value;
    }
  }

  private void IncrementVerbCounterClicks(object sender, 
    WebPartEventArgs e)
  {
    VerbCounterClicks += 1;
    Label4.Text = "Custom Verbs Click Count: " + 
      this.VerbCounterClicks.ToString();
  }

  void Page_Load(object sender, EventArgs e)
  {
    Label3.Text = "Custom Verb Count:  " +
      WebPartManager.GetCurrentWebPartManager(Page).
      WebParts[0].Verbs.Count.ToString();
  }


  // <snippet3>
  // This property implements the IWebActionable interface.
  WebPartVerbCollection IWebActionable.Verbs
  {
    get
    {
      if (m_Verbs == null)
      {
        ArrayList verbsList = new ArrayList();
        WebPartVerb onlyVerb = new WebPartVerb
          ("customVerb1", new WebPartEventHandler(IncrementVerbCounterClicks));
        onlyVerb.Text = "My Verb";
        onlyVerb.Description = "VerbTooltip";
        onlyVerb.Visible = true;
        onlyVerb.Enabled = true;
        verbsList.Add(onlyVerb);
        WebPartVerb otherVerb = new WebPartVerb
          ("customVerb2", new WebPartEventHandler(IncrementVerbCounterClicks));
        otherVerb.Text = "My other Verb";
        otherVerb.Description = "Other VerbTooltip";
        otherVerb.Visible = true;
        otherVerb.Enabled = true;
        verbsList.Add(otherVerb);
        m_Verbs = new WebPartVerbCollection(verbsList);
        return m_Verbs;
      }
      return m_Verbs;
    }
  }
  // </snippet3>
  
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