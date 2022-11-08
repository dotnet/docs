---
title: Collect diagnostics in containers
description: In this article, you'll learn how .NET Core diagnostics tools can be used in Docker containers.
ms.date: 09/01/2020
---

# Collect diagnostics in containers

The same diagnostics tools that are useful for diagnosing .NET Core issues in other scenarios also work in Docker containers. However, some of the tools require special steps to work in a container. This article covers how tools for gathering performance traces and collecting dumps can be used in Docker containers.

## Using .NET CLI tools in a container

**These tools apply to: ✔️** .NET Core 3.1 SDK and later versions

The .NET Core global CLI diagnostic tools ([dotnet-counters](dotnet-counters.md), [dotnet-dump](dotnet-dump.md), [dotnet-gcdump](dotnet-gcdump.md), [dotnet-monitor](dotnet-monitor.md), and [dotnet-trace](dotnet-trace.md)) are designed to work in a wide variety of environments and should all work directly in Docker containers. Because of this, these tools are the preferred method of collecting diagnostic information for .NET Core scenarios targeting .NET Core 3.1 or later in containers.

You can also install these tools without the .NET SDK by downloading the single-file variants from the links in the previous paragraph. These installs require a global install of the .NET runtime version 3.1 or later, which you can acquire following any of the prescribed methods in the [.NET installation documentation](../install/index.yml) or by consuming any of the official runtime containers.

### Using .NET Core global CLI tools in a sidecar container

If you would like to use .NET Core global CLI diagnostic tools to diagnose processes in a different container, bear the following additional requirements in mind:

1. The containers must [share a process namespace](https://docs.docker.com/engine/reference/run/#pid-settings---pid) (so that tools in the sidecar container can access processes in the target container).
2. The .NET Core global CLI diagnostic tools need access to files the .NET Core runtime writes to the /tmp directory, so the /tmp directory must be shared between the target and sidecar container via a volume mount. This could be done, for example, by having the containers share a common [volume](https://docs.docker.com/storage/volumes/#create-and-manage-volumes) or a Kubernetes [emptyDir](https://kubernetes.io/docs/concepts/storage/volumes/#emptydir) volume. If you attempt to use the diagnostic tools from a sidecar container without sharing the /tmp directory, you will get an error about the process "not running compatible .NET runtime."

## Using `PerfCollect` in a container

**This tool applies to: ✔️** .NET Core 2.1 and later versions

The [`PerfCollect`](./trace-perfcollect-lttng.md) script is useful for collecting performance traces and is the recommended tool for collecting traces prior to .NET Core 3.0. If using `PerfCollect` in a container, keep the following requirements in mind:

- `PerfCollect` requires the [`SYS_ADMIN` capability](https://man7.org/linux/man-pages/man7/capabilities.7.html) (in order to run the `perf` tool), so be sure the container is [started with that capability](https://docs.docker.com/engine/reference/run/#runtime-privilege-and-linux-capabilities).

- `PerfCollect` requires some environment variables be set prior to the app it is profiling starting. These can be set either in a [Dockerfile](https://docs.docker.com/engine/reference/builder/#env) or when [starting the container](https://docs.docker.com/engine/reference/run/#env-environment-variables). Because these variables shouldn't be set in normal production environments, it's common to just add them when starting a container that will be profiled. The two variables that PerfCollect requires are:

  - `DOTNET_PerfMapEnabled=1`
  - `DOTNET_EnableEventLog=1`

> [!NOTE]
> When executing the app with .NET 7, you must also set `DOTNET_EnableWriteXorExecute=0` in addition to the preceding environment variables.

  [!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

### Using `PerfCollect` in a sidecar container

If you would like to run `PerfCollect` in one container to profile a .NET Core process in a different container, the experience is almost the same except for these differences:

- The environment variables mentioned previously (`DOTNET_PerfMapEnabled` and `DOTNET_EnableEventLog`) must be set for the target container (not the one running `PerfCollect`).
- The container running `PerfCollect` must have the `SYS_ADMIN` capability (not the target container).
- The two containers must [share a process namespace](https://docs.docker.com/engine/reference/run/#pid-settings---pid).
