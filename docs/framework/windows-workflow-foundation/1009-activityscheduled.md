---
description: "Learn more about: 1009 - ActivityScheduled"
title: "1009 - ActivityScheduled"
ms.date: "03/30/2017"
ms.assetid: 307e38b6-d47e-47a4-9708-e74d8314b1a1
---
# 1009 - ActivityScheduled

## Properties

| Property | Value |
| - | - |
|ID|1009|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates an activity is being scheduled for execution.  
  
## Message  

 Parent Activity '%1', DisplayName: '%2', InstanceId: '%3' scheduled child Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ParentActivity|xs:string|The type name of the parent activity.|  
|ParentDisplayName|xs:string|The display name of the parent activity.|  
|ParentInstanceId|xs:string|The instance id of the parent activity.|  
|ChildActivity|xs:string|The type name of the scheduled child activity.|  
|ChildDisplayName|xs:string|The display name of the scheduled child activity.|  
|ChildInstanceId|xs:string|The instance id of the scheduled child activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
