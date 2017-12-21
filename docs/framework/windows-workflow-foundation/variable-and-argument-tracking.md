---
title: "Variable and Argument Tracking"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8f3d9d30-d899-49aa-b7ce-a8d0d32c4ff0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Variable and Argument Tracking
When tracking the execution of a workflow, it is often useful to extract data. This provides additional context when accessing a tracking record post execution. In [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)], you can extract any visible variable or argument within the scope of any activity in a workflow using tracking. Tracking profiles make it easy to extract data.  
  
## Variables and Arguments  
 Variables and arguments are extracted when an activity emits an ActivityStateRecord.  A variable is available for extraction only if it is within the scope of the activity. A variable to be extracted within an activity is specified in the following manner:  
  
-   If a variable is specified by the variable name, then tracking looks for the variable within the current activity being tracked and in parent activities. The variable is searched in current activity scope and in parent scope.  
  
-   If variables to be extracted are specified by using name="*", then all variables within the current activity being tracked are extracted. In this case variables that are in scope but defined in parent activities are not extracted.  
  
 When extracting arguments, the arguments extracted depend on the state of the activity. When the state of an activity is Executing, then only the `InArguments` are available for extraction. For any other activity state (Closed, Faulted, Canceled), all arguments, both InArguments and OutArguments, are available for extraction.  
  
 The following example shows an activity state query that extracts variables and arguments when the activity’s `Closed` tracking record is emitted. Variables and arguments can be extracted only with an <xref:System.Activities.Tracking.ActivityStateRecord> and thus are subscribed to within a tracking profile using <xref:System.Activities.Tracking.ActivityStateQuery>.  
  
```xml  
<activityStateQuery activityName="SendEmailActivity">  
  <states>  
    <state name="Closed"/>  
  </states>  
  <variables>  
    <variable name="FromAddress"/>  
  </variables>  
  <arguments>  
    <argument name="Result"/>  
  </arguments>  
</activityStateQuery>  
```  
  
## Protecting Information Stored Within Variables and Arguments  
 A tracked variable or argument is by default made visible by the WF runtime. A workflow developer can protect it from being accessed by taking the following steps:  
  
1.  Encrypt the value of a variable.  
  
2.  Control the authoring of a tracking profile to prevent the extraction of a variable or argument.  
  
3.  For custom tracking participants ensure that the WF code does not disclose sensitive information that is stored in variables or arguments.  
  
## See Also  
 [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](http://go.microsoft.com/fwlink/?LinkId=201275)
