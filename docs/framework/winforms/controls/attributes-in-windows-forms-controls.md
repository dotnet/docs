---
title: "Attributes in Windows Forms Controls"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "attributes [Windows Forms]"
  - "attributes [Windows Forms], data binding properties"
  - "attributes [Windows Forms], control properties"
  - "attributes [Windows Forms], classes"
ms.assetid: 2c5640e9-6c6c-49d7-a5e4-a768f6be7853
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Attributes in Windows Forms Controls
The .NET Framework provides a variety of attributes you can apply to the members of your custom controls and components. Some of these attributes affect the run-time behavior of a class, and others affect the design-time behavior.  
  
## Attributes for Control and Component Properties  
 The following table shows the attributes you can apply to properties or other members of your custom controls and components. For an example that uses many of these attributes, see [How to: Apply Attributes in Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-apply-attributes-in-windows-forms-controls.md).  
  
|Attribute|Description|  
|---------------|-----------------|  
|<xref:System.ComponentModel.AmbientValueAttribute>|Specifies the value to pass to a property to cause the property to get its value from another source. This is known as *ambience*.|  
|<xref:System.ComponentModel.BrowsableAttribute>|Specifies whether a property or event should be displayed in a **Properties** window.|  
|<xref:System.ComponentModel.CategoryAttribute>|Specifies the name of the category in which to group the property or event when displayed in a <xref:System.Windows.Forms.PropertyGrid> control set to <xref:System.Windows.Forms.PropertySort.Categorized> mode.|  
|<xref:System.ComponentModel.DefaultValueAttribute>|Specifies the default value for a property.|  
|<xref:System.ComponentModel.DescriptionAttribute>|Specifies a description for a property or event.|  
|<xref:System.ComponentModel.DisplayNameAttribute>|Specifies the display name for a property, event, or `public``void` method that takes no arguments.|  
|<xref:System.ComponentModel.EditorAttribute>|Specifies the editor to use to change a property.|  
|<xref:System.ComponentModel.EditorBrowsableAttribute>|Specifies that a property or method is viewable in an editor.|  
|<xref:System.ComponentModel.Design.HelpKeywordAttribute>|Specifies the context keyword for a class or member.|  
|<xref:System.ComponentModel.LocalizableAttribute>|Specifies whether a property should be localized.|  
|<xref:System.ComponentModel.PasswordPropertyTextAttribute>|Indicates that an object's text representation is obscured by characters such as asterisks.|  
|<xref:System.ComponentModel.ReadOnlyAttribute>|Specifies whether the property this attribute is bound to is read-only or read/write at design time.|  
|<xref:System.ComponentModel.RefreshPropertiesAttribute>|Indicates that the property grid should refresh when the associated property value changes.|  
|<xref:System.ComponentModel.TypeConverterAttribute>|Specifies what type to use as a converter for the object this attribute is bound to.|  
  
## Attributes for Data Binding Properties  
 The following table shows the attributes you can apply to specify how your custom controls and components interact with data binding.  
  
|Attribute|Description|  
|---------------|-----------------|  
|<xref:System.ComponentModel.BindableAttribute>|Specifies whether a property is typically used for binding.|  
|<xref:System.ComponentModel.ComplexBindingPropertiesAttribute>|Specifies the data source and data member properties for a component.|  
|<xref:System.ComponentModel.DefaultBindingPropertyAttribute>|Specifies the default binding property for a component.|  
|<xref:System.ComponentModel.LookupBindingPropertiesAttribute>|Specifies the data source and data member properties for a component.|  
|<xref:System.ComponentModel.AttributeProviderAttribute>|Enables attribute redirection.|  
  
## Attributes for Classes  
 The following table shows the attributes you can apply to specify the behavior of your custom controls and components at design time.  
  
|Attribute|Description|  
|---------------|-----------------|  
|<xref:System.ComponentModel.DefaultEventAttribute>|Specifies the default event for a component.|  
|<xref:System.ComponentModel.DefaultPropertyAttribute>|Specifies the default property for a component.|  
|<xref:System.ComponentModel.DesignerAttribute>|Specifies the class used to implement design-time services for a component.|  
|<xref:System.ComponentModel.DesignerCategoryAttribute>|Specifies that the designer for a class belongs to a certain category.|  
|<xref:System.ComponentModel.ToolboxItemAttribute>|Represents an attribute of a toolbox item.|  
|<xref:System.ComponentModel.ToolboxItemFilterAttribute>|Specifies the filter string and filter type to use for a Toolbox item.|  
  
## See Also  
 <xref:System.Attribute>  
 [How to: Apply Attributes in Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-apply-attributes-in-windows-forms-controls.md)  
 [Extending Design-Time Support](http://msdn.microsoft.com/library/d6ac8a6a-42fd-4bc8-bf33-b212811297e2)  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)
