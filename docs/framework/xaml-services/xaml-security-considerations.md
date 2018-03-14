---
title: "XAML Security Considerations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [XAML Services], .NET XAML services"
  - "XAML security [XAML Services]"
ms.assetid: 544296d4-f38e-4498-af49-c9f4dad28964
caps.latest.revision: 7
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAML Security Considerations
This topic describes best practices for security in applications when you use XAML and .NET Framework XAML Services API.  
  
## Untrusted XAML in Applications  
 In the most general sense, untrusted XAML is any XAML source that your application did not specifically include or emit.  
  
 XAML that is compiled into or stored as a `resx`-type resource within a trusted and signed assembly is not inherently untrusted. You can trust the XAML as much as you trust the assembly as a whole. In most cases, you are only concerned with the trust aspects of loose XAML, which is a XAML source that you load from a stream or other IO. Loose XAML is not a specific component or feature of an application model with a deployment and packaging infrastructure. However, an assembly might implement a behavior that involves loading loose XAML.  
  
 For untrusted XAML, you should treat it generally the same as if it were untrusted code. Use sandboxing or other metaphors to prevent possibly untrusted XAML from accessing your trusted code.  
  
 The nature of XAML capabilities gives the XAML the right to construct objects and set their properties. These capabilities also include accessing type converters, mapping and accessing assemblies in the application domain, using markup extensions, `x:Code` blocks, and so on.  
  
 In addition to its language-level capabilities, XAML is used for UI definition in many technologies. Loading untrusted XAML might mean loading a malicious spoofing UI.  
  
## Sharing Context Between Readers and Writers  
 The .NET Framework XAML Services architecture for XAML readers and XAML writers often requires sharing a XAML reader to a XAML writer, or a shared XAML schema context. Sharing objects or contexts might be required if you are writing XAML node loop logic, or providing a custom save path. You should not share XAML reader instances, nondefault XAML schema context, or settings for XAML reader/writer classes between trusted and untrusted code.  
  
 Most scenarios and operations involving XAML object writing for a CLR-based type backing can just use default XAML schema context. The default XAML schema context does not explicitly include settings that could compromise full trust. It is thus safe to share context between trusted and untrusted XAML reader/writer components. However, if you do this, it is still a best practice to keep such readers and writers in separate <xref:System.AppDomain> scopes, with one of them specifically intended/sandboxed for partial trust.  
  
## XAML Namespaces and Assembly Trust  
 The basic unqualified syntax and definition for how XAML interprets a custom XAML namespace mapping to an assembly does not distinguish between a trusted and untrusted assembly as loaded into the application domain. Thus, it is technically possible for an untrusted assembly to spoof a trusted assembly's intended XAML namespace mapping and capture a XAML source's declared object and property information. If you have security requirements to avoid this situation, your intended XAML namespace mapping should be made using one of the following techniques:  
  
-   Use a fully qualified assembly name with strong name in any XAML namespace mapping made by your application's XAML.  
  
-   Restrict assembly mapping to a fixed set of reference assemblies, by constructing a specific <xref:System.Xaml.XamlSchemaContext> for your XAML readers and XAML object writers. See <xref:System.Xaml.XamlSchemaContext.%23ctor%28System.Collections.Generic.IEnumerable%7BSystem.Reflection.Assembly%7D%29>.  
  
## XAML Type Mapping and Type System Access  
 XAML supports its own type system, which in many ways is a peer to how CLR implements the basic CLR type system. However, for certain aspects of type awareness where you are making trust decisions about a type based on its type information, you should defer to the type information in the CLR backing types. This is because some of the specific reporting capabilities of the XAML type system are left open as virtual methods and are therefore, not fully under the control of the original .NET Framework XAML Services implementations. These extensibility points exist because the XAML type system is extensible, to match the extensibility of XAML itself and its possible alternative type-mapping strategies versus the default CLR-backed implementation and default XAML schema context. For more information, see the specific notes on several of the properties of <xref:System.Xaml.XamlType> and <xref:System.Xaml.XamlMember>.  
  
## See Also  
 <xref:System.Xaml.Permissions.XamlAccessLevel>
