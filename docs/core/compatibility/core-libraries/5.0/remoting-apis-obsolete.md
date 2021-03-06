---
title: "Breaking change: Remoting APIs are obsolete"
description: Learn about the .NET 5 breaking change in core .NET libraries where some remoting-related APIs are marked as obsolete and generate a warning with a custom diagnostic ID.
ms.date: 11/01/2020
---
# Remoting APIs are obsolete

Some remoting-related APIs are marked as obsolete and generate a `SYSLIB0010` warning at compile time. These APIs may be removed in a future version of .NET.

## Change description

The following remoting APIs are marked obsolete.

| API | Marked obsolete in... |
| - | - |
| <xref:System.MarshalByRefObject.GetLifetimeService?displayProperty=nameWithType> | 5.0 RC1 |
| <xref:System.MarshalByRefObject.InitializeLifetimeService?displayProperty=nameWithType> | 5.0 RC1 |

In .NET Framework 2.x - 4.x, the <xref:System.MarshalByRefObject.GetLifetimeService> and <xref:System.MarshalByRefObject.InitializeLifetimeService> methods control the lifetime of instances involved with .NET remoting. In .NET Core 2.x- 3.x, these methods always throw a <xref:System.PlatformNotSupportedException> at run time.

In .NET 5 and later versions, the <xref:System.MarshalByRefObject.GetLifetimeService> and <xref:System.MarshalByRefObject.InitializeLifetimeService> methods are marked obsolete as warning, but continue to throw a <xref:System.PlatformNotSupportedException> at run time.

```csharp
// MemoryStream, like all Stream instances, subclasses MarshalByRefObject.
MemoryStream stream = new MemoryStream();
// Throws PlatformNotSupportedException; also produces warning SYSLIB0010.
obj.InitializeLifetimeService();
```

This is a compile-time only change. There is no run-time change from previous versions of .NET Core.

## Reason for change

[.NET remoting](/previous-versions/dotnet/netframework-1.1/kwdt6w2k(v=vs.71)) is a legacy technology. It allows instantiating an object in another process (potentially even on a different machine) and interacting with that object as if it were an ordinary, in-process .NET object instance. The .NET remoting infrastructure only exists in .NET Framework 2.x - 4.x. .NET Core and .NET 5 and later versions don't have support for .NET remoting, and the remoting APIs either don't exist or always throw exceptions on these runtimes.

To help steer developers away from these APIs, we are obsoleting selected remoting-related APIs. These APIs may be removed entirely in a future version of .NET.

## Version introduced

.NET 5.0

## Recommended action

- Consider using WCF or HTTP-based REST services to communicate with objects in other applications or across machines. For more information, see [.NET Framework technologies unavailable on .NET Core](../../../porting/net-framework-tech-unavailable.md).

- If you must continue to use the obsolete APIs, you can suppress the `SYSLIB0010` warning in code.

  ```csharp
  MarshalByRefObject obj = GetMarshalByRefObj();
  #pragma warning disable SYSLIB0010 // Disable the warning.
  obj.InitializeLifetimeService(); // Still throws PNSE.
  obj.GetLifetimeService(); // Still throws PNSE.
  #pragma warning restore SYSLIB0010 // Reenable the warning.
  ```

  You can also suppress the warning in your project file, which disables the warning for all source files in the project.

  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
     <TargetFramework>net5.0</TargetFramework>
     <!-- NoWarn below will suppress SYSLIB0010 project-wide -->
     <NoWarn>$(NoWarn);SYSLIB0010</NoWarn>
    </PropertyGroup>
  </Project>
  ```

  Suppressing `SYSLIB0010` disables only the remoting API obsoletion warnings. It does not disable any other warnings. Additionally, it doesn't change the hardcoded run-time behavior of always throwing <xref:System.PlatformNotSupportedException>.

## Affected APIs

- <xref:System.MarshalByRefObject.GetLifetimeService?displayProperty=fullName>
- <xref:System.MarshalByRefObject.InitializeLifetimeService?displayProperty=fullName>

<!--

#### Category

Core .NET libraries

### Affected APIs

- `M:System.MarshalByRefObject.GetLifetimeService`
- `M:System.MarshalByRefObject.InitializeLifetimeService`

-->
