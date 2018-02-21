---
title: "Trees in WPF"
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
  - "logical tree [WPF]"
  - "element tree [WPF]"
  - "visual tree [WPF]"
ms.assetid: e83f25e5-d66b-4fc7-92d2-50130c9a6649
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Trees in WPF
In many technologies, elements and components are organized in a tree structure where developers directly manipulate the object nodes in the tree to affect the rendering or behavior of an application. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] also uses several tree structure metaphors to define relationships between program elements. For the most part WPF developers can create an application in code or define portions of the application in XAML while thinking conceptually about the object tree metaphor, but will be calling specific API or using specific markup to do so rather than some general object tree manipulation API such as you might use in XML DOM. WPF exposes two helper classes that provide a tree metaphor view, <xref:System.Windows.LogicalTreeHelper> and <xref:System.Windows.Media.VisualTreeHelper>. The terms visual tree and logical tree are also used in the WPF documentation because these same trees are useful for understanding the behavior of certain key WPF features. This topic defines what the visual tree and logical tree represent, discusses how such trees relate to an overall object tree concept, and introduces <xref:System.Windows.LogicalTreeHelper> and <xref:System.Windows.Media.VisualTreeHelper>s.  
  

  
<a name="element_tree"></a>   
## Trees in WPF  
 The most complete tree structure in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is the object tree. If you define an application page in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] and then load the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], the tree structure is created based on the nesting relationships of the elements in the markup. If you define an application or a portion of the application in code, then the tree structure is created based on how you assign property values for properties that implement the content model for a given object. In [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)], there are two ways that the complete object tree is conceptualized and can be reported to its public API: as the logical tree and as the visual tree. The distinctions between logical tree and visual tree are not always necessarily important, but they can occasionally cause issues with certain [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] subsystems and affect choices you make in markup or code.  
  
 Even though you do not always manipulate either the logical tree or the visual tree directly, understanding the concepts of how the trees interact is useful for understanding WPF as a technology. Thinking of WPF as a tree metaphor of some kind is also crucial to understanding how property inheritance and event routing work in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
> [!NOTE]
>  Because the object tree is more of a concept than an actual API, another way to think of the concept is as an object graph. In practice, there are relationships between objects at run time where the tree metaphor will break down. Nevertheless, particularly with XAML-defined UI, the tree metaphor is relevant enough that most WPF documentation will use the term object tree when referencing this general concept.  
  
