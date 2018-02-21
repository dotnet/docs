---
title: "Routing Introduction"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bf6ceb38-6622-433b-9ee7-f79bc93497a1
caps.latest.revision: 11
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Routing Introduction
The Routing Service provides a generic pluggable SOAP intermediary that is capable of routing messages based on message content. With the Routing Service, you can create complex routing logic that allows you to implement scenarios such as service aggregation, service versioning, priority routing, and multicast routing. The Routing Service also provides error handling that allows you to set up lists of backup endpoints, to which messages are sent if a failure occurs when sending to the primary destination endpoint.  
  
 This topic is intended for those new to the Routing Service and covers basic configuration and hosting of the Routing Service.  
  
## Configuration  
 The Routing Service is implemented as a WCF service that exposes one or more service endpoints that receive messages from client applications and route the messages to one or more destination endpoints. The service provides a <xref:System.ServiceModel.Routing.RoutingBehavior>, which is applied to the service endpoints exposed by the service. This behavior is used to configure various aspects of how the service operates. For ease of configuration when using a configuration file, the parameters are specified on the **RoutingBehavior**. In code-based scenarios, these parameters would be specified as part of a <xref:System.ServiceModel.Routing.RoutingConfiguration> object, which can then be passed to a **RoutingBehavior**.  
  
 When starting, this behavior adds the <xref:System.ServiceModel.Routing.SoapProcessingBehavior>, which is used to perform SOAP processing of messages, to the client endpoints. This allows the Routing Service to transmit messages to endpoints that require a different **MessageVersion** than the endpoint the message was received over. The **RoutingBehavior** also registers a service extension, the <xref:System.ServiceModel.Routing.RoutingExtension>, which provides an accessibility point for modifying the Routing Service configuration at run time.  
  
 The **RoutingConfiguration** class provides a consistent means of configuring and updating the configuration of the Routing Service.  It contains parameters that act as the settings for the Routing Service and is used to configure the **RoutingBehavior** when the service starts, or is passed to the **RoutingExtension** to modify routing configuration at run time.  
  
 The routing logic used to perform content-based routing of messages is defined by grouping multiple <xref:System.ServiceModel.Dispatcher.MessageFilter> objects together into filter tables (<xref:System.ServiceModel.Dispatcher.MessageFilterTable%601> objects). Incoming messages are evaluated against the message filters contained in the filter table, and for each **MessageFilter** that matches the message, forwarded to a destination endpoint. The filter table that should be used to route messages is specified by using either the **RoutingBehavior** in configuration or through code by using the **RoutingConfiguration** object.  
  
### Defining Endpoints  
 While it may seem that you should start your configuration by defining the routing logic you will use, your first step should actually be to determine the shape of the endpoints you will be routing messages to. The Routing Service uses contracts that define the shape of the channels used to receive and send messages, and therefore the shape of the input channel must match that of the output channel.  For example, if you are routing to endpoints that use the request-reply channel shape, then you must use a compatible contract on the inbound endpoints, such as the <xref:System.ServiceModel.Routing.IRequestReplyRouter>.  
  
 This means that if your destination endpoints use contracts with multiple communication patterns (such as mixing one-way and two-way operations,) you cannot create a single service endpoint that can receive and route messages to all of them. You must determine which endpoints have compatible shapes and define one or more service endpoints that will be used to receive messages to be routed to the destination endpoints.  
  
> [!NOTE]
>  When working with contracts that specify multiple communication patterns (such as a mix of one-way and two-way operations,) a workaround is to use a duplex contract at the Routing Service such as <xref:System.ServiceModel.Routing.IDuplexSessionRouter>. However this means that the binding must be capable of duplex communication, which may not be possible for all scenarios. In scenarios where this is not possible, factoring the communication into multiple endpoints or modifying the application may be necessary.  
  
 For more information about routing contracts, see [Routing Contracts](../../../../docs/framework/wcf/feature-details/routing-contracts.md).  
  
 After the service endpoint is defined, you can use the **RoutingBehavior** to associate a specific **RoutingConfiguration** with the endpoint. When configuring the Routing Service by using a configuration file, the **RoutingBehavior** is used to specify the filter table that contains the routing logic used to process messages received on this endpoint. If you are configuring the Routing Service programmatically you can specify the filter table by using the **RoutingConfiguration**.  
  
 The following example defines the service and client endpoints that are used by the Routing Service both programmatically and by using a configuration file.  
  
