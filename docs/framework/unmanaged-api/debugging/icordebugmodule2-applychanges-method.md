---
description: "Learn more about: ICorDebugModule2::ApplyChanges Method"
title: "ICorDebugModule2::ApplyChanges Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule2.ApplyChanges"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule2::ApplyChanges"
helpviewer_keywords:
  - "ApplyChanges method [.NET Framework debugging]"
  - "ICorDebugModule2::ApplyChanges method [.NET Framework debugging]"
ms.assetid: 96fa3406-6a6f-41a1-88c6-d9bc5d1a16d1
topic_type:
  - "apiref"
---
# ICorDebugModule2::ApplyChanges Method

Applies the changes in the metadata and the changes in the common intermediate language (CIL) code to the running process.

## Syntax

```cpp
HRESULT ApplyChanges (
    [in] ULONG                       cbMetadata,
    [in, size_is(cbMetadata)] BYTE   pbMetadata[],
    [in] ULONG                       cbIL,
    [in, size_is(cbIL)] BYTE         pbIL[]
);
```

## Parameters

 `cbMetadata`
 [in] Size, in bytes, of the delta metadata.

 `pbMetadata`
 [in] Buffer that contains the delta metadata. The address of the buffer is returned from the [IMetaDataEmit2::SaveDeltaToMemory](../../../core/unmanaged-apis/metadata/imetadataemit2-savedeltatomemory-method.md) method.

 The relative virtual addresses (RVAs) in the metadata should be relative to the start of the CIL code.

 `cbIL`
 [in] Size, in bytes, of the delta CIL code.

 `pbIL`
 [in] Buffer that contains the updated CIL code.

## Remarks

 The `pbMetadata` parameter is in a special delta metadata format (as output by [IMetaDataEmit2::SaveDeltaToMemory](../../../core/unmanaged-apis/metadata/imetadataemit2-savedeltatomemory-method.md)). `pbMetadata` takes previous metadata as a base and describes individual changes to apply to that base.

 In contrast, the `pbIL[`] parameter contains the new CIL for the updated method, and is meant to completely replace the previous CIL for that method

 When the delta CIL and the metadata have been created in the debugger’s memory, the debugger calls `ApplyChanges` to send the changes into the common language runtime (CLR). The runtime updates its metadata tables, places the new CIL into the process, and sets up a just-in-time (JIT) compilation of the new CIL. When the changes have been applied, the debugger should call [IMetaDataEmit2::ResetENCLog](../../../core/unmanaged-apis/metadata/imetadataemit2-resetenclog-method.md) to prepare for the next editing session. The debugger may then continue the process.

 Whenever the debugger calls `ApplyChanges` on a module that has delta metadata, it should also call [IMetaDataEmit::ApplyEditAndContinue](../../../core/unmanaged-apis/metadata/imetadataemit-applyeditandcontinue-method.md) with the same delta metadata on all of its copies of that module’s metadata except for the copy used to emit the changes. If a copy of the metadata somehow becomes out-of-sync with the actual metadata, the debugger can always throw away that copy and obtain a new copy.

 If the `ApplyChanges` method fails, the debug session is in an invalid state and must be restarted.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
