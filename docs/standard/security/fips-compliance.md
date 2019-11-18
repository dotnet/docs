---
title: FIPS compliance - .NET Core
description: Explains .NET Core Federal Information Processing Standard (FIPS) compliance.
ms.date: 11/20/2019
author: "Rick-Anderson"
ms.author: "riande"
---

# .NET Core Federal Information Processing Standard (FIPS) compliance

The Federal Information Processing Standard (FIPS) Publication 140-2 is a U.S. government standard that defines minimum security requirements for cryptographic modules in information technology products, as defined in Section 5131 of the Information Technology Management Reform Act of 1996.

.NET Core:

* Passes cryptographic primitives calls through to the standard modules the underlying operating system provides.
* Does **not** enforce the use of FIPS Approved algorithms or key sizes in .NET Core apps.

The system administrator is responsible for configuring the FIPS compliance for an operating system.

If code is written for a FIPS-compliant environment, the developer is responsible for ensuring that non-compliant FIPS algorithms aren't used.

For more information on FIPS compliance, see the following articles:

* [Windows FIPS Compliance](/windows/security/threat-protection/fips-140-validation)
* [Configuring Windows for FIPS Compliance](/windows/security/threat-protection/security-policy-settings/system-cryptography-use-fips-compliant-algorithms-for-encryption-hashing-and-signing)
* [10.2. FEDERAL INFORMATION PROCESSING STANDARD (FIPS)](https://access.redhat.com/documentation/red_hat_enterprise_linux/6/html/security_guide/sect-security_guide-federal_standards_and_regulations-federal_information_processing_standard)
