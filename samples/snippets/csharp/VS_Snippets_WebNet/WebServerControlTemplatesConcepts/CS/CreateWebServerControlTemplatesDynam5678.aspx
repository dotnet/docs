<%@ Page Language="C#"  %>
<%@ Import Namespace= "System.Data"%>
<%@ Import Namespace= "System.Data.SqlClient"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to: Create Web Server Control Templates Dynamically</title>
</head>

<script runat="server">
    
    //<Snippet5>
    public class MyTemplate : ITemplate
    {
        static int itemcount = 0;
        ListItemType templateType;

        public MyTemplate(ListItemType type)
        {
            templateType = type;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Literal lc = new Literal();
            switch (templateType)
            {
                case ListItemType.Header:
                    lc.Text = "<table border=\"1\"><tr><th>Items</th></tr>";
                    break;
                case ListItemType.Item:
                    lc.Text = "<tr><td>Item number: " + itemcount.ToString() +
                       "</td></tr>";
                    break;
                case ListItemType.AlternatingItem:
                    lc.Text = "<tr><td bgcolor=\"lightblue\">Item number: " +
                       itemcount.ToString() + "</td></tr>";
                    break;
                case ListItemType.Footer:
                    lc.Text = "</table>";
                    break;
            }
            container.Controls.Add(lc);
            itemcount += 1;
        }
    }
  
    //</Snippet5>
    
    
    //<Snippet6>
    private void Page_Load(object sender, System.EventArgs e)
    {
        SqlConnection conn = 
          new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);

        SqlDataAdapter sqlDataAdapter1;
        DataSet dsCategories1;

        sqlDataAdapter1 = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories", conn);
        dsCategories1 = new DataSet();
                
        Repeater1.HeaderTemplate = new MyTemplate(ListItemType.Header);
        Repeater1.ItemTemplate = new MyTemplate(ListItemType.Item);
        Repeater1.AlternatingItemTemplate =
           new MyTemplate(ListItemType.AlternatingItem);
        Repeater1.FooterTemplate = new MyTemplate(ListItemType.Footer);
        sqlDataAdapter1.Fill(dsCategories1, "Categories");
        Repeater1.DataSource = dsCategories1.Tables["Categories"];
        Repeater1.DataBind();
    }
    //</Snippet6>

    private void Button1_Click()
    {
        Literal lc = new Literal();
        ListItemType templateType = new ListItemType();
switch(templateType)
{
  //<Snippet7>
   case ListItemType.Item:
  
   lc.Text = "<tr><td>";
   lc.DataBinding += new EventHandler(TemplateControl_DataBinding);
   break;
  //</Snippet7>
         
  
}

    }
    
    //<Snippet8>
    //<Snippet9>
    private void TemplateControl_DataBinding(object sender,
    System.EventArgs e)
   //</Snippet9>
    {
        
        Literal lc;

        lc = (Literal)sender;
        RepeaterItem container = (RepeaterItem)lc.NamingContainer;
        lc.Text += DataBinder.Eval(container.DataItem, "CategoryName");
        lc.Text += "</td></tr>";
    }
    //</Snippet8>
    
</script>
<body>
    <form id="form1" runat="server">
      <asp:Repeater id="Repeater1" runat="server"></asp:Repeater>
      <asp:Button id="Button1" runat= "server" />
    </form>
</body>
</html>
