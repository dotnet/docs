---
title: "Activity Definition Scoping and Visibility"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ccdffa07-9503-4eea-a61b-17f1564368b7
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity Definition Scoping and Visibility
Activity definition scoping and visibility, just like scoping and visibility of an object, is the ability of other objects or activities to access members of the activity. Activity definition is performed by the following implementations:  
  
1.  Determining the members (<xref:System.Activities.Argument>, <xref:System.Activities.Variable>, and <xref:System.Activities.ActivityDelegate> objects, and child activities) an activity exposes to its users.  
  
2.  Implementing the execution logic of the activity  
  
 The implementation may involve members that are not exposed to consumers of the activity, but are rather details of the implementation.  Similar to type definition, the activity model allows an author to qualify the visibility of an activity member regarding the definition of the activity being defined.  This visibility governs aspects of member usage, such as data scoping.  
  
## Scope  
 In addition to data scoping, activity model visibility can restrict access to other aspects of the activity, such as validation, debugging, tracking, or tracing. Execution properties use visibility and scoping for constraining execution characteristics to a particular scope of definition. Secondary roots use visibility and scoping to constrain the state captured by a <xref:System.Activities.Statements.CompensableActivity> to the scope of definition in which the compensable activities are used.  
  
## Definition and usage  
 A workflow is written by authoring new activities by inheriting from base activity classes, and by using activities from the [Built-In Activity Library](../../../docs/framework/windows-workflow-foundation/net-framework-4-5-built-in-activity-library.md). In order to use an activity, the activity author must configure the visibility of each component of its definition.  
  
### Activity Members  
 The activity model defines the arguments, variables, delegates, and child activities that the activity makes available to consumers. Each of these members can be declared as `public` or `private`. Public members are configured by the consumer of the activity, whereas `private` members use an implementation fixed by the author of the activity. The visibility rules for data scoping are as follows:  
  
1.  Public members and the public members of public child activities can reference public variables.  
  
2.  Private members and the public members of public child activities can reference arguments and private variables.  
  
 A member that can be set by the consumer of an activity should never be made private.  
  
### Authoring Models  
 Custom activities are defined by using <xref:System.Activities.NativeActivity>, <xref:System.Activities.Activity>, <xref:System.Activities.CodeActivity>, or <xref:System.Activities.AsyncCodeActivity>. Activities that derive from these classes can expose different member types with different visibilities.  
  
#### NativeActivity  
 Activities that derive from <xref:System.Activities.NativeActivity> have behavior that is written in imperative code, and can optionally be defined by using existing activities. Deriving activities from <xref:System.Activities.NativeActivity> grants access to all of the features exposed by the runtime. Any member of such an activity can be defined by using either public or private visibility, except arguments, which can only be declared as `public`.  
  
 Members of classes derived from <xref:System.Activities.NativeActivity> are declared to the runtime using the <xref:System.Activities.NativeActivityMetadata> struct passed to the <xref:System.Activities.NativeActivity.CacheMetadata%2A> method.  
  
#### Activity  
 Activities created by using <xref:System.Activities.Activity> have behavior that is designed strictly through composing other activities. The <xref:System.Activities.Activity> class has one implementation child activity, obtained by the runtime using <xref:System.Activities.Activity.Implementation%2A>. An activity deriving from <xref:System.Activities.Activity> can define public arguments, public variables, imported ActivityDelegates, and imported Activities.  
  
 Imported ActivityDelegates and Activities are declared as public children of the activity, but cannot be directly scheduled by the activity. This information is used during validation to avoid running parent-facing validations at locations where the activity will never execute. Also, imported children, just like public children, can be referenced and scheduled by the activity’s implementation. This means that an activity which imports an activity called Activity1 can contain a <xref:System.Activities.Statements.Sequence> in its implementation which schedules Activity1.  
  
#### CodeActivity/ AsyncCodeActivity  
 This base class is used for authoring behavior in imperative code. Activities that derive from this class only have access to the arguments they expose. This means that the only members that these activities can expose are public arguments. No other members or visibilities apply to these activities.  
  
#### Summary of visibilities  
 The following table summarizes the information earlier in this section.  
  
|Member Type|NativeActivity|Activity|CodeActivity/ AsyncCodeActivity|  
|-----------------|--------------------|--------------|--------------------------------------|  
|Arguments|Public/ Private|Public|not applicable|  
|Variables|Public/ Private|Public|not applicable|  
|Child Activities|Public/ Private|Public, one fixed private child defined in Implementation.|not applicable|  
|ActivityDelegates|Public/ Private|Public|not applicable|  
  
 In general, a member that cannot be set by the consumer of an activity should not be made public.  
  
### Execution Properties  
 In some scenarios, it is useful to scope a particular execution property to the public children of an activity. The <xref:System.Activities.ExecutionProperties> collection provides this capability with the <xref:System.Activities.ExecutionProperties.Add%2A> method. This method has a Boolean parameter indicating whether a particular property is scoped to all children, or just those that are public. If this parameter is set to `true`, the property will only be visible to public members and the public members of their public children.  
  
### Secondary Roots  
 A secondary root is the runtime’s internal mechanism for managing state for compensation activities. When a <xref:System.Activities.Statements.CompensableActivity> has finished running, its state is not cleaned up immediately. Instead, the state is maintained by the runtime in a secondary root until the compensation episode has completed. The location environments captured with the secondary root correspond to the scope of definition in which the Compensable activity is used.
