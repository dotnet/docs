---
title: System.Security.Cryptography.RSAParameters structure
description: Learn about the System.Security.Cryptography.RSAParameters structure.
ms.date: 12/31/2023
---
# System.Security.Cryptography.RSAParameters structure

[!INCLUDE [context](includes/context.md)]

The <xref:System.Security.Cryptography.RSAParameters> structure represents the standard parameters for the RSA algorithm.

The <xref:System.Security.Cryptography.RSA> class exposes an <xref:System.Security.Cryptography.RSA.ExportParameters%2A> method that enables you to retrieve the raw RSA key in the form of an <xref:System.Security.Cryptography.RSAParameters> structure.

To understand the contents of this structure, it helps to be familiar with how the <xref:System.Security.Cryptography.RSA> algorithm works. The next section discusses the algorithm briefly.

## RSA algorithm

To generate a key pair, you start by creating two large prime numbers named p and q. These numbers are multiplied and the result is called n. Because p and q are both prime numbers, the only factors of n are 1, p, q, and n.

If we consider only numbers that are less than n, the count of numbers that are relatively prime to n, that is, have no factors in common with n, equals (p - 1)(q - 1).

Now you choose a number e, which is relatively prime to the value you calculated. The public key is now represented as {e, n}.

To create the private key, you must calculate d, which is a number such that (d)(e) mod (p - 1)(q - 1) = 1. In accordance with the Euclidean algorithm, the private key is now {d, n}.

Encryption of plaintext m to ciphertext c is defined as c = (m ^ e) mod n. Decryption would then be defined as m = (c ^ d) mod n.

## Summary of fields

Section A.1.2 of the [PKCS #1: RSA Cryptography Standard](https://datatracker.ietf.org/doc/html/rfc8017#appendix-A.1.2) defines a format for RSA private keys.

The following table summarizes the fields of the <xref:System.Security.Cryptography.RSAParameters> structure. The third column provides the corresponding field in section A.1.2 of [PKCS #1: RSA Cryptography Standard](https://datatracker.ietf.org/doc/html/rfc8017#appendix-A.1.2).

| <xref:System.Security.Cryptography.RSAParameters> field    | Contains                | Corresponding PKCS #1 field |
| ---------------------------------------------------------- | ----------------------- | --------------------------- |
| <xref:System.Security.Cryptography.RSAParameters.D>        | d, the private exponent | privateExponent             |
| <xref:System.Security.Cryptography.RSAParameters.DP>       | d mod (p - 1)           | exponent1                   |
| <xref:System.Security.Cryptography.RSAParameters.DQ>       | d mod (q - 1)           | exponent2                   |
| <xref:System.Security.Cryptography.RSAParameters.Exponent> | e, the public exponent  | publicExponent              |
| <xref:System.Security.Cryptography.RSAParameters.InverseQ> | (InverseQ)(q) = 1 mod p | coefficient                 |
| <xref:System.Security.Cryptography.RSAParameters.Modulus>  | n                       | modulus                     |
| <xref:System.Security.Cryptography.RSAParameters.P>        | p                       | prime1                      |
| <xref:System.Security.Cryptography.RSAParameters.Q>        | q                       | prime2                      |

The security of RSA derives from the fact that, given the public key { e, n }, it is computationally infeasible to calculate d, either directly or by factoring n into p and q. Therefore, any part of the key related to d, p, or q must be kept secret. If you call <xref:System.Security.Cryptography.RSACryptoServiceProvider.ExportParameters%2A> and ask for only the public key information, this is why you will receive only <xref:System.Security.Cryptography.RSAParameters.Exponent> and <xref:System.Security.Cryptography.RSAParameters.Modulus>. The other fields are available only if you have access to the private key, and you request it.

<xref:System.Security.Cryptography.RSAParameters> is not encrypted in any way, so you must be careful when you use it with the private key information. All members of <xref:System.Security.Cryptography.RSAParameters> are serialized. If anyone can derive or intercept the private key parameters, the key and all the information encrypted or signed with it are compromised.
