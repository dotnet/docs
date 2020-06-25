### Serialization of control characters with DataContractJsonSerializer is now compatible with ECMAScript V6 and V8

#### Details

In .NET Framework 4.6.2 and earlier versions, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer?displayProperty=fullName> did not serialize some special control characters, such as \b, \f, and \t, in a way that was compatible with the ECMAScript V6 and V8 standards. Starting with .NET Framework 4.7, serialization of these control characters is compatible with ECMAScript V6 and V8.

#### Suggestion

For apps that target the .NET Framework 4.7, this feature is enabled by default. If this behavior is not desirable, you can opt out of this feature by adding the following line to the `<runtime>` section of the app.config or web.config file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.Runtime.Serialization.DoNotUseECMAScriptV6EscapeControlCharacter=false" />
</runtime>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.7         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject(System.IO.Stream,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject(System.Xml.XmlDictionaryWriter,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject(System.Xml.XmlWriter,System.Object)?displayProperty=nameWithType>
