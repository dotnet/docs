---
title: "Breaking change: `dotnet workload` commands output change"
description: Learn about a breaking change in the .NET 9 SDK where the `dotnet workload` commands output only the JSON body.
ms.date: 01/09/2024
ms.topic: concept-article
---
# `dotnet workload` commands output change

There's been in a change in the output of the following commands:

- `dotnet workload list --machine-readable`
- `dotnet workload install --print-download-link-only`
- `dotnet workload update --print-download-link-only`
- `dotnet workload update --print-rollback`

Previously, the affected commands outputted the following:

- Start and end boundary lines for custom parsing to locate the JSON body.
- Any other logging text that the commands outputted during normal operation.
- The JSON body.

Now, these commands only output the JSON body.

## Previous behavior

Previously, the affected `dotnet workload` commands produced output similar to the following for the command `dotnet workload list --machine-readable`:

```output
Failed to update the advertising manifest microsoft.net.sdk.tvos: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.sdk.android: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.sdk.maui: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.workload.emscripten: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.sdk.macos: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.sdk.maccatalyst: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.sdk.ios: Unable to load the service index for source https://REDACTED/index.json..
Failed to update the advertising manifest microsoft.net.workload.mono.toolchain: Unable to load the service index for source https://REDACTED/index.json..
==workloadListJsonOutputStart==
{"installed":["macos","ios"],"updateAvailable":[{"existingManifestVersion":"12.0.101-preview.10.249","availableUpdateManifestVersion":"12.0.101-preview.10.251","description":".NET SDK Workload for building macOS applications.","workloadId":"macos"},{"existingManifestVersion":"15.0.101-preview.9.31","availableUpdateManifestVersion":"15.0.101-preview.10.251","description":".NET SDK Workload for building iOS applications.","workloadId":"ios"}]}
==workloadListJsonOutputEnd==
```

## New behavior

Starting in .NET 9, the affected `dotnet workload` commands produced output similar to the following for the command `dotnet workload list --machine-readable`:

```output
{"installed":["macos","ios"],"updateAvailable":[{"existingManifestVersion":"12.0.101-preview.10.249","availableUpdateManifestVersion":"12.0.101-preview.10.251","description":".NET SDK Workload for building macOS applications.","workloadId":"macos"},{"existingManifestVersion":"15.0.101-preview.9.31","availableUpdateManifestVersion":"15.0.101-preview.10.251","description":".NET SDK Workload for building iOS applications.","workloadId":"ios"}]}
```

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

When JSON is requested, many CLI products only output JSON. We wanted to follow suit and also output only JSON. With this change, customers that use these commands in their tooling don't require any custom parsing. You can pipe the output of these commands directly into a JSON parser instead of intermediary parsing logic.

## Recommended action

If your code searches for the following start and end boundary text prior to parsing JSON, you no longer need to search the output for these boundaries. Instead, consider the output of these commands to directly be the JSON body.

- `==workloadListJsonOutputStart==/==workloadListJsonOutputEnd==`
- `==allPackageLinksJsonOutputStart==/==allPackageLinksJsonOutputEnd==`
- `==workloadRollbackDefinitionJsonOutputStart==/==workloadRollbackDefinitionJsonOutputEnd==`

## Affected APIs

N/A
