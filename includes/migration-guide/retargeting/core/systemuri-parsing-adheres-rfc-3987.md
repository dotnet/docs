### System.Uri parsing adheres to RFC 3987

#### Details

URI parsing has changed in several ways in .NET Framework 4.5. Note, however, that these changes only affect code targeting .NET Framework 4.5. If a binary targets .NET Framework 4.0, the old behavior will be observed. Changes to URI parsing in .NET Framework 4.5 include:

- URI parsing will perform normalization and character checking according to the latest IRI rules in RFC 3987.
- Unicode normalization form C will only be performed on the host portion of the URI.
- Invalid mailto: URIs will now cause an exception.
- Trailing dots at the end of a path segment are now preserved.
- `file://` URIs do not escape the `?` character.
- Unicode control characters `U+0080` through `U+009F` are not supported.
- Comma characters `,` or `%2c` are not automatically unescaped.

#### Suggestion

If the old .NET Framework 4.0 URI parsing semantics are necessary (they often aren't), they can be used by targeting .NET Framework 4.0. This can be accomplished by using a <xref:System.Runtime.Versioning.TargetFrameworkAttribute?displayProperty=fullName> on the assembly, or through Visual Studio's project system UI in the 'project properties' page.

| Name    | Value       |
|:--------|:------------|
| Scope   | Major       |
| Version | 4.5         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Uri.%23ctor(System.String)>
- <xref:System.Uri.%23ctor(System.String,System.Boolean)>
- <xref:System.Uri.%23ctor(System.String,System.UriKind)>
- <xref:System.Uri.%23ctor(System.Uri,System.String)>
- <xref:System.Uri.TryCreate(System.String,System.UriKind,System.Uri@)?displayProperty=nameWithType>
- <xref:System.Uri.TryCreate(System.Uri,System.String,System.Uri@)?displayProperty=nameWithType>
- <xref:System.Uri.TryCreate(System.Uri,System.Uri,System.Uri@)?displayProperty=nameWithType>
