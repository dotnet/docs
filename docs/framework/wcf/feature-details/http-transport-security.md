---
title: "HTTP Transport Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d3439262-c58e-4d30-9f2b-a160170582bb
caps.latest.revision: 14
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# HTTP Transport Security
When using HTTP as the transport, security is provided by a Secure Sockets Layer (SSL) implementation. SSL is widely used on the Internet to authenticate a service to a client, and then to provide confidentiality (encryption) to the channel. This topic explains how SSL works and how it is implemented in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
## Basic SSL  
 How SSL works is best explained through a typical scenario, in this case, a bank's Web site. The site allows a customer to log on with a user name and password. After being authenticated, the user can perform transactions, such as view account balances, pay bills, and move money from one account to another.  
  
 When a user first visits the site, the SSL mechanism begins a series of negotiations, called a *handshake*, with the user's client (in this case, Internet Explorer). SSL first authenticates the bank site to the customer. This is an essential step because customers must first know that they are communicating with the actual site, and not a spoof that tries to lure them into typing in their user name and password. SSL does this authentication by using an SSL certificate provided by a trusted authority, such as VeriSign. The logic goes like this: VeriSign vouches for the identity of the bank site. Because Internet Explorer trusts VeriSign, the site is trusted. If you want to check with VeriSign, you can do so as well by clicking on the VeriSign logo. That presents a statement of authenticity with its expiration date and who it is issued to (the bank site).  
  
 To initiate a secure session, the client sends the equivalent of a "hello" to the server along with a list of cryptographic algorithms it can use to sign, generate hashes, and encrypt and decrypt with. In response, the site sends back an acknowledgment and its choice of one of the algorithms suites. During this initial handshake, both parties send and receive nonces. A *nonce* is a randomly generated piece of data that is used, in combination with the site's public key, to create a hash. A *hash* is a new number that is derived from the two numbers using a standard algorithm, such as SHA1. (The client and the site also exchange messages to agree which hash algorithm to use.) The hash is unique and is used only for the session between the client and the site to encrypt and decrypt messages. Both client and service have the original nonce and the certificate's public key, so both sides can generate the same hash. Therefore, the client validates the hash sent by the service by (a) using the agreed upon algorithm to calculate the hash from the data, and (b) comparing it to the hash sent by the service; if the two match, then the client has assurance that the hash has not been tampered with. The client can then use this hash as a key to encrypt a message that contains yet another new hash. The service can decrypt the message using the hash, and recover this second-to-final hash. The accumulated information (nonces, public key, and other data) is now known to both sides, and a final hash (or master key) can be created. This final key is sent encrypted using the next-to-last hash. The master key is then used to encrypt and decrypt messages for the reset of the session. Because both client and service use the same key, this is also called a *session key*.  
  
 The session key is also characterized as a symmetric key, or a "shared secret." Having a symmetric key is important because it reduces the computation required by both sides of the transaction. If every message demanded a new exchange of nonces and hashes, performance would deteriorate. Therefore, the ultimate goal of SSL is to use a symmetric key that allows messages to flow freely between the two sides with a greater degree of security and efficiency.  
  
 The previous description is a simplified version of what happens, because the protocol may vary from site to site. It is also possible that both the client and the site both generate nonces that are algorithmically combined during the handshake to add more complexity, and therefore protection, to the process of exchanging data.  
  
### Certificates and Public Key Infrastructure  
 During the handshake, the service also sends its SSL certificate to the client. The certificate contains information, such as its expiration date, issuing authority, and the site's Uniform Resource Identifier (URI). The client compares the URI to the URI it had originally contacted to ensure a match, and also checks the date and issuing authority.  
  
 Every certificate has two keys, a private key and a public key, and the two are known as an *exchange key pair*. In brief, the private key is known only to the owner of the certificate while the public key is readable from the certificate. Either key can be used to encrypt or decrypt a digest, hash, or other key, but only as contrary operations. For example, if the client encrypts with the public key, only the site can decrypt the message using the private key. Similarly, if the site encrypts with the private key, the client can decrypt with the public key. This provides assurance to the client that the messages are being exchanged only with the possessor of the private key because only messages encrypted with the private key can be decrypted with the public key. The site is assured that it is exchanging messages with a client that has encrypted using the public key. This exchange is secure only for an initial handshake, however, which is why much more is done to create the actual symmetric key. Nevertheless, all communications depend on the service having a valid SSL certificate.  
  
## Implementing SSL with WCF  
 HTTP transport security (or SSL) is provided externally to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. You can implement SSL in one of two ways; the deciding factor is how your application is hosted:  
  
-   If you are using Internet Information Services (IIS) as your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] host, use the IIS infrastructure to set up an SSL service.  
  
-   If you are creating a self-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, you can bind an SSL certificate to the address using the HttpCfg.exe tool.  
  
### Using IIS for Transport Security  
  
#### IIS 7.0  
 To set up [!INCLUDE[iisver](../../../../includes/iisver-md.md)] as a secure host (using SSL), see [IIS 7.0 Beta: Configuring Secure Sockets Layer in IIS 7.0](http://go.microsoft.com/fwlink/?LinkId=88600).  
  
 To configure certificates for use with [!INCLUDE[iisver](../../../../includes/iisver-md.md)], see [IIS 7.0 Beta: Configuring Server Certificates in IIS 7.0](http://go.microsoft.com/fwlink/?LinkID=88595).  
  
#### IIS 6.0  
 To set up [!INCLUDE[iis601](../../../../includes/iis601-md.md)] as a secure host (using SSL), see [Configuring Secure Sockets Layer](http://go.microsoft.com/fwlink/?LinkId=88601).  
  
 To configure certificates for use with [!INCLUDE[iis601](../../../../includes/iis601-md.md)], see [Certificates_IIS_SP1_Ops](http://go.microsoft.com/fwlink/?LinkId=88602).  
  
### Using HttpCfg for SSL  
 If you are creating a self-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, download the HttpCfg.exe tool, available at the [Windows XP Service Pack 2 Support Tools site](http://go.microsoft.com/fwlink/?LinkId=29002).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using the HttpCfg.exe tool to set up a port with an X.509 certificate, see [How to: Configure a Port with an SSL Certificate](../../../../docs/framework/wcf/feature-details/how-to-configure-a-port-with-an-ssl-certificate.md).  
  
## See Also  
 [Transport Security](../../../../docs/framework/wcf/feature-details/transport-security.md)  
 [Message Security](../../../../docs/framework/wcf/feature-details/message-security-in-wcf.md)
