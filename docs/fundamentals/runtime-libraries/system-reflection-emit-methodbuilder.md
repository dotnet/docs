---
title: System.Reflection.Emit.MethodBuilder class
description: Learn about the System.Reflection.Emit.MethodBuilder class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Reflection.Emit.MethodBuilder class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Reflection.Emit.MethodBuilder> class is used to fully describe a method in common intermediate language (CIL), including the name, attributes, signature, and method body. It is used in conjunction with the <xref:System.Reflection.Emit.TypeBuilder> class to create classes at runtime.

You can use reflection emit to define global methods and to define methods as type members. The APIs that define methods return <xref:System.Reflection.Emit.MethodBuilder> objects.

## Global methods

A global method is defined by using the <xref:System.Reflection.Emit.ModuleBuilder.DefineGlobalMethod%2A?displayProperty=nameWithType> method, which returns a `MethodBuilder` object.

Global methods must be static. If a dynamic module contains global methods, the <xref:System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions%2A?displayProperty=nameWithType> method must be called before persisting the dynamic module or the containing dynamic assembly because the common language runtime postpones fixing up the dynamic module until all global functions have been defined.

A global native method is defined by using the <xref:System.Reflection.Emit.ModuleBuilder.DefinePInvokeMethod%2A?displayProperty=nameWithType> method. Platform invoke (PInvoke) methods must not be declared abstract or virtual. The runtime sets the <xref:System.Reflection.MethodAttributes.PinvokeImpl?displayProperty=nameWithType> attribute for a platform invoke method.

## Methods as members of types

A method is defined as a type member by using the <xref:System.Reflection.Emit.TypeBuilder.DefineMethod%2A?displayProperty=nameWithType> method, which returns a <xref:System.Reflection.Emit.MethodBuilder> object.

The <xref:System.Reflection.Emit.MethodBuilder.DefineParameter%2A> method is used to set the name and parameter attributes of a parameter, or of the return value. The <xref:System.Reflection.Emit.ParameterBuilder> object returned by this method represents a parameter or the return value. The <xref:System.Reflection.Emit.ParameterBuilder> object can be used to set the marshaling, to set the constant value, and to apply custom attributes.

## Attributes

Members of the <xref:System.Reflection.MethodAttributes> enumeration define the precise character of a dynamic method:

- Static methods are specified using the <xref:System.Reflection.MethodAttributes.Static?displayProperty=nameWithType> attribute.
- Final methods (methods that cannot be overridden) are specified using the <xref:System.Reflection.MethodAttributes.Final?displayProperty=nameWithType> attribute.
- Virtual methods are specified using the <xref:System.Reflection.MethodAttributes.Virtual?displayProperty=nameWithType> attribute.
- Abstract methods are specified using the <xref:System.Reflection.MethodAttributes.Abstract?displayProperty=nameWithType> attribute.
- Several attributes determine method visibility. See the description of the <xref:System.Reflection.MethodAttributes> enumeration.
- Methods that implement overloaded operators must set the <xref:System.Reflection.MethodAttributes.SpecialName?displayProperty=nameWithType> attribute.
- Finalizers must set the <xref:System.Reflection.MethodAttributes.SpecialName?displayProperty=nameWithType> attribute.

## Known issues

- Although <xref:System.Reflection.Emit.MethodBuilder> is derived from <xref:System.Reflection.MethodInfo>, some of the abstract methods defined in the <xref:System.Reflection.MethodInfo> class are not fully implemented in <xref:System.Reflection.Emit.MethodBuilder>. These <xref:System.Reflection.Emit.MethodBuilder> methods throw the <xref:System.NotSupportedException>. For example the <xref:System.Reflection.Emit.MethodBuilder.Invoke%2A?displayProperty=nameWithType> method is not fully implemented. You can reflect on these methods by retrieving the enclosing type using the <xref:System.Type.GetType%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType> methods.
- Custom modifiers are supported.
