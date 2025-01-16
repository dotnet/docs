---
title: Handle unmapped members during deserialization
description: "Learn how to configure the JSON deserialization behavior when properties are present in the JSON payload that aren't present in the POCO type."
ms.date: 01/15/2025
no-loc: [System.Text.Json]
dev_langs:
  - "csharp"
---

# Handle unmapped members during deserialization

By default, if the JSON payload you're deserializing contains properties that don't exist in the plain old CLR object (POCO) type, they're simply ignored. Starting in .NET 8, you can specify that *all payload properties must exist in the POCO*. If they're not, a <xref:System.Text.Json.JsonException> exception is thrown during deserialization. You can configure this behavior in one of three ways:

- Annotate your POCO type with the <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandlingAttribute> attribute, specifying either to <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip> or <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow> unmapped members.

  ```csharp
  [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
  public class MyPoco
  {
       public int Id { get; set; }
  }

  JsonSerializer.Deserialize<MyPoco>("""{"Id" : 42, "AnotherId" : -1 }""");
  // JsonException : The JSON property 'AnotherId' could not be mapped to any .NET member contained in type 'MyPoco'.
  ```

- Set <xref:System.Text.Json.JsonSerializerOptions.UnmappedMemberHandling?displayProperty=nameWithType> to either <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip> or <xref:System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow>.
- Customize the <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> contract for the relevant type. (For information about customizing a contract, see [Customize a JSON contract](custom-contracts.md).)
