<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
      CountStyleFunc(sender, e);
  }
  protected void CountStyleFunc(object sender, EventArgs e)
  {
    int styleCount;
    // Get the StylesCollection Count.
    styleCount = mytextBox.Style.Count;
    Response.Write("<br /> CssStyleCollection Count  " + styleCount);
  }
  protected void AddBtn_Click(Object Src, EventArgs e)
  {
    // Add style to textbox.
    mytextBox.Style["background-color"] = "green";
    CountStyleFunc(Src, e);
  }
  protected void ClearButton_Click(Object Src, EventArgs e)
  {
    mytextBox.Style.Clear();
    CountStyleFunc(Src, e);
  }
  protected void RemoveButton_Click(Object Src, EventArgs e)
  {
    mytextBox.Style.Remove("background-color");
    CountStyleFunc(Src, e);
  }

  protected void ShowButton_Click(Object Src, EventArgs e)
  {
    DataTable dt = new DataTable();
    DataRow dr;
    dt.Columns.Add(new DataColumn("AttributeName", typeof(String)));
    dt.Columns.Add(new DataColumn("AttributeValue", typeof(String)));

    // Get the styles collection.
    foreach (object styleKey in mytextBox.Style.Keys)
    {
      dr = dt.NewRow();
      dr[0] = (string)styleKey;
      dr[1] = mytextBox.Style[(string)styleKey];
      dt.Rows.Add(dr);
    }
    DataView dv = new DataView(dt);
    DataList1.DataSource = dv;
    DataList1.DataBind();
    
  }
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>CssStyleCollection Example</title>
</head>
   <body>
      <form id="CSSForm" runat="server">
        <div>
         <input type="text"
                id="mytextBox"
                style="color:black;font: 12pt arial;" 
                runat="server" 
                name="mytextBox"/>
         <br /> <br />
         <input type="Button"
                id="addBtn"
                value="AddStyle"
                onserverclick="AddBtn_Click"
                runat="server" 
                name="addBtn"/>
         <input type="Button" 
                id="removeBtn" 
                value="RemoveStyle" 
                onserverclick="RemoveButton_Click" 
                runat="server"
                name="removeBtn"/>
         <input type="Button" 
                id="clearBtn"
                value="ClearStyle" 
                onserverclick="ClearButton_Click" 
                runat="server" 
                name="clearBtn"/>
         <input type="Button" 
                id="showBtn"
                value="ShowAllStyles" 
                onserverclick="ShowButton_Click" 
                runat="server"
                name="showBtn"/>
         <asp:DataList id="DataList1"
                       runat="server">
           <HeaderStyle Font-Bold="true"/>
           <HeaderTemplate>
              CssStyleCollection
           </HeaderTemplate>
           <ItemTemplate>
             Attribute: 
             <%# DataBinder.Eval(Container.DataItem, "AttributeName") %>
             , 
             Value: 
             <%# DataBinder.Eval(Container.DataItem, "AttributeValue") %>
           </ItemTemplate>
         </asp:DataList>
        </div>
      </form>
   </body>
</html>
<!-- </Snippet1> -->
