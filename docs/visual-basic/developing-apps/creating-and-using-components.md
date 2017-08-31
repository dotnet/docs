---
title: "Creating and Using Components in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "components [Visual Basic]"
ms.assetid: ee6a4156-73f7-4e9b-8e01-c74c4798b65c
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Creating and Using Components in Visual Basic
[!INCLUDE[vs2017banner](../../includes/vs2017banner.md)]

A *component* is a class that implements the <xref:System.ComponentModel.IComponent?displayProperty=fullName> interface or that derives directly or indirectly from a class that implements <xref:System.ComponentModel.IComponent>. A [!INCLUDE[dnprdnshort](../../includes/dnprdnshort-md.md)] component is an object that is reusable, can interact with other objects, and provides control over external resources and design-time support.  
  
 An important feature of components is that they are designable, which means that a class that is a component can be used in the [!INCLUDE[vsprvs](../../includes/vsprvs-md.md)] Integrated Development Environment. A component can be added to the Toolbox, dragged and dropped onto a form, and manipulated on a design surface. Notice that base design-time support for components is built into the [!INCLUDE[dnprdnshort](../../includes/dnprdnshort-md.md)]; a component developer does not have to do any additional work to take advantage of the base design-time functionality.  
  
 A *control* is similar to a component, as both are designable. However, a control provides a user interface, while a component does not. A control must derive from one of the base control classes: <xref:System.Windows.Forms.Control> or <xref:System.Web.UI.Control>.  
  
## When to Create a Component  
 If your class will be used on a design surface (such as the Windows Forms or Web Forms Designer) but has no user interface, it should be a component and implement <xref:System.ComponentModel.IComponent>, or derive from a class that directly or indirectly implements <xref:System.ComponentModel.IComponent>.  
  
 The <xref:System.ComponentModel.Component> and <xref:System.ComponentModel.MarshalByValueComponent> classes are base implementations of the <xref:System.ComponentModel.IComponent> interface. The main difference between these classes is that the <xref:System.ComponentModel.Component> class is marshaled by reference, while <xref:System.ComponentModel.IComponent> is marshaled by value. The following list provides broad guidelines for implementers.  
  
-   If your component needs to be marshaled by reference, derive from <xref:System.ComponentModel.Component>.  
  
-   If your component needs to be marshaled by value, derive from <xref:System.ComponentModel.MarshalByValueComponent>.  
  
-   If your component cannot derive from one of the base implementations due to single inheritance, implement <xref:System.ComponentModel.IComponent>.  
  
 For more information about design-time support, see [Design-Time Attributes for Components](../Topic/Design-Time%20Attributes%20for%20Components.md) and [Extending Design-Time Support](../Topic/Extending%20Design-Time%20Support.md).  
  
## Component Classes  
 The <xref:System.ComponentModel> namespace provides classes that are used to implement the run-time and design-time behavior of components and controls. This namespace includes the base classes and interfaces for implementing attributes and type converters, binding to data sources, and licensing components.  
  
 The core component classes are:  
  
-   <xref:System.ComponentModel.Component>. A base implementation for the <xref:System.ComponentModel.IComponent> interface. This class enables object sharing between applications.  
  
-   <xref:System.ComponentModel.MarshalByValueComponent>. A base implementation for the <xref:System.ComponentModel.IComponent> interface.  
  
-   <xref:System.ComponentModel.Container>. The base implementation for the <xref:System.ComponentModel.IContainer> interface. This class encapsulates zero or more components.  
  
 Some of the classes used for component licensing are:  
  
-   <xref:System.ComponentModel.License>. The abstract base class for all licenses. A license is granted to a specific instance of a component.  
  
-   <xref:System.ComponentModel.LicenseManager>. Provides properties and methods to add a license to a component and to manage a <xref:System.ComponentModel.LicenseProvider>.  
  
-   <xref:System.ComponentModel.LicenseProvider>. The abstract base class for implementing a license provider.  
  
-   <xref:System.ComponentModel.LicenseProviderAttribute>. Specifies the <xref:System.ComponentModel.LicenseProvider> class to use with a class.  
  
 Classes commonly used for describing and persisting components.  
  
-   <xref:System.ComponentModel.TypeDescriptor>. Provides information about the characteristics for a component, such as its attributes, properties, and events.  
  
-   <xref:System.ComponentModel.EventDescriptor>. Provides information about an event.  
  
-   <xref:System.ComponentModel.PropertyDescriptor>. Provides information about a property.  
  
## Related Sections  
 [Class vs. Component vs. Control](../Topic/Class%20vs.%20Component%20vs.%20Control.md)  
 Defines *component* and *control*, and discusses the differences between them and classes.  
  
 [Component Authoring](../Topic/Component%20Authoring.md)  
 Roadmap for getting started with components.  
  
 [Component Authoring Walkthroughs](../Topic/Component%20Authoring%20Walkthroughs.md)  
 Links to topics that provide step-by-step instruction for component programming.  
  
 [Component Classes](../Topic/Component%20Classes.md)  
 Describes what makes a class a component, ways to expose component functionality, controlling access to components, and controlling how component instances are created.  
  
 [Troubleshooting Control and Component Authoring](../Topic/Troubleshooting%20Control%20and%20Component%20Authoring.md)  
 Explains how to fix common problems.  
  
## See Also  
 [How to: Access Design-Time Support in Windows Forms](../Topic/How%20to:%20Access%20Design-Time%20Support%20in%20Windows%20Forms.md)   
 [How to: Extend the Appearance and Behavior of Controls in Design Mode](../Topic/How%20to:%20Extend%20the%20Appearance%20and%20Behavior%20of%20Controls%20in%20Design%20Mode.md)   
 [How to: Perform Custom Initialization for Controls in Design Mode](../Topic/How%20to:%20Perform%20Custom%20Initialization%20for%20Controls%20in%20Design%20Mode.md)