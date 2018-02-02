---
title: "Understanding Protection Level"
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
  - "WCF, security"
  - "ProtectionLevel property"
ms.assetid: 0c034608-a1ac-4007-8287-b1382eaa8bf2
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Understanding Protection Level
The `ProtectionLevel` property is found on many different classes, such as the <xref:System.ServiceModel.ServiceContractAttribute> and the <xref:System.ServiceModel.OperationContractAttribute> classes. The property controls how a part (or whole) of a message is protected. This topic explains the [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] feature and how it works.  
  
 For instructions on setting the protection level, see [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md).  
  
> [!NOTE]
>  Protection levels can be set only in code, not in configuration.  
  
## Basics  
 To understand the protection level feature, the following basic statements apply:  
  
-   Three basic levels of protection exist for any part of a message. The property (wherever it occurs) is set to one of the <xref:System.Net.Security.ProtectionLevel> enumeration values. In ascending order of protection, they include:  
  
    -   `None`.  
  
    -   `Sign`. The protected part is digitally signed. This ensures detection of any tampering with the protected message part.  
  
    -   `EncryptAndSign`. The message part is encrypted to ensure confidentiality before it is signed.  
  
-   You can set protection requirements only for *application data* with this feature. For example, WS-Addressing headers are infrastructure data and, therefore, are not affected by the `ProtectionLevel`.  
  
-   When the security mode is set to `Transport`, the entire message is protected by the transport mechanism. Therefore, setting a separate protection level for different parts of a message has no effect.  
  
-   The `ProtectionLevel` is a way for the developer to set the *minimum level* that a binding must comply with. When a service is deployed, the actual binding specified in configuration may or may not support the minimum level. For example, by default, the <xref:System.ServiceModel.BasicHttpBinding> class does not supply security (although it can be enabled). Therefore, using it with a contract that has any setting other than `None` will cause an exception to be thrown.  
  
-   If the service requires that the minimum `ProtectionLevel` for all messages is `Sign`, a client (perhaps created by a non-[!INCLUDE[indigo2](../../../includes/indigo2-md.md)] technology) can encrypt and sign all messages (which is more than the minimum required). In this case, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] will not throw an exception because the client has done more than the minimum. Note, however, that [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications (services or clients) will not over-secure a message part if possible but will comply with the minimum level. Also note that when using `Transport` as the security mode, the transport may over-secure the message stream because it is inherently unable to secure at a more granular level.  
  
-   If you set the `ProtectionLevel` explicitly to either `Sign` or `EncryptAndSign`, then you must use a binding with security enabled or an exception will be thrown.  
  
-   If you select a binding that enables security and you do not set the `ProtectionLevel` property anywhere on the contract, all application data will be encrypted and signed.  
  
-   If you select a binding that does not have security enabled (for example, the `BasicHttpBinding` class has security disabled by default), and the `ProtectionLevel` is not explicitly set, then none of the application data will be protected.  
  
-   If you are using a binding that applies security at the transport level, all application data will be secured according to the capabilities of the transport.  
  
-   If you use a binding that applies security at the message level, then application data will be secured according to the protection levels set on the contract. If you do not specify a protection level, then all application data in the messages will be encrypted and signed.  
  
-   The `ProtectionLevel` can be set at different scoping levels. There is a hierarchy associated with scoping, which is explained in the next section.  
  
## Scoping  
 Setting the `ProtectionLevel` on the topmost API sets the level for all levels below it. If the `ProtectionLevel` is set to a different value at a lower level, all APIs below that level in the hierarchy will now be reset to the new level (APIs above it, however, will still be affected by the topmost level). The hierarchy is as follows. Attributes at the same level are peers.  
  
 <xref:System.ServiceModel.ServiceContractAttribute>  
  
 <xref:System.ServiceModel.OperationContractAttribute>  
  
 <xref:System.ServiceModel.FaultContractAttribute>  
  
 <xref:System.ServiceModel.MessageContractAttribute>  
  
 <xref:System.ServiceModel.MessageHeaderAttribute>  
  
 <xref:System.ServiceModel.MessageBodyMemberAttribute>  
  
## Programming ProtectionLevel  
 To program the `ProtectionLevel` at any point in the hierarchy, simply set the property to an appropriate value when applying the attribute. For examples, see [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md).  
  
> [!NOTE]
>  Setting the property on faults and message contracts requires understanding how those features work. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md) and [Using Message Contracts](../../../docs/framework/wcf/feature-details/using-message-contracts.md).  
  
