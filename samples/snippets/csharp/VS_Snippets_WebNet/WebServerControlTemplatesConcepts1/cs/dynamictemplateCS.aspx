<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    // <Snippet2>
    public class MyTemplate : System.Web.UI.ITemplate
    {
        // <Snippet3>
        System.Web.UI.WebControls.ListItemType templateType;
        public MyTemplate(System.Web.UI.WebControls.ListItemType type)
        {
            templateType = type;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            PlaceHolder ph = new PlaceHolder();
            Label item1 = new Label();
            Label item2 = new Label();
            item1.ID = "item1";
            item2.ID = "item2";
            
            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<table border=\"1\">" +
                        "<tr><td><b>Category ID</b></td>" + 
                        "<td><b>Category Name</b></td></tr>"));
                    break;
                case ListItemType.Item:
                    ph.Controls.Add(new LiteralControl("<tr><td>"));
                    ph.Controls.Add(item1);
                    ph.Controls.Add(new LiteralControl("</td><td>"));
                    ph.Controls.Add(item2);
                    ph.Controls.Add(new LiteralControl("</td></tr>"));
                    ph.DataBinding += new EventHandler(Item_DataBinding);
                    break;                    
                case ListItemType.AlternatingItem:
                    ph.Controls.Add(new LiteralControl("<tr bgcolor=\"lightblue\"><td>"));
                    ph.Controls.Add(item1);
                    ph.Controls.Add(new LiteralControl("</td><td>"));
                    ph.Controls.Add(item2);
                    ph.Controls.Add(new LiteralControl("</td></tr>"));
                    ph.DataBinding += new EventHandler(Item_DataBinding);
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</table>"));
                    break;
            }
            container.Controls.Add(ph);
        }
        // </Snippet3>
    }
    // </Snippet2>

    // <Snippet4>
    static void Item_DataBinding(object sender, System.EventArgs e)
    {
        PlaceHolder ph = (PlaceHolder)sender;
        RepeaterItem ri = (RepeaterItem)ph.NamingContainer;
        Int32 item1Value = (Int32)DataBinder.Eval(ri.DataItem, "CategoryID");
        String item2Value = (String)DataBinder.Eval(ri.DataItem, "CategoryName");
        ((Label)ph.FindControl("item1")).Text = item1Value.ToString();
        ((Label)ph.FindControl("item2")).Text = item2Value;
    }
    // </Snippet4>

    // <Snippet5>
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection conn =
            new System.Data.SqlClient.SqlConnection(
            ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);

        System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        System.Data.DataSet dsCategories1;

        sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter(
            "SELECT [CategoryID], [CategoryName] FROM [Categories]", conn);
        dsCategories1 = new System.Data.DataSet();
        
        Repeater1.HeaderTemplate = new MyTemplate(ListItemType.Header);
        Repeater1.ItemTemplate = new MyTemplate(ListItemType.Item);
        Repeater1.AlternatingItemTemplate =
           new MyTemplate(ListItemType.AlternatingItem);
        Repeater1.FooterTemplate = new MyTemplate(ListItemType.Footer);
        sqlDataAdapter1.Fill(dsCategories1, "Categories");
        Repeater1.DataSource = dsCategories1.Tables["Categories"];
        Repeater1.DataBind();
    }
    // </Snippet5>


</script>
<!-- <Snippet6> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dynamically Creating Templates</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Repeater id="Repeater1" runat="server"></asp:Repeater>
    </div>
    </form>
</body>
</html>
<!-- </Snippet6> -->
<!-- </Snippet1> -->