---
title: "x:Property Directive"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 618555a8-c893-455c-810f-ac54cd24ef10
caps.latest.revision: 6
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Property Directive
Declares a XAML property in markup.  
  
## XAML Object Element Usage  
  
```  
<object x:Class="className">  
  <x:Members>  
    <x:Property Name="propertyName" Type="propertyType/>  
    additionalProperties  
  </x:Members>  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`className`|Name of the backing class or partial class for the XAML production.|  
|`propertyName`|Member name of the property being defined.|  
|`propertyType`|Type name (or other string form, framework-specific) that specifies the type of this property.|  
  
## Remarks  
 In the .NET Framework XAML Services implementation, . `x:Property` does not have a direct type backing, but is supported by the <xref:System.Windows.Markup.PropertyDefinition> class. In a XAML node stream, an `x:Property` element is represented as a member named `Property`, from the XAML language XAML namespace. The member `Property` hold attributes as declared by markup.  
  
 The meaning of `Name` and `Type` are not assigned at the .NET Framework XAML Services level. They are stored in the initial XAML node stream as string values, to be interpreted later under the rules that might be imposed by specific frameworks. The meaning might align to a XAML name and XAML type meaning, or might only be valid in a backing type system, depending on the implementation.  
  
 To support a practical usage of `x:Members` as a means to specify member definitions in markup, the members must be associated with a class that can be modified. The intended model is that `x:Members` exists as a member of a type that specifies an `x:Class`. However, the mechanism for associating types and members or for producing dynamic member definitions is not supported at the .NET Framework XAML Services level. This is left to individual frameworks that have application models that support member definitions from XAML. Typically, MSBUILD build actions that markup-compile the XAML and either integrate it with code-behind or produce pure from-XAML assemblies are needed to support that feature.  
  
## x:Property for Windows Workflow Foundation  
 For Windows Workflow Foundation, `x:Property` defines the members of a custom activity composed entirely in XAML, or XAML –defined dynamic members for an activity designer with code-behind. `x:Class` must also be specified on the root element of the XAML production. This is not a requirement at the .NET Framework XAML Services level, but becomes a requirement when the XAML production is loaded by the MSBUILD build actions that support custom activities and Windows Workflow Foundation XAML in general. Windows Workflow Foundation does not use the pure XAML type name as its intended value for the `x:Property` `Type` attribute, and instead uses a convention that is not documented here. For more information, see [Dynamic Activity Creation](http://msdn.microsoft.com/library/dd807392.aspx).
