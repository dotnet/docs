---
title: SYSLIB0038 warning - SerializationFormat.Binary is obsolete
description: Learn about the obsoletion of SerializationFormat.Binary that generates compile-time warning SYSLIB0038.
ms.date: 03/18/2022
---
# SYSLIB0038: SerializationFormat.Binary is obsolete

<xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType> is marked as obsolete, starting in .NET 7. Using this API in code generates warning `SYSLIB0038` at compile time.

## Workaround

If your code uses <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>, switch to using <xref:System.Data.SerializationFormat.Xml?displayProperty=nameWithType> or use another method of serialization.

Otherwise, you can set the `Switch.System.Data.AllowUnsafeSerializationFormatBinary` <xref:System.AppContext> switch. This switch lets you opt in to allowing the use of <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>, so that code can work as before. However, this switch will be removed in .NET 8. For information about setting the switch, see [AppContext for library consumers](/dotnet/api/system.appcontext#appcontext-for-library-consumers).

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [SerializationFormat.Binary is obsolete](../../core/compatibility/core-libraries/7.0/serializationformat-binary.md)
