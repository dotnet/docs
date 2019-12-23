---
title: Unsupported APIs on .NET Core
description: Learn which APIs from the .NET Framework that always throw an exception on .NET Core.
ms.date: 12/23/2019
---
# APIs that always throw exceptions on .NET Core

The following APIs will always through an exception (usually a <xref:System.PlatformNotSupportedException>) when run on .NET Core. This article organizes the information by namespace.

## System.Console

| Member | Platform | Exception|
| - | - | - |
| <xref:System.Console.Beep?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.BufferHeight?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.BufferWidth?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.CursorSize?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.CursorVisible?displayProperty=nameWithType> (get only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.MoveBufferArea%2A?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.SetWindowPosition%2A?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.SetWindowSize%2A?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.Title?displayProperty=nameWithType> (get only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.WindowHeight?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.WindowLeft?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.WindowTop?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Console.WindowWidth?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |

## System.Diagnostics.Process

| Member | Platform | Exception|
| - | - | - |
| <xref:System.Diagnostics.Process.MaxWorkingSet?displayProperty=nameWithType> (set only) | Linux | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.Process.MinWorkingSet?displayProperty=nameWithType> (set only) | Linux | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.Process.MaxWorkingSet?displayProperty=nameWithType> | OSX | <xref:System.PlatformNotSupportedException> for other processes |
| <xref:System.Diagnostics.Process.ProcessorAffinity?displayProperty=nameWithType> | OSX | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.Process.MainWindowHandle?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessStartInfo.UserName?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessStartInfo.PasswordInClearText?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessStartInfo.Domain?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessStartInfo.LoadUserProfile?displayProperty=nameWithType> | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessThread.BasePriority?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessThread.BasePriority?displayProperty=nameWithType> (get only) | OSX | <xref:System.PlatformNotSupportedException> |
| <xref:System.Diagnostics.ProcessThread.ProcessorAffinity?displayProperty=nameWithType> (set only) | Unix | <xref:System.PlatformNotSupportedException> |

## System.IO.IsolatedStorage

| Member | Platform | Exception|
| - | - | - |
| <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A?displayProperty=nameWithType> (when specifying identity or evidence types) | All | <xref:System.PlatformNotSupportedException> |

## System.IO.Pipes

| Member | Platform | Exception|
| - | - | - |
| <xref:System.IO.Pipes.NamedPipeClientStream.NumberOfServerInstances?displayProperty=nameWithType> | non-Windows | <xref:System.PlatformNotSupportedException> |
| <xref:System.IO.Pipes.NamedPipeServerStream.GetImpersonationUserName?displayProperty=nameWithType> | non-Windows |  <xref:System.PlatformNotSupportedException> |
| <xref:System.IO.Pipes.PipeStream.InBufferSize?displayProperty=nameWithType> | non-Windows | <xref:System.PlatformNotSupportedException> |
| <xref:System.IO.Pipes.PipeStream.OutBufferSize?displayProperty=nameWithType> | non-Windows | <xref:System.PlatformNotSupportedException> |
| <xref:System.IO.Pipes.PipeStream.ReadMode?displayProperty=nameWithType> (set only) | non-Windows | <xref:System.PlatformNotSupportedException> |
| <xref:System.IO.Pipes.PipeStream.WaitForPipeDrain?displayProperty=nameWithType> | non-Windows | <xref:System.PlatformNotSupportedException> |

## System.Net.NetworkInformation

| Member | Platform | Exception|
| - | - | - |
| <xref:System.Net.NetworkInformation.Ping.Send%2A?displayProperty=nameWithType> | UWP | <xref:System.PlatformNotSupportedException> |

## System.Security.Cryptography

| Member | Platform | Exception|
| - | - | - |
| <xref:System.Security.Cryptography.HMAC.HashCore%2A?displayProperty=nameWithType> | All | <xref:System.PlatformNotSupportedException> |
| <xref:System.Security.Cryptography.HMAC.HashFinal%2A?displayProperty=nameWithType> | All | <xref:System.PlatformNotSupportedException> |
| <xref:System.Security.Cryptography.HMAC.HashName%2A?displayProperty=nameWithType> (except setting to current value) | All | <xref:System.PlatformNotSupportedException> |
| <xref:System.Security.Cryptography.HMAC.Initalize%2A?displayProperty=nameWithType> | All | <xref:System.PlatformNotSupportedException> |

## System.ServiceProcess.ServiceController

| Member | Platform | Exception|
| - | - | - |
| <xref:System.ServiceProcess.TimeoutException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All | <xref:System.PlatformNotSupportedException> |

## See also

- [Breaking changes for migration from .NET Framework to .NET Core](../compatibility/fx-core.md)
- [.NET portability analyzer](../../standard/analyzers/portability-analyzer.md)
