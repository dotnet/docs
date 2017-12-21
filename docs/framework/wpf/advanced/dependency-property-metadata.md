---
title: "Dependency Property Metadata"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "APIs [WPF], metadata"
  - "dependency properties [WPF], metadata"
  - "metadata [WPF], for dependency properties"
  - "overriding metadata [WPF]"
ms.assetid: d01ed009-b722-41bf-b82f-fe1a8cdc50dd
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Dependency Property Metadata
The [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] property system includes a metadata reporting system that goes beyond what can be reported about a property through reflection or general [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] characteristics. Metadata for a dependency property can also be assigned uniquely by the class that defines a dependency property, can be changed when the dependency property is added to a different class, and can be specifically overridden by all derived classes that inherit the dependency property from the defining base class.  
  
 
  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand dependency properties from the perspective of a consumer of existing dependency properties on [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] classes, and have read the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md). In order to follow the examples in this topic, you should also understand [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] and know how to write [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.  
  
<a name="dp_metadata_contents"></a>   
## How Dependency Property Metadata is Used  
 Dependency property metadata exists as an object that can be queried to examine the characteristics of a dependency property. This metadata is also accessed frequently by the property system as it processes any given dependency property. The metadata object for a dependency property can contain the following types of information:  
  
-   Default value for the dependency property, if no other value can be determined for the dependency property by local value, style, inheritance, etc. For a thorough discussion of how default values participate in the precedence used by the property system when assigning values for dependency properties, see [Dependency Property Value Precedence](../../../../docs/framework/wpf/advanced/dependency-property-value-precedence.md).  
  
-   References to callback implementations that affect coercion or change-notification behaviors on a per-owner-type basis. Note that these callbacks are often defined with a nonpublic access level, so obtaining the actual references from metadata is generally not possible unless the references are within your permitted access scope. For more information on dependency property callbacks, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md).  
  
-   If the dependency property in question is considered to be a WPF framework-level property, the metadata might contain WPF framework-level dependency property characteristics, which report information and state for services such as the WPF framework-level layout engine and property inheritance logic. For more information on this aspect of dependency property metadata, see [Framework Property Metadata](../../../../docs/framework/wpf/advanced/framework-property-metadata.md).  
  
<a name="APIs"></a>   
## Metadata APIs  
 The type that reports most of the metadata information used by the property system is the <xref:System.Windows.PropertyMetadata> class. Metadata instances are optionally specified when dependency properties are registered with the property system, and can be specified again for additional types that either add themselves as owners or override metadata they inherit from the base class dependency property definition. (For cases where a property registration does not specify metadata, a default <xref:System.Windows.PropertyMetadata> is created with default values for that class.)The registered metadata is returned as <xref:System.Windows.PropertyMetadata> when you call the various <xref:System.Windows.DependencyProperty.GetMetadata%2A> overloads that get metadata from a dependency property on a <xref:System.Windows.DependencyObject> instance.  
  
 The <xref:System.Windows.PropertyMetadata> class is then derived from to provide more specific metadata for architectural divisions such as the WPF framework-level classes. <xref:System.Windows.UIPropertyMetadata> adds animation reporting, and <xref:System.Windows.FrameworkPropertyMetadata> provides the WPF framework-level properties mentioned in the previous section. When dependency properties are registered, they can be registered with these <xref:System.Windows.PropertyMetadata> derived classes. When the metadata is examined, the base <xref:System.Windows.PropertyMetadata> type can potentially be cast to the derived classes so that you can examine the more specific properties.  
  
> [!NOTE]
>  The property characteristics that can be specified in <xref:System.Windows.FrameworkPropertyMetadata> are sometimes referred to in this documentation as "flags". When you create new metadata instances for use in dependency property registrations or metadata overrides, you specify these values using the flagwise enumeration <xref:System.Windows.FrameworkPropertyMetadataOptions> and then you supply possibly concatenated values of the enumeration to the <xref:System.Windows.FrameworkPropertyMetadata> constructor. However, once constructed, these option characteristics are exposed within a <xref:System.Windows.FrameworkPropertyMetadata> as a series of Boolean properties rather than the constructing enumeration value. The Boolean properties enable you to check each conditional, rather than requiring you to apply a mask to a flagwise enumeration value to get the information you are interested in. The constructor uses the concatenated <xref:System.Windows.FrameworkPropertyMetadataOptions> in order to keep the length of the constructor signature reasonable, whereas the actual constructed metadata exposes the discrete properties to make querying the metadata more intuitive.  
  
