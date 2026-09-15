---
title: dnim query products command
description: The query releases command provides information about specific .NET products.
author: joeloff
ms.date: 08/11/2026
ai-usage: ai-assisted
---

# dnim query

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

- Display release information for all products:

  ```console
  dnim-win-[x86|x64|arm64] query products
  ```

- Display release information for all products that are not end-of-life:

  ```console
  dnim-win-[x86|x64|arm64] query products --esp eol
  ```

- Display release information for .NET 7.0 and 9.0

  ```console
  dnim-win-[x86|x64|arm64] query products --pv 7.0 --pv 9.0
  ```

## See also
