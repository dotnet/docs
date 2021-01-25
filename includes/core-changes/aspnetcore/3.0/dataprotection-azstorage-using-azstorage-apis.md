### Data Protection: DataProtection.Blobs uses new Azure Storage APIs

`Azure.Extensions.AspNetCore.DataProtection.Blobs` depends on the [Azure Storage libraries](https://github.com/Azure/azure-storage-net). These libraries renamed their assemblies, packages, and namespaces. Starting in ASP.NET Core 3.0, `Azure.Extensions.AspNetCore.DataProtection.Blobs` uses the new `Azure.Storage.`-prefixed APIs and packages.

For questions about the Azure Storage APIs, use <https://github.com/Azure/azure-storage-net>. For discussion on this issue, see [dotnet/aspnetcore#19570](https://github.com/dotnet/aspnetcore/issues/19570).

#### Version introduced

3.0

#### Old behavior

The package referenced the `WindowsAzure.Storage` NuGet package.
The package references the `Microsoft.Azure.Storage.Blob` NuGet package.

#### New behavior

The package references the `Azure.Storage.Blob` NuGet package.

#### Reason for change

This change allows `Azure.Extensions.AspNetCore.DataProtection.Blobs` to migrate to the recommended Azure Storage packages.

#### Recommended action

If you still need to use the older Azure Storage APIs with ASP.NET Core 3.0, add a direct dependency to the package [WindowsAzure.Storage](https://www.nuget.org/packages/WindowsAzure.Storage/) or [Microsoft.Azure.Storage](https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/). This package can be installed alongside the new `Azure.Storage` APIs.

In many cases, the upgrade only involves changing the `using` statements to use the new namespaces:

```diff
- using Microsoft.WindowsAzure.Storage;
- using Microsoft.WindowsAzure.Storage.Blob;
- using Microsoft.Azure.Storage;
- using Microsoft.Azure.Storage.Blob;
+ using Azure.Storage;
+ using Azure.Storage.Blobs;
```

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

#### Affected APIs

Not detectable via API analysis

-->