## WS-Addressing Dependency  
 In most cases, using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to generate a client ensures that the client and service contracts are identical. However, seemingly identical contracts can cause the client to throw an exception. This occurs whenever a binding does not support the WS-Addressing specification and multiple levels of protection are specified on the contract. For example, the <xref:System.ServiceModel.BasicHttpBinding> class does not support the specification, or if you create a custom binding that does not support WS-Addressing. The `ProtectionLevel` feature relies on the WS-Addressing specification to enable different protection levels on a single contract. If the binding does not support the WS-Addressing specification, all levels will be set to the same protection level. The effective protection level for all scopes on the contract will be set to the strongest protection level used on the contract.  
  
 This may cause a problem that is hard to debug at first glance. It is possible to create a client contract (an interface) that includes methods for more than one service. That is, the same interface is used to create a client that communicates with many services, and the single interface contains methods for all services. The developer must take care in this rare scenario to invoke only those methods that are applicable for each particular service. If the binding is the <xref:System.ServiceModel.BasicHttpBinding> class, multiple protection levels cannot be supported. However, a service replying to the client might respond to a client with a lower protection level than required. In this case, the client will throw an exception because it expects a higher protection level.  
  
 An example of the code illustrates this problem. The following example shows a service and a client contract. Assume that the binding is the [\<basicHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md) element. Therefore, all operations on a contract have the same protection level. This uniform protection level is determined as the maximum protection level across all operations.  
  
 The service contract is:  
  
 [!code-csharp[c_ProtectionLevel#7](../../../samples/snippets/csharp/VS_Snippets_CFX/c_protectionlevel/cs/source.cs#7)]
 [!code-vb[c_ProtectionLevel#7](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_protectionlevel/vb/source.vb#7)]  
  
 The following code shows the client contract interface. Note that it includes a `Tax` method that is intended to be used with a different service:  
  
 [!code-csharp[c_ProtectionLevel#8](../../../samples/snippets/csharp/VS_Snippets_CFX/c_protectionlevel/cs/source.cs#8)]
 [!code-vb[c_ProtectionLevel#8](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_protectionlevel/vb/source.vb#8)]  
  
 When the client calls the `Price` method, it throws an exception when it receives a reply from the service. This occurs because the client does not specify a `ProtectionLevel` on the `ServiceContractAttribute`, and therefore the client uses the default (<xref:System.Net.Security.ProtectionLevel.EncryptAndSign>) for all methods, including the `Price` method. However, the service returns the value using the <xref:System.Net.Security.ProtectionLevel.Sign> level because the service contract defines a single method that has its protection level set to <xref:System.Net.Security.ProtectionLevel.Sign>. In this case, the client will throw an error when validating the response from the service.  
  
## See Also  
 <xref:System.ServiceModel.ServiceContractAttribute>  
 <xref:System.ServiceModel.OperationContractAttribute>  
 <xref:System.ServiceModel.FaultContractAttribute>  
 <xref:System.ServiceModel.MessageContractAttribute>  
 <xref:System.ServiceModel.MessageHeaderAttribute>  
 <xref:System.ServiceModel.MessageBodyMemberAttribute>  
 <xref:System.Net.Security.ProtectionLevel>  
 [Securing Services](../../../docs/framework/wcf/securing-services.md)  
 [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md)  
 [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)  
 [Using Message Contracts](../../../docs/framework/wcf/feature-details/using-message-contracts.md)