```xml  
    <services>  
      <!--ROUTING SERVICE -->  
      <service behaviorConfiguration="routingData"  
               name="System.ServiceModel.Routing.RoutingService">  
        <host>  
          <baseAddresses>  
            <add baseAddress="http://localhost:8000/routingservice/router"/>  
          </baseAddresses>  
        </host>  
        <!-- Define the service endpoints that are receive messages -->  
        <endpoint address=""  
                  binding="wsHttpBinding"  
                  name="reqReplyEndpoint"  
                  contract="System.ServiceModel.Routing.IRequestReplyRouter" />      
      </service>  
    </services>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="routingData">  
          <serviceMetadata httpGetEnabled="True"/>  
          <!-- Add the RoutingBehavior and specify the Routing Table to use -->  
          <routing filterTableName="routingTable1" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
    <client>  
    <!-- Define the client endpoint(s) to route messages to -->  
      <endpoint name="CalculatorService"  
                address="http://localhost:8000/servicemodelsamples/service"  
                binding="wsHttpBinding" contract="*" />  
    </client>  
```  
  
```csharp  
//set up some communication defaults  
string clientAddress = "http://localhost:8000/servicemodelsamples/service";  
string routerAddress = "http://localhost:8000/routingservice/router";  
Binding routerBinding = new WSHttpBinding();  
Binding clientBinding = new WSHttpBinding();  
//add the endpoint the router uses to receive messages  
serviceHost.AddServiceEndpoint(  
     typeof(IRequestReplyRouter),   
     routerBinding,   
     routerAddress);  
//create the client endpoint the router routes messages to  
ContractDescription contract = ContractDescription.GetContract(  
     typeof(IRequestReplyRouter));  
ServiceEndpoint client = new ServiceEndpoint(  
     contract,   
     clientBinding,   
     new EndpointAddress(clientAddress));  
//create a new routing configuration object  
RoutingConfiguration rc = new RoutingConfiguration();  
….  
rc.FilterTable.Add(new MatchAllMessageFilter(), endpointList);  
//attach the behavior to the service host  
serviceHost.Description.Behaviors.Add(  
     new RoutingBehavior(rc));  
```  
  
 This example configures the Routing Service to expose a single endpoint with an address of "http://localhost:8000/routingservice/router", which is used to receive messages to be routed. Because the messages are routed to request-reply endpoints, the service endpoint uses the <xref:System.ServiceModel.Routing.IRequestReplyRouter> contract. This configuration also defines a single client endpoint of "http://localhost:8000/servicemodelsample/service" that messages are routed to. The filter table (not shown) named "routingTable1" contains the routing logic used to route messages, and is associated with the service endpoint by using the **RoutingBehavior** (for a configuration file) or **RoutingConfiguration** (for programmatic configuration).  
  
