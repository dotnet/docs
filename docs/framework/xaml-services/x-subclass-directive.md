---
title: "x:Subclass Directive"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "Subclass"
  - "xSubclass"
  - "x:Subclass"
helpviewer_keywords: 
  - "x:Subclass attribute [XAML Services]"
  - "XAML [XAML Services], x:Subclass attribute"
  - "Subclass attribute in XAML [XAML Services]"
ms.assetid: 99f66072-8107-4362-ab99-8171dc83b469
caps.latest.revision: 20
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Subclass Directive
Modifies XAML markup compile behavior when `x:Class` is also provided. Instead of creating a partial class that is based on `x:Class`, the provided `x:Class` is created as an intermediate class, and then your provided derived class is expected to be based on `x:Class`.  
  
## XAML Attribute Usage  
  
```  
<object x:Class="namespace.classname" x:Subclass="subclassNamespace.subclassName">  
   ...  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`namespace`|Optional. Specifies a CLR namespace that contains `classname`. If `namespace` is specified, a dot (.) separates `namespace` and `classname`.|  
|`classname`|Required. Specifies the CLR name of the partial class that connects the loaded XAML and your code-behind for that XAML. See Remarks.|  
|`subclassNamespace`|Optional. Can be different from `namespace` if each namespace can resolve the other. Specifies a CLR namespace that contains `subclassName`. If `subclassName` is specified, a dot (.) separates `subclassNamespace` and `subclassName`.|  
|`subclassName`|Required. Specifies the CLR name of the subclass.|  
  
## Dependencies  
 [x:Class Directive](../../../docs/framework/xaml-services/x-class-directive.md) must also be provided on the same object, and that object must be the root element of the XAML production.  
  
## Remarks  
 `x:Subclass` usage is primarily intended for languages that do not support partial class declarations.  
  
 The class used as the `x:Subclass` cannot be a nested class, and `x:Subclass` must refer to the root object as explained in the "Dependencies" section.  
  
 Otherwise, the conceptual meaning of `x:Subclass` is undefined by a .NET Framework XAML Services implementation. This is because .NET Framework XAML Services behavior does not specify the overall programming model by which XAML markup and backing code are connected. Implementations of further concepts related to `x:Class` and `x:Subclass` are performed by specific frameworks that use programming models or application models to define how to connect XAML markup, compiled markup, and CLR-based code-behind. Each framework might have its own build actions that enable some of the behavior, or specific components that must be included in the build environment. Within a framework, build actions can also vary based on the specific CLR language that is used for the code-behind.  
  
## WPF Usage Notes  
 `x:Subclass` can be on a page root or on the <xref:System.Windows.Application> root in the application definition, which already has `x:Class`. Declaring `x:Subclass` on any element other than a page or application root, or specifying it where no `x:Class` exists, causes a compile-time error.  
  
 Creating derived classes that work correctly for the `x:Subclass` scenario is fairly complex. You might need to examine the intermediate files (the .g files produced in the obj folder of your project by markup compile, with names that incorporate the .xaml file names). These intermediate files can help you determine the origin of certain programming constructs in the joined partial classes in the compiled application.  
  
 Event handlers in the derived class must be `internal override` (`Friend Overrides` in [!INCLUDE[TLA#tla_visualb](../../../includes/tlasharptla-visualb-md.md)]) in order to override the stubs for the handlers as created in the intermediate class during compilation. Otherwise, the derived class implementations hide (shadow) the intermediate class implementation and the intermediate class handlers are not invoked.  
  
 When you define both `x:Class` and `x:Subclass`, you do not need to provide any implementation for the class that is referenced by `x:Class`. You only need to give it a name via the `x:Class` attribute so that the compiler has some guidance for the class that it creates in the intermediate files (the compiler does not select a default name in this case). You can give the `x:Class` class an implementation; however, this is not the typical scenario for using both `x:Class` and `x:Subclass`.  
  
## See Also  
 [x:Class Directive](../../../docs/framework/xaml-services/x-class-directive.md)  
 [XAML and Custom Classes for WPF](../../../docs/framework/wpf/advanced/xaml-and-custom-classes-for-wpf.md)
