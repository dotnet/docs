---
description: "Learn more about: <findCriteria>"
title: "<findCriteria>"
ms.date: "03/30/2017"
ms.assetid: 5454cd19-6bf5-4ba8-94d1-f58d10dc1917
---
# \<findCriteria>

A configuration element that supplies a set of criteria used by a client application to search for a discovery service. Criteria can be grouped into search criteria (specifying what services you’re looking for) and find termination criteria (how long the search should last).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<standardEndpoints>**](standardendpoints.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<dynamicEndpoint>**](dynamicendpoint.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<standardEndpoint>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<discoveryClientSettings>**](discoveryclientsettings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<findCriteria>**  
  
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
            </contractTypeNames>
            <extensions />
            <scopes>
              <add scope="URI" />
            </scopes>
          </findCriteria>
        </discoveryClientSettings>
      </standardEndpoint>
    </dynamicEndpoint>
  </standardEndpoints>
</system.serviceModel>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|duration|A Timespan value that specifies the maximum time to wait for replies from services on the network. The default duration is 20 seconds.|  
|maxResults|An integer that specifies the maximum number of replies to wait for, from services on a network or the Internet. If maximum replies are received before the value specified in the `duration` attribute has elapsed, the find operation ends.|  
|scopeMatchBy|A URI that specify the matching algorithm to use while matching the scopes in the Probe message with that of the endpoint.<br /><br /> There are five supported scope-matching rules. If you do not specify a scope-matching rule, `ScopeMatchByPrefix` is used. For more information on this, see <xref:System.ServiceModel.Discovery.FindCriteria>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<contractTypeNames>](contracttypenames.md)|A collection of configuration elements that contain the names of workflow service contract types.|  
|\<extensions> of \<findCriteria>|A collection of XML element objects that provide extensions.|  
|[\<scopes>](scopes.md)|A collection of objects that contain absolute URIs that are used during a find operation to locate a specific service or services.<br /><br /> If the specific service is found, a successful match has been made between the service URI and the Scope URI, sometimes with the help of scope rules that handle complications of matching.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<standardEndpoints>](standardendpoints.md)|Contains the settings needed by an application to participate in the service discovery process as a client.|  
  
## See also

- <xref:System.ServiceModel.Discovery.FindCriteria>
- <xref:System.ServiceModel.Discovery.Configuration.FindCriteriaElement>
