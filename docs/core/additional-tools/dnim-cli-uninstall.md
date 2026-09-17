---
title: dnim uninstall command
description: The uninstall command removes .NET installations.
author: joeloff
ms.date: 08/11/2026
ai-usage: ai-assisted
---

# dnim uninstall

## Name

`dnim-win-[x86|x64|arm64] uninstall` - Detects, classifies, and removes .NET installations on a device.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] uninstall [-a|--accept-license]
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
    [-v|--verbosity <quiet|normal|diagnostic>]
    [--verify-signatures <always|bypass|never>]
    [--what-if]

dnim-win-[x86|x64|arm64] uninstall -?|-h|--help
```

## Description

The `uninstall` command attempts to remove all copies of .NET from the device. This may not be possible if installations are shared with other products like Visual Studio (see [Managed .NET installations on Windows](dnim-net-installs.md)).

Various options can be used to target specific installations. For example, an administrator may want to remove all copies of .NET that are not in active support to comply with their organization's internal policies.

> [!IMPORTANT]
> This command must be run with elevated privileges to make changes. Include the `--what-if` option if you want to evaluate the results without making changes.

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

- [!INCLUDE [restore-point-suffix](includes/dnim-cli-restore-point-suffix.md)]

- [!INCLUDE [report-issues](includes/dnim-cli-report-issues.md)]

- [!INCLUDE [release-version](includes/dnim-cli-release-version.md)]

- [!INCLUDE [support-phase](includes/dnim-cli-support-phase.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

- [!INCLUDE [verify-signatures](includes/dnim-cli-verify-signatures.md)]

- [!INCLUDE [what-if](includes/dnim-cli-what-if.md)]

## Results

The results are similar to those produced by the [`scan`](dnim-cli-scan.md) command with the addition of an extra column indicating whether or not an installation can be removed. The excerpt below was generated from running `dnim-win-x64.exe uninstall --pv 8.0 --klsp active --klsp maintenance --what-if`. The command specifically targets removing .NET 8.0, but will retain installations if they are the latest known release and the support phase is either `active` or `maintenance`. The 3.1 and 6.0 SDKs are excluded because they are not part of .NET 8.0. The 8.0.130 SDK is also not removed because it was the latest known release version when the command was executed.

| Display Name | Release | Type | Support | Uninstall Action |
| --- | --- | --- | --- | --- |
| Microsoft .NET Core SDK 3.1.426 (x64) | 3.1.426 | Bundle | EOL | NoneProductVersionExcluded |
| Microsoft .NET SDK 6.0.136 (x64) | 6.0.136 | Bundle | EOL | NoneProductVersionExcluded |
| Microsoft .NET SDK 8.0.130 (x64) | 8.0.130 | Bundle | Maintenance | NoneLatestReleasedVersion |

## Policy Evaluation

DNIM generates a set of internal policy rules based on the command-line options. Every installation is evaluated against the policies. Evaluation stops when a policy applies. If no policies apply, the .NET installation can be removed.

The table below contains an overview of the policies created from the command-line options.

| Policy | Description |
| --- | --- |
| Product Version | Include or exclude installations based on their product version. |
| Support Phase | Include or exclude installations based on their support phase. |
| Release Version | Include or exclude installations based on their release version. |
| Retention | Retain installations based on product version or support phase. |
| Install Type | Include or exclude installations based on their install type. |
| Orphaned Installations | Consider orphaned installations for removal. |
| Visual Studio EOL | Considers installations marked as out-of-support in Visual Studio. |
| Dependency Provider | Exclude installations if other products depend on them. |
| Signing | Exclude or include installations based on whether packages are signed. |

### Example

Consider the following command-line: `dnim-win-x64 uninstall --pv 6.0`. The command only considers installations associated with .NET 6.0. When the tool evaluates a .NET 7.0 installation, the product version policy applies and excludes it.

## Policy Results

Every installation is assigned an action based on the evaluated policies. The table belows contains
a description for the various policy actions returned by the `uninstall` command. Policy actions with a
`None` prefix indicate the installation won't be removed.

| Action | Policy | Description |
| --- | --- | --- |
| NoneNotOutOfSupport | Support Phase | The product is still considered to be in support based on the published release information. |
| NoneLatestReleasedVersion | Retention | The installation is the latest known released version and will be retained. |
| NoneNotOutOfSupportInVisualStudio | Visual Studio EOL | The product is out of support, but not all instances of Visual Studio considers it out-of-support. This indicates that product information in one or more Visual Studio catalog is outdated or incorrect. |
| NoneProductVersionExcluded | Product Version | The product will be retained because its version excluded it from being removed. |
| NoneProductVersionNotFound | Product Version | The installation belongs to an unknown .NET product version. This can happen when the .NET releases JSON data has not been updated or an old copy of data is being used. |
| NoneSupportPhaseExcluded | Support Phase | The installation will be retained because its support phase is excluded. |
| NoneInstallPlatformExcluded | Install Type | The installation will be retained because its platform is excluded. |
| NoneInstallTypeExcluded | Install Type | The installation will be retained because its type is excluded. For example, the user only specified MSIs to be removed. |
| NoneInstallComponentExcluded | Install Type | The installation will be retained because its component is excluded. For example, only SDK installations were selected, but the install is part of a shared framework like ASP.NET Core. |
| NoneReleaseVersionExcluded | Release Version | The installation will be retained because it does not match the specified release version. |
| NoneDependentsExist | Dependency Provider | The installation will be retained because another product still depends on it. For example, the same MSI was installed by both a standalone bundle and one or more Visual Studio instances. |
| NoneUnsigned | Signing | The installation package on disk is not signed. |
| Uninstall | N/A | The installation was successfully evaluated agaisnt all active policies and will be removed. |
| UninstallParentDependency | N/A  | The installation will be removed because a parent dependency will be removed, e.g., an MSI will be removed becasue the .NET bundle to which it belongs will be removed. |
| UninstallOrphanedByVs | N/A | The installation will be removed because it was orphaned by Visual Studio. |
| NoneEolVersion | N/A | The product associated with an installation is EOL and won't be updated. |
| NoneDiscontinuedSdk | N/A | The .NET product is still supported, but the latest updates no longer include the specific feature band. |
| NoneNoComponent | N/A | The release data does not have any component data about the SDK or runtime. |
| NoneNoComponentFile | N/A | The release data includes component data, but not information about individual installation files. |

## Examples

- Remove all .NET installations that are end-of-life (EOL).

  ```console
  dnim-win-[x86|x64|arm64] uninstall --sp eol
  ```

- Remove all .NET installs, but retain the latest version for any products that are in active support if they are installed.

  ```console
  dnim-win-[x86|x64|arm64] uninstall --klsp active
  ```

  Assume .NET 9 and 8 are in active support and when the command was executed, the latest releases included 9.0.19 and 8.0.30. If a device has .NET 9.0.17 and 8.0.30 installed, the command will remove 9.0.17, but retain 8.0.30.

- Remove all SDK bundles if their release version is less than 10.0.0.

  ```console
  dnim-win-[x86|x64|arm64] uninstall --it sdk --it bundle --rv [,10.0.0)
  ```

## See also

[.NET Installs](dnim-net-installs.md)
