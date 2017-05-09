<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register tagprefix="uc1" 
    tagname="DisplayModeMenuCS"
    src="~/displaymodemenucs.ascx" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_PreRender(object sender, EventArgs e)
  {
     // Set properties on verbs.
     connectionsZone1.CancelVerb.Description = 
       "Terminates the connection process";
     connectionsZone1.CloseVerb.Description = 
       "Closes the connections UI";
     connectionsZone1.ConfigureVerb.Description =
       "Configure the transformer for the connection";
     connectionsZone1.ConnectVerb.Description =
       "Connect two WebPart controls";
     connectionsZone1.DisconnectVerb.Description =
       "End the connection between two controls";
    
     // Set properties for UI text strings.
     connectionsZone1.ConfigureConnectionTitle = 
       "Configure";
     connectionsZone1.ConnectToConsumerInstructionText = 
       "Choose a consumer connection point";
     connectionsZone1.ConnectToConsumerText = 
       "Select a consumer for the provider to connect with";
     connectionsZone1.ConnectToConsumerTitle = 
       "Send data to this consumer";
     connectionsZone1.ConnectToProviderInstructionText =
       "Choose a provider connection point";
     connectionsZone1.ConnectToProviderText =
       "Select a provider for the consumer to connect with";
     connectionsZone1.ConnectToProviderTitle =
       "Get data from this provider";
     connectionsZone1.ConsumersInstructionText = 
       "WebPart controls that receive data from providers";
     connectionsZone1.ConsumersTitle = "Consumer Controls";
     connectionsZone1.GetFromText = "Receive from";
     connectionsZone1.GetText = "Retrieve";
     connectionsZone1.HeaderText = 
      "Create and Manage Connections";
     connectionsZone1.InstructionText = 
      "Manage connections for the selected WebPart control";
     connectionsZone1.InstructionTitle = 
       "Manage connections for consumers or providers";
     connectionsZone1.NoExistingConnectionInstructionText = 
       "No connections exist. Click the above link to create "
       + "a connection.";
     connectionsZone1.NoExistingConnectionTitle = 
       "No current connections";
     connectionsZone1.ProvidersInstructionText =
       "WebPart controls that send data to consumers";
     connectionsZone1.ProvidersTitle = "Provider controls";
     
  }
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
  <uc1:displaymodemenucs id="menu1" runat="server" />
  <div>
  <asp:webpartzone id="WebPartZone1" runat="server">
    <zonetemplate>
      <aspsample:zipcodewebpart id="zipProvider" runat="server" 
        Title="Zip Code Provider"  />
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