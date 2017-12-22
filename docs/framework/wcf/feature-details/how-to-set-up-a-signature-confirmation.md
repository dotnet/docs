---
title: "How to: Set Up a Signature Confirmation"
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
  - "signature confirmation"
  - "WCF, security"
ms.assetid: 2424c137-c7c2-4aa9-8d5d-a066e12fefda
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Set Up a Signature Confirmation
*Signature confirmation* is a mechanism for a message initiator to ensure that a received reply was generated in response to the sender's original message. Signature confirmation is defined in the WS-Security 1.1 specification. If an endpoint supports WS-Security 1.0, you cannot use signature confirmation.  
  
 The following procedures specify how to enable signature confirmation using an <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>. You can use the same procedure with a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>. The procedure builds upon the basic steps found in [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md).  
  
### To enable signature confirmation in code  
  
1.  Create an instance of the <xref:System.ServiceModel.Channels.BindingElementCollection> class.  
  
2.  Create an instance of the  <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> class.  
  
3.  Set the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement.RequireSignatureConfirmation%2A> to `true`.  
  
4.  Add the security element to the binding collection.  
  
5.  Create a custom binding, as specified in [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md).  
  
### To enable signature confirmation in configuration  
  
1.  Add a `<customBinding>` element to the `<bindings>` section of the configuration file.  
  
2.  Add a `<binding>` element and set the name attribute to an appropriate value.  
  
3.  Add an appropriate encoding element. The following example adds a `<TextMessageEncoding>` element.  
  
4.  Add a `<security>` child element and set the `requireSignatureConfirmation` attribute to `true`.  
  
5.  Optional. To enable signature confirmation during the bootstrap, add a [\<secureConversationBootstrap>](../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md) child element and set the `equireSignatureConfirmation` attribute to `true`.  
  
6.  Add an appropriate transport element. The following example adds an [\<httpTransport>](../../../../docs/framework/configure-apps/file-schema/wcf/httptransport.md):  
  
    ```xml  
    <bindings>  
      <customBinding>  
        <binding name="SignatureConfirmationBinding">  
          <security requireSignatureConfirmation="true">  
            <secureConversationBootstrap requireSignatureConfirmation="true" />  
              </security>  
           <textMessageEncoding />  
             <httpTransport />  
        </binding>  
      </customBinding>  
    </bindings>  
    ```  
  
## Example  
 The following code creates an instance of the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> and sets the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement.RequireSignatureConfirmation%2A> property to `true`. Note that this example does not use the `<secureConversationBootstrap>` element shown in the preceding example. This example demonstrates signature confirmation when using a Windows (Kerberos protocol) token. In this case, the signature of the client is returned in all responses from the service and is confirmed by the client.  
  
 [!code-csharp[c_SignatureConfirmation#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_signatureconfirmation/cs/source.cs#1)]
 [!code-vb[c_SignatureConfirmation#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_signatureconfirmation/vb/source.vb#1)]  
  
## See Also  
 <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>  
 <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>  
 <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateMutualCertificateBindingElement%2A>  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md)
