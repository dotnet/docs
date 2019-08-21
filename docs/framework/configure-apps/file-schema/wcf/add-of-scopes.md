---
title: "<add> of <scopes>"
ms.date: "03/30/2017"
ms.assetid: 0563a7d8-fc84-4c85-9066-af32665857c2
---
# \<add> of \<scopes>
Adds a custom scope Uri that can be used to filter service endpoints during query.  
  
\<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<endpointDiscovery>  
\<scopes>  
\<add>  
  
## Syntax  
  
```xml  
<behaviors>
  <endpointBehaviors>
    <behavior name="String">
      <endpointDiscovery enable="Boolean">
        <scopes>
          <add scope="URI" />
        </scopes>
      </endpointDiscovery>
    </behavior>
  </endpointBehaviors>
</behaviors>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|scope|A URI that contains scope information for the endpoint that can be used in matching criteria for finding services.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<scopes>](scopes.md)|Contains a collection of configuration elements that specify custom scope Uris that can be used to filter service endpoints during query.|  
  
## See also

- <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior>
