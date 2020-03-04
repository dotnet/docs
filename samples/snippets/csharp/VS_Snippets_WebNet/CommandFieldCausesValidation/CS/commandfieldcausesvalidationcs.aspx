<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>CommandField CausesValidation Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>CommandField CausesValidation Example</h3>

      <!-- Normally, the validation controls declared in the            -->
      <!-- EditItemTemplate of each TemplateField field column would    -->
      <!-- prevent the user from leaving a field value empty; however,  -->
      <!-- because the CausesValidation property of the CommandField    -->
      <!-- field column is set to false, validation does not occur when -->
      <!-- the user clicks a button in the CommandField field column.   -->
      <asp:gridview id="CustomerGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        datakeynames="CustomerID"
        cellpadding="10"   
        runat="server">
                
        <columns>
        
          <asp:commandfield showeditbutton="true"
            causesvalidation="false"
            headertext="Edit"/> 
        
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID"
            readonly="true"/>
            
          <asp:templatefield headertext="Company Name"
            itemstyle-verticalalign="Top">
            
            <itemtemplate>
              <%#Eval("CompanyName")%>
            </itemtemplate>
            
            <edititemtemplate>
              <asp:textbox id="CompanyNameTextBox"
                text='<%#Bind("CompanyName")%>'
                width="90"
                runat="server"/>
              <br/>
              <asp:requiredfieldvalidator id="CompanyNameRequiredValidator"
                controltovalidate="CompanyNameTextBox"
                display="Dynamic"
                text="Please enter the company name." 
                runat="server"/>                                      
            </edititemtemplate>
            
          </asp:templatefield>
          
          <asp:templatefield headertext="Address"
            itemstyle-verticalalign="Top">
            
            <itemtemplate>
              <%#Eval("Address")%>
            </itemtemplate>
            
            <edititemtemplate>
              <asp:textbox id="AddressTextBox"
                text='<%#Bind("Address")%>'
                width="90"
                runat="server"/>
              <br/>
              <asp:requiredfieldvalidator id="AddressRequiredValidator"
                controltovalidate="AddressTextBox"
                display="Dynamic"
                text="Please enter the address."
                runat="server"/>                      
            </edititemtemplate>
            
          </asp:templatefield>
          
          <asp:templatefield headertext="City"
            itemstyle-verticalalign="Top">
            
            <itemtemplate>
              <%#Eval("City")%>
            </itemtemplate>
            
            <edititemtemplate>
              <asp:textbox id="CityTextBox"
                text='<%#Bind("City")%>'
                width="90"
                runat="server"/>
              <br/>
              <asp:requiredfieldvalidator id="CityRequiredValidator"
                controltovalidate="CityTextBox"
                display="Dynamic"
                text="Please enter the city."
                runat="server"/>                      
            </edititemtemplate>
            
          </asp:templatefield>
            
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City] From [Customers]"             
        updatecommand="Update [Customers] Set [CompanyName]=@CompanyName, [Address]=@Address, [City]=@City Where [CustomerID] = @CustomerID" 
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->