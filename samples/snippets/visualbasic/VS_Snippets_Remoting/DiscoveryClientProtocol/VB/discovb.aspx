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
      ' Specify the URL to save discovery results to or read from.
      Dim outputDirectory As String = DiscoDir.Text

      Dim client as DiscoveryClientProtocol = new DiscoveryClientProtocol()
      ' Use default credentials to access the URL being discovered.
      client.Credentials = CredentialCache.DefaultCredentials
      Try 
       	Dim doc As DiscoveryDocument
        ' Check to see whether the user wanted to read in existing discovery results.
	If (DiscoverMode.Value = "ReadAll") Then
	   Dim results As DiscoveryClientResultCollection 
           results = client.ReadAll(Path.Combine(DiscoDir.Text,"results.discomap"))
	   SaveMode.Value = "NoSave"						
	Else
	   ' Check to see whether the user user wants the capability to discover any kind of discoverable document.
           If (DiscoverMode.Value = "DiscoverAny") Then
	     doc = client.DiscoverAny(sourceUrl)
           Else
	     ' Discover only discovery documents, which might contain references to other types of discoverable documents. 
   	     doc = client.Discover(sourceUrl)
	   End If
           
           ' Check to see whether the user wants to resolve all possible references from the supplied URL.
 	   If (ResolveMode.Value = "ResolveAll") Then
	      client.ResolveAll()
           ' Check to see whether the user wants to resolve references nested more than one level deep.
	   ElseIf (ResolveMode.Value = "ResolveOneLevel")  Then
              client.ResolveOneLevel()
	   Else
  	      Status.Text = String.Empty
           End If
	End If
            
       Catch e2 As Exception
       	  DiscoveryResultsGrid.Columns.Clear()
          Status.Text = e2.Message
       End Try

       ' If documents were discovered, display the results in a data grid.
       If (client.Documents.Count > 0) Then
            'populate our Grid with the discovery results.
	    PopulateGrid(client)
       End If

       ' If the user also asked to have the results saved to the Web server, do so.	    
       If (SaveMode.Value = "Save") Then
	  Dim results As DiscoveryClientResultCollection 
          results = client.WriteAll(outputDirectory, "results.discomap")
          Status.Text = "The following file holds the links to each of the discovery results: <b>" + _ 
	                                 Path.Combine(outputDirectory,"results.discomap") + "</b>"
       End If                             

      End Sub
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
        Enter the URL to discover:
        <asp:textbox id=DiscoURL Columns=60 runat="SERVER" /><p>

       Discovery Mode:
       <select id="DiscoverMode" size=1 runat="SERVER">
	     <option Value="DiscoverAny">Discover any of the discovery types</option>
             <option Value="Discover">Discover just discovery documents</option>
             <option Value="ReadAll">Read in saved discovery results</option>
	</select> <p>

       Resolve References Mode:
       <select id="ResolveMode" size=1 runat="SERVER">
	      <option Value="ResolveAll">Resolve all references</option>
             <option Value="ResolveOneLevel">Resolve references only in discovery documents within the supplied URL</option>
             <option Value="ResolveNone">Do not resolve references</option>
	</select> <p>
		
       Save Results Mode:
	<select id="SaveMode" size=1 runat="SERVER">
	      <option Value="NoSave">Do not save any of the discovery documents found locally</option>
             <option Value="Save">Save the discovery documents found locally</option>
      	</select> <p>
        Enter the directory to Read/Save the Discovery results:
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
<!--</Snippet1> -->