<!-- <Snippet6> -->
<%@ Page Language="VB" Trace="true"%>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.Controls.VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script runat="server">
         Function CreateDataSource() As ICollection 
      
         ' Create sample data for the DataList control.
         Dim dt As DataTable = New DataTable()
         dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
         dt.Columns.Add(New DataColumn("ImageValue", GetType(String)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 8 

            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Description for item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
            dr(3) = "Image" & i.ToString() & ".jpg"
 
            dt.Rows.Add(dr)

         Next i
 
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 

         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then 
     
            simpleDataBoundColumn1.DataSource = CreateDataSource()
            simpleDataBoundColumn1.DataBind()
         
         End If

      End Sub

</script>

<head runat="server">
    <title>SimpleDataBoundColumn test page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <aspSample:SimpleDataBoundColumn runat="server" id="simpleDataBoundColumn1" DataTextField="CurrencyValue" BorderStyle="Solid"></aspSample:SimpleDataBoundColumn>
    </div>
    </form>
</body>
</html>
<!-- </Snippet6> -->