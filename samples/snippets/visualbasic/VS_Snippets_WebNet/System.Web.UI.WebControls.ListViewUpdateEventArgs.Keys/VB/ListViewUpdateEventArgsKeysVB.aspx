<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
   
  Sub Page_Load() 
      Message.Text = String.Empty
  End Sub 'Page_Load

  Sub UnitMeasureListView_ItemUpdating(ByVal sender As Object, ByVal e As ListViewUpdateEventArgs)
    ' Use the Keys property to retrieve the key field value
    Dim keyValue As String = e.Keys(0).ToString().Trim()
    
    ' Cancel the update operation if the user attempts to 
    ' edit a protected record. In this example, unit measure
    ' codes with 3 letters are protected.
    If keyValue.Length = 3 Then
      Message.Text = "You cannot update this record. " & _
        " Unit Measure Code " & keyValue & " is protected."
      e.Cancel = True
    End If

  End Sub 'UnitMeasureListView_ItemUpdating

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListViewUpdateEventArgs Keys Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListViewUpdateEventArgs Keys Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>

      <asp:ListView ID="UnitMeasureListView" 
        DataSourceID="UnitMeasureDataSource" 
        DataKeyNames="UnitMeasureCode"
        OnItemUpdating="UnitMeasureListView_ItemUpdating"  
        runat="server">
        <LayoutTemplate>
          <table width="400px" border="1" id="tblUnit">
            <tr runat="server">
              <th runat="server">&nbsp;</th>
              <th runat="server">Unit Measure Code</th>
              <th runat="server">Name</th>
            </tr>
            <tr id="itemPlaceholder" runat="server"></tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
              <asp:Label ID="CodeLabel" runat="server" Text='<%#Eval("UnitMeasureCode") %>' />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <tr style="background-color:#B0C4DE" runat="server">
            <td>
              <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
              <asp:Label ID="CodeLabel" runat="server" Text='<%#Eval("UnitMeasureCode") %>' />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
          </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
          <tr style="background-color:#4682B4">
            <td>
              <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
              <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
              <asp:Label ID="CodeLabel" runat="server" Text='<%#Eval("UnitMeasureCode") %>' />
            </td>
            <td>
              <asp:TextBox ID="NameTextBox" runat="server" Text='<%#Bind("Name") %>' MaxLength="50" /><br />
            </td>
          </tr>
        </EditItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="UnitMeasureDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [UnitMeasureCode], [Name] FROM Production.UnitMeasure"
        UpdateCommand="UPDATE Production.UnitMeasure
                       SET [Name] = @Name
                       WHERE [UnitMeasureCode] = @UnitMeasureCode">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>