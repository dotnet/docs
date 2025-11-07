---
title: Threading config settings
description: Learn about the settings that configure threading for .NET apps.
ms.date: 11/04/2021
ai-usage: ai-assisted
---

# Runtime configuration options for threading

...

## Default stack size for new threads

- Specifies the stack size (in bytes) for new VM threads that are created with the default stack size.
- This setting allows configuration of the stack size for threads created by <xref:System.Threading.Thread> and other APIs that do not manually specify a stack size.
- If not set, the stack size is determined by the system or runtime default.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **Environment variable** | `DOTNET_Thread_DefaultStackSize` | An integer value (bytes). Example: `1048576` for 1 MB | .NET 9 |

### Examples

Set the stack size to 2 MB for all new threads:

#### On Windows, Linux, or macOS:

```shell
export DOTNET_Thread_DefaultStackSize=2097152
dotnet myapp.dll
```

#### In C# code (for reference, no runtimeconfig property):

```csharp
// Stack size is determined by the DOTNET_Thread_DefaultStackSize environment variable
var thread = new Thread(() => { /* thread logic */ }); 
thread.Start();
```

**Note:** This setting does not affect threads for which a non-default stack size is specified at creation.

...
