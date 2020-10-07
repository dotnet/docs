### JsonSerializer.Deserialize throws JsonException for null or empty strings

When the type parameter is <xref:System.Char>, <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> now throws a <xref:System.Text.Json.JsonException> instead of a <xref:System.NullReferenceException> or <xref:System.IndexOutOfRangeException>.

#### Change description

In previous .NET versions, when the type parameter is <xref:System.Char>, passing a null reference for the <xref:System.String> parameter of <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> causes a <xref:System.NullReferenceException> to be thrown. Passing an empty string causes an <xref:System.IndexOutOfRangeException> to be thrown.

In .NET Core 3.1 and later, when the type parameter is <xref:System.Char>, passing a null reference or an empty string causes a <xref:System.Text.Json.JsonException> to be thrown.

```csharp
// .NET Core 3.0: Throws NullReferenceException.
// .NET Core 3.1 and later: Throws JsonException.
JsonSerializer.Deserialize<char>(null);

// .NET Core 3.0: Throws IndexOutOfRangeException
// .NET Core 3.1 and later: Throws JsonException.
JsonSerializer.Deserialize<char>("");
```

#### Version introduced

.NET Core 3.1

#### Recommended action

When parsing a string into a <xref:System.Char> type using <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType>, make sure the string is non-null and non-empty.

If you specifically catch <xref:System.NullReferenceException> or <xref:System.IndexOutOfRangeException> exceptions when calling this method, change your code to catch a <xref:System.Text.Json.JsonException> instead.

#### Category

Serialization

#### Affected APIs

- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>

<!--

#### Affected APIs

- `M:System.Text.Json.JsonSerializer.Deserialize``1(System.String,System.Text.Json.JsonSerializerOptions)`

-->
