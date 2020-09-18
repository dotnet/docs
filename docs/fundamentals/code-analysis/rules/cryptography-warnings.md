---
title: Cryptography Warnings
ms.date: 11/04/2016
ms.topic: reference
ms.assetid: d96723ea-a293-488d-b9db-adb437e50cdd
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
- multiple
---
# Cryptography Warnings
Cryptography warnings support safer libraries and applications through the correct use of cryptography. These warnings help prevent security flaws in your program. If you disable any of these warnings, you should clearly mark the reason in code and also inform the designated security officer for your development project.

|Rule|Description|
|----------|-----------------|
|[CA5350: Do Not Use Weak Cryptographic Algorithms](../code-quality/ca5350.md)|Weak encryption algorithms and hashing functions are used today for a number of reasons, but they should not be used to guarantee the confidentiality or integrity of the data they protect.        This rule triggers when it finds TripleDES, SHA1, or RIPEMD160 algorithms in the code.|
|[CA5351 Do Not Use Broken Cryptographic Algorithms](../code-quality/ca5351.md)|Broken cryptographic algorithms are not considered secure and their use should be strongly discouraged. This rule triggers when it finds the MD5 hash algorithm or either the DES or RC2 encryption algorithms in code.|
