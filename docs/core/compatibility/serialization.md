---
title: Serialization breaking changes
description: Lists the breaking changes in the serialization category in .NET Core and .NET 5.0 and later.
ms.date: 07/30/2020
---
# Serialization breaking changes

The following breaking changes are documented on this page:

| Breaking change | Introduced version |
| - | - |
| [BinaryFormatter.Deserialize rewraps some exceptions in SerializationException](#binaryformatterdeserialize-rewraps-some-exceptions-in-serializationexception) | 5.0 |
| [JSON serializer exception type changed from JsonException to NotSupportedException](#json-serializer-exception-type-changed-from-jsonexception-to-notsupportedexception) | 3.0 |

## .NET Core 5.0

[!INCLUDE [binaryformatter-deserialize-rewraps-exceptions](../../../includes/core-changes/serialization/5.0/binaryformatter-deserialize-rewraps-exceptions.md)]

***

## .NET Core 3.0

[!INCLUDE[JSON serializer exception type changed from JsonException to NotSupportedException](~/includes/core-changes/serialization/3.0/serializer-throws-notsupportedexception.md)]

***
