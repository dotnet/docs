<%--<Snippet1>--%>
<%@ Import Namespace = "System.Data"  %>
<%@ Page language="VB" AutoEventWireup="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">    
' The following example creates a DataSource as a DataView.
' The DataView is bound to a DataList that is displayed using an
' ItemTemplate. When the page is first loaded, the program uses the 
' CopyTo method to copy the entire data source to an Array and then 
' displays that data.

Function CreateDataSource() As ICollection 
    Dim myDataTable As DataTable = New DataTable()
    Dim myDataRow As DataRow 
    Dim i As Integer

    myDataTable.Columns.Add(New DataColumn("EmployeeName", GetType(String)))
    myDataTable.Columns.Add(New DataColumn("EmployeeID", GetType(Integer)))
    For i = 0 To 2
        myDataRow = myDataTable.NewRow()
        myDataRow(0) = "somename" + i.ToString()
        myDataRow(1) = i + 1000
        myDataTable.Rows.Add(myDataRow)
    Next 
    CreateDataSource = new DataView(myDataTable)
End Function

' <Snippet2>
Sub Page_Load(sender As object, e As EventArgs)
    If (Not IsPostBack)
        ' Bind the DataView to the DataSource.
        myDataList.DataSource = CreateDataSource()
        myDataList.DataBind()
        ' Create a Array to hold the DataSource.
        Dim myArray As System.Array = Array.CreateInstance(GetType(DataListItem), _
            myDataList.Items.Count)
        ' Copy the DataSource to an Array.
        myDataList.Items.CopyTo(myArray, 0)
        PrintValues(myArray)
    End If
End sub

' Prints each element in the Array onto the label lblAllItems1.
Public Sub PrintValues(myArr As Array)
    Dim currentItem As DataListItem 
    Dim myEnumerator As System.Collections.IEnumerator = myArr.GetEnumerator()
    While (myEnumerator.MoveNext())
        currentItem = CType(myEnumerator.Current,DataListItem)
        lblAllItems1.Text = lblAllItems1.Text & "<br /><br />" & _
            CType(currentItem.Controls(1),Label).Text
    End While
End Sub

    ' Event handler method for show button.
Sub show_Click(sender as Object, e As EventArgs)
    ' Get the underlying DataListItemCollection from the DataList object.
    Dim myDataListItemCollection As DataListItemCollection = myDataList.Items
    ' Display the read-only properties.
    Response.Write("<b>The Total number of items are " & _
        myDataListItemCollection.Count & "</b>")
        Response.Write("<br /><b>The ReadOnly property of the " & _
            "DataListItemCollection is always " & _
            myDataListItemCollection.IsReadOnly & "</b>")
        Response.Write("<br /><b>The IsSynchronized property of the " & _
            "DataListItemCollection is always " _
            & myDataListItemCollection.IsSynchronized & "</b>")
    myDataListItemCollection = Nothing
End Sub
    ' </Snippet2>

' <Snippet5>
Sub AllItems_Click(sender As Object, e As EventArgs)
    Dim dataListEnumerator As IEnumerator
    Dim currentItem As DataListItem 
    lblAllItems.Text = ""
    ' Get an enumerator to traverse the DataListItemCollection.
    dataListEnumerator = myDataList.Items.GetEnumerator()
    while(dataListEnumerator.MoveNext())
        currentItem = CType(dataListEnumerator.Current,DataListItem)
        ' Display the current DataListItem onto the label.
        lblAllItems.Text = lblAllItems.Text & CType((currentItem.Controls(1)), _
        Label).Text & "  "
    End While
End Sub
' </Snippet5>

' <Snippet6>
Sub ItemSelected(sender As object, e As EventArgs)
    ' Get the underlying DataListItemCollection from the DataList object.
    Dim myDataListItemCollection As DataListItemCollection  = myDataList.Items
    ' Get the index of the selected radio button in the RadioButtonList.
    Dim index As Integer = Convert.ToInt16(listItemNo.SelectedItem.Value)
    ' Get the DataListItem corresponding to index from DataList.
    ' SyncRoot is used to make access to the DataListItemCollection 
    ' in a thread-safe manner It returns the object that invoked it. 
    Dim currentItem As DataListItem = _ 
        CType(myDataListItemCollection.SyncRoot,DataListItemCollection)(index)
    ' Display the selected DataListItem onto a label.
    lblDisplay.Text = "<b>DataListItem" & index & " is: " _
        & CType(currentItem.Controls(1),Label).Text
    currentItem = Nothing
    myDataListItemCollection = Nothing
End Sub
    ' </Snippet6>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>
        DataListItemCollection Example
    </title>
</head>
<body>
<form runat="server" id="Form1">
    <h3>
        DataListItemCollection Example
    </h3>
    <table>
        <tr>
            <td>
                <asp:datalist id="myDataList" runat="server" Font-Size="8pt" 
                    Font-Names="Verdana" BorderColor="black" CellSpacing="5"
                    CellPadding="10" GridLines="Horizontal">
                    <HeaderStyle BackColor="#aaaadd"></HeaderStyle>
                    <HeaderTemplate>
                        EmployeeName EmployeeID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label id="label1"  runat="server"
                            Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName") %>' />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <%# DataBinder.Eval(Container.DataItem, "EmployeeID")%>
                    </ItemTemplate>
                </asp:datalist>
            </td>
            <td>
                <asp:label id="lblAllItems1" 
                    Text="The following items <br /> are copied to the array: " 
                    Runat="server" ForeColor="blue" Font-Bold="true" 
                    AssociatedControlID="listItemNo">
                    The following items <br /> are copied to the array:
                </asp:label>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp; <b>Show Items:</b>
                <asp:RadioButtonList ID="listItemNo" 
                    OnSelectedIndexChanged="itemSelected" AutoPostBack="true" 
                    Runat="server">
                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Label ID="lblDisplay" Runat="server" />
            </td>
        </tr>
    </table>
    <p>
        <asp:button id="show" onclick="show_Click" Runat="server" 
            Font-Bold="True" Text="DataList Information" />
        <asp:button id="allitems" onclick="allItems_Click" Runat="server" 
            Font-Bold="True" Text="Show All DataListItems" />
    </p>
    <p>
        <b>All DataList items will be shown here:</b>
        <asp:label id="lblAllItems" Runat="server" ForeColor="blue" />
    </p>
</form>
</body>
</html>
<%--</Snippet1>--%>
