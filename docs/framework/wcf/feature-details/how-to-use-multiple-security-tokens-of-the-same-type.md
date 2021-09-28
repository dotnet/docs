---
description: "Learn more about: How to: Use Multiple Security Tokens of the Same Type"
title: "How to: Use Multiple Security Tokens of the Same Type"
ms.date: "03/30/2017"
ms.assetid: cf179f48-4ed4-4caa-86a5-ef8eecc231cd
---
# How to: Use Multiple Security Tokens of the Same Type

- In .NET Framework 3.0, a client message only contained one token of any given type. Now client messages can contain multiple tokens of a type. This topic shows how to include multiple tokens of the same type in a client message.  
  
- Note that you cannot configure a service in this way: a service can contain only one supporting token.  
  
### To use multiple security tokens of the same type  
  
1. Create an empty binding element collection to be populated.  
  
     [!code-csharp[C_CustomBinding#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#9)]  
  
2. Create a <xref:System.ServiceModel.Channels.SecurityBindingElement> by calling <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateMutualCertificateBindingElement%2A>.  
  
     [!code-csharp[C_CustomBinding#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#10)]  
  
3. Create a <xref:System.ServiceModel.Security.Tokens.SupportingTokenParameters> collection.  
  
     [!code-csharp[C_CustomBinding#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#11)]  
  
4. Add SAML tokens to the collection.  
  
     [!code-csharp[C_CustomBinding#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#12)]  
  
5. Add the collection to the <xref:System.ServiceModel.Channels.SecurityBindingElement>.  
  
     [!code-csharp[C_CustomBinding#13](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#13)]  
  
6. Add binding elements to the binding element collection.  
  
     [!code-csharp[C_CustomBinding#14](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#14)]  
  
7. Return a new custom binding created from the binding element collection.  
  
     [!code-csharp[C_CustomBinding#15](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#15)]  
  
## Example  

 The following is the entire method described by the preceding procedure.  
  
 [!code-csharp[C_CustomBinding#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombinding/cs/c_custombinding.cs#7)]  
