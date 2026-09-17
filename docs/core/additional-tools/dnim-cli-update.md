---
title: dnim update command
description: The update command updates existing .NET installations.
author: joeloff
ms.date: 09/16/2026
ai-usage: ai-assisted
---

# dnim update

## Name

`dnim-win-[x86|x64|arm64] update` - Detects, classifies, removes and updates .NET installations on a device.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] update [-a|--accept-license]
    [-b|--include-bin-deployed-installs]
    [--csrp|--create-system-restore-point]
    [--epv|--except-product-version <PRODUCT_VERSION>]
    [--esp|--except-support-phase <active|eol|golive|maintenance|preview>]
    [--ignore-dependents]
    [--it|--install-type <msi|bundle|bin|hosting|runtime|aspnetruntime|desktopruntime|sdk|x86|x64|arm64>]
    [--klpv|--keep-latest-product-version <PRODUCT_VERSION>]
    [--klsp|--keep-latest-support-phase <active|eol|golive|maintenance|preview>]
    [-l|--log-file <LOG_FILE>]
    [--log-extra-debug-information, --lx]
    [--no-wua]
    [-o|--output-file <OUTPUT_FILE>]
    [--offline <LAYOUT_DIRECTORY>]
    [--offline-revocation-checks]
    [--output-format <text|csv|html|json>]
    [--pv|--product-version <PRODUCT_VERSION>]
    [--remove-EOL-versions-from-VS]
    [--remove-orphaned-installs]
    [--restore-point-suffix|--rps <SUFFIX>]
    [--ri|--report-issues]
    [--rv|--release-version <RELEASE_VERSION_RANGE>]
    [--sp|--support-phase <active|eol|golive|maintenance|preview>]
    [--update-discontinued-sdks]
    [--update-EOL-versions]
    [-v|--verbosity <quiet|normal|diagnostic>]
    [--verify-signatures <always|bypass|never>]
    [--what-if]

dnim-win-[x86|x64|arm64] update -?|-h|--help
```

## Description

The `update` command detects, classifies, removes and updates .NET installations on Windows. MSIs and bundles are detected by default. Bin deployed (xcopy/zip) installs under `Program Files` can be detected using the `--include-bin-deployed-installs` option.

The command can target specific products based on their product version, support phase, type and release version. Only standalone bundles can be updated. Installations of .NET that came from Visual Studio will require you to update Visual Studio. DNIM will not update Visual Studio.

The command will first remove any applicable installs before applying updates. This approach yields better results to meet compliance goals and reduce the need for secondary deployments to remove old copies of .NET.

## Options

- [!INCLUDE [accept-license](includes/dnim-cli-accept-license.md)]

- [!INCLUDE [bin-deployed-installs](includes/dnim-cli-include-bin-deployed-installs.md)]

- [!INCLUDE [create-system-restore-point](includes/dnim-cli-create-system-restore-point.md)]

- [!INCLUDE [except-product-version](includes/dnim-cli-except-product-version.md)]
  
- [!INCLUDE [except-support-phase](includes/dnim-cli-except-support-phase.md)]

- [!INCLUDE [ignore-dependents](includes/dnim-cli-ignore-dependents.md)]

- [!INCLUDE [install-type](includes/dnim-cli-install-type.md)]

- [!INCLUDE [keep-latest-product-version](includes/dnim-cli-keep-latest-product-version.md)]

- [!INCLUDE [keep-latest-support-phase](includes/dnim-cli-keep-latest-support-phase.md)]

- [!INCLUDE [log-file](includes/dnim-cli-log-file.md)]

- [!INCLUDE [log-extra-debug-information](includes/dnim-cli-log-extra-debug-information.md)]

- [!INCLUDE [no-wua](includes/dnim-cli-no-wua.md)]

- [!INCLUDE [output-file](includes/dnim-cli-output-file.md)]

- [!INCLUDE [offline](includes/dnim-cli-offline.md)]

- [!INCLUDE [offline-revocation-checks](includes/dnim-cli-offline-revocation-checks.md)]

- [!INCLUDE [output-format](includes/dnim-cli-output-format.md)]

- [!INCLUDE [product-version](includes/dnim-cli-product-version.md)]

- [!INCLUDE [remove-EOL-versions-from-VS](includes/dnim-cli-remove-eol-versions-from-vs.md)]

- [!INCLUDE [remove-orphaned-installs](includes/dnim-cli-remove-orphaned-installs.md)]

- [!INCLUDE [report-issues](includes/dnim-cli-report-issues.md)]

- [!INCLUDE [release-version](includes/dnim-cli-release-version.md)]

- [!INCLUDE [support-phase](includes/dnim-cli-support-phase.md)]

- [!INCLUDE [update-discontinued-sdks](includes/dnim-cli-update-discontinued-sdks.md)]

- [!INCLUDE [update-EOL-versions](includes/dnim-cli-update-eol-versions.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

- [!INCLUDE [verify-signatures](includes/dnim-cli-verify-signatures.md)]

- [!INCLUDE [what-if](includes/dnim-cli-what-if.md)]

## Results

The results are similar to that of the uninstall command, but additional columns showing the update action and target version are included.

| Display Name | Release | Type | Support | Uninstall Action | Update Action | Update Version |
| --- | --- | --- | --- | --- | --- | --- |
| Microsoft Windows Desktop Runtime 11.0.0 (x64) | 11.0.0-preview.7.26381.103 | Bundle | GoLive | Uninstall | Update | 11.0.0-rc.1.26425.128 |

## Examples

- Update .NET installs:

  ```console
  dnim-win-[x86|x64|arm64] update
  ```

- Updated all the .NET 8.0 installations, including discontinued SDKs.

  ```console
  dnim-win-[x86|x64|arm64] update --update-discontinued-sdk --pv 8.0
  ```

  Assume 8.0.31 is the latest .NET 8 release. It includes updates for both the 8.0.1xx and 8.0.4xx SDKs. The 8.0.2xx and 8.0.3xx SDKs are no longer produced and considered discontinued. If a device has the 8.0.202 SDK installed, DNIM can install the 8.0.425 SDK and remove the 8.0.202 SDK.

## See also

[.NET Installs](dnim-net-installs.md)
