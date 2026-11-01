---
title: "Example COM class"
description: Learn how to expose a C# class with properties, methods, and events as a COM object using explicit interfaces and DispId attributes.
ms.date: 11/01/2026
ms.topic: how-to
helpviewer_keywords: 
  - "examples [C#], COM classes"
  - "COM, exposing C# objects to"
---
# Example COM class

The following code demonstrates a practical class exposed as a Component Object Model (COM) object. To expose C# objects to COM clients, declare a class interface, an events interface, and the implementing class.

Class members must follow these rules to be visible to COM:

- The class and its interfaces must be `public`.
- Properties, methods, and events must be `public`.
- Properties and methods must be declared on the class interface and decorated with distinct [`DispId`](<xref:System.Runtime.InteropServices.DispIdAttribute>) values.
- Events must be declared on the event interface and decorated with [`DispId`](<xref:System.Runtime.InteropServices.DispIdAttribute>) values. The event interface must be marked with `[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]`.
- The class must implement the class interface, but it must **not** implement the events interface. Instead, associate the event interface using the [`[ComSourceInterfaces]`](<xref:System.Runtime.InteropServices.ComSourceInterfacesAttribute>) attribute.
- Apply [`[ClassInterface(ClassInterfaceType.None)]`](<xref:System.Runtime.InteropServices.ClassInterfaceAttribute>) to enforce that COM clients interact with your class through your explicit interface rather than an auto-generated class interface.

## Example

The following example defines a `Calculator` COM class that exposes calculations, properties, and completion events to COM clients:

:::code language="csharp" source="./snippets/ExampleCOMClass/ExampleCOM.cs":::

## See also

- [COM interoperability in .NET](../../../standard/native-interop/cominterop.md)
- [Exposing .NET Core components to COM](../../../core/native-interop/expose-components-to-com.md)
- [Interoperability overview](./index.md)
