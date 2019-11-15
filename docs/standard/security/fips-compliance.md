---
title: FIPS compliance - .NET Core
description: Explains .NET Core Federal Information Processing Standard (FIPS) compliance.
ms.date: 11/20/2019
author: "Rick-Anderson"
ms.author: "riande"
---

# .NET Core Federal Information Processing Standard (FIPS) compliance

.NET Core:

* Does **not** implement any cryptographic primitives.
* Passes cryptographic primitives calls through to the standard modules the underlying operating system provides.
* Does **not** enforce FIPS compliance in .NET Core apps.
* Does **not** stop developers from using non-FIPS compliant algorithms, even on systems configured for FIPS compliance.

The system administrator is responsible for configuring the FIPS compliance for an operating system.

If code is written for a FIPS-compliant environment, the developer is responsible for ensuring that non-compliant FIPS algorithms aren't used.

* Non-compliant FIPS algorithms are not used.

For more information on FIPS compliance, see the following articles:

* [Windows FIPS Compliance](/windows/security/threat-protection/fips-140-validation)
* [Configuring Windows for FIPS Compliance](/windows/security/threat-protection/security-policy-settings/system-cryptography-use-fips-compliant-algorithms-for-encryption-hashing-and-signing)
* [OpenSSL FIPS Compliance](https://www.openssl.org/docs/fips.html)
* [Configuring OpenSSL for FIPS Compliance](https://www.openssl.org/docs/fips/UserGuide.pdf)
