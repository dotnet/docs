---
title: Serialization breaking changes
description: Lists the breaking changes in the serialization category in .NET Core and .NET 5.0 and later.
ms.date: 07/30/2020
---
# Serialization breaking changes

The following breaking changes are documented on this page:

| Breaking change | Introduced version |
| - | - |
| [JsonSerializer.Deserialize requires single-character string](#jsonserializerdeserialize-requires-single-character-string) | 5.0 |
| [BinaryFormatter.Deserialize rewraps some exceptions in SerializationException](#binaryformatterdeserialize-rewraps-some-exceptions-in-serializationexception) | 5.0 |
| [JsonSerializer.Deserialize throws JsonException for null or empty strings](#jsonserializerdeserialize-throws-jsonexception-for-null-or-empty-strings) | 3.1 |

## .NET 5.0

[!INCLUDE [deserializing-json-into-char-requires-single-character](../../../includes/core-changes/serialization/5.0/deserializing-json-into-char-requires-single-character.md)]

***

[!INCLUDE [binaryformatter-deserialize-rewraps-exceptions](../../../includes/core-changes/serialization/5.0/binaryformatter-deserialize-rewraps-exceptions.md)]

***

## .NET Core 3.1

[!INCLUDE [jsonserializer-deserialize-throws-jsonexception](../../../includes/core-changes/serialization/3.1/jsonserializer-deserialize-throws-jsonexception.md)]
