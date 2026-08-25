---
title: "Breaking change: NativeAOT uses lib prefix for native library outputs on Unix"
description: "Learn about the breaking change in .NET 11 where NativeAOT applies the lib prefix by default to non-executable native library outputs on Unix."
ms.date: 04/03/2026
ai-usage: ai-assisted
---

# NativeAOT uses lib prefix for native library outputs on Unix

Starting in .NET 11, NativeAOT applies the `lib` prefix (for example, `libmylib.so`, `libmylib.dylib`, `libmylib.a`) by default to non-executable native library outputs on Unix platforms. A new MSBuild property, `UseNativeLibPrefix`, lets you opt out of this behavior.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, NativeAOT didn't apply the `lib` prefix to native library outputs on Unix. For example:

- A shared library output was named `mylib.so`.
- A static library output was named `mylib.a`.

## New behavior

Starting in .NET 11, NativeAOT applies the `lib` prefix by default to non-executable native library outputs on Unix. For example:

- A shared library output is now named `libmylib.so`.
- A static library output is now named `libmylib.a`.

To opt out of the new behavior, set `UseNativeLibPrefix` to `false` in your project file:

```xml
<PropertyGroup>
  <UseNativeLibPrefix>false</UseNativeLibPrefix>
</PropertyGroup>
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The `lib` prefix is the widely accepted naming convention for shared and static libraries on Unix platforms. Applying it by default improves consistency and interoperability with other Unix-based tools and systems. It also removes the need for workarounds in .NET for Android, which requires binaries to follow this convention.

For more details, see the [original pull request](https://github.com/dotnet/runtime/pull/124611).

## Recommended action

Review your build outputs and update any scripts, deployment processes, or configurations that depend on the previous naming conventions. Specifically:

- **Update scripts and tools**: If your build or deployment scripts reference native library outputs by name, update them to account for the new `lib` prefix.
- **Opt out if necessary**: If the `lib` prefix causes issues in your workflow, set `UseNativeLibPrefix` to `false` in your project file:

  ```xml
  <PropertyGroup>
    <UseNativeLibPrefix>false</UseNativeLibPrefix>
  </PropertyGroup>
  ```

## Affected APIs

None.
