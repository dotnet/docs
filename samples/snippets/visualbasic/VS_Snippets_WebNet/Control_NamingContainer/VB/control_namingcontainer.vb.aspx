<!-- System.Web.UI.Control.NamingContainer -->
<!--
     The following example demonstrates the 'NamingContainer' property
     of the class 'Control'. In this sample, a Datasource is attatched
     to a Datalist and the UniqueIDs and NamingContainer values of the
     rows of Datalist are displayed.
-->
<!-- <Snippet1>-->
<%@ Import Namespace = "System.Data"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>
            Control NamingContainer Example
         </title>
<script language="VB" runat="server">
      ' Build the DataSource.
      Function CreateDataSource() As ICollection
         Dim myDataTable As New DataTable()
         Dim myDataRow As DataRow
         myDataTable.Columns.Add(New DataColumn("EmployeeName", GetType(String)))
         Dim i As Integer
         For i = 0 To 9
            myDataRow = myDataTable.NewRow()
            myDataRow(0) = "somename" + i.ToString()
            myDataTable.Rows.Add(myDataRow)
         Next i
         Dim myDataView As New DataView(myDataTable)
         Return myDataView
      End Function

      Sub Page_Load(sender As Object, e As EventArgs)
         If Not IsPostBack Then
            ' Bind 'DataView' to the DataSource.
            myDataList.DataSource = CreateDataSource()
            myDataList.DataBind()
         End If
         ' Attach EventHandler for SelectedIndexChanged event.
         AddHandler myDataList.SelectedIndexChanged, AddressOf selectedItemChanged
      End Sub

      ' Handler function for 'SelectedIndexChanged' event.
      Sub selectedItemChanged(sender As Object, e As EventArgs)
         Dim myCurrentItem As DataListItem = myDataList.SelectedItem
         Dim myNamingContainer As Control = myCurrentItem.Controls(0).NamingContainer
         ' Display the NamingContainer.
         myLabel1.Text = "The NamingContainer is : " + myNamingContainer.UniqueID
         ' Display the UniqueID.
         myLabel2.Text = "The UniqueID is : " + CType(myCurrentItem.Controls(0), Control).UniqueID
      End Sub
    </script>
   </head>
   <body>
      <form runat="server" id="Form1">
         <h3>
            Control NamingContainer Example
         </h3>
         <h4>
            Click an item to view it's Naming Container and UniqueID
         </h4>
         <asp:Label ID="myLabel1" Runat="server"></asp:Label>
         <br />
         <asp:Label ID="myLabel2" Runat="server"></asp:Label>
         <br />
         <asp:DataList id="myDataList" runat="server" BorderColor="black">
            <HeaderStyle BackColor="#aaaadd"></HeaderStyle>
            <SelectedItemStyle BackColor="lightgreen"></SelectedItemStyle>
            <HeaderTemplate>
               EmployeeName
            </HeaderTemplate>
            <ItemTemplate>
               <asp:LinkButton id="button1" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName") %>' CommandName="select" runat="server" />
               &nbsp;&nbsp;&nbsp;&nbsp;
            </ItemTemplate>
         </asp:DataList>
      </form>
   </body>
</html>
<!-- </Snippet1>-->