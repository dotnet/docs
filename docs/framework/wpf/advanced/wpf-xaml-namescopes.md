---
title: "WPF XAML Namescopes"
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
  - "namescopes [WPF]"
  - "styles [WPF], namescopes in"
  - "templates [WPF], namescopes in"
  - "APIs [WPF], name-related"
  - "name-related APIs"
  - "XAML [WPF], namescopes"
  - "classes [WPF], FrameworkContentElement"
ms.assetid: 52bbf4f2-15fc-40d4-837b-bb4c21ead7d4
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WPF XAML Namescopes
XAML namescopes are a concept that identifies objects that are defined in XAML. The names in a XAML namescope can be used to establish relationships between the XAML-defined names of objects and their instance equivalents in an object tree. Typically, XAML namescopes in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] managed code are created when loading the individual XAML page roots for a XAML application. XAML namescopes as the programming object are defined by the <xref:System.Windows.Markup.INameScope> interface and are also implemented by the practical class <xref:System.Windows.NameScope>.  
  
  
  
<a name="Namescopes_in_Loaded_XAML_Applications"></a>   
## Namescopes in Loaded XAML Applications  
 In a broader programming or computer science context, programming concepts often include the principle of a unique identifier or name that can be used to access an object. For systems that use identifiers or names, the namescope defines the boundaries within which a process or technique will search if an object of that name is requested, or the boundaries wherein uniqueness of identifying names is enforced. These general principles are true for XAML namescopes. In WPF, XAML namescopes are created on the root element for a XAML page when the page is loaded. Each name specified within the XAML page starting at the page root is added to a pertinent XAML namescope.  
  
 In WPF XAML, elements that are common root elements (such as <xref:System.Windows.Controls.Page>, and <xref:System.Windows.Window>) always control a XAML namescope. If an element such as <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> is the root element of the page in markup, a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor adds a <xref:System.Windows.Controls.Page> root implicitly so that the <xref:System.Windows.Controls.Page> can provide a working XAML namescope.  
  
> [!NOTE]
>  WPF build actions create a XAML namescope for a XAML production even if no `Name` or `x:Name` attributes are defined on any elements in the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] markup.  
  
 If you try to use the same name twice in any XAML namescope, an exception is raised. For WPF XAML that has code-behind and is part of a compiled application, the exception is raised at build time by WPF build actions, when creating the generated class for the page during the initial markup compile. For XAML that is not markup-compiled by any build action, exceptions related to XAML namescope issues might be raised when the XAML is loaded. XAML designers might also anticipate XAML namescope issues at design time.  
  
