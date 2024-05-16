---
title: ".NET 6 breaking change: Environment.ProcessorCount behavior on Windows"
description: Learn about the .NET 6 breaking change in core .NET libraries where Environment.ProcessorCount may return a different value on Windows compared to previous .NET versions.
ms.date: 05/19/2021
---
# Environment.ProcessorCount behavior on Windows

On Windows, the <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> property now respects process affinity and the job object's hard limit on CPU utilization.

## Change description

In previous .NET versions, the <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> property on Windows returns the number of logical processors on the machine. The property ignores process affinity and the job object's hard limit on CPU utilization. That Windows behavior is inconsistent with the behavior on Unix-based operating systems, where those limits are respected.

Starting with .NET 6, the behavior of <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> on Windows is consistent with the behavior on Unix-based operating system. In general, <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> returns the minimum of:

- The number of logical processors on the machine.
- If the process is running with CPU affinity, the number of processors that the process is affinitized to.
- If the process is running with a CPU utilization limit, the CPU utilization limit rounded up to the next whole number.

The following table shows how the value of <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> changes from .NET 5 to .NET 6 on a machine with eight logical processors:

| Environment | .NET 5 | .NET 6 |
|-|-|-|
| Process affinitized to two logical processors (Windows) | 8 | 2 |
| Process affinitized to two logical processors (Unix) | 2 | 2 |
| CPU utilization limited to the equivalent of two logical processors (Windows) | 8 | 2 |
| CPU utilization limited to the equivalent of two logical processors (Unix) | 2 | 2 |

## Version introduced

6.0

## Reason for change

This property is frequently used to determine the parallelism factor for a process. We've observed that not limiting the property's value based on affinitization and CPU utilization limit can lead to worse performance.

## Recommended action

Review code that uses <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> to scale down the parallelism factor based on application or system configuration. Even if the code takes the process's affinity mask or the job object's CPU utilization limit into account, it may end up using lower parallelism than intended.

Review code that expects <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> to return the total number of logical processors on the machine, for example, to display it to a user. Instead, you can use a PInvoke call to the `GetSystemInfo` or `GetNativeSystemInfo` Win32 APIs.

If code performs worse as a result of this change, you can use the `DOTNET_PROCESSOR_COUNT` environment variable to override the number of processors thought to be available by the .NET runtime and reported by the <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> property. For example, if you set `DOTNET_PROCESSOR_COUNT` to 4, <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> will disregard any process affinity and CPU utilization limit and return 4. To mimic .NET 5 behavior, set the environment variable to `%NUMBER_OF_PROCESSORS%`.

## Affected APIs

- <xref:System.Environment.ProcessorCount?displayProperty=fullName>

<!--

### Category

- Core .NET libraries

### Affected APIs

- `P:System.Environment.ProcessorCount`

-->
