<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField Example</h3>

      <!-- Populate the Columns collection declaratively. -->
      <!-- Create a custom TemplateField column that uses      -->
      <!-- two Label controls to display an author's first and -->
      <!-- last name in the same column.                       -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">
                
        <columns>
                
          <asp:templatefield headertext="Author Name">
            <itemtemplate>
              <asp:label id="FirstNameLabel"
                text= '<%# Eval("au_fname") %>'
                runat="server"/> 
              <asp:label id="LastNameLabel"
                text= '<%# Eval("au_lname") %>'
                runat="server"/>
            </itemtemplate>
          </asp:templatefield>
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_lname], [au_fname], [address], [city], [state], [zip], [contract] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->