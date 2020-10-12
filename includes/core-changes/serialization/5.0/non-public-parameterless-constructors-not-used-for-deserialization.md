### Non-public, parameterless constructors not used for deserialization

For consistency across all supported target framework monikers (TFMs), non-public, parameterless constructors are no longer used for deserialization with <xref:System.Text.Json.JsonSerializer>, by default.

#### Change description

On .NET Core 3.0 and 3.1, internal and private constructors can be used for deserialization. On .NET Standard 2.0 and 2.1, internal and private constructors are not allowed, and a <xref:System.MissingMethodException> is thrown if no public, parameterless constructor is defined.

Starting in .NET 5.0, non-public constructors, including parameterless constructors, are ignored by the serializer by default. The serializer uses one of the following constructors for deserialization:

- Public constructor annotated with <xref:System.Text.Json.Serialization.JsonConstructorAttribute>.
- Public parameterless constructor.
- Public parameterized constructor (if it's the only public constructor present).

If none of these constructors are available, a <xref:System.NotSupportedException> is thrown if you attempt to deserialize the type.

#### Version introduced

5.0

#### Reason for change

- To enforce consistent behavior between all target framework monikers (TFMs) that <xref:System.Text.Json?displayProperty=fullName> builds for (.NET Core 3.0 and later versions, and .NET Standard 2.0 and 2.1)
- Because <xref:System.Text.Json.JsonSerializer> shouldn't call the non-public surface area of a type, whether that's a constructor, a property, or a field.

#### Recommended action

- If you own the type and it's feasible, make the parameterless constructor public.
- Otherwise, implement a `JsonConverter<T>` for the type and control the deserialization behavior.

#### Category

Serialization

#### Affected APIs

- <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A?displayProperty=fullName>

<!--

#### Affected APIs

- `Overload:System.Text.Json.JsonSerializer.Deserialize`
- `Overload:System.Text.Json.JsonSerializer.DeserializeAsync`

-->
