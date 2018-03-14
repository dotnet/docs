<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Function CreateDataSource() As ICollection 
      
         ' Create sample data for the DataGrid control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(string)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(double)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 to 8 
        
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)

         Next i
 
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         ' Load sample data only once when the page is first loaded.
         If Not IsPostBack Then 
  
            ' Retrieve sample data.
            Dim Source As DataView = CreateDataSource()


            ' Bind the data source to the DataGrid control if each column in 
            ' the data source contains a data type that is compatible with the 
            ' DataGrid; Otherwise, display an error message. 
            If ValidateSourceTypes(Source) Then

               ItemsGrid.DataSource = Source
               ItemsGrid.DataBind()

            Else

               Message.Text = "The data source is not compatible with the DataGrid control."

            End If

         End If

      End Sub

      Function ValidateSourceTypes(Source As DataView) As Boolean
       
         ' Test the data type of each column in the data source to make 
         ' sure it is compatible with the DataGrid control.

         ' Initialize the success flag to True.
         Dim Success As Boolean = True

         ' Iterate through each column of the data source and test the 
         ' data type for compatibility with the DataGrid control.
         Dim column As DataColumn
           
         For Each column In Source.Table.Columns

            If Not BaseDataList.IsBindableType(column.DataType) Then
         
               Success = False
            
            End If

         Next

         Return Success

      End Function

   </script>
 
<head runat="server">
    <title>BaseDataList IsBindableType Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>BaseDataList IsBindableType Example</h3>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           GridLines="Both"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 
 
      </asp:DataGrid>

      <br /><br />

      <asp:Label id="Message" 
           runat="server"/>       

   </form>
 
</body>
</html>

<!-- </Snippet1> -->
