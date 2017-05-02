---
title: "&lt;cancelRequestedQuery&gt; of WCF | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b690d870-02eb-4c56-8bc3-e5ca99d7097b
caps.latest.revision: 3
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# &lt;cancelRequestedQuery&gt; of WCF
Represents a query that is used to track requests to cancel a child activity by the parent activity. The query is necessary for a tracking participant to subscribe to cancel request record objects.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md).  
  
 \<system.serviceModel>  
\<tracking>  
\<trackingProfile>  
\<workflow>  
\<cancelRequestedQueries>  
\<cancelRequestedQuery>  
  
## Syntax  
  
```vb  
<tracking>   <trackingProfile name="Name">       <workflow>          <cancelRequestQueries>             <cancelRequestQuery activityName="String"                 childActivityName="String"/>          </cancelRequestQueries>       </workflow>   </trackingProfile></tracking>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|activityName|A string that specifies the name of the activity that is requesting the cancellation.|  
|childActivityName|A string that specifies the name of the child activity for which cancellation was requested.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<faultPropagationQuery>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/faultpropagationquery.md)|Represents a list of configuration elements that are used to track requests to cancel a child activity by the parent activity. The query is necessary for a tracking participant to subscribe to cancel request record objects.|  
  
## See Also  
 <xref:System.ServiceModel.Activities.Tracking.Configuration.CancelRequestQueryElement?displayProperty=fullName>       
 <xref:System.Activities.Tracking.CancelRequestedQuery?displayProperty=fullName>     
 [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)   
 [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)