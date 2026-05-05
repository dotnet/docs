---
title: "Breaking change: dotnet nuget verify outputs CRL and OCSP URLs"
description: "Learn about the breaking change in .NET 10 where dotnet nuget verify outputs CRL and OCSP URLs for each certificate in the signature chain."
ms.date: 05/05/2026
ai-usage: ai-assisted
---

# `dotnet nuget verify` outputs CRL and OCSP URLs

Starting in .NET 10.0.400 SDK, `dotnet nuget verify` outputs Certificate Revocation List (CRL) and Online Certificate Status Protocol (OCSP) URLs for each certificate in the signature chain.

## Version introduced

.NET 10.0.400 SDK

## Previous behavior

Previously, `dotnet nuget verify` displayed certificate details such as subject name, SHA1 hash, SHA256 hash, issuer, and validity period, but didn't include CRL or OCSP URLs.

```
Verifying NuGet.Versioning.7.0.0
Content hash: vMEhpystjAmHzWARE09PjYMWOiGgM+f9rJYMcXGs8soz9/url4qmU9O9Y+hy22kPuqozCMoGcJt0JzKRZ1woZg==
C:\Users\user\.nuget\packages\nuget.versioning\7.0.0\nuget.versioning.7.0.0.nupkg
Signature Hash Algorithm: SHA256

Signature type: Author
Verifying the author primary signature with certificate:
  Subject Name: CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
  SHA1 hash: F25C45D17C53D4E0D1DC9FB9DFD0731FCF904B77
  SHA256 hash: 566A31882BE208BE4422F7CFD66ED09F5D4524A5994F50CCC8B05EC0528C1353
  Issued by: CN=DigiCert Trusted G4 Code Signing RSA4096 SHA384 2021 CA1, O="DigiCert, Inc.", C=US
  Valid from: 2023-07-27 9:30:00 AM to 2026-10-18 10:29:59 AM
```

## New behavior

Starting in .NET 10.0.400 SDK, CRL URL and OCSP URL lines appear after the certificate validity period. A certificate can have multiple CRL URLs.

```
Verifying NuGet.Versioning.7.0.0
Content hash: vMEhpystjAmHzWARE09PjYMWOiGgM+f9rJYMcXGs8soz9/url4qmU9O9Y+hy22kPuqozCMoGcJt0JzKRZ1woZg==
C:\Users\user\.nuget\packages\nuget.versioning\7.0.0\nuget.versioning.7.0.0.nupkg
Signature Hash Algorithm: SHA256

Signature type: Author
Verifying the author primary signature with certificate:
  Subject Name: CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
  SHA1 hash: F25C45D17C53D4E0D1DC9FB9DFD0731FCF904B77
  SHA256 hash: 566A31882BE208BE4422F7CFD66ED09F5D4524A5994F50CCC8B05EC0528C1353
  Issued by: CN=DigiCert Trusted G4 Code Signing RSA4096 SHA384 2021 CA1, O="DigiCert, Inc.", C=US
  Valid from: 2023-07-27 9:30:00 AM to 2026-10-18 10:29:59 AM
  CRL URL: http://crl3.digicert.com/DigiCertTrustedG4CodeSigningRSA4096SHA3842021CA1.crl
  CRL URL: http://crl4.digicert.com/DigiCertTrustedG4CodeSigningRSA4096SHA3842021CA1.crl
  OCSP URL: http://ocsp.digicert.com
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Some users asked NuGet to provide a full list of URLs or hosts that NuGet accesses during a restore, and to explain why NuGet makes HTTP (rather than HTTPS) requests. The CRL and OCSP URLs in certificate chains are the source of these HTTP requests. Displaying these URLs in `dotnet nuget verify` output lets users discover this information without needing to capture network traces.

For more information, see the [NuGet.Client pull request #7343](https://github.com/NuGet/NuGet.Client/pull/7343).

## Recommended action

If you use `dotnet nuget verify` in automation and parse its output, update your parsing logic to handle the new `CRL URL` and `OCSP URL` fields. Note that certificate information blocks no longer have unique keys—a certificate can have multiple `CRL URL` entries.

## Affected APIs

None.

## See also

- [`dotnet nuget verify`](../../../tools/dotnet-nuget-verify.md)
