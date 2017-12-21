---
title: "Framework Property Metadata"
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
  - "metadata [WPF], framework properties"
  - "framework property metadata [WPF]"
ms.assetid: 9962f380-b885-4b61-a62e-457397083fea
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Framework Property Metadata
Framework property metadata options are reported for the properties of object elements considered to be at the WPF framework level in the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] architecture. In general the WPF framework-level designation entails that features such as rendering, data binding, and property system refinements are handled by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] presentation [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] and executables. Framework property metadata is queried by these systems to determine feature-specific characteristics of particular element properties.  
  
 
  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand dependency properties from the perspective of a consumer of existing dependency properties on [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] classes, and have read the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md). You should also have read [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md).  
  
<a name="What_Is_Communicated_by_Framework_Property"></a>   
## What Is Communicated by Framework Property Metadata  
 Framework property metadata can be divided into the following categories:  
  
-   Reporting layout properties that affect an element (<xref:System.Windows.FrameworkPropertyMetadata.AffectsArrange%2A>, <xref:System.Windows.FrameworkPropertyMetadata.AffectsMeasure%2A>, <xref:System.Windows.FrameworkPropertyMetadata.AffectsRender%2A>). You might set these flags in metadata if the property affects those respective aspects, and you are also implementing the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> / <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> methods in your class to supply specific rendering behavior and information to the layout system. Typically, such an implementation would check for property invalidations in dependency properties where any of these layout properties were true in the property metadata, and only those invalidations would necessitate requesting a new layout pass.  
  
-   Reporting layout properties that affect the parent element of an element (<xref:System.Windows.FrameworkPropertyMetadata.AffectsParentArrange%2A>, <xref:System.Windows.FrameworkPropertyMetadata.AffectsParentMeasure%2A>). Some examples where these flags are set by default are <xref:System.Windows.Documents.FixedPage.Left%2A?displayProperty=nameWithType> and <xref:System.Windows.Documents.Paragraph.KeepWithNext%2A?displayProperty=nameWithType>.  
  
-   <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A>. By default, dependency properties do not inherit values. <xref:System.Windows.FrameworkPropertyMetadata.OverridesInheritanceBehavior%2A> allows the pathway of inheritance to also travel into a visual tree, which is necessary for some control compositing scenarios.  
  
    > [!NOTE]
    >  The term "inherits" in the context of property values means something specific for dependency properties; it means that child elements can inherit the actual dependency property value from parent elements because of a WPF framework-level capability of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system. It has nothing to do directly with managed code type and members inheritance through derived types. For details, see [Property Value Inheritance](../../../../docs/framework/wpf/advanced/property-value-inheritance.md).  
  
-   Reporting data binding characteristics (<xref:System.Windows.FrameworkPropertyMetadata.IsNotDataBindable%2A>, <xref:System.Windows.FrameworkPropertyMetadata.BindsTwoWayByDefault%2A>). By default, dependency properties in the framework support data binding, with a one-way binding behavior. You might disable data binding if there were no scenario for it whatsoever (because they are intended to be flexible and extensible, there aren't many examples of such properties in the default [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)]). You might set binding to have a two-way default for properties that tie together a control's behaviors amongst its component pieces (<xref:System.Windows.Controls.MenuItem.IsSubmenuOpen%2A> is an example) or where two-way binding is the common and expected scenario for users (<xref:System.Windows.Controls.TextBox.Text%2A> is an example). Changing the data binding–related metadata only influences the default; on a per-binding basis that default can always be changed. For details on the binding modes and binding in general, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
-   Reporting whether properties should be journaled by applications or services that support journaling (<xref:System.Windows.FrameworkPropertyMetadata.Journal%2A>). For general elements, journaling is not enabled by default, but it is selectively enabled for certain user input controls. This property is intended to be read by journaling services including the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] implementation of journaling, and is typically set on user controls such as user selections within lists that should be persisted across navigation steps. For information about the journal, see [Navigation Overview](../../../../docs/framework/wpf/app-development/navigation-overview.md).  
  
<a name="Reading_FrameworkPropertyMetadata"></a>   
## Reading FrameworkPropertyMetadata  
 Each of the properties linked above are the specific properties that the <xref:System.Windows.FrameworkPropertyMetadata> adds to its immediate base class <xref:System.Windows.UIPropertyMetadata>. Each of these properties will be `false` by default. A metadata request for a property where knowing the value of these properties is important should attempt to cast the returned metadata to <xref:System.Windows.FrameworkPropertyMetadata>, and then check the values of the individual properties as needed.  
  
