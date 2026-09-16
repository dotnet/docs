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

The command can be used to obtain a summary of available .NET products.



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



## Examples

- Display all releases include a specific CVE:

  ```console
  dnim-win-[x86|x64|arm64] query releases --cve CVE-2026-71328
  ```

- Display the latest releases that are not end-of-life

  ```console
  dnim-win-[x86|x64|arm64] query products --esp eol --latest
  ```

## See also