<a name="logical_tree"></a>   
## The Logical Tree  
 In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], you add content to UI elements by setting properties of the objects that back those elements. For example, you add items to a <xref:System.Windows.Controls.ListBox> control by manipulating its <xref:System.Windows.Controls.ItemsControl.Items%2A> property. By doing this, you are placing items into the <xref:System.Windows.Controls.ItemCollection> that is the <xref:System.Windows.Controls.ItemsControl.Items%2A> property value. Similarly, to add objects to a <xref:System.Windows.Controls.DockPanel>, you manipulate its <xref:System.Windows.Controls.Panel.Children%2A> property value. Here, you are adding objects to the <xref:System.Windows.Controls.UIElementCollection>. For a code example, see [Add an Element Dynamically](http://msdn.microsoft.com/library/d00f258a-7973-4de7-bc54-a3fc1f638419).  
  
 In [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)], when you place list items in a <xref:System.Windows.Controls.ListBox> or controls or other UI elements in a <xref:System.Windows.Controls.DockPanel>, you also use the <xref:System.Windows.Controls.ItemsControl.Items%2A> and <xref:System.Windows.Controls.Panel.Children%2A> properties, either explicitly or implicitly, as in the following example.  
  
 [!code-xaml[TreeOvwsSupport#AllCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TreeOvwsSupport/CS/page1.xaml#allcode)]  
  
 If you were to process this XAML as XML under a document object model, and if you had included the tags commented out as implicit (which would have been legal), then the resulting XML DOM tree would have included elements for `<ListBox.Items>` and the other implicit items. But XAML does not process that way when you read the markup and write to objects, the resulting object graph does not literally include `ListBox.Items`. It does however have a <xref:System.Windows.Controls.ListBox> property named `Items` that contains a <xref:System.Windows.Controls.ItemCollection>, and that <xref:System.Windows.Controls.ItemCollection> is initialized but empty when the <xref:System.Windows.Controls.ListBox> XAML is processed. Then, each child object element that exists as content for the <xref:System.Windows.Controls.ListBox> is added to the <xref:System.Windows.Controls.ItemCollection> by parser calls to `ItemCollection.Add`. This example of processing XAML into an object tree is so far seemingly an example where the created object tree is basically the logical tree.  
  
 However, the logical tree is not the entire object graph that exists for your application UI at run time, even with the XAML implicit syntax items factored out. The main reason for this is visuals and templates. For example, consider the <xref:System.Windows.Controls.Button>. The logical tree reports the <xref:System.Windows.Controls.Button> object and also its string `Content`. But there is more to this button in the run-time object tree. In particular, the button only appears on screen the way it does because a specific <xref:System.Windows.Controls.Button> control template was applied. The visuals that come from an applied template (such as the template-defined <xref:System.Windows.Controls.Border> of dark gray around the visual button) are not reported in the logical tree, even if you are looking at the logical tree during run time (such as handling an input event from the visible UI and then reading the logical tree). To find the template visuals, you would instead need to examine the visual tree.  
  
 For more information about how [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] syntax maps to the created object graph, and implicit syntax in XAML, see [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md) or [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md).  
  
<a name="tree_property_inheritance_event_routing"></a>   
### The Purpose of the Logical Tree  
 The logical tree exists so that content models can readily iterate over their possible child objects, and so that content models can be extensible. Also, the logical tree provides a framework for certain notifications, such as when all objects in the logical tree are loaded. Basically, the logical tree is an approximation of a run time object graph at the framework level, which excludes visuals, but is adequate for many querying operations against your own run time application's composition.  
  
 In addition, both static and dynamic resource references are resolved by looking upwards through the logical tree for <xref:System.Windows.FrameworkElement.Resources%2A> collections on the initial requesting object, and then continuing up the logical tree and checking each <xref:System.Windows.FrameworkElement> (or <xref:System.Windows.FrameworkContentElement>) for another `Resources` value that contains a <xref:System.Windows.ResourceDictionary>, possibly containing that key. The logical tree is used for resource lookup when both the logical tree and the visual tree are present. For more information on resource dictionaries and lookup, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
<a name="composition"></a>   
### Composition of the Logical Tree  
 The logical tree is defined at the WPF framework-level, which means that the WPF base element that is most relevant for logical tree operations is either <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>. However, as you can see if you actually use the <xref:System.Windows.LogicalTreeHelper> API, the logical tree sometimes contains nodes that are not either <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>. For instance, the logical tree reports the <xref:System.Windows.Controls.TextBlock.Text%2A> value of a <xref:System.Windows.Controls.TextBlock>, which is a string.  
  
<a name="override_logical_tree"></a>   
### Overriding the Logical Tree  
 Advanced control authors can override the logical tree by overriding several [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] that define how a general object or content model adds or removes objects within the logical tree. For an example of how to override the logical tree, see [Override the Logical Tree](../../../../docs/framework/wpf/advanced/how-to-override-the-logical-tree.md).  
  
<a name="pvi"></a>   
### Property Value Inheritance  
 Property value inheritance operates through a hybrid tree. The actual metadata that contains the <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A> property that enables property inheritance is the WPF framework-level <xref:System.Windows.FrameworkPropertyMetadata> class. Therefore, both the parent that holds the original value and the child object that inherits that value must both be <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>, and they must both be part of some logical tree. However, for existing WPF properties that support property inheritance, property value inheritance is able to perpetuate through an intervening object that is not in the logical tree. Mainly this is relevant for having template elements use any inherited property values set either on the instance that is templated, or at still higher levels of page-level composition and therefore higher in the logical tree. In order for property value inheritance to work consistently across such a boundary, the inheriting property must be registered as an attached property, and you should follow this pattern if you intend to define a custom dependency property with property inheritance behavior. The exact tree used for property inheritance cannot be entirely anticipated by a helper class utility method, even at run time. For more information, see [Property Value Inheritance](../../../../docs/framework/wpf/advanced/property-value-inheritance.md).  
  
<a name="two_trees"></a>   
## The Visual Tree  
 In addition to the concept of the logical tree, there is also the concept of the visual tree in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. The visual tree describes the structure of visual objects, as represented by the <xref:System.Windows.Media.Visual> base class. When you write a template for a control, you are defining or redefining the visual tree that applies for that control. The visual tree is also of interest to developers who want lower-level control over drawing for performance and optimization reasons. One exposure of the visual tree as part of conventional [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application programming is that event routes for a routed event mostly travel along the visual tree, not the logical tree. This subtlety of routed event behavior might not be immediately apparent unless you are a control author. Routing events through the visual tree enables controls that implement composition at the visual level to handle events or create event setters.  
  
<a name="trees_content"></a>   
## Trees, Content Elements, and Content Hosts  
 Content elements (classes that derive from <xref:System.Windows.ContentElement>) are not part of the visual tree; they do not inherit from <xref:System.Windows.Media.Visual> and do not have a visual representation. In order to appear in a UI at all, a <xref:System.Windows.ContentElement> must be hosted in a content host that is both a <xref:System.Windows.Media.Visual> and a logical tree participant. Usually such an object is a <xref:System.Windows.FrameworkElement>. You can conceptualize that the content host is somewhat like a "browser" for the content and chooses how to display that content within the screen region that the host controls. When the content is hosted, the content can be made a participant in certain tree processes that are normally associated with the visual tree. Generally, the <xref:System.Windows.FrameworkElement> host class includes implementation code that adds any hosted <xref:System.Windows.ContentElement> to the event route through subnodes of the content logical tree, even though the hosted content is not part of the true visual tree. This is necessary so that a <xref:System.Windows.ContentElement> can source a routed event that routes to any element other than itself.  
  
<a name="tree_traversal"></a>   
## Tree Traversal  
 The <xref:System.Windows.LogicalTreeHelper> class provides the <xref:System.Windows.LogicalTreeHelper.GetChildren%2A>, <xref:System.Windows.LogicalTreeHelper.GetParent%2A>, and <xref:System.Windows.LogicalTreeHelper.FindLogicalNode%2A> methods for logical tree traversal. In most cases, you should not have to traverse the logical tree of existing controls, because these controls almost always expose their logical child elements as a dedicated collection property that supports collection access such as `Add`, an indexer, and so on. Tree traversal is mainly a scenario that is used by control authors who choose not to derive from intended control patterns such as <xref:System.Windows.Controls.ItemsControl> or <xref:System.Windows.Controls.Panel> where collection properties are already defined, and who intend to provide their own collection property support.  
  
 The visual tree also supports a helper class for visual tree traversal, <xref:System.Windows.Media.VisualTreeHelper>. The visual tree is not exposed as conveniently through control-specific properties, so the <xref:System.Windows.Media.VisualTreeHelper> class is the recommended way to traverse the visual tree if that is necessary for your programming scenario. For more information, see [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md).  
  
> [!NOTE]
>  Sometimes it is necessary to examine the visual tree of an applied template. You should be careful when using this technique. Even if you are traversing a visual tree for a control where you define the template, consumers of your control can always change the template by setting the <xref:System.Windows.Controls.Control.Template%2A> property on instances, and even the end user can influence the applied template by changing the system theme.  
  
<a name="routes"></a>   
## Routes for Routed Events as a "Tree"  
 As mentioned before, the route of any given routed event travels along a single and predetermined path of a tree that is a hybrid of the visual and logical tree representations. The event route can travel either in the up or down directions within the tree depending on whether it is a tunneling or bubbling routed event. The event route concept does not have a directly supporting helper class that could be used to "walk" the event route independently of raising an event that actually routes. There is a class that represents the route, <xref:System.Windows.EventRoute>, but the methods of that class are generally for internal use only.  
  
<a name="resourcesandtrees"></a>   
## Resource Dictionaries and Trees  
 Resource dictionary lookup for all `Resources` defined in a page traverses basically the logical tree. Objects that are not in the logical tree can reference keyed resources, but the resource lookup sequence begins at the point where that object is connected to the logical tree. In WPF, only logical tree nodes can have a `Resources` property that contains a <xref:System.Windows.ResourceDictionary>, therefore there is no benefit in traversing the visual tree looking for keyed resources from a <xref:System.Windows.ResourceDictionary>.  
  
 However, resource lookup can also extend beyond the immediate logical tree. For application markup, the resource lookup can then continue onward to application-level resource dictionaries and then to theme support and system values that are referenced as static properties or keys. Themes themselves can also reference system values outside of the theme logical tree if the resource references are dynamic. For more information on resource dictionaries and the lookup logic, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
## See Also  
 [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md)  
 [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md)  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)  
 [Initialization for Object Elements Not in an Object Tree](../../../../docs/framework/wpf/advanced/initialization-for-object-elements-not-in-an-object-tree.md)  
 [WPF Architecture](../../../../docs/framework/wpf/advanced/wpf-architecture.md)