### Routing Logic  
 To define the routing logic used to route messages, you must determine what data contained within the incoming messages can be uniquely acted upon. For example, if all the destination endpoints you are routing to share the same SOAP Actions, the value of the Action contained within the message is not a good indicator of which specific endpoint the message should be routed to. If you must uniquely route messages to one specific endpoint, you should filter upon data that uniquely identifies the destination endpoint that the message is routed to.  
  
 The Routing Service provides several **MessageFilter** implementations that inspect specific values within the message, such as the address, action, endpoint name, or even an XPath query. If none of these implementations meet your needs you can create a custom **MessageFilter** implementation. For more information about message filters and a comparison of the implementations used by the Routing Service, see [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md) and [Choosing a Filter](../../../../docs/framework/wcf/feature-details/choosing-a-filter.md).  
  
 Multiple message filters are organized together into filter tables, which associate each **MessageFilter** with a destination endpoint. Optionally, the filter table can also be used to specify a list of back-up endpoints that the Routing Service will attempt to send the message to in the event of a transmission failure.  
  
 By default all message filters within a filter table are evaluated simultaneously; however, you can specify a <xref:System.ServiceModel.Routing.Configuration.FilterTableEntryElement.Priority%2A> that causes the message filters to be evaluated in a specific order. All entries with the highest priority are evaluated first, and message filters of lower priorities are not evaluated if a match is found at a higher priority level. For more information about filter tables, see [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md).  
  
 The following examples use the <xref:System.ServiceModel.Dispatcher.MatchAllMessageFilter>, which evaluates to `true` for all messages. This **MessageFilter** is added to the "routingTable1" filter table, which associates the **MessageFilter** with the client endpoint named "CalculatorService". The **RoutingBehavior** then specifies that this table should be used to route messages processed by the service endpoint.  
  
```xml  
<behaviors>  
  <serviceBehaviors>  
    <behavior name="routingData">  
      <serviceMetadata httpGetEnabled="True"/>  
      <!-- Add the RoutingBehavior and specify the Routing Table to use -->  
      <routing filterTableName="routingTable1" />  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
<!--ROUTING SECTION -->  
<routing>  
  <filters>  
    <filter name="MatchAllFilter1" filterType="MatchAll" />  
  </filters>  
  <filterTables>  
    <table name="routingTable1">  
      <filters>  
        <add filterName="MatchAllFilter1" endpointName="CalculatorService" />  
      </filters>  
    </table>  
  </filterTables>  
</routing>  
```  
  
```csharp  
//create a new routing configuration object  
RoutingConfiguration rc = new RoutingConfiguration();  
//create the endpoint list that contains the endpoints to route to  
//in this case we have only one  
List<ServiceEndpoint> endpointList = new List<ServiceEndpoint>();  
endpointList.Add(client);  
//add a MatchAll filter to the Router's filter table  
//map it to the endpoint list defined earlier  
//when a message matches this filter, it is sent to the endpoint contained in the list  
rc.FilterTable.Add(new MatchAllMessageFilter(), endpointList);  
```  
  
> [!NOTE]
>  By default, the Routing Service only evaluates the headers of the message. To allow the filters to access the message body, you must set <xref:System.ServiceModel.Routing.RoutingConfiguration.RouteOnHeadersOnly%2A> to `false`.  
  
 **Multicast**  
  
 While many Routing Service configurations use exclusive filter logic that routes messages to only one specific endpoint, you may need to route a given message to multiple destination endpoints. To multicast a message to multiple destinations, the following conditions must be true:  
  
-   The channel shape must not be request-reply (though may be one-way or duplex,) because only one reply can be received by the client application in response to the request.  
  
-   Multiple filters must return `true` when evaluating the message.  
  
 If these conditions are met, the message is routed to all endpoints of all filters that evaluate to `true`. The following example defines a routing configuration that results in messages being routed to both endpoints if the endpoint address in the message is http://localhost:8000/routingservice/router/rounding.  
  
```xml  
<!--ROUTING SECTION -->  
<routing>  
  <filters>  
    <filter name="MatchAllFilter1" filterType="MatchAll" />  
    <filter name="RoundingFilter1" filterType="EndpointAddress"  
            filterData="http://localhost:8000/routingservice/router/rounding" />  
  </filters>  
  <filterTables>  
    <table name="routingTable1">  
      <filters>  
        <add filterName="MatchAllFilter1" endpointName="CalculatorService" />  
        <add filterName="RoundingFilter1" endpointName="RoundingCalcService" />  
      </filters>  
    </table>  
  </filterTables>  
</routing>  
```  
  
