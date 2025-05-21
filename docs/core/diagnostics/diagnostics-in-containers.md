---
title: Collect diagnostics in Linux containers
description: Learn how .NET diagnostics tools for gathering performance traces and collecting dumps can be used in Linux containers.
ms.date: 04/16/2025
ms.topic: how-to
---

# Collect diagnostics in Linux containers

The same diagnostics tools that are useful for diagnosing .NET issues in other scenarios also work in containers. The tools can be run in the same container as the target process, from the host, or from a sidecar container.

## Use .NET CLI tools in a container

**These tools apply to: ✔️** .NET Core 3.1 SDK and later versions

All of the [dotnet-* CLI diagnostic tools](tools-overview.md#cli-tools) can work when run within the same container as the application they are inspecting but beware these potential trouble spots:

- Tools run inside a container will be subject to container resource limits. The tools may run slowly or fail if the resource limits are too low. Most of the tools have modest requirements but `dotnet-dump` and `dotnet-gcdump` can use considerable memory and disk space when targeting a process that has a large memory footprint. `dotnet-trace` and `dotnet-counters` might also create large files if they are configured to capture a large amount of trace events or metric time-series data.
- `dotnet-dump` will cause a helper process to run that needs ptrace permissions. Linux has numerous security configuration options that can affect whether this is successful so in some cases you may need to adjust the container's security configuration. See the [dump FAQ](faq-dumps.yml) for more guidance on diagnosing security privileges.
- When running tools inside the container you can either install them in advance when building the container or download them on-demand. Installing them in advance makes it easier when you need them but increases the size of the container and creates a larger attack surface that malicious actors could attempt to exploit.

## Use .NET CLI tools in a sidecar container or from the host

The [dotnet-* CLI diagnostic tools](tools-overview.md#cli-tools) also support running from the host or in a sidecar container. This largely avoids the size, security, and resource limitations of running in the same container but has some additional requirements for the tools to communicate successfully.

When identifying a target process to inspect using the `--process-id` or `--name` tool command-line arguments, this requires:

1. The containers must [share a process namespace](https://docs.docker.com/reference/cli/docker/container/run/#pid) so that tools in the sidecar container can access processes in the target container.
2. The tools need access to the [diagnostic port](diagnostic-port.md) Unix Domain Socket which the .NET runtime writes to the */tmp* directory, so the */tmp* directory must be shared between the target and sidecar container via a volume mount. This could be done, for example, by having the containers share a common [volume](https://docs.docker.com/storage/volumes/#create-and-manage-volumes) or a Kubernetes [emptyDir](https://kubernetes.io/docs/concepts/storage/volumes/#emptydir) volume. If you attempt to use the diagnostic tools from a sidecar container without sharing the */tmp* directory, you will get an error about the process "not running compatible .NET runtime."

If you don't want to share process namespace and the */tmp* directory, many of the tools also support a more advanced `--diagnostic-port` command-line option. This allows you to directly specify the path to the target process' [diagnostic port](diagnostic-port.md) within the filesystem of the host or sidecar. The target container's /tmp directory will need to be mapped somewhere for this path to exist, but it doesn't have to be shared with the host or sidecar */tmp*.

> [!NOTE]
> Even when running the diagnostic tools from the host or sidecar, the target process may still be requested to do work which increases its resource usage inside the target container. We have observed dotnet-dump may cause the target process to page in substantial virtual memory when collecting a dump. Other tools may cause smaller impacts though we haven't seen these cause problems in practice. For example, `dotnet-trace` requests the target process to allocate an event buffer and `dotnet-counters` requests a small memory region where metric data is aggregated. We recommend testing to ensure your memory limits aren't so tight that running the tools causes the OS to terminate your containers.

> [!NOTE]
> When `dotnet-dump` writes a dump file to disk, the output path is interpreted in the context of the target process' view of the file system. This may differ from the host or sidecar container.

## Use `PerfCollect` in a container

**This tool applies to: ✔️** .NET Core 2.1 and later versions

The [`PerfCollect`](./trace-perfcollect-lttng.md) script is useful for collecting performance traces that contain kernel events such as CPU samples or context switches. If using `PerfCollect` in a container, keep the following requirements in mind:

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
