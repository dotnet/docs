### Allow Unicode in URIs that resemble UNC shares

#### Details

In <xref:System.Uri?displayProperty=fullName>, constructing a file URI containing both a UNC share name and Unicode characters will no longer result in a URI with invalid internal state. The behavior will change only when all of the following are true:

- The URI has the scheme `file:` and is followed by four or more slashes.
- The host name begins with an underscore or other non-reserved symbol.
- The URI contains Unicode characters.

#### Suggestion

Applications working with URIs consistently containing Unicode could have conceivably used this behavior to disallow references to UNC shares. Those applications should use <xref:System.Uri.IsUnc> instead.

| Name    | Value   |
| :------ | :------ |
| Scope   | Edge    |
| Version | 4.7.2   |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Uri?displayProperty=nameWithType>

<!--

#### Affected APIs

- `T:System.Uri`

-->
