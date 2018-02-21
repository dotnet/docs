---
title: "Attached Properties Overview"
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
  - "attached properties [WPF Designer]"
ms.assetid: 75928354-dc01-47e8-a018-8409aec1f32d
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Attached Properties Overview
An attached property is a concept defined by XAML. An attached property is intended to be used as a type of global property that is settable on any object. In [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)], attached properties are typically defined as a specialized form of dependency property that does not have the conventional property "wrapper".  
  
   
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand dependency properties from the perspective of a consumer of existing dependency properties on [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] classes, and have read the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md). To follow the examples in this topic, you should also understand XAML and know how to write [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.  
  
<a name="attached_properties_usage"></a>   
## Why Use Attached Properties  
 One purpose of an attached property is to allow different child elements to specify unique values for a property that is actually defined in a parent element. A specific application of this scenario is having child elements inform the parent element of how they are to be presented in the [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)]. One example is the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> property. The <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> property is created as an attached property because it is designed to be set on elements that are contained within a <xref:System.Windows.Controls.DockPanel>, rather than on <xref:System.Windows.Controls.DockPanel> itself. The <xref:System.Windows.Controls.DockPanel> class defines the static <xref:System.Windows.DependencyProperty> field named <xref:System.Windows.Controls.DockPanel.DockProperty>, and then provides the <xref:System.Windows.Controls.DockPanel.GetDock%2A> and <xref:System.Windows.Controls.DockPanel.SetDock%2A> methods as public accessors for the attached property.  
  
<a name="attached_properties_xaml"></a>   
## Attached Properties in XAML  
 In XAML, you set attached properties by using the syntax *AttachedPropertyProvider*.*PropertyName*  
  
 The following is an example of how you can set <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> in XAML:  
  
 [!code-xaml[PropertiesOvwSupport#APBasicUsage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page4.xaml#apbasicusage)]  
  
 Note that the usage is somewhat similar to a static property; you always reference the type <xref:System.Windows.Controls.DockPanel> that owns and registers the attached property, rather than referring to any instance specified by name.  
  
 Also, because an attached property in XAML is an attribute that you set in markup, only the set operation has any relevance. You cannot directly get a property in XAML, although there are some indirect mechanisms for comparing values, such as triggers in styles (for details, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)).  
  
### Attached Property Implementation in WPF  
 In [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)], most of the attached properties that exist on [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] types that are related to UI presentation are implemented as dependency properties. Attached properties are a XAML concept, whereas dependency properties are a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] concept. Because [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] attached properties are dependency properties, they support dependency property concepts such as property metadata, and default values from that property metadata.  
  
<a name="howused"></a>   
## How Attached Properties Are Used by the Owning Type  
 Although attached properties are settable on any object, that does not automatically mean that setting the property will produce a tangible result, or that the value will ever be used by another object. Generally, attached properties are intended so that objects coming from a wide variety of possible class hierarchies or logical relationships can each report common information to the type that defines the attached property. The type that defines the attached property typically follows one of these models:  
  
-   The type that defines the attached property is designed so that it can be the parent element of the elements that will set values for the attached property. The type then iterates its child objects through internal logic against some object tree structure, obtains the values, and acts on those values in some manner.  
  
-   The type that defines the attached property will be used as the child element for a variety of possible parent elements and content models.  
  
-   The type that defines the attached property represents a service. Other types set values for the attached property. Then, when the element that set the property is evaluated in the context of the service, the attached property values are obtained through internal logic of the service class.  
  
### An Example of a Parent-Defined Attached Property  
 The most typical scenario where [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] defines an attached property is when a parent element supports a child element collection, and also implements a behavior where the specifics of the behavior are reported individually for each child element.  
  
 <xref:System.Windows.Controls.DockPanel> defines the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> attached property, and <xref:System.Windows.Controls.DockPanel> has class-level code as part of its rendering logic (specifically, <xref:System.Windows.Controls.DockPanel.MeasureOverride%2A> and <xref:System.Windows.Controls.DockPanel.ArrangeOverride%2A>). A <xref:System.Windows.Controls.DockPanel> instance will always check to see whether any of its immediate child elements have set a value for <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType>. If so, those values become input for the rendering logic applied to that particular child element. Nested <xref:System.Windows.Controls.DockPanel> instances each treat their own immediate child element collections, but that behavior is implementation-specific to how <xref:System.Windows.Controls.DockPanel> processes <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> values. It is theoretically possible to have attached properties that influence elements beyond the immediate parent. If the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> attached property is set on an element that has no <xref:System.Windows.Controls.DockPanel> parent element to act upon it, no error or exception is raised. This simply means that a global property value was set, but it has no current <xref:System.Windows.Controls.DockPanel> parent that could consume the information.  
  
