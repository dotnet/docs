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

Previously, the socket file backing a <xref:System.IO.Pipes.NamedPipeServerStream> was created with whatever permissions the process umask allowed (commonly `0644` or `0755`). Specifying <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> didn't change the on-disk file mode. Other local users could `stat` and might be able to attempt a connection to the socket file, depending on the platform and effective permissions. Cross-user connection attempts were rejected at connect time by peer-credential checks, but the socket file itself could still be visible to other users and, on some Unix systems, might also be connectable at the operating system level.

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

<xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> is documented as restricting access to the current user. On Unix, however, the socket file was created with permissions derived from the process umask, so enforcement relied on peer-credential checks at connect time. This left the socket file discoverable by other local users, and on platforms that honor socket-node permission bits for `connect()`, it might also allow other users to attempt or make a connection before peer-credential checks rejected cross-user access. That behavior made Unix behavior inconsistent with the option's documented intent and with the Windows implementation. For more information, see [dotnet/runtime#127239](https://github.com/dotnet/runtime/pull/127239).

## Recommended action

Most callers benefit from the tighter permissions and require no action.

On Linux and macOS, <xref:System.IO.Pipes.NamedPipeServerStream> uses Unix domain sockets. If you rely on that socket file being visible or connectable to local users other than the owner, update your guidance and your app assumptions to reflect that <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> now sets the socket file mode to `0600` at bind time.

Removing <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType> doesn't guarantee cross-user access by itself. When you omit that option, the socket file still inherits permissions from the process umask, and other users also need enough access to the directory that contains the socket path. If you intend to allow cross-user access, verify the effective socket file mode and the directory permissions on the target system.

To let the server accept connections from other local users—for example, from a helper process that runs under a different account, or from external tooling that probes the socket—stop passing <xref:System.IO.Pipes.PipeOptions.CurrentUserOnly?displayProperty=nameWithType>.

Also account for the in-process ratcheting behavior. If any `NamedPipeServerStream` instance for a given pipe name in the process specifies `CurrentUserOnly`, all later instances for that pipe name keep `0600` permissions on the socket file until the shared server entry is released.

## Affected APIs

- <xref:System.IO.Pipes.NamedPipeServerStream.%23ctor(System.String,System.IO.Pipes.PipeDirection,System.Int32,System.IO.Pipes.PipeTransmissionMode,System.IO.Pipes.PipeOptions)>
- <xref:System.IO.Pipes.NamedPipeServerStream.%23ctor(System.String,System.IO.Pipes.PipeDirection,System.Int32,System.IO.Pipes.PipeTransmissionMode,System.IO.Pipes.PipeOptions,System.Int32,System.Int32)>
- <xref:System.IO.Pipes.NamedPipeServerStream.%23ctor(System.String,System.IO.Pipes.PipeDirection,System.Int32,System.IO.Pipes.PipeTransmissionMode,System.IO.Pipes.PipeOptions,System.Int32,System.Int32,System.IO.Pipes.PipeSecurity)>
