<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet6>-->
<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="head1" runat="server">
    <title>NamingContainer Example</title>
</head>

<script language="c#" runat="server">

    ArrayList list;

    private void Page_Load(object sender, EventArgs e)
    {
        list = new ArrayList();
        list.Add("One");
        list.Add("Two");
        list.Add("Three");
        MyRepeater.DataSource = list;
        MyRepeater.DataBind();
    }

    private void ChangeBtn_Click(object sender, EventArgs e)
    {
        Control x = MyRepeater.Items[0].FindControl("Message");
        if (x != null) list = WalkContainers(x);
        MyRepeater.DataSource = list;
        MyRepeater.DataBind();
    }

    private ArrayList WalkContainers(Control ctl)
    {
        ArrayList ret = new ArrayList();
        Control parent = ctl.NamingContainer;
        if (parent != null)
        {
            ArrayList sublist = WalkContainers(parent);
            for (int j = 0; j < sublist.Count; j++) ret.Add(sublist[j]);
        }
        ret.Add(ctl.GetType().Name);
        return ret;
    }
</script>


<body>
<form id="repeaterform" runat="server">
  <h3>Using the NamingContainer Property to Determine a 
      Control's Naming Container
  </h3>
  <table id="mytable" width="80%">
      <asp:repeater id="MyRepeater" runat="server">
      <ItemTemplate>
        <tr>
          <td align="center" style="width:100%;">
           <span id="message" runat="server">
           <%#Container.DataItem%>
           </span>
          </td>
        </tr>
      </ItemTemplate>
      </asp:repeater>
    <tr>
      <td align="center" style="width:100%;">
      <input id="changebtn" 
             type="submit" 
             onserverclick="ChangeBtn_Click"
             runat="server" />
       </td>
    </tr>
  </table>
</form>
</body>
</html>
<!--</Snippet6>-->