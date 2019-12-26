---
title: Unsupported APIs on .NET Core
description: Learn which APIs from the .NET Framework that always throw an exception on .NET Core.
ms.date: 12/23/2019
---
# APIs that always throw exceptions on .NET Core

The following APIs will always through a <xref:System.PlatformNotSupportedException> when run on .NET Core.

This article organizes the affected API members by namespace.

> [!NOTE]
> This article is a work-in-progress. It is not a complete list of APIs that throw exceptions on .NET Core.

## System.Console

| Member | Platform |
| - | - |
| <xref:System.Console.Beep?displayProperty=nameWithType> | Unix |
| <xref:System.Console.BufferHeight?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Console.BufferWidth?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Console.CursorSize?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Console.CursorVisible?displayProperty=nameWithType> (get only) | Unix |
| <xref:System.Console.MoveBufferArea%2A?displayProperty=nameWithType> | Unix |
| <xref:System.Console.SetWindowPosition%2A?displayProperty=nameWithType> | Unix |
| <xref:System.Console.SetWindowSize%2A?displayProperty=nameWithType> | Unix |
| <xref:System.Console.Title?displayProperty=nameWithType> (get only) | Unix |
| <xref:System.Console.WindowHeight?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Console.WindowLeft?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Console.WindowTop?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Console.WindowWidth?displayProperty=nameWithType> (set only) | Unix |

## System.Data.Common

| <xref:System.Data.Common.DbDataReader.GetSchemaTable%2A?displayProperty=nameWithType> | All (throws a <xref:System.NotSupportedException>) |

## System.Diagnostics.Process

| Member | Platform |
| - | - |
| <xref:System.Diagnostics.Process.MaxWorkingSet?displayProperty=nameWithType> (set only) | Linux |
| <xref:System.Diagnostics.Process.MinWorkingSet?displayProperty=nameWithType> (set only) | Linux |
| <xref:System.Diagnostics.Process.MaxWorkingSet?displayProperty=nameWithType> (for other processes) | OSX |
| <xref:System.Diagnostics.Process.ProcessorAffinity?displayProperty=nameWithType> | OSX |
| <xref:System.Diagnostics.Process.MainWindowHandle?displayProperty=nameWithType> | Unix |
| <xref:System.Diagnostics.ProcessStartInfo.UserName?displayProperty=nameWithType> | Unix |
| <xref:System.Diagnostics.ProcessStartInfo.PasswordInClearText?displayProperty=nameWithType> | Unix |
| <xref:System.Diagnostics.ProcessStartInfo.Domain?displayProperty=nameWithType> | Unix |
| <xref:System.Diagnostics.ProcessStartInfo.LoadUserProfile?displayProperty=nameWithType> | Unix |
| <xref:System.Diagnostics.ProcessThread.BasePriority?displayProperty=nameWithType> (set only) | Unix |
| <xref:System.Diagnostics.ProcessThread.BasePriority?displayProperty=nameWithType> (get only) | OSX |
| <xref:System.Diagnostics.ProcessThread.ProcessorAffinity?displayProperty=nameWithType> (set only) | Unix |

## System.IO.IsolatedStorage

| Member | Platform |
| - | - |
| <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A?displayProperty=nameWithType> (when specifying identity or evidence types) | All |

## System.IO.MemoryMappedFiles

| Member | Platform |
| - | - |
| <xref:System.IO.MemoryMappedFiles.MemoryMappedFile.CreateNew(System.String,System.Int64)?displayProperty=nameWithType> (when passed a named, memory-mapped file) | non-Windows |

## System.IO.Pipes

| Member | Platform |
| - | - |
| <xref:System.IO.Pipes.NamedPipeClientStream.NumberOfServerInstances?displayProperty=nameWithType> | non-Windows |
| <xref:System.IO.Pipes.NamedPipeServerStream.GetImpersonationUserName?displayProperty=nameWithType> | non-Windows |  <xref:System.PlatformNotSupportedException> |
| <xref:System.IO.Pipes.PipeStream.InBufferSize?displayProperty=nameWithType> | non-Windows |
| <xref:System.IO.Pipes.PipeStream.OutBufferSize?displayProperty=nameWithType> | non-Windows |
| <xref:System.IO.Pipes.PipeStream.ReadMode?displayProperty=nameWithType> (set only) | non-Windows |
| <xref:System.IO.Pipes.PipeStream.WaitForPipeDrain?displayProperty=nameWithType> | non-Windows |

## System.Net.NetworkInformation

| Member | Platform |
| - | - |
| <xref:System.Net.NetworkInformation.Ping.Send%2A?displayProperty=nameWithType> | UWP |

## System.Security.Cryptography

| Member | Platform |
| - | - |
| <xref:System.Security.Cryptography.AsymmetricAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.CspKeyContainerInfo?displayProperty=nameWithType> | non-Windows |
| <xref:System.Security.Cryptography.HashAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.HashCore%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.HashFinal%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.HashName%2A?displayProperty=nameWithType><br/>(except when setting to current value) | All |
| <xref:System.Security.Cryptography.HMAC.Initialize%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.KeyedHashAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.Pkcs.CmsSigner.%23ctor(System.Security.Cryptography.CspParameters)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.Pkcs.SignedCms.ComputeSignature(System.Security.Cryptography.Pkcs.CmsSigner,System.Boolean)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.ProtectedData.Protect%2A?displayProperty=nameWithType> | non-Windows |
| <xref:System.Security.Cryptography.ProtectedData.Unprotect%2A?displayProperty=nameWithType> | non-Windows |
| <xref:System.Security.Cryptography.RSA.FromXmlString%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.RSA.ToXmlString%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.SymmetricAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate.Import%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.PrivateKey?displayProperty=nameWithType> (set only) | All |

## System.ServiceProcess.ServiceController

| Member | Platform |
| - | - |
| <xref:System.ServiceProcess.TimeoutException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |


## See also

- [Breaking changes for migration from .NET Framework to .NET Core](../compatibility/fx-core.md)
- [.NET portability analyzer](../../standard/analyzers/portability-analyzer.md)
