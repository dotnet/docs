---
description: "Learn more about: 3503 - DuplicateCorrelationQuery"
title: "3503 - DuplicateCorrelationQuery"
ms.date: "03/30/2017"
ms.assetid: b857f8e6-ce4d-4da4-bc9d-6cd63fa558a4
---
# 3503 - DuplicateCorrelationQuery

## Properties

| Property | Value |
| - | - |
|ID|3503|  
|Keywords|WFServices|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 Indicates a duplicate CorrelationQuery was found. The duplicate query will not be used when calculating correlation.  
  
## Message  

 A duplicate CorrelationQuery was found with Where='%1'. This duplicate query will not be used when calculating correlation.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Where|xs:string|The Where portion of the correlation query.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
