<!-- <snippet2> -->
<%@ Control Language="C#" %>

<script runat="server">
private System.Drawing.Color userchoice;

[Personalizable]
public System.Drawing.Color UserColorChoice
{
   get
   {
     return userchoice;
   }
   set
   {
     userchoice = value;
   }
}

protected void OnRed(object src, EventArgs e)
{
  _color.BackColor = System.Drawing.Color.Red;
  UserColorChoice = System.Drawing.Color.Red;
}

protected void OnGreen(object src, EventArgs e)
{
  _color.BackColor = System.Drawing.Color.Green;
  UserColorChoice = System.Drawing.Color.Green;
}

protected void OnBlue(object src, EventArgs e)
{
  _color.BackColor = System.Drawing.Color.Blue;
  UserColorChoice = System.Drawing.Color.Blue;
}

protected void Page_Init(object src, EventArgs e)
{
  _redButton.Click   += new EventHandler(OnRed);  
  _greenButton.Click += new EventHandler(OnGreen);  
  _blueButton.Click  += new EventHandler(OnBlue);  
}

protected void Page_Load(object src, EventArgs e)
{
  if (!IsPostBack)
  {
          _color.BackColor = UserColorChoice;
  }
}

</script>
<body>
    <div>
        <asp:TextBox ID="_color" runat="server" Height="100" Width="100" />
        <br />
        <asp:button runat="server"  id="_redButton" text="Red"  /> 
        &nbsp;&nbsp;
        <asp:button runat="server"  id="_greenButton" text="Green" />
        &nbsp;&nbsp;
        <asp:button runat="server" id="_blueButton" text="Blue" />
    </div>
</body>
<!-- </snippet2> -->