### Adding Objects to Runtime Object Trees  
 The moment that XAML is parsed represents the moment in time that a WPF XAML namescope is created and defined. If you add an object to an object tree at a point in time after the XAML that produced that tree was parsed, a `Name` or `x:Name` value on the new object does not automatically update the information in a XAML namescope. To add a name for an object into a WPF XAML namescope after XAML is loaded, you must call the appropriate implementation of <xref:System.Windows.Markup.INameScope.RegisterName%2A> on the object that defines the XAML namescope, which is typically the XAML page root. If the name is not registered, the added object cannot be referenced by name through methods such as <xref:System.Windows.FrameworkElement.FindName%2A>, and you cannot use that name for animation targeting.  
  
 The most common scenario for application developers is that you will use <xref:System.Windows.FrameworkElement.RegisterName%2A> to register names into the XAML namescope on the current root of the page. <xref:System.Windows.FrameworkElement.RegisterName%2A> is part of an important scenario for storyboards that target objects for animations. For more information, see [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
 If you call <xref:System.Windows.FrameworkElement.RegisterName%2A> on an object other than the object that defines the XAML namescope, the name is still registered to the XAML namescope that the calling object is held within, as if you had called <xref:System.Windows.FrameworkElement.RegisterName%2A> on the XAML namescope defining object.  
  
### XAML Namescopes in Code  
 You can create and then use XAML namescopes in code. The APIs and the concepts involved in XAML namescope creation are the same even for a pure code usage, because the XAML processor for [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses these APIs and concepts when it processes XAML itself. The concepts and API exist mainly for the purpose of being able to find objects by name within an object tree that is typically defined partially or entirely in XAML.  
  
 For applications that are created programmatically, and not from loaded XAML, the object that defines a XAML namescope must implement <xref:System.Windows.Markup.INameScope>, or be a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> derived class, in order to support creation of a XAML namescope on its instances.  
  
 Also, for any element that is not loaded and processed by a XAML processor, the XAML namescope for the object is not created or initialized by default. You must explicitly create a new XAML namescope for any object that you intend to register names into subsequently. To create a XAML namescope, you call the static <xref:System.Windows.NameScope.SetNameScope%2A> method. Specify the object that will own it as the `dependencyObject` parameter, and a new <xref:System.Windows.NameScope.%23ctor%2A> constructor call as the `value` parameter.  
  
 If the object provided as `dependencyObject` for <xref:System.Windows.NameScope.SetNameScope%2A> is not a <xref:System.Windows.Markup.INameScope> implementation, <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>, calling <xref:System.Windows.FrameworkElement.RegisterName%2A> on any child elements will have no effect. If you fail to create the new XAML namescope explicitly, then calls to <xref:System.Windows.FrameworkElement.RegisterName%2A> will raise an exception.  
  
 For an example of using XAML namescope APIs in code, see [Define a Name Scope](../../../../docs/framework/wpf/graphics-multimedia/how-to-define-a-name-scope.md).  
  
<a name="Namescopes_in_Styles_and_Templates"></a>   
## XAML Namescopes in Styles and Templates  
 Styles and templates in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provide the ability to reuse and reapply content in a straightforward way. However, styles and templates might also include elements with XAML names defined at the template level. That same template might be used multiple times in a page. For this reason, styles and templates both define their own XAML namescopes, independent of whatever location in an object tree where the style or template is applied.  
  
 Consider the following example:  
  
 [!code-xaml[XamlOvwSupport#NameScopeTemplates](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page6.xaml#namescopetemplates)]  
  
 Here, the same template is applied to two different buttons. If templates did not have discrete XAML namescopes, the `TheBorder` name used in the template would cause a name collision in the XAML namescope. Each instantiation of the template has its own XAML namescope, so in this example each instantiated template's XAML namescope would contain exactly one name.  
  
 Styles also define their own XAML namescope, mostly so that parts of storyboards can have particular names assigned. These names enable control specific behaviors that will target elements of that name, even if the template was re-defined as part of control customization.  
  
 Because of the separate XAML namescopes, finding named elements in a template is more challenging than finding a non-templated named element in a page. You first need to determine the applied template, by getting the <xref:System.Windows.Controls.Control.Template%2A> property value of the control where the template is applied. Then, you call the template version of <xref:System.Windows.FrameworkTemplate.FindName%2A>, passing the control where the template was applied as the second parameter.  
  
 If you are a control author and you are generating a convention where a particular named element in an applied template is the target for a behavior that is defined by the control itself, you can use the <xref:System.Windows.FrameworkElement.GetTemplateChild%2A> method from your control implementation code. The <xref:System.Windows.FrameworkElement.GetTemplateChild%2A> method is protected, so only the control author has access to it.  
  
 If you are working from within a template, and need to get to the XAML namescope where the template is applied, get the value of <xref:System.Windows.FrameworkElement.TemplatedParent%2A>, and then call <xref:System.Windows.FrameworkElement.FindName%2A> there. An example of working within the template would be if you are writing the event handler implementation where the event will be raised from an element in an applied template.  
  
<a name="Namescopes_and_Name_related_APIs"></a>   
## XAML Namescopes and Name-related APIs  
 <xref:System.Windows.FrameworkElement> has <xref:System.Windows.FrameworkElement.FindName%2A>, <xref:System.Windows.FrameworkElement.RegisterName%2A> and <xref:System.Windows.FrameworkElement.UnregisterName%2A> methods. If the object you call these methods on owns a XAML namescope, the methods call into the methods of the relevant XAML namescope. Otherwise, the parent element is checked to see if it owns a XAML namescope, and this process continues recursively until a XAML namescope is found (because of the XAML processor behavior, there is guaranteed to be a XAML namescope at the root). <xref:System.Windows.FrameworkContentElement> has analogous behaviors, with the exception that no <xref:System.Windows.FrameworkContentElement> will ever own a XAML namescope. The methods exist on <xref:System.Windows.FrameworkContentElement> so that the calls can be forwarded eventually to a <xref:System.Windows.FrameworkElement> parent element.  
  
 <xref:System.Windows.NameScope.SetNameScope%2A> is used to map a new XAML namescope to an existing object. You can call <xref:System.Windows.NameScope.SetNameScope%2A> more than once in order to reset or clear the XAML namescope, but that is not a common usage. Also, <xref:System.Windows.NameScope.GetNameScope%2A> is not typically used from code.  
  
### XAML Namescope Implementations  
 The following classes implement <xref:System.Windows.Markup.INameScope> directly:  
  
-   <xref:System.Windows.NameScope>  
  
-   <xref:System.Windows.Style>  
  
-   <xref:System.Windows.ResourceDictionary>  
  
-   <xref:System.Windows.FrameworkTemplate>  
  
 <xref:System.Windows.ResourceDictionary> does not use XAML names or namescopes ; it uses keys instead, because it is a dictionary implementation. The only reason that <xref:System.Windows.ResourceDictionary> implements <xref:System.Windows.Markup.INameScope> is so it can raise exceptions to user code that help clarify the distinction between a true XAML namescope and how a <xref:System.Windows.ResourceDictionary> handles keys, and also to assure that XAML namescopes are not applied to a <xref:System.Windows.ResourceDictionary> by parent elements.  
  
 <xref:System.Windows.FrameworkTemplate> and <xref:System.Windows.Style> implement <xref:System.Windows.Markup.INameScope> through explicit interface definitions. The explicit implementations allow these XAML namescopes to behave conventionally when they are accessed through the <xref:System.Windows.Markup.INameScope> interface, which is how XAML namescopes are communicated by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] internal processes. But the explicit interface definitions are not part of the conventional API surface of <xref:System.Windows.FrameworkTemplate> and <xref:System.Windows.Style>, because you seldom need to call the <xref:System.Windows.Markup.INameScope> methods on <xref:System.Windows.FrameworkTemplate> and <xref:System.Windows.Style> directly, and instead would use other API such as <xref:System.Windows.FrameworkElement.GetTemplateChild%2A>.  
  
 The following classes define their own XAML namescope, by using the <xref:System.Windows.NameScope?displayProperty=nameWithType> helper class and connecting to its XAML namescope implementation through the <xref:System.Windows.NameScope.NameScope%2A?displayProperty=nameWithType> attached property:  
  
-   <xref:System.Windows.FrameworkElement>  
  
-   <xref:System.Windows.FrameworkContentElement>  
  
## See Also  
 [XAML Namespaces and Namespace Mapping for WPF XAML](../../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md)  
 [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md)
