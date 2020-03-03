<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet2>-->
  <script language="vb" runat="server">
      
      Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
          Dim sb As New StringBuilder()
          sb.Append("Container: " + _
          MyDataList.NamingContainer.ToString() + "<p>")

          Dim a As New ArrayList()
          a.Add("A")
          a.Add("B")
          a.Add("C")

          MyDataList.DataSource = a
          MyDataList.DataBind()
    
          Dim i As Integer
          Dim l As Label
          For i = 0 To MyDataList.Controls.Count - 1
              l = CType(CType(MyDataList.Controls(i), RepeaterItem).FindControl("MyLabel"), Label)
              sb.Append("Container: " & _
                 CType(MyDataList.Controls(i), RepeaterItem).NamingContainer.ToString() & _
                 "<p>")
              sb.Append("<b>" & l.UniqueID.ToString() & "</b><p>")
          Next
          ResultsLabel.Text = sb.ToString()
      End Sub
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