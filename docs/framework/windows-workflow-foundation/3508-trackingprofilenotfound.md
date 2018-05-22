---
title: "3508 - TrackingProfileNotFound"
ms.date: "03/30/2017"
ms.assetid: 4cee3c4a-0490-4c94-aa19-ef7ce7287c02
---
# 3508 - TrackingProfileNotFound
## Properties  
  
|||  
|-|-|  
|ID|3508|  
|Keywords|WFServices|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates either a TrackingProfile is not found in the config file or the ActivityDefinitionId does not match the profile.  
  
## Message  
 TrackingProfile '%1' for the ActivityDefinitionId '%2' not found. Either the TrackingProfile is not found in the config file or the ActivityDefinitionId does not match.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TrackingProfile|xs:string|The name of the tracking profile.|  
|ActivityDefinitionId|xs:string|The activity definition id.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
