---
title: "Activity Authoring Options in WF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b9061f5f-12c3-47f0-adbe-1330e2714c94
caps.latest.revision: 20
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity Authoring Options in WF
[!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] provides several options for creating custom activities. The correct method to use for authoring a given activity depends on what run-time features are required.  
  
## Deciding Which Base Activity Class to Use for Authoring Custom Activities  
 The following table lists the features available in the custom activity base classes.  
  
|Base activity class|Features available|  
|-------------------------|------------------------|  
|<xref:System.Activities.Activity>|Composes groups of system-provided and custom activities into a composite activity.|  
|<xref:System.Activities.CodeActivity>|Implements imperative functionality by providing an <xref:System.Activities.CodeActivity%601.Execute%2A> method that can be overridden. Also provides access to tracking, variables, and arguments..|  
|<xref:System.Activities.NativeActivity>|Provides all of the features of <xref:System.Activities.CodeActivity>, plus aborting activity execution, canceling child activity execution, using bookmarks, and scheduling activities, activity actions, and functions.|  
|<xref:System.Activities.DynamicActivity>|Provides a DOM-like approach to constructing activities that interfaces with the WF designer and the run-time machinery through <!--zz <xref:System.ComponentModel.IcustomTypeDescriptor>--> `IcustomTypeDescriptor`, allowing new activities to be created without defining new types.|  
  
## Authoring Activities using Activity  
 Activities that derive from <xref:System.Activities.Activity> compose functionality by assembling other existing activities. These activities can be existing custom activities and activities from the [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] activity library. Assembling these activities is the most basic way to create custom functionality. This approach is most typically taken when using a visual design environment for authoring workflows.  
  
## Authoring Activities using CodeActivity or AsyncCodeActivity  
 Activities that derive from <xref:System.Activities.CodeActivity> or <xref:System.Activities.AsyncCodeActivity> can implement imperative functionality by overriding the <xref:System.Activities.CodeActivity%601.Execute%2A> method with custom imperative code. The custom code is executed when the activity is executed by the runtime. While activities created in this way have access to custom functionality, they do not have access to all of the features of the runtime, such as full access to the execution environment, the ability to schedule child activities, bookmark creation, or support for a Cancel or Abort method. When a <xref:System.Activities.CodeActivity> executes, it has access to a reduced version of the execution environment (through the <xref:System.Activities.CodeActivityContext> or <xref:System.Activities.AsyncCodeActivityContext> class). Activities created using <xref:System.Activities.CodeActivity> have access to argument and variable resolution, extensions, and tracking. Asynchronous activity scheduling can be done using <xref:System.Activities.AsyncCodeActivity>.  
  
## Authoring Activities using NativeActivity  
 Activities that derive from <xref:System.Activities.NativeActivity>, like those that derive from <xref:System.Activities.CodeActivity>, create imperative functionality by overriding <xref:System.Activities.NativeActivity.Execute%2A>, but also have access to all of the functionality of the workflow runtime through the <xref:System.Activities.NativeActivityContext> that gets passed into the <xref:System.Activities.NativeActivity.Execute%2A> method. This context has support for scheduling and canceling child activities, executing <xref:System.Activities.ActivityAction> and <!--zz <xref:System.Activities.ActivityFunc>--> `ActivityFunc` objects, flowing transactions into a workflow, invoking asynchronous processes, canceling and aborting execution, access to execution properties and extensions, and bookmarks (handles for resuming paused workflows).  
  
## Authoring Activities using DynamicActivity  
 Unlike the other three types of activity, new functionality is not created by deriving new types from <xref:System.Activities.DynamicActivity> (the class is sealed), but instead, by assembling functionality into the <xref:System.Activities.DynamicActivity.Properties%2A> and <xref:System.Activities.DynamicActivity.Implementation%2A> properties using an activity document object model (DOM).  
  
## Authoring Activities that Return a Result  
 Many activities must return a result after their execution. Although it is possible to always define a custom <xref:System.Activities.OutArgument%601> on an activity for this purpose, it is suggested to instead use <xref:System.Activities.Activity%601>, or derive from <xref:System.Activities.CodeActivity%601> or <xref:System.Activities.NativeActivity%601>. Each of these base classes has an <xref:System.Activities.OutArgument%601> named Result that your activity can use for its return value. Activities that return a result should only be used if only one result needs to be returned from an activity; if multiple results need to be returned, separate <xref:System.Activities.OutArgument%601> members should be used instead.
