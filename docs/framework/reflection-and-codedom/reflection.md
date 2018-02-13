---
title: "Reflection in the .NET Framework"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "assemblies [.NET Framework], reflection"
  - "EventInfo class, reflection"
  - "common language runtime, reflection"
  - "FieldInfo class, reflection"
  - "ParameterInfo class, reflection"
  - "ConstructorInfo class, reflection"
  - "Assembly class, reflection"
  - "value types, reflection"
  - "reflection, about reflection"
  - "modules, reflection"
  - "runtime, reflection"
  - "Module class, reflection"
  - "MethodInfo class, reflection"
  - "PropertyInfo class, reflection"
  - "type browsers"
  - "reflection"
  - "discovering type information at run time"
  - "type system, reflection"
ms.assetid: d1a58e7f-fb39-4d50-bf84-e3b8f9bf9775
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reflection in the .NET Framework
The classes in the <xref:System.Reflection> namespace, together with <xref:System.Type?displayProperty=nameWithType>, enable you to obtain information about loaded [assemblies](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md) and the types defined within them, such as [classes](http://msdn.microsoft.com/library/ad7d3561-271e-4546-82fc-e00b059f27a9), [interfaces](http://msdn.microsoft.com/library/fd9d5975-5363-4bc9-b883-609f887895e5), and [value types](http://msdn.microsoft.com/library/c9c567f8-8ab1-4d88-834d-00f7d92418de). You can also use reflection to create type instances at run time, and to invoke and access them. For topics about specific aspects of reflection, see [Related Topics](#related_topics) at the end of this overview.  
  
 The [common language runtime](../../../docs/standard/clr.md) loader manages [application domains](../../../docs/framework/app-domains/application-domains.md), which constitute defined boundaries around objects that have the same application scope. This management includes loading each assembly into the appropriate application domain and controlling the memory layout of the type hierarchy within each assembly.  
  
 [Assemblies](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md) contain modules, modules contain types, and types contain members. Reflection provides objects that encapsulate assemblies, modules, and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object. You can then invoke the type's methods or access its fields and properties. Typical uses of reflection include the following:  
  
-   Use <xref:System.Reflection.Assembly> to define and load assemblies, load modules that are listed in the assembly manifest, and locate a type from this assembly and create an instance of it.  
  
-   Use <xref:System.Reflection.Module> to discover information such as the assembly that contains the module and the classes in the module. You can also get all global methods or other specific, nonglobal methods defined on the module.  
  
-   Use <xref:System.Reflection.ConstructorInfo> to discover information such as the name, parameters, access modifiers (such as `public` or `private`), and implementation details (such as `abstract` or `virtual`) of a constructor. Use the <xref:System.Type.GetConstructors%2A> or <xref:System.Type.GetConstructor%2A> method of a <xref:System.Type> to invoke a specific constructor.  
  
-   Use <xref:System.Reflection.MethodInfo> to discover information such as the name, return type, parameters, access modifiers (such as `public` or `private`), and implementation details (such as `abstract` or `virtual`) of a method. Use the <xref:System.Type.GetMethods%2A> or <xref:System.Type.GetMethod%2A> method of a <xref:System.Type> to invoke a specific method.  
  
-   Use <xref:System.Reflection.FieldInfo> to discover information such as the name, access modifiers (such as `public` or `private`) and implementation details (such as `static`) of a field, and to get or set field values.  
  
-   Use <xref:System.Reflection.EventInfo> to discover information such as the name, event-handler data type, custom attributes, declaring type, and reflected type of an event, and to add or remove event handlers.  
  
-   Use <xref:System.Reflection.PropertyInfo> to discover information such as the name, data type, declaring type, reflected type, and read-only or writable status of a property, and to get or set property values.  
  
-   Use <xref:System.Reflection.ParameterInfo> to discover information such as a parameter's name, data type, whether a parameter is an input or output parameter, and the position of the parameter in a method signature.  
  
-   Use <xref:System.Reflection.CustomAttributeData> to discover information about custom attributes when you are working in the reflection-only context of an application domain. <xref:System.Reflection.CustomAttributeData> allows you to examine attributes without creating instances of them.  
  
 The classes of the <xref:System.Reflection.Emit> namespace provide a specialized form of reflection that enables you to build types at run time.  
  
 Reflection can also be used to create applications called type browsers, which enable users to select types and then view the information about those types.  
  
 There are other uses for reflection. Compilers for languages such as JScript use reflection to construct symbol tables. The classes in the <xref:System.Runtime.Serialization> namespace use reflection to access data and to determine which fields to persist. The classes in the <xref:System.Runtime.Remoting> namespace use reflection indirectly through serialization.  
  
## Runtime Types in Reflection  
 Reflection provides classes, such as <xref:System.Type> and <xref:System.Reflection.MethodInfo>, to represent types, members, parameters, and other code entities. However, when you use reflection you don't work directly with these classes, most of which are abstract (`MustInherit` in Visual Basic). Instead, you work with types provided by the common language runtime (CLR).  
  
 For example, when you use the C# `typeof` operator (`GetType` in Visual Basic) to obtain a <xref:System.Type> object, the object is really a `RuntimeType`. `RuntimeType` derives from <xref:System.Type>, and provides implementations of all the abstract methods.  
  
 These runtime classes are `internal` (`Friend` in Visual Basic). They are not documented separately from their base classes, because their behavior is described by the base class documentation.  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Viewing Type Information](../../../docs/framework/reflection-and-codedom/viewing-type-information.md)|Describes the <xref:System.Type> class and provides code examples that illustrate how to use <xref:System.Type> with several reflection classes to obtain information about constructors, methods, fields, properties, and events.|  
|[Reflection and Generic Types](../../../docs/framework/reflection-and-codedom/reflection-and-generic-types.md)|Explains how reflection handles the type parameters and type arguments of generic types and generic methods.|  
|[Security Considerations for Reflection](../../../docs/framework/reflection-and-codedom/security-considerations-for-reflection.md)|Describes the rules that determine to what degree reflection can be used to discover type information and access types.|  
|[Dynamically Loading and Using Types](../../../docs/framework/reflection-and-codedom/dynamically-loading-and-using-types.md)|Describes the reflection custom-binding interface that supports late binding.|  
|[How to: Load Assemblies into the Reflection-Only Context](../../../docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md)|Describes the reflection-only load context. Shows how to load an assembly, how to test the context, and how to examine attributes applied to an assembly in the reflection-only context.|  
|[Accessing Custom Attributes](../../../docs/framework/reflection-and-codedom/accessing-custom-attributes.md)|Demonstrates using reflection to query attribute existence and values.|  
|[Specifying Fully Qualified Type Names](../../../docs/framework/reflection-and-codedom/specifying-fully-qualified-type-names.md)|Describes the format of fully qualified type names in terms of the Backus-Naur form (BNF), and the syntax required for specifying special characters, assembly names, pointers, references, and arrays.|  
|[How to: Hook Up a Delegate Using Reflection](../../../docs/framework/reflection-and-codedom/how-to-hook-up-a-delegate-using-reflection.md)|Explains how to create a delegate for a method and hook the delegate up to an event. Explains how to create an event-handling method at run time using <xref:System.Reflection.Emit.DynamicMethod>.|  
|[Emitting Dynamic Methods and Assemblies](../../../docs/framework/reflection-and-codedom/emitting-dynamic-methods-and-assemblies.md)|Explains how to generate dynamic assemblies and dynamic methods.|  
  
## Reference  
 <xref:System.Type?displayProperty=nameWithType>  
  
 <xref:System.Reflection>  
  
 <xref:System.Reflection.Emit>  
  
