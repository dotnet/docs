<!-- <Snippet1> -->
<%@Page  Language="VB" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- <Snippet2> -->
<script runat="server">
Private Sub UpdateRecords(source As Object, e As EventArgs)

  ' This method is an example of batch updating using a
  ' data source control. The method iterates through the rows
  ' of the GridView, extracts each CheckBox from the row and, if
  ' the CheckBox is checked, updates data by calling the Update
  ' method of the data source control, adding required parameters
  ' to the UpdateParameters collection.

  Dim cb As CheckBox
  Dim row As GridViewRow

  For Each row In GridView1.Rows

    cb = CType(row.Cells(0).Controls(1), CheckBox)
    If cb.Checked Then

      Dim oid As String
      oid = CType(row.Cells(1).Text, String)

      Dim param1 As New Parameter("date", TypeCode.DateTime, DateTime.Now.ToString())
      MyAccessDataSource.UpdateParameters.Add(param1)

      Dim param2 As New Parameter("orderid", TypeCode.String, oid)
      MyAccessDataSource.UpdateParameters.Add(param2)

      MyAccessDataSource.Update()
      MyAccessDataSource.UpdateParameters.Clear()
    End If
  Next
End Sub ' UpdateRecords
</script>
<!-- </Snippet2> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
<!-- <Snippet3> -->

<!-- Security Note: The SqlDataSource uses a QueryStringParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the QueryStringParameter, handle the Selecting event. -->

      <asp:SqlDataSource
        id="MyAccessDataSource"
        runat="server"
        ProviderName="<%$ ConnectionStrings:MyPasswordProtectedAccess.providerName%>"
        ConnectionString="<%$ ConnectionStrings:MyPasswordProtectedAccess%>"
        SelectCommand="SELECT OrderID, OrderDate, RequiredDate, ShippedDate FROM Orders WHERE EmployeeID=?"
        UpdateCommand="UPDATE Orders SET ShippedDate=? WHERE OrderID = ?">
        <SelectParameters>
          <asp:QueryStringParameter Name="empId" QueryStringField="empId" />
        </SelectParameters>
      </asp:SqlDataSource>

<!-- </Snippet3> -->
      <asp:GridView
        id ="GridView1"
        runat="server"
        DataSourceID="MyAccessDataSource"
        AllowPaging="True"
        PageSize="10"
        AutoGenerateColumns="False">
          <columns>
            <asp:TemplateField HeaderText="">
              <ItemTemplate>
                <asp:CheckBox runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Order" DataField="OrderID" />
            <asp:BoundField HeaderText="Order Date" DataField="OrderDate" />
            <asp:BoundField HeaderText="Required Date" DataField="RequiredDate" />
            <asp:BoundField HeaderText="Shipped Date" DataField="ShippedDate" />
          </columns>
      </asp:GridView>

      <asp:Button
        id="Button1"
        runat="server"
        Text="Update the Selected Records As Shipped"
        OnClick="UpdateRecords" />

      <asp:Label id="Label1" runat="server" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->