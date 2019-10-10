### DataProtection.AzureStorage uses new Azure Storage APIs

<xref:Microsoft.AspNetCore.DataProtection.AzureStorage?displayProperty=fullName> depends on the [Azure Storage libraries](https://github.com/Azure/azure-storage-net). These libraries renamed their assemblies, packages, and namespaces. Starting in ASP.NET Core 3.0, `Microsoft.AspNetCore.DataProtection.AzureStorage` uses the new `Microsoft.Azure.Storage.`-prefixed APIs and packages.

For questions about the Azure Storage APIs, use https://github.com/Azure/azure-storage-net. For discussion on this issue, see [aspnet/AspNetCore#8472](https://github.com/aspnet/AspNetCore/issues/8472).

#### Version introduced

3.0

#### Old behavior

The package referenced the `WindowsAzure.Storage` NuGet package.

#### New behavior

The package references the `Microsoft.Azure.Storage.Blob` NuGet package.

#### Reason for change

This change allows `Microsoft.AspNetCore.DataProtection.AzureStorage` to migrate to the recommended Azure Storage packages.

#### Recommended action

If you still need to use the older Azure Storage APIs with ASP.NET Core 3.0, add a direct dependency to the [WindowsAzure.Storage](https://www.nuget.org/packages/WindowsAzure.Storage/) package. This package can be installed alongside the new `Microsoft.Azure.Storage` APIs.

In many cases, the upgrade only involves changing the `using` statements to use the new namespaces:

```diff
- using Microsoft.WindowsAzure.Storage;
- using Microsoft.WindowsAzure.Storage.Blob;
+ using Microsoft.Azure.Storage;
+ using Microsoft.Azure.Storage.Blob;
```

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

#### Affected APIs

Not detectable via API analysis

-->