```csharp  
rc.FilterTable.Add(new MatchAllMessageFilter(), calculatorEndpointList);  
rc.FilterTable.Add(new EndpointAddressMessageFilter(new EndpointAddress(  
    "http://localhost:8000/routingservice/router/rounding")),  
    roundingCalcEndpointList);  
```  
  
### SOAP Processing  
 To support the routing of messages between dissimilar protocols, the **RoutingBehavior** by default adds the <xref:System.ServiceModel.Routing.SoapProcessingBehavior> to all client endpoint(s) that messages are routed to. This behavior automatically creates a new **MessageVersion** before routing the message to the endpoint, as well as creating a compatible **MessageVersion** for any response document before returning it to the requesting client application.  
  
 The steps taken to create a new **MessageVersion** for the outbound message are as follows:  
  
 **Request processing**  
  
-   Get the **MessageVersion** of the outbound binding/channel.  
  
-   Get the body reader for the original message.  
  
-   Create a new message with the same action, body reader, and a new **MessageVersion**.  
  
-   If <xref:System.ServiceModel.Channels.MessageVersion.Addressing%2A> != **Addressing.None**, copy the To, From, FaultTo, and RelatesTo headers to the new message.  
  
-   Copy all message properties to the new message.  
  
-   Store the original request message to use when processing the response.  
  
-   Return the new request message.  
  
 **Response processing**  
  
-   Get the **MessageVersion** of the original request message.  
  
-   Get the body reader for the received response message.  
  
-   Create a new response message with the same action, body reader, and the **MessageVersion** of the original request message.  
  
-   If <xref:System.ServiceModel.Channels.MessageVersion.Addressing%2A> != **Addressing.None**, copy the To, From, FaultTo, and RelatesTo headers to the new message.  
  
-   Copy the message properties to the new message.  
  
-   Return the new response message.  
  
 By default, the **SoapProcessingBehavior** is automatically added to the client endpoints by the <xref:System.ServiceModel.Routing.RoutingBehavior> when the service starts; however, you can control whether SOAP processing is added to all client endpoints by using the <xref:System.ServiceModel.Routing.RoutingConfiguration.SoapProcessingEnabled%2A> property. You can also add the behavior directly to a specific endpoint and enable or disable this behavior at the endpoint level if a more granular control of SOAP processing is required.  
  
> [!NOTE]
>  If SOAP processing is disabled for an endpoint that requires a different MessageVersion than that of the original request message, you must provide a custom mechanism for performing any SOAP modifications that are required before sending the message to the destination endpoint.  
  
 In the following examples, the **soapProcessingEnabled** property is used to prevent the **SoapProcessingBehavior** from being automatically added to all client endpoints.  
  
```xml  
<behaviors>  
  <!--default routing service behavior definition-->  
  <serviceBehaviors>  
    <behavior name="routingConfiguration">  
      <routing filterTableName="filterTable1" soapProcessingEnabled="false"/>  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
```csharp  
//create the default RoutingConfiguration  
RoutingConfiguration rc = new RoutingConfiguration();  
rc.SoapProcessingEnabled = false;  
```  
  
### Dynamic Configuration  
 When you add additional client endpoints, or need to modify the filters that are used to route messages, you must have a way to update the configuration dynamically at run time to prevent interrupting the service to the endpoints currently receiving messages through the Routing Service. Modifying a configuration file or the code of the host application is not always sufficient, because either method requires recycling the application, which would lead to the potential loss of any messages currently in transit and the potential for downtime while waiting on the service to restart.  
  
 You can only modify the **RoutingConfiguration** programmatically. While you can initially configure the service by using a configuration file, you can only modify the configuration at run time by constructing a new **RoutingConfigution** and passing it as a parameter to the <xref:System.ServiceModel.Routing.RoutingExtension.ApplyConfiguration%2A> method exposed by the <xref:System.ServiceModel.Routing.RoutingExtension> service extension. Any messages currently in transit continue to be routed using the previous configuration, while messages received after the call to **ApplyConfiguration** use the new configuration. The following example demonstrates creating an instance of the Routing Service and then subsequently modifying the configuration.  
  
```csharp  
RoutingConfiguration routingConfig = new RoutingConfiguration();  
routingConfig.RouteOnHeadersOnly = true;  
routingConfig.FilterTable.Add(new MatchAllMessageFilter(), endpointList);  
RoutingBehavior routing = new RoutingBehavior(routingConfig);  
routerHost.Description.Behaviors.Add(routing);  
routerHost.Open();  
// Construct a new RoutingConfiguration  
RoutingConfiguration rc2 = new RoutingConfiguration();  
ServiceEndpoint clientEndpoint = new ServiceEndpoint();  
ServiceEndpoint clientEndpoint2 = new ServiceEndpoint();  
// Add filters to the FilterTable in the new configuration  
rc2.FilterTable.add(new MatchAllMessageFilter(),  
       new List<ServiceEndpoint>() { clientEndpoint });  
