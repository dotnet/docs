---
title: How to use a JSON DOM in System.Text.Json
description: "Learn how to use a JSON document object model (DOM)."
ms.date: 03/29/2022
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
---

# How to use a JSON document object model in System.Text.Json

This article shows how to use a [JSON document object model (DOM)](#json-dom-choices) for random access to data in a JSON payload.

## JSON DOM choices

Working with a DOM is an alternative to deserialization with <xref:System.Text.Json.JsonSerializer> when:

* You don't have a type to deserialize into.
* The JSON you receive doesn't have a fixed schema and must be inspected to know what it contains.

`System.Text.Json` provides two ways to build a JSON DOM:

* <xref:System.Text.Json.JsonDocument> provides the ability to build a read-only DOM by using `Utf8JsonReader`. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.JsonElement> type. The `JsonElement` type provides array and object enumerators along with APIs to convert JSON text to common .NET types. `JsonDocument` exposes a <xref:System.Text.Json.JsonDocument.RootElement> property. For more information, see [Use JsonDocument](#use-jsondocument) later in this article.

* <xref:System.Text.Json.Nodes.JsonNode> and the classes that derive from it in the <xref:System.Text.Json.Nodes> namespace provide the ability to create a mutable DOM. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.Nodes.JsonNode>, <xref:System.Text.Json.Nodes.JsonObject>, <xref:System.Text.Json.Nodes.JsonArray>, <xref:System.Text.Json.Nodes.JsonValue>, and <xref:System.Text.Json.JsonElement> types. For more information, see [Use `JsonNode`](#use-jsonnode) later in this article.

Consider the following factors when choosing between `JsonDocument` and `JsonNode`:

* The `JsonNode` DOM can be changed after it's created. The `JsonDocument` DOM is immutable.
* The `JsonDocument` DOM provides faster access to its data.

## Use `JsonNode`

The following example shows how to use <xref:System.Text.Json.Nodes.JsonNode> and the other types in the <xref:System.Text.Json.Nodes> namespace to:

* Create a DOM from a JSON string
* Write JSON from a DOM.
* Get a value, object, or array from a DOM.

:::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeFromStringExample.cs":::

### Create a JsonNode DOM with object initializers and make changes

The following example shows how to:

* Create a DOM by using object initializers.
* Make changes to a DOM.

:::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeFromObjectExample.cs":::

### Deserialize subsections of a JSON payload

The following example shows how to use [JsonNode](#json-dom-choices) to navigate to a subsection of a JSON tree and deserialize a single value, a custom type, or an array from that subsection.

:::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodePOCOExample.cs":::

### JsonNode average grade example

The following example selects a JSON array that has integer values and calculates an average value:

:::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeAverageGradeExample.cs":::

The preceding code:

* Calculates an average grade for objects in a `Students` array that have a `Grade` property.
* Assigns a default grade of 70 for students who don't have a grade.
* Gets the number of students from the `Count` property of `JsonArray`.

### `JsonNode` with `JsonSerializerOptions`

You can use `JsonSerializer` to serialize and deserialize an instance of `JsonNode`. However, if you use an overload that takes `JsonSerializerOptions`, the options instance is only used to get custom converters. Other features of the options instance are not used. For example, if you set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition%2A?displayProperty=nameWithType> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull> and call `JsonSerializer` with an overload that takes `JsonSerializerOptions`, null properties won't be ignored.

The same limitation applies to the `JsonNode` methods that take a `JsonSerializerOptions` parameter: <xref:System.Text.Json.Nodes.JsonNode.WriteTo(System.Text.Json.Utf8JsonWriter,System.Text.Json.JsonSerializerOptions)> and <xref:System.Text.Json.Nodes.JsonNode.ToJsonString(System.Text.Json.JsonSerializerOptions)>. These APIs use `JsonSerializerOptions` only to get custom converters.

The following example illustrates the result of using methods that take a `JsonSerializerOptions` parameter and serialize a `JsonNode` instance:

:::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeWithJsonSerializerOptions.cs" :::

If you need features of `JsonSerializerOptions` other than custom converters, use `JsonSerializer` with strongly typed targets (such as the `Person` class in this example) rather than `JsonNode`.

## Use `JsonDocument`

The following example shows how to use the <xref:System.Text.Json.JsonDocument> class for random access to data in a JSON string:

:::code language="csharp" source="snippets/how-to/csharp/JsonDocumentDataAccess.cs" id="AverageGrades1":::
:::code language="vb" source="snippets/how-to/vb/JsonDocumentDataAccess.vb" id="AverageGrades1":::

The preceding code:

* Assumes the JSON to analyze is in a string named `jsonString`.
* Calculates an average grade for objects in a `Students` array that have a `Grade` property.
* Assigns a default grade of 70 for students who don't have a grade.
* Creates the `JsonDocument` instance in a [`using` statement](../../../csharp/language-reference/statements/using.md) because `JsonDocument` implements `IDisposable`. After a `JsonDocument` instance is disposed, you lose access to all of its `JsonElement` instances also. To retain access to a `JsonElement` instance, make a copy of it before the parent `JsonDocument` instance is disposed. To make a copy, call <xref:System.Text.Json.JsonElement.Clone%2A?displayProperty=nameWithType>. For more information, see [JsonDocument is IDisposable](migrate-from-newtonsoft.md#jsondocument-is-idisposable).

The preceding example code counts students by incrementing a `count` variable with each iteration. An alternative is to call <xref:System.Text.Json.JsonElement.GetArrayLength%2A>, as shown in the following example:

  :::code language="csharp" source="snippets/how-to/csharp/JsonDocumentDataAccess.cs" id="AverageGrades2":::
  :::code language="vb" source="snippets/how-to/vb/JsonDocumentDataAccess.vb" id="AverageGrades2":::

Here's an example of the JSON that this code processes:

:::code language="json" source="snippets/how-to/csharp/GradesPrettyPrint.json":::

For a similar example that uses `JsonNode` instead of `JsonDocument`, see [JsonNode average grade example](#jsonnode-average-grade-example).

### How to search a JsonDocument and JsonElement for sub-elements

Searches on `JsonElement` require a sequential search of the properties and hence are relatively slow (for example when using `TryGetProperty`). <xref:System.Text.Json?displayProperty=fullName> is designed to minimize initial parse time rather than lookup time. Therefore, use the following approaches to optimize performance when searching through a `JsonDocument` object:

* Use the built-in enumerators (<xref:System.Text.Json.JsonElement.EnumerateArray%2A> and <xref:System.Text.Json.JsonElement.EnumerateObject%2A>) rather than doing your own indexing or loops.
* Don't do a sequential search on the whole `JsonDocument` through every property by using `RootElement`. Instead, search on nested JSON objects based on the known structure of the JSON data. For example, the preceding code examples look for a `Grade` property in `Student` objects by looping through the `Student` objects and getting the value of `Grade` for each, rather than searching through all `JsonElement` objects looking for `Grade` properties. Doing the latter would result in unnecessary passes over the same data.

### Use `JsonDocument` to write JSON

The following example shows how to write JSON from a <xref:System.Text.Json.JsonDocument>:

:::code language="csharp" source="snippets/how-to/csharp/JsonDocumentWriteJson.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/JsonDocumentWriteJson.vb" id="Serialize":::

The preceding code:

* Reads a JSON file, loads the data into a `JsonDocument`, and writes formatted (pretty-printed) JSON to a file.
* Uses <xref:System.Text.Json.JsonDocumentOptions> to specify that comments in the input JSON are allowed but ignored.
* When finished, calls <xref:System.Text.Json.Utf8JsonWriter.Flush%2A> on the writer. An alternative is to let the writer auto-flush when it's disposed.

Here's an example of JSON input to be processed by the example code:

:::code language="json" source="snippets/how-to/csharp/Grades.json":::

The result is the following pretty-printed JSON output:

:::code language="json" source="snippets/how-to/csharp/GradesPrettyPrint.json":::

### JsonDocument is IDisposable

`JsonDocument` builds an in-memory view of the data into a pooled buffer. Therefore the `JsonDocument` type implements `IDisposable` and needs to be used inside a `using` block.

Only return a `JsonDocument` from your API if you want to transfer lifetime ownership and dispose responsibility to the caller. In most scenarios, that isn't necessary. If the caller needs to work with the entire JSON document, return the <xref:System.Text.Json.JsonElement.Clone%2A> of the <xref:System.Text.Json.JsonDocument.RootElement%2A>, which is a <xref:System.Text.Json.JsonElement>. If the caller needs to work with a particular element within the JSON document, return the <xref:System.Text.Json.JsonElement.Clone%2A> of that <xref:System.Text.Json.JsonElement>. If you return the `RootElement` or a sub-element directly without making a `Clone`, the caller won't be able to access the returned `JsonElement` after the `JsonDocument` that owns it is disposed.

Here's an example that requires you to make a `Clone`:

```csharp
public JsonElement LookAndLoad(JsonElement source)
{
    string json = File.ReadAllText(source.GetProperty("fileName").GetString());

    using (JsonDocument doc = JsonDocument.Parse(json))
    {
        return doc.RootElement.Clone();
    }
}
```

The preceding code expects a `JsonElement` that contains a `fileName` property. It opens the JSON file and creates a `JsonDocument`. The method assumes that the caller wants to work with the entire document, so it returns the `Clone` of the `RootElement`.

If you receive a `JsonElement` and are returning a sub-element, it's not necessary to return a `Clone` of the sub-element. The caller is responsible for keeping alive the `JsonDocument` that the passed-in `JsonElement` belongs to. For example:

```csharp
public JsonElement ReturnFileName(JsonElement source)
{
   return source.GetProperty("fileName");
}
```

### `JsonDocument` with `JsonSerializerOptions`

You can use `JsonSerializer` to serialize and deserialize an instance of `JsonDocument`. However, the implementation for reading and writing `JsonDocument` instances by using `JsonSerializer` is a wrapper over the <xref:System.Text.Json.JsonDocument.ParseValue(System.Text.Json.Utf8JsonReader@)?displayProperty=nameWithType> and <xref:System.Text.Json.JsonDocument.WriteTo(System.Text.Json.Utf8JsonWriter)?displayProperty=nameWithType>. This wrapper does not forward any `JsonSerializerOptions` (serializer features) to `Utf8JsonReader` or `Utf8JsonWriter`. For example, if you set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition%2A?displayProperty=nameWithType> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull> and call `JsonSerializer` with an overload that takes `JsonSerializerOptions`, null properties won't be ignored.

The following example illustrates the result of using methods that take a `JsonSerializerOptions` parameter and serialize a `JsonDocument` instance:

:::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonDocumentWithJsonSerializerOptions.cs" :::

If you need features of `JsonSerializerOptions`, use `JsonSerializer` with strongly typed targets (such as the `Person` class in this example) rather than `JsonDocument`.

## See also

* [System.Text.Json overview](overview.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
