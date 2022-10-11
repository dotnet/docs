---
description: "Learn more about: SqlMoney Constructor"
title: SqlMoney Constructor (System.Data.SqlTypes)
author: grabyourpitchforks
ms.date: 04/04/2022
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlMoney..ctor"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlMoney Constructor

Initializes a new instance of the `SqlMoney` struct, where `value` has already been scaled by a ten-thousandth of a currency unit. For example, if **20000** is provided for the `value` parameter, this `SqlMoney` instance will represent **2** currency units.

The `ignored` parameter is ignored.

```csharp
internal SqlMoney(long value, int ignored);
```

## Remarks

> [!WARNING]
> This overload of the `SqlMoney` constructor is internal and is not meant to be used directly in your code. This API may not be available in future versions of .NET.
>
> Microsoft does not support the use of this constructor in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
