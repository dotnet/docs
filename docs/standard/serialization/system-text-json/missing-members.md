---
title: Handle missing members during deserialization
description: "Learn how to configure the JSON deserialization behavior when properties are present in the JSON payload that aren't present in the POCO type."
ms.date: 02/21/2023
no-loc: [System.Text.Json]
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
---

# Handle missing members during deserialization

By default, if the JSON payload you're deserializing contains properties that don't exist in the deserialized plain old CLR object (POCO) type, they're simply ignored. Starting in .NET 8, you can specify that all members must be present in the payload. If they're not, a <xref:System.Text.Json.JsonException> exception is thrown. You can configure this behavior in one of three ways:

- Annotate your POCO type with the `[JsonUnmappedMemberHandlingAttribute]` attribute, specifying either to `Skip` or `Disallow` missing members.

  ```csharp
  [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
  public class MyPoco
  {
       public int Id { get; set; }
  }

  JsonSerializer.Deserialize<MyPoco>("""{"Id" : 42, "AnotherId" : -1 }"""); 
  // JsonException : The JSON property 'AnotherId' could not be mapped to any .NET member contained in type 'MyPoco'.
  ```

- Set `JsonSerializerOptions.JsonUnmappedMemberHandling` to either `JsonUnmappedMemberHandling.Skip` or `JsonUnmappedMemberHandling.Disallow`.
- Customize the <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> contract for the relevant type. (For information about customizing a contract, see [Customize a JSON contract](custom-contracts.md).)
