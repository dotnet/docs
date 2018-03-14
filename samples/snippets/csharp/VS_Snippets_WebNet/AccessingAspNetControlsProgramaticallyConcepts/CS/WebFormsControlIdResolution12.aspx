<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet2>-->
<script language="c#" runat="server">
    
  void Page_Load(Object sender, EventArgs e) 
  {
      StringBuilder sb = new StringBuilder();
      sb.Append("Container: " + 
          MyDataList.NamingContainer.ToString() + "<p>");

      ArrayList a = new ArrayList();
      a.Add("A");
      a.Add("B");
      a.Add("C");

      MyDataList.DataSource = a;
      MyDataList.DataBind();

      for (int i = 0; i < MyDataList.Controls.Count; i++)
      {
          Label l = 
              (Label)((RepeaterItem)MyDataList.Controls[i]).FindControl("MyLabel");
          sb.Append("Container: " + 
              ((RepeaterItem)MyDataList.Controls[i]).NamingContainer.ToString() + 
              "<p>");
          sb.Append("<b>" + l.UniqueID + "</b><p>");
      }
      ResultsLabel.Text = sb.ToString();
}
</script>
<!--</Snippet2>-->

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head2" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--<Snippet1>-->
      <asp:Repeater id="MyDataList" runat="server">
        <ItemTemplate>
          <asp:Label id="MyLabel" Text="<%# Container.ToString() %>" runat="server"/><br />
        </ItemTemplate>
      </asp:Repeater>
      <hr />
      <asp:Label id="ResultsLabel" runat="server" AssociatedControlID="MyDataList"/>
     <!--</Snippet1>-->    
    </div>
    </form>
</body>
</html>