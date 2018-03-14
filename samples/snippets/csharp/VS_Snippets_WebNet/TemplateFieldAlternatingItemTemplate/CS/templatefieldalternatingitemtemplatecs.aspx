<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField AlternatingItemTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField AlternatingItemTemplate Example</h3>

      <!-- Populate the Columns collection declaratively.    -->
      <!-- Create a TemplateField field column that has both      -->
      <!-- an  item template and an alternating item template.    -->
      <!-- The item template displays an author's image on the    -->
      <!-- left side of the column, while the alternating item    -->
      <!-- template displays an author's image on the right side. -->
      
      <!-- For this example, the zip field is used for the        -->
      <!-- values of the image URL. For your application, you     -->
      <!-- should use a field that contains valid URLs to         -->
      <!-- images.                                                -->
      <asp:gridview id="AuthorsGridView" 
        datasourceid="AuthorsSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">
                
        <columns>
                
          <asp:templatefield headertext="Author">
            <itemtemplate>
              <asp:image id="LeftAuthorImage"
                imageurl='<%# Eval("zip") %>'
                alternatetext="Author Photo"  
                runat="server"/>
              <asp:label id="LeftFirstNameLabel"
                text= '<%# Eval("au_fname") %>'
                runat="server"/> 
              <asp:label id="LeftLastNameLabel"
                text= '<%# Eval("au_lname") %>'
                runat="server"/>
            </itemtemplate>
            <alternatingitemtemplate>
              <asp:label id="RightFirstNameLabel"
                text= '<%# Eval("au_fname") %>'
                runat="server"/> 
              <asp:label id="RightLastNameLabel"
                text= '<%# Eval("au_lname") %>'
                runat="server"/>
              <asp:image id="RightAuthorImage"
                imageurl='<%# Eval("zip") %>'
                alternatetext="Author Photo"
                runat="server"/>
            </alternatingitemtemplate>
          </asp:templatefield>
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="AuthorsSqlDataSource"  
        selectcommand="SELECT [au_lname], [au_fname], [zip] FROM [authors]"
        connectionstring="server=localhost;database=pubs;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->