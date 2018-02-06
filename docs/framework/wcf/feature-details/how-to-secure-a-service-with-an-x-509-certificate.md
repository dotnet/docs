---
title: "How to: Secure a Service with an X.509 Certificate"
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
ms.assetid: 2d06c2aa-d0d7-4e5e-ad7e-77416aa1c10b
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Secure a Service with an X.509 Certificate
Securing a service with an X.509 certificate is a basic technique that most bindings in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] use. This topic walks through the steps of configuring a self-hosted service with an X.509 certificate.  
  
 A prerequisite is a valid certificate that can be used to authenticate the server. The certificate must be issued to the server by a trusted certificate authority. If the certificate is not valid, any client trying to use the service will not trust the service, and consequently no connection will be made. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using certificates, see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
### To configure a service with a certificate using code  
  
1.  Create the service contract and the implemented service. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Designing and Implementing Services](../../../../docs/framework/wcf/designing-and-implementing-services.md).  
  
2.  Create an instance of the <xref:System.ServiceModel.WSHttpBinding> class and set its security mode to <xref:System.ServiceModel.SecurityMode.Message>, as shown in the following code.  
  
     [!code-csharp[C_SecureWithCertificate#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#1)]
     [!code-vb[C_SecureWithCertificate#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#1)]  
  
3.  Create two <xref:System.Type> variables, one each for the contract type and the implemented contract, as shown in the following code.  
  
     [!code-csharp[C_SecureWithCertificate#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#2)]
     [!code-vb[C_SecureWithCertificate#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#2)]  
  
4.  Create an instance of the <xref:System.Uri> class for the base address of the service. Because the `WSHttpBinding` uses the HTTP transport, the Uniform Resource Identifier (URI) must begin with that schema, or [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] will throw an exception when the service is opened.  
  
     [!code-csharp[C_SecureWithCertificate#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#3)]
     [!code-vb[C_SecureWithCertificate#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#3)]  
  
5.  Create a new instance of the <xref:System.ServiceModel.ServiceHost> class with the implemented contract type variable and the URI.  
  
     [!code-csharp[C_SecureWithCertificate#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#4)]
     [!code-vb[C_SecureWithCertificate#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#4)]  
  
6.  Add a <xref:System.ServiceModel.Description.ServiceEndpoint> to the service using the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> method. Pass the contract, binding, and an endpoint address to the constructor, as shown in the following code.  
  
     [!code-csharp[C_SecureWithCertificate#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#5)]
     [!code-vb[C_SecureWithCertificate#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#5)]  
  
7.  Optional. To retrieve metadata from the service, create a new <xref:System.ServiceModel.Description.ServiceMetadataBehavior> object and set the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpGetEnabled%2A> property to `true`.  
  
     [!code-csharp[C_SecureWithCertificate#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#6)]
     [!code-vb[C_SecureWithCertificate#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#6)]  
  
8.  Use the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential> class to add the valid certificate to the service. The method can use one of several methods to find a certificate. This example uses the <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName> enumeration. The enumeration specifies that the supplied value is the name of the entity that the certificate was issued to.  
  
     [!code-csharp[C_SecureWithCertificate#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#7)]
     [!code-vb[C_SecureWithCertificate#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#7)]  
  
9. Call the <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> method to start the service listening. If you are creating a console application, call the <xref:System.Console.ReadLine%2A> method to keep the service in the listening state.  
  
     [!code-csharp[C_SecureWithCertificate#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#8)]
     [!code-vb[C_SecureWithCertificate#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#8)]  
  
## Example  
 The following example uses the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A> method to configure a service with an X.509 certificate.  
  
 [!code-csharp[C_SecureWithCertificate#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewithcertificate/cs/source.cs#9)]
 [!code-vb[C_SecureWithCertificate#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewithcertificate/vb/source.vb#9)]  
  
## Compiling the Code  
 The following namespaces are required to compile the code:  
  
-   <xref:System>  
  
-   <xref:System.ServiceModel>  
  
-   <xref:System.ServiceModel.Channels>  
  
-   <xref:System.Web.Services.Description>  
  
-   <xref:System.Security.Cryptography.X509Certificates>  
  
-   <xref:System.Runtime.Serialization>  
  
## See Also  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)
