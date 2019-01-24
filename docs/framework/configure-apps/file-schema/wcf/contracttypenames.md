---
title: "&lt;contractTypeNames&gt;"
ms.date: "03/30/2017"
ms.assetid: 5ec5efc6-87f8-4160-9be0-dcd2e01df3df
---
# &lt;contractTypeNames&gt;
A configuration section that specifies a list of contract type names, which are the contract names of the services being searched for, and the criteria typically used when searching for a service. If more than one contract name is specified, only service endpoints matching ALL contracts will reply. Note that in Windows Communication Foundation (WCF), an endpoint can only support one contract.  
  
 \<system.ServiceModel>  
\<standardEndpoints>  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <standardEndpoints>
    <dynamicEndpoint>
      <standardEndpoint>
        <discoveryClientSettings discoveryEndpoint="String">
          <findCriteria duration="TimeSpan"
                        maxResults="Integer"
                        scopeMatchBy="Uri">
            <contractTypeNames>
              <add name="String"
                   namespace="String" />
            <contractTypeNames>
            <extensions />
            <scopes>
              <add scope="URI"/>
            </scopes>
          </findCriteria>
        </discoveryClientSettings>
      <standardEndpoint>
    </dynamicEndpoint>
  </standardEndpoints>
</system.serviceModel>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/wcf/contracttypenames.md)|A contract type name is a property that refers to the set of criteria typically used when searching for a service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<findCriteria>](../../../../../docs/framework/configure-apps/file-schema/wcf/findcriteria.md)|A configuration element that supplies a set of criteria used by a client application to search for a discovery service. Criteria can be grouped into search criteria (specifying what services you’re looking for) and find termination criteria (how long the search should last).|  
  
## See also
- <xref:System.ServiceModel.Discovery.FindCriteria>
- <xref:System.ServiceModel.Discovery.Configuration.FindCriteriaElement>
- <xref:System.ServiceModel.Discovery.Configuration.ContractTypeNameElementCollection>
