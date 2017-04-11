<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    DataTable dt = new DataTable();
    DataRow dr;
    dt.Columns.Add(new DataColumn("AttributeName", typeof(String)));
    dt.Columns.Add(new DataColumn("AttributeValue", typeof(String)));
            
    // The Style property of the MyText control returns
    // a CssStyleCollection object.
    IEnumerator keys = MyText.Style.Keys.GetEnumerator();

    while (keys.MoveNext())
    {
      String key = (String)keys.Current;
      dr = dt.NewRow();
      dr[0] = key;
      dr[1] = MyText.Style[key];
      dt.Rows.Add(dr);
    }
    DataView dv = new DataView(dt);
    MessageList.DataSource = dv;
    MessageList.DataBind();
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CssStyleCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DataList id="MessageList"
                  runat="server">
      <HeaderStyle Font-Bold="true"/>
      <HeaderTemplate>
         HtmlInputText control's CssStyleCollection
      </HeaderTemplate>
      <ItemTemplate>
        Attribute: 
        <%# DataBinder.Eval(Container.DataItem, "AttributeName") %>
        , 
        Value: 
        <%# DataBinder.Eval(Container.DataItem, "AttributeValue") %>
      </ItemTemplate>
    </asp:DataList>
    <br />
    An input control with a style attribute:
    <br />
    <input id="MyText"
           type="text"  
           value="Type a value here." 
           style="font: 14pt verdana;width:300;"
           runat="server"/>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
