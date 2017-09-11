### Serialization of control characters with DataContractJsonSerializer is now compatible with ECMAScript V6 and V8

|   |   |
|---|---|
|Details|In the .NET framework 4.6.2 and earlier versions, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer?displayProperty=name> did not serialize some special control characters, such as \b, \f, and \t, in a way that was compatible with the ECMAScript V6 and V8 standards. Starting with the .NET Framework 4.7, serialization of these control characters is compatible with ECMAScript V6 and V8.|
|Suggestion|For apps that target the .NET Framework 4.7, this feature is enabled by default. If this behavior is not desirable, you can opt out of this feature by adding the following line to the <code>&lt;runtime&gt;</code> section of the app.config or web.config file:<pre><code>&lt;runtime&gt;<br />&lt;AppContextSwitchOverrides value=&quot;Switch.System.Runtime.Serialization.DoNotUseECMAScriptV6EscapeControlCharacter=false&quot; /&gt;<br />&lt;/runtime&gt;</code></pre>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject(System.IO.Stream%2CSystem.Object)?displayProperty=fullName></li><li><xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject(System.Xml.XmlDictionaryWriter%2CSystem.Object)?displayProperty=fullName></li><li><xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject(System.Xml.XmlWriter%2CSystem.Object)?displayProperty=fullName></li></ul>|