rc2.FilterTable.add(new MatchAllMessageFilter(),  
       new List<ServiceEndpoint>() { clientEndpoint2 });  
rc2.RouteOnHeadersOnly = false;  
// Apply the new configuration to the Routing Service hosted in  
routerHost.routerHost.Extensions.Find<RoutingExtension>().ApplyConfiguration(rc2);  
```  
  
> [!NOTE]
>  When updating the Routing Service in this manner it is only possible to pass a new configuration. It is not possible to modify only select elements of the current configuration or append new entries to the current configuration; you must create and pass a new configuration that replaces the existing one.  
  
> [!NOTE]
>  Any sessions opened using the previous configuration continue using the previous configuration. The new configuration is only used by new sessions.  
  
## Error Handling  
 If any <xref:System.ServiceModel.CommunicationException> is encountered while attempting to send a message, error handling take place. These exceptions typically indicate that a problem was encountered while attempting to communicate with the defined client endpoint, such as an <xref:System.ServiceModel.EndpointNotFoundException>, <xref:System.ServiceModel.ServerTooBusyException>, or <xref:System.ServiceModel.CommunicationObjectFaultedException>. The error handling-code will also catch and attempt to retry sending when a <xref:System.TimeoutException> occurs, which is another common exception that is not derived from **CommunicationException**.  
  
 When one of the preceding exceptions occurs, the Routing Service fails over to a list of backup endpoints. If all backup endpoints fail with a communications failure, or if an endpoint returns an exception that indicates a failure within the destination service, the Routing Service returns a fault to the client application.  
  
> [!NOTE]
>  The error-handling functionality captures and handles exceptions that occur when attempting to send a message and when attempting to close a channel. The error-handling code is not intended to detect or handle exceptions created by the application endpoints it is communicating with; a <xref:System.ServiceModel.FaultException> thrown by a service appears at the Routing Service as a **FaultMessage** and is flowed back to the client.  
>   
>  If an error occurs when the routing service tries to relay a message, you may  get a <xref:System.ServiceModel.FaultException> on the client side, rather than a <xref:System.ServiceModel.EndpointNotFoundException> you would normally get in the absence of the routing service. A routing service may thus mask exceptions and not provide full transparency unless you examine nested exceptions.  
  
### Tracing Exceptions  
 When sending a message to an endpoint in a list fails, the Routing Service traces the resulting exception data and attaches the exception details as a message property named **Exceptions**. This preserves the exception data and allows a user programmatic access through a message inspector.  The exception data is stored per message in a dictionary that maps the endpoint name to the exception details encountered when trying to send a message to it.  
  
### Backup Endpoints  
 Each filter entry within the filter table can optionally specify a list of backup endpoints, which are used in the event of a transmission failure when sending to the primary endpoint. If such a failure occurs, the Routing Service attempts to transmit the message to the first entry in the backup endpoint list. If this send attempt also encounters a transmission failure, the next endpoint in the backup list is tried. The Routing Service continues sending the message to each endpoint in the list until the message is successfully received, all endpoints return a transmission failure, or a non-transmission failure is returned by an endpoint.  
  
 The following examples configure the Routing Service to use a backup list.  
  
```xml  
<routing>  
  <filters>  
    <!-- Create a MatchAll filter that catches all messages -->  
    <filter name="MatchAllFilter1" filterType="MatchAll" />  
  </filters>  
  <filterTables>  
    <!-- Set up the Routing Service's Message Filter Table -->  
    <filterTable name="filterTable1">  
        <!-- Add an entry that maps the MatchAllMessageFilter to the dead destination -->  
        <!-- If that endpoint is down, tell the Routing Service to try the endpoints -->  
        <!-- Listed in the backupEndpointList -->  
        <add filterName="MatchAllFilter1" endpointName="deadDestination" backupList="backupEndpointList"/>  
    </filterTable>  
  </filterTables>  
  <!-- Create the backup endpoint list -->  
  <backupLists>  
    <!-- Add an endpoint list that contains the backup destinations -->  
    <backupList name="backupEndpointList">  
      <add endpointName="realDestination" />  
      <add endpointName="backupDestination" />  
    </backupList>  
  </backupLists>  
