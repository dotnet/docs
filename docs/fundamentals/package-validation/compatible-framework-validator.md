---
title: Validating Different Runtimes
description: Learn about validating the run-time and compile-time assemblies applicable for supported target frameworks and runtimes.
ms.date: 09/29/2021
---

# Validate packages against different runtimes

You may choose to have different implementation assemblies for different runtimes in your NuGet package. In that case, you'll need to make sure that these assemblies are compatible with each other and with the compile-time assemblies.

For example, consider the following scenario. You're working on a library involving some interop calls to Unix and Windows APIs, respectively. You have written the following code:

```csharp
#if Unix
    public static void Open(string path, bool securityDescriptor)
    {
        // call unix specific stuff
    }
#else
    public static void Open(string path)
    {
        // call windows specific stuff
    }
#endif
```

The resulting package structure looks as follows.

```xml
lib/net6.0/A.dll
runtimes/unix/lib/net6.0/A.dll
```

`lib\net6.0\A.dll` will always be used at compile time, regardless of the underlying operating system. `lib\net6.0\A.dll` will also be used at run time for non-Unix systems. However, `runtimes\unix\lib\net6.0\A.dll` will be used at run time for Unix systems.

When you try to pack this project, you'll get the following error:

```cmd
D:\demo>dotnet pack
Microsoft (R) Build Engine version 17.0.0-preview-21460-01+8f208e609 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  All projects are up-to-date for restore.
  You are using a preview version of .NET. See: https://aka.ms/dotnet-core-preview
  PackageValidationThrough -> D:\demo\bin\Debug\net6.0\PackageValidationThrough.dll
  Successfully created package 'D:\demo\bin\Debug\PackageValidationThrough.1.0.0.nupkg'.
C:\Program Files\dotnet\sdk\6.0.100-rc.1.21463.6\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Compatibility.Common.targets(32,5): error CP0002: Member 'A.B.Open(string)' exists on lib/net6.0/PackageValidationThrough.dll but not on runtimes/unix/lib/net6.0/PackageValidationThrough.dll [D:\demo\PackageValidationThrough.csproj]
C:\Program Files\dotnet\sdk\6.0.100-rc.1.21463.6\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Compatibility.Common.targets(32,5): error CP0002: Member 'A.B.Open(string, bool)' exists on runtimes/unix/lib/net6.0/PackageValidationThrough.dll but not on lib/net6.0/PackageValidationThrough.dll [D:\demo\PackageValidationThrough.csproj]
```

![MultipleRuntimes](media/multiple-runtimes.png)

You realize your mistake and add `A.B.Open(string)` to the Unix runtime as well.

```csharp
#if Unix
    public static void Open(string path, bool securityDescriptor)
    {
        // call unix specific stuff
    }

    public static void Open(string path)
    {
        throw new PlatformNotSupportedException();
    }
#else
    public static void Open(string path)
    {
        // call windows specific stuff
    }

    public static void Open(string path, bool securityDescriptor)
    {
        throw new PlatformNotSupportedException();
    }
#endif
```

You try to pack the project again, and it succeeds.

![MultipleRuntimesSuccessful](media/multiple-runtimes-successful.png)

You can enable *strict mode* for this validator by setting the `EnableStrictModeForCompatibleTfms` property in your project file. Enabling strict mode changes some rules, and some other rules will be executed when getting the differences. This is useful when you want both sides we are comparing to be strictly the same on their surface area and identity.