<a name="override_or_subclass"></a>   
## When to Override Metadata, When to Derive a Class  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system has established capabilities for changing some characteristics of dependency properties without requiring them to be entirely re-implemented. This is accomplished by constructing a different instance of property metadata for the dependency property as it exists on a particular type. Note that most existing dependency properties are not virtual properties, so strictly speaking "re-implementing" them on inherited classes could only be accomplished by shadowing the existing member.  
  
 If the scenario you are trying to enable for a dependency property on a type cannot be accomplished by modifying characteristics of existing dependency properties, it might then be necessary to create a derived class, and then to declare a custom dependency property on your derived class. A custom dependency property behaves identically to dependency properties defined by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)]. For more details about custom dependency properties, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md).  
  
 One notable characteristic of a dependency property that you cannot override is its value type. If you are inheriting a dependency property that has the approximate behavior you require, but you require a different type for it, you will have to implement a custom dependency property and perhaps link the properties through type conversion or other implementation on your custom class. Also, you cannot replace an existing <xref:System.Windows.ValidateValueCallback>, because this callback exists in the registration field itself and not within its metadata.  
  
<a name="scenarios"></a>   
## Scenarios for Changing Existing Metadata  
 If you are working with metadata of an existing dependency property, one common scenario for changing dependency property metadata is to change the default value. Changing or adding property system callbacks is a more advanced scenario. You might want to do this if your implementation of a derived class has different interrelationships between dependency properties. One of the conditionals of having a programming model that supports both code and declarative usage is that properties must enable being set in any order. Thus any dependent properties need to be set just-in-time without context and cannot rely on knowing a setting order such as might be found in a constructor. For more information on this aspect of the property system, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md). Note that validation callbacks are not part of the metadata; they are part of the dependency property identifier. Therefore, validation callbacks cannot be changed by overriding the metadata.  
  
 In some cases you might also want to alter the WPF framework-level property metadata options on existing dependency properties. These options communicate certain known conditionals about WPF framework-level properties to other WPF framework-level processes such as the layout system.  Setting the options is generally done only when registering a new dependency property, but it is also possible to change the WPF framework-level property metadata as part of a <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> or <xref:System.Windows.DependencyProperty.AddOwner%2A> call. For the specific values to use and more information, see [Framework Property Metadata](../../../../docs/framework/wpf/advanced/framework-property-metadata.md). For more information that is pertinent to how these options should be set for a newly registered dependency property, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md).  
  
<a name="dp_override_metadata"></a>   
### Overriding Metadata  
 The purpose of overriding metadata is primarily so that you have the opportunity to change the various metadata-derived behaviors that are applied to the dependency property as it exists on your type. The reasons for this are explained in more detail in the [Metadata](#dp_metadata_contents) section. For more information including some code examples, see [Override Metadata for a Dependency Property](../../../../docs/framework/wpf/advanced/how-to-override-metadata-for-a-dependency-property.md).  
  
 Property metadata can be supplied for a dependency property during the registration call (<xref:System.Windows.DependencyProperty.Register%2A>). However, in many cases, you might want to provide type-specific metadata for your class when it inherits that dependency property. You can do this by calling the <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> method.  For an example from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)], the <xref:System.Windows.FrameworkElement> class is the type that first registers the <xref:System.Windows.UIElement.Focusable%2A> dependency property. But the <xref:System.Windows.Controls.Control> class overrides metadata for the dependency property to provide its own initial default value, changing it from `false` to `true`, and otherwise re-uses the original <xref:System.Windows.UIElement.Focusable%2A> implementation.  
  
 When you override metadata, the different metadata characteristics are either merged or replaced.  
  
-   <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> is merged. If you add a new <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A>, that callback is stored in the metadata. If you do not specify a <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> in the override, the value of <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> is promoted as a reference from the nearest ancestor that specified it in metadata.  
  
