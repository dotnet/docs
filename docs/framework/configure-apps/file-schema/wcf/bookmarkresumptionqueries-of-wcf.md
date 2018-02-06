---
title: "&lt;bookmarkResumptionQueries&gt; of WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ed086712-1dc7-4932-a592-d1116a0155f3
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;bookmarkResumptionQueries&gt; of WCF
Represents a collection of queries that are used to track resumption of a bookmark within a workflow instance. The query is necessary for a tracking participant to subscribe to bookmark resumption records.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
  
 \<system.serviceModel>  
\<tracking>  
\<trackingProfile>  
\<workflow>  
\<bookmarkResumptionQueries>  
\<bookmarkResumptionQuery>  
  
## Syntax  
  
```xml
<tracking>   <trackingProfile name="Name">       <workflow>          <bookmarkResumptionQueries>             <bookmarkResumptionQuery name="String" />          </bookmarkResumptionQueries>       </workflow>   </trackingProfile></tracking>  
```

## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bookmarkResumptionQuery>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/bookmarkresumptionquery.md)|A query that is used to track resumption of a bookmark within a workflow instance. The query is necessary for a tracking participant to subscribe to bookmark resumption records.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflow>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/workflow.md)|A configuration element that contains all queries for a specific workflow identified by the `activityDefinitionId` property.|  
  
## See Also  
 <xref:System.ServiceModel.Activities.Tracking.Configuration.BookmarkResumptionQueryElementCollection?displayProperty=nameWithType>       
 <xref:System.Activities.Tracking.BookmarkResumptionQuery?displayProperty=nameWithType>       
 [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)  
 [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
