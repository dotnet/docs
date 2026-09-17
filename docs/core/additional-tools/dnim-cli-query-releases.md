---
title: dnim query prreleases command
description: The query releases command provides information about specific .NET releases.
author: joeloff
ms.date: 08/11/2026
ai-usage: ai-assisted
---

# dnim query releases

## Name

`dnim-win-[x86|x64|arm64] query releases` - Queries release information about specific .NET products.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] query releases [-a|--accept-license] 
    [--epv|--except-product-version <PRODUCT_VERSION>] 
    [--esp|--except-support-phase <active|eol|golive|maintenance|preview>]
    [-o|--output-file <OUTPUT_FILE>] [--offline <LAYOUT_DIRECTORY>]
    [--output-format <text|csv|html|json>] [--pv|--product-version <PRODUCT_VERSION>]
    [--sp|--support-phase <active|eol|golive|maintenance|preview>]
    [-v|--verbosity <quiet|normal|diagnostic>]

dnim-win-[x86|x64|arm64] query releases -?|-h|--help
```

## Description

The command can be used to obtain information for specific .NET releases.

> [!IMPORTANT]
> The information provided by this command depends on the published releases JSON data.

## Options

- [!INCLUDE [accept-license](includes/dnim-cli-accept-license.md)]

- [!INCLUDE [except-product-version](includes/dnim-cli-except-product-version.md)]
  
- [!INCLUDE [except-support-phase](includes/dnim-cli-except-support-phase.md)]

- [!INCLUDE [output-file](includes/dnim-cli-output-file.md)]

- [!INCLUDE [offline](includes/dnim-cli-offline.md)]

- [!INCLUDE [output-format](includes/dnim-cli-output-format.md)]

- [!INCLUDE [product-version](includes/dnim-cli-product-version.md)]

- [!INCLUDE [support-phase](includes/dnim-cli-support-phase.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

## Results

The example below shows the latest release information for .NET Core 3.1.

```console
Version: 3.1.32
Release date: 12/13/2022
Release notes: https://github.com/dotnet/core/blob/main/release-notes/3.1/3.1.32/3.1.32.md
Security: True
CVEs:
  CVE-2022-41089, https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2022-41089
SDK 3.1.426
  ASP.NET Core Runtime 3.1.32
  .NET Core Runtime 3.1.32
  Desktop Runtime 3.1.32
```

## Examples

- Display all releases that addressed a specific CVE:

  ```console
  dnim-win-[x86|x64|arm64] query releases --cve CVE-2026-71328
  ```

- Display the latest releases available for all products that are not end-of-life.

  ```console
  dnim-win-[x86|x64|arm64] query release --esp eol --latest
  ```

## See also

The [`query products`](dnim-cli-query-products.md) command.
