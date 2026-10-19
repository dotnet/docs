---
title: "Breaking change: Named mutexes default to user scope on Unix"
description: "Learn about the breaking change in .NET 8, .NET 9, .NET 10, and .NET 11 where named mutexes on Unix default to user scope."
ms.date: 10/14/2026
ai-usage: ai-assisted
---

# Named mutexes default to user scope on Unix

Named mutexes on Unix now default to user scope instead of global scope. This change affects .NET 8.0.32, .NET 9.0.21, .NET 10.0.13, and .NET 11 RC 2.

## Version introduced

.NET 11 RC 2, .NET 10.0.13, .NET 9.0.21, and .NET 8.0.32

## Previous behavior

Previously, named mutexes on Unix were globally scoped by default, so processes run by different users could share them. User-scoped mutexes were available through <xref:System.Threading.Mutex> constructors that accept <xref:System.Threading.NamedWaitHandleOptions>, starting in .NET 10. Those mutexes were stored in a subdirectory of `/tmp/`.

## New behavior

Named mutexes on Unix now default to user scope. The runtime stores user-scoped mutex backing files in `$TMPDIR` when it points to a user-owned directory. Otherwise, it uses `$XDG_RUNTIME_DIR` on an XDG-compliant platform; if not, it uses `$HOME/.dotnet/`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To improve security, named mutexes now default to a scope and storage location that restrict access to the current user. The previous `/tmp/` backing files could allow another user on the system to interfere with a named mutex. For more information, see [dotnet/docs issue #56396](https://github.com/dotnet/docs/issues/56396).

## Recommended action

If your named mutexes do not need cross-user access and your application can access the user-only directory for its platform, no change is required.

If your named mutexes need cross-user access, use a <xref:System.Threading.Mutex> constructor that accepts <xref:System.Threading.NamedWaitHandleOptions> on .NET 10 or later and pass `NamedWaitHandleOptions.None` to opt into global scope. Alternatively, set the `System.Threading.Mutex.UnsafeDefaultMutexScopeGlobal` runtime configuration option to `true` in your `runtimeconfig.json`. This option applies on all affected platforms.

## Affected APIs

- <xref:System.Threading.Mutex.%23ctor(System.Boolean,System.String)>
- <xref:System.Threading.Mutex.%23ctor(System.Boolean,System.String,System.Boolean@)>
- <xref:System.Threading.Mutex.%23ctor(System.Boolean,System.String,System.Threading.NamedWaitHandleOptions)>
- <xref:System.Threading.Mutex.%23ctor(System.String,System.Threading.NamedWaitHandleOptions)>
- <xref:System.Threading.Mutex.%23ctor(System.Boolean,System.String,System.Threading.NamedWaitHandleOptions,System.Boolean@)>
