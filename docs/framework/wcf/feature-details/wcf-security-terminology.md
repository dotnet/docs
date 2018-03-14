---
title: "WCF Security Terminology"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [WCF], terminology"
  - "security glossary [WCF]"
  - "security terms [WCF]"
ms.assetid: 68dde024-8e51-40ba-804f-ec52d85e9ca9
caps.latest.revision: 14
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# WCF Security Terminology
Some of the terminology used when discussing security may be unfamiliar. This topic provides short explanations of some of security terms, but is not intended to provide comprehensive documentation for every item.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] terms used in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] documentation, see [Fundamental Windows Communication Foundation Concepts](../../../../docs/framework/wcf/fundamental-concepts.md).  
  
 access control list (ACL)  
 A list of security protections that applies to an object. (An object can be a file, process, event, or anything else having a security descriptor.) An entry in an ACL is an access control entry (ACE). There are two types of ACLs: discretionary and system.  
  
 authentication  
 The process for verifying that a user, computer, service, or process is who or what it claims to be.  
  
 authorization  
 The act of controlling access and rights to a resource. For example, allowing members of one group to read a file, but allowing only members of another group to alter the file.  
  
 certification authority (CA) certificate  
 Identifies the CA that issues server and client authentication certificates to the servers and clients that request these certificates. Because it contains a public key used in digital signatures, it is also referred to as a *signature certificate*. If the CA is a root authority, the CA certificate may be referred to as a *root certificate*. Also sometimes known as a *site certificate*.  
  
 CA hierarchy  
 A CA hierarchy contains multiple CAs. It is organized so that each CA is certified by another CA in a higher level of the hierarchy until the top of the hierarchy, also known as the *root authority*, is reached.  
  
 certificate  
 A digitally signed statement that contains information about an entity and the entity's public key, thus binding these two pieces of information together. A certificate is issued by a trusted organization (or entity), called a certification authority, after the authority has verified that the entity is who it says it is.  
  
 Certificates can contain different types of data. For example, an X.509 certificate includes the format of the certificate, the serial number of the certificate, the algorithm used to sign the certificate, the name of the CA that issued the certificate, the name and public key of the entity requesting the certificate, and the CA's signature.  
  
 certificate store  
 Typically, a permanent storage where certificates, certificate revocation lists (CRLs), and certificate trust lists (CTLs) are stored. It is possible, however, to create and open a certificate store solely in memory when working with certificates that do not need to be put in permanent storage.  
  
 claims  
 Information passed from one entity to another used to establish the sender's identity. For example, a username and password token, or an X.509 certificate.  
  
 client certificate  
 Refers to a certificate used for client authentication, such as authenticating a Web browser on a Web server. When a Web browser client attempts to access a secured Web server, the client sends its certificate to the server to allow it to verify the client's identity.  
  
 credentials  
 Previously authenticated logon data that a security principal uses to establish its own identity, such as a password, or a Kerberos protocol ticket. Credentials are used to control access to resources.  
  
 digested data  
 A data content type defined by public key cryptographic standard (PKCS) #7 that consists of any type of data plus a message hash (digest) of the content.  
  
 digital signature  
 Data that binds a sender's identity to the information being sent. A digital signature may be bundled with any message, file, or other digitally encoded information, or transmitted separately. Digital signatures are used in public key environments and provide authentication and integrity services.  
  
 encoding  
 The process of turning data into a stream of bits. Encoding is part of the serialization process that converts data into a stream of ones and zeros.  
  
 exchange key pair  
 A public/private key pair used to encrypt session keys so that they can be safely stored and exchanged with other users.  
  
 hash  
 A fixed-size numerical value obtained by applying a mathematical function (see hashing algorithm) to an arbitrary amount of data. The data typically includes random data, known as a *nonce*. Both the service and client contribute exchange nonces to increase the complexity of the result. The result is also known as a *message digest*. Sending a hash value is safer than sending sensitive data, such as a password, even if the password is encrypted. The hash sender and receiver must agree on the hashing algorithm and the nonces so that, once received, a hash can be verified.  
  
 hashing algorithm  
 An algorithm used to produce a hash value of some piece of data, such as a message or session key. Typical hashing algorithms include MD2, MD4, MD5, and SHA-1.  
  
 Kerberos protocol  
 A protocol that defines how clients interact with a network authentication service. Clients obtain tickets from the Kerberos Key Distribution Center (KDC), and they present these tickets to servers when connections are established. Kerberos tickets represent the client's network credentials.  
  
 local security authority (LSA)  
 A protected subsystem that authenticates and logs users on to the local system. LSA also maintains information about all aspects of local security on a system, collectively known as the local security policy of the system.  
  
 Negotiate  
 A security support provider (SSP) that acts as an application layer between the Security Support Provider Interface (SSPI) and the other SSPs. When an application calls into SSPI to log on to a network, it can specify an SSP to process the request. If the application specifies `Negotiate`, `Negotiate` analyzes the request and picks the best SSP to handle the request based on the customer-configured security policy.  
  
 nonce  
 A randomly generated value used to defeat "replay" attacks.  
  
 nonrepudiation  
 The ability to identify users who performed certain actions, thus irrefutably countering any attempts by a user to deny responsibility. For example, a system may log the ID of a user whenever a file is deleted.  
  
 Public Key Cryptography Standard (PKCS)  
 Specifications produced by RSA Data Security, Inc. in cooperation with developers of secure systems worldwide in order to accelerate the deployment of public-key cryptography.  
  
 PKCS #7  
 The Cryptographic Message Syntax Standard. A general syntax for data to which cryptography may be applied, such as digital signatures and encryption. It also provides syntax for disseminating certificates or certificate revocation lists and other message attributes, such as time stamps, to the message.  
  
 plaintext  
 A message that is not encrypted. Plaintext messages are sometimes referred to as *cleartext* messages.  
  
 privilege  
 The right of a user to perform various system-related operations, such as shutting down the system, loading device drivers, or changing the system time. A user's access token contains a list of the privileges that the user or the user's groups hold.  
  
 private key  
 The secret half of a key pair used in a public-key algorithm. Private keys are typically used to encrypt a symmetric session key, digitally sign a message, or decrypt a message that has been encrypted with the corresponding public key. See also "public key."  
  
 process  
 The security context under which an application runs. Typically, the security context is associated with a user, so all applications running under a given process take on the permissions and privileges of the owning user.  
  
 public/private key pair  
 A set of cryptographic keys used for public key cryptography. For each user, a cryptographic service provider (CSP) usually maintains two public/private key pairs: an exchange key pair and a digital signature key pair. Both key pairs are maintained from session to session.  
  
 public key  
 A cryptographic key typically used when decrypting a session key or a digital signature. The public key can also be used to encrypt a message, guaranteeing that only the person with the corresponding private key can decrypt the message.  
  
 public key encryption  
 Encryption that uses a pair of keys, one key to encrypt data and the other key to decrypt data. In contrast, symmetric encryption algorithms that use the same key for both encryption and decryption. In practice, public key cryptography is typically used to protect the session key a symmetric encryption algorithm uses. In this case, the public key is used to encrypt the session key, which in turn was used to encrypt some data, and the private key is used for decryption. In addition to protecting session keys, public key cryptography may also be used to digitally sign a message (using the private key) and validate the signature (using the public key).  
  
 public key infrastructure (PKI)  
 An infrastructure providing an integrated set of services and administrative tools for creating, deploying, and managing public-key applications.  
  
 repudiation  
 The ability of a user to falsely deny having performed an action while other parties cannot prove otherwise. For example, a user who deletes a file and who can successfully deny having done so.  
  
 root authority  
 The CA at the top of a CA hierarchy. The root authority certifies CAs in the next level of the hierarchy.  
  
 Secure Hash Algorithm (SHA)  
 A hashing algorithm that generates a message digest. SHA is used with the Digital Signature Algorithm (DSA) in the Digital Signature Standard (DSS), among other places. There are four varieties of SHA: SHA-1, SHA-256, SHA-384, and SHA-512. SHA-1 generates a 160-bit message digest. SHA-256, SHA-384, and SHA-512 generate 256-bit, 384-bit, and 512-bit message digests, respectively. SHA was developed by the National Institute of Standards and Technology (NIST) and by the National Security Agency (NSA).  
  
 Secure Sockets Layer (SSL)  
 A protocol for secure network communications using a combination of public and secret key technology.  
  
 security context  
 The security attributes or rules that are currently in effect. For example, the current user logged on to the computer or the personal identification number entered by the smart card user. For SSPI, a security context is an opaque data structure that contains security data relevant to a connection, such as a session key or an indication of the duration of the session.  
  
 security principal  
 An entity recognized by the security system. Principals can include human users as well as autonomous processes.  
  
 security support provider (SSP)  
 A dynamic-link library (DLL) that implements the SSPI by making one or more security packages available to applications. Each security package provides mappings between an application's SSPI function calls and an actual security model's functions. Security packages support security protocols such as Kerberos authentication and the Microsoft LAN Manager (LanMan).  
  
 Security Support Provider Interface (SSPI)  
 A common interface between transport-level applications, such as Microsoft remote procedure call (RPC), and security providers, such as Windows distributed security. SSPI allows a transport application to call one of several security providers to obtain an authenticated connection. These calls do not require extensive knowledge of the security protocol's details.  
  
 security token service  
 Services designed to issue and manage custom security tokens (issued tokens) in a multiservice scenario. The custom tokens are usually Security Assertions Markup Language (SAML) tokens that include a custom credential.  
  
 server certificate  
 Refers to a certificate used for server authentication, such as authenticating a Web server to a Web browser. When a Web browser client attempts to access a secured Web server, the server sends its certificate to the browser to allow it to verify the server's identity.  
  
 session  
 An exchange of messages under the protection of a single piece of keying material. For example, SSL sessions use a single key to send multiple messages back and forth under that key.  
  
 session key  
 A randomly generated key that is used once and then discarded. Session keys are symmetric (used for both encryption and decryption). They are sent with the message, protected by encryption with a public key from the intended recipient. A session key consists of a random number of approximately 40 to 2,000 bits.  
  
 supplemental credentials  
 Credentials for use in authenticating a security principal to foreign security domains.  
  
 symmetric encryption  
 Encryption that uses a single key for both encryption and decryption. Symmetric encryption is preferred when encrypting large amounts of data. Some of the more common symmetric encryption algorithms are RC2, RC4, and Data Encryption Standard (DES).  
  
 See also "public key encryption."  
  
 symmetric key  
 A single key used for both encryption and decryption. Session keys are usually symmetric.  
  
 token (access token)  
 An access token contains the security information for a logon session. The system creates an access token when a user logs on, and every process executed on behalf of the user has a copy of the token. The token identifies the user, the user's groups, and the user's privileges. The system uses the token to control access to securable objects and to control the ability of the user to perform various system-related operations on the local computer. There are two kinds of access tokens, primary and impersonation.  
  
 transport layer  
 The network layer that is responsible for both quality of service and accurate delivery of information. Among the tasks performed in this layer are error detection and correction.  
  
 trust list (certificate trust list, or CTL)  
 A predefined list of items that have been signed by a trusted entity. A CTL can be anything, such as a list of hashes of certificates, or a list of file names. All the items in the list are authenticated (approved) by the signing entity.  
  
 trust provider  
 The software that decides whether a given file is trusted. This decision is based on the certificate associated with the file.  
  
 user principal name (UPN)  
 A user account name (sometimes referred to as the *user logon name*) and a domain name identifying the domain in which the user account is located. This is the standard usage for logging on to a Windows domain. The format is: someone@example.com (as for an email address).  
  
> [!NOTE]
>  In addition to standard UPN form, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] accepts UPNs in down-level form, for example, cohowinery.com\someone.  
  
 X.509  
 An internationally recognized standard for certificates that defines their required parts.  
  
## See Also  
 [Fundamental Windows Communication Foundation Concepts](../../../../docs/framework/wcf/fundamental-concepts.md)  
 [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
