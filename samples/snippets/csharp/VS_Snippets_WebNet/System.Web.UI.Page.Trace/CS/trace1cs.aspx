<%@ Page Trace="true" TraceMode="SortByCategory" %>
<%-- See also: SortByTime --%>

<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Data.SqlClient" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<script language="C#" runat="server">

  public void Page_Load(Object sender, EventArgs E)
  {
// <snippet1>
    Trace.Warn("Custom Trace","Beginning User Code...");
// </snippet1>
    if (!IsPostBack)
    {
      Trace.Write("CustomTrace","PostBack=false");

      SqlConnection myConnection = new SqlConnection("server=(local)\\NetSDK;database=grocertogo;Trusted_Connection=yes");
      SqlDataAdapter myCommand = new SqlDataAdapter("select distinct CategoryName from Categories", myConnection);

      DataSet ds = new DataSet();
      myCommand.Fill(ds, "Categories");
// <snippet2>
      if (Trace.IsEnabled)
      {
        for (int i=0; i<ds.Tables["Categories"].Rows.Count; i++)
        {
          Trace.Write("ProductCategory",ds.Tables["Categories"].Rows[i][0].ToString());
        }
      }
// </snippet2>
      Categories.DataSource = ds.Tables["Categories"].DefaultView;
      Categories.DataBind();
    }
  }

  public void Submit_Click(Object sender, EventArgs E)
  {
    Trace.Write("CustomTrace","Entering Submit Handler...");

    SqlConnection myConnection = new SqlConnection("server=(local)\\NetSDK;database=grocertogo;Trusted_Connection=yes");
    SqlDataAdapter myCommand = new SqlDataAdapter("select ProductName, ImagePath, UnitPrice, c.CategoryId  from Products p, Categories c where c.CategoryName='" + Categories.SelectedItem.Value + "' and p.CategoryId = c.CategoryId", myConnection);

    DataSet ds = new DataSet();
    myCommand.Fill(ds, "Products");

    Products.DataSource = ds.Tables["Products"].DefaultView;
    Products.DataBind();

    Trace.Write("CustomTrace","Leaving Submit Handler...");
  }

</script>

<head runat="server">
    <title>Writing Custom Trace Ouput to a Page</title>
</head>
<body style="font: 10pt verdana; background-color:#ffffcc">

  <form id="form1" runat="server">

  <h3>Writing Custom Trace Ouput to a Page</h3>

  Select a Category:

  <asp:DropDownList id="Categories" DataValueField="CategoryName" runat="server"/>

  <input type="Submit" onserverclick="Submit_Click" value="Get Products" runat="server"/><br />

  <asp:DataList id="Products" ShowHeader="false" ShowFooter="false" RepeatDirection="horizontal" BorderWidth="0" runat="server">

    <ItemTemplate>
      <table>
        <tr>
          <td style="text-align:center; font-size:8pt; vertical-align:top; height:200; width:150">
            <asp:ImageButton borderwidth="6" bordercolor="#ffffcc" CommandName="Select" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' runat="server"/>
            <br />
            <%# DataBinder.Eval(Container.DataItem, "ProductName") %> <br />
            <%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}").ToString() %>
          </td>
        </tr>
      </table>
    </ItemTemplate>

  </asp:DataList>

  </form>

</body>
</html>

  