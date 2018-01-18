---
title: "Custom Dependency Properties"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "implementing [WPF], wrappers"
  - "registering properties [WPF]"
  - "properties [WPF], metadata"
  - "metadata [WPF], for properties"
  - "custom dependency properties [WPF]"
  - "properties [WPF], registering"
  - "wrappers [WPF], implementing"
  - "dependency properties [WPF], custom"
ms.assetid: e6bfcfac-b10d-4f58-9f77-a864c2a2938f
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Custom Dependency Properties
This topic describes the reasons that [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application developers and component authors might want to create custom dependency property, and describes the implementation steps as well as some implementation options that can improve performance, usability, or versatility of the property.  
  

  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand dependency properties from the perspective of a consumer of existing dependency properties on [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes, and have read the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md) topic. In order to follow the examples in this topic, you should also understand [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] and know how to write [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.  
  
<a name="whatis"></a>   
## What Is a Dependency Property?  
 You can enable what would otherwise be a [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] property to support styling, data binding, inheritance, animations, and default values by implementing it as a dependency property. Dependency properties are properties that are registered with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system by calling the <xref:System.Windows.DependencyProperty.Register%2A> method (or <xref:System.Windows.DependencyProperty.RegisterReadOnly%2A>), and that are backed by a <xref:System.Windows.DependencyProperty> identifier field. Dependency properties can be used only by <xref:System.Windows.DependencyObject> types, but <xref:System.Windows.DependencyObject> is quite high in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] class hierarchy, so the majority of classes available in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] can support dependency properties. For more information about dependency properties and some of the terminology and conventions used for describing them in this [!INCLUDE[TLA2#tla_sdk](../../../../includes/tla2sharptla-sdk-md.md)], see [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md).  
  
<a name="example_dp"></a>   
## Examples of Dependency Properties  
 Examples of dependency properties that are implemented on [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes include the <xref:System.Windows.Controls.Control.Background%2A> property, the <xref:System.Windows.FrameworkElement.Width%2A> property, and the <xref:System.Windows.Controls.TextBox.Text%2A> property, among many others. Each dependency property exposed by a class has a corresponding public static field of type <xref:System.Windows.DependencyProperty> exposed on that same class. This is the identifier for the dependency property. The identifier is named using a convention: the name of the dependency property with the string `Property` appended to it. For example, the corresponding <xref:System.Windows.DependencyProperty> identifier field for the <xref:System.Windows.Controls.Control.Background%2A> property is <xref:System.Windows.Controls.Control.BackgroundProperty>. The identifier stores the information about the dependency property as it was registered, and the identifier is then used later for other operations involving the dependency property, such as calling <xref:System.Windows.DependencyObject.SetValue%2A>.  
  
 As mentioned in the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md), all dependency properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] (except most attached properties) are also [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] properties because of the "wrapper" implementation. Therefore, from code, you can get or set dependency properties by calling [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] accessors that define the wrappers in the same manner that you would use other [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] properties. As a consumer of established dependency properties, you do not typically use the <xref:System.Windows.DependencyObject> methods <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A>, which are the connection point to the underlying property system. Rather, the existing implementation of the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] properties will have already called <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> within the `get` and `set` wrapper implementations of the property, using the identifier field appropriately. If you are implementing a custom dependency property yourself, then you will be defining the wrapper in a similar way.  
  
<a name="backing_with_dp"></a>   
## When Should You Implement a Dependency Property?  
 When you implement a property on a class, so long as your class derives from <xref:System.Windows.DependencyObject>, you have the option to back your property with a <xref:System.Windows.DependencyProperty> identifier and thus to make it a dependency property. Having your property be a dependency property is not always necessary or appropriate, and will depend on your scenario needs. Sometimes, the typical technique of backing your property with a private field is adequate. However, you should implement your property as a dependency property whenever you want your property to support one or more of the following [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] capabilities:  
  
-   You want your property to be settable in a style. For more information, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
-   You want your property to support data binding. For more information about data binding dependency properties, see [Bind the Properties of Two Controls](../../../../docs/framework/wpf/data/how-to-bind-the-properties-of-two-controls.md).  
  
-   You want your property to be settable with a dynamic resource reference. For more information, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
-   You want to inherit a property value automatically from a parent element in the element tree. In this case, register with the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method, even if you also create a property wrapper for [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] access. For more information, see [Property Value Inheritance](../../../../docs/framework/wpf/advanced/property-value-inheritance.md).  
  
-   You want your property to be animatable. For more information, see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
-   You want the property system to report when the previous value of the property has been changed by actions taken by the property system, the environment, or the user, or by reading and using styles. By using property metadata, your property can specify a callback method that will be invoked each time the property system determines that your property value was definitively changed. A related concept is property value coercion. For more information, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md).  
  
