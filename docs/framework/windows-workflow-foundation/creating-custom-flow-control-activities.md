---
title: "Creating custom flow control activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 27f409f6-2d1d-4cfb-9765-93eb2ad667d5
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating custom flow control activities
The .Net Framework contains a variety of flow-control activities that function similarly to abstract programming structures (such as <xref:System.Activities.Statements.Flowchart>)   or to standard programming statements (such as <xref:System.Activities.Statements.If>). This topic discusses the architecture of one of the sample projects, [Non-Generic ForEach](../../../docs/framework/windows-workflow-foundation/samples/non-generic-foreach.md).  
  
## Creating the custom class  
 Since the Non-Generic ForEach class will need to schedule child activities, it will need to derive from <xref:System.Activities.NativeActivity>, since activities that derive from <xref:System.Workflow.Activities.CodeActivity> do not have this functionality.  
  
```  
public sealed class ForEach : NativeActivity  
    {  
```  
  
 The custom class requires several members to store data being used by the activity, and to provide functionality to execute the activity’s child activities. These members include:  
  
-   `valueEnumerator`: The non-public <xref:System.Activities.Variable%601> of type <xref:System.Collections.IEnumerator> used to iterate over the collection of items. This member is of type <xref:System.Activities.Variable%601> because it is used internally in the activity, rather than an argument or public property, which would be used if this object were to have an origin outside the activity.  
  
-   `OnChildComplete`: The public <xref:System.Activities.CompletionCallback> property that executes when each child completes execution. This member is defined as a CLR property, since its value will not change for different instances of the activity.  
  
-   `Values`: The collection of inputs used for the iterations of the child activity. This member is of type <xref:System.Activities.InArgument%601>, since the origin of the data is outside the activity, but the contents of the collection is not expected to change during the execution of the activity. If the activity needed the functionality to change the contents of this collection while the activity was executing (to add or remove activities, for instance), this member would have been defined as an <xref:System.Activities.ActivityAction>, which then would have been evaluated every time it was accessed, so that changes would be available to the activity.  
  
-   `Body`: This member defines the activity to be executed for each item in the `Values` collection. This member is defined as an <xref:System.Activities.ActivityAction> so that it is evaluated every time it is accessed.  
  
-   `Execute`: This method uses the `InternalExecute`, `OnForEachComplete`, and `GetStateAndExecute` non-public members to schedule the execution and assign the completion handler of the child activity defined in the Body member.  
  
-   `CacheMetadata`: This member provides the runtime with the information it needs to execute the activity. By default, an activity’s `CacheMetadata` method will inform the runtime of all public members of the activity, but since this activity uses private members for some functionality, it needs to inform the runtime of their existence so that the runtime can be aware of them. In this case, the `CacheMetadata` function is overridden so that the private `valueEnumerator` member can be accessed. This member also creates an argument for the values for the activity so that they can be passed in to the activity during execution.
