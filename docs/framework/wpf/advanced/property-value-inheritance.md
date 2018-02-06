---
title: "Property Value Inheritance"
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
  - "inheritance [WPF], property values"
  - "value inheritance [WPF]"
  - "properties [WPF], value inheritance"
ms.assetid: d7c338f9-f2bf-48ed-832c-7be58ac390e4
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Property Value Inheritance
Property value inheritance is a feature of the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] property system. Property value inheritance enables child elements in a tree of elements to obtain the value of a particular property from parent elements, inheriting that value as it was set anywhere in the nearest parent element. The parent element might also have obtained its value through property value inheritance, so the system potentially recurses all the way to the page root. Property value inheritance is not the default property system behavior; a property must be established with a particular metadata setting in order to cause that property to initiate property value inheritance on child elements.  
  

  
<a name="Property_Value_Inheritance_is_Containment_Inheritance"></a>   
## Property Value Inheritance Is Containment Inheritance  
 "Inheritance" as a term here is not quite the same concept as inheritance in the context of types and general object-oriented programming, where derived classes inherit member definitions from their base classes. That meaning of inheritance is also active in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]: properties defined in various base classes are exposed as attributes for derived [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] classes when used as elements, and exposed as members for code. Property value inheritance is particularly about how property values can inherit from one element to another on the basis of the parent-child relationships within a tree of elements. That tree of elements is most directly visible when nesting elements inside other elements as you define applications in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] markup. Trees of objects can also be created programmatically by adding objects to designated collections of other objects, and property value inheritance works the same way in the finished tree at run time.  
  
<a name="Practical_Applications_of_Property_Value_Inheritance"></a>   
## Practical Applications of Property Value Inheritance  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)] include several properties that have property inheritance enabled. Typically, the scenario for these is that they involve a property where it is appropriate that the property be set only once per page, but where that property is also a member of one of the base element classes and thus would also exist on most of the child elements. For example, the <xref:System.Windows.FrameworkElement.FlowDirection%2A> property controls which direction flowed content should be presented and arranged on the page. Typically, you want the text flow concept to be handled consistently throughout all child elements. If flow direction were for some reason reset in some level of the element tree by user or environment action, it should typically be reset throughout. When the <xref:System.Windows.FrameworkElement.FlowDirection%2A> property is made to inherit, the value need only be set or reset once at the level in the element tree that encompasses the presentation needs of each page in the application. Even the initial default value will inherit in this way. The property value inheritance model still enables individual elements to reset the value for the rare cases where having a mix of flow directions is intentional.  
  
<a name="Making_a_Custom_Property_Inheritable"></a>   
## Making a Custom Property Inheritable  
 By changing a custom property's metadata, you can also make your own custom properties inheritable. Note, however, that designating a property as inheritable does have some performance considerations. In cases where that property does not have an established local value, or a value obtained through styles, templates, or data binding, an inheritable property provides its assigned property values to all child elements in the logical tree.  
  
 To make a property participate in value inheritance, create a custom attached property, as described in [Register an Attached Property](../../../../docs/framework/wpf/advanced/how-to-register-an-attached-property.md). Register the property with metadata (<xref:System.Windows.FrameworkPropertyMetadata>) and specify the "Inherits" option in the options settings within that metadata. Also make sure that the property has an established default value, because that value will now inherit. Although you registered the property as attached, you might also want to create a property "wrapper" for get/set access on the owner type, just as you would for an "nonattached" dependency property. After doing so, the inheritable property can either be set by using the direct property wrapper on the owner type or derived types, or it can be set by using the attached property syntax on any <xref:System.Windows.DependencyObject>.  
  
 Attached properties are conceptually similar to global properties; you can check for the value on any <xref:System.Windows.DependencyObject> and get a valid result. The typical scenario for attached properties is to set property values on child elements, and that scenario is more effective if the property in question is an attached property that is always implicitly present as an attached property on each element (<xref:System.Windows.DependencyObject>) in the tree.  
  
> [!NOTE]
>  Although property value inheritance might appear to work for nonattached dependency properties, the inheritance behavior for a nonattached property through certain element boundaries in the run-time tree is undefined. Always use <xref:System.Windows.DependencyProperty.RegisterAttached%2A> to register properties where you specify <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A> in the metadata.  
  
<a name="InheritanceContext"></a>   
## Inheriting Property Values Across Tree Boundaries  
 Property inheritance works by traversing a tree of elements. This tree is often parallel to the logical tree. However, whenever you include a WPF core-level object in the markup that defines an element tree, such as a <xref:System.Windows.Media.Brush>, you have created a discontinuous logical tree. A true logical tree does not conceptually extend through the <xref:System.Windows.Media.Brush>, because the logical tree is a WPF framework-level concept. You can see this reflected in the results when using the methods of <xref:System.Windows.LogicalTreeHelper>. However, property value inheritance can bridge this gap in the logical tree and can still pass inherited values through, so long as the inheritable property was registered as an attached property and no deliberate inheritance-blocking boundary (such as a <xref:System.Windows.Controls.Frame>) is encountered.  
  
## See Also  
 [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md)  
 [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md)  
 [Dependency Property Value Precedence](../../../../docs/framework/wpf/advanced/dependency-property-value-precedence.md)
