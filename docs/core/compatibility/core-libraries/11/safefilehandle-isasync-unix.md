---
title: "Breaking change: SafeFileHandle.IsAsync and FileStream.IsAsync accurately reflect non-blocking state on Unix"
description: "Learn about the breaking change in .NET 11 where SafeFileHandle.IsAsync and FileStream.IsAsync on Unix now accurately reflect whether the underlying file descriptor is in non-blocking mode."
ms.date: 04/07/2026
ai-usage: ai-assisted
---

# SafeFileHandle.IsAsync and FileStream.IsAsync accurately reflect non-blocking state on Unix

On Unix, <xref:Microsoft.Win32.SafeHandles.SafeFileHandle.IsAsync?displayProperty=nameWithType> and <xref:System.IO.FileStream.IsAsync?displayProperty=nameWithType> now accurately reflect whether the underlying file descriptor has the `O_NONBLOCK` flag set. Previously, `IsAsync` unconditionally returned `true` for regular files opened with <xref:System.IO.FileOptions.Asynchronous?displayProperty=nameWithType>, even though regular file I/O on Unix is inherently synchronous at the kernel level.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, `SafeFileHandle.IsAsync` always returned `true` on Unix for regular files opened with `FileOptions.Asynchronous`, regardless of whether the underlying file descriptor had the `O_NONBLOCK` flag set.

```csharp
using Microsoft.Win32.SafeHandles;

// On Unix, IsAsync was true for regular files opened with FileOptions.Asynchronous,
// even though the file descriptor had no O_NONBLOCK set.
using SafeFileHandle handle = File.OpenHandle("myfile.txt", options: FileOptions.Asynchronous);
Console.WriteLine(handle.IsAsync); // true (misleading; no O_NONBLOCK on regular file)
```

Conversely, for file descriptors that were genuinely non-blocking (for example, pipes or sockets with `O_NONBLOCK` set), `IsAsync` incorrectly returned `false`.

On non-Windows platforms, constructing a `SendPacketsElement` with a non-async `FileStream` threw an `ArgumentException`.

## New behavior

Starting in .NET 11, `SafeFileHandle.IsAsync` on Unix returns `true` only when the underlying file descriptor has the `O_NONBLOCK` flag set, which is possible for pipes and sockets. For regular files, it returns `false`.

```csharp
using Microsoft.Win32.SafeHandles;

// On Unix, IsAsync now reflects the actual non-blocking state of the file descriptor.
SafeFileHandle.CreateAnonymousPipe(
    out SafeFileHandle readHandle,
    out SafeFileHandle writeHandle,
    asyncRead: true,
    asyncWrite: false);

Console.WriteLine(readHandle.IsAsync);  // true  (O_NONBLOCK set on read end)
Console.WriteLine(writeHandle.IsAsync); // false (blocking write end)
```

For regular files opened with `FileOptions.Asynchronous`, `IsAsync` correctly returns `false` on Unix because regular file I/O is inherently synchronous at the kernel level.

`FileStream.IsAsync` reflects the updated value of the underlying `SafeFileHandle.IsAsync`.

Additionally, on non-Windows platforms, constructing a `SendPacketsElement` with a `FileStream` no longer throws `ArgumentException` regardless of whether the stream is async.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was incorrect and misleading. `SafeFileHandle.IsAsync` reported `true` on Unix for regular files that aren't truly non-blocking, and `false` for file descriptors (such as pipes or sockets) that genuinely had `O_NONBLOCK` set. This caused APIs and user code that relied on this property to make incorrect decisions. Accurate `IsAsync` reporting was also a prerequisite for the new `SafeFileHandle.CreateAnonymousPipe` API to correctly expose per-end async semantics on Unix. For more information, see [dotnet/runtime#125220](https://github.com/dotnet/runtime/pull/125220).

## Recommended action

Review any code that checks `SafeFileHandle.IsAsync` or `FileStream.IsAsync` on Unix and takes action based on the result:

- If your code assumed `IsAsync` was always `true` on Unix for files opened with `FileOptions.Asynchronous`, update it to account for the fact that regular file handles now return `false`.

- If you wrap a non-blocking `SafeFileHandle` in a `FileStream` (for example, one created via `SafeFileHandle.CreateAnonymousPipe` with `asyncRead: true` or `asyncWrite: true`), `FileStream.IsAsync` might now return `true` where it previously returned `false`. Adjust downstream code accordingly.

- If you construct `SendPacketsElement` with a `FileStream` on a non-Windows platform and previously expected an `ArgumentException` to be thrown for non-async streams, note that the exception is no longer thrown. Guard any such expectation with `OperatingSystem.IsWindows()`.

## Affected APIs

- <xref:Microsoft.Win32.SafeHandles.SafeFileHandle.IsAsync?displayProperty=fullName>
- <xref:System.IO.FileStream.IsAsync?displayProperty=fullName>
- <xref:System.Net.Sockets.SendPacketsElement.%23ctor(System.IO.FileStream,System.Int64,System.Int32)?displayProperty=fullName>
- <xref:System.Net.Sockets.SendPacketsElement.%23ctor(System.IO.FileStream,System.Int64,System.Int32,System.Boolean)?displayProperty=fullName>
