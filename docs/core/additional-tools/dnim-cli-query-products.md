---
title: dnim query products command
description: The query releases command provides information about specific .NET products.
author: joeloff
ms.date: 08/11/2026
ai-usage: ai-assisted
---

# dnim query products

## Name

`dnim-win-[x86|x64|arm64] query products` - Queries release information about specific .NET products.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] query products [-a|--accept-license] 
    [--epv|--except-product-version <PRODUCT_VERSION>] 
    [--esp|--except-support-phase <active|eol|golive|maintenance|preview>]
    [-o|--output-file <OUTPUT_FILE>] [--offline <LAYOUT_DIRECTORY>]
    [--output-format <text|csv|html|json>] [--pv|--product-version <PRODUCT_VERSION>]
    [--sp|--support-phase <active|eol|golive|maintenance|preview>]
    [-v|--verbosity <quiet|normal|diagnostic>]

dnim-win-[x86|x64|arm64] query products -?|-h|--help
```

## Description

The command provides a summary of .NET products, including the latest versions, support phase and expected end-of-life date.

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

The example below lists all products whose support phase is not `eol`. The security update column indicates whether the latest release addressed security vulnerabilities. The [`query releases`](dnim-cli-query-releases.md) command can be used to obtain a list of vulnerabilities addressed by the latest release.

| Version | Support | Release type | Latest release | Latest release date | Latest SDK | Latest runtime | End of support | Security update |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 11.0 | GoLive | STS | 11.0.0-rc.1 | 9/8/2026 | 11.0.100-rc.1.26425.128 | 11.0.0-rc.1.26425.128 | n/a | True |
| 10.0 | Active | LTS | 10.0.12 | 9/8/2026 | 10.0.401 | 10.0.12 | 11/14/2028 | True |
| 9.0 | Maintenance | STS | 9.0.20 | 9/8/2026 | 9.0.318 | 9.0.20 | 11/10/2026 | True |
| 8.0 | Maintenance | LTS | 8.0.31 | 9/8/2026 | 8.0.425 | 8.0.31 | 11/10/2026 | True |

## Examples

- Display information for all .NET products.

  ```console
  dnim-win-[x86|x64|arm64] query products
  ```

- Display information for all products that are not end-of-life:

  ```console
  dnim-win-[x86|x64|arm64] query products --esp eol
  ```

- Only display information for the .NET 7.0 and 9.0 products.

  ```console
  dnim-win-[x86|x64|arm64] query products --pv 7.0 --pv 9.0
  ```

## See also

The [`query-releases`](dnim-cli-query-releases.md) command.
