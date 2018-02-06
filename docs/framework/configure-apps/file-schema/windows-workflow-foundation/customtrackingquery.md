---
title: "&lt;customTrackingQuery&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 4e108e89-1132-46b7-868a-c7f5c69dc89f
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;customTrackingQuery&gt;
Represents a collection of queries that are used to track events that you define in your code activities. The query is necessary for a tracking participant to subscribe to custom tracking records.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
  
\<system.serviceModel>  
\<tracking>  
\<trackingProfile>  
\<workflow>  
\<customTrackingQueries>  
\<customTrackingQuery>  
  
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
  
|Attribute|Description|  
|---------------|-----------------|  
|activityName|A string that specifies the name of the activity that generated the tracking record.|  
|name|A string that specifies the name of the custom tracking record that is emitted.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<customTrackingQuery>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/customtrackingquery.md)|A query that is used to track events that you define in your code activities.|  
  
## See Also  
 <xref:System.ServiceModel.Activities.Tracking.Configuration.CustomTrackingQueryElementCollection?displayProperty=nameWithType>       
 <xref:System.Activities.Tracking.CustomTrackingQuery?displayProperty=nameWithType>         
 [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)  
 [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
