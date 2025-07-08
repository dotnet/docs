---
title: System.Dynamic.ExpandoObject class
description: Learn about the System.Dynamic.ExpandoObject class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Dynamic.ExpandoObject class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Dynamic.ExpandoObject> class enables you to add and delete members of its instances at run time and also to set and get values of these members. This class supports dynamic binding, which enables you to use standard syntax like `sampleObject.sampleMember` instead of more complex syntax like `sampleObject.GetAttribute("sampleMember")`.

The `ExpandoObject` class implements the standard Dynamic Language Runtime (DLR) interface <xref:System.Dynamic.IDynamicMetaObjectProvider>, which enables you to share instances of the `ExpandoObject` class between languages that support the DLR interoperability model. For example, you can create an instance of the `ExpandoObject` class in C# and then pass it to an IronPython function. For more information, see [Dynamic Language Runtime Overview](../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md) and [Introducing the ExpandoObject](/archive/blogs/csharpfaq/dynamic-in-c-4-0-introducing-the-expandoobject).

The `ExpandoObject` class is an implementation of the dynamic object concept that enables getting, setting, and invoking members. If you want to define types that have their own dynamic dispatch semantics, use the <xref:System.Dynamic.DynamicObject> class. If you want to define how dynamic objects participate in the interoperability protocol and manage DLR fast dynamic dispatch caching, create your own implementation of the <xref:System.Dynamic.IDynamicMetaObjectProvider> interface.

## Create an instance

In C#, to enable late binding for an instance of the `ExpandoObject` class, you must use the `dynamic` keyword. For more information, see [Using Type dynamic](/dotnet/csharp/programming-guide/types/using-type-dynamic).

In Visual Basic, dynamic operations are supported by late binding. For more information, see [Early and Late Binding (Visual Basic)](../../visual-basic/programming-guide/language-features/early-late-binding/index.md).

The following code example demonstrates how to create an instance of the `ExpandoObject` class.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet1":::

## Add new members

You can add properties, methods, and events to instances of the `ExpandoObject` class.

The following code example demonstrates how to add a new property to an instance of the `ExpandoObject` class.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet2":::

The methods represent lambda expressions that are stored as delegates, which can be invoked when they are needed. The following code example demonstrates how to add a method that increments a value of the dynamic property.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet3":::

The following code example demonstrates how to add an event to an instance of the `ExpandoObject` class.

```csharp
class Program
{
    static void Main(string[] args)
    {
        dynamic sampleObject = new ExpandoObject();

        // Create a new event and initialize it with null.
        sampleObject.sampleEvent = null;

        // Add an event handler.
        sampleObject.sampleEvent += new EventHandler(SampleHandler);

        // Raise an event for testing purposes.
        sampleObject.sampleEvent(sampleObject, new EventArgs());
   }

    // Event handler.
    static void SampleHandler(object sender, EventArgs e)
    {
        Console.WriteLine("SampleHandler for {0} event", sender);
    }
}
// This code example produces the following output:
// SampleHandler for System.Dynamic.ExpandoObject event.
```

```vb
Module Module1

Sub Main()
    Dim sampleObject As Object = New ExpandoObject()

    ' Create a new event and initialize it with null.
    sampleObject.sampleEvent = Nothing

    ' Add an event handler.
    Dim handler As EventHandler = AddressOf SampleHandler
    sampleObject.sampleEvent =
        [Delegate].Combine(sampleObject.sampleEvent, handler)

    ' Raise an event for testing purposes.
    sampleObject.sampleEvent.Invoke(sampleObject, New EventArgs())

End Sub

' Event handler.
Sub SampleHandler(ByVal sender As Object, ByVal e As EventArgs)
    Console.WriteLine("SampleHandler for {0} event", sender)
End Sub

' This code example produces the following output:
' SampleHandler for System.Dynamic.ExpandoObject event.

End Module
```

## Pass as a parameter

You can pass instances of the `ExpandoObject` class as parameters. Note that these instances are treated as dynamic objects in C# and late-bound objects in Visual Basic. This means that you do not have IntelliSense for object members and you do not receive compiler errors when you call non-existent members. If you call a member that does not exist, an exception occurs.

The following code example demonstrates how you can create and use a method to print the names and values of properties.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet4":::

## Enumerate and delete members

The `ExpandoObject` class implements the `IDictionary<String, Object>` interface. This enables enumeration of members added to the instance of the `ExpandoObject` class at run time. This can be useful if you do not know at compile time what members an instance might have.

The following code example shows how you can cast an instance of the `ExpandoObject` class to the <xref:System.Collections.Generic.IDictionary%602> interface and enumerate the instance's members.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet5":::

In languages that do not have syntax for deleting members (such as C# and Visual Basic), you can delete a member by implicitly casting an instance of the `ExpandoObject` to the `IDictionary<String, Object>` interface and then deleting the member as a key/value pair. This is shown in the following example.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet6":::

## Receive notifications of property changes

The `ExpandoObject` class implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface and can raise a <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event when a member is added, deleted, or modified. This enables `ExpandoObject` class integration with Windows Presentation Foundation (WPF) data binding and other environments that require notification about changes in the object content.

The following code example demonstrates how to create an event handler for the `PropertyChanged` event.

:::code language="csharp" source="./snippets/System.Dynamic/ExpandoObject/Overview/csharp/program.cs" id="Snippet7":::
:::code language="vb" source="./snippets/System.Dynamic/ExpandoObject/Overview/vb/module1.vb" id="Snippet7":::
