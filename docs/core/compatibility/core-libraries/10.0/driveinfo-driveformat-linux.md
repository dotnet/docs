---
title: "Breaking change: DriveInfo.DriveFormat returns Linux filesystem types"
description: Learn about the .NET 10 breaking change in core .NET libraries where DriveInfo.DriveFormat on Linux systems returns Linux kernel filesystem type strings instead of mapped magic constants.
ms.date: 06/24/2025
---
# DriveInfo.DriveFormat returns Linux filesystem types

On Linux systems, <xref:System.IO.DriveInfo.DriveFormat?displayProperty=nameWithType> now returns Linux kernel filesystem type strings. These strings represent a more granular representation of the filesystem type than the previous implementation. For example, it's now possible to distinguish between `ext3` and `ext4`.

## Previous behavior

Previously, .NET returned a string representation by mapping magic constants to strings. Because several different filesystem types use the same magic constants, it wasn't possible to distinguish between them.

For cgroup file systems, `DriveFormat` returned `cgroupfs`/`cgroup2fs`. For the SELinux filesystem, the value was `selinux`.

## New behavior

Starting in .NET 10, .NET returns the string representation used by the Linux kernel for the filesystem type.

For cgroup file systems, `DriveFormat` returns `cgroup`/`cgroup2`. For the SELinux filesystem, the value is `selinuxfs`.

## Version introduced

.NET 10 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Provide more granular filesystem type information.

## Recommended action

Check and update usages of <xref:System.IO.DriveInfo.DriveFormat?displayProperty=nameWithType> to include the Linux filesystem type strings. On a Linux system, you can read the type strings of the drives from the `/proc/self/mountinfo` file. On each line, the filesystem type string is the first field after the `-` separator.

## Affected APIs

- <xref:System.IO.DriveInfo.DriveFormat?displayProperty=fullName>
