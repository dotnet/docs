<!--<snippet1>-->
<%@ Control Language="C#" ClassName="PersAdmin" %>

<script runat="server">
    WebPartManager _manager;
    string _provider;
    string _userscope;

  void Page_Init(object sender, EventArgs e)
  {
    Page.InitComplete += new EventHandler(InitComplete);
  }

    void InitComplete(object sender, System.EventArgs e)
    {
        _manager = WebPartManager.GetCurrentWebPartManager(Page);
        // <snippet4>
        _provider = PersonalizationAdministration.Provider.Name;
        TextBox1.Text = _provider;
        // </snippet4>
        // <snippet6>
        if (_manager.Personalization.Scope == PersonalizationScope.Shared)
        {
            TextBox2.Text = "Shared Scope";
        }
        else
            TextBox2.Text = "User Scope";
        // </snippet6>
           // <snippet5>
        Label4.Visible = false;
        TextBox4.Text = PersonalizationAdministration.GetCountOfState(PersonalizationScope.User).ToString();
            // </snippet5>
    }

// <snippet2>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text != null)
        {
            // <snippet3>
            PersonalizationStateInfoCollection findresult;
          findresult = PersonalizationAdministration.FindUserState(null, TextBox3.Text);
          if (findresult.Count != 0)
          {
              Label4.Text = findresult.Count + "  user(s) found";
              Label4.Visible = true;
          }
              // </snippet3>
          else
          {
              Label4.Text = "No users found.";
              Label4.Visible = true;
          }
        }
      else
      {
          Label4.Text = "You must enter a user name to find.";
      }

    }
    // </snippet2>

</script>
<asp:Label ID="Label1" runat="server" Text="Personalization Provider" Width="162px"
  AssociatedControlID="TextBox1" />
<br />
<asp:TextBox ID="TextBox1" runat="server" Width="268px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Scope" AssociatedControlID="TextBox2" />
<br />
<asp:TextBox ID="TextBox2" runat="server" Width="90px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="User to Find" Width="135px"
  AssociatedControlID="TextBox3" />
<br />
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;
<asp:Label ID="Label4" runat="server" Width="77px" ForeColor="Red" />
<br />
<br />
<asp:Button ID="Button1" runat="server" Text="Find User" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;
<br />
<br />
<asp:Label ID="Label5" runat="server" Text="Personalization Statistics" Width="204px" />
<br />
<br />
<asp:Label ID="Label6" runat="server" Text="Number of User Personalization States" Width="246px"
  AssociatedControlID="TextBox4" Height="21px" />
<br />
<asp:TextBox ID="TextBox4" runat="server" Width="63px"></asp:TextBox>
<br />
<br />
<br />
<br />
<!--</snippet1>-->