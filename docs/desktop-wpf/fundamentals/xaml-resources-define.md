---
title: Define XAML resources for WPF - .NET Core Desktop Guide
description: Learn about XAML resources in WPF for .NET Core. Understand the types of XAML resources and learn how to define XAML resources.
author: thraka
ms.author: adegeo
ms.date: 08/21/2019
---

# Overview of XAML Resources

A resource is an object that can be reused in different places in your application. Examples of resources include brushes and styles. This overview describes how to use resources in Extensible Application Markup Language (XAML). You can also create and access resources by using code.

> [!NOTE]
> XAML resources described in this article are different from *application resources* which are generally made up files added to an application, such as content, data, or embedded files.

<!-- TODO: File redirect from docs\framework\wpf\advanced\xaml-resources.md -->

[!INCLUDE [desktop guide under construction](../../../includes/desktop-guide-preview-note.md)]

## Using Resources in XAML

The following example defines a <xref:System.Windows.Media.SolidColorBrush> as a resource on the root element of a page. The example then references the resource and uses it to set properties of several child elements, including an <xref:System.Windows.Shapes.Ellipse>, a <xref:System.Windows.Controls.TextBlock>, and a <xref:System.Windows.Controls.Button>.

[!code-xaml[FEResourceSH_snip#XAML](~/samples/snippets/csharp/VS_Snippets_Wpf/FEResourceSH_snip/CS/page1.xaml#xaml)]

Every framework-level element (<xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>) has a <xref:System.Windows.FrameworkElement.Resources%2A> property, which is a <xref:System.Windows.ResourceDictionary> type, that contains defined resources. You can define resources on any element, such as a <xref:System.Windows.Controls.Button>. However, resources are most often defined on the root element, which is <xref:System.Windows.Controls.Page> in the example.

Each resource in a resource dictionary must have a unique key. When you define resources in markup, you assign the unique key through the [x:Key Directive](../../framework/xaml-services/x-key-directive.md). Typically, the key is a string; however, you can also set it to other object types by using the appropriate markup extensions. Non-string keys for resources are used by certain feature areas in WPF, notably for styles, component resources, and data styling.

You can use a defined resource with the resource markup extension syntax that specifies the key name of the resource. For example, use the resource as the value of a property on another element:

[!code-xaml[FEResourceSH_snip#KeyNameUsage](~/samples/snippets/csharp/VS_Snippets_Wpf/FEResourceSH_snip/CS/page2.xaml#keynameusage)]

In the preceding example, when the XAML loader processes the value `{StaticResource MyBrush}` for the <xref:System.Windows.Controls.Control.Background%2A> property on <xref:System.Windows.Controls.Button>, the resource lookup logic first checks the resource dictionary for the <xref:System.Windows.Controls.Button> element. If <xref:System.Windows.Controls.Button> doesn't have a definition of the resource key `MyBrush` (in that example it doesn't; its resource collection is empty), the lookup next checks the parent element of <xref:System.Windows.Controls.Button>, which is <xref:System.Windows.Controls.Page>. If you define a resource on the <xref:System.Windows.Controls.Page> root element, all the elements in the logical tree of the <xref:System.Windows.Controls.Page> can access it. And you can reuse the same resource for setting the value of any property that accepts the same type that the resource represents. In the previous example, the same `MyBrush` resource sets two different properties: the <xref:System.Windows.Controls.Control.Background%2A> of a <xref:System.Windows.Controls.Button>, and the <xref:System.Windows.Shapes.Shape.Fill%2A> of a <xref:System.Windows.Shapes.Rectangle>.

## Static and Dynamic Resources

A resource can be referenced as either static or dynamic. References are created by using either the [StaticResource Markup Extension](../../framework/wpf/advanced/staticresource-markup-extension.md) or the [DynamicResource Markup Extension](../../framework/wpf/advanced/dynamicresource-markup-extension.md). A markup extension is a XAML feature that lets you specify an object reference by having the markup extension process the attribute string and return the object to a XAML loader. For more information about markup extension behavior, see [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md).

When you use a markup extension, you typically provide one or more parameters in string form that are processed by that particular markup extension. The [StaticResource Markup Extension](../../framework/wpf/advanced/staticresource-markup-extension.md) processes a key by looking up the value for that key in all available resource dictionaries. Processing happens during load, which is when the loading process needs to assign the property value. The [DynamicResource Markup Extension](../../framework/wpf/advanced/dynamicresource-markup-extension.md) instead processes a key by creating an expression, and that expression remains unevaluated until the application runs, at which time the expression is evaluated and provides a value.

When you reference a resource, the following considerations can influence whether you use a static resource reference or a dynamic resource reference:

- The overall design of how you create the resources for your application. Is it per page, in the application, in loose XAML, or in a resource-only assembly?
- The application's functionality. Are updating resources in real-time part of your application requirements?
- The respective lookup behavior of that resource reference type.
- The particular property or resource type, and the native behavior of those types.

## Static Resources

Static resource references work best for the following circumstances:

- Your application design concentrates most of its resources into page or application-level resource dictionaries. Static resource references aren't reevaluated based on runtime behaviors, such as reloading a page. So there can be some performance benefit to avoiding large numbers of dynamic resource references when they aren't necessary based on your resource and application design.

- You're setting the value of a property that isn't on a <xref:System.Windows.DependencyObject> or a <xref:System.Windows.Freezable>.

- You're creating a resource dictionary that will be compiled into a DLL and packaged as part of the application or shared between applications.

- You're creating a theme for a custom control and are defining resources that are used within the themes. For this case, you typically do not want the dynamic resource reference lookup behavior; you instead want the static resource reference behavior so that the lookup is predictable and self-contained to the theme. With a dynamic resource reference, even a reference within a theme is left unevaluated until run-time. and there is a chance that when the theme is applied, some local element will redefine a key that your theme is trying to reference, and the local element will fall prior to the theme itself in the lookup. If that happens, your theme will not behave as expected.

- You're using resources to set large numbers of dependency properties. Dependency properties have effective value caching as enabled by the property system, so if you provide a value for a dependency property that can be evaluated at load time, the dependency property doesn't have to check for a reevaluated expression and can return the last effective value. This technique can be a performance benefit.

- You want to change the underlying resource for all consumers, or you want to maintain separate writable instances for each consumer by using the [x:Shared Attribute](../../framework/xaml-services/x-shared-attribute.md).

### Static resource lookup behavior

The following describes the lookup process that automatically happens when a static resource is referenced by a property or element.

01. The lookup process checks for the requested key within the resource dictionary defined by the element that sets the property.

01. The lookup process then traverses the logical tree upward to the parent element and its resource dictionary. This process continues until the root element is reached.

01. Application resources are checked. Application resources are those resources within the resource dictionary that is defined by the <xref:System.Windows.Application> object for your WPF application.

Static resource references from within a resource dictionary must reference a resource that has already been defined lexically before the resource reference. Forward references cannot be resolved by a static resource reference. For this reason, design your resource dictionary structure such that resources are defined at or near the beginning of each respective resource dictionary.

Static resource lookup can extend into themes or into system resources, but this lookup is supported only because the XAML loader defers the request. The deferral is necessary so that the runtime theme at the time the page loads applies properly to the application. However, static resource references to keys that are known to only exist in themes or as system resources aren't recommended, because such references aren't reevaluated if the theme is changed by the user in real time. A dynamic resource reference is more reliable when you request theme or system resources. The exception is when a theme element itself requests another resource. These references should be static resource references, for the reasons mentioned earlier.

The exception behavior if a static resource reference isn't found varies. If the resource was deferred, then the exception occurs at runtime. If the resource was not deferred, the exception occurs at load time.

## Dynamic Resources

Dynamic resources work best for the following circumstances:

- The value of the resource, including system resources, or resources that are otherwise user settable, depends on conditions that aren't known until runtime. For example, you can create setter values that refer to system properties as exposed by <xref:System.Windows.SystemColors>, <xref:System.Windows.SystemFonts>, or <xref:System.Windows.SystemParameters>. These values are truly dynamic because they ultimately come from the runtime environment of the user and operating system. You might also have application-level themes that can change, where page-level resource access must also capture the change.

- You're creating or referencing theme styles for a custom control.

- You intend to adjust the contents of a <xref:System.Windows.ResourceDictionary> during an application lifetime.

- You have a complicated resource structure that has interdependencies, where a forward reference may be required. Static resource references do not support forward references, but dynamic resource references do support them because the resource doesn't need to be evaluated until runtime, and forward references are therefore not a relevant concept.

- You're referencing a resource that is large from the perspective of a compile or working set, and the resource might not be used immediately when the page loads. Static resource references always load from XAML when the page loads. However, a dynamic resource reference doesn't load until it's used.

- You're creating a style where setter values might come from other values that are influenced by themes or other user settings.

- You're applying resources to elements that might be reparented in the logical tree during application lifetime. Changing the parent also potentially changes the resource lookup scope, so if you want the resource for a reparented element to be reevaluated based on the new scope, always use a dynamic resource reference.

### Dynamic resource lookup behavior

Resource lookup behavior for a dynamic resource reference parallels the lookup behavior in your code if you call <xref:System.Windows.FrameworkElement.FindResource%2A> or <xref:System.Windows.FrameworkElement.SetResourceReference%2A>.

01. The lookup checks for the requested key within the resource dictionary defined by the element that sets the property.

    - If the element defines a <xref:System.Windows.FrameworkElement.Style%2A> property, the <xref:System.Windows.FrameworkElement.Style?displayProperty=fullName> of the element has its <xref:System.Windows.Style.Resources> dictionary checked.

    - If the element defines a <xref:System.Windows.Controls.Control.Template%2A> property, the <xref:System.Windows.FrameworkTemplate.Resources?displayProperty=fullName> dictionary of the element is checked.

01. The lookup traverses the logical tree upward to the parent element and its resource dictionary. This process continues until the root element is reached.

01. Application resources are checked. Application resources are those resources within the resource dictionary that are defined by the <xref:System.Windows.Application> object for your WPF application.

01. The theme resource dictionary is checked for the currently active theme. If the theme changes at runtime, the value is reevaluated.

01. System resources are checked.

Exception behavior (if any) varies:

- If a resource was requested by a <xref:System.Windows.FrameworkElement.FindResource%2A> call and was not found, an exception is thrown.

- If a resource was requested by a <xref:System.Windows.FrameworkElement.TryFindResource%2A> call and was not found, no exception is thrown, and the returned value is `null`. If the property being set doesn't accept `null`, then it's still possible that a deeper exception will be thrown, depending on the individual property being set.

- If a resource was requested by a dynamic resource reference in XAML and was not found, then the behavior depends on the general property system. The general behavior is as if no property setting operation occurred at the level where the resource exists. For instance, if you attempt to set the background on an individual button element using a resource that could not be evaluated, then no value set results, but the effective value can still come from other participants in the property system and value precedence. For instance, the background value might still come from a locally defined button style or from the theme style. For properties that aren't defined by theme styles, the effective value after a failed resource evaluation might come from the default value in the property metadata.

### Restrictions

Dynamic resource references have some notable restrictions. At least one of the following conditions must be true:

- The property being set must be a property on a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>. That property must be backed by a <xref:System.Windows.DependencyProperty>.

- The reference is for a value within a `StyleSetter`.

- The property being set must be a property on a <xref:System.Windows.Freezable> that is provided as a value of either a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> property, or a <xref:System.Windows.Setter> value.

Because the property being set must be a <xref:System.Windows.DependencyProperty> or <xref:System.Windows.Freezable> property, most property changes can propagate to the UI because a property change (the changed dynamic resource value) is acknowledged by the property system. Most controls include logic that will force another layout of a control if a <xref:System.Windows.DependencyProperty> changes and that property might affect layout. However, not all properties that have a [DynamicResource Markup Extension](../../framework/wpf/advanced/dynamicresource-markup-extension.md) as their value are guaranteed to provide real time updates in the UI. That functionality still might vary depending on the property, as well as depending on the type that owns the property, or even the logical structure of your application.

## Styles / DataTemplates / Implicit Keys

Although all items in a <xref:System.Windows.ResourceDictionary> must have a key, that doesn't mean that all resources must have an explicit `x:Key`. Several object types support an implicit key when defined as a resource, where the key value is tied to the value of another property. This type of key is known as an implicit key, whereas an `x:Key` attribute is an explicit key. You can overwrite any implicit key by specifying an explicit key.

One important scenario for resources is when you define a <xref:System.Windows.Style>. In fact, a <xref:System.Windows.Style> is almost always defined as an entry in a resource dictionary, because styles are inherently intended for reuse. For more information about styles, see [Styling and Templating](../controls/styling-and-templating.md).

Styles for controls can be both created with and referenced with an implicit key. The theme styles that define the default appearance of a control rely on this implicit key. From the standpoint of requesting it, the implicit key is the <xref:System.Type> of the control itself. From the standpoint of defining the resources, the implicit key is the <xref:System.Windows.Style.TargetType%2A> of the style. Therefore, if you're creating themes for custom controls or creating styles that interact with existing theme styles, you do not need to specify an [x:Key Directive](../../xaml-services/x-key-directive.md) for that <xref:System.Windows.Style>. And if you want to use the themed styles, you do not need to specify any style at all. For instance, the following style definition works, even though the <xref:System.Windows.Style> resource doesn't appear to have a key:

[!code-xaml[FEResourceSH_snip#ImplicitStyle](~/samples/snippets/csharp/VS_Snippets_Wpf/FEResourceSH_snip/CS/page2.xaml#implicitstyle)]

That style really does have a key: the implicit key `typeof(System.Windows.Controls.Button)`. In markup, you can specify a <xref:System.Windows.Style.TargetType%2A> directly as the type name (or you can optionally use [{x:Type...}](../../framework/xaml-services/x-type-markup-extension.md) to return a <xref:System.Type>.

Through the default theme style mechanisms used by WPF, that style is applied as the runtime style of a <xref:System.Windows.Controls.Button> on the page, even though the <xref:System.Windows.Controls.Button> itself doesn't attempt to specify its <xref:System.Windows.FrameworkElement.Style%2A> property or a specific resource reference to the style. Your style defined in the page is found earlier in the lookup sequence than the theme dictionary style, using the same key that the theme dictionary style has. You could just specify `<Button>Hello</Button>` anywhere in the page, and the style you defined with <xref:System.Windows.Style.TargetType%2A> of `Button` would apply to that button. If you want, you can still explicitly key the style with the same type value as <xref:System.Windows.Style.TargetType%2A> for clarity in your markup, but that is optional.

Implicit keys for styles do not apply on a control if <xref:System.Windows.FrameworkElement.OverridesDefaultStyle%2A> is `true`. (Also note that <xref:System.Windows.FrameworkElement.OverridesDefaultStyle%2A> might be set as part of native behavior for the control class, rather than explicitly on an instance of the control.) Also, in order to support implicit keys for derived class scenarios, the control must override <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A> (all existing controls provided as part of WPF include this override). For more information about styles, themes, and control design, see [Guidelines for Designing Stylable Controls](../../framework/wpf/controls/guidelines-for-designing-stylable-controls.md).

<xref:System.Windows.DataTemplate> also has an implicit key. The implicit key for a <xref:System.Windows.DataTemplate> is the <xref:System.Windows.DataTemplate.DataType%2A> property value. <xref:System.Windows.DataTemplate.DataType%2A> can also be specified as the name of the type rather than explicitly using [{x:Type...}](../../framework/xaml-services/x-type-markup-extension.md). For details, see [Data Templating Overview](../../framework/wpf/data/data-templating-overview.md).

## See also

- <xref:System.Windows.ResourceDictionary>
- [Application Resources](../../framework/wpf/advanced/optimizing-performance-application-resources.md)
- [Resources and Code](../../framework/wpf/advanced/resources-and-code.md)
- [Define and Reference a Resource](../../framework/wpf/advanced/how-to-define-and-reference-a-resource.md)
- [Application Management Overview](../../framework/wpf/app-development/application-management-overview.md)
- [x:Type Markup Extension](../../framework/xaml-services/x-type-markup-extension.md)
- [StaticResource Markup Extension](../../framework/wpf/advanced/staticresource-markup-extension.md)
- [DynamicResource Markup Extension](../../framework/wpf/advanced/dynamicresource-markup-extension.md)
