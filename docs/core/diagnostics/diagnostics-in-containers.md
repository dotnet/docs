---
title: Collect diagnostics in containers
description: Learn how .NET diagnostics tools for gathering performance traces and collecting dumps can be used in Docker containers.
ms.date: 09/01/2020
---

# Collect diagnostics in containers

The same diagnostics tools that are useful for diagnosing .NET issues in other scenarios also work in Docker containers. However, some of the tools require special steps to work in a container. This article covers how tools for gathering performance traces and collecting dumps can be used in Docker containers.

## Use .NET CLI tools in a container

**These tools apply to: ✔️** .NET Core 3.1 SDK and later versions

The .NET global CLI diagnostic tools ([dotnet-counters](dotnet-counters.md), [dotnet-dump](dotnet-dump.md), [dotnet-gcdump](dotnet-gcdump.md), [dotnet-monitor](dotnet-monitor.md), and [dotnet-trace](dotnet-trace.md)) are designed to work in a wide variety of environments and should all work directly in Docker containers. Because of this, these tools are the preferred method of collecting diagnostic information for .NET scenarios targeting .NET Core 3.1 or later in containers.

You can also install these tools without the .NET SDK by downloading the single-file variants from the links in the previous paragraph. These installs require a global install of the .NET runtime version 3.1 or later, which you can acquire following any of the prescribed methods in the [.NET installation documentation](../install/index.yml) or by consuming any of the official runtime containers.

### Use .NET global CLI tools in a sidecar container

If you would like to use .NET global CLI diagnostic tools to diagnose processes in a different container, bear the following additional requirements in mind:

1. The containers must [share a process namespace](https://docs.docker.com/reference/cli/docker/container/run/#pid) (so that tools in the sidecar container can access processes in the target container).
2. The .NET global CLI diagnostic tools need access to files the .NET runtime writes to the /tmp directory, so the /tmp directory must be shared between the target and sidecar container via a volume mount. This could be done, for example, by having the containers share a common [volume](https://docs.docker.com/storage/volumes/#create-and-manage-volumes) or a Kubernetes [emptyDir](https://kubernetes.io/docs/concepts/storage/volumes/#emptydir) volume. If you attempt to use the diagnostic tools from a sidecar container without sharing the /tmp directory, you will get an error about the process "not running compatible .NET runtime."

## Use `PerfCollect` in a container

**This tool applies to: ✔️** .NET Core 2.1 and later versions

The [`PerfCollect`](./trace-perfcollect-lttng.md) script is useful for collecting performance traces and is the recommended tool for collecting traces prior to .NET Core 3.0. If using `PerfCollect` in a container, keep the following requirements in mind:

- `PerfCollect` requires additional capabilities to run the `perf` tool. The minimal set of capabilities required is [`PERFMON`](https://man7.org/linux/man-pages/man7/capabilities.7.html) and [`SYS_PTRACE`](https://man7.org/linux/man-pages/man7/capabilities.7.html). Some environments require [`SYS_ADMIN`](https://man7.org/linux/man-pages/man7/capabilities.7.html). Be sure to start the container with [the necessary capabilities](https://docs.docker.com/engine/security/#linux-kernel-capabilities). If the minimal set doesn't work, then try with the full set.

- `PerfCollect` requires some environment variables to be set prior to the app it is profiling starting. These can be set either in a [Dockerfile](https://docs.docker.com/engine/reference/builder/#env) or when you [start the container](https://docs.docker.com/reference/cli/docker/container/run/#env). Because these variables shouldn't be set in normal production environments, it's common to just add them when starting a container that will be profiled. The two variables that PerfCollect requires are:

  - `DOTNET_PerfMapEnabled=1`
  - `DOTNET_EnableEventLog=1`

> [!NOTE]
> When executing the app with .NET 7, you must also set `DOTNET_EnableWriteXorExecute=0` in addition to the preceding environment variables.

  [!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

### Use `PerfCollect` in a sidecar container

If you want to run `PerfCollect` in one container to profile a .NET process in a different container, the experience is almost the same. The differences are:

- The environment variables mentioned previously (`DOTNET_PerfMapEnabled` and `DOTNET_EnableEventLog`) must be set for the target container (not the one running `PerfCollect`).
- The container running `PerfCollect` must have the `SYS_ADMIN` capability (not the target container).
- The two containers must [share a process namespace](https://docs.docker.com/reference/cli/docker/container/run/#pid).
