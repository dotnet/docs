<!--<Snippet1> -->
<%@ Page Language="C#" Debug="true" %>

<%@ Import Namespace="System.Web.Services.Discovery" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Data" %>

<HTML>
<HEAD>
   <SCRIPT RUNAT="SERVER">
   protected void Discover_Click(object Source, EventArgs e)
   {
	// Specify the URL to discover.
	string sourceUrl = DiscoURL.Text;

        DiscoveryClientProtocol client = new DiscoveryClientProtocol();
	// Use default credentials to access the URL being discovered.
        client.Credentials = CredentialCache.DefaultCredentials;

        try 
        {
       	  DiscoveryDocument doc;
          
          // Discover the URL for any discoverable documents. 
	  doc = client.DiscoverAny(sourceUrl);
        }
        catch ( Exception e2) 
        {
          DiscoveryResultsGrid.Columns.Clear();
          Status.Text = e2.Message;
        }
	// If the discovered document contained, references display them in a data grid.
        if (client.References.Count > 0)
	    PopulateGrid(client);
   }

      protected void PopulateGrid(DiscoveryClientProtocol client) 
      {
         DataTable dt = new DataTable();
         DataRow dr;
 
         dt.Columns.Add(new DataColumn("Reference") );
         dt.Columns.Add(new DataColumn("Type") );

	 // Iterate over the references in the discovered document, displaying their type.
         foreach (DictionaryEntry entry in client.References) 
         {
                dr = dt.NewRow();
  		dr[0] = (string) entry.Key;
		dr[1] = entry.Value.GetType();
		dt.Rows.Add(dr);
         }
        DataView dv = new DataView(dt);
	DiscoveryResultsGrid.DataSource = (ICollection) dv;
	DiscoveryResultsGrid.DataBind();
      
    }
  </SCRIPT>
  </HEAD> 
  <BODY>
	<H3> <p align="center"> Discovery Class Sample </p> </H3>
        <FORM RUNAT="SERVER">
	<hr>	
	 Enter the URL to discover:
        <asp:textbox id=DiscoURL Columns=60 runat="SERVER" /><p>

	<p align="center"> <asp:Button id=Discover Text="Discover!" onClick="Discover_Click" runat="SERVER"/> </p><p>

        <hr>
        <asp:label id="Status" runat="SERVER" /><p>
     <asp:DataGrid id="DiscoveryResultsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="DarkBlue" ForeColor="White">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="LightYellow">
         </AlternatingItemStyle>

     </asp:DataGrid>
        </FORM>
  </BODY>
<!--</Snippet1> -->