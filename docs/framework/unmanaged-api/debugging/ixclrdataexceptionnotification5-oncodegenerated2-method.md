---
description: "Learn more about: IXCLRDataExceptionNotification5::OnCodeGenerated2 Method"
title: "IXCLRDataExceptionNotification5::OnCodeGenerated2 Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification5::OnCodeGenerated2 Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification5::OnCodeGenerated2 Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification5::OnCodeGenerated2 Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification5::OnCodeGenerated2 Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the generation of code for a particular method instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnCodeGenerated2(
    [in] IXCLRDataMethodInstance *method,
    [in] CLRDATA_ADDRESS nativeCodeLocation
);
```

## Parameters

`method`\
[in] The method instance for which code was generated.

`nativeCodeLocation`\
[in] The starting address of the newly jitted code.

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification5` interface and corresponds to the 17th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)
- [IXCLRDataExceptionNotification2 Interface](ixclrdataexceptionnotification2-interface.md)
- [IXCLRDataExceptionNotification3 Interface](ixclrdataexceptionnotification3-interface.md)
- [IXCLRDataExceptionNotification4 Interface](ixclrdataexceptionnotification4-interface.md)
