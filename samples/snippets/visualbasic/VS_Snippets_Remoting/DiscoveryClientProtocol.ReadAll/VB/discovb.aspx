<%@ Page Language="VB" Debug="true" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Services.Discovery" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Data" %>

<HTML>
<HEAD>
   <SCRIPT RUNAT="SERVER">
'<Snippet1>
   Public Sub Discover_Click(Source As Object, e as EventArgs )
      ' Specify the URL to read the discovery results from.
      Dim outputDirectory As String = DiscoDir.Text

      Dim client as DiscoveryClientProtocol = new DiscoveryClientProtocol()
      ' Use default credentials to access files containing the previously saved discovery results.
      client.Credentials = CredentialCache.DefaultCredentials
      Try 
       	Dim doc As DiscoveryDocument
     
       ' Read in existing discovery results.
        Dim results As DiscoveryClientResultCollection 
        results = client.ReadAll(Path.Combine(DiscoDir.Text,"results.discomap"))

      Catch e2 As Exception
       	  DiscoveryResultsGrid.Columns.Clear()
          Status.Text = e2.Message
      End Try

      ' If disocvery documents existed in the supplied folder, display the results in a data grid.
       If (client.Documents.Count > 0) Then
            ' Populate the data grid with the discovery results.
	    PopulateGrid(client)
       End If
   End Sub
'</Snippet1>

      Public Sub PopulateGrid(client As DiscoveryClientProtocol) 
         Dim dt As DataTable = new DataTable()
         Dim dr AS DataRow 
 
         dt.Columns.Add(new DataColumn("Discovery Document") )
         dt.Columns.Add(new DataColumn("References") )
         dt.Columns.Add(new DataColumn("Type") )

	 Dim entry As DictionaryEntry
         For Each entry in client.Documents
            dr = dt.NewRow()
 	    dr(0) = entry.Key
 	    dr(2) = entry.Value.GetType()
 	    dt.Rows.Add(dr)
	    If TypeOf entry.Value Is DiscoveryDocument Then
	       Dim discoDoc As DiscoveryDocument = entry.Value
	       Dim discoref As DiscoveryReference
	       For Each discoref in discoDoc.References
		  dr = dt.NewRow()
		  dr(1) = discoref.Url
		  dr(2) = discoref.GetType()
		  dt.Rows.Add(dr)
	       Next
	    End If   
	Next 	
         
        Dim dv As DataView = new DataView(dt)
	DiscoveryResultsGrid.DataSource = dv
	DiscoveryResultsGrid.DataBind()
     End Sub
  </SCRIPT>
  </HEAD> 
  <BODY>
	<H3> <p align="center"> Discovery Class Sample </p> </H3>
        <FORM RUNAT="SERVER">

	<hr>	
        Enter the directory to Read the Discovery results from:
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