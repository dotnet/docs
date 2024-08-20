---
author: adegeo
ms.author: adegeo
ms.date: 11/15/2022
ms.topic: include
ms.custom: linux-related-content
---

### Install the SDK

The .NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install the .NET SDK, run the following command:

```bash
sudo zypper install dotnet-sdk-7.0
```

To learn how to use the .NET CLI, see [.NET CLI overview](../../tools/index.md).

### Install the runtime

The ASP.NET Core Runtime allows you to run apps that were made with .NET that didn't provide the runtime. The following command installs the ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following command:

```bash
sudo zypper install aspnetcore-runtime-7.0
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime, which doesn't include ASP.NET Core support: replace `aspnetcore-runtime-7.0` in the previous command with `dotnet-runtime-7.0`:

```bash
sudo zypper install dotnet-runtime-7.0
```

To learn how to use the .NET CLI, see [.NET CLI overview](../../tools/index.md).
