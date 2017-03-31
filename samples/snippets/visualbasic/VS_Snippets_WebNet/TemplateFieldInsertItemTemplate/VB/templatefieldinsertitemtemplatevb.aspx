<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub StoresGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    ' Set the DataItemIndex property of the DetailsView control to display
    ' the record selected from the GridView control.
        '  StoresDetailView.DataItem = StoresGridView.SelectedIndex
  
  End Sub
  
  Sub StoresDetailView_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs)

    ' Get the state value from the DropDownList control in the 
    ' DetailsView control.
    Dim state As String = GetState()
    
    ' Add the state to the dictionary of values to 
    ' insert into the database.
    e.Values("state") = state
  
  End Sub
  
    Sub StoresDetailView_ItemInserted(ByVal sender As Object, ByVal e As DetailsViewInsertedEventArgs)

        ' Refresh the GridView control after a new record is inserted.
        StoresGridView.DataBind()
   
    End Sub
  
  Function GetState() As String

    Dim state As String
        
    ' Get the DropDownList control that contains the state value
    ' in the DetailsView control.
    Dim list As DropDownList = CType(StoresDetailView.Rows(4).FindControl("StateList"), DropDownList)
    
    If Not list Is Nothing Then

      ' Get the selected value of the DropDownList control.
      state = list.SelectedItem.Text
    
    Else
    
      ' Set the state to an empty string ("").
      state = ""
      
    End If
    
    Return state
  
  End Function

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField InsertItemTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField InsertItemTemplate Example</h3>

        <table cellspacing="10">
            
          <tr>
              
            <td>
                
              <asp:gridview id="StoresGridView" 
                datasourceid="StoresSqlDataSource" 
                autogeneratecolumns="false"
                autogenerateselectbutton="true"
                datakeynames="stor_id"
                onselectedindexchanged="StoresGridView_SelectedIndexChanged"   
                runat="server">
                
                <headerstyle backcolor="Blue"
                  forecolor="White"/>
                
                <columns>
                
                  <asp:boundfield datafield="stor_name"
                    headertext="Store Name"/>
                    
                  <asp:boundfield datafield="stor_address"
                    headertext="Address"/>
                    
                  <asp:boundfield datafield="city"
                    headertext="City"/>
                        
                  <asp:boundfield datafield="state"
                    headertext="State"/>
                    
                  <asp:boundfield datafield="zip"
                    headertext="ZIP Code"/>
                    
                </columns>
                
              </asp:gridview>
            
            </td>
                
            <td valign="top">
                
              <asp:detailsview id="StoresDetailView"
                datasourceid="StoresDetailsSqlDataSource"
                autogenerateinsertbutton="true"
                autogeneraterows="false" 
                datakeynames="stor_id"        
                gridlines="Both"
                oniteminserting="StoresDetailView_ItemInserting"
                oniteminserted="StoresDetailView_ItemInserted"    
                runat="server">
                
                <headerstyle backcolor="Navy"
                  forecolor="White"/>
                                    
                <fields>
                  
                  <asp:boundfield datafield="stor_id"
                    headertext="Store ID"/>
                    
                  <asp:boundfield datafield="stor_name"
                    headertext="Store Name"/>
                    
                  <asp:boundfield datafield="stor_address"
                    headertext="Address"/>
                    
                  <asp:boundfield datafield="city"
                    headertext="City"/>
                        
                  <asp:templatefield headertext="State">
                    <itemtemplate>
                      <%#Eval("state")%>
                    </itemtemplate>
                    <insertitemtemplate>
                      <asp:dropdownlist id="StateList"
                        datasourceid="StateSqlDataSource"
                        datatextfield="state" 
                        runat="server"/>
                    </insertitemtemplate>
                  </asp:templatefield>
                    
                  <asp:boundfield datafield="zip"
                    headertext="ZIP Code"/>
                    
                </fields>
                    
              </asp:detailsview>
            
            </td>
                
          </tr>
            
        </table>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Pubs sample database.                        -->
        <asp:sqldatasource id="StoresSqlDataSource"  
          selectcommand="SELECT [stor_id], [stor_name], [stor_address], [city], [state], [zip] FROM [stores]" 
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
            
        <asp:sqldatasource id="StoresDetailsSqlDataSource"  
          selectcommand="SELECT [stor_id], [stor_name], [stor_address], [city], [state], [zip] FROM [stores]"
          insertcommand="INSERT INTO stores([stor_id], [stor_name], [stor_address], [city], [state], [zip]) VALUES (@stor_id, @stor_name, @stor_address, @city, @state, @zip)" 
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
        
        <!-- For this example, the states are retrieved from the  -->
        <!-- state field. For your application, you should use a  -->
        <!-- more complete source for the state values.           -->
        <asp:sqldatasource id="StateSqlDataSource"  
          selectcommand="SELECT Distinct [state] FROM [stores]"
          connectionstring="server=localhost;database=pubs;integrated security=SSPI"
          runat="server">
        </asp:sqldatasource>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->