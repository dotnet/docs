### ProviderAliasAttribute moved to another assembly

The <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute> class has been moved.

#### Change description

In .NET versions before .NET 10, the <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute> class is found in the *Microsoft.Extensions.Logging* assembly.

Starting with .NET 10, it is found in the *Microsoft.Extensions.Logging.Abstractions* assembly. To maintain compatibility, the type is type-forwarded from *Microsoft.Extensions.Logging*, allowing existing code to continue working without modification in most scenarios.

#### Version introduced

.NET 10 Preview 4

#### Recommended action

This change should not be breaking in most common scenarios due to the type forwarding. The only potential breaking case occurs when a project references an older version of *Microsoft.Extensions.Logging* alongside the .NET 10 version of *Microsoft.Extensions.Logging.Abstractions*. In that situation, a compilation error may occur due to `ProviderAliasAttribute` being defined in both assemblies.

If you encounter this issue, upgrade to the .NET 10 version of *Microsoft.Extensions.Logging* to resolve the problem.

#### Category

Extensions

#### Affected APIs

<xref:Microsoft.Extensions.Logging.ProviderAliasAttribute>

<!--

#### Affected APIs

- `T:Microsoft.Extensions.Logging.ProviderAliasAttribute`

-->