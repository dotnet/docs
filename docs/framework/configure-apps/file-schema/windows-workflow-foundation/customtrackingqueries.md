---
description: "Learn more about: <customTrackingQueries>"
title: "<customTrackingQueries>"
ms.date: "03/30/2017"
ms.assetid: 4e9e732d-911d-45a3-a569-4b5e9cd1ffbe
---
# \<customTrackingQueries>

Represents a collection of queries that are used to track events that you define in your code activities. The query is necessary for a tracking participant to subscribe to custom tracking records.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<tracking>**](tracking.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<trackingProfile>**](trackingprofile.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflow>**](workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<customTrackingQueries>**  
  
## Syntax  
  
```xml  
<tracking>
  <trackingProfile name="Name">
    <workflow>
      <customTrackingQueries>
        <customTrackingQuery activityName="String"
                             name="String" />
      </customTrackingQueries>
    </workflow>
  </trackingProfile>
</tracking>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<customTrackingQuery>](customtrackingquery.md)|A query that is used to track events that you define in your code activities.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflow>](workflow.md)|A configuration element that contains all queries for a specific workflow identified by the **activityDefinitionId** property.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.CustomTrackingQueryElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.CustomTrackingQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