-   The actual property system behavior for <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> is that implementations for all metadata owners in the hierarchy are retained and added to a table, with order of execution by the property system being that the most derived class's callbacks are invoked first.  
  
-   <xref:System.Windows.PropertyMetadata.DefaultValue%2A> is replaced. If you do not specify a <xref:System.Windows.PropertyMetadata.DefaultValue%2A> in the override, the value of <xref:System.Windows.PropertyMetadata.DefaultValue%2A> comes from the nearest ancestor that specified it in metadata.  
  
-   <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> implementations are replaced. If you add a new <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A>, that callback is stored in the metadata. If you do not specify a <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> in the override, the value of <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> is promoted as a reference from the nearest ancestor that specified it in metadata.  
  
-   The property system behavior is that only the <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> in the immediate metadata is invoked. No references to other <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> implementations in the hierarchy are retained.  
  
 This behavior is implemented by <xref:System.Windows.PropertyMetadata.Merge%2A>, and can be overridden on derived metadata classes.  
  
#### Overriding Attached Property Metadata  
 In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], attached properties are implemented as dependency properties. This means that they also have property metadata, which individual classes can override. The scoping considerations for an attached property in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are generally that any <xref:System.Windows.DependencyObject> can have an attached property set on them. Therefore, any <xref:System.Windows.DependencyObject> derived class can override the metadata for any attached property, as it might be set on an instance of the class. You can override default values, callbacks, or WPF framework-level characteristic-reporting properties. If the attached property is set on an instance of your class, those override property metadata characteristics apply. For instance, you can override the default value, such that your override value is reported as the value of the attached property on instances of your class, whenever the property is not otherwise set.  
  
> [!NOTE]
>  The <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A> property is not relevant for attached properties.  
  
<a name="dp_add_owner"></a>   
### Adding a Class as an Owner of an Existing Dependency Property  
 A class can add itself as an owner of a dependency property that has already been registered, by using the <xref:System.Windows.DependencyProperty.AddOwner%2A> method. This enables the class to use a dependency property that was originally registered for a different type. The adding class is typically not a derived class of the type that first registered that dependency property as owner. Effectively, this allows your class and its derived classes to "inherit" a dependency property implementation without the original owner class and the adding class being in the same true class hierarchy. In addition, the adding class (and all derived classes as well) can then provide type-specific metadata for the original dependency property.  
  
 As well as adding itself as owner through the property system utility methods, the adding class should declare additional public members on itself in order to make the dependency property] a full participant in the property system with exposure to both code and markup. A class that adds an existing dependency property has the same responsibilities as far as exposing the object model for that dependency property as does a class that defines a new custom dependency property. The first such member to expose is a dependency property identifier field. This field should be a `public static readonly` field of type <xref:System.Windows.DependencyProperty>, which is assigned to the return value of the <xref:System.Windows.DependencyProperty.AddOwner%2A> call. The second member to define is the [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] "wrapper" property. The wrapper makes it much more convenient to manipulate your dependency property in code (you avoid calls to <xref:System.Windows.DependencyObject.SetValue%2A> each time, and can make that call only once in the wrapper itself). The wrapper is implemented identically to how it would be implemented if you were registering a custom dependency property. For more information about implementing a dependency property, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md) and [Add an Owner Type for a Dependency Property](../../../../docs/framework/wpf/advanced/how-to-add-an-owner-type-for-a-dependency-property.md).  
  
#### AddOwner and Attached Properties  
 You can call <xref:System.Windows.DependencyProperty.AddOwner%2A> for a dependency property that is defined as an attached property by the owner class. Generally the reason for doing this is to expose the previously attached property as a non-attached dependency property. You then will expose the <xref:System.Windows.DependencyProperty.AddOwner%2A> return value as a `public static readonly` field for use as the dependency property identifier, and will define appropriate "wrapper" properties so that the property appears in the members table and supports a non-attached property usage in your class.  
  
## See Also  
 <xref:System.Windows.PropertyMetadata>  
 <xref:System.Windows.DependencyObject>  
 <xref:System.Windows.DependencyProperty>  
 <xref:System.Windows.DependencyProperty.GetMetadata%2A>  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Framework Property Metadata](../../../../docs/framework/wpf/advanced/framework-property-metadata.md)
