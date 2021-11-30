---
title: Unsupported APIs on .NET Core and .NET 5+
titleSuffix: ""
description: Learn which .NET APIs always throw an exception on .NET Core and .NET 5 and later versions.
ms.date: 11/23/2021
---
# APIs that always throw exceptions on .NET Core and .NET 5+

The following APIs will always throw an exception on .NET 5 and later versions (including all versions of .NET Core) on all or a subset of platforms. In most cases, the exception that's thrown is <xref:System.PlatformNotSupportedException>.

This article organizes the affected APIs by namespace.

> [!NOTE]
>
> - This article is a work-in-progress. It is not a complete list of APIs that throw exceptions on .NET 5+.
> - This article does not include the explicit interface implementations for binary serialization that throw on .NET 5+. For more information, see [Binary serialization in .NET Core](../../standard/serialization/binary-serialization.md#net-core).

## System

| Member | Platforms that throw |
| - | - |
| <xref:System.AppDomain.CreateDomain%2A?displayProperty=nameWithType> | All |
| <xref:System.AppDomain.ExecuteAssembly(System.String,System.String[],System.Byte[],System.Configuration.Assemblies.AssemblyHashAlgorithm)?displayProperty=nameWithType> | All |
| <xref:System.AppDomain.Unload(System.AppDomain)?displayProperty=nameWithType> | All |
| <xref:System.Console.CapsLock?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Console.NumberLock?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Delegate.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Exception.SerializeObjectState?displayProperty=nameWithType> | All |
| <xref:System.MarshalByRefObject.GetLifetimeService?displayProperty=nameWithType> | All |
| <xref:System.MarshalByRefObject.InitializeLifetimeService?displayProperty=nameWithType> | All |
| <xref:System.OperatingSystem.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Type.ReflectionOnlyGetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType> | All |

## System.CodeDom.Compiler

| Member | Platforms that throw |
| - | - |
| <xref:System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromDom%2A?displayProperty=nameWithType> | All |
| <xref:System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromFile%2A?displayProperty=nameWithType> | All |
| <xref:System.CodeDom.Compiler.CodeDomProvider.CompileAssemblyFromSource%2A?displayProperty=nameWithType> | All |

## System.Collections.Specialized

| Member | Platforms that throw |
| - | - |
| <xref:System.Collections.Specialized.NameObjectCollectionBase.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Collections.Specialized.NameObjectCollectionBase.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Collections.Specialized.NameObjectCollectionBase.OnDeserialization(System.Object)?displayProperty=nameWithType> | All |

## System.Configuration

| Member | Platforms that throw |
| - | - |
| <xref:System.Configuration.RsaProtectedConfigurationProvider?displayProperty=nameWithType> (all members) | All |

## System.Console

| Member | Platforms that throw |
| - | - |
| <xref:System.Console.Beep?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Console.BufferHeight?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Console.BufferWidth?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Console.CursorSize?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Console.CursorVisible?displayProperty=nameWithType> (get only) | Linux and macOS |
| <xref:System.Console.MoveBufferArea%2A?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Console.SetWindowPosition%2A?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Console.SetWindowSize%2A?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Console.Title?displayProperty=nameWithType> (get only) | Linux and macOS |
| <xref:System.Console.WindowHeight?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Console.WindowLeft?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Console.WindowTop?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Console.WindowWidth?displayProperty=nameWithType> (set only) | Linux and macOS |

## System.Data.Common

| Member | Platforms that throw |
| - | - |
| <xref:System.Data.Common.DbDataReader.GetSchemaTable%2A?displayProperty=nameWithType> (throws <xref:System.NotSupportedException>) | All |

## System.Diagnostics.Process

| Member | Platforms that throw |
| - | - |
| <xref:System.Diagnostics.Process.MaxWorkingSet?displayProperty=nameWithType> (set only) | Linux |
| <xref:System.Diagnostics.Process.MinWorkingSet?displayProperty=nameWithType> (set only) | Linux |
| <xref:System.Diagnostics.Process.ProcessorAffinity?displayProperty=nameWithType> | macOS |
| <xref:System.Diagnostics.Process.MainWindowHandle?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.Process.Start(System.String,System.String,System.String,System.Security.SecureString,System.String)?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.Process.Start(System.String,System.String,System.Security.SecureString,System.String)?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.ProcessStartInfo.UserName?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.ProcessStartInfo.PasswordInClearText?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.ProcessStartInfo.Domain?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.ProcessStartInfo.LoadUserProfile?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Diagnostics.ProcessThread.BasePriority?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.Diagnostics.ProcessThread.BasePriority?displayProperty=nameWithType> (get only) | macOS |
| <xref:System.Diagnostics.ProcessThread.ProcessorAffinity?displayProperty=nameWithType> (set only) | Linux and macOS |

## System.IO

| Member | Platforms that throw |
| - | - |
| <xref:System.IO.FileSystemInfo.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.IO.FileSystemInfo.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |

## System.IO.Pipes

| Member | Platforms that throw |
| - | - |
| <xref:System.IO.Pipes.NamedPipeClientStream.NumberOfServerInstances?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.IO.Pipes.NamedPipeServerStream.GetImpersonationUserName?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.IO.Pipes.PipeStream.InBufferSize?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.IO.Pipes.PipeStream.OutBufferSize?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.IO.Pipes.PipeStream.ReadMode?displayProperty=nameWithType> (set only) | Linux and macOS |
| <xref:System.IO.Pipes.PipeStream.WaitForPipeDrain?displayProperty=nameWithType> | Linux and macOS |

## System.Media

| Member | Platforms that throw |
| - | - |
| <xref:System.Media.SoundPlayer.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |

## System.Net

| Member | Platforms that throw |
| - | - |
| <xref:System.Net.AuthenticationManager.Authenticate(System.String,System.Net.WebRequest,System.Net.ICredentials)?displayProperty=nameWithType> | All |
| <xref:System.Net.AuthenticationManager.PreAuthenticate(System.Net.WebRequest,System.Net.ICredentials)?displayProperty=nameWithType> | All |
| <xref:System.Net.FileWebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.FileWebRequest.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Net.FileWebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.FileWebResponse.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Net.HttpWebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.HttpWebRequest.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Net.HttpWebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.HttpWebResponse.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Net.WebProxy.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.WebProxy.GetDefaultProxy?displayProperty=nameWithType> | All |
| <xref:System.Net.WebProxy.GetObjectData%2A?displayProperty=nameWithType> | All |
| <xref:System.Net.WebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.WebRequest.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Net.WebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Net.WebResponse.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |

## System.Net.NetworkInformation

| Member | Platforms that throw |
| - | - |
| <xref:System.Net.NetworkInformation.Ping.Send%2A?displayProperty=nameWithType> | Windows (UWP) |

## System.Net.Sockets

| Member | Platforms that throw |
| - | - |
| <xref:System.Net.Sockets.Socket.%23ctor(System.Net.Sockets.SocketInformation)> | All |
| <xref:System.Net.Sockets.Socket.DuplicateAndClose(System.Int32)?displayProperty=nameWithType> | All |

## System.Net.WebSockets

| Member | Platforms that throw |
| - | - |
| <xref:System.Net.WebSockets.WebSocket.RegisterPrefixes?displayProperty=nameWithType> | All |

## System.Reflection

| Member | Platforms that throw |
| - | - |
| <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType> | All |
| <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType> | All |
| <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A?displayProperty=nameWithType> | All |
| <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Reflection.AssemblyName.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=fullName> | All |
| <xref:System.Reflection.AssemblyName.OnDeserialization(System.Object)?displayProperty=nameWithType> | All |
| <xref:System.Reflection.StrongNameKeyPair.%23ctor%2A> | All |
| <xref:System.Reflection.StrongNameKeyPair.PublicKey?displayProperty=nameWithType> | All |

## System.Runtime.CompilerServices

| Member | Platforms that throw |
| - | - |
| <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator?displayProperty=nameWithType> | All |

## System.Runtime.InteropServices

| Member | Platforms that throw |
| - | - |
| <xref:System.Runtime.InteropServices.Marshal.GetIDispatchForObject(System.Object)?displayProperty=nameWithType> | All |
| <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile?displayProperty=nameWithType> | All |
| <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)?displayProperty=nameWithType> | All |
| <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)?displayProperty=nameWithType> | All |
| <xref:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal.StringToHString(System.String)?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal.PtrToStringHString(System.IntPtr)?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal.FreeHString(System.IntPtr)?displayProperty=nameWithType> | Linux and macOS |

