---
title: Working with macOS Catalina Notarization
description: How to handle notarization and certificate problems with macOS when you install the .NET runtime, SDK, and apps built with .NET.
author: adegeo
ms.author: adegeo
ms.date: 11/04/2021
---

# macOS Catalina Notarization and the impact on .NET downloads and projects

Beginning with macOS Catalina (version 10.15), all software built after June 1, 2019, and distributed with Developer ID, must be notarized. This requirement applies to the .NET runtime, .NET SDK, and software created with .NET. This article describes the common scenarios you may face with .NET and macOS notarization.

## Installing .NET

The installers for .NET (both runtime and SDK) have been notarized since February 18, 2020. Prior released versions aren't notarized. You can manually install a non-notarized version of .NET by first downloading the installer, and then using the `sudo installer` command. For more information, see [Download and manually install for macOS](./macos.md#download-and-manually-install).

## appHost is disabled by default

.NET doesn't produce an **appHost** version of your app, a native Mach-O executable. The executable is usually invoked by .NET when your project compiles, publishes, or is run with the `dotnet run` command. The non-**appHost** version of your app is a _dll_ file invoked by .NET directly. You can turn on **appHost** generation with the [`UseAppHost`](../project-sdk/msbuild-props.md#useapphost) boolean setting in the project file. You can also toggle the appHost with the `-p:UseAppHost` parameter on the command line for the specific `dotnet` command you run:

- Project file

  ```xml
  <PropertyGroup>
    <UseAppHost>true</UseAppHost>
  </PropertyGroup>
  ```

- Command-line parameter

  ```dotnetcli
  dotnet run -p:UseAppHost=true
  ```

An **appHost** is always created when you publish your app [self-contained](../deploying/index.md#publish-self-contained). You would notarize this version of your app prior to distribution.

For more information about the `UseAppHost` setting, see [MSBuild properties for Microsoft.NET.Sdk](../project-sdk/msbuild-props.md#useapphost).

### Context of the appHost

When the appHost is enabled in your project, and you use the `dotnet run` command to run your app, the app is invoked in the context of the appHost and not the default host (the default host is the `dotnet` command). If the appHost is disabled in your project, the `dotnet run` command runs your app in the context of the default host. Even if the appHost is disabled, publishing your app as self-contained generates an appHost executable, and users use that executable to run your app. Running your app with `dotnet <filename.dll>` invokes the app with the default host, the shared runtime.

When an app using the appHost is invoked, the certificate partition accessed by the app is different from the notarized default host. If your app must access the certificates installed through the default host, use the `dotnet run` command to run your app from its project file, or use the `dotnet <filename.dll>` command to start the app directly.

More information about this scenario is provided in the [ASP.NET Core and macOS and certificates](#aspnet-core-macos-and-certificates) section.

## ASP.NET Core, macOS, and certificates

.NET provides the ability to manage certificates in the macOS Keychain with the <xref:System.Security.Cryptography.X509Certificates> class. Access to the macOS Keychain uses the applications identity as the primary key when deciding which partition to consider. For example, unsigned applications store secrets in the unsigned partition, but signed applications store their secrets in partitions only they can access. The source of execution that invokes your app decides which partition to use.

.NET provides three sources of execution: [appHost](#apphost-is-disabled-by-default), default host (the `dotnet` command), and a custom host. Each execution model may have different identities, either signed or unsigned, and has access to different partitions within the Keychain. Certificates imported by one mode may not be accessible from another. For example, the notarized versions of .NET have a default host that is signed. Certificates are imported into a secure partition based on its identity. These certificates aren't accessible from a generated appHost, as the appHost is unsigned.

Another example, by default, ASP.NET Core imports a default SSL certificate through the default host. ASP.NET Core applications that use an appHost won't have access to this certificate and will receive an error when .NET detects the certificate isn't accessible. The error message provides instructions on how to fix this problem.

If certificate sharing is required, macOS provides configuration options with the `security` utility.

For more information on how to troubleshoot ASP.NET Core certificate issues, see [Enforce HTTPS in ASP.NET Core](/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio#troubleshoot-certificate-problems&preserve-view=false).

## Default entitlements

.NET's default host (the `dotnet` command) has a set of default entitlements. These entitlements are required for proper operation of .NET. It's possible that your application may need additional entitlements, in which case you'll need to generate and use an [appHost](#apphost-is-disabled-by-default) and then add the necessary entitlements locally.

Default set of entitlements for .NET:

- `com.apple.security.cs.allow-jit`
- `com.apple.security.cs.allow-unsigned-executable-memory`
- `com.apple.security.cs.allow-dyld-environment-variables`
- `com.apple.security.cs.disable-library-validation`

## Notarize a .NET app

If you want your application to run on macOS Catalina (version 10.15) or higher, you'll want to notarize your app. The appHost you submit with your application for notarization should be used with at least the same [default entitlements](#default-entitlements) for .NET Core.

## Next steps

- [Install .NET on macOS](macos.md).
