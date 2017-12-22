---
title: "How To: Use Filters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f2c7255f-c376-460e-aa20-14071f1666e5
caps.latest.revision: 12
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How To: Use Filters
This topic outlines the basic steps required to create a routing configuration that uses multiple filters. In this example, messages are routed to two implementations of a calculator service, regularCalc and roundingCalc. Both implementations support the same operations; however one service rounds all calculations to the nearest integer value before returning. A client application must be able to indicate whether to  use the rounding version of the service; if no service preference is expressed then the message is load balanced between the two services. The operations exposed by both services are:  
  
-   Add  
  
-   Subtract  
  
-   Multiply  
  
-   Divide  
  
 Because both services implement the same operations, you cannot use the Action filter, because the action specified in the message will not be unique. Instead you must do additional work to ensure that the messages are routed to the appropriate endpoints.  
  
### Determine Unique Data  
  
1.  Because both service implementations handle the same operations, and are essentially identical other than the data that they return, the base data contained in messages sent from client applications is not unique enough to allow you to determine how to route the request. But if the client application adds a unique header value to the message, then you can use this value to determine how the message should be routed.  
  
     For this example, if the client application needs the message to be processed by the rounding calculator, it adds a custom header by using the following code:  
  
    ```csharp  
    messageHeadersElement.Add(MessageHeader.CreateHeader("RoundingCalculator",   
                                   "http://my.custom.namespace/", "rounding"));  
    ```  
  
     You can now use the XPath filter to inspect messages for this header, and route messages containing the header to the roundCalc service.  
  
2.  Additionally the Routing Service exposes two virtual service endpoints that can be used with the EndpointName, EndpointAddress, or PrefixEndpointAddress filters to uniquely route incoming messages to a specific calculator implementation based on the endpoint to which the client application submits the request.  
  
### Define Endpoints  
  
1.  When defining the endpoints used by the Routing Service, you should first determine the shape of the channel used by your clients and services. In this scenario both the destination services use a request-reply pattern, so the <xref:System.ServiceModel.Routing.IRequestReplyRouter> is used. The following example defines the service endpoints exposed by the Routing Service.  
  
    ```xml  
    <services>  
          <service behaviorConfiguration="routingConfiguration"  
                   name="System.ServiceModel.Routing.RoutingService">  
            <host>  
              <baseAddresses>  
                <add baseAddress="http://localhost/routingservice/router" />  
              </baseAddresses>  
            </host>  
            <!--Set up the inbound endpoints for the Routing Service-->  
            <!--first create the general router endpoint-->  
            <endpoint address="general"  
                      binding="wsHttpBinding"  
                      name="routerEndpoint"  
                      contract="System.ServiceModel.Routing.IRequestReplyRouter" />  
            <!--create a virtual endpoint for the regular calculator service-->  
            <endpoint address="regular/calculator"  
                      binding="wsHttpBinding"  
                      name="calculatorEndpoint"  
                      contract="System.ServiceModel.Routing.IRequestReplyRouter" />  
            <!--now create a virtual endpoint for the rounding calculator-->  
            <endpoint address="rounding/calculator"  
                      binding="wsHttpBinding"  
                      name="roundingEndpoint"  
                      contract="System.ServiceModel.Routing.IRequestReplyRouter" />  
  
          </service>  
    </services>  
    ```  
  
     With this configuration, the Routing Service exposes three separate endpoints. Depending on run-time choices, the client application sends messages to one of these addresses. Messages arriving at one of the "virtual" service endpoints ("rounding/calculator" or "regular/calculator") are forwarded to the corresponding calculator implementation. If the client application doesn’t send the request to a particular endpoint, the message is addressed to the general endpoint. Regardless of the endpoint chosen, the client application may also choose to include the custom header to indicate that the message should be forwarded to the rounding calculator implementation.  
  
2.  The following example defines the client (destination) endpoints that the Routing Service routes messages to.  
  
    ```xml  
    <client>  
          <endpoint name="regularCalcEndpoint"  
                    address="net.tcp://localhost:9090/servicemodelsamples/service/"  
                    binding="netTcpBinding"  
                    contract="*" />  
  
          <endpoint name="roundingCalcEndpoint"  
                    address="net.tcp://localhost:8080/servicemodelsamples/service/"  
                    binding="netTcpBinding"  
                    contract="*" />  
    </client>  
    ```  
  
     These endpoints are used in the filter table to indicate the destination endpoint the message is sent to when it matches a specific filter.  
  
