### BinaryFormatter can fail to find type from LoadFrom context

#### Details

As of .NET Framework 4.5, a number of <xref:System.Xml.Serialization.XmlSerializer?displayProperty=fullName> changes may cause differences in deserialization when using <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=fullName> to deserialize types that had been loaded in the LoadFrom context. These changes are due to the new ways <xref:System.Xml.Serialization.XmlSerializer?displayProperty=fullName> now loads a type which causes different behavior when a <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=fullName> attempts to deserialize to that type later on. The default serialization binder does not automatically search the LoadFrom context, although it may have worked in some circumstances based on the old behavior of XmlSerializer. Due to the changes, when a type is being loaded from an assembly loaded in a different context, a <xref:System.IO.FileNotFoundException?displayProperty=fullName> may be thrown.

[!INCLUDE [binary-serialization-warning](../../../binary-serialization-warning.md)]

#### Suggestion

If this exception is seen, the `Binder` property of the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=fullName> can be set to a custom binder that will find the correct type.<pre><code class="lang-csharp">var formatter = new BinaryFormatter { Binder = new TypeFinderBinder() }&#13;&#10;</code></pre>And then the custom binder:

```csharp
public class TypeFinderBinder : SerializationBinder
{
private static readonly string s_assemblyName = Assembly.GetExecutingAssembly().FullName;

public override Type BindToType(string assemblyName, string typeName)
{
return Type.GetType(String.Format(CultureInfo.InvariantCulture, "{0}, {1}", typeName, s_assemblyName));
}
}

```

| Name    | Value   |
| :------ | :------ |
| Scope   | Edge    |
| Version | 4.5     |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream,System.Runtime.Remoting.Messaging.HeaderHandler)?displayProperty=nameWithType>

<!--

#### Affected APIs

- `T:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter`
- `M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)`
- `M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream,System.Runtime.Remoting.Messaging.HeaderHandler)`

-->