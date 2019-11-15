---
title: .NET Core FIPS compliance
description: Explains .NET Core FIPS compliance
ms.date: 11/20/2019
---

# .NET Core FIPS compliance

.NET Core:

* Does **not** implement any cryptographic primitives.
* Passes cryptographic primitives calls through to the standard modules the underlying operating system provides.
* Does **not** enforce FIPS compliance in .NET Core app.
* Does **not** stop developers using non-FIPS compliant algorithms, even on systems configured for FIPS compliance.

It's the responsibility of the system administrator to configure FIPS compliance for an operating system.

If code is written for a FIPS-compliant environment, it's the responsibility of the developer to:

* Ensure that non-compliant FIPS algorithms are not used.
* FIPS compliance is met.

For more information on FIPS compliance, see the following articles:

* [Windows FIPS Compliance](/windows/security/threat-protection/fips-140-validation)
* [Configuring Windows for FIPS Compliance](/windows/security/threat-protection/security-policy-settings/system-cryptography-use-fips-compliant-algorithms-for-encryption-hashing-and-signing)
* [OpenSSL FIPS Compliance](https://www.openssl.org/docs/fips.html)
* [Configuring OpenSSL for FIPS Compliance](https://www.openssl.org/docs/fips/UserGuide.pdf)
