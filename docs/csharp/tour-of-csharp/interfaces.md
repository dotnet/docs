---
title: C# Interfaces | A tour of the C# language
description: Interfaces define contracts implemented by types in C#
keywords: .NET, csharp, interfaces, multiple inheritance, polymorphism
author: BillWagner
manager: wpickett
ms.date: 2016/08/10
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: a9bf82f4-efd1-4216-bd34-4ef0fa48c968
---

## Interfaces

An ***interface*** defines a contract that can be implemented by classes and structs. An interface can contain methods, properties, events, and indexers. An interface does not provide implementations of the members it defines—it merely specifies the members that must be supplied by classes or structs that implement the interface.

Interfaces may employ ***multiple inheritance***. In the following example, the interface `IComboBox` inherits from both `ITextBox` and `IListBox`.

```csharp
interface IControl
{
	void Paint();
}
interface ITextBox: IControl
{
	void SetText(string text);
}
interface IListBox: IControl
{
	void SetItems(string[] items);
}
interface IComboBox: ITextBox, IListBox {}
```

Classes and structs can implement multiple interfaces. In the following example, the class `EditBox` implements both `IControl` and `IDataBound`.

```csharp
interface IDataBound
{
	void Bind(Binder b);
}
public class EditBox: IControl, IDataBound
{
	public void Paint() {...}
	public void Bind(Binder b) {...}
} 
```

When a class or struct implements a particular interface, instances of that class or struct can be implicitly converted to that interface type. For example

```csharp
EditBox editBox = new EditBox();
IControl control = editBox;
IDataBound dataBound = editBox;
```

In cases where an instance is not statically known to implement a particular interface, dynamic type casts can be used. For example, the following statements use dynamic type casts to obtain an object’s `IControl` and `IDataBound` interface implementations. Because the run-time actual type of the object is `EditBox`, the casts succeed.

```csharp
object obj = new EditBox();
IControl control = (IControl)obj;
IDataBound dataBound = (IDataBound)obj;
```

In the previous `EditBox` class, the `Paint` method from the `IControl` interface and the `Bind` method from the `IDataBound` interface are implemented using public members. C# also supports explicit ***interface member implementations***, using which the class or struct can avoid making the members public. An explicit interface member implementation is written using the fully qualified interface member name. For example, the `EditBox` class could implement the `IControl.Paint` and `IDataBound.Bind` methods using explicit interface member implementations as follows.

```csharp
public class EditBox: IControl, IDataBound
{
	void IControl.Paint() {...}
	void IDataBound.Bind(Binder b) {...}
}
```

Explicit interface members can only be accessed via the interface type. For example, the implementation of `IControl.Paint` provided by the previous EditBox class can only be invoked by first converting the `EditBox` reference to the `IControl` interface type.

```csharp
EditBox editBox = new EditBox();
editBox.Paint();            // Error, no such method
IControl control = editBox;
control.Paint();            // Ok
```

>[!div class="step-by-step"]
[Pre](arrays.md)
[Next](enums.md)
