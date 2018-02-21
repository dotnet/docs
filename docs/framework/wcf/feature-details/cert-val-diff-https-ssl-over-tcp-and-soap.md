---
title: "Certificate Validation Differences Between HTTPS, SSL over TCP, and SOAP Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "certificates [WCF], validation differences"
ms.assetid: 953a219f-4745-4019-9894-c70704f352e6
caps.latest.revision: 14
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Certificate Validation Differences Between HTTPS, SSL over TCP, and SOAP Security
You can use certificates in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] with message-layer (SOAP) security in addition to transport-layer security (TLS) over HTTP (HTTPS) or TCP. This topic describes differences in the way such certificates are validated.  
  
## Validation of HTTPS Client Certificates  
 When using HTTPS to communicate between a client and a service, the certificate that the client uses to authenticate to the service must support chain trust. That is, it must chain to a trusted root certificate authority. If not, the HTTP layer raises a <xref:System.Net.WebException> with the message "The remote server returned an error: (403) Forbidden." [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] surfaces this exception as a <xref:System.ServiceModel.Security.MessageSecurityException>.  
  
## Validation of HTTPS Service Certificates  
 When using HTTPS to communicate between a client and a service, the certificate that the server authenticates with must support chain trust by default. That is, it must chain to a trusted root certificate authority. No online check is performed to see whether the certificate has been revoked. You can override this behavior by registering a <xref:System.Net.Security.RemoteCertificateValidationCallback> callback, as shown in the following code.  
  
 [!code-csharp[c_CertificateValidationDifferences#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_certificatevalidationdifferences/cs/source.cs#1)] 
 [!code-vb[c_CertificateValidationDifferences#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_certificatevalidationdifferences/vb/source.vb#1)]  
  
 where the signature for `ValidateServerCertificate` is as follows:  
  
 [!code-csharp[c_CertificateValidationDifferences#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_certificatevalidationdifferences/cs/source.cs#2)]
 [!code-vb[c_CertificateValidationDifferences#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_certificatevalidationdifferences/vb/source.vb#2)]  
  
 Implementing `ValidateServerCertificate` can perform any checks that the client application developer deems necessary to validate the service certificate.  
  
## Validation of Client Certificates in SSL over TCP or SOAP Security  
 When using Secure Sockets Layer (SSL) over TCP or message (SOAP) security, client certificates are validated according to the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication.CertificateValidationMode%2A> property value of the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication> class. The property is set to one of the <xref:System.ServiceModel.Security.X509CertificateValidationMode> values. Revocation checking is performed according to the values of the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication.RevocationMode%2A> property value of the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication> class. The property is set to one of the <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode> values.  
  
 [!code-csharp[c_CertificateValidationDifferences#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_certificatevalidationdifferences/cs/source.cs#3)]
 [!code-vb[c_CertificateValidationDifferences#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_certificatevalidationdifferences/vb/source.vb#3)]  
  
## Validation of Service Certificate in SSL over TCP and SOAP Security  
 When using SSL over TCP or (SOAP) message security, service certificates are validated according to the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CertificateValidationMode%2A> property value of the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication> class. The property is set to one of the <xref:System.ServiceModel.Security.X509CertificateValidationMode> values.  
  
 Revocation checking is performed according to the values of the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.RevocationMode%2A> property value of the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication> class. The property is set to one of the <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode> values.  
  
 [!code-csharp[c_CertificateValidationDifferences#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_certificatevalidationdifferences/cs/source.cs#4)]
 [!code-vb[c_CertificateValidationDifferences#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_certificatevalidationdifferences/vb/source.vb#4)]  
  
## See Also  
 <xref:System.Net.Security.RemoteCertificateValidationCallback>  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)
