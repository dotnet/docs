---
title: "ICorDebugSymbolProvider2::GetGenericDictionaryInfo Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: ba28fe4e-5491-4670-bff7-7fde572d7593
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugSymbolProvider2::GetGenericDictionaryInfo Method
Retrieves a generic dictionary map.  
  
## Syntax  
  
```  
HRESULT GetGenericDictionaryInfo(  
   [out] ICorDebugMemoryBuffer** ppMemoryBuffer  
);  
```  
  
#### Parameters  
 `ppMemoryBuffer`  
 [out] A pointer to the address of an [ICorDebugMemoryBuffer](../../../../docs/framework/unmanaged-api/debugging/icordebugmemorybuffer-interface.md) object containing the generic dictionary map. See the Remarks section for more information.  
  
## Remarks  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
 The map consists of two top-level sections:  
  
-   A [directory](#Directory) containing the relative virtual addresses (RVA) of all dictionaries included in this map.  
  
-   A byte-aligned [heap](#Heap) that contains object instantiation information. It starts immediately after the last directory entry.  
  
<a name="Directory"></a>   
## The Directory  
 Each entry in the directory refers to an offset inside the heap; that is, it is an offset that is relative to the start of the heap. The value of individual entries is not necessarily unique; it is possible for multiple directory entries to point to the same offset in the heap.  
  
 The directory portion of the generic dictionary map has the following structure:  
  
-   The first 4 bytes contains the number of dictionary entries (that is, the number of relative virtual addresses in the dictionary). We will refer to this value as *N*. If the high bit is set, the entries are sorted by relative virtual address in ascending order.  
  
-   The *N* directory entries follow. Each entry consists of 8 bytes, in two 4-byte segments:  
  
    -   Bytes 0-3: RVA; the dictionary's relative virtual address.  
  
    -   Bytes 4-7: Offset; an offset relative to the start of the heap.  
  
<a name="Heap"></a>   
## The Heap  
 The heap’s size can be computed by a stream reader by subtracting the length of the stream from the directory size + 4. In other words:  
  
```  
Heap Size = Stream.Length – (Directory Size + 4)  
```  
  
 where the directory size is `N * 8`.  
  
 The format for each instantiation information item on the heap is:  
  
-   The length of this instantiation information item in bytes in compressed ECMA metadata format. The value excludes this length information.  
  
-   The number of generic instantiation types, or *T*, in compressed ECMA metadata format.  
  
-   *T* types, each represented in ECMA type signature format.  
  
 The inclusion of the length for each heap element enables simple sorting of the directory section without affecting the heap.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [ICorDebugSymbolProvider2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugsymbolprovider2-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
