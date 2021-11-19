---
description: "Learn more about: 201 - ClientMessageInspectorAfterReceiveInvoked"
title: "201 - ClientMessageInspectorAfterReceiveInvoked"
ms.date: "03/30/2017"
ms.assetid: 9ff637f1-cc26-4400-ab9b-546f70e5057d
---
# 201 - ClientMessageInspectorAfterReceiveInvoked

## Properties

| Property | Value |
| - | - |
|ID|201|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after the Service Model has invoked the `AfterReceiveReply` method on a client message inspector.  
  
## Message  

 The Dispatcher invoked 'AfterReceiveReply' on a ClientMessageInspector of type '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the invoked inspector's type.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
