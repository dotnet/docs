---
title: "1146 - FlowchartSwitchCase"
ms.date: "03/30/2017"
ms.assetid: 274e9209-1720-4512-a615-e742f00895f4
---
# 1146 - FlowchartSwitchCase
## Properties  
  
|||  
|-|-|  
|ID|1146|  
|Keywords|WFActivities|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates which case has been selected in a Flowchart switch.  
  
## Message  
 Flowchart '%1'/FlowSwitch - Case '%2' was selected.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|FlowChart|xs:string|The display name of the FlowChart.|  
|Case|xs:string|The switch case that selected.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
