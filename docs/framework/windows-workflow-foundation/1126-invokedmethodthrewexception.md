---
description: "Learn more about: 1126 - InvokedMethodThrewException"
title: "1126 - InvokedMethodThrewException"
ms.date: "03/30/2017"
ms.assetid: 0d3cff1a-97e6-4b6c-be18-108c6881bfc0
---
# 1126 - InvokedMethodThrewException

## Properties

| Property | Value |
| - | - |
|ID|1126|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates an exception was thrown by the method called by the InvokeMethod activity.  
  
## Message  

 An exception was thrown in the method called by the activity '%1'. %2  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InvokeMethod|xs:string|The display name of the InvokeMethod activity.|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
