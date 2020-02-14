---
title: Working with macOS Catalina Notarization
description: How to handle notarization and certificate problems with macOS when you install the .NET Core runtime, SDK, and apps built with .NET Core.
author: thraka
ms.author: adegeo
ms.date: 02/14/2020
---

# macOS Catalina Notarization and the impact on .NET Core downloads and projects

Beginning with macOS Catalina (version 10.15), all software built after June 1, 2019, and distributed with Developer ID, must be notarized. This requirement applies to the .NET Core runtime, .NET Core SDK, and software created with .NET Core. This article describes the common scenarios you may face with .NET Core and macOS notarization.

## Installing .NET Core

The installers for .NET Core (both runtime and SDK) versions 3.1, 3.0, and 2.1, have been notarized by Apple since February 19, 2020. Prior released versions, including the now end-of-life .NET Core 2.2, aren't notarized. If necessary, you can manually install these by first downloading the installer, and then using the `sudo installer` command. For more information, see [Download and manually install for macOS](sdk.md?pivots=os-macos#download-and-manually-install).

## appHost is disabled by default

Starting with .NET Core SDK 3.0, a native Mach-O executable (known as the appHost) is generated when your project is compiled or published. This is a convenient way to run your app. Otherwise, your app must be started by running `dotnet <filename.dll>`. The generated executable isn't notarized and macOS will display an error if you try to run it.

The [`UseAppHost`](project-sdk/msbuild-props.md#UseAppHost) boolean setting controls the generation of an appHost. The latest versions of the SDK default to `false` for this setting. You can set `UseAppHost` in the project file or on the command line:

- Project file

  ```xml
  <PropertyGroup>
    <UseAppHost>true</UseAppHost>
  </PropertyGroup>
  ```

- Command-line parameter

  ```dotnetcli
  dotnet publish -p:UseAppHost=true
  ```

An appHost is always created when you publish your app [self-contained](../deploying/index.md#publish-self-contained).

For more information about the `UseAppHost` setting, see [MSBuild properties for Microsoft.NET.Sdk](project-sdk/msbuild-props.md#UseAppHost).

## macOS Keychain Services and Certificates

.NET Core provides the ability to manage certificates in the macOS Keychain with the <xref:System.Security.Cryptography.X509Certificates> class. Access to the macOS Keychain uses the applications identity as the primary key when deciding which partition to consider. For example, unsigned applications store secrets in the unsigned partition, whereas signed applications store their secrets in partitions only they can access. The source of execution that invokes your app decides which partition to use.

.NET Core provides three sources of execution: [appHost](#apphost-disabled-by-default), default host (the `dotnet` command), and a custom host. Each execution model may have different identities, either signed or unsigned, and has access to different partitions within the Keychain. Certificates imported by one mode may not be accessible from another. For example, the notarized versions of .NET Core have a default host that is signed. Certificates are imported into a secure partition based on its identity. These certificates aren't accessible from a generated appHost, as the appHost is unsigned.

Another example, by default, ASP.NET Core imports a default SSL certificate through the default host. ASP.NET Core applications that use an appHost won't have access to this certificate and will receive an error when .NET Core detects the certificate isn't accessible. The error message provides instructions on how to fix this problem.

If certificate sharing is required, macOS provides configuration options with the `security` utility.

For more information on how to troubleshoot ASP.NET Core certificate issues, see [Enforce HTTPS in ASP.NET Core](/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio#troubleshoot-certificate-problems).

## Default entitlements

.NET Core’s default host (the `dotnet` command) has a set of default entitlements. These entitlements are required for proper operation of .NET Core. It's possible that your application may need additional entitlements, in which case you'll need to generate and use an [appHost](#apphost-disabled-by-default) and then add the necessary entitlements locally.
 
Default set of entitlements for .NET Core:

- `com.apple.security.cs.allow-jit`
- `com.apple.security.cs.allow-unsigned-executable-memory`
- `com.apple.security.cs.allow-dyld-environment-variables`
- `com.apple.security.cs.disable-library-validation`

## Notarize a .NET Core app

If you want your application to run on macOS Catalina (version 10.15) or higher, you'll want to notarize your app. The appHost you submit with your application for notarization should be used with at least the same [default entitlements](#default-entitlements) for .NET Core.

## Next steps

- [.NET Core dependencies and requirements](dependencies.md).
- [Install the .NET Core SDK](sdk.md).
- [Install the .NET Core Runtime](runtime.md)
