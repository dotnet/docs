<%@ Page Language="C#" Debug="true" %>

<%@ Import Namespace="System.Web.Services.Discovery" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Data" %>

<HTML>
<HEAD>
   <SCRIPT RUNAT="SERVER">
//<Snippet1>
   protected void Discover_Click(object Source, EventArgs e)
   {
	// Specify the URL to read the discovery results from.
	string outputDirectory = DiscoDir.Text;

        DiscoveryClientProtocol client = new DiscoveryClientProtocol();
	// Use default credentials to access the files containing the discovery results.
        client.Credentials = CredentialCache.DefaultCredentials;

        try {
       	  DiscoveryDocument doc;
	  // Read in existing discovery results.
          DiscoveryClientResultCollection results = client.ReadAll(Path.Combine(DiscoDir.Text,"results.discomap"));
        }
        catch ( Exception e2) 
        {
          DiscoveryResultsGrid.Columns.Clear();
          Status.Text = e2.Message;
        }
	// If discovery documents existed in the supplied folder, display the results in a data grid.
        if (client.Documents.Count > 0)
	    PopulateGrid(client);
  }
//</Snippet1>
      protected void PopulateGrid(DiscoveryClientProtocol client) 
      {
         DataTable dt = new DataTable();
         DataRow dr;
 
         dt.Columns.Add(new DataColumn("Discovery Document") );
         dt.Columns.Add(new DataColumn("References") );
         dt.Columns.Add(new DataColumn("Type") );


         foreach (DictionaryEntry entry in client.Documents) 
         {
                dr = dt.NewRow();
  		dr[0] = (string) entry.Key;
		dr[2] = entry.Value.GetType();
		dt.Rows.Add(dr);
		if (entry.Value is DiscoveryDocument)
		{
	  	  DiscoveryDocument discoDoc = (DiscoveryDocument) entry.Value;
		  foreach (DiscoveryReference discoref in discoDoc.References)
		  {
		    dr = dt.NewRow();
		    dr[1] = discoref.Url;
		    dr[2] = discoref.GetType();
		    dt.Rows.Add(dr);
		   }
		}
		
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

        Enter the directory to Read the Discovery results:
        <asp:textbox id=DiscoDir runat="SERVER" /> <p>

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