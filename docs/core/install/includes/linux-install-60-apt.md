---
author: adegeo
ms.author: adegeo
ms.date: 10/26/2021
ms.topic: include
---

### Install the SDK

The .NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install the .NET SDK, run the following commands:

```bash
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-6.0
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-sdk-6.0**, see the [APT troubleshooting](#apt-troubleshooting) section.

### Install the runtime

The ASP.NET Core Runtime allows you to run apps that were made with .NET that didn't provide the runtime. The following commands install the ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following commands:

```bash
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-6.0
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package aspnetcore-runtime-6.0**, see the [APT troubleshooting](#apt-troubleshooting) section.

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime, which doesn't include ASP.NET Core support: replace `aspnetcore-runtime-6.0` in the previous command with `dotnet-runtime-6.0`:

```bash
sudo apt-get install -y dotnet-runtime-6.0
```
