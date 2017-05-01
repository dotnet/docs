<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataListCommandEventArgs Example</title>
<script language="VB" runat="server">
 
    Function CreateDataSource() As ICollection
        
        Dim dt As New DataTable()
        Dim dr As DataRow
        
        ' Create a DataTable.
        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("DateTimeValue", GetType(DateTime)))
        
        ' Create sample data.
        Dim i As Integer
        For i = 1 To 9
            dr = dt.NewRow()
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = DateTime.Now.ToShortTimeString()
            dt.Rows.Add(dr)
        Next i
        
        
        ' Return a DataView to the DataTable.
        Dim dv As New DataView(dt)
        Return dv
    End Function 'CreateDataSource
     

    Sub Page_Load(sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            BindList()
        End If 
    End Sub 'Page_Load


    Sub BindList()
        
        DataList1.DataSource = CreateDataSource()
        DataList1.DataBind()
    End Sub 'BindList
     

    Sub DataList_ItemCommand(sender As Object, e As DataListCommandEventArgs)
        If CType(e.CommandSource, LinkButton).CommandName = "select" Then
            DataList1.SelectedIndex = e.Item.ItemIndex
        End If 
        BindList()
    End Sub 'DataList_ItemCommand
     
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataListCommandEventArgs Example</h3>
 
      <asp:DataList id="DataList1"                                                
                    GridLines="Both"                                                       
                    OnItemCommand="DataList_ItemCommand"
                    runat="server">

         <HeaderTemplate>
            Items
         </HeaderTemplate>

         <ItemTemplate>
            <asp:LinkButton id="button1"
                            Text="Show details" 
                            CommandName="select" 
                            runat="server"/>
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>
         </ItemTemplate>

         <SelectedItemTemplate>
            Item:
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>
            <br />
            Order Date:
            <%# DataBinder.Eval(Container.DataItem, "DateTimeValue", "{0:d}") %>
            <br />
            Quantity:
            <%# DataBinder.Eval(Container.DataItem, "IntegerValue", "{0:N1}") %>
            <br />
         </SelectedItemTemplate>
 
      </asp:DataList>

   </form>
 
</body>
</html>
   
<!--</Snippet1>-->
