---
title: "Creating and Using Components in Visual Basic | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "components [Visual Basic]"
ms.assetid: ee6a4156-73f7-4e9b-8e01-c74c4798b65c
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Creating and Using Components in Visual Basic
A *component* is a class that implements the <xref:System.ComponentModel.IComponent?displayProperty=fullName> interface or that derives directly or indirectly from a class that implements <xref:System.ComponentModel.IComponent>. A [!INCLUDE[dnprdnshort](../../csharp/getting-started/includes/dnprdnshort_md.md)] component is an object that is reusable, can interact with other objects, and provides control over external resources and design-time support.  
  
 An important feature of components is that they are designable, which means that a class that is a component can be used in the [!INCLUDE[vsprvs](../../csharp/includes/vsprvs_md.md)] Integrated Development Environment. A component can be added to the Toolbox, dragged and dropped onto a form, and manipulated on a design surface. Notice that base design-time support for components is built into the [!INCLUDE[dnprdnshort](../../csharp/getting-started/includes/dnprdnshort_md.md)]; a component developer does not have to do any additional work to take advantage of the base design-time functionality.  
  
 A *control* is similar to a component, as both are designable. However, a control provides a user interface, while a component does not. A control must derive from one of the base control classes: <xref:System.Windows.Forms.Control> or <xref:System.Web.UI.Control>.  
  
## When to Create a Component  
 If your class will be used on a design surface (such as the Windows Forms or Web Forms Designer) but has no user interface, it should be a component and implement <xref:System.ComponentModel.IComponent>, or derive from a class that directly or indirectly implements <xref:System.ComponentModel.IComponent>.  
  
 The <xref:System.ComponentModel.Component> and <xref:System.ComponentModel.MarshalByValueComponent> classes are base implementations of the <xref:System.ComponentModel.IComponent> interface. The main difference between these classes is that the <xref:System.ComponentModel.Component> class is marshaled by reference, while <xref:System.ComponentModel.IComponent> is marshaled by value. The following list provides broad guidelines for implementers.  
  
-   If your component needs to be marshaled by reference, derive from <xref:System.ComponentModel.Component>.  
  
-   If your component needs to be marshaled by value, derive from <xref:System.ComponentModel.MarshalByValueComponent>.  
  
-   If your component cannot derive from one of the base implementations due to single inheritance, implement <xref:System.ComponentModel.IComponent>.  
  
 For more information about design-time support, see [Design-Time Attributes for Components](http://msdn.microsoft.com/library/12050fe3-9327-4509-9e21-4ee2494b95c3) and [Extending Design-Time Support](http://msdn.microsoft.com/library/d6ac8a6a-42fd-4bc8-bf33-b212811297e2).  
  
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
 [Class vs. Component vs. Control](http://msdn.microsoft.com/library/db8b842e-44d9-40cc-a0f8-70fd189632c3)  
 Defines *component* and *control*, and discusses the differences between them and classes.  
  
 [Component Authoring](http://msdn.microsoft.com/library/4a5a5e49-0378-4a31-83bc-24da0f1a727d)  
 Roadmap for getting started with components.  
  
 [Component Authoring Walkthroughs](http://msdn.microsoft.com/library/c414cca9-2489-4208-8b38-954586d91c13)  
 Links to topics that provide step-by-step instruction for component programming.  
  
 [Component Classes](http://msdn.microsoft.com/library/ce2e5647-e673-4c2b-8125-ffebbd9d71bc)  
 Describes what makes a class a component, ways to expose component functionality, controlling access to components, and controlling how component instances are created.  
  
 [Troubleshooting Control and Component Authoring](../../framework/winforms/controls/troubleshooting-control-and-component-authoring.md)  
 Explains how to fix common problems.  
  
## See Also  
 [How to: Access Design-Time Support in Windows Forms](http://msdn.microsoft.com/library/a84f8579-1f47-41b9-ba37-69030b0aff09)   
 [How to: Extend the Appearance and Behavior of Controls in Design Mode](http://msdn.microsoft.com/library/68f85054-2253-47f5-a4f2-3f1ac8c9f27b)   
 [How to: Perform Custom Initialization for Controls in Design Mode](http://msdn.microsoft.com/library/914eaa03-092f-4556-9160-b8a2a40641d9)