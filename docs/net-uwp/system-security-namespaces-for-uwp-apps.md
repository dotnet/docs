---
title: "System.Security namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 83ab5fbe-67f9-4be0-b255-204ebd64384f
caps.latest.revision: 7
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.Security namespaces for UWP apps
The `System.Security` its children namespaces (`System.Security.Authentication`, `System.Security.Authentication.ExtendedProtection`,`System.Security.Claims`) contain classes that represent the .NET Framework security system and permissions.  
  
 This topic displays the types in the `System.Security` and `System.Security.Principal` namespaces that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.Security namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.AllowPartiallyTrustedCallersAttribute>|Allows an assembly to be called by partially trusted code. Without this declaration, only fully trusted callers are able to use the assembly. This class cannot be inherited.|  
|<xref:System.Security.SecurityCriticalAttribute>|Specifies that code or an assembly performs security-critical operations.|  
|<xref:System.Security.SecurityException>|The exception that is thrown when a security error is detected.|  
|<xref:System.Security.SecuritySafeCriticalAttribute>|Identifies types or members as security-critical and safely accessible by transparent code.|  
|<xref:System.Security.SecurityTransparentAttribute>|Specifies that an assembly cannot cause an elevation of privilege.|  
|<xref:System.Security.VerificationException>|The exception that is thrown when the security policy requires code to be type safe and the verification process is unable to verify that the code is type safe.|  
  
## System.Security.Authentication namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Authentication.CipherAlgorithmType>|Defines the possible cipher algorithms for the SslStream class.|  
|<xref:System.Security.Authentication.ExchangeAlgorithmType>|Specifies the algorithm used to create keys shared by the client and server.|  
|<xref:System.Security.Authentication.HashAlgorithmType>|Specifies the algorithm used for generating message authentication codes (MACs).|  
|<xref:System.Security.Authentication.SslProtocols>|Defines the possible versions of SslProtocols.|  
  
## System.Security.Authentication.ExtendedProtection namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Authentication.ExtendedProtection.ChannelBinding>|The ChannelBinding class encapsulates a pointer to the opaque data used to bind an authenticated transaction to a secure channel.|  
|<xref:System.Security.Authentication.ExtendedProtection.ChannelBindingKind>|The ChannelBindingKind enumeration represents the kinds of channel bindings that can be queried from secure channels.|  
  
## System.Security.Claims namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Claims.Claim>|Represents a claim.|  
|<xref:System.Security.Claims.ClaimsIdentity>|Represents a claims-based identity.|  
|<xref:System.Security.Claims.ClaimsPrincipal>|An IPrincipal implementation that supports multiple claims-based identities.|  
|<xref:System.Security.Claims.ClaimTypes>|Defines constants for the well-known claim types that can be assigned to a subject. This class cannot be inherited.|  
|<xref:System.Security.Claims.ClaimValueTypes>|Defines claim value types according to the type URIs defined by W3C and OASIS. This class cannot be inherited.|  
  
