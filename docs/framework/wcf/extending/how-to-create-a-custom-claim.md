---
title: "How to: Create a Custom Claim"
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
ms.assetid: d619976b-eda3-475e-ac23-c7988a2dceb0
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Claim
The Identity Model infrastructure in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a set of built-in claim types and rights with the helper functions for creating <xref:System.IdentityModel.Claims.Claim> instances with those types and rights. These built-in claims are designed to model information found in client credential types that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports by default. In many cases, the built-in claims are sufficient; however some applications may require custom claims. A claim consists of the claim type, the resource for which the claim applies to and the right that is asserted over that resource. This topic describes how to create a custom claim.  
  
### To create a custom claim that is based on a primitive data type  
  
1.  Create a custom claim by passing the claim type, resource value and right to the <xref:System.IdentityModel.Claims.Claim.%23ctor%28System.String%2CSystem.Object%2CSystem.String%29> constructor.  
  
    1.  Decide on a unique value for the claim type.  
  
         The claim type is a unique string identifier. It is the custom claim designer's responsibility to ensure that the string identifier that is used for the claim type is unique. For a list of claim types that are defined by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see the <xref:System.IdentityModel.Claims.ClaimTypes> class.  
  
    2.  Choose the primitive data type and value for the resource.  
  
         A resource is an object. The CLR type of the resource can be a primitive, such as <xref:System.String> or <xref:System.Int32>, or any serializable type. The CLR type of the resource must be serializable, because claims are serialized at various points by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Primitive types are serializable.  
  
    3.  Choose a right that is defined by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] or a unique value for a custom right.  
  
         A right is a unique string identifier. The rights that are defined by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are defined in the <xref:System.IdentityModel.Claims.Rights> class.  
  
         It is the custom claim designer's responsibility to ensure that the string identifier that is used for the right is unique.  
  
         The following code example creates a custom claim with a claim type of `http://example.org/claims/simplecustomclaim`, for a resource named `Driver's License`, and with the <xref:System.IdentityModel.Claims.Rights.PossessProperty%2A> right.  
  
     [!code-csharp[c_CustomClaim#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customclaim/cs/c_customclaim.cs#4)]
     [!code-vb[c_CustomClaim#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customclaim/vb/c_customclaim.vb#4)]  
  
### To create a custom claim that is based on a non-primitive data type  
  
1.  Create a custom claim by passing the claim type, resource value and right to the <xref:System.IdentityModel.Claims.Claim.%23ctor%28System.String%2CSystem.Object%2CSystem.String%29> constructor.  
  
    1.  Decide on a unique value for the claim type.  
  
         The claim type is a unique string identifier. It is the custom claim designer's responsibility to ensure that the string identifier that is used for the claim type is unique. For a list of claim types that are defined by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see the <xref:System.IdentityModel.Claims.ClaimTypes> class.  
  
    2.  Choose or define a serializable non-primitive type for the resource.  
  
         A resource is an object. The CLR type of the resource must be serializable, because claims are serialized at various points by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Primitive types are already serializable.  
  
         When a new type is defined, apply the <xref:System.Runtime.Serialization.DataContractAttribute> to the class. Also apply the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute to the all members of the new type that need to be serialized as part of the claim.  
  
         The following code example defines a custom resource type named `MyResourceType`.  
  
         [!code-csharp[c_CustomClaim#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customclaim/cs/c_customclaim.cs#2)] 
         [!code-vb[c_CustomClaim#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customclaim/vb/c_customclaim.vb#2)]        
  
    3.  Choose a right that is defined by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] or a unique value for a custom right.  
  
         A right is a unique string identifier. The rights that are defined by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are defined in the <xref:System.IdentityModel.Claims.Rights> class.  
  
         It is the custom claim designer's responsibility to ensure that the string identifier that is used for the right is unique.  
  
         The following code example creates a custom claim with a claim type of `http://example.org/claims/complexcustomclaim`, a custom resource type of `MyResourceType`, and with the <xref:System.IdentityModel.Claims.Rights.PossessProperty%2A> right.  
  
         [!code-csharp[c_CustomClaim#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customclaim/cs/c_customclaim.cs#5)] 
         [!code-vb[c_CustomClaim#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customclaim/vb/c_customclaim.vb#5)]     
  
## Example  
 The following code example demonstrates how to create a custom claim with a primitive resource type and a custom claim with a non-primitive resource type.  
  
 [!code-csharp[c_CustomClaim#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customclaim/cs/c_customclaim.cs#0)]
 [!code-vb[c_CustomClaim#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customclaim/vb/c_customclaim.vb#0)]  
  
## See Also  
 <xref:System.IdentityModel.Claims.Claim>  
 <xref:System.IdentityModel.Claims.Rights>  
 <xref:System.IdentityModel.Claims.ClaimTypes>  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)
