---
description: "Learn more about: CorDebugEHClause Structure"
title: "CorDebugEHClause Structure"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "CorDebugEHClause"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# CorDebugEHClause Structure

Represents an exception handling (EH) clause for a given piece of intermediate language (IL) code.

## Syntax

```cpp
typedef struct _CorDebugEHClause {
   ULONG32 Flags;
   ULONG32 TryOffset;
   ULONG32 TryLength;
   ULONG32 HandlerOffset;
   ULONG32 HandlerLength;
   ULONG32 ClassToken;
   ULONG32 FilterOffset;
} CorDebugEHClause;
```

## Members

|Member|Description|
|------------|-----------------|
|`Flags`|A bit field that describes the exception information in the EH clause. For more information, see the Remarks section.|
|`TryOffset`|The offset, in bytes, of the `try` block from the start of the method body.|
|`TryLength`|The length, in bytes, of the `try` block.|
|`HandlerOffset`|The location of the handler for this `try` block.|
|`HandlerLength`|The size of the handler code in bytes.|
|`ClassToken`|The metadata token for a type-based exception handler.|
|`FilterOffset`|The offset, in bytes, from the start of the method body for a filter-based exception handler.|

## Remarks

 An array of `CoreDebugEHClause` values is returned by the [GetEHClauses](icordebugilcode-getehclauses-method.md) method.

 The EH clause information is defined by the CLI specification. For more information, see [Standard ECMA-355: Common Language Infrastructure (CLI), 6th Edition](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

 The `flags` field can contain the following flags. Note that they are not defined in CorDebug.idl or CorDebug.h.

|Flag|Value|Description|
|----------|-----------|-----------------|
|`COR_ILEXCEPTION_CLAUSE_EXCEPTION`|0x00000000|A typed exception clause.|
|`COR_ILEXCEPTION_CLAUSE_FILTER`|0x00000001|An exception filter and handler clause.|
|`COR_ILEXCEPTION_CLAUSE_FINALLY`|0x00000002|A `finally` clause.|
|`COR_ILEXCEPTION_CLAUSE_FAULT`|0x00000004|A fault clause (a `finally` clause that is called only when an exception is thrown).|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [GetEHClauses Method](icordebugilcode-getehclauses-method.md)
