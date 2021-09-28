---
description: "Learn more about: ICorDebugMergedAssemblyRecord::GetVersion Method"
title: "ICorDebugMergedAssemblyRecord::GetVersion Method"
ms.date: "03/30/2017"
ms.assetid: c6858b06-ae26-4312-b325-ea6025016675
---
# ICorDebugMergedAssemblyRecord::GetVersion Method

Gets the assembly's version information.  
  
## Syntax  
  
```cpp  
HRESULT GetVersion(  
   [out] USHORT *pMajor,
   [out] USHORT *pMinor,
   [out] USHORT *pBuild,
   [out] USHORT *pRevision  
);  
```  
  
## Parameters  

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
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
