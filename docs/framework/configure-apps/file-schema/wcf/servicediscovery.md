---
title: "<serviceDiscovery>"
ms.date: "03/30/2017"
ms.assetid: a3c68a4a-fc95-43c5-aacb-785936c0cf39
---
# \<serviceDiscovery>
Specifies the discoverability of service endpoints.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceDiscovery>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <serviceDiscovery>
        <announcementEndpoints>
          <endpoint name="String"
                    kind="Type" />
        </announcementEndpoints>
        <discoveryEndpoints>
          <endpoint name="String"
                    kind="Type" />
        </discoveryEndpoints>
      </serviceDiscovery>
    </behavior>
  </serviceBehaviors>
</behaviors>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<announcementEndpoint>](announcementendpoint.md)|A collection of announcement endpoints. Use this section to specify the endpoints to use for sending announcement messages.|  
|[\<discoveryEndpoint>](discoveryendpoint.md)|A collection of discovery endpoints. Use this section to specify the endpoints on which to listen for the discovery messages.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 When added to the service’s behavior configuration, this configuration element makes all of the endpoints of that service discoverable. You can further configure the discovery features of such endpoints by using the [\<discoveryEndpoint>](discoveryendpoint.md) or [\<announcementEndpoint>](announcementendpoint.md) child elements. Use the [\<announcementEndpoint>](announcementendpoint.md) section to configure the announcements by specifying the endpoint configuration to be use to send service announcements (online/Hello and offline/Bye). Use the [\<discoveryEndpoint>](discoveryendpoint.md) section to manually specify the endpoint on which to listen for the discovery messages.  
  
## Example  
 The following configuration example specifies that the CalculatorService to be discoverable, and optionally specifies the announcement endpoint to be used.  
  
```xml  
<services>
  <service name="CalculatorService"
           behaviorConfiguration="CalculatorServiceBehavior">
    ...
  </service>
</services>
<behaviors>
  <serviceBehaviors>
    <behavior name="CalculatorServiceBehavior">
      <serviceDiscovery>
        <announcementEndpoints>
          <endpoint name="udpEndpoint"
                    kind="udpAnnouncementEndpoint" />
        </announcementEndpoints>
      </serviceDiscovery>
    </behavior>
  </serviceBehaviors>
</behaviors>
```  
  
## See also

- <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior>
