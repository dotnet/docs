---
title: "ICorDebugMergedAssemblyRecord::GetVersion Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: c6858b06-ae26-4312-b325-ea6025016675
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugMergedAssemblyRecord::GetVersion Method
Gets the assembly's version information.  
  
## Syntax  
  
```  
HRESULT GetVersion(  
   [out] USHORT *pMajor,   
   [out] USHORT *pMinor,   
   [out] USHORT *pBuild,   
   [out] USHORT *pRevision  
);  
```  
  
#### Parameters  
 `pMajor`  
 [out] A pointer to the major version number.  
  
 `pMinor`  
 [out] A pointer to the minor version number.  
  
 `pBuild`  
 [out] A pointer to the build number.  
  
 `pRevision`  
 [out] A pointer to the revision number.  
  
## Remarks  
 For information on assembly version numbers, see the <xref:System.Version> class topic.  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [ICorDebugMergedAssemblyRecord Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmergedassemblyrecord-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
