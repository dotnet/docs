<!-- <Snippet1> -->
<%@Page  Language="VB" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 Sub On_Inserting(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)

    Dim insertedKey As SqlParameter  
    insertedKey = New SqlParameter("@PK_New", SqlDbType.Int)
    insertedKey.Direction    = ParameterDirection.Output     
    
    e.Command.Parameters.Add(insertedKey)

 End Sub 'On_Inserting

 Sub On_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
    Dim command As DbCommand 
    command = e.Command
    
    ' The label displays the primary key of the recently inserted row.
    Label1.Text = command.Parameters("@PK_New").Value.ToString()    
    
    ' Explicitly call DataBind to refresh the data
    ' and show the newly inserted row.
    GridView1.DataBind()
 End Sub 'On_Inserted

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:GridView
        id="GridView1"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="EmployeeID"        
        DataSourceID="SqlDataSource1">
        <columns>          
          <asp:BoundField HeaderText="First Name" DataField="FirstName" />
          <asp:BoundField HeaderText="Last Name" DataField="LastName" />
          <asp:BoundField HeaderText="Title" DataField="Title" />
          <asp:ButtonField ButtonType="Link" CommandName="Select" Text="Details..." />
        </columns>
      </asp:GridView>

      <asp:SqlDataSource
        id="SqlDataSource1"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:MyNorthwind %>"
        SelectCommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees">
      </asp:SqlDataSource>

      <hr />

      <asp:DetailsView
        id="DetailsView1"
        runat="server"
        DataSourceID="SqlDataSource2"
        AutoGenerateRows="False"
        AutoGenerateInsertButton="True">
        <fields>
          <asp:BoundField HeaderText="First Name" DataField="FirstName" ReadOnly="False"/>
          <asp:BoundField HeaderText="Last Name" DataField="LastName" ReadOnly="False"/>
          <asp:TemplateField HeaderText="Title">
            <ItemTemplate>
              <asp:DropDownList
                id="TitleDropDownList"
                runat="server"
                selectedvalue="<%# Bind('Title') %>" >
                <asp:ListItem Selected="True">Sales Representative</asp:ListItem>
                <asp:ListItem>Sales Manager</asp:ListItem>
                <asp:ListItem>Vice President, Sales</asp:ListItem>
              </asp:DropDownList>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField HeaderText="Notes" DataField="Notes" ReadOnly="False"/>
        </fields>
      </asp:DetailsView>


      <asp:SqlDataSource
        id="SqlDataSource2"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
        SelectCommand="SELECT * FROM Employees"
        InsertCommandType = "StoredProcedure"
        InsertCommand="sp_insertemployee"        
        OnInserting="On_Inserting"
        OnInserted ="On_Inserted"
        FilterExpression="EmployeeID={0}">
        <FilterParameters>
          <asp:ControlParameter Name="EmployeeID" ControlId="GridView1" PropertyName="SelectedValue" />
        </FilterParameters>
      </asp:SqlDataSource>

<!-- 
     -- An example sp_insertemployee stored procedure that returns
     -- the primary key of the row that was inserted in an OUT parameter.
     CREATE PROCEDURE sp_insertemployee 
        @FirstName nvarchar(10), 
        @LastName nvarchar(20) , 
        @Title nvarchar(30), 
        @Notes nvarchar(200), 
        @PK_New int OUTPUT
      AS
        INSERT INTO Employees(FirstName,LastName,Title,Notes)VALUES (@FirstName,@LastName,@Title,@Notes)
        SELECT @PK_New = @@IDENTITY
        RETURN (1)    
      GO
-->      

      <asp:Label 
        id="Label1"
        runat="server" />
      
    </form>
  </body>
</html>
<!-- </Snippet1> -->