### Define Filters  
  
1.  To route messages based on the "RoundingCalculator" custom header that the client application adds to the message, define a filter that uses an XPath query to check for the presence of this header. Because this header is defined by using a custom namespace, also add a namespace entry that defines a custom namespace prefix of "custom" that is used in the XPath query. The following example defines the necessary routing section, namespace table, and XPath filter.  
  
    ```xml  
    <routing>  
          <!-- use the namespace table element to define a prefix for our custom namespace-->  
          <namespaceTable>  
            <add prefix="custom" namespace="http://my.custom.namespace/"/>  
          </namespaceTable>  
          <filters>  
            <!--define the different message filters-->  
            <!--define an xpath message filter to look for the custom header coming from the client-->  
            <filter name="XPathFilter" filterType="XPath"   
                    filterData="/s12:Envelope/s12:Header/custom:RoundingCalculator = 'rounding'"/>  
          </filters>  
    </routing>  
    ```  
  
     This **MessageFilter** looks for a RoundingCalculator header in the message that contains a value of "rounding". This header is set by the client to indicate that the message should be routed to the roundingCalc service.  
  
    > [!NOTE]
    >  The s12 namespace prefix is defined by default in the namespace table, and represents the namespace "http://www.w3.org/2003/05/soap-envelope".  
  
2.  You must also define filters that look for messages received on the two virtual endpoints. The first virtual endpoint is the "regular/calculator" endpoint. The client can send requests to this endpoint to indicate that the message should be routed to the regularCalc service. The following configuration defines a filter that uses the <xref:System.ServiceModel.Dispatcher.EndpointNameMessageFilter> to determine if the message arrived through an endpoint with the name specified in filterData.  
  
    ```xml  
    <!--define an endpoint name filter looking for messages that show up on the virtual regular calculator endpoint-->  
    <filter name="EndpointNameFilter" filterType="EndpointName" filterData="calculatorEndpoint"/>  
    ```  
  
     If a message is received by the service endpoint named "calculatorEndpoint", this filter evaluates to `true`.  
  
3.  Next, define a filter that looks for messages sent to the address of the roundingEndpoint. The client can send requests to this endpoint to indicate that the message should be routed to the roundingCalc service. The following configuration defines a filter that uses the <xref:System.ServiceModel.Dispatcher.PrefixEndpointAddressMessageFilter> to determine if the message arrived at the "rounding/calculator" endpoint.  
  
    ```xml  
    <!--define a filter looking for messages that show up with the address prefix.  The corresponds to the rounding calc virtual endpoint-->  
    <filter name="PrefixAddressFilter" filterType="PrefixEndpointAddress"  
            filterData="http://localhost/routingservice/router/rounding/"/>  
    ```  
  
     If a message is received at an address that begins with "http://localhost/routingservice/router/rounding/" then this filter evaluates to **true**. Because the base address used by this configuration is "http://localhost/routingservice/router" and the address specified for the roundingEndpoint is "rounding/calculator", the full address used to communicate with this endpoint is "http://localhost/routingservice/router/rounding/calculator", which matches this filter.  
  
    > [!NOTE]
    >  The PrefixEndpointAddress filter does not evaluate the host name when performing a match, because a single host can be referred to by using a variety of host names that may all be valid ways of referring to the host from the client application. For example, all of the following may refer to the same host:  
    >   
    >  -   localhost  
    > -   127.0.0.1  
    > -   www.contoso.com  
    > -   ContosoWeb01  
  
4.  The final filter must support the routing of messages that arrive at the general endpoint without the custom header. For this scenario, the messages should alternate between the regularCalc and roundingCalc services. To support the "round robin" routing of these messages,  use a custom filter that allows one filter instance to match for each message processed.  The following defines two instances of a RoundRobinMessageFilter, which are grouped together to indicate that they should alternate between each other.  
  
    ```xml  
    <!-- Set up the custom message filters.  In this example,   
         we'll use the example round robin message filter,   
         which alternates between the references-->  
    <filter name="RoundRobinFilter1" filterType="Custom"  
                    customType="CustomFilterAssembly.RoundRobinMessageFilter, CustomFilterAssembly"  
                    filterData="group1"/>  
    <filter name="RoundRobinFilter2" filterType="Custom"  
                    customType="CustomFilterAssembly.RoundRobinMessageFilter, CustomFilterAssembly"  
                    filterData="group1"/>  
    ```  
  
     During run time, this filter type alternates between all defined filter instances of this type that are configured as the same group into one collection. This causes messages processed by this custom filter to alternate between returning `true` for RoundRobinFilter1 and RoundRobinFilter2.  
  