</routing>  
```  
  
```csharp  
//create the endpoint list that contains the service endpoints we want to route to  
List<ServiceEndpoint> backupList = new List<ServiceEndpoint>();  
//add the endpoints in the order that the Routing Service should contact them  
//first add the endpoint that we know is down  
//clearly, normally you wouldn't know that this endpoint was down by default  
backupList.Add(fakeDestination);  
//then add the real Destination endpoint  
//the Routing Service attempts to send to this endpoint only if it   
//encounters a TimeOutException or CommunicationException when sending  
//to the previous endpoint in the list.  
backupList.Add(realDestination);  
//add the backupDestination endpoint  
//the Routing Service attempts to send to this endpoint only if it  
//encounters a TimeOutException or CommunicationsException when sending  
//to the previous endpoints in the list  
backupList.Add(backupDestination);  
//create the default RoutingConfiguration option              
RoutingConfiguration rc = new RoutingConfiguration();  
//add a MatchAll filter to the Routing Configuration's filter table  
//map it to the list of endpoints defined above  
//when a message matches this filter, it is sent to the endpoints in the list in order  
//if an endpoint is down or does not respond (which the first endpoint won't  
//since the client does not exist), the Routing Service automatically moves the message  
//to the next endpoint in the list and try again.  
rc.FilterTable.Add(new MatchAllMessageFilter(), backupList);  
```  
  
### Supported Error Patterns  
 The following table describes the patterns that are compatible with the use of backup endpoint lists, along with notes describing the details of error handling for specific patterns.  
  
|Pattern|Session|Transaction|Receive Context|Backup List Supported|Notes|  
|-------------|-------------|-----------------|---------------------|---------------------------|-----------|  
|One-Way||||Yes|Attempts to resend the message on a backup endpoint. If this message is being multicast, only the message on the failed channel is moved to its backup destination.|  
|One-Way||![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")||No|An exception is thrown and the transaction is rolled back.|  
|One-Way|||![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|Yes|Attempts to resend the message on a backup endpoint. After the message is successfully received, complete all receive contexts. If the message is not successfully received by any endpoint, do not complete the receive context.<br /><br /> When this message is being multicast, the receive context is only completed if the message is successfully received by at least one endpoint (primary or backup). If none of the endpoints in any of the multicast paths successfully receive the message, do not complete the receive context.|  
|One-Way||![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|Yes|Abort the previous transaction, create a new transaction, and resend all messages. Messages that encountered an error are transmitted to a backup destination.<br /><br /> After a transaction has been created in which all transmissions succeed, complete the receive contexts and commit the transaction.|  
|One-Way|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|||Yes|Attempts to resend the message on a backup endpoint. In a multicast scenario only the messages in a session that encountered an error or in a session whose session close failed are resent to backup destinations.|  
|One-Way|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")||No|An exception is thrown and the transaction is rolled back.|  
|One-Way|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")||![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|Yes|Attempts to resend the message on a backup endpoint. After all message sends complete without error, the session indicates no more messages and the Routing Service successfully closes all outbound session channel(s), all receive contexts are completed, and the inbound session channel is closed.|  
|One-Way|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|Yes|Abort the current transaction and create a new one. Resend all previous messages in the session. After a transaction has been created in which all messages have been successfully sent and the session indicates no more messages, all the outbound session channels are closed, receive contexts are all completed with the transaction, the inbound session channel is closed, and the transaction is committed.<br /><br /> When the sessions are being multicast the messages that had no error are resent to the same destination as before, and messages that encountered an error are sent to backup destinations.|  
|Two-Way||||Yes|Send to a backup destination.  After a channel returns a response message, return the response to the original client.|  
|Two-Way|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|||Yes|Send all messages on the channel to a backup destination.  After a channel returns a response message, return the response to the original client.|  
|Two-Way||![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")||No|An exception is thrown and the transaction is rolled back.|  
|Two-Way|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")||No|An exception is thrown and the transaction is rolled back.|  
|Duplex||||No|Non-session duplex communication is not currently supported.|  
|Duplex|![Check mark](../../../../docs/framework/wcf/feature-details/media/checkmark.gif "Checkmark")|||Yes|Send to a backup destination.|  
  
## Hosting  
 Because the Routing Service is implemented as a WCF service, it must be either self-hosted within an application or hosted by IIS or WAS. It is recommended that the Routing Service be hosted in either IIS, WAS, or a Windows Service application to take advantage of the automatic start and life-cycle management features available in these hosting environments.  
  
 The following example demonstrates hosting the Routing Service in an application.  
  
```csharp  
using (ServiceHost serviceHost =  
                new ServiceHost(typeof(RoutingService)))  
