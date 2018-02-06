---
title: "How to: Obtain a Certificate (WCF)"
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
  - "certificates [WCF], obtaining"
ms.assetid: d53762fd-15ea-42dc-b0ea-6a6597aa23f7
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Obtain a Certificate (WCF)
To use any of the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] features of that use X.509 certificates, you just first obtain certificates.  
  
### To obtain an X.509 certificate  
  
1.  Choose one of the following:  
  
    -   Purchase a certificate from a certification authority, such as VeriSign, Inc.  
  
    -   Set up your own certificate service and have a certification authority sign the certificates. [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], Windows 2000 Server, Windows 2000 Server Datacenter, and Windows 2000 Datacenter Server all include certificate services that support public key infrastructure (PKI). In Windows Server 2008, use the [Active Directory Certificate Services](http://go.microsoft.com/fwlink/?LinkID=153483) role to manage a certification authority.  
  
    -   Set up your own certificate service and do not have the certificates signed.  
  
    > [!NOTE]
    >  Whichever approach you take, the recipient of the SOAP request that contains the X.509 certificate must trust the X.509 certificate. This means that the X.509 certificate or an issuer in the certificate chain is in the Trusted People certificate store and that the X.509 certificate is not in the Untrusted Certificates store.  
  
## See Also  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [How to: Create Temporary Certificates for Use During Development](../../../../docs/framework/wcf/feature-details/how-to-create-temporary-certificates-for-use-during-development.md)
