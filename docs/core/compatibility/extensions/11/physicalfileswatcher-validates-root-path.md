---
title: "Breaking change: PhysicalFilesWatcher validates root and FileSystemWatcher paths"
description: "Learn about the breaking change in .NET 11 where PhysicalFilesWatcher validates the root argument and the relationship between root and FileSystemWatcher.Path."
ms.date: 08/28/2026
ai-usage: ai-assisted
---

# PhysicalFilesWatcher validates root and FileSystemWatcher paths

<xref:Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher> constructors now validate the `root` argument and the relationship between `root` and `FileSystemWatcher.Path`. Invalid combinations that were previously accepted at construction time now throw an exception.

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, the `PhysicalFilesWatcher` constructors stored the supplied `root` without validation or normalization. A `null` or otherwise invalid root could be accepted at construction time and fail during a later watcher operation.

The constructors also accepted a `FileSystemWatcher` whose nonempty `Path` was unrelated to `root`. Such a watcher generally couldn't report changes relevant to the configured root, but the mismatch didn't cause the constructor to throw.

For example, the following construction succeeded:

```csharp
string root = Path.Combine(Path.GetTempPath(), "root");
string unrelatedPath = Path.Combine(Path.GetTempPath(), "unrelated");
Directory.CreateDirectory(root);
Directory.CreateDirectory(unrelatedPath);

using var fileSystemWatcher = new FileSystemWatcher(unrelatedPath);
using var watcher = new PhysicalFilesWatcher(
    root,
    fileSystemWatcher,
    pollForChanges: false);
```

## New behavior

Starting in .NET 11, the `PhysicalFilesWatcher` constructors normalize `root` by calling `Path.GetFullPath()` and reject invalid inputs at construction time:

- If `root` is `null`, the constructor throws <xref:System.ArgumentNullException>.
- If `root` can't be converted to a full path, the constructor propagates the applicable exception from `Path.GetFullPath()`.
- If `FileSystemWatcher.Path` is nonempty and is unrelated to `root`, the constructor throws <xref:System.ArgumentException>.

`FileSystemWatcher.Path` is valid when it's empty, equal to `root`, an ancestor of `root`, or a descendant of `root`. In the previous example, construction now throws `ArgumentException` because `unrelatedPath` is neither an ancestor nor a descendant of `root`.

A root directory that doesn't yet exist remains valid. File watching is deferred until the root is created.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

`PhysicalFilesWatcher` now supports roots that don't exist when the watcher is constructed. This requires normalization of the root and coordination of a supplied `FileSystemWatcher` with that root.

A `FileSystemWatcher` that monitors an unrelated directory can't reliably produce notifications for the configured root. Rejecting this invalid combination at construction time prevents a watcher from being created in a configuration that generally didn't work. Validation of the root also causes invalid paths to fail immediately instead of during a later watcher operation. For more information, see [dotnet/runtime#126411](https://github.com/dotnet/runtime/pull/126411).

## Recommended action

Pass a non-null, valid path as `root`.

When you supply a `FileSystemWatcher` with a nonempty `Path`, configure its path to be equal to, an ancestor of, or a descendant of `root`. For example:

```csharp
string root = Path.GetFullPath(configuredRoot);

using var fileSystemWatcher = new FileSystemWatcher(root);
using var watcher = new PhysicalFilesWatcher(
    root,
    fileSystemWatcher,
    pollForChanges: false);
```

If the root directory doesn't exist yet, an empty `FileSystemWatcher.Path` is valid:

```csharp
string root = Path.GetFullPath(configuredRoot);

using var fileSystemWatcher = new FileSystemWatcher();
using var watcher = new PhysicalFilesWatcher(
    root,
    fileSystemWatcher,
    pollForChanges: false);
```

The watcher begins monitoring after the root directory is created.

## Affected APIs

- [PhysicalFilesWatcher(String, FileSystemWatcher, Boolean) constructor](xref:Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher.%23ctor(System.String,System.IO.FileSystemWatcher,System.Boolean))
- [PhysicalFilesWatcher(String, FileSystemWatcher, Boolean, Physical.ExclusionFilters) constructor](xref:Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher.%23ctor(System.String,System.IO.FileSystemWatcher,System.Boolean,Microsoft.Extensions.FileProviders.Physical.ExclusionFilters))
