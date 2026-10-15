---
title: "Breaking change: SDK local container runtime selection prefers platform-native tools"
description: "Learn about the breaking change in .NET 11 where SDK local container runtime selection prefers platform-native tools on Windows and macOS."
ms.date: 08/04/2026
ai-usage: ai-assisted
---

# SDK local container runtime selection prefers platform-native tools

Starting in .NET 11, when you publish an SDK container to a local container runtime, the SDK automatically prefers platform-native CLIs when they're available: `wslc` on Windows and Apple's `container` CLI on macOS. This change affects which local runtime receives the image when Docker or Podman is also installed.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, when `LocalRegistry` wasn't explicitly set, the SDK probed Docker and Podman and loaded the published image into the selected Docker or Podman runtime.

## New behavior

Starting in .NET 11, on Windows, the SDK first probes `wslc`. On macOS, the SDK first probes Apple's `container` CLI. If the platform-native tool is available and its service runs, the SDK loads the published image there. Docker and Podman remain fallback options.

You can explicitly select Docker, Podman, `wslc`, or Apple's `container` CLI through the `LocalRegistry` MSBuild property.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Windows and macOS now provide platform-native container tooling. The SDK gives you the native platform experience while it preserves Docker and Podman fallback behavior.

For more information, see the [related implementation](https://github.com/dotnet/sdk/pull/55249) and tracking issues [dotnet/sdk-container-builds#651](https://github.com/dotnet/sdk-container-builds/issues/651) and [dotnet/sdk-container-builds#636](https://github.com/dotnet/sdk-container-builds/issues/636).

## Recommended action

If automatic selection works for your workflow, no action is required.

To keep using a specific runtime, set the `LocalRegistry` MSBuild property explicitly:

```dotnetcli
dotnet publish /t:PublishContainer -p:LocalRegistry=Docker
```

Use `Docker` or `Podman` to select Docker or Podman. Use `Wslc` on Windows or `MacOSContainer` on macOS to select the platform-native runtime explicitly.

## Affected APIs

- `Microsoft.NET.Build.Containers.KnownLocalRegistryTypes.Wslc`
- `Microsoft.NET.Build.Containers.KnownLocalRegistryTypes.MacOSContainer`