### Define Filter Tables  
  
1.  To associate the filters with specific client endpoints, you must place them within a filter table. This example scenario also uses filter priority settings, which is an optional setting that allows you to indicate the order in which filters are processed. If no filter priority is specified, all filters are evaluated simultaneously.  
  
    > [!NOTE]
    >  While specifying a filter priority allows you to control the order in which filters are processed, it can adversely affect the performance of the Routing Service. When possible, construct filter logic so that the use of filter priorities is not required.  
  
     The following defines the filter table and adds the "XPathFilter" defined earlier to the table with a priority of 2. This entry also specifies that if the "XPathFilter" matches the message, the message will be routed to the "roundingCalcEndpoint"  
  
    ```xml  
    <routing>  
    ...      <filters>  
    ...      </filters>  
          <filterTables>  
            <table name="filterTable1">  
              <entries>  
                <!--add the filters to the message filter table-->  
                <!--first look for the custom header, and if we find it,  
                    send the message to the rounding calc endpoint-->  
                <add filterName="XPathFilter" endpointName="roundingCalcEndpoint" priority="2"/>  
              </entries>  
            </table>  
          <filterTables>  
    </routing>  
    ```  
  
     When specifying a filter priority, the highest priority filters are evaluated first. If one or more filters at a specific priority level match, no filters at lower priority levels will be evaluated. For this scenario, 2 is the highest priority specified and this is the only filter entry at this level.  
  
2.  Filter entries were defined to check to see if a message is received on a specific endpoint by inspecting the endpoint name or the address prefix. The following entries add both of these filter entries to the filter table and associate them with the destination endpoints that the message will be routed to. These filters are set to a priority of 1 to indicate that they should only run if the previous XPath filter did not match the message.  
  
    ```xml  
    <!--if the header wasn't there, send the message based on which virtual endpoint it arrived at-->  
    <!--we determine this through the endpoint name, or through the address prefix-->  
    <add filterName="EndpointNameFilter" endpointName="regularCalcEndpoint" priority="1"/>  
    <add filterName="PrefixAddressFilter" endpointName="roundingCalcEndpoint" priority="1"/>  
    ```  
  
     Because these filters have a filter priority of 1, they will only be evaluated if the filter at priority level 2 does not match the message. Also, because both filters have the same priority level they will be evaluated simultaneously. Because both filters are mutually exclusive, it is possible for only one or the other to match a message.  
  
3.  If a message does not match any of the previous filters, then the message was received through the generic service endpoint and contained no header information that indicates where to route it. These messages are to be handled by the custom filter, which load balances them between the two calculator services. The following example demonstrates how to add the filter entries to the filter table; each filter is associated with one of the two destination endpoints.  
  
    ```xml  
    <!--if none of the other filters have matched,   
        this message showed up on the default router endpoint,   
        with no custom header-->  
    <!--round robin these requests between the two services-->  
    <add filterName="RoundRobinFilter1" endpointName="regularCalcEndpoint" priority="0"/>  
    <add filterName="RoundRobinFilter2" endpointName="roundingCalcEndpoint" priority="0"/>  
    ```  
  
     Because these entries specify a priority of 0, they will only be evaluated if no filter of a higher priority matches the message. Also, since both are of the same priority, they are evaluated simultaneously.  
  
     As mentioned previously, the custom filter used by these filter definitions only evaluates one or the other as `true` for each message received. Because only two filters are defined using this filter, with the same specified group setting, the effect is that the Routing Service alternates between sending to the regularCalcEndpoint and the RoundingCalcEndpoint.  
  
4.  To evaluate messages against the filters, the filter table must first be associated with the service endpoints that will be used to receive messages.  The following example demonstrates how to associate the routing table with the service endpoints by using the routing behavior:  
  
    ```xml  
    <behaviors>  
      <!--default routing service behavior definition-->  
      <serviceBehaviors>  
        <behavior name="routingConfiguration">  
          <routing filterTableName="filterTable1" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
    ```  
  
