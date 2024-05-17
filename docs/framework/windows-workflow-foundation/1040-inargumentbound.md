---
description: "Learn more about: 1040 - InArgumentBound"
title: "1040 - InArgumentBound"
ms.date: "03/30/2017"
ms.assetid: 7dfaad1b-36c0-4575-84c1-31d63b0eaf5d
---
# 1040 - InArgumentBound

## Properties

| Property | Value |
| - | - |
|ID|1040|  
|Keywords|WFActivities|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates an In argument has been bound.  
  
## Message  

 In argument '%1' on Activity '%2', DisplayName: '%3', InstanceId: '%4' has been bound with value: %5.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InArgument|xs:string|The name of the InArgument.|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|Value|xs:string|The value bound to the InArgument.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
