---
title: How to use a JSON document, Utf8JsonReader, and Utf8JsonWriter in System.Text.Json
description: "Learn how to use a JSON document object model (DOM), Utf8JsonReader, and Utf8JsonWriter."
ms.date: 11/26/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
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

# How to use a JSON document, Utf8JsonReader, and Utf8JsonWriter in System.Text.Json

This article shows how to use:

* A [JSON Document Object Model (DOM)](#json-dom-choices) for random access to data in a JSON payload.
* The [`Utf8JsonWriter`](#use-utf8jsonwriter) type for building custom serializers.
* The [`Utf8JsonReader`](#use-utf8jsonreader) type for building custom parsers and deserializers.

## JSON DOM choices

Working with a DOM is an alternative to deserialization with <xref:System.Text.Json.JsonSerializer>:

* When you don't have a type to deserialize into.
* When the JSON you receive doesn't have a fixed schema and must be inspected to know what it contains.

`System.Text.Json` provides two ways to build a JSON DOM:

* <xref:System.Text.Json.JsonDocument> provides the ability to build a read-only DOM by using `Utf8JsonReader`. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.JsonElement> type. The `JsonElement` type provides array and object enumerators along with APIs to convert JSON text to common .NET types. `JsonDocument` exposes a <xref:System.Text.Json.JsonDocument.RootElement> property. For more information, see [Use JsonDocument](#use-jsondocument) later in this article.

:::zone pivot="dotnet-6-0"

* <xref:System.Text.Json.Nodes.JsonNode> and the classes that derive from it in the <xref:System.Text.Json.Nodes> namespace provide the ability to create a mutable DOM. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.Nodes.JsonNode>, <xref:System.Text.Json.Nodes.JsonObject>, <xref:System.Text.Json.Nodes.JsonArray>, <xref:System.Text.Json.Nodes.JsonValue>, and <xref:System.Text.Json.JsonElement> types. For more information, see [Use `JsonNode`](#use-jsonnode) later in this article.

Consider the following factors when choosing between `JsonDocument` and `JsonNode`:

* The `JsonNode` DOM can be changed after it's created. The `JsonDocument` DOM is immutable.
* The `JsonDocument` DOM provides faster access to its data.

:::zone-end

:::zone pivot="dotnet-5-0,dotnet-core-3-1"

* Starting in .NET 6, <xref:System.Text.Json.Nodes.JsonNode> and the classes that derive from it in the <xref:System.Text.Json.Nodes> namespace provide the ability to create a mutable DOM. For more information, see the [.NET 6 version of this article](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md?pivots=dotnet-6-0).

:::zone-end

:::zone pivot="dotnet-6-0"

## Use `JsonNode`

The following example shows how to use <xref:System.Text.Json.Nodes.JsonNode> and the other types in the <xref:System.Text.Json.Nodes> namespace to:

* Create a DOM from a JSON string
* Write JSON from a DOM.
* Get a value, object, or array from a DOM.

:::code language="csharp" source="snippets/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeFromStringExample.cs":::

### Create a JsonNode DOM with object initializers and make changes

The following example shows how to:

* Create a DOM by using object initializers.
* Make changes to a DOM.

:::code language="csharp" source="snippets/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeFromObjectExample.cs":::

### Deserialize subsections of a JSON payload

The following example shows how to use [JsonNode](#json-dom-choices) to navigate to a subsection of a JSON tree and deserialize a single value, a custom type, or an array from that subsection.

:::code language="csharp" source="snippets/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodePOCOExample.cs":::

### JsonNode average grade example

The following example selects a JSON array that has integer values and calculates an average value:

:::code language="csharp" source="snippets/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter/csharp/JsonNodeAverageGradeExample.cs":::

The preceding code:

* Calculates an average grade for objects in a `Students` array that have a `Grade` property.
* Assigns a default grade of 70 for students who don't have a grade.
* Gets the number of students from the `Count` property of `JsonArray`.

::: zone-end

## Use `JsonDocument`

The following example shows how to use the <xref:System.Text.Json.JsonDocument> class for random access to data in a JSON string:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/JsonDocumentDataAccess.cs" id="AverageGrades1":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/JsonDocumentDataAccess.vb" id="AverageGrades1":::

The preceding code:

* Assumes the JSON to analyze is in a string named `jsonString`.
* Calculates an average grade for objects in a `Students` array that have a `Grade` property.
* Assigns a default grade of 70 for students who don't have a grade.
* Creates the `JsonDocument` instance in a [`using` statement](../../csharp/language-reference/keywords/using-statement.md) because `JsonDocument` implements `IDisposable`. After a `JsonDocument` instance is disposed, you lose access to all of its `JsonElement` instances also. To retain access to a `JsonElement` instance, make a copy of it before the parent `JsonDocument` instance is disposed. To make a copy, call <xref:System.Text.Json.JsonElement.Clone%2A?displayProperty=nameWithType>. For more information, see [JsonDocument is IDisposable](system-text-json-migrate-from-newtonsoft-how-to.md#jsondocument-is-idisposable).

The preceding example code counts students by incrementing a `count` variable with each iteration. An alternative is to call <xref:System.Text.Json.JsonElement.GetArrayLength%2A>, as shown in the following example:

  :::code language="csharp" source="snippets/system-text-json-how-to/csharp/JsonDocumentDataAccess.cs" id="AverageGrades2":::
  :::code language="vb" source="snippets/system-text-json-how-to/vb/JsonDocumentDataAccess.vb" id="AverageGrades2":::

Here's an example of the JSON that this code processes:

:::code language="json" source="snippets/system-text-json-how-to/csharp/GradesPrettyPrint.json":::

:::zone pivot="dotnet-6-0"
For a similar example that uses `JsonNode` instead of `JsonDocument`, see [JsonNode average grade example](#jsonnode-average-grade-example).
:::zone-end

### How to search a JsonDocument and JsonElement for sub-elements

Searches on `JsonElement` require a sequential search of the properties and hence are relatively slow (for example when using `TryGetProperty`). <xref:System.Text.Json> is designed to minimize initial parse time rather than lookup time. Therefore, use the following approaches to optimize performance when searching through a `JsonDocument` object:

* Use the built-in enumerators (<xref:System.Text.Json.JsonElement.EnumerateArray%2A> and <xref:System.Text.Json.JsonElement.EnumerateObject%2A>) rather than doing your own indexing or loops.
* Don't do a sequential search on the whole `JsonDocument` through every property by using `RootElement`. Instead, search on nested JSON objects based on the known structure of the JSON data. For example, the preceding code examples look for a `Grade` property in `Student` objects by looping through the `Student` objects and getting the value of `Grade` for each, rather than searching through all `JsonElement` objects looking for `Grade` properties. Doing the latter would result in unnecessary passes over the same data.

### Use `JsonDocument` to write JSON

The following example shows how to write JSON from a <xref:System.Text.Json.JsonDocument>:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/JsonDocumentWriteJson.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/JsonDocumentWriteJson.vb" id="Serialize":::

The preceding code:

* Reads a JSON file, loads the data into a `JsonDocument`, and writes formatted (pretty-printed) JSON to a file.
* Uses <xref:System.Text.Json.JsonDocumentOptions> to specify that comments in the input JSON are allowed but ignored.
* When finished, calls <xref:System.Text.Json.Utf8JsonWriter.Flush%2A> on the writer. An alternative is to let the writer auto-flush when it's disposed.

Here's an example of JSON input to be processed by the example code:

:::code language="json" source="snippets/system-text-json-how-to/csharp/Grades.json":::

The result is the following pretty-printed JSON output:

:::code language="json" source="snippets/system-text-json-how-to/csharp/GradesPrettyPrint.json":::

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

## Use `Utf8JsonWriter`

<xref:System.Text.Json.Utf8JsonWriter> is a high-performance way to write UTF-8 encoded JSON text from common .NET types like `String`, `Int32`, and `DateTime`. The writer is a low-level type that can be used to build custom serializers. The <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType> method uses `Utf8JsonWriter` under the covers.

The following example shows how to use the <xref:System.Text.Json.Utf8JsonWriter> class:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Utf8WriterToStream.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/Utf8WriterToStream.vb" id="Serialize":::

### Write with UTF-8 text

To achieve the best possible performance while using the `Utf8JsonWriter`, write JSON payloads already encoded as UTF-8 text rather than as UTF-16 strings. Use <xref:System.Text.Json.JsonEncodedText> to cache and pre-encode known string property names and values as statics, and pass those to the writer, rather than using UTF-16 string literals. This is faster than caching and using UTF-8 byte arrays.

This approach also works if you need to do custom escaping. `System.Text.Json` doesn't let you disable escaping while writing a string. However, you could pass in your own custom <xref:System.Text.Encodings.Web.JavaScriptEncoder> as an option to the writer, or create your own `JsonEncodedText` that uses your `JavascriptEncoder` to do the escaping, and then write the `JsonEncodedText` instead of the string. For more information, see [Customize character encoding](system-text-json-character-encoding.md).

:::zone pivot="dotnet-6-0"

### Write raw JSON

In some scenarios, you might want to write "raw" JSON to a JSON payload that you're creating with `Utf8JsonWriter`. You can use <xref:System.Text.Json.Utf8JsonWriter.WriteRawValue%2A?displayProperty=nameWithType> to do that. Here are typical scenarios:

* You have an existing JSON payload that you want to enclose in new JSON.
* You want to format values differently from the default `Utf8JsonWriter` formatting.

  For example, you might want to customize number formatting. By default, System.Text.Json omits the decimal point for whole numbers, writing `1` rather than `1.0`, for example. The rationale is that writing fewer bytes is good for performance. But suppose the consumer of your JSON treats numbers with decimals as doubles, and numbers without decimals as integers. You might want to ensure that the numbers in an array are all recognized as doubles, by writing a decimal point and zero for whole numbers. The following example shows how to do that:

  :::code language="csharp" source="snippets/system-text-json-use-dom-utf8jsonreader-utf8jsonwriter/csharp/WriteRawJson.cs":::

:::zone-end

### Customize character escaping

The [StringEscapeHandling](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_StringEscapeHandling.htm) setting of `JsonTextWriter` offers options to escape all non-ASCII characters **or** HTML characters. By default, `Utf8JsonWriter` escapes all non-ASCII **and** HTML characters. This escaping is done for defense-in-depth security reasons. To specify a different escaping policy, create a <xref:System.Text.Encodings.Web.JavaScriptEncoder> and set <xref:System.Text.Json.JsonWriterOptions.Encoder?displayProperty=nameWithType>. For more information, see [Customize character encoding](system-text-json-character-encoding.md).

### Write null values

To write null values by using `Utf8JsonWriter`, call:

* <xref:System.Text.Json.Utf8JsonWriter.WriteNull%2A> to write a key-value pair with null as the value.
* <xref:System.Text.Json.Utf8JsonWriter.WriteNullValue%2A> to write null as an element of a JSON array.

For a string property, if the string is null, <xref:System.Text.Json.Utf8JsonWriter.WriteString%2A> and <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A> are equivalent to `WriteNull` and `WriteNullValue`.

### Write Timespan, Uri, or char values

To write `Timespan`, `Uri`, or `char` values, format them as strings (by calling `ToString()`, for example) and call <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A>.

## Use `Utf8JsonReader`

<xref:System.Text.Json.Utf8JsonReader> is a high-performance, low allocation, forward-only reader for UTF-8 encoded JSON text, read from a `ReadOnlySpan<byte>` or `ReadOnlySequence<byte>`. The `Utf8JsonReader` is a low-level type that can be used to build custom parsers and deserializers. The <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> method uses `Utf8JsonReader` under the covers. The  `Utf8JsonReader` can't be used directly from Visual Basic code. For more information, see [Visual Basic support](system-text-json-how-to.md#visual-basic-support).

The following example shows how to use the <xref:System.Text.Json.Utf8JsonReader> class:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Utf8ReaderFromBytes.cs" id="Deserialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/Utf8ReaderFromBytes.vb" id="Deserialize":::

The preceding code assumes that the `jsonUtf8` variable is a byte array that contains valid JSON, encoded as UTF-8.

### Filter data using `Utf8JsonReader`

The following example shows how to synchronously read a file, and search for a value.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Utf8ReaderFromFile.cs":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/Utf8ReaderFromFile.vb":::

For an asynchronous version of this example, see [.NET samples JSON project](https://github.com/dotnet/samples/blob/18e31a5f1abd4f347bf96bfdc3e40e2cfb36e319/core/json/Program.cs).

The preceding code:

* Assumes the JSON contains an array of objects and each object may contain a "name" property of type string.
* Counts objects and "name" property values that end with "University".
* Assumes the file is encoded as UTF-16 and transcodes it into UTF-8. A file encoded as UTF-8 can be read directly into a `ReadOnlySpan<byte>`, by using the following code:

  ```csharp
  ReadOnlySpan<byte> jsonReadOnlySpan = File.ReadAllBytes(fileName);
  ```

  If the file contains a UTF-8 byte order mark (BOM), remove it before passing the bytes to the `Utf8JsonReader`, since the reader expects text. Otherwise, the BOM is considered invalid JSON, and the reader throws an exception.

Here's a JSON sample that the preceding code can read. The resulting summary message is "2 out of 4 have names that end with 'University'":

:::code language="json" source="snippets/system-text-json-how-to/csharp/Universities.json":::

### Read from a stream using `Utf8JsonReader`

When reading a large file (a gigabyte or more in size, for example), you might want to avoid having to load the entire file into memory at once. For this scenario, you can use a <xref:System.IO.FileStream>.

When using the `Utf8JsonReader` to read from a stream, the following rules apply:

* The buffer containing the partial JSON payload must be at least as large as the largest JSON token within it so that the reader can make forward progress.
* The buffer must be at least as large as the largest sequence of white space within the JSON.
* The reader doesn't keep track of the data it has read until it completely reads the next <xref:System.Text.Json.Utf8JsonReader.TokenType%2A> in the JSON payload. So when there are bytes left over in the buffer, you have to pass them to the reader again. You can use <xref:System.Text.Json.Utf8JsonReader.BytesConsumed%2A> to determine how many bytes are left over.

The following code illustrates how to read from a stream. The example shows a <xref:System.IO.MemoryStream>. Similar code will work with a <xref:System.IO.FileStream>, except when the `FileStream` contains a UTF-8 BOM at the start. In that case, you need to strip those three bytes from the buffer before passing the remaining bytes to the `Utf8JsonReader`. Otherwise the reader would throw an exception, since the BOM is not considered a valid part of the JSON.

The sample code starts with a 4KB buffer and doubles the buffer size each time it finds that the size is not large enough to fit a complete JSON token, which is required for the reader to make forward progress on the JSON payload. The JSON sample provided in the snippet triggers a buffer size increase only if you set a very small initial buffer size, for example, 10 bytes. If you set the initial buffer size to 10, the `Console.WriteLine` statements illustrate the cause and effect of buffer size increases. At the 4KB initial buffer size, the entire sample JSON is shown by each `Console.WriteLine`, and the buffer size never has to be increased.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Utf8ReaderPartialRead.cs":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/Utf8ReaderPartialRead.vb":::

The preceding example sets no limit to how large the buffer can grow. If the token size is too large, the code could fail with an <xref:System.OutOfMemoryException> exception. This can happen if the JSON contains a token that is around 1 GB or more in size, because doubling the 1 GB size results in a size that is too large to fit into an `int32` buffer.

### Utf8JsonReader is a ref struct

Because the `Utf8JsonReader` type is a *ref struct*, it has [certain limitations](../../csharp/language-reference/builtin-types/struct.md#ref-struct). For example, it can't be stored as a field on a class or struct other than a ref struct. To achieve high performance, this type must be a `ref struct` since it needs to cache the input [ReadOnlySpan\<byte>](xref:System.ReadOnlySpan%601), which itself is a ref struct. In addition, this type is mutable since it holds state. Therefore, **pass it by reference** rather than by value. Passing it by value would result in a struct copy and the state changes would not be visible to the caller. For more information about how to use ref structs, see [Write safe and efficient C# code](../../csharp/write-safe-efficient-code.md).

### Read UTF-8 text

To achieve the best possible performance while using the `Utf8JsonReader`, read JSON payloads already encoded as UTF-8 text rather than as UTF-16 strings. For a code example, see [Filter data using Utf8JsonReader](#filter-data-using-utf8jsonreader).

### Read with multi-segment ReadOnlySequence

If your JSON input is a [ReadOnlySpan\<byte>](xref:System.ReadOnlySpan%601), each JSON element can be accessed from the `ValueSpan` property on the reader as you go through the read loop. However, if your input is a [ReadOnlySequence\<byte>](xref:System.Buffers.ReadOnlySequence%601) (which is the result of reading from a <xref:System.IO.Pipelines.PipeReader>), some JSON elements might straddle multiple segments of the `ReadOnlySequence<byte>` object. These elements would not be accessible from <xref:System.Text.Json.Utf8JsonReader.ValueSpan%2A> in a contiguous memory block. Instead, whenever you have a multi-segment `ReadOnlySequence<byte>` as input, poll the <xref:System.Text.Json.Utf8JsonReader.HasValueSequence%2A> property on the reader to figure out how to access the current JSON element. Here's a recommended pattern:

```csharp
while (reader.Read())
{
    switch (reader.TokenType)
    {
        // ...
        ReadOnlySpan<byte> jsonElement = reader.HasValueSequence ?
            reader.ValueSequence.ToArray() :
            reader.ValueSpan;
        // ...
    }
}
```

### Use ValueTextEquals for property name lookups

Don't use <xref:System.Text.Json.Utf8JsonReader.ValueSpan%2A> to do byte-by-byte comparisons by calling <xref:System.MemoryExtensions.SequenceEqual%2A> for property name lookups. Call <xref:System.Text.Json.Utf8JsonReader.ValueTextEquals%2A> instead, because that method unescapes any characters that are escaped in the JSON. Here's an example that shows how to search for a property that is named "name":

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/ValueTextEqualsExample.cs" id="DefineUtf8Var":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/ValueTextEqualsExample.cs" id="UseUtf8Var" highlight="9":::

### Read null values into nullable value types

The built-in `System.Text.Json` APIs return only non-nullable value types. For example, <xref:System.Text.Json.Utf8JsonReader.GetBoolean%2A?displayProperty=nameWithType> returns a `bool`. It throws an exception if it finds `Null` in the JSON. The following examples show two ways to handle nulls, one by returning a nullable value type and one by returning the default value:

```csharp
public bool? ReadAsNullableBoolean()
{
    _reader.Read();
    if (_reader.TokenType == JsonTokenType.Null)
    {
        return null;
    }
    if (_reader.TokenType != JsonTokenType.True && _reader.TokenType != JsonTokenType.False)
    {
        throw new JsonException();
    }
    return _reader.GetBoolean();
}
```

```csharp
public bool ReadAsBoolean(bool defaultValue)
{
    _reader.Read();
    if (_reader.TokenType == JsonTokenType.Null)
    {
        return defaultValue;
    }
    if (_reader.TokenType != JsonTokenType.True && _reader.TokenType != JsonTokenType.False)
    {
        throw new JsonException();
    }
    return _reader.GetBoolean();
}
```

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](system-text-json-handle-overflow.md)
* [Preserve references and handle circular references](system-text-json-preserve-references.md)
* [Deserialize to immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [How to use source generation](system-text-json-source-generation.md)
* [Supported collection types](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
