---
title: "Reflection in .NET"
titleSuffix: ""
description: Review reflection in .NET. Get information about loaded assemblies and the types defined within them, such as classes, interfaces, structures, and enumerations.
ms.date: 03/27/2024
helpviewer_keywords:
  - "assemblies [.NET], reflection"
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
ms.topic: article
---

# Reflection in .NET

The classes in the <xref:System.Reflection> namespace, together with <xref:System.Type?displayProperty=nameWithType>, enable you to obtain information about loaded [assemblies](../../standard/assembly/index.md) and the types defined within them, such as [classes](../../standard/base-types/common-type-system.md#classes), [interfaces](../../standard/base-types/common-type-system.md#interfaces), and value types (that is, [structures](../../standard/base-types/common-type-system.md#structures) and [enumerations](../../standard/base-types/common-type-system.md#enumerations)). You can also use reflection to create type instances at run time, and to invoke and access them.

[Assemblies](../../standard/assembly/index.md) contain modules, modules contain types, and types contain members. Reflection provides objects that encapsulate assemblies, modules, and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object. You can then invoke the type's methods or access its fields and properties. Typical uses of reflection include the following:

- Use <xref:System.Reflection.Assembly> to define and load assemblies, load modules that are listed in the assembly manifest, and locate a type from this assembly and create an instance of it.
- Use <xref:System.Reflection.Module> to discover information such as the assembly that contains the module and the classes in the module. You can also get all global methods or other specific, non-global methods defined on the module.
- Use <xref:System.Reflection.ConstructorInfo> to discover information such as the name, parameters, access modifiers (such as `public` or `private`), and implementation details (such as `abstract` or `virtual`) of a constructor. Use the <xref:System.Type.GetConstructors%2A> or <xref:System.Type.GetConstructor%2A> method of a <xref:System.Type> to invoke a specific constructor.
- Use <xref:System.Reflection.MethodInfo> to discover information such as the name, return type, parameters, access modifiers, and implementation details (such as `abstract` or `virtual`) of a method. Use the <xref:System.Type.GetMethods%2A> or <xref:System.Type.GetMethod%2A> method of a <xref:System.Type> to invoke a specific method.
- Use <xref:System.Reflection.FieldInfo> to discover information such as the name, access modifiers, and implementation details (such as `static`) of a field, and to get or set field values.
- Use <xref:System.Reflection.EventInfo> to discover information such as the name, event-handler data type, custom attributes, declaring type, and reflected type of an event, and to add or remove event handlers.
- Use <xref:System.Reflection.PropertyInfo> to discover information such as the name, data type, declaring type, reflected type, and read-only or writable status of a property, and to get or set property values.
- Use <xref:System.Reflection.ParameterInfo> to discover information such as a parameter's name, data type, whether a parameter is an input or output parameter, and the position of the parameter in a method signature.
- Use <xref:System.Reflection.CustomAttributeData> to discover information about custom attributes when you are working in the <xref:System.Reflection.MetadataLoadContext> or reflection-only context (.NET Framework). <xref:System.Reflection.CustomAttributeData> allows you to examine attributes without creating instances of them.

The classes of the <xref:System.Reflection.Emit> namespace provide a specialized form of reflection that enables you to build types at run time.

Reflection can also be used to create *type browsers*, which enable users to select types and then view the information about those types.

There are other uses for reflection. Compilers for languages such as JScript use reflection to construct symbol tables. The classes in the <xref:System.Runtime.Serialization> namespace use reflection to access data and to determine which fields to persist. The classes in the <xref:System.Runtime.Remoting> namespace use reflection indirectly through serialization.

## Runtime types in reflection

Reflection provides classes, such as <xref:System.Type> and <xref:System.Reflection.MethodInfo>, to represent types, members, parameters, and other code entities. However, when you use reflection, you don't work directly with these classes, most of which are abstract (`MustInherit` in Visual Basic). Instead, you work with types provided by the common language runtime (CLR).

For example, when you use the C# `typeof` operator (`GetType` in Visual Basic) to obtain a <xref:System.Type> object, the object is really a `RuntimeType`. `RuntimeType` derives from <xref:System.Type> and provides implementations of all the abstract methods.

These runtime classes are `internal` (`Friend` in Visual Basic). They are not documented separately from their base classes, because their behavior is described by the base class documentation.

## Reference

- <xref:System.Type?displayProperty=nameWithType>
- <xref:System.Reflection>
- <xref:System.Reflection.Emit>
