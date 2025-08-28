---
description: "Learn more about: ICorDebugProcess7::SetWriteableMetadataUpdateMode Method"
title: "ICorDebugProcess7::SetWriteableMetadataUpdateMode Method"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ICorDebugProcess7.SetWriteableMetadataUpdateMode"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ICorDebugProcess7::SetWriteableMetadataUpdateMode Method

[Supported in the .NET Framework 4.5.2 and later versions]

 Configures how the debugger handles in-memory updates to metadata within the target process.

## Syntax

```cpp
HRESULT SetWriteableMetadataUpdateMode(
   WriteableMetadataUpdateMode flags
);
```

## Parameters

 `flags`\
 A [WriteableMetadataUpdateMode](../../../../framework/unmanaged-api/debugging/writeablemetadataupdatemode-enumeration.md) enumeration value that specifies whether in-memory updates to metadata in the target process are visible (`WriteableMetadataUpdateMode::AlwaysShowUpdates`) or not visible (`WriteableMetadataUpdateMode::LegacyCompatPolicy`) to the debugger.

## Remarks

 Updates to the metadata of the target process can come from Edit and Continue, a profiler, or <xref:System.Reflection.Emit?displayProperty=nameWithType>.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [ICorDebugProcess7 Interface](icordebugprocess7-interface.md)
