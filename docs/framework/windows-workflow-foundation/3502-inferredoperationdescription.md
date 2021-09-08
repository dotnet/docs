---
description: "Learn more about: 3502 - InferredOperationDescription"
title: "3502 - InferredOperationDescription"
ms.date: "03/30/2017"
ms.assetid: 6aebb614-3c72-4537-ba11-3cc7200ef1f1
---
# 3502 - InferredOperationDescription

## Properties

| Property | Value |
| - | - |
|ID|3502|  
|Keywords|WFServices|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 Indicates an OperationDescription has been inferred from WorkflowService.  
  
## Message  

 OperationDescription with Name='%1' in contract '%2' has been inferred from WorkflowService. IsOneWay=%3.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|OperationName|xs:string|The name of the operation.|  
|ContractName|xs:string|The name of the contract.|  
|IsOneWay|xs:string|True or False indicating if the contract is one-way.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
