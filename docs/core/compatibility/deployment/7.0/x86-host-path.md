---
title: "Breaking change: x86 host path on 64-bit Windows"
description: Learn about the breaking change in deployment where the 32-bit .NET host isn't added to PATH on 64-bit Windows platforms.
ms.date: 06/22/2022
ms.topic: concept-article
---
# x86 host path on 64-bit Windows

The x86 versions of .NET installers for Windows have been modified to no longer add the x86 host location (*Program Files (x86)\dotnet*) to the `PATH` environment variable on 64-bit Windows systems.

With this change, if the x86 host location was added to `PATH` by a prior version of .NET, the x86 versions of .NET installers and .NET updates will remove it on upgrade.

This change affects .NET Core 3.1, .NET 6, .NET 7, and future versions.

This change only affects the `dotnet` host. It doesn't affect 32-bit/x86 application hosts, like *myapp.exe*. Those hosts will continue to find the x86 runtime correctly (assuming it's installed).

## Previous behavior

The x86 host location was added to `PATH`, even on x64/Arm64 systems. Depending on which .NET architecture installer was run first, a user's machine could have either the native (x64/Arm64) or x86 host listed first in `PATH`.

## New behavior

Going forward, the x86 host location is only added to the `PATH` environment variable on x86 systems and will be removed on upgrade of .NET or Visual Studio on any x64 and arm64 systems.

## Version introduced

.NET 7

## Reason for change

Currently, the x86 host location is added to `PATH`, even on x64/Arm64 systems. Depending on which .NET architecture installer is run first, a user's machine could have either the native (x64/Arm64) or the x86 host as the first location in the `PATH` list. This ambiguity causes problems with the initial .NET installation and during .NET servicing events. Any of these installation scenarios can modify the order of .NET hosts in `PATH`, making it non-deterministic. There's a high chance of behavior regression of the .NET runtime.

This change streamlines the `dotnet` host experience on Windows 64-bit systems. Only 64-bit hosts will be available in the system's `PATH` environment variable: the x64 host on x64 systems and the Arm64 host on Arm64 systems. We removed the ambiguity in the order of `dotnet` hosts in `PATH`, and only one host will be present.

## Recommended action

If you need the x86 host in the `PATH` environment variable on x64/Arm64 systems, add the host location to `PATH` manually.

## Affected APIs

None.
