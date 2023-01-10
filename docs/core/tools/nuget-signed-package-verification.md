---
title: NuGet signed package verification
description: Learn about how NuGet performs signed package verification using root stores that are valid for code signing and timestamping.
author: DTivel
ms.date: 11/07/2022
---
# NuGet signed-package verification

You can [sign a NuGet package](/nuget/create-packages/sign-a-package) to enable the package consumer to validate the package's authenticity and integrity. If verification is enabled, .NET verifies signed packages during a package restore operation, which occurs automatically when the consumer builds or runs their project.

NuGet package signatures are based on X.509 certificates, and a prerequisite for signed-package verification is a certificate root store that's valid for both code signing and timestamping.

Starting with .NET 7, NuGet uses fallback certificate bundles included in the .NET SDK to verify signed packages where a suitable system root store is not available. These bundles are sourced from the [Microsoft Trusted Root Program](/security/trusted-root/program-requirements) and contain the same code signing and timestamping certificates as the root store on Windows.

Some NuGet commands, such as `sign` and `verify`, always perform signed package verification.

The following sections for each operating system describe:

- When implicit verification during restore operations is enabled by default.
- How to enable it.
- What root stores are used.

## Windows

Verification is enabled by default during package restore operations.

NuGet uses the default root store on Windows, which already supports general-purpose code signing and timestamping. .NET SDK fallback certificate bundles aren't used.

## Linux

Verification is disabled by default during package restore operations. To opt in, set the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `true`.

NuGet uses .NET SDK fallback certificate bundles by default. You can override the code signing fallback certificate bundle by providing a certificate bundle valid for code signing at the following probe path:

```text
/etc/pki/ca-trust/extracted/pem/objsign-ca-bundle.pem
```

## macOS

Verification is disabled by default during package restore operations. To opt in, set the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `true`. However, we recommend that you don't enable verification. For more information, see [NuGet/Home#11985](https://github.com/NuGet/Home/issues/11985) and [NuGet/Home#11986](https://github.com/NuGet/Home/issues/11986).

NuGet uses only .NET SDK fallback certificate bundles.

## See also

- [Signed-package verification design document](https://github.com/dotnet/designs/blob/main/accepted/2021/signed-package-verification/re-enable-signed-package-verification.md)
- [Signed-package verification technical specification](https://github.com/dotnet/designs/blob/main/accepted/2021/signed-package-verification/re-enable-signed-package-verification-technical.md)
