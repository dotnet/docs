<%@ page language="VB"%>

<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <head>
    <title>DetailsView Constructor Example</title>
<script runat="server">
    
      Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
        ' Create a new DetailsView object.
        Dim storeDetailsView As New DetailsView()
        
        ' Set the DetailsView object's properties.
        storeDetailsView.ID = "StoresDetailsView"
        storeDetailsView.DataSourceID = "StoresSqlDataSource"
        storeDetailsView.AutoGenerateRows = True
        storeDetailsView.AllowPaging = True
        storeDetailsView.PagerSettings.Mode = _
          PagerButtons.NextPrevious

        ' Add the DetailsView object to the Controls collection
        ' of the PlaceHolder control.
        DetailsViewPlaceHolder.Controls.Add(storeDetailsView)

      End Sub
    
    </script>
  
  </head>
  
  <body>
    <form id="form1" runat="server">
        
      <h3>DetailsView Constructor Example</h3>
        
        <!-- Use a PlaceHolder control as the container for the -->
        <!-- dynamically generated DetailsView control.         -->       
        <asp:PlaceHolder id="DetailsViewPlaceHolder"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Pubs sample database.                        -->  
        <asp:sqldatasource id="StoresSqlDataSource"  
          selectcommand="SELECT [stor_id], [stor_name], [stor_address], 
            [city], [state], [zip] FROM [stores]"
          connectionstring=
            "server=localhost;database=pubs;integrated security=SSPI"
          runat="server">          
        </asp:sqldatasource>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->

