---
author: IEvangelist
ms.author: dapine
ms.date: 01/11/2023
ms.topic: include
recommendations: false
---

With .NET 7+, `System.Text.Json` supports serializing and deserializing <xref:System.DateOnly> and <xref:System.TimeOnly> types. Consider the following object:

:::code source="../snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="appointment":::

The following example serializes an `Appointment` object, displays the resulting JSON, and then deserializes it back into a new instance of the `Appointment` type. Finally, the original and newly deserialized instances are compared for equality and the results are written to the console:

:::code source="../snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="serialization":::

In the preceding code:

- An `Appointment` object is instantiated and assigned to the `appointment` variable.
- The `appointment` instance is serialized to JSON using <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType>.
- The resulting JSON is written to the console.
- The JSON is deserialized back into a new instance of the `Appointment` type using <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType>.
- The original and newly deserialized instances are compared for equality.
- The result of the comparison is written to the console.
