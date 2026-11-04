---
title: dnim scan command
description: The scan command identifies .NET installations.
author: joeloff
ms.date: 08/11/2026
ai-usage: ai-assisted
---

# dnim scan

## Name

`dnim-win-[x86|x64|arm64] scan` - Detects, classifies, and reports .NET installations on a device.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] scan [-a|--accept-license] [-b|--include-bin-deployed-installs]
    [--epv|--except-product-version <PRODUCT_VERSION>] 
    [--esp|--except-support-phase <active|eol|golive|maintenance|preview>]
    [-l|--log-file <LOG_FILE>] [-o|--output-file <OUTPUT_FILE>] [--offline <LAYOUT_DIRECTORY>]
    [--output-format <text|csv|html|json>] [--pv|--product-version <PRODUCT_VERSION>]
    [--sp|--support-phase <active|eol|golive|maintenance|preview>]
    [-v|--verbosity <quiet|normal|diagnostic>]

dnim-win-[x86|x64|arm64] scan -?|-h|--help
```

## Description

The `scan` command detects, classifies and reports .NET installations on Windows. MSIs and bundles are detected by default. Bin deployed (xcopy/zip) installs under `Program Files` can be detected using the `--include-bin-deployed-installs` option.

Results can be filtered using the product version and support phase options to only include installations matching the specified criteria. Results are written to both the console and diagnostic log. Additional output formats are available and include JSON, HTML and CSV.

## Options

- [!INCLUDE [accept-license](includes/dnim-cli-accept-license.md)]

- [!INCLUDE [bin-deployed-installs](includes/dnim-cli-include-bin-deployed-installs.md)]

- [!INCLUDE [except-product-version](includes/dnim-cli-except-product-version.md)]
  
- [!INCLUDE [except-support-phase](includes/dnim-cli-except-support-phase.md)]

- [!INCLUDE [log-file](includes/dnim-cli-log-file.md)]

- [!INCLUDE [output-file](includes/dnim-cli-output-file.md)]

- [!INCLUDE [offline](includes/dnim-cli-offline.md)]

- [!INCLUDE [output-format](includes/dnim-cli-output-format.md)]

- [!INCLUDE [product-version](includes/dnim-cli-product-version.md)]

- [!INCLUDE [support-phase](includes/dnim-cli-support-phase.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

## Results

The results presents a summary of each installation, including its type (MSI, bundle, etc.), the .NET product to which it belongs and its current support phase. It may also include information about its origin. In the example below there are three installations: two bundles and one MSI. The targeting pack MSI is shared between both SDK installs and two instances of Visual Studio: 17.14.37502 and 17.14.37110.

| Display Name | Product | Release | Type | Support | Installed By |
| --- | --- | --- | --- | --- | --- |
| Microsoft .NET SDK 6.0.136 (x64) | 6.0 | 6.0.136 | Bundle | EOL | |
| Microsoft .NET SDK 6.0.428 (x64) | 6.0 | 6.0.428 | Bundle | EOL | |
| Microsoft Windows Desktop Targeting Pack - 6.0.36 (x64) | 6.0 | 6.0.36 | Msi | EOL | VS 17.14.37502, VS 17.14.37110, Microsoft .NET SDK 6.0.428 (x64), Microsoft .NET SDK 6.0.136 (x64) |

## Examples

- Scan and report all .NET installations:

  ```console
  dnim-win-[x86|x64|arm64] scan
  ```

- Scan and report .NET installations that are in active support:

  ```console
  dnim-win-[x86|x64|arm64] scan --sp active
  ```

- Scan for end-of-life (EOL) installations of .NET and write the results to an HTML file:

  ```console
  dnim-win-[x86|x64|arm64] scan --sp eol -o report.html --output-format html
  ```

## See also

[.NET Installs](dnim-net-installs.md)