-   You want to use established metadata conventions that are also used by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] processes, such as reporting whether changing a property value should require the layout system to recompose the visuals for an element. Or you want to be able to use metadata overrides so that derived classes can change metadata-based characteristics such as the default value.  
  
-   You want properties of a custom control to receive [!INCLUDE[vs_orcas_long](../../../../includes/vs-orcas-long-md.md)] [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)] support, such as **Properties** window editing. For more information, see [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md).  
  
 When you examine these scenarios, you should also consider whether you can achieve your scenario by overriding the metadata of an existing dependency property, rather than implementing a completely new property. Whether a metadata override is practical depends on your scenario and how closely that scenario resembles the implementation in existing [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] dependency properties and classes. For more information about overriding metadata on existing properties, see [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md).  
  
<a name="checklist"></a>   
## Checklist for Defining a Dependency Property  
 Defining a dependency property consists of four distinct concepts. These concepts are not necessarily strict procedural steps, because some of these end up being combined as single lines of code in the implementation:  
  
-   (Optional) Create property metadata for the dependency property.  
  
-   Register the property name with the property system, specifying an owner type and the type of the property value. Also specify the property metadata, if used.  
  
-   Define a <xref:System.Windows.DependencyProperty> identifier as a `public` `static` `readonly` field on the owner type.  
  
-   Define a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] "wrapper" property whose name matches the name of the dependency property. Implement the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] "wrapper" property's `get` and `set` accessors to connect with the dependency property that backs it.  
  
