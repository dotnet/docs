---
title: Collect diagnostics in containers
description: In this article, you'll learn how .NET Core diagnostics tools can be used in Docker containers.
ms.date: 09/01/2020
---

# Collect diagnostics in containers

The same diagnostics tools that are useful for diagnosing .NET Core issues in other scenarios also work in Docker containers. However, some of the tools require special steps to work in a container. This article covers how tools for gathering performance traces and collecting dumps can be used in Docker containers.

## Using .NET CLI tools in a container

**These tools apply to: ✔️** .NET Core 3.0 SDK and later versions

The .NET Core global CLI diagnostic tools ([`dotnet-counters`](dotnet-counters.md), [`dotnet-dump`](dotnet-dump.md), [`dotnet-gcdump`](dotnet-gcdump.md), and [`dotnet-trace`](dotnet-trace.md)) are designed to work in a wide variety of environments and should all work directly in Docker containers. Because of this, these tools are the preferred method of collecting diagnostic information for .NET Core scenarios targeting .NET Core 3.0 or above (or 3.1 or above in the case of `dotnet-gcdump`) in containers.

The only complicating factor of using these tools in a container is that they are installed with the .NET SDK and many Docker containers run without the .NET SDK present. One easy solution to this problem is to install the tools in the initial Docker image. The tools don't need the .NET SDK to run, only to be installed. Therefore, it's possible to create a Dockerfile with a [multi-stage build](https://docs.docker.com/develop/develop-images/multistage-build/) that installs the tools in a build stage (where the .NET SDK is present) and then copies the binaries into the final image. The only downside to this approach is increased Docker image size.

```dockerfile
# In build stage
# Install desired .NET CLI diagnostics tools
RUN dotnet tool install --tool-path /tools dotnet-trace
RUN dotnet tool install --tool-path /tools dotnet-counters
RUN dotnet tool install --tool-path /tools dotnet-dump

...

# In final stage
# Copy diagnostics tools
WORKDIR /tools
COPY --from=build /tools .
```

Alternatively, the .NET SDK can be installed in a container when needed in order to install the CLI tools. Be aware that installing the .NET SDK will have the side-effect of reinstalling the .NET runtime. So be sure to install the version of the SDK that matches the runtime present in the container.

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

  [!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

### Using `PerfCollect` in a sidecar container

If you would like to run `PerfCollect` in one container to profile a .NET Core process in a different container, the experience is almost the same except for these differences:

- The environment variables mentioned previously (`DOTNET_PerfMapEnabled` and `DOTNET_EnableEventLog`) must be set for the target container (not the one running `PerfCollect`).
- The container running `PerfCollect` must have the `SYS_ADMIN` capability (not the target container).
- The two containers must [share a process namespace](https://docs.docker.com/engine/reference/run/#pid-settings---pid).

## Using `createdump` in a container

**This tool applies to: ✔️** .NET Core 2.1 and later versions

An alternative to `dotnet-dump`, [`createdump`](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/botr/xplat-minidump-generation.md) can be used for creating core dumps on Linux containing both native and managed information. The `createdump` tool is installed with the .NET Core runtime and can be found next to libcoreclr.so (typically in "/usr/share/dotnet/shared/Microsoft.NETCore.App/[version]"). The tool works the same in a container as it does in non-containerized Linux environments with the single exception that the tool requires the [`SYS_PTRACE` capability](https://man7.org/linux/man-pages/man7/capabilities.7.html), so the Docker container must be [started with that capability](https://docs.docker.com/engine/reference/run/#runtime-privilege-and-linux-capabilities).

### Using `createdump` in a sidecar container

If you would like to use `createdump` to create a dump from a process in a different container, the experience is almost the same except for these differences:

- The container running `createdump` must have the `SYS_PTRACE` capability (not the target container).
- The two containers must [share a process namespace](https://docs.docker.com/engine/reference/run/#pid-settings---pid).
