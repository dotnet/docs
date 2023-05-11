---
description: "Learn more about: SqlMoney.ToSqlInternalRepresentation Method"
title: SqlMoney.ToSqlInternalRepresentation Method (System.Data.SqlTypes)
author: grabyourpitchforks
ms.date: 06/16/2022
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlMoney.ToSqlInternalRepresentation"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlMoney.ToSqlInternalRepresentation Method

Returns the value of this `SqlMoney` instance scaled by a ten-thousandth of a currency unit.
For example, if the current `SqlMoney` instance represents **2** currency units, the
`ToSqlInternalRepresentation` method will return **20000**.

If this `SqlMoney` instance represents a null value (see <xref:System.Data.SqlTypes.SqlMoney.IsNull>), calling this method will throw a <xref:System.Data.SqlTypes.SqlNullValueException>.

```csharp
internal long ToSqlInternalRepresentation();
```

## Remarks

> [!WARNING]
> This method is internal and is not meant to be used directly in your code. This API may not be available in future versions of .NET.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
