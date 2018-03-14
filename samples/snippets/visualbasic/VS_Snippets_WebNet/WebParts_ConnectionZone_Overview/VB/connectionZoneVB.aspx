<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuVB"
    src="~/displaymodemenuvb.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_PreRender(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    ' Set properties for verbs.
    connectionsZone1.CancelVerb.Description = _
      "Terminates the connection process"
    connectionsZone1.CloseVerb.Description = _
      "Closes the connections UI"
    connectionsZone1.ConfigureVerb.Description = _
      "Configure the transformer for the connection"
    connectionsZone1.ConnectVerb.Description = _
      "Connect two WebPart controls"
    connectionsZone1.DisconnectVerb.Description = _
      "End the connection between two controls"
    
    ' Set properties for UI text strings.
    connectionsZone1.ConfigureConnectionTitle = _
      "Configure a new connection"
    connectionsZone1.ConnectToConsumerInstructionText = _
      "Choose a consumer connection point"
    connectionsZone1.ConnectToConsumerText = _
      "Select a consumer for the provider to connect with"
    connectionsZone1.ConnectToConsumerTitle = _
      "Send data to this consumer"
    connectionsZone1.ConnectToProviderInstructionText = _
      "Choose a provider connection point"
    connectionsZone1.ConnectToProviderText = _
      "Select a provider for the consumer to connect with"
    connectionsZone1.ConnectToProviderTitle = _
      "Get data from this provider"
    connectionsZone1.ConsumersInstructionText = _
      "WebPart controls that receive data from providers"
    connectionsZone1.ConsumersTitle = "Consumer Controls"
    connectionsZone1.GetFromText = "Receive from"
    connectionsZone1.GetText = "Retrieve"
    connectionsZone1.HeaderText = _
      "Create and Manage Connections"
    connectionsZone1.InstructionText = _
      "Manage connections for the selected WebPart control"
    connectionsZone1.InstructionTitle = _
      "Manage connections for consumers or providers"
    connectionsZone1.NoExistingConnectionInstructionText = _
      "No connections exist. Click the above link to create " _
      & "a connection."
    connectionsZone1.NoExistingConnectionTitle = _
      "No current connections"
    connectionsZone1.ProvidersInstructionText = _
      "WebPart controls that send data to consumers"
    connectionsZone1.ProvidersTitle = "Provider controls"

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Connection Zone Sample</title>
</head>
<body>
  <form id="form1" runat="server">
  <asp:webpartmanager runat="server" id="mgr">
    <staticconnections>
      <asp:webpartconnection id="connection1" 
        consumerconnectionpointid="ZipCodeConsumer"
        consumerid="zipConsumer"
        providerconnectionpointid="ZipCodeProvider" 
        providerid="zipProvider" />
    </staticconnections>
  </asp:webpartmanager>
  <uc1:displaymodemenuvb id="menu1" runat="server" />
  <div>
  <asp:webpartzone id="WebPartZone1" runat="server">
    <zonetemplate>
      <aspsample:zipcodewebpart id="zipProvider" runat="server" 
        Title="Zip Code Provider" />
      <aspsample:weatherwebpart id="zipConsumer" runat="server" 
        Title="Zip Code Consumer" />
    </zonetemplate>
  </asp:webpartzone>
  <asp:connectionszone id="connectionsZone1" runat="server" >
    <cancelverb text="Terminate" />
    <closeverb text="Close Zone" />
    <configureverb text="Configure" />
    <connectverb text="Connect Controls" />
    <disconnectverb text="End Connection" />
  </asp:connectionszone>
  </div>
  </form>
</body>
</html>
<!-- </snippet1> -->