## Example  
 The following is a complete listing of the configuration file.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<!-- Copyright (c) Microsoft Corporation. All rights reserved -->  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service behaviorConfiguration="routingConfiguration"  
               name="System.ServiceModel.Routing.RoutingService">  
        <host>  
          <baseAddresses>  
            <add baseAddress="http://localhost/routingservice/router" />  
          </baseAddresses>  
        </host>  
        <!--Set up the inbound endpoints for the Routing Service-->  
        <!--first create the general router endpoint-->  
        <endpoint address="general"  
                  binding="wsHttpBinding"  
                  name="routerEndpoint"  
                  contract="System.ServiceModel.Routing.IRequestReplyRouter" />  
        <!--create a virtual endpoint for the regular calculator service-->  
        <endpoint address="regular/calculator"  
                  binding="wsHttpBinding"  
                  name="calculatorEndpoint"  
                  contract="System.ServiceModel.Routing.IRequestReplyRouter" />  
        <!--now create a virtual endpoint for the rounding calculator-->  
        <endpoint address="rounding/calculator"  
                  binding="wsHttpBinding"  
                  name="roundingEndpoint"  
                  contract="System.ServiceModel.Routing.IRequestReplyRouter" />  
  
      </service>  
    </services>  
    <behaviors>  
      <!--default routing service behavior definition-->  
      <serviceBehaviors>  
        <behavior name="routingConfiguration">  
          <routing filterTableName="filterTable1" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  
    <client>  
<!--set up the destination endpoints-->  
      <endpoint name="regularCalcEndpoint"  
                address="net.tcp://localhost:9090/servicemodelsamples/service/"  
                binding="netTcpBinding"  
                contract="*" />  
  
      <endpoint name="roundingCalcEndpoint"  
                address="net.tcp://localhost:8080/servicemodelsamples/service/"  
                binding="netTcpBinding"  
                contract="*" />  
    </client>  
    <routing>  
      <!-- use the namespace table element to define a prefix for our custom namespace-->  
      <namespaceTable>  
        <add prefix="custom" namespace="http://my.custom.namespace/"/>  
      </namespaceTable>  
      <filters>  
        <!--define the different message filters-->  
        <!--define an xpath message filter to look for the custom header coming from the client-->  
        <filter name="XPathFilter" filterType="XPath" filterData="/s12:Envelope/s12:Header/custom:RoundingCalculator = 'rounding'"/>  
  
        <!--define an endpoint name filter looking for messages that show up on the virtual regular calculator endpoint-->  
        <filter name="EndpointNameFilter" filterType="EndpointName" filterData="calculatorEndpoint"/>  
  
        <!--define a filter looking for messages that show up with the address prefix.  The corresponds to the rounding calc virtual endpoint-->  
        <filter name="PrefixAddressFilter" filterType="PrefixEndpointAddress" filterData="http://localhost/routingservice/router/rounding/"/>  
  
        <!--Set up the custom message filters.  In this example, we'll use the example round robin message filter, which alternates between the references-->  
        <filter name="RoundRobinFilter1" filterType="Custom" customType="CustomFilterAssembly.RoundRobinMessageFilter, CustomFilterAssembly" filterData="group1"/>  
        <filter name="RoundRobinFilter2" filterType="Custom" customType="CustomFilterAssembly.RoundRobinMessageFilter, CustomFilterAssembly" filterData="group1"/>  
      </filters>  
      <filterTables>  
        <table name="filterTable1">  
          <entries>  
            <!--add the filters to the message filter table-->  
            <!--first look for the custom header, and if we find it, send the message to the rounding calc endpoint-->  
            <add filterName="XPathFilter" endpointName="roundingCalcEndpoint" priority="2"/>  
  
            <!--if the header wasn't there, send the message based on which virtual endpoint it arrived at-->  
            <!--we determine this through the endpoint name, or through the address prefix-->  
            <add filterName="EndpointNameFilter" endpointName="regularCalcEndpoint" priority="1"/>  
            <add filterName="PrefixAddressFilter" endpointName="roundingCalcEndpoint" priority="1"/>  
  
            <!--if none of the other filters have matched, this message showed up on the default router endpoint, with no custom header-->  
            <!--round robin these requests between the two services-->  
            <add filterName="RoundRobinFilter1" endpointName="regularCalcEndpoint" priority="0"/>  
            <add filterName="RoundRobinFilter2" endpointName="roundingCalcEndpoint" priority="0"/>  
          </entries>  
        </table>  
      </filterTables>  
    </routing>  
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 [Routing Services](../../../../docs/framework/wcf/samples/routing-services.md)
