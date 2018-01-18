---
title: "Security ETW Events"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security events [.NET Framework]"
  - "ETW, security events (CLR)"
ms.assetid: 0ed69f73-5c01-4514-bd63-979c6e38d41d
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security ETW Events
<a name="top"></a> Security events are raised during strong name verification and Authenticode verification.  
  
 This category consists of the following events:  
  
-   [StrongNameVerificationStart_V1 and StrongNameVerificationStop_V1 Events](#strongnameverificationstart_v1_and_strongnameverificationstop_v1_events)  
  
-   [AuthenticodeVerificationStart_V1 and AuthenticodeVerificationStop_V1 Events](#authenticodeverificationstart_v1_and_authenticodeverificationstop_v1_events)  
  
<a name="strongnameverificationstart_v1_and_strongnameverificationstop_v1_events"></a>   
## StrongNameVerificationStart_V1 and StrongNameVerificationStop_V1 Events  
 The following table shows the keyword and level. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`SecurityKeyword` (0x400)|Informational(4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`StrongNameVerificationStart_V1`|181|Start of strong name verification.|  
|`StrongNameVerificationStop_V1`|182|End of strong name verification.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|VerificationFlags|win:UInt32|The verification flags.|  
|ErrorCode|win:UInt32|The HResult error code.|  
|FullyQualifiedAssemblyName|win:UnicodeString|The fully qualified assembly name.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="authenticodeverificationstart_v1_and_authenticodeverificationstop_v1_events"></a>   
## AuthenticodeVerificationStart_V1 and AuthenticodeVerificationStop_V1 Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`SecurityKeyword` (0x400)|Informational(4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`AuthenticodeVerificationStart_V1`|183|Start of Authenticode verification.|  
|`AuthenticodeVerificationStop_V1`|184|End of Authenticode verification.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|VerificationFlags|win:UInt32|The verification flags.|  
|ErrorCode|win:UInt32|The HResult error code.|  
|ModulePath|win:UnicodeString|The module path.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
