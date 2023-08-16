---
title: NuGet signed-package verification
description: Learn about how NuGet performs signed-package verification using root stores that are valid for code signing and timestamping.
author: DTivel
ms.date: 11/07/2022
---
# NuGet signed-package verification

You can [sign a NuGet package](/nuget/create-packages/sign-a-package) to enable package consumers to validate the package's authenticity and integrity. If verification is enabled, .NET verifies signed packages during a package restore operation, which occurs automatically when a package consumer builds or runs their project.

NuGet package signatures are based on X.509 certificates, and a prerequisite for signed-package verification is a certificate root store that is valid for both code signing and timestamping.

Starting with .NET 6.0.400 SDK, NuGet uses certificate bundles included in the .NET SDK to verify signed packages where a suitable system root store is not available. These bundles are sourced from the [Microsoft Trusted Root Program](/security/trusted-root/program-requirements) and contain the same code signing and timestamping certificates as the root store on Windows. These certificate bundles should contain all of the root certificates necessary to verify packages from [NuGet.org](https://nuget.org).

Some NuGet commands, such as `sign` and `verify`, always perform signed-package verification.

The following sections for each operating system describe:

- When implicit verification during restore operations is enabled by default.
- How to enable it.
- What root stores are used.

## Windows

Verification is enabled by default during package restore operations.

NuGet uses the default root store on Windows, which already supports general-purpose code signing and timestamping. .NET SDK certificate bundles aren't used.  All signed-package verification functionality is supported on Windows in the .NET SDK version in which it was introduced.

## Linux

> [!IMPORTANT]
> Although signed-package verification functionality was added in .NET 5 SDK's, the functionality isn't supported on Linux until .NET 6.0.400 SDK. We strongly recommend that signed-package verification not be used with .NET SDK's below 6.0.400.

Prior to .NET 8 Preview 4 SDK, verification is disabled by default during package restore operations. To opt in, set the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `true`.

Starting with .NET 8 Preview 4 SDK, verification is enabled by default. To opt out, set the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `false`.

For code signing certificate verification, NuGet will first probe for a certificate bundle at the following location:

```text
/etc/pki/ca-trust/extracted/pem/objsign-ca-bundle.pem
```

If a valid certificate bundle is found, NuGet will prefer it over the .NET SDK's certificate bundle for code signing. If it contains at least the same set of root certificates as the .NET SDK's certificate bundle, then NuGet signed-package verification should succeed. If it lacks root certificates, like those used in signed packages on [NuGet.org](https://nuget.org), NuGet signed-package verification will fail with an untrusted status (via [NU3018](/nuget/reference/errors-and-warnings/nu3018) or [NU3028](/nuget/reference/errors-and-warnings/nu3028)). Adding root certificates to this certificate bundle can enable successful verification; however, keep in mind that this certificate bundle is a system-wide trust store, whereas .NET SDK certificate bundles are used as an application-wide trust store.

If a valid certificate bundle is not found at the above location, NuGet will fall back to using the .NET SDK's certificate bundle for code signing.

For timestamping certificate verification, NuGet always uses the .NET SDK's certificate bundle for timestamping.

## macOS

Verification is disabled by default during package restore operations. To opt in, set the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `true`. However, we recommend that you don't enable verification. For more information, see [NuGet/Home#11985](https://github.com/NuGet/Home/issues/11985) and [NuGet/Home#11986](https://github.com/NuGet/Home/issues/11986).

NuGet uses only the .NET SDK's certificate bundles.

> [!IMPORTANT]
> Although signed-package verification functionality was added in .NET 5 SDK's, the functionality isn't currently supported on macOS. We strongly recommend that signed-package verification not be used with .NET SDK's below 6.0.400 and that it remains disabled by default.

## See also

- [Signed-package verification design document](https://github.com/dotnet/designs/blob/main/accepted/2021/signed-package-verification/re-enable-signed-package-verification.md)
- [Signed-package verification technical specification](https://github.com/dotnet/designs/blob/main/accepted/2021/signed-package-verification/re-enable-signed-package-verification-technical.md)
