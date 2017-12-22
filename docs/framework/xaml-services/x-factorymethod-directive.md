---
title: "x:FactoryMethod Directive"
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
  - "XAML. x:FactoryMethod directive [XAML Services]"
  - "FactoryMethod directive in XAML [XAML Services]"
  - "x:FactoryMethod directive [XAML Services]"
ms.assetid: 829bcbdf-5318-4afb-9a03-c310e0d2f23d
caps.latest.revision: 8
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:FactoryMethod Directive
Specifies a method other than a constructor that a XAML processor should use to initialize an object after resolving its backing type.  
  
## XAML Attribute Usage, no x:Arguments  
  
```  
<object x:FactoryMethod="methodname"...>  
  ...  
</object>  
```  
  
## XAML Attribute Usage, x:Arguments as Element(s)  
  
```  
<object x:FactoryMethod="methodname"...>  
  <x:Arguments>  
    oneOrMoreObjectElements  
  </x:Arguments>  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`methodname`|The string method name of a method that XAML processors call to initialize the instance specified as `object`. See Remarks.|  
|`oneOrMoreObjectElements`|One or more object elements for objects that specify factory method parameters. Order is significant; it signifies the order in which arguments should be passed to the factory method.|  
  
## Remarks  
 If `methodname` is an instance method, it cannot be qualified.  
  
 Static methods as factory methods are supported. If `methodname` is a static method, `methodname` is provided as a *typeName*.*methodName* combination, where *typeName* names the class that defines the static factory method. *typeName* can be prefix-qualified if referring to a type in a mapped xmlns. *typeName* can be a different type than `typeof(``object``)`.  
  
 The factory method must be a declared public method of the type that backs the relevant object element.  
  
 The factory method must return an instance that is assignable to the relevant object. Factory methods should never return null.  
  
 `x:Arguments` operates on a principle of best match for signatures of factory methods. Matching evaluates the parameter count first. If there is more than one possible match for a parameter count, parameter type is then evaluated and best match is determined. If there is still ambiguity after this phase of evaluation, XAML processor behavior is undefined.  
  
 The `x:FactoryMethod` element usage is not property element usage in the typical sense, because the directive markup does not reference the containing object element's type. It is expected that element usage is less common than attribute usage. `x:Arguments` (either attribute or element usage) can be used along with `x:FactoryMethod` element usage, but this is not specifically shown in the Usage sections.  
  
 `x:FactoryMethod` as an element must precede any other property elements, must precede any `x:Arguments` also provided as elements, and must precede any content/inner text/initialization text.  
  
## See Also  
 [x:Arguments Directive](../../../docs/framework/xaml-services/x-arguments-directive.md)
