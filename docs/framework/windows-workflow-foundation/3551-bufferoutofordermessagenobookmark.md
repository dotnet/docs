---
description: "Learn more about: 3551 - BufferOutOfOrderMessageNoBookmark"
title: "3551 - BufferOutOfOrderMessageNoBookmark"
ms.date: "03/30/2017"
ms.assetid: 7930d6c4-c843-4a83-933a-cecd71b80d1e
---
# 3551 - BufferOutOfOrderMessageNoBookmark

## Properties

| Property | Value |
| - | - |
|ID|3551|  
|Keywords|WFServices|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 Indicates a bookmark resumption has failed. The buffered receive operation will be attempted again when the service instance is ready to process this particular operation.  
  
## Message  

 Operation '%2' on service instance '%1' cannot be performed at this time. Another attempt will be made when the service instance is ready to process this particular operation.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|OperationName|xs:string|The name of the operation.|  
|ServiceInstanceId|xs:string|The id of the service instance.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