<a name="registering"></a>   
### Registering the Property with the Property System  
 In order for your property to be a dependency property, you must register that property into a table maintained by the property system, and give it a unique identifier that is used as the qualifier for later property system operations. These operations might be internal operations, or your own code calling property system [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)]. To register the property, you call the <xref:System.Windows.DependencyProperty.Register%2A> method within the body of your class (inside the class, but outside of any member definitions). The identifier field is also provided by the <xref:System.Windows.DependencyProperty.Register%2A> method call, as the return value. The reason that the <xref:System.Windows.DependencyProperty.Register%2A> call is done outside of other member definitions is because you use this return value to assign and create a `public` `static` `readonly` field of type <xref:System.Windows.DependencyProperty> as part of your class. This field becomes the identifier for your dependency property.  
  
 [!code-csharp[WPFAquariumSln#RegisterAG](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#registerag)]
 [!code-vb[WPFAquariumSln#RegisterAG](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#registerag)]  
  
<a name="nameconventions"></a>   
### Dependency Property Name Conventions  
 There are established naming conventions regarding dependency properties that you must follow in all but exceptional circumstances.  
  
 The dependency property itself will have a basic name, "AquariumGraphic" as in this example, which is given as the first parameter of <xref:System.Windows.DependencyProperty.Register%2A>. That name must be unique within each registering type. Dependency properties inherited through base types are considered to be already part of the registering type; names of inherited properties cannot be registered again. However, there is a technique for adding a class as owner of a dependency property even when that dependency property is not inherited; for details, see [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md).  
  
 When you create the identifier field, name this field by the name of the property as you registered it, plus the suffix `Property`. This field is your identifier for the dependency property, and it will be used later as an input for the <xref:System.Windows.DependencyObject.SetValue%2A> and <xref:System.Windows.DependencyObject.GetValue%2A> calls you will make in the wrappers, by any other code access to the property by your own code, by any external code access you allow, by the property system, and potentially by [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processors.  
  
> [!NOTE]
>  Defining the dependency property in the class body is the typical implementation, but it is also possible to define a dependency property in the class static constructor. This approach might make sense if you need more than one line of code to initialize the dependency property.  
  
<a name="wrapper1"></a>   
### Implementing the "Wrapper"  
 Your wrapper implementation should call <xref:System.Windows.DependencyObject.GetValue%2A> in the `get` implementation, and <xref:System.Windows.DependencyObject.SetValue%2A> in the `set` implementation (the original registration call and field are shown here too for clarity).  
  
 In all but exceptional circumstances, your wrapper implementations should perform only the <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> actions, respectively. The reason for this is discussed in the topic [XAML Loading and Dependency Properties](../../../../docs/framework/wpf/advanced/xaml-loading-and-dependency-properties.md).  
  
 All existing public dependency properties that are provided on the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes use this simple wrapper implementation model; most of the complexity of how dependency properties work is either inherently a behavior of the property system, or is implemented through other concepts such as coercion or property change callbacks through property metadata.  
  
 [!code-csharp[WPFAquariumSln#AGWithWrapper](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#agwithwrapper)]
 [!code-vb[WPFAquariumSln#AGWithWrapper](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#agwithwrapper)]  
  
 Again, by convention, the name of the wrapper property must be the same as the name chosen and given as first parameter of the <xref:System.Windows.DependencyProperty.Register%2A> call that registered the property. If your property does not follow the convention, this does not necessarily disable all possible uses, but you will encounter several notable issues:  
  
-   Certain aspects of styles and templates will not work.  
  
-   Most tools and designers must rely on the naming conventions to properly serialize [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], or to provide designer environment assistance at a per-property level.  
  
-   The current implementation of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] loader bypasses the wrappers entirely, and relies on the naming convention when processing attribute values. For more information, see [XAML Loading and Dependency Properties](../../../../docs/framework/wpf/advanced/xaml-loading-and-dependency-properties.md).  
  
<a name="metadata"></a>   
### Property Metadata for a New Dependency Property  
 When you register a dependency property, the registration through the property system creates a metadata object that stores property characteristics. Many of these characteristics have defaults that are set if the property is registered with the simple signatures of <xref:System.Windows.DependencyProperty.Register%2A>. Other signatures of <xref:System.Windows.DependencyProperty.Register%2A> allow you to specify the metadata that you want as you register the property. The most common metadata given for dependency properties is to give them a default value that is applied on new instances that use the property.  
  
 If you are creating a dependency property that exists on a derived class of <xref:System.Windows.FrameworkElement>, you can use the more specialized metadata class <xref:System.Windows.FrameworkPropertyMetadata> rather than the base <xref:System.Windows.PropertyMetadata> class. The constructor for the <xref:System.Windows.FrameworkPropertyMetadata> class has several signatures where you can specify various metadata characteristics in combination. If you want to specify the default value only, use the signature that takes a single parameter of type <xref:System.Object>. Pass that object parameter as a type-specific default value for your property (the default value provided must be the type you provided as the `propertyType` parameter in the <xref:System.Windows.DependencyProperty.Register%2A> call).  
  
 For <xref:System.Windows.FrameworkPropertyMetadata>, you can also specify metadata option flags for your property. These flags are converted into discrete properties on the property metadata after registration and are used to communicate certain conditionals to other processes such as the layout engine.  
  
#### Setting Appropriate Metadata Flags  
  
-   If your property (or changes in its value) affects the [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)], and in particular affects how the layout system should size or render your element in a page, set one or more of the following flags: <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsMeasure>, <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsArrange>, <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsRender>.  
  
    -   <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsMeasure> indicates that a change to this property requires a change to [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] rendering where the containing object might require more or less space within the parent. For example, a "Width" property should have this flag set.  
  
    -   <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsArrange> indicates that a change to this property requires a change to [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] rendering that typically does not require a change in the dedicated space, but does indicate that the positioning within the space has changed. For example, an "Alignment" property should have this flag set.  
  
    -   <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsRender> indicates that some other change has occurred that will not affect layout and measure, but does require another render. An example would be a property that changes a color of an existing element, such as "Background".  
  
    -   These flags are often used as a protocol in metadata for your own override implementations of property system or layout callbacks. For instance, you might have an <xref:System.Windows.DependencyObject.OnPropertyChanged%2A> callback that will call <xref:System.Windows.UIElement.InvalidateArrange%2A> if any property of the instance reports a value change and has <xref:System.Windows.FrameworkPropertyMetadata.AffectsArrange%2A> as `true` in its metadata.  
  
-   Some properties may affect the rendering characteristics of the containing parent element, in ways above and beyond the changes in required size mentioned above. An example is the <xref:System.Windows.Documents.Paragraph.MinOrphanLines%2A> property used in the flow document model, where changes to that property can change the overall rendering of the flow document that contains the paragraph. Use <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsParentArrange> or <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsParentMeasure> to identify similar cases in your own properties.  
  
-   By default, dependency properties support data binding. You can deliberately disable data binding, for cases where there is no realistic scenario for data binding, or where performance in data binding for a large object is recognized as a problem.  
  
-   By default, data binding <xref:System.Windows.Data.Binding.Mode%2A> for dependency properties defaults to <xref:System.Windows.Data.BindingMode.OneWay>. You can always change the binding to be <xref:System.Windows.Data.BindingMode.TwoWay> per binding instance; for details, see [Specify the Direction of the Binding](../../../../docs/framework/wpf/data/how-to-specify-the-direction-of-the-binding.md). But as the dependency property author, you can choose to make the property use <xref:System.Windows.Data.BindingMode.TwoWay> binding mode by default. An example of an existing dependency property is <xref:System.Windows.Controls.MenuItem.IsSubmenuOpen%2A?displayProperty=nameWithType>; the scenario for this property is that the <xref:System.Windows.Controls.MenuItem.IsSubmenuOpen%2A> setting logic and the compositing of <xref:System.Windows.Controls.MenuItem> interact with the default theme style. The <xref:System.Windows.Controls.MenuItem.IsSubmenuOpen%2A> property logic uses data binding natively to maintain the state of the property in accordance to other state properties and method calls. Another example property that binds <xref:System.Windows.Data.BindingMode.TwoWay> by default is <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType>.  
  
-   You can also enable property inheritance in a custom dependency property by setting the <xref:System.Windows.FrameworkPropertyMetadataOptions.Inherits> flag. Property inheritance is useful for a scenario where parent elements and child elements have a property in common, and it makes sense for the child elements to have that particular property value set to the same value as the parent set it. An example inheritable property is <xref:System.Windows.FrameworkElement.DataContext%2A>, which is used for binding operations to enable the important master-detail scenario for data presentation. By making <xref:System.Windows.FrameworkElement.DataContext%2A> inheritable, any child elements inherit that data context also. Because of property value inheritance, you can specify a data context at the page or application root, and do not need to respecify it for bindings in all possible child elements. <xref:System.Windows.FrameworkElement.DataContext%2A> is also a good example to illustrate that inheritance overrides the default value, but it can always be set locally on any particular child element; for details, see [Use the Master-Detail Pattern with Hierarchical Data](../../../../docs/framework/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data.md). Property value inheritance does have a possible performance cost, and thus should be used sparingly; for details, see [Property Value Inheritance](../../../../docs/framework/wpf/advanced/property-value-inheritance.md).  
  
-   Set the <xref:System.Windows.FrameworkPropertyMetadataOptions.Journal> flag to indicate if your dependency property should be detected or used by navigation journaling services. An example is the <xref:System.Windows.Controls.Primitives.Selector.SelectedIndex%2A> property; any item selected in a selection control should be persisted when the journaling history is navigated.  
  
<a name="RODP"></a>   
## Read-Only Dependency Properties  
 You can define a dependency property that is read-only. However, the scenarios for why you might define your property as read-only are somewhat different, as is the procedure for registering them with the property system and exposing the identifier. For more information, see [Read-Only Dependency Properties](../../../../docs/framework/wpf/advanced/read-only-dependency-properties.md).  
  
<a name="CTDP"></a>   
## Collection-Type Dependency Properties  
 Collection-type dependency properties have some additional implementation issues to consider. For details, see [Collection-Type Dependency Properties](../../../../docs/framework/wpf/advanced/collection-type-dependency-properties.md).  
  
<a name="SecurityC"></a>   
## Dependency Property Security Considerations  
 Dependency properties should be declared as public properties. Dependency property identifier fields should be declared as public static fields. Even if you attempt to declare other access levels (such as protected), a dependency property can always be accessed through the identifier in combination with the property system [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)]. Even a protected identifier field is potentially accessible because of metadata reporting or value determination [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] that are part of the property system, such as <xref:System.Windows.LocalValueEnumerator>. For more information, see [Dependency Property Security](../../../../docs/framework/wpf/advanced/dependency-property-security.md).  
  
<a name="DPCtor"></a>   
## Dependency Properties and Class Constructors  
 There is a general principle in managed code programming (often enforced by code analysis tools such as FxCop) that class constructors should not call virtual methods. This is because constructors can be called as base initialization of a derived class constructor, and entering the virtual method through the constructor might occur at an incomplete initialization state of the object instance being constructed. When you derive from any class that already derives from <xref:System.Windows.DependencyObject>, you should be aware that the property system itself calls and exposes virtual methods internally. These virtual methods are part of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system services. Overriding the methods enables derived classes to participate in value determination. To avoid potential issues with runtime initialization, you should not set dependency property values within constructors of classes, unless you follow a very specific constructor pattern. For details, see [Safe Constructor Patterns for DependencyObjects](../../../../docs/framework/wpf/advanced/safe-constructor-patterns-for-dependencyobjects.md).  
  
## See Also  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md)  
 [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md)  
 [Collection-Type Dependency Properties](../../../../docs/framework/wpf/advanced/collection-type-dependency-properties.md)  
 [Dependency Property Security](../../../../docs/framework/wpf/advanced/dependency-property-security.md)  
 [XAML Loading and Dependency Properties](../../../../docs/framework/wpf/advanced/xaml-loading-and-dependency-properties.md)  
 [Safe Constructor Patterns for DependencyObjects](../../../../docs/framework/wpf/advanced/safe-constructor-patterns-for-dependencyobjects.md)
