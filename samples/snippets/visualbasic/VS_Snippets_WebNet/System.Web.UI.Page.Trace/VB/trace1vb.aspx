<%@ Page Trace="true" TraceMode="SortByCategory" %>
<%-- See also: SortByTime --%>

<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Data.SqlClient" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<script language="VB" runat="server">

  Sub Page_Load(Sender As Object, E As EventArgs)
' <snippet1>
    Trace.Warn("Custom Trace","Beginning User Code...")
' </snippet1>
    If Not (IsPostBack) Then

      Trace.Write("CustomTrace","PostBack=false")

      Dim MyConnection As SqlConnection
      Dim MyCommand As SqlDataAdapter    

      MyConnection = New SqlConnection("server=(local)\NetSDK;database=grocertogo;Trusted_Connection=yes")
      MyCommand = New SqlDataAdapter("select distinct CategoryName from Categories", MyConnection)

      Dim DS As New DataSet
      MyCommand.Fill(DS, "Categories")
' <snippet2>
      If (Trace.IsEnabled) Then

        Dim I As Integer
        For I = 0 To DS.Tables("Categories").Rows.Count - 1

          Trace.Write("ProductCategory",DS.Tables("Categories").Rows(I)(0).ToString())
        Next
      End If
' </snippet2>
      Categories.DataSource = ds.Tables("Categories").DefaultView
      Categories.DataBind
    End If
  End Sub

  Sub Submit_Click(Sender As Object, E As EventArgs)

    Trace.Write("CustomTrace","Entering Submit Handler...")

    Dim MyConnection As SqlConnection
    Dim MyCommand As SqlDataAdapter

    MyConnection = New SqlConnection("server=(local)\NetSDK;database=grocertogo;Trusted_Connection=yes")
    MyCommand = New SqlDataAdapter("select ProductName, ImagePath, UnitPrice, c.CategoryId  from Products p, Categories c where c.CategoryName='" & Categories.SelectedItem.Value & "' and p.CategoryId = c.CategoryId", MyConnection)


    Dim DS As New DataSet
    MyCommand.Fill(DS, "Products")

    Products.DataSource = ds.Tables("Products").DefaultView
    Products.DataBind()

    Trace.Write("CustomTrace","Leaving Submit Handler...")
  End Sub

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
          <td style="width:150; text-align:center; font-size:8pt; vertical-align:top; height:200">
            <asp:ImageButton borderwidth="6" bordercolor="#ffffcc" commandname="Select" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' runat="server"/>
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

