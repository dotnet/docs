---
title: "Breaking change: NamedPipeServerStream with PipeOptions.CurrentUserOnly tightens Unix socket file permissions"
description: "Learn about the breaking change in .NET 11 where NamedPipeServerStream with PipeOptions.CurrentUserOnly sets the Unix socket file mode to 0600."
ms.date: 05/04/2026
ai-usage: ai-assisted
---

# NamedPipeServerStream with PipeOptions.CurrentUserOnly tightens Unix socket file permissions

To better align on-disk permissions with the documented intent of <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> and with the Windows implementation, the underlying Unix domain socket file is now created with file permissions `0600` (read/write for the owning user only). Previously, the socket file inherited permissions from the process umask, and `CurrentUserOnly` only rejected cross-user connections at connect time without restricting who could open the socket file itself.

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, the socket file backing a <xref:System.IO.Pipes.NamedPipeServerStream> was created with whatever permissions the process umask allowed (commonly `0644` or `0755`). Specifying <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> didn't change the on-disk file mode. Other local users could `stat` and attempt to connect to the socket file. Cross-user connection attempts were rejected at connect time by peer-credential checks, but the socket file itself was world-visible and connectable at the operating system level.

```csharp
using var server = new NamedPipeServerStream(
    "mypipe", PipeDirection.InOut, 1,
    PipeTransmissionMode.Byte, PipeOptions.CurrentUserOnly);

// Mode reflected the process umask, for example UserRead | UserWrite | GroupRead | OtherRead.
UnixFileMode mode = File.GetUnixFileMode("/tmp/CoreFxPipe_mypipe");
```

## New behavior

Starting in .NET 11, when you specify <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType>, the socket file is `chmod`'d to `0600` immediately after `bind()`. Other local users (other than root) can no longer open or connect to the socket file at the operating system level.

```csharp
using var server = new NamedPipeServerStream(
    "mypipe", PipeDirection.InOut, 1,
    PipeTransmissionMode.Byte, PipeOptions.CurrentUserOnly);

// Always UserRead | UserWrite (0600).
UnixFileMode mode = File.GetUnixFileMode("/tmp/CoreFxPipe_mypipe");
```

For the in-process shared server cache, where multiple `NamedPipeServerStream` instances use the same pipe name, the permission change is one-way (ratcheted):

- If a `CurrentUserOnly` instance is created for a given pipe name, the socket file is tightened to `0600` at that point and stays `0600` for the remainder of that path's shared lifetime.
- A later instance for the same pipe name that doesn't specify `CurrentUserOnly` doesn't loosen the mode back.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

<xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> is documented as restricting access to the current user. On Unix, however, the socket file was created with permissions derived from the process umask, so enforcement relied solely on peer-credential checks at connect time. This left the socket file discoverable and connectable by other local users, and made Unix behavior inconsistent with the option's documented intent and with the Windows implementation. For more information, see [dotnet/runtime#127239](https://github.com/dotnet/runtime/pull/127239).

## Recommended action

Most callers benefit from the tighter permissions and require no action.

To allow the server to be reachable by local users other than the owner—for example, a helper process that runs under a different account or external tooling that probes the socket—stop passing <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> when other-user access is required.

Also be aware of the in-process ratcheting behavior: if any `NamedPipeServerStream` for a given pipe name in the process specifies `CurrentUserOnly`, all subsequent instances for that pipe name will see `0600` permissions on the socket file until the shared server entry is released.

## Affected APIs

- <xref:System.IO.Pipes.NamedPipeServerStream.%23ctor(System.String,System.IO.Pipes.PipeDirection,System.Int32,System.IO.Pipes.PipeTransmissionMode,System.IO.Pipes.PipeOptions)>
- <xref:System.IO.Pipes.NamedPipeServerStream.%23ctor(System.String,System.IO.Pipes.PipeDirection,System.Int32,System.IO.Pipes.PipeTransmissionMode,System.IO.Pipes.PipeOptions,System.Int32,System.Int32)>
- <xref:System.IO.Pipes.NamedPipeServerStream.%23ctor(System.String,System.IO.Pipes.PipeDirection,System.Int32,System.IO.Pipes.PipeTransmissionMode,System.IO.Pipes.PipeOptions,System.Int32,System.Int32,System.IO.Pipes.PipeSecurity)>
