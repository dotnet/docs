---
title: "Security ETW Events"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "security events [.NET Framework]"
  - "ETW, security events (CLR)"
ms.assetid: 0ed69f73-5c01-4514-bd63-979c6e38d41d
---
# Security ETW Events

Security events are raised during strong name verification and Authenticode verification.  

## StrongNameVerificationStart_V1 and StrongNameVerificationStop_V1 Events  
 The following table shows the keyword and level. (For more information, see [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md).)  
  
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
  
## See also

- [CLR ETW Events](clr-etw-events.md)
