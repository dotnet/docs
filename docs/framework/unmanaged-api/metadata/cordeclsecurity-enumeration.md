---
title: "CorDeclSecurity Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CorDeclSecurity"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDeclSecurity"
helpviewer_keywords: 
  - "CorDeclSecurity enumeration [.NET Framework metadata]"
ms.assetid: 864f1267-d267-4696-8df7-1f83f8444d6f
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDeclSecurity Enumeration
Specifies the security actions that can be performed using declarative security.  
  
## Syntax  
  
```  
typedef enum CorDeclSecurity {  
  
    dclActionMask               =   0x001f,  
    dclActionNil                =   0x0000,  
    dclRequest                  =   0x0001,  
    dclDemand                   =   0x0002,  
    dclAssert                   =   0x0003,  
    dclDeny                     =   0x0004,  
    dclPermitOnly               =   0x0005,  
    dclLinktimeCheck            =   0x0006,  
    dclInheritanceCheck         =   0x0007,  
    dclRequestMinimum           =   0x0008,  
    dclRequestOptional          =   0x0009,  
    dclRequestRefuse            =   0x000a,  
    dclPrejitGrant              =   0x000b,  
    dclPrejitDenied             =   0x000c,  
    dclNonCasDemand             =   0x000d,  
    dclNonCasLinkDemand         =   0x000e,  
    dclNonCasInheritance        =   0x000f,  
    dclLinkDemandChoice         =   0x0010,  
    dclInheritanceDemandChoice  =   0x0011,  
    dclDemandChoice             =   0x0012,  
    dclMaximumValue             =   0x0012  
  
} CorDeclSecurity;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`dclActionMask`|Reserved.|  
|`dclActionNil`|Reserved.|  
|`dclRequest`|Reserved.|  
|`dclDemand`|All callers higher in the call stack are required to have been granted the permission specified by the current permission object.|  
|`dclAssert`|The calling code can access the resource identified by the current permission object, even if callers higher in the stack have not been granted permission to access the resource|  
|`dclDeny`|The ability to access the resource specified by the current permission object is denied to callers, even if they have been granted permission to access it.|  
|`dclPermitOnly`|Only the resources specified by this permission object can be accessed, even if the code has been granted permission to access other resources.|  
|`dclLinktimeCheck`|The immediate caller is required to have been granted the specified permission for a given period of time.|  
|`dclInheritanceCheck`|The derived class inheriting another class or overriding a method is required to have been granted the specified permission.|  
|`dclRequestMinimum`|The caller can request for the minimum permissions required for code to run. This action can only be used within the scope of the assembly.|  
|`dclRequestOptional`|The caller can request for additional permissions that are optional (not required to run). This request implicitly refuses all other permissions not specifically requested. This action can only be used within the scope of the assembly.|  
|`dclRequestRefuse`|The caller's request for permissions that might be misused will not be granted. This action can only be used within the scope of the assembly.|  
|`dclPrejitGrant`|Reserved.|  
|`dclPrejitDenied`|Reserved.|  
|`dclNonCasDemand`|Reserved.|  
|`dclNonCasLinkDemand`|The immediate caller is required to have been granted the specified permission.|  
|`dclNonCasInheritance`|Reserved.|  
|`dclLinkDemandChoice`|Reserved.|  
|`dclInheritanceDemandChoice`|Reserved.|  
|`dclDemandChoice`|Reserved.|  
|`dclMaximumValue`|Reserved.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
