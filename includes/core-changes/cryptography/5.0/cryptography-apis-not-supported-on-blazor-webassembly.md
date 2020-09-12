### System.Security.Cryptography APIs not supported on Blazor WebAssembly

<xref:System.Security.Cryptography> APIs throw a <xref:System.PlatformNotSupportedException> for projects that use the `Microsoft.NET.Sdk.BlazorWebAssembly` SDK.

#### Change description

In previous .NET versions, you can use the <xref:System.Security.Cryptography> APIs in the Blazor WebAssembly configuration. In .NET 5.0 and later versions, these APIs throw a <xref:System.PlatformNotSupportedException> when invoked from Blazor WebAssembly projects.

#### Reason for change

Microsoft is unable to ship OpenSSL as a dependency in the Blazor WebAssembly configuration. We attempted to work around this by trying to integrate with the browser's `SubtleCrypto` API. Unfortunately, it required significant API changes that made it too hard to integrate.

#### Version introduced

5.0 RC1

#### Recommended action

There are no good workarounds to suggest at this time.

#### Category

- ASP.NET Core
- Cryptography

#### Affected APIs

- <xref:System.Security.Cryptography?displayProperty=fullName>

<!--

#### Affected APIs

- `T:System.Security.Cryptography`

-->
