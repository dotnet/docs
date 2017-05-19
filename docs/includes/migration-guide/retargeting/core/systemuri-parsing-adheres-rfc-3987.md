### System.Uri parsing adheres to RFC 3987

|   |   |
|---|---|
|Details|URI parsing has changed in several ways in .NET 4.5. Note, however, that these changes only affect code targeting .NET 4.5. If a binary targets .NET 4.0, the old behavior will be observed. Changes to URI parsing in .NET 4.5 include:<ul><li>URI parsing will perform normalization and character checking according to the latest IRI rules in RFC 3987.</li><li>Unicode normalization form C will only be performed on the host portion of the URI.</li><li>Invalid mailto: URIs will now cause an exception.</li><li>Trailing dots at the end of a path segment are now preserved.</li><li><code>file://</code> URIs do not escape the <code>?</code> character.</li><li>Unicode control characters <code>U+0080</code> through <code>U+009F</code> are not supported.</li><li>Comma characters <code>,</code> or <code>%2c</code> are not automatically unescaped.</li></ul>|
|Suggestion|If the old .NET 4.0 URI parsing semantics are necessary (they often aren&#39;t), they can be used by targeting .NET 4.0. This can be accomplished by using a <xref:System.Runtime.Versioning.TargetFrameworkAttribute?displayProperty=name> on the assembly, or through Visual Studio&#39;s project system UI in the &#39;project properties&#39; page.|
|Scope|Major|
|Version|4.5|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Uri.%23ctor(System.String)?displayProperty=fullName></li><li><xref:System.Uri.%23ctor(System.String%2CSystem.Boolean)?displayProperty=fullName></li><li><xref:System.Uri.%23ctor(System.String%2CSystem.UriKind)?displayProperty=fullName></li><li><xref:System.Uri.%23ctor(System.Uri%2CSystem.String)?displayProperty=fullName></li><li><xref:System.Uri.TryCreate(System.String%2CSystem.UriKind%2CSystem.Uri%40)?displayProperty=fullName></li><li><xref:System.Uri.TryCreate(System.Uri%2CSystem.String%2CSystem.Uri%40)?displayProperty=fullName></li><li><xref:System.Uri.TryCreate(System.Uri%2CSystem.Uri%2CSystem.Uri%40)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0006D</li><li>CD0006C</li><li>CD0006F</li><li>CD0006E</li><li>CD0006A</li><li>CD0006G</li><li>CD0006B</li></ul>|