<a name="attached_properties_code"></a>   
## Attached Properties in Code  
 Attached properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] do not have the typical [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] "wrapper" methods for easy get/set access. This is because the attached property is not necessarily part of the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] namespace for instances where the property is set. However, a XAML processor must be able to set those values when XAML is parsed. To support an effective attached property usage, the owner type of the attached property must implement dedicated accessor methods in the form `Get`*PropertyName* and `Set`*PropertyName*. These dedicated accessor methods are also useful to get or set the attached property in code. From a code perspective, an attached property is similar to a backing field that has method accessors instead of property accessors, and that backing field can exist on any object rather than needing to be specifically defined.  
  
 The following example shows how you can set an attached property in code. In this example, `myCheckBox` is an instance of the <xref:System.Windows.Controls.CheckBox> class.  
  
 [!code-csharp[PropertiesOvwSupport#APCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page4.xaml.cs#apcode)]
 [!code-vb[PropertiesOvwSupport#APCode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page4.xaml.vb#apcode)]  
  
 Similar to the XAML case, if `myCheckBox` had not already been added as a child element of `myDockPanel` by the third line of code, the fourth line of code would not raise an exception, but the property value would not interact with a <xref:System.Windows.Controls.DockPanel> parent and thus would do nothing. Only a <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> value set on a child element combined with the presence of a <xref:System.Windows.Controls.DockPanel> parent element will cause an effective behavior in the rendered application. (In this case, you could set the attached property, then attach to the tree. Or you could attach to the tree then set the attached property. Either action order provides the same result.)  
  
<a name="attached_properties_metadata"></a>   
## Attached Property Metadata  
 When registering the property, <xref:System.Windows.FrameworkPropertyMetadata> is set to specify characteristics of the property, such as whether the property affects rendering, measurement, and so on. Metadata for an attached property is generally no different than on a dependency property. If you specify a default value in an override to attached property metadata, that value becomes the default value of the implicit attached property on instances of the overriding class. Specifically, your default value is reported if some process queries for the value of an attached property through the `Get` method accessor for that property, specifying an instance of the class where you specified the metadata, and the value for that attached property was otherwise not set.  
  
 If you want to enable property value inheritance on a property, you should use attached properties rather than non-attached dependency properties. For details, see [Property Value Inheritance](../../../../docs/framework/wpf/advanced/property-value-inheritance.md).  
  
<a name="custom"></a>   
## Custom Attached Properties  
  
<a name="create_attached_properties"></a>   
### When to Create an Attached Property  
 You might create an attached property when there is a reason to have a property setting mechanism available for classes other than the defining class. The most common scenario for this is layout. Examples of existing layout properties are <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.Panel.ZIndex%2A?displayProperty=nameWithType>, and <xref:System.Windows.Controls.Canvas.Top%2A?displayProperty=nameWithType>. The scenario enabled here is that elements that exist as child elements to layout-controlling elements are able to express layout requirements to their layout parent elements individually, each setting a property value that the parent defined as an attached property.  
  
 Another scenario for using an attached property is when your class represents a service, and you want classes to be able to integrate the service more transparently.  
  
 Yet another scenario is to receive [!INCLUDE[vs_orcas_long](../../../../includes/vs-orcas-long-md.md)] [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)] support, such as **Properties** window editing. For more information, see [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md).  
  
 As mentioned before, you should register as an attached property if you want to use property value inheritance.  
  
<a name="how_do_i_create_attached_properties"></a>   
### How to Create an Attached Property  
 If your class is defining the attached property strictly for use on other types, then the class does not have to derive from <xref:System.Windows.DependencyObject>. But you do need to derive from <xref:System.Windows.DependencyObject> if you follow the overall [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] model of having your attached property also be a dependency property.  
  
 Define your attached property as a dependency property by declaring a `public` `static` `readonly` field of type <xref:System.Windows.DependencyProperty>. You define this field by using the return value of the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method. The field name must match the attached property name, appended with the string `Property`, to follow the established [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] pattern of naming the identifying fields versus the properties that they represent. The attached property provider must also provide static `Get`*PropertyName* and `Set`*PropertyName* methods as accessors for the attached property; failing to do this will result in the property system being unable to use your attached property.  
  
> [!NOTE]
>  If you omit the attached property's get accessor, data binding on the property will not work in design tools, such as [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] and Expression Blend.  
  
#### The Get Accessor  
 The signature for the `Get`*PropertyName* accessor must be:  
  
 `public static object Get` *PropertyName* `(object`  `target` `)`  
  
-   The `target` object can be specified as a more specific type in your implementation. For example, the <xref:System.Windows.Controls.DockPanel.GetDock%2A?displayProperty=nameWithType> method types the parameter as <xref:System.Windows.UIElement>, because the attached property is only intended to be set on <xref:System.Windows.UIElement> instances.  
  
-   The return value can be specified as a more specific type in your implementation. For example, the <xref:System.Windows.Controls.DockPanel.GetDock%2A> method types it as <xref:System.Windows.Controls.Dock>, because the value can only be set to that enumeration.  
  
#### The Set Accessor  
 The signature for the `Set`*PropertyName* accessor must be:  
  
 `public static void Set` *PropertyName* `(object`  `target` `, object`  `value` `)`  
  
-   The `target` object can be specified as a more specific type in your implementation. For example, the <xref:System.Windows.Controls.DockPanel.SetDock%2A> method types it as <xref:System.Windows.UIElement>, because the attached property is only intended to be set on <xref:System.Windows.UIElement> instances.  
  
-   The `value` object can be specified as a more specific type in your implementation. For example, the <xref:System.Windows.Controls.DockPanel.SetDock%2A> method types it as <xref:System.Windows.Controls.Dock>, because the value can only be set to that enumeration. Remember that the value for this method is the input coming from the XAML loader when it encounters your attached property in an attached property usage in markup. That input is the value specified as a XAML attribute value in markup. Therefore there must be type conversion, value serializer, or markup extension support for the type you use, such that the appropriate type can be created from the attribute value (which is ultimately just a string).  
  
 The following example shows the dependency property registration (using the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method), as well as the `Get`*PropertyName* and `Set`*PropertyName* accessors. In the example, the attached property name is `IsBubbleSource`. Therefore, the accessors must be named `GetIsBubbleSource` and `SetIsBubbleSource`.  
  
 [!code-csharp[WPFAquariumSln#RegisterAttachedBubbler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#registerattachedbubbler)]
 [!code-vb[WPFAquariumSln#RegisterAttachedBubbler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#registerattachedbubbler)]  
  
#### Attached Property Attributes  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] defines several [!INCLUDE[TLA2#tla_netframewkattr#plural](../../../../includes/tla2sharptla-netframewkattrsharpplural-md.md)] that are intended to provide information about attached properties to reflection processes, and to typical users of reflection and property information such as designers. Because attached properties have a type of unlimited scope, designers need a way to avoid overwhelming users with a global list of all the attached properties that are defined in a particular technology implementation that uses XAML. The [!INCLUDE[TLA2#tla_netframewkattr#plural](../../../../includes/tla2sharptla-netframewkattrsharpplural-md.md)] that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] defines for attached properties can be used to scope the situations where a given attached property should be shown in a properties window. You might consider applying these attributes for your own custom attached properties also. The purpose and syntax of the [!INCLUDE[TLA2#tla_netframewkattr#plural](../../../../includes/tla2sharptla-netframewkattrsharpplural-md.md)] is described on the appropriate reference pages:  
  
-   <xref:System.Windows.AttachedPropertyBrowsableAttribute>  
  
-   <xref:System.Windows.AttachedPropertyBrowsableForChildrenAttribute>  
  
-   <xref:System.Windows.AttachedPropertyBrowsableForTypeAttribute>  
  
-   <xref:System.Windows.AttachedPropertyBrowsableWhenAttributePresentAttribute>  
  
<a name="more"></a>   
## Learning More About Attached Properties  
  
-   For more information on creating an attached property, see [Register an Attached Property](../../../../docs/framework/wpf/advanced/how-to-register-an-attached-property.md).  
  
-   For more advanced usage scenarios for dependency properties and attached properties, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md).  
  
-   You can also register a property as an attached property, and as a dependency property, but then still expose "wrapper" implementations. In this case, the property can be set either on that element, or on any element through the XAML attached property syntax. An example of a property with an appropriate scenario for both standard and attached usages is <xref:System.Windows.FrameworkElement.FlowDirection%2A?displayProperty=nameWithType>.  
  
## See Also  
 <xref:System.Windows.DependencyProperty>  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Register an Attached Property](../../../../docs/framework/wpf/advanced/how-to-register-an-attached-property.md)
