---
title: "Working with Dynamic Objects (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "dynamic objects [Visual Basic]"
ms.assetid: bdee2a00-07ff-46f9-86dd-fdac9b99cc97
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Working with Dynamic Objects (Visual Basic)
Dynamic objects provide another way, other than the `Object` type, to late bind to an object at run time. A dynamic object exposes members such as properties and methods at run time by using dynamic interfaces that are defined in the <xref:System.Dynamic> namespace. You can use the classes in the <xref:System.Dynamic> namespace to create objects that work with data structures that do not match a static type or format. You can also use the dynamic objects that are defined in dynamic languages such as IronPython and IronRuby. For examples that show how to create dynamic objects or use a dynamic object defined in a dynamic language, see [Walkthrough: Creating and Using Dynamic Objects](../../../../csharp/programming-guide/types/walkthrough-creating-and-using-dynamic-objects.md), <xref:System.Dynamic.DynamicObject>, or <xref:System.Dynamic.ExpandoObject>.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] binds to objects from the dynamic language runtime and dynamic languages such as IronPython and IronRuby by using the <xref:System.Dynamic.IDynamicMetaObjectProvider> interface. Examples of classes that implement the `IDynamicMetaObjectProvider` interface are the <xref:System.Dynamic.DynamicObject> and <xref:System.Dynamic.ExpandoObject> classes.  
  
 If a late-bound call is made to an object that implements the `IDynamicMetaObjectProvider` interface, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] binds to the dynamic object by using that interface. If a late-bound call is made to an object that does not implement the `IDynamicMetaObjectProvider` interface, or if the call to the `IDynamicMetaObjectProvider` interface fails, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] binds to the object by using the late-binding capabilities of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] runtime.  
  
## See Also  
 <xref:System.Dynamic.DynamicObject>  
 <xref:System.Dynamic.ExpandoObject>  
 [Walkthrough: Creating and Using Dynamic Objects](../../../../csharp/programming-guide/types/walkthrough-creating-and-using-dynamic-objects.md)  
 [Early and Late Binding](../../../../visual-basic/programming-guide/language-features/early-late-binding/index.md)
