<!-- <Snippet1> -->

<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub PopulateNode(ByVal sender As Object, ByVal e As TreeNodeEventArgs)

    ' Call the appropriate method to populate a node at a particular level.
    Select Case e.Node.Depth

      Case 0
        ' Populate the first-level nodes.
        PopulateCategories(e.Node)

      Case 1
        ' Populate the second-level nodes.
        PopulateProducts(e.Node)

      Case Else
        ' Do nothing.

    End Select

  End Sub

  Sub PopulateCategories(ByVal node As TreeNode)

    ' Query for the product categories. These are the values
    ' for the second-level nodes.
    Dim ResultSet As DataSet = RunQuery("Select CategoryID, CategoryName From Categories")

    ' Create the second-level nodes.
    If ResultSet.Tables.Count > 0 Then

      ' Iterate through and create a new node for each row in the query results.
      ' Notice that the query results are stored in the table of the DataSet.
      Dim row As DataRow

      For Each row In ResultSet.Tables(0).Rows

        ' Create the new node. Notice that the CategoryId is stored in the Value property 
        ' of the node. This will make querying for items in a specific category easier when
        ' the third-level nodes are created. 
        Dim NewNode As TreeNode = New TreeNode(row("CategoryName").ToString(), row("CategoryID").ToString())

        ' Set the PopulateOnDemand property to true so that the child nodes can be 
        ' dynamically populated.
        NewNode.PopulateOnDemand = True

        ' Set additional properties for the node.
        NewNode.SelectAction = TreeNodeSelectAction.Expand

        ' Add the new node to the ChildNodes collection of the parent node.
        node.ChildNodes.Add(NewNode)

      Next

    End If

  End Sub

  Sub PopulateProducts(ByVal node As TreeNode)

    ' Query for the products of the current category. These are the values
    ' for the third-level nodes.
    Dim ResultSet As DataSet = RunQuery("Select ProductName From Products Where CategoryID=" & node.Value)

    ' Create the third-level nodes.
    If ResultSet.Tables.Count > 0 Then

      ' Iterate through and create a new node for each row in the query results.
      ' Notice that the query results are stored in the table of the DataSet.
      Dim row As DataRow

      For Each row In ResultSet.Tables(0).Rows

        ' Create the new node.
        Dim NewNode As TreeNode = New TreeNode(row("ProductName").ToString())

        ' Set the PopulateOnDemand property to false because these are leaf nodes and
        ' do not need to be populated.
        NewNode.PopulateOnDemand = False

        ' Set additional properties for the node.
        NewNode.SelectAction = TreeNodeSelectAction.None

        ' Add the new node to the ChildNodes collection of the parent node.
        node.ChildNodes.Add(NewNode)

      Next

    End If

  End Sub

  Function RunQuery(ByVal QueryString As String) As DataSet

    ' Declare the connection string. This example uses Microsoft SQL Server and connects to the
    ' Northwind sample database.
    Dim ConnectionString As String = "server=localhost;database=NorthWind;Integrated Security=SSPI"

    Dim DBConnection As SqlConnection = New SqlConnection(ConnectionString)
    Dim DBAdapter As SqlDataAdapter
    Dim ResultsDataSet As DataSet = New DataSet

    Try

      ' Run the query and create a DataSet.
      DBAdapter = New SqlDataAdapter(QueryString, DBConnection)
      DBAdapter.Fill(ResultsDataSet)

      ' Close the database connection.
      DBConnection.Close()

    Catch ex As Exception

      ' Close the database connection if it is still open.
      If DBConnection.State = ConnectionState.Open Then

        DBConnection.Close()

      End If

      Message.Text = "Unable to connect to the database."

    End Try

    Return ResultsDataSet

  End Function

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView TreeNodePopulate Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView TreeNodePopulate Example</h3>
    
      <asp:TreeView id="LinksTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
        EnableClientScript="false" 
        OnTreeNodePopulate="PopulateNode"
        runat="server">
         
        <Nodes>
        
          <asp:TreeNode Text="Inventory" 
            SelectAction="Expand"  
            PopulateOnDemand="true"/>
        
        </Nodes>
        
      </asp:TreeView>
      
      <br /><br />
      
      <asp:Label id="Message" runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
