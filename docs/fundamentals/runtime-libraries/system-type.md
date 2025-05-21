---
title: System.Type class
description: Learn about the System.Type class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Type class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Type> class is the root of the <xref:System.Reflection> functionality and is the primary way to access metadata. Use the members of <xref:System.Type> to get information about a type declaration, about the members of a type (such as the constructors, methods, fields, properties, and events of a class), as well as the module and the assembly in which the class is deployed.

No permissions are required for code to use reflection to get information about types and their members, regardless of their access levels. No permissions are required for code to use reflection to access public members, or other members whose access levels would make them visible during normal compilation. However, in order for your code to use reflection to access members that would normally be inaccessible, such as private or internal methods, or protected fields of a type your class does not inherit, your code must have <xref:System.Security.Permissions.ReflectionPermission>. See [Security Considerations for Reflection](../../framework/reflection-and-codedom/security-considerations-for-reflection.md).

`Type` is an abstract base class that allows multiple implementations. The system will always provide the derived class `RuntimeType`. In reflection, all classes beginning with the word Runtime are created only once per object in the system and support comparison operations.

> [!NOTE]
> In multithreading scenarios, do not lock <xref:System.Type> objects in order to synchronize access to `static` data. Other code, over which you have no control, might also lock your class type. This might result in a deadlock. Instead, synchronize access to static data by locking a private `static` object.

> [!NOTE]
> A derived class can access protected members of the calling code's base classes. Also, access is allowed to assembly members of the calling code's assembly. As a rule, if you are allowed access in early-bound code, then you are also allowed access in late-bound code.

> [!NOTE]
> Interfaces that extend other interfaces do not inherit the methods defined in the extended interfaces.

## What types does a Type object represent?

This class is thread safe; multiple threads can concurrently read from an instance of this type. An instance of the <xref:System.Type> class can represent any of the following types:

- Classes
- Value types
- Arrays
- Interfaces
- Enumerations
- Delegates
- Constructed generic types and generic type definitions
- Type arguments and type parameters of constructed generic types, generic type definitions, and generic method definitions

## Retrieve a Type object

The <xref:System.Type> object associated with a particular type can be obtained in the following ways:

- The instance <xref:System.Object.GetType%2A?displayProperty=nameWithType> method returns a <xref:System.Type> object that represents the type of an instance. Because all managed types derive from <xref:System.Object>, the <xref:System.Object.GetType%2A> method can be called on an instance of any type.

  The following example calls the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method to determine the runtime type of each object in an object array.

  :::code language="csharp" source="./snippets/System/Type/Overview/csharp/GetType1.cs" interactive="try-dotnet-method" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Type/Overview/fsharp/GetType1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Type/Overview/vb/GetType1.vb" id="Snippet2":::

- The static <xref:System.Type.GetType%2A?displayProperty=nameWithType> methods return a <xref:System.Type> object that represents a type specified by its fully qualified name.

- The <xref:System.Reflection.Module.GetTypes%2A?displayProperty=nameWithType>, <xref:System.Reflection.Module.GetType%2A?displayProperty=nameWithType>, and <xref:System.Reflection.Module.FindTypes%2A?displayProperty=nameWithType> methods return `Type` objects that represent the types defined in a module. The first method can be used to obtain an array of <xref:System.Type> objects for all the public and private types defined in a module. (You can obtain an instance of `Module` through the <xref:System.Reflection.Assembly.GetModule%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.GetModules%2A?displayProperty=nameWithType> method, or through the <xref:System.Type.Module?displayProperty=nameWithType> property.)

- The <xref:System.Reflection.Assembly?displayProperty=nameWithType> object contains a number of methods to retrieve the classes defined in an assembly, including <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType>, <xref:System.Reflection.Assembly.GetTypes%2A?displayProperty=nameWithType>, and <xref:System.Reflection.Assembly.GetExportedTypes%2A?displayProperty=nameWithType>.

- The <xref:System.Type.FindInterfaces%2A> method returns a filtered list of interface types supported by a type.

- The <xref:System.Type.GetElementType%2A> method returns a `Type` object that represents the element.

- The <xref:System.Type.GetInterfaces%2A> and <xref:System.Type.GetInterface%2A> methods return <xref:System.Type> objects representing the interface types supported by a type.

- The <xref:System.Type.GetTypeArray%2A> method returns an array of <xref:System.Type> objects representing the types specified by an arbitrary set of objects. The objects are specified with an array of type <xref:System.Object>.

- The <xref:System.Type.GetTypeFromProgID%2A> and <xref:System.Type.GetTypeFromCLSID%2A> methods are provided for COM interoperability. They return a <xref:System.Type> object that represents the type specified by a `ProgID` or `CLSID`.

- The <xref:System.Type.GetTypeFromHandle%2A> method is provided for interoperability. It returns a `Type` object that represents the type specified by a class handle.

- The C# `typeof` operator, the C++ `typeid` operator, and the Visual Basic `GetType` operator obtain the `Type` object for a type.

- The <xref:System.Type.MakeGenericType%2A> method returns a <xref:System.Type> object representing a constructed generic type, which is an open constructed type if its <xref:System.Type.ContainsGenericParameters> property returns `true`, and a closed constructed type otherwise. A generic type can be instantiated only if it is closed.

- The <xref:System.Type.MakeArrayType%2A>, <xref:System.Type.MakePointerType%2A>, and <xref:System.Type.MakeByRefType%2A> methods return <xref:System.Type> objects that represent, respectively, an array of a specified type, a pointer to a specified type, and the type of a reference parameter (`ref` in C#, 'byref' in F#, `ByRef` in Visual Basic).

## Compare type objects for equality

A <xref:System.Type> object that represents a type is unique; that is, two <xref:System.Type> object references refer to the same object if and only if they represent the same type. This allows for comparison of <xref:System.Type> objects using reference equality. The following example compares the <xref:System.Type> objects that represent a number of integer values to determine whether they are of the same type.

:::code language="csharp" source="./snippets/System/Type/Overview/csharp/Equals1.cs" interactive="try-dotnet-method" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Type/Overview/fsharp/Equals1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Type/Overview/vb/Equals1.vb" id="Snippet3":::
