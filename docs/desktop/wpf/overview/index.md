---
title: What is Windows Presentation Foundation
description: This article gives an overview about what Windows Presentation Foundation (WPF) is as it relates to .NET Core and what features are provided.
ms.date: 07/18/2019
ms.topic: overview
#Customer intent: As a developer, I want to understand the components of WPF so that I can understand the overall picture of WPF.
---

# What is Windows Presentation Foundation

This article provides a basic overview of Windows Presentation Foundation (WPF) as it relates to .NET Core. WPF for .NET is a UI framework that creates desktop client applications. The WPF development platform supports a broad set of application development features, including an application model, controls, graphics, and data binding. WPF uses the Extensible Application Markup Language (XAML) to provide a declarative model for application programming.

[!INCLUDE [desktop guide under construction](../../../../includes/desktop-guide-wpf-preview-note.md)]

Windows Presentation Foundation (WPF) is only available for the Windows operating system. There are two implementations of WPF.

01. The new open-source implementation hosted on [GitHub](https://github.com/dotnet/wpf). This version runs on .NET Core 3.0. The WPF visual designer for XAML requires, at a minimum, [Visual Studio 2019 16.2 Preview 1](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+desktopguide).

01. The .NET Framework implementation of WPF that is supported by Visual Studio 2019 and Visual Studio 2017.

The WPF Desktop Guide is written for .NET Core 3.0 and WPF. For more information about the existing documentation for WPF with the .NET Framework, see [Framework Windows Presentation Foundation](../../../framework/wpf/index.md).

## XAML

XAML is a declarative XML-based language used by WPF in many ways, such as defining resources or UI elements. Elements defined in XAML represent the instantiation of objects from an assembly. XAML is unlike most other markup languages, which are interpreted at runtime without a direct tie to a backing type system.

The following example shows how you would create a button as part of a UI. This example is intended to give you an idea of how XAML represents an object, where `Button` is the type and `Content` is a property.

```xaml
<StackPanel>
    <Button Content="Click Me!" />
</StackPanel>
```

<!--For more information, see [XAML overview (WPF)][for-more-info-xaml].-->

### XAML extensions

XAML provides syntax for markup extensions. Markup extensions can be used to provide values for properties in attribute form, property-element form, or both.

For example, the previous XAML code defined a button with the visible content set to the literal string `"Click Me!"`, but the content can be instead set by a supported markup extension. A markup extension is defined with opening and closing curly braces `{ }`. The type of markup extension is then identified by the string token immediately following the opening curly brace.

```xaml
<StackPanel>
    <Button Content="{MarkupType}" />
</StackPanel>
```

WPF provides different markup extensions for XAML such as `{Binding}` for data binding.

<!--For more information, see [Markup Extensions and WPF XAML][for-more-info-markup-ext].-->

## Property system

Windows Presentation Foundation (WPF) provides a set of services that can be used to extend the functionality of a type's [property](../../../standard/base-types/common-type-system.md#Properties). Collectively, these services are typically referred to as the *WPF property system*. A property that is backed by the *WPF property system* is known as a dependency property.

Dependency properties extend property functionality by providing the <xref:System.Windows.DependencyProperty> type that backs a property. The dependency property type is an alternative implementation of the standard pattern of backing the property with a private field.

### Dependency property

In Windows Presentation Foundation (WPF), dependency properties are typically exposed as standard .NET [properties](../../../standard/base-types/common-type-system.md#Properties). At a basic level, you could interact with these properties directly and never know that they're implemented as a dependency property.

The purpose of dependency properties is to provide a way to compute the value of a property based on the value of other inputs. These other inputs might include system properties such as themes and user preferences or just-in-time property from data binding and animations.

A dependency property can be implemented to provide validation, default values, callbacks that monitor changes to other properties. Derived classes can also change some specific characteristics of an existing property by overriding dependency property metadata, rather than creating a new property or overriding an existing property.

### Dependency object

Another type that is key to the *WPF property system* is the <xref:System.Windows.DependencyObject>. This type defines the base class that can register and own a dependency property. The <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> methods provide the backing implementation of the dependency property for the dependency object instance.

The following example shows a dependency object that defines a single dependency property identifier named `ValueProperty`. The dependency property is created with the `Value` .NET property.

```csharp
public class TextField: DependencyObject
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(string), typeof(TextField), new PropertyMetadata(""));

    public string Value
    {
        get { return (string)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
}
```

The dependency property is defined as a static member of a dependency object type, such as `TextField` in example above. The dependency property must be registered with the dependency object.

The `Value` property in the example above wraps the dependency property, providing the standard .NET property pattern you're probably used to.

<!--For more information, see [Dependency properties overview][for-more-info-dependency-props].-->

## Events

Windows Presentation Foundation (WPF) provides an eventing system that is layered on top of the .NET common language runtime (CLR) events you're familiar with. These WPF events are called routed events.

A routed event is a CLR event that is backed by an instance of the `RoutedEvent` class and registered with the WPF event system. The `RoutedEvent` instance obtained from event registration is typically retained as a` public static readonly` field member of the class that registers, and thus "owns," the routed event. The connection to the identically named CLR event (which is sometimes termed the "wrapper" event) is accomplished by overriding the `add` and `remove` implementations for the CLR event. The routed event backing and connection mechanism is conceptually similar to how a [dependency property](#dependency-property) is a CLR property that is backed by the `DependencyProperty` class and registered with the WPF property system.

The main advantage of the routed event system is that events are "bubbled" up the control element tree looking for a handler. For example, because WPF has a rich content model, you set an image control as the content of a button control. When the mouse is clicked on the image control, you would expect it to consume the mouse events, and thus break the hit-tests that cause a button to invoke the `Click` event. In a traditional CLR eventing model, you would work around this limitation by attaching the same handler to both the image and the button. But with the routed event system, the mouse events invoked on the image control (like clicking on it) bubble up to the parent button control.

<!--For more information, including other types of event models, see [Events overview][for-more-info-events].-->

## Data binding

Windows Presentation Foundation (WPF) data binding provides a simple and consistent way for applications to present and interact with data. Elements can be bound to data from different kinds of data sources in the form of common language runtime (CLR) objects and XML. WPF also provides a mechanism for the transfer of data through drag-and-drop operations.

Data binding is the process that establishes a connection between the application UI and business logic. If the binding has the correct settings and the data provides the proper notifications, then, when the data changes its value, the elements that bound to the data reflect changes automatically. Data binding can also mean that if an outer representation of the data in an element changes, then the underlying data is automatically updated to reflect the change. For example, if the user edits the value in a TextBox element, the underlying data value is automatically updated to reflect that change.

Data binding can be configured in XAML through the `{Binding}` markup extension. The following example demonstrates binding to a data object's `ButtonText` property. If that binding fails, the value of `Click Me!` is used.

```xaml
<StackPanel>
    <Button Content="{Binding ButtonText, FallbackValue='Click Me!'}" />
</StackPanel>
```

<!--For more information, see [Data Binding Overview][for-more-info-databinding].-->

## UI components

Windows Presentation Foundation (WPF) provides many of the common UI components that are used in almost every Windows application, such as `Button`, `Label`, `TextBox`, `Menu`, and `ListBox`. Historically, these objects have been referred to as controls. While the WPF SDK continues to use the term "control" to loosely mean any class that represents a visible object in an application, it's important to note that a class doesn't need to inherit from the `Control` class to have a visible presence. Classes that inherit from the `Control` class contain a `ControlTemplate`, which allows the consumer of a control to radically change the control's appearance without having to create a new subclass. 

## Styles and templates

Windows Presentation Foundation (WPF) styling and templating refer to a suite of features (styles, templates, triggers, and storyboards) that allow an application, document, or user interface (UI) designer to create visually compelling applications and to standardize on a particular look for their product.

Another feature of the WPF styling model is the separation of presentation and logic. Meaning, designers can work on the appearance of an application with XAML while developers work on the programming logic elsewhere.

In addition, it's important to understand resources, which are what enable styles and templates to be reused.

<!--For more information, see [Styling and Templating][for-more-info-styling].-->

## Resources

Windows Presentation Foundation (WPF) resources are objects that can be reused in different places in your application. Examples of resources include styles, templates, and color brushes. Resources can be both defined and referenced in code and in XAML format.

Every framework-level element (<xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>) has a `Resources` property (which is a <xref:System.Windows.ResourceDictionary> type) that contains defined resources. Since all elements inherit from a framework-level element, all elements can define resources. It's common though to define resources on a root element of a XAML document.

<!--For more information, see [XAML Resources][for-more-info-resources].-->

[for-more-info-markup-ext]: ../../../framework/wpf/advanced/markup-extensions-and-wpf-xaml.md
[for-more-info-xaml]: ../../../framework/wpf/advanced/xaml-overview-wpf.md
[for-more-info-databinding]: ../../../framework/wpf/data/data-binding-overview.md
[for-more-info-styling]: ../../../framework/wpf/controls/styling-and-templating.md
[for-more-info-dependency-props]: ../../../framework/wpf/advanced/dependency-properties-overview.md
[for-more-info-events]: ../../../framework/wpf/advanced/routed-events-overview.md
[for-more-info-resources]: ../../../framework/wpf/advanced/xaml-resources.md