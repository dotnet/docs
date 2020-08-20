### Uri recognition of UNC paths on Unix

The <xref:System.Uri> class now recognizes strings that start with two forward slashes (`//`) as universal naming convention (UNC) paths on Unix operating systems. This change makes the behavior for such strings consistent across all platforms.

#### Change description

In previous versions of .NET, the <xref:System.Uri> class recognizes strings that start with with two forward slashes, for example, `//contoso`, as absolute file paths on Unix operating systems. However, on Windows, such strings are recognized as UNC paths.

Starting in .NET 5.0,  the <xref:System.Uri> class recognizes strings that start with with two forward slashes as UNC paths on all platforms, including Unix. In addition, properties behave according to UNC semantics:

- <xref:System.Uri.IsUnc?displayProperty=nameWithType> returns `true`.
- Backslashes in the path are replaced with forward slashes. For example, `//first\second` becomes `//first/second`.
- <xref:System.Uri.LocalPath?displayProperty=nameWithType> doesn't percent-encode characters. For example, `//first/\uFFF0` is *not* converted to `//first/%EF%BF%B0`.

#### Version introduced

5.0

#### Recommended action

No action is required on the part of the developer.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Uri?displayProperty=fullName>

<!--

#### Affected APIs

- `T:System.Uri`

-->
