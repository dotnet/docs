---
title: System.Reflection.Emit.TypeBuilder class
description: Learn about the System.Reflection.Emit.TypeBuilder class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Reflection.Emit.TypeBuilder class

[!INCLUDE [context](includes/context.md)]

<xref:System.Reflection.Emit.TypeBuilder> is the root class used to control the creation of dynamic classes in the runtime. It provides a set of routines that are used to define classes, add methods and fields, and create the class inside a module. A new <xref:System.Reflection.Emit.TypeBuilder> can be created from a dynamic module by calling the <xref:System.Reflection.Emit.ModuleBuilder.DefineType%2A?displayProperty=nameWithType> method, which returns a <xref:System.Reflection.Emit.TypeBuilder> object.

Reflection emit provides the following options for defining types:

- Define a class or interface with the given name.
- Define a class or interface with the given name and attributes.
- Define a class with the given name, attributes, and base class.
- Define a class with the given name, attributes, base class, and the set of interfaces that the class implements.
- Define a class with the given name, attributes, base class, and packing size.
- Define a class with the given name, attributes, base class, and the class size as a whole.
- Define a class with the given name, attributes, base class, packing size, and the class size as a whole.

To create an array type, pointer type, or byref type for an incomplete type that is represented by a <xref:System.Reflection.Emit.TypeBuilder> object, use the <xref:System.Reflection.Emit.TypeBuilder.MakeArrayType%2A> method, <xref:System.Reflection.Emit.TypeBuilder.MakePointerType%2A> method, or <xref:System.Reflection.Emit.TypeBuilder.MakeByRefType%2A> method, respectively.

Before a type is used, the <xref:System.Reflection.Emit.TypeBuilder.CreateType%2A?displayProperty=nameWithType> method must be called. **CreateType** completes the creation of the type. Following the call to **CreateType**, the caller can instantiate the type by using the <xref:System.Activator.CreateInstance%2A?displayProperty=nameWithType> method, and invoke members of the type by using the <xref:System.Type.InvokeMember%2A?displayProperty=nameWithType> method. It is an error to invoke methods that change the implementation of a type after **CreateType** has been called. For example, the common language runtime throws an exception if the caller tries to add new members to a type.

A class initializer is created by using the <xref:System.Reflection.Emit.TypeBuilder.DefineTypeInitializer%2A?displayProperty=nameWithType> method. **DefineTypeInitializer** returns a <xref:System.Reflection.Emit.ConstructorBuilder> object.

Nested types are defined by calling one of the <xref:System.Reflection.Emit.TypeBuilder.DefineNestedType%2A?displayProperty=nameWithType> methods.

## Attributes

The <xref:System.Reflection.Emit.TypeBuilder> class uses the <xref:System.Reflection.TypeAttributes> enumeration to further specify the characteristics of the type to be created:

- Interfaces are specified using the <xref:System.Reflection.TypeAttributes.Interface?displayProperty=nameWithType> and <xref:System.Reflection.TypeAttributes.Abstract?displayProperty=nameWithType> attributes.
- Concrete classes (classes that cannot be extended) are specified using the <xref:System.Reflection.TypeAttributes.Sealed?displayProperty=nameWithType> attribute.
- Several attributes determine type visibility. See the description of the <xref:System.Reflection.TypeAttributes> enumeration.
- If <xref:System.Reflection.TypeAttributes.SequentialLayout?displayProperty=nameWithType> is specified, the class loader lays out fields in the order they are read from metadata. The class loader considers the specified packing size but ignores any specified field offsets. The metadata preserves the order in which the field definitions are emitted. Even across a merge, the metadata will not reorder the field definitions. The loader will honor the specified field offsets only if <xref:System.Reflection.TypeAttributes.ExplicitLayout?displayProperty=nameWithType> is specified.

## Known issues

- Reflection emit does not verify whether a non-abstract class that implements an interface has implemented all the methods declared in the interface. However, if the class does not implement all the methods declared in an interface, the runtime does not load the class.
- Although <xref:System.Reflection.Emit.TypeBuilder> is derived from <xref:System.Type>, some of the abstract methods defined in the <xref:System.Type> class are not fully implemented in the <xref:System.Reflection.Emit.TypeBuilder> class. Calls to these <xref:System.Reflection.Emit.TypeBuilder> methods throw a <xref:System.NotSupportedException> exception. The desired functionality can be obtained by retrieving the created type using the <xref:System.Type.GetType%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType> and reflecting on the retrieved type.
