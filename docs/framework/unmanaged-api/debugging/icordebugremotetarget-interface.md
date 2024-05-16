---
description: "Learn more about: ICorDebugRemoteTarget Interface"
title: "ICorDebugRemoteTarget Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugRemoteTarget"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRemoteTarget"
helpviewer_keywords: 
  - "ICorDebugRemoteTarget interface [.NET Framework debugging]"
ms.assetid: bd9936a6-cc24-4869-8761-0988664464e6
topic_type: 
  - "apiref"
---
# ICorDebugRemoteTarget Interface

Provides methods that enable developers to debug Silverlight-based applications in the common language runtime (CLR) environment.  
  
## Syntax  
  
```cpp  
interface ICorDebugRemoteTarget  : IUnknown  
{  
    HRESULT GetHostName (  
        [in]  ULONG32                    cchHostName,  
        [out] ULONG32*                   pcchHostName,  
        [out, size_is(cchHostName),  
              length_is(*pcchHostName)]  
                  WCHAR szHostName[]  
        );  
};  
```  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ICorDebugRemoteTarget::GetHostName Method](icordebugremotetarget-gethostname-method.md)|Returns the host name or the IP address of a remote machine.|  
  
## Remarks  

 Mixed-mode (that is, managed and native code) debugging is not supported on non-x86 platforms (such as IA-64 and AMD64).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** : CorGuids.lib  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See also

- [ICorDebugRemote Interface](icordebugremote-interface.md)
- [ICorDebug Interface](icordebug-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
