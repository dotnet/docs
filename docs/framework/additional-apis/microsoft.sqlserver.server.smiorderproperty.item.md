---
title: SmiOrderProperty.Item Property (Microsoft.SqlServer.Server)
author: douglaslMS
ms.author: douglasl
ms.date: 12/20/2018
ms.technology:
  - "dotnet-data"
api_name:
  - "Microsoft.SqlServer.Server.SmiOrderProperty.Item"
  - "Microsoft.SqlServer.Server.SmiOrderProperty.get_Item"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SmiOrderProperty.Item Property

Gets the column order for the entity. The assembly that contains this property has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

## Syntax

```csharp
internal SmiColumnOrder Item { get; }
```

## Property value

The column order.

## Remarks

> [!WARNING]
> The `SmiOrderProperty.Item` property is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this property in a production application under any circumstance.

## Requirements

**Namespace:** <xref:Microsoft.SqlServer.Server>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.