## System.Security.Cryptography namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Cryptography.Aes>|Represents the abstract base class from which all implementations of the Advanced Encryption Standard (AES) must inherit.|  
|<xref:System.Security.Cryptography.AsnEncodedData>|Represents Abstract Syntax Notation One (ASN.1)-encoded data.|  
|<xref:System.Security.Cryptography.AsymmetricAlgorithm>|Represents the abstract base class from which all implementations of asymmetric algorithms must inherit.|  
|<xref:System.Security.Cryptography.CipherMode>|Specifies the block cipher mode to use for encryption.|  
|<xref:System.Security.Cryptography.CngAlgorithm>|Encapsulates the name of an encryption algorithm.|  
|<xref:System.Security.Cryptography.CngAlgorithmGroup>|Encapsulates the name of an encryption algorithm group.|  
|<xref:System.Security.Cryptography.CngExportPolicies>|Specifies the key export policies for a key.|  
|<xref:System.Security.Cryptography.CngKey>|Defines the core functionality for keys that are used with Cryptography Next Generation (CNG) objects.|  
|<xref:System.Security.Cryptography.CngKeyBlobFormat>|Specifies a key BLOB format for use with Microsoft Cryptography Next Generation (CNG) objects.|  
|<xref:System.Security.Cryptography.CngKeyCreationOptions>|Specifies options used for key creation.|  
|<xref:System.Security.Cryptography.CngKeyCreationParameters>|Contains advanced properties for key creation.|  
|<xref:System.Security.Cryptography.CngKeyHandleOpenOptions>|Specifies options for opening key handles.|  
|<xref:System.Security.Cryptography.CngKeyOpenOptions>|Specifies options for opening a key.|  
|<xref:System.Security.Cryptography.CngKeyUsages>|Specifies the cryptographic operations that a Cryptography Next Generation (CNG) key may be used with.|  
|<xref:System.Security.Cryptography.CngProperty>|Encapsulates a property of a Cryptography Next Generation (CNG) key or provider.|  
|<xref:System.Security.Cryptography.CngPropertyCollection>|Provides a strongly typed collection of Cryptography Next Generation (CNG) properties.|  
|<xref:System.Security.Cryptography.CngPropertyOptions>|Specifies Cryptography Next Generation (CNG) key property options.|  
|<xref:System.Security.Cryptography.CngProvider>|Encapsulates the name of a key storage provider (KSP) for use with Cryptography Next Generation (CNG) objects.|  
|<xref:System.Security.Cryptography.CngUIPolicy>|Encapsulates optional configuration parameters for the user interface (UI) that Cryptography Next Generation (CNG) displays when you access a protected key.|  
|<xref:System.Security.Cryptography.CngUIProtectionLevels>|Specifies the protection level for the key in user interface (UI) prompting scenarios.|  
|<xref:System.Security.Cryptography.CryptographicException>|The exception that is thrown when an error occurs during a cryptographic operation.|  
|<xref:System.Security.Cryptography.CryptoStream>|Defines a stream that links data streams to cryptographic transformations.|  
|<xref:System.Security.Cryptography.CryptoStreamMode>|Specifies the mode of a cryptographic stream.|  
|<xref:System.Security.Cryptography.DeriveBytes>|Represents the abstract base class from which all classes that derive byte sequences of a specified length inherit.|  
|<xref:System.Security.Cryptography.HashAlgorithm>|Represents the base class from which all implementations of cryptographic hash algorithms must derive.|  
|<xref:System.Security.Cryptography.HashAlgorithmName>|Specifies the name of a cryptographic hash algorithm.|  
|<xref:System.Security.Cryptography.HMAC>|Represents the abstract class from which all implementations of Hash-based Message Authentication Code (HMAC) must derive.|  
|<xref:System.Security.Cryptography.HMACSHA1>|Computes a Hash-based Message Authentication Code (HMAC) using the SHA1 hash function.|  
|<xref:System.Security.Cryptography.HMACSHA256>|Computes a Hash-based Message Authentication Code (HMAC) by using the SHA256 hash function.|  
|<xref:System.Security.Cryptography.HMACSHA384>|Computes a Hash-based Message Authentication Code (HMAC) using the SHA384 hash function.|  
|<xref:System.Security.Cryptography.HMACSHA512>|Computes a Hash-based Message Authentication Code (HMAC) using the SHA512 hash function.|  
|<xref:System.Security.Cryptography.ICryptoTransform>|Defines the basic operations of cryptographic transformations.|  
|<xref:System.Security.Cryptography.KeyedHashAlgorithm>|Represents the abstract class from which all implementations of keyed hash algorithms must derive.|  
|<xref:System.Security.Cryptography.KeySizes>|Determines the set of valid key sizes for the symmetric cryptographic algorithms.|  
|<xref:System.Security.Cryptography.MD5>|Represents the abstract class from which all implementations of the MD5 hash algorithm inherit.|  
|<xref:System.Security.Cryptography.Oid>|Represents a cryptographic object identifier. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.OidCollection>|Represents a collection of Oid objects. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.OidEnumerator>|Provides the ability to navigate through an OidCollection object. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.OidGroup>|Identifies Windows cryptographic object identifier (OID) groups.|  
|<xref:System.Security.Cryptography.PaddingMode>|Specifies the type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.|  
|<xref:System.Security.Cryptography.RandomNumberGenerator>|Represents the abstract class from which all implementations of cryptographic random number generators derive.|  
|<xref:System.Security.Cryptography.Rfc2898DeriveBytes>|Implements password-based key derivation functionality; PBKDF2; by using a pseudo-random number generator based on HMACSHA1.|  
|<xref:System.Security.Cryptography.RSA>|Represents the base class from which all implementations of the RSA algorithm inherit.|  
|<xref:System.Security.Cryptography.RSACng>|Provides a Cryptography Next Generation (CNG) implementation of the RSA algorithm.|  
|<xref:System.Security.Cryptography.RSAEncryptionPadding>|Specifies the padding mode and parameters to use with RSA encryption or decryption operations.|  
|<xref:System.Security.Cryptography.RSAEncryptionPaddingMode>|Specifies the padding mode to use with RSA encryption or decryption operations.|  
|<xref:System.Security.Cryptography.RSAParameters>|Represents the standard parameters for the RSA algorithm.|  
|<xref:System.Security.Cryptography.RSASignaturePadding>|Specifies the padding mode and parameters to use with RSA signature creation or verification operations.|  
|<xref:System.Security.Cryptography.RSASignaturePaddingMode>|Specifies the padding mode to use with RSA signature creation or verification operations.|  
|<xref:System.Security.Cryptography.SHA1>|Computes the SHA1 hash for the input data.|  
|<xref:System.Security.Cryptography.SHA256>|Computes the SHA256 hash for the input data.|  
|<xref:System.Security.Cryptography.SHA384>|Computes the SHA384 hash for the input data.|  
|<xref:System.Security.Cryptography.SHA512>|Computes the SHA512 hash for the input data.|  
|<xref:System.Security.Cryptography.SymmetricAlgorithm>|Represents the abstract base class from which all implementations of symmetric algorithms must inherit.|  
  
## System.Security.Cryptography.X509Certificates namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Cryptography.X509Certificates.OpenFlags>|Specifies the way to open the X.509 certificate store.|  
|<xref:System.Security.Cryptography.X509Certificates.PublicKey>|Represents a certificate's public key information. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions>|Provides extension methods for retrieving RSA implementations for the public and private keys of an X509Certificate2.|  
|<xref:System.Security.Cryptography.X509Certificates.StoreLocation>|Specifies the location of the X.509 certificate store.|  
|<xref:System.Security.Cryptography.X509Certificates.StoreName>|Specifies the name of the X.509 certificate store to open.|  
|<xref:System.Security.Cryptography.X509Certificates.X500DistinguishedName>|Represents the distinguished name of an X509 certificate. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X500DistinguishedNameFlags>|Specifies characteristics of the X.500 distinguished name.|  
|<xref:System.Security.Cryptography.X509Certificates.X509BasicConstraintsExtension>|Defines the constraints set on a certificate. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Certificate>|Provides methods that help you use X.509 v.3 certificates.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Certificate2>|Represents an X.509 certificate.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection>|Represents a collection of X509Certificate2 objects. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Certificate2Enumerator>|Supports a simple iteration over a X509Certificate2Collection object. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509CertificateCollection>|Defines a collection that stores X509Certificate objects.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Chain>|Represents a chain-building engine for X509Certificate2 certificates.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ChainElement>|Represents an element of an X.509 chain.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ChainElementCollection>|Represents a collection of X509ChainElement objects. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ChainElementEnumerator>|Supports a simple iteration over an X509ChainElementCollection. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy>|Represents the chain policy to be applied when building an X509 certificate chain. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ChainStatus>|Provides a simple structure for storing X509 chain status and error information.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ChainStatusFlags>|Defines the status of an X509 chain.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ContentType>|Specifies the format of an X.509 certificate.|  
|<xref:System.Security.Cryptography.X509Certificates.X509EnhancedKeyUsageExtension>|Defines the collection of object identifiers (OIDs) that indicates the applications that use the key. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Extension>|Represents an X509 extension.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ExtensionCollection>|Represents a collection of X509Extension objects. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509ExtensionEnumerator>|Supports a simple iteration over a X509ExtensionCollection. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509FindType>|Specifies the type of value the X509Certificate2Collection.Find method searches for.|  
|<xref:System.Security.Cryptography.X509Certificates.X509KeyStorageFlags>|Defines where and how to import the private key of an X.509 certificate.|  
|<xref:System.Security.Cryptography.X509Certificates.X509KeyUsageExtension>|Defines the usage of a key contained within an X.509 certificate.  This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509KeyUsageFlags>|Defines how the certificate key can be used. If this value is not defined; the key can be used for any purpose.|  
|<xref:System.Security.Cryptography.X509Certificates.X509NameType>|Specifies the type of name the X509 certificate contains.|  
|<xref:System.Security.Cryptography.X509Certificates.X509RevocationFlag>|Specifies which X509 certificates in the chain should be checked for revocation.|  
|<xref:System.Security.Cryptography.X509Certificates.X509RevocationMode>|Specifies the mode used to check for X509 certificate revocation.|  
|<xref:System.Security.Cryptography.X509Certificates.X509Store>|Represents an X.509 store; which is a physical store where certificates are persisted and managed. This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509SubjectKeyIdentifierExtension>|Defines a string that identifies a certificate's subject key identifier (SKI). This class cannot be inherited.|  
|<xref:System.Security.Cryptography.X509Certificates.X509SubjectKeyIdentifierHashAlgorithm>|Defines the type of hash algorithm to use with the X509SubjectKeyIdentifierExtension class.|  
|<xref:System.Security.Cryptography.X509Certificates.X509VerificationFlags>|Specifies conditions under which verification of certificates in the X509 chain should be conducted.|  
  
## System.Security.Principal namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Principal.GenericIdentity>|Represents a generic user.|  
|<xref:System.Security.Principal.GenericPrincipal>|Represents a generic principal.|  
|<xref:System.Security.Principal.IIdentity>|Defines the basic functionality of an identity object.|  
|<xref:System.Security.Principal.IPrincipal>|Defines the basic functionality of a principal object.|  
|<xref:System.Security.Principal.TokenImpersonationLevel>|Defines security impersonation levels. Security impersonation levels govern the degree to which a server process can act on behalf of a client process.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)