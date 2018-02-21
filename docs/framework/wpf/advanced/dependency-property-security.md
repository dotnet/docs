---
title: "Dependency Property Security"
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
  - "wrappers [WPF], access"
  - "wrappers [WPF], security"
  - "dependency properties [WPF], security"
  - "security [WPF], wrappers"
  - "validation [WPF], dependency properties"
  - "dependency properties [WPF], access"
  - "security [WPF], dependency properties"
ms.assetid: d10150ec-90c5-4571-8d35-84bafa2429a4
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Dependency Property Security
Dependency properties should generally be considered to be public properties. The nature of the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] property system prevents the ability to make security guarantees about a dependency property value.  
  
  
<a name="AccessSecurity"></a>   
## Access and Security of Wrappers and Dependency Properties  
 Typically, dependency properties are implemented along with "wrapper" [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] properties that simplify getting or setting the property from an instance. But the wrappers are really just convenience methods that implement the underlying <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> static calls that are used when interacting with dependency properties. Thinking of it in another way, the properties are exposed as [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] properties that happen to be backed by a dependency property rather than by a private field. Security mechanisms applied to the wrappers do not parallel the property system behavior and access of the underlying dependency property. Placing a security demand on the wrapper will only prevent the usage of the convenience method but will not prevent calls to <xref:System.Windows.DependencyObject.GetValue%2A> or <xref:System.Windows.DependencyObject.SetValue%2A>. Similarly, placing protected or private access level on the wrappers does not provide any effective security.  
  
 If you are writing your own dependency properties, you should declare the wrappers and the <xref:System.Windows.DependencyProperty> identifier field as public members, so that callers do not get misleading information about the true access level of that property (because of its store being implemented as a dependency property).  
  
 For a custom dependency property, you can register your property as a read-only dependency property, and this does provide an effective means of preventing a property being set by anyone that does not hold a reference to the <xref:System.Windows.DependencyPropertyKey> for that property. For more information, see [Read-Only Dependency Properties](../../../../docs/framework/wpf/advanced/read-only-dependency-properties.md).  
  
> [!NOTE]
>  Declaring a <xref:System.Windows.DependencyProperty> identifier field private is not forbidden, and it can conceivably be used to help reduce the immediately exposed namespace of a custom class, but such a property should not be considered "private" in the same sense as the [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] language definitions define that access level, for reasons described in the next section.  
  
<a name="PropertySystemExposure"></a>   
## Property System Exposure of Dependency Properties  
 It is not generally useful, and it is potentially misleading, to declare a <xref:System.Windows.DependencyProperty> as any access level other than public. That access level setting only prevents someone from being able to get a reference to the instance from the declaring class. But there are several aspects of the property system that will return a <xref:System.Windows.DependencyProperty> as the means of identifying a particular property as it exists on an instance of a class or a derived class instance, and this identifier is still usable in a <xref:System.Windows.DependencyObject.SetValue%2A> call even if the original static identifier is declared as nonpublic. Also, <xref:System.Windows.DependencyObject.OnPropertyChanged%2A> virtual methods receive information of any existing dependency property that changed value. In addition, the <xref:System.Windows.DependencyObject.GetLocalValueEnumerator%2A> method returns identifiers for any property on instances with a locally set value.  
  
### Validation and Security  
 Applying a demand to a <xref:System.Windows.DependencyProperty.ValidateValueCallback%2A> and expecting the validation failure on a demand failure to prevent a property from being set is not an adequate security mechanism. Set-value invalidation enforced through <xref:System.Windows.DependencyProperty.ValidateValueCallback%2A> could also be suppressed by malicious callers, if those callers are operating within the application domain.  
  
## See Also  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)
