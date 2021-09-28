---
description: "Learn more about: ICorDebugMutableDataTarget::WriteVirtual Method"
title: "ICorDebugMutableDataTarget::WriteVirtual Method"
ms.date: "03/30/2017"
ms.assetid: 80833648-58a7-491a-8dc8-9a48e9bb3adc
---
# ICorDebugMutableDataTarget::WriteVirtual Method

Writes memory into the target process address space.  
  
## Syntax  
  
```cpp  
HRESULT WriteVirtual(  
   [in] CORDB_ADDRESS address,  
   [in, size_is(bytesRequested)] const BYTE * pBuffer,  
   [in] ULONG32 bytesRequested);  
```  
  
## Parameters  

 `address`  
 [in] The address at which to write the contents of `pBuffer`.  
  
 `pBuffer`  
 [in] A pointer to a byte array that contains the bytes to be written.  
  
 `address`  
 [in] The number of bytes in `pBuffer`.  
  
## Return Value  

 `S_OK` on success, or any other `HRESULT` on failure.  
  
## Remarks  

 If any bytes cannot be written, the method call fails without changing any bytes in the target address space. (Otherwise, the target would be in an inconsistent state that makes further debugging unreliable.)  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See also

- [ICorDebugMutableDataTarget Interface](icordebugmutabledatatarget-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
