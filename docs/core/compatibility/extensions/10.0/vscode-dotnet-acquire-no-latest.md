---
title: "Breaking change: dotnet.acquire API for VS Code no longer always downloads latest"
description: "Learn about the breaking change in .NET 10 where the dotnet.acquire VS Code API no longer always checks for the latest runtime version before returning a path."
ms.date: 11/04/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/vscode-dotnet-runtime/issues/2359
---

# dotnet.acquire API for VS Code no longer always downloads latest

The .NET Install Tool Extension for VS Code provides the `dotnet.acquire` command to install a .NET runtime for VS Code extensions. Starting in version 3.0.0 of the .NET Install Tool, calling `dotnet.acquire` no longer always checks for the latest runtime version. Instead, it uses existing runtime installations and checks daily for newer versions after a configurable delay.

## Version introduced

.NET Install Tool 3.0.0

## Previous behavior

Up until version 3.0.0 of the .NET Install Tool (or pre-release version 2.4.1), calling `dotnet.acquire` always triggered a check to see what the latest runtime version was, given the user was online and did not specify any settings to do otherwise. If that latest runtime was not available on the machine, it would be installed, and the path to it would be returned.

This runtime is used for C# Dev Kit, C#, and other VS Code extensions to run internal C# code and processes, such as the language server host.

## New behavior

Starting in .NET Install Tool 3.0.0, `dotnet.acquire` no longer always checks for a newer runtime version before returning the path to a runtime that matches the `major.minor`. Instead, the tool:

1. Uses existing runtime installations it made.
1. Checks daily for a new runtime after `runtimeUpdateDelaySeconds` (defaults to 5 minutes). This is a setting that can be changed in the VS Code Extension Settings.
1. After the delay, checks for newer runtime versions and installs the new runtime if needed.
1. After installation, automatically uninstalls all remaining .NET runtimes that are not 'in-use' and are not the latest patch for a specific `major.minor`, `architecture`, and `mode` (`runtime` vs `aspnetcore` runtime) combination.

'In-use' means that the executable path to that .NET runtime install was:

- Returned by a command through the .NET Install Tool in any session of VS Code, VS Code Insiders, or otherwise that has a currently live, running process. This includes but is not limited to: `dotnet.acquire`, `dotnet.acquireStatus`, `dotnet.availableInstalls`, and `dotnet.findPath`.
- Part of the PATH or DOTNET_ROOT environment variable in which VS Code is operating within.

Additionally, the `dotnet.uninstall` command no longer allows uninstalling an install that is 'in-use'.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change speeds up the developer loop by deferring the network call and installation time away from the launch of extensions that utilize .NET. For users in the worst 3% of networks who did not have their own .NET runtime that matched the requirements of any extension's .NET version, the download time alone created a 9-36 second delay at startup. For the median user, this represented a 287 ms delay.

## Recommended action

Developers who rely on `dotnet.acquire` and want to enforce that a new runtime is used every single time should consider using `forceUpdate: true` in their call to `dotnet.acquire`. We generally recommend against this unless a runtime security patch, feature, or bug is dramatic enough to warrant downloading the latest runtime.

Example:

```javascript
const dotnetRuntimePath = (await vscode.commands.executeCommand<IDotnetAcquireResult>(
    'dotnet.acquire',
    { version: '9.0', requestingExtensionId, forceUpdate: true }
)).dotnetPath;
```

Developers who rely on the .NET Install Tool should make sure that they don't cache or reuse any path from the .NET Install Tool without calling `dotnet.availableInstalls` again to demonstrate that they are using the installation in a given session if it's not in the PATH.

Developers should continue to use `dotnet.uninstall` as they previously did to decrement the reference counts of the installs they own. However, this is less vital since uninstallation happens when the older version is replaced with the newer version.

Customers should avoid relying on hard-coded private runtime installations managed by the .NET Install Tool as that is not the intended purpose of these runtimes. If they must, they should set the PATH or DOTNET_ROOT for their VS Code instances such that the install does not get automatically cleaned up.

## Affected APIs

None.

## See also

- [.NET Install Tool for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-runtime)
- [.NET Install Tool commands documentation](https://github.com/dotnet/vscode-dotnet-runtime/blob/main/Documentation/commands.md)
