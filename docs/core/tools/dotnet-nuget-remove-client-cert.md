---
title: dotnet nuget remove client-cert command
description: The dotnet nuget remove client-cert command removes the client certificate configuration for a NuGet package source.
ms.date: 10/23/2026
ai-usage: ai-generated
---
# dotnet nuget remove client-cert

**This article applies to:** ✔️ .NET Core 3.1.400 SDK and later versions

## Name

`dotnet nuget remove client-cert` - Remove a client certificate configuration for a NuGet package source.

## Synopsis

```dotnetcli
dotnet nuget remove client-cert --package-source <SOURCE_NAME>
    [--configfile <FILE>]

dotnet nuget remove client-cert -h|--help
```

## Description

The `dotnet nuget remove client-cert` command removes the client certificate configuration that matches the given package source name.

The command doesn't delete the certificate file, remove certificates from a certificate store, or remove the package source itself. If no client certificate configuration matches the name, NuGet reports that no matching configuration exists.

## Options

- [!INCLUDE [configfile](includes/cli-configfile.md)]

- [!INCLUDE [help](includes/cli-help.md)]

- **`-s|--package-source <SOURCE_NAME>`**

  The package source name associated with the client certificate configuration to remove. Required. Specify the source name, not its URL.

## Examples

Remove the client certificate configuration for the package source named `Contoso` from a specific configuration file:

```dotnetcli
dotnet nuget remove client-cert --package-source Contoso --configfile .\nuget.config
```

## See also

- [dotnet nuget add client-cert](dotnet-nuget-add-client-cert.md)
- [dotnet nuget list client-cert](dotnet-nuget-list-client-cert.md)
- [dotnet nuget update client-cert](dotnet-nuget-update-client-cert.md)
- [dotnet nuget remove source](dotnet-nuget-remove-source.md)
