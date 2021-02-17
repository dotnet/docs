---
title: How to write custom serializers and deserializers with System.Text.Json
description: "Learn how to write custom serializers and deserializers for JSON, using the System.Text.Json namespace."
ms.date: 01/19/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# How to write custom serializers and deserializers with System.Text.Json

<xref:System.Text.Json.Utf8JsonReader?displayProperty=fullName> is a high-performance, low allocation, forward-only reader for UTF-8 encoded JSON text, read from a `ReadOnlySpan<byte>` or `ReadOnlySequence<byte>`. The `Utf8JsonReader` is a low-level type that can be used to build custom parsers and deserializers. The <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> method uses `Utf8JsonReader` under the covers. The  `Utf8JsonReader` can't be used directly from Visual Basic code. For more information, see [Visual Basic support](system-text-json-how-to.md#visual-basic-support).

<xref:System.Text.Json.Utf8JsonWriter?displayProperty=fullName> is a high-performance way to write UTF-8 encoded JSON text from common .NET types like `String`, `Int32`, and `DateTime`. The writer is a low-level type that can be used to build custom serializers. The <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType> method uses `Utf8JsonWriter` under the covers.

<xref:System.Text.Json.JsonDocument?displayProperty=fullName> provides the ability to build a read-only Document Object Model (DOM) by using `Utf8JsonReader`. The DOM provides random access to data in a JSON payload. The JSON elements that compose the payload can be accessed via the <xref:System.Text.Json.JsonElement> type. The `JsonElement` type provides array and object enumerators along with APIs to convert JSON text to common .NET types. `JsonDocument` exposes a <xref:System.Text.Json.JsonDocument.RootElement> property.

The following sections show how to use these tools for reading and writing JSON.

## Use JsonDocument for access to data

The following example shows how to use the <xref:System.Text.Json.JsonDocument> class for random access to data in a JSON string:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/JsonDocumentDataAccess.cs" id="AverageGrades1":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/JsonDocumentDataAccess.vb" id="AverageGrades1":::

The preceding code:

* Assumes the JSON to analyze is in a string named `jsonString`.
* Calculates an average grade for objects in a `Students` array that have a `Grade` property.
* Assigns a default grade of 70 for students who don't have a grade.
* Counts students by incrementing a `count` variable with each iteration. An alternative is to call <xref:System.Text.Json.JsonElement.GetArrayLength%2A>, as shown in the following example:

  :::code language="csharp" source="snippets/system-text-json-how-to/csharp/JsonDocumentDataAccess.cs" id="AverageGrades2":::
  :::code language="vb" source="snippets/system-text-json-how-to/vb/JsonDocumentDataAccess.vb" id="AverageGrades2":::

Here's an example of the JSON that this code processes:

:::code language="json" source="snippets/system-text-json-how-to/csharp/GradesPrettyPrint.json":::

## Use JsonDocument to write JSON

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

## Use Utf8JsonWriter

The following example shows how to use the <xref:System.Text.Json.Utf8JsonWriter> class:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Utf8WriterToStream.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/Utf8WriterToStream.vb" id="Serialize":::

## Use Utf8JsonReader

The following example shows how to use the <xref:System.Text.Json.Utf8JsonReader> class:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/Utf8ReaderFromBytes.cs" id="Deserialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/Utf8ReaderFromBytes.vb" id="Deserialize":::

The preceding code assumes that the `jsonUtf8` variable is a byte array that contains valid JSON, encoded as UTF-8.

### Filter data using Utf8JsonReader

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

### Read from a stream using Utf8JsonReader

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

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to customize character encoding](system-text-json-character-encoding.md)
* [How to write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [System.Text.Json API reference](xref:System.Text.Json)
