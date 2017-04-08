<!--<Snippet1> -->
<%@ Page Language="VB" Debug="true" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Services.Discovery" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Data" %>

<HTML>
<HEAD>
   <SCRIPT RUNAT="SERVER">

   Public Sub Discover_Click(Source As Object, e as EventArgs )
      ' Specify the URL to discover.
      Dim sourceUrl as String = DiscoURL.Text

      Dim client as DiscoveryClientProtocol = new DiscoveryClientProtocol()
      ' Use default credentials to access the URL being discovered.
      client.Credentials = CredentialCache.DefaultCredentials
      Try 
       	Dim doc As DiscoveryDocument
        ' Discover the URL for any discoverable documents. 
        doc = client.DiscoverAny(sourceUrl)

       Catch e2 As Exception
       	  DiscoveryResultsGrid.Columns.Clear()
          Status.Text = e2.Message
       End Try

       ' If the discovered document contained references, display them in a data grid.
       If (client.References.Count > 0) Then
            'populate our Grid with the discovery results
	    PopulateGrid(client)
       End If

  End Sub

  Public Sub PopulateGrid(client As DiscoveryClientProtocol) 
    Dim dt As DataTable = new DataTable()
    Dim dr AS DataRow 
 
    dt.Columns.Add(new DataColumn("Reference") )
    dt.Columns.Add(new DataColumn("Type") )

    Dim entry As DictionaryEntry
	 
    ' Iterate over the references in the discovered document, displaying their type.
    For Each entry in client.References
       dr = dt.NewRow()
       dr(0) = entry.Key
       dr(1) = entry.Value.GetType()
       dt.Rows.Add(dr)
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