<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    Dim dt As New DataTable()
    Dim dr As DataRow
    dt.Columns.Add(New DataColumn("AttributeName", GetType(String)))
    dt.Columns.Add(New DataColumn("AttributeValue", GetType(String)))
    
    ' The Style property of the MyText control returns
    ' a CssStyleCollection object.
    Dim keys As IEnumerator = MyText.Style.Keys.GetEnumerator()
   
    While keys.MoveNext()
      
      Dim key As [String] = CType(keys.Current, [String])
      dr = dt.NewRow()
      dr(0) = key
      dr(1) = MyText.Style(key)
      dt.Rows.Add(dr)
    End While
    Dim dv As New DataView(dt)
    MessageList.DataSource = dv
    MessageList.DataBind()

  End Sub
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
    <input id="MyText"
           type="text"  
           value="Type a value here." 
           style="font: 14pt verdana;width:300;"
           runat="server"/>
    </div>
    </form>
</body></html>
<!-- </Snippet1> -->