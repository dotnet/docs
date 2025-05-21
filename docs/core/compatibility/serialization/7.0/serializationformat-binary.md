---
title: ".NET 7 breaking change: SerializationFormat.Binary is obsolete"
description: Learn about the .NET 7 breaking change in core .NET libraries where binary serialization and deserialization of DataSet and DataTable objects is obsolete.
ms.date: 03/18/2022
ms.topic: article
---
# SerializationFormat.Binary is obsolete

<xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType> is obsolete for <xref:System.Data.DataTable> and <xref:System.Data.DataSet>. Binary serialization relies on <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, which is insecure. If you use <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType> in your code, obsoletion warning [SYSLIB0038](../../../../fundamentals/syslib-diagnostics/syslib0038.md) will be generated at compile time.

In addition, an <xref:System.ComponentModel.InvalidEnumArgumentException> is thrown at run time if you:

- Set <xref:System.Data.DataSet.RemotingFormat?displayProperty=nameWithType> or <xref:System.Data.DataTable.RemotingFormat?displayProperty=nameWithType> to <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>.
- Call one of the deserialization constructors for <xref:System.Data.DataTable> or <xref:System.Data.DataSet> with binary data.

## Previous behavior

Previously, <xref:System.Data.DataTable> and <xref:System.Data.DataSet> could be serialized and deserialized with their <xref:System.Data.DataTable.RemotingFormat> property set to <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>, which used <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> under the hood.

## New behavior

Starting in .NET 7, if you attempt to serialize or deserialize <xref:System.Data.DataTable> and <xref:System.Data.DataSet> with their <xref:System.Data.DataTable.RemotingFormat> property set to <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>, an <xref:System.ComponentModel.InvalidEnumArgumentException> is thrown.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

<xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType> is implemented via <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, which is insecure and being obsoleted across the entire .NET stack.

## Recommended action

If your code uses <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>, switch to using <xref:System.Data.SerializationFormat.Xml?displayProperty=nameWithType> or use another method of serialization.

Otherwise, you can set the `Switch.System.Data.AllowUnsafeSerializationFormatBinary` <xref:System.AppContext> switch. This switch lets you opt in to allowing the use of <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType>, so that code can work as before. However, this switch will be removed in .NET 8. For information about setting the switch, see [AppContext for library consumers](/dotnet/api/system.appcontext#appcontext-for-library-consumers).

## Affected APIs

- <xref:System.Data.SerializationFormat.Binary?displayProperty=fullName>
- <xref:System.Data.DataSet.RemotingFormat?displayProperty=nameWithType>
- <xref:System.Data.DataTable.RemotingFormat?displayProperty=nameWithType>
- <xref:System.Data.DataSet.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)>
- <xref:System.Data.DataSet.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext,System.Boolean)>
- <xref:System.Data.DataTable.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)>

## See also

- [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps](../5.0/binaryformatter-serialization-obsolete.md)
