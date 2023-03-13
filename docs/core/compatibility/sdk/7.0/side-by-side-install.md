---
title: "Breaking change: Side-by-side SDK installations"
description: Learn about a breaking change in the .NET 7 SDK where having a preview version of the SDK installed alongside the GA version causes projects with certain workloads to fail to build, load, or run.
ms.date: 12/05/2022
---
# Side-by-side SDK installations

If a preview .NET 7 SDK is installed alongside the general availability (GA) version of the .NET 7 SDK, projects with workload dependencies such as `microsoft.net.workload.mono.toolchain` may fail to build, load, or run. The error is similar to:

> The SDK resolver "Microsoft.DotNet.MSBuildSdkResolver" failed while attempting to resolve the SDK "Microsoft.NET.Sdk". Exception: "Microsoft.NET.Sdk.WorkloadManifestReader.WorkloadManifestCompositionException: Workload definition 'wasm-tools' in manifest 'microsoft.net.workload.mono.toolchain'.

> [!NOTE]
> This behavior was fixed in .NET SDK 7.0.101.

## Version introduced

.NET 7

## Previous behavior

Building, loading, or running an affected project worked fine.

## New behavior

Building, loading, or running an affected project fails.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

.NET 7 preview SDKs are incompatible with the GA version because the mono.toolchain workload was renamed.

## Recommended action

Choose one of the following actions:

- Uninstall any .NET 7 preview SDKs. For detailed instructions, see [How to remove the .NET Runtime and SDK](../../../install/remove-runtime-sdk-versions.md). For example, on Windows, you can uninstall .NET preview SDKs using **Add or remove programs** in Control panel. You can also use the [`dotnet-core-uninstall` tool](https://github.com/dotnet/cli-lab/releases) to uninstall preview SDKs.

- For file-based installs, you can delete the folder *%ProgramFiles%/dotnet/sdk-manifests/7.0.100/microsoft.net.workload.mono.toolchain*.