<a name="Specifying_Metadata"></a>   
## Specifying Metadata  
 When you create a new metadata instance for purposes of applying metadata to a new dependency property registration, you have the choice of which metadata class to use: the base <xref:System.Windows.PropertyMetadata> or some derived class such as <xref:System.Windows.FrameworkPropertyMetadata>. In general, you should use <xref:System.Windows.FrameworkPropertyMetadata>, particularly if your property has any interaction with property system and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] functions such as layout and data binding. Another option for more sophisticated scenarios is to derive from <xref:System.Windows.FrameworkPropertyMetadata> to create your own metadata reporting class with extra information carried in its members. Or you might use <xref:System.Windows.PropertyMetadata> or <xref:System.Windows.UIPropertyMetadata> to communicate the degree of support for features of your implementation.  
  
 For existing properties (<xref:System.Windows.DependencyProperty.AddOwner%2A> or <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> call), you should always override with the metadata type used by the original registration.  
  
 If you are creating a <xref:System.Windows.FrameworkPropertyMetadata> instance, there are two ways to populate that metadata with values for the specific properties that communicate the framework property characteristics:  
  
1.  Use the <xref:System.Windows.FrameworkPropertyMetadata> constructor signature that allows a `flags` parameter. This parameter should be filled with all desired combined values of the <xref:System.Windows.FrameworkPropertyMetadataOptions> enumeration flags.  
  
2.  Use one of the signatures without a `flags` parameter, and then set each reporting Boolean property on <xref:System.Windows.FrameworkPropertyMetadata> to `true` for each desired characteristic change. If you do this, you must set these properties before any elements with this dependency property are constructed; the Boolean properties are read-write in order to allow this behavior of avoiding the `flags` parameter and still populate the metadata, but the metadata must become effectively sealed before property use. Thus, attempting to set the properties after metadata is requested will be an invalid operation.  
  
<a name="Framework_Property_Metadata_Merge_Behavior"></a>   
## Framework Property Metadata Merge Behavior  
 When you override framework property metadata, the different metadata characteristics are either merged or replaced.  
  
-   <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> is merged. If you add a new <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A>, that callback is stored in the metadata. If you do not specify a <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> in the override, the value of <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> is promoted as a reference from the nearest ancestor that specified it in metadata.  
  
-   The actual property system behavior for <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> is that implementations for all metadata owners in the hierarchy are retained and added to a table, with order of execution by the property system being that the callbacks of the most deeply derived class are invoked first. Inherited callbacks run only once, counting as being owned by the class that placed them in metadata.  
  
-   <xref:System.Windows.PropertyMetadata.DefaultValue%2A> is replaced. If you do not specify a <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A> in the override, the value of <xref:System.Windows.PropertyMetadata.DefaultValue%2A> comes from the nearest ancestor that specified it in metadata.  
  
-   <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> implementations are replaced. If you add a new <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A>, that callback is stored in the metadata. If you do not specify a <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> in the override, the value of <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> is promoted as a reference from the nearest ancestor that specified it in metadata.  
  
-   The property system behavior is that only the <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> in the immediate metadata is invoked. No references to other <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> implementations in the hierarchy are retained.  
  
-   The flags of <xref:System.Windows.FrameworkPropertyMetadataOptions> enumeration are combined as a bitwise OR operation.  If you specify <xref:System.Windows.FrameworkPropertyMetadataOptions>, the original options are not overwritten.  To change an option, set the corresponding property on <xref:System.Windows.FrameworkPropertyMetadata>. For example, if the original <xref:System.Windows.FrameworkPropertyMetadata> object sets the <xref:System.Windows.FrameworkPropertyMetadataOptions.NotDataBindable?displayProperty=nameWithType> flag, you can change that by setting <xref:System.Windows.FrameworkPropertyMetadata.IsNotDataBindable%2A?displayProperty=nameWithType> to `false`.  
  
 This behavior is implemented by <xref:System.Windows.FrameworkPropertyMetadata.Merge%2A>, and can be overridden on derived metadata classes.  
  
## See Also  
 <xref:System.Windows.DependencyProperty.GetMetadata%2A>  
 [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md)  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)
