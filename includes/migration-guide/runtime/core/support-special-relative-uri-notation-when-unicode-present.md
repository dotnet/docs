### Support special relative URI notation when Unicode is present

#### Details

<xref:System.Uri> will no longer throw a <xref:System.NullReferenceException> when calling <xref:System.Uri.TryCreate%2A> on certain relative URIs containing Unicode. The simplest reproduction of the <xref:System.NullReferenceException> is below, with the two statements being equivalent:

```csharp
bool success = Uri.TryCreate("http:%C3%A8", UriKind.RelativeOrAbsolute, out Uri href);
bool success = Uri.TryCreate("http:è", UriKind.RelativeOrAbsolute, out Uri href);
```

To reproduce the <xref:System.NullReferenceException>, the following items must be true:

- The URI must be specified as relative by prepending it with 'http:' and not following it with '//'.
- The URI must contain percent-encoded Unicode or unreserved symbols.

#### Suggestion

Users depending on this behavior to disallow relative URIs should instead specify <xref:System.UriKind.Absolute?displayProperty=nameWithType> when creating a URI.

| Name    | Value   |
| :------ | :------ |
| Scope   | Edge    |
| Version | 4.7.2   |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Uri.TryCreate(System.Uri,System.Uri,System.Uri@)?displayProperty=nameWithType>
- <xref:System.Uri.TryCreate(System.String,System.UriKind,System.Uri@)?displayProperty=nameWithType>
- <xref:System.Uri.TryCreate(System.Uri,System.String,System.Uri@)?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:System.Uri.TryCreate(System.Uri,System.Uri,System.Uri@)`
- `M:System.Uri.TryCreate(System.String,System.UriKind,System.Uri@)`
- `M:System.Uri.TryCreate(System.Uri,System.String,System.Uri@)`

-->
