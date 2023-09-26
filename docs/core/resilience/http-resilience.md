---
title: Resilient patterns for HTTP
description: 
author: IEvangelist
ms.author: dapine
ms.date: 09/26/2023
---

If you're app is using the [IHttpClientFactory](../extensions/httpclient-factory.md), you should install the [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) NuGet package—as this package is specifically designed to provide resiliency mechanisms for the <xref:System.Net.Http.HttpClient>.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Http.Resilience --version 8.0.0-rc.1.23421.29
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Http.Resilience"
    Version="8.0.0-rc.1.23421.29" />
```

---