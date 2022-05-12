---
description: "Learn more about: SqlBinary Constructor"
title: SqlBinary Constructor (System.Data.SqlTypes)
author: grabyourpitchforks
ms.date: 04/04/2022
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlBinary..ctor"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlBinary Constructor

Initializes a new instance of the `SqlBinary` struct without making a copy of the `byte` array passed via the `value` parameter. Future mutations to this array may cause the resulting `SqlBinary` instance to change its value.

The `ignored` parameter is ignored.

```csharp
internal SqlBinary(byte[] value, bool ignored);
```

## Remarks

> [!WARNING]
> This overload of the `SqlBinary` constructor is internal and is not meant to be used directly in your code. This API may not be available in future versions of .NET.
>
> Microsoft does not support the use of this constructor in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