## System.Runtime.Serialization

| Member | Platforms that throw |
| - | - |
| <xref:System.Runtime.Serialization.XsdDataContractExporter.Schemas?displayProperty=nameWithType> | All |

## System.Security

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.CodeAccessPermission.Deny?displayProperty=nameWithType> | All |
| <xref:System.Security.CodeAccessPermission.PermitOnly?displayProperty=nameWithType> | All |
| <xref:System.Security.PermissionSet.ConvertPermissionSet(System.String,System.Byte[],System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.PermissionSet.Deny?displayProperty=nameWithType> | All |
| <xref:System.Security.PermissionSet.PermitOnly?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.Capture?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.CreateCopy?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.Dispose?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.IsFlowSuppressed?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.IsWindowsIdentityFlowSuppressed?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.RestoreFlow?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.Run(System.Security.SecurityContext,System.Threading.ContextCallback,System.Object)?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.SuppressFlow?displayProperty=nameWithType> | All |
| <xref:System.Security.SecurityContext.SuppressFlowWindowsIdentity?displayProperty=nameWithType> | All |

## System.Security.Claims

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.Claims.ClaimsPrincipal.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Security.Claims.ClaimsPrincipal.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Security.Claims.ClaimsIdentity.%23ctor(System.Runtime.Serialization.SerializationInfo)> | All |
| <xref:System.Security.Claims.ClaimsIdentity.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Security.Claims.ClaimsIdentity.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |

## System.Security.Cryptography

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.Cryptography.AsymmetricAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.CngAlgorithm?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CngAlgorithmGroup?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CngKey?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CngKeyBlobFormat?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CngKeyCreationParameters?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CngProvider?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CngUIPolicy?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CryptoConfig.EncodeOID(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.%23ctor%2A> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.Accessible?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.Exportable?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.HardwareDevice?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.KeyContainerName?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.KeyNumber?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.MachineKeyStore?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.Protected?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.ProviderName?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.ProviderType?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.RandomlyGenerated?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.Removable?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.CspKeyContainerInfo.UniqueKeyContainerName?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.HashAlgorithm.Create?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.Create?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.HashCore%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.HashFinal%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.HMAC.Initialize%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.KeyedHashAlgorithm.Create?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.KeyedHashAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.ProtectedData.Protect%2A?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.ProtectedData.Unprotect%2A?displayProperty=nameWithType> | Linux and macOS |
| <xref:System.Security.Cryptography.RSA.FromXmlString%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.RSA.ToXmlString%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.SymmetricAlgorithm.Create?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.SymmetricAlgorithm.Create(System.String)?displayProperty=nameWithType> | All |

## System.Security.Cryptography.Pkcs

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.Cryptography.Pkcs.CmsSigner.%23ctor(System.Security.Cryptography.CspParameters)> | All |
| <xref:System.Security.Cryptography.Pkcs.SignerInfo.ComputeCounterSignature?displayProperty=nameWithType> | All |

## System.Security.Cryptography.X509Certificates

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate.Import%2A?displayProperty=nameWithType> | All |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |
| <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.PrivateKey?displayProperty=nameWithType> (set only) | All |

## System.Security.Authentication.ExtendedProtection

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |

## System.Security.Policy

| Member | Platforms that throw |
| - | - |
| <xref:System.Security.Policy.Hash.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |

## System.ServiceProcess.ServiceController

| Member | Platforms that throw |
| - | - |
| <xref:System.ServiceProcess.TimeoutException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> | All |

## System.Text.RegularExpressions

| Member | Platforms that throw |
| - | - |
| <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> | All |

## System.Threading

| Member | Platforms that throw |
| - | - |
| <xref:System.Threading.CompressedStack.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Threading.ExecutionContext.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> | All |
| <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> | All |
| <xref:System.Threading.Thread.ResetAbort?displayProperty=nameWithType> | All |
| <xref:System.Threading.Thread.Resume?displayProperty=nameWithType> | All |
| <xref:System.Threading.Thread.Suspend?displayProperty=nameWithType> | All |

## System.Xml

| Member | Platforms that throw |
| - | - |
| <xref:System.Xml.XmlDictionaryReader.CreateMtomReader(System.Byte[],System.Int32,System.Int32,System.Text.Encoding[],System.String,System.Xml.XmlDictionaryReaderQuotas,System.Int32,System.Xml.OnXmlDictionaryReaderClose)?displayProperty=nameWithType> | All |
| <xref:System.Xml.XmlDictionaryReader.CreateMtomReader(System.IO.Stream,System.Text.Encoding[],System.String,System.Xml.XmlDictionaryReaderQuotas,System.Int32,System.Xml.OnXmlDictionaryReaderClose)?displayProperty=nameWithType> | All |
| <xref:System.Xml.XmlDictionaryWriter.CreateMtomWriter(System.IO.Stream,System.Text.Encoding,System.Int32,System.String,System.String,System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType> | All |

## See also

- [Breaking changes for migration from .NET Framework to .NET Core](fx-core.md)
- [Binary serialization in .NET Core](../../standard/serialization/binary-serialization.md#net-core)
- [.NET portability analyzer](../../standard/analyzers/portability-analyzer.md)
