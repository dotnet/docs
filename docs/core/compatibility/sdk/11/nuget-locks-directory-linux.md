---
title: "Breaking change: NuGet locks directory moved on Linux"
description: "Learn about the breaking change in .NET 11 where the NuGet inter-process lock directory on Linux moves to the user's home directory."
ms.date: 11/06/2026
ai-usage: ai-assisted
---

# NuGet locks directory moved on Linux

Starting in .NET SDK 11.0.200, NuGet uses `~/.nuget/locks` instead of `/tmp/NuGetScratch{username}/locks` for inter-process locks on Linux. Concurrent NuGet processes that use different lock directories don't coordinate access to shared files.

## Version introduced

.NET SDK 11.0.200

## Previous behavior

Previously, NuGet used `/tmp/NuGetScratch{username}/locks` for inter-process locks on Linux, unless you set the `NUGET_SCRATCH` environment variable.

## New behavior

Starting in .NET SDK 11.0.200, NuGet uses `~/.nuget/locks` for inter-process locks on Linux, unless you set `NUGET_SCRATCH`. The `~` represents the user's home directory.

If SDK versions older than 11.0.200 and SDK versions 11.0.200 or later restore concurrently with different lock directories, they don't coordinate access to the global packages folder and other NuGet files. Failures or undefined behavior can result.

In every version, `NUGET_SCRATCH` overrides the default location. Its value specifies the parent directory, without a trailing `locks` component; NuGet uses the `locks` subdirectory within that directory.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To prevent other users on shared Linux computers from blocking NuGet for a target account, NuGet now stores locks in the user's home directory. The previous predictable path under the shared `/tmp` directory allowed other users to block NuGet for that account.

## Recommended action

To ensure concurrent restores coordinate access to shared files, use .NET SDK 11.0.200 or later everywhere, even for projects that specify an earlier `TargetFramework`.

Alternatively, set the same `NUGET_SCRATCH` value for all concurrent NuGet processes, regardless of SDK version. Specify the parent directory without a trailing `locks` component. For more information, see [NuGet environment variables](/nuget/reference/cli-reference/cli-ref-environment-variables).

## Affected APIs

None.
