---
title: "Breaking change: dotnet.acquire API for VS Code no longer always downloads latest"
description: "Learn about the breaking change where the dotnet.acquire VS Code API no longer always checks for the latest runtime version before returning a path."
ms.date: 11/04/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/49127
---

# dotnet.acquire API for VS Code no longer always downloads latest

The .NET Install Tool Extension for VS Code provides the `dotnet.acquire` command to install a .NET runtime for VS Code extensions. Starting in version 3.0.0 of the .NET Install Tool, calling `dotnet.acquire` no longer always checks for the latest runtime version. Instead, it uses existing runtime installations and checks daily for newer versions after a configurable delay.

## Version introduced

.NET Install Tool 3.0.0

## Previous behavior

Up until version 3.0.0 of the .NET Install Tool (or prerelease version 2.4.1), calling `dotnet.acquire` always triggered a check to see what the latest runtime version was, given the user was online and did not specify any settings to do otherwise. If that latest runtime wasn't available on the machine, it was installed, and the path to it was returned.

This runtime is used for C# Dev Kit, C#, and other VS Code extensions to run internal C# code and processes, such as the language server host.

## New behavior

Starting with .NET Install Tool 3.0.0, `dotnet.acquire` no longer always checks for a newer runtime version before returning the path to a runtime that matches the `major.minor`. Instead, the tool:

1. Uses existing runtime installations it made.
1. Checks daily for a new runtime after `runtimeUpdateDelaySeconds` (defaults to 5 minutes). This setting can be changed in the VS Code Extension Settings.
1. After the delay, checks for newer runtime versions and installs the new runtime if needed.
1. After installation, automatically uninstalls all remaining .NET runtimes that aren't *in-use* and aren't the latest patch for a specific `major.minor`, `architecture`, and `mode` (`runtime` or `aspnetcore` runtime) combination.

*In-use* means that the executable path to that .NET runtime install was:

- Returned by a command through the .NET Install Tool in any session of VS Code, VS Code Insiders, or otherwise that has a currently live, running process. Commands include `dotnet.acquire`, `dotnet.acquireStatus`, `dotnet.availableInstalls`, and `dotnet.findPath`.
- Part of the `PATH` or `DOTNET_ROOT` environment variable in which VS Code is operating.

Additionally, the `dotnet.uninstall` command no longer allows uninstalling an install that's *in-use*.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change speeds up the developer loop by deferring the network call and installation time away from the launch of extensions that utilize .NET. For users in the worst 3% of networks who didn't have their own .NET runtime that matched the requirements of any extension's .NET version, the download time alone created a 9-36 second delay at startup. For the median user, this represented a 287 ms delay.

## Recommended action

If you rely on `dotnet.acquire` and want to enforce that a new runtime is used every single time, use `forceUpdate: true` in your call to `dotnet.acquire`. This is generally not recommended unless a runtime security patch, feature, or bug is dramatic enough to warrant downloading the latest runtime.

Example:

```javascript
const dotnetRuntimePath = (await vscode.commands.executeCommand<IDotnetAcquireResult>(
    'dotnet.acquire',
    { version: '9.0', requestingExtensionId, forceUpdate: true }
)).dotnetPath;
```

Make sure you don't cache or reuse any path from the .NET Install Tool without calling `dotnet.availableInstalls` again (to demonstrate that you're using the installation in a given session) if it's not in the `PATH`.

Continue to use `dotnet.uninstall` as you did previously to decrement the reference counts of the installs you own. However, this is less vital since uninstallation happens when the older version is replaced with the newer version.

Avoid relying on hard-coded private runtime installations managed by the .NET Install Tool as that isn't the intended purpose of these runtimes. If you must, set the `PATH` or `DOTNET_ROOT` for your VS Code instances such that the install doesn't get cleaned up automatically.

## Affected APIs

None.

## See also

- [.NET Install Tool for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-runtime)
- [.NET Install Tool commands documentation](https://github.com/dotnet/vscode-dotnet-runtime/blob/main/Documentation/commands.md)