```  
  
 To host the Routing Service within IIS or WAS, you must either create a service file (.svc) or use configuration-based activation of the service. When using a service file, you must specify the <xref:System.ServiceModel.Routing.RoutingService> using the Service parameter. The following example contains a sample service file that can be used to host the Routing Service with IIS or WAS.  
  
```  
<%@ ServiceHost Language="C#" Debug="true" Service="System.ServiceModel.Routing.RoutingService,   
     System.ServiceModel.Routing, version=4.0.0.0, Culture=neutral,   
     PublicKeyToken=31bf3856ad364e35" %>  
```  
  
## Routing Service and Impersonation  
 The WCF Routing Service can be used with impersonation for both sending and receiving messages. All of the usual Windows constraints of impersonation apply. If you would have needed to set up service or account permissions to use impersonation when writing your own service, then you’ll have to do those same steps to use impersonation with the routing service. For more information, see [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
 Impersonation with the routing service requires either the use of ASP.NET impersonation while in ASP.NET compatibility mode or the use of Windows credentials that have been configured to allow impersonation. For more information about ASP.NET compatibility mode, see [WCF Services and ASP.NET](../../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md).  
  
> [!WARNING]
>  The WCF Routing Service does not support impersonation with basic authentication.  
  
 To use ASP.NET impersonation with the routing service, enable ASP.NET compatibility mode on the service hosting environment. The routing service has already been marked as allowing ASP.NET compatibility mode and impersonation will automatically be enabled. Impersonation is the only supported use of ASP.NET integration with the routing service.  
  
 To use Windows credential impersonation with the routing service you need to configure both the credentials and the service. The client credentials object (<xref:System.ServiceModel.Security.WindowsClientCredential>, accessable from the <xref:System.ServiceModel.ChannelFactory>) defines an <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> property that must be set to permit impersonation. Finally, on the service you need to configure the <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior> behavior to set `ImpersonateCallerForAllOperations` to `true`. The routing service uses this flag to decide whether to create the clients for forwarding messages with impersonation enabled.  
  
## See Also  
 [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md)  
 [Routing Contracts](../../../../docs/framework/wcf/feature-details/routing-contracts.md)  
 [Choosing a Filter](../../../../docs/framework/wcf/feature-details/choosing-a-filter.md)
