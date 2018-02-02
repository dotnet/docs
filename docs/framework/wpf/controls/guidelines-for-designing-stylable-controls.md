---
title: "Guidelines for Designing Stylable Controls"
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
  - "style design for controls [WPF]"
  - "controls [WPF], style design"
ms.assetid: c52dde45-a311-4531-af4c-853371c4d5f4
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Guidelines for Designing Stylable Controls
This document summarizes a set of best practices to consider when designing a control which you intend to be easily stylable and templatable. We came to this set of best practices through a lot of trial and error while working on the theme control styles for the built-in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control set. We learned that successful styling is as much a function of a well-designed object model as it is of the style itself. The intended audience for this document is the control author, not the style author.  
  
  <a name="Terminology"></a>   
## Terminology  
 "Styling and templating" refer to the suite of technologies that enable a control author to defer the visual aspects of the control to the style and template of the control. This suite of technologies includes:  
  
-   Styles (including property setters, triggers, and storyboards).  
  
-   Resources.  
  
-   Control templates.  
  
-   Data templates.  
  
 For an introduction to styling and templating, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
<a name="Before_You_Start__Understanding_Your_Control"></a>   
## Before You Start: Understanding Your Control  
 Before you jump into these guidelines, it is important to understand and have defined the common usage of your control. Styling exposes an often unruly set of possibilities. Controls that are written to be used broadly (in many applications, by many developers) face the challenge that styling can be used to make far-reaching changes to the visual appearance of the control. In fact, the styled control may not even resemble the control author's intentions. Since the flexibility offered by styling is essentially boundless, you can use the idea of common usage to help you scope your decisions.  
  
 To understand your control's common usage, it's good to think about the value proposition of the control. What does your control bring to the table that no other control can offer? Common usage does not imply any specific visual appearance, but rather the philosophy of the control and a reasonable set of expectations about its usage. This understanding allows you to make some assumptions about the composition model and the style-defined behaviors of the control in the common case. In the case of <xref:System.Windows.Controls.ComboBox>, for example, understanding the common usage won't give you any insight about whether a particular <xref:System.Windows.Controls.ComboBox> has rounded corners, but it will give you insight into the fact that the <xref:System.Windows.Controls.ComboBox> probably needs a pop-up window and some way of toggling whether it is open.  
  
<a name="General_Guidelines"></a>   
## General Guidelines  
  
-   **Do not strictly enforce template contracts.** The template contract of a control might consist of elements, commands, bindings, triggers, or even property settings that are required or expected for a control to function properly.  
  
    -   Minimize contracts as much as possible.  
  
    -   Design around the expectation that during design time (that is, when using a design tool) it is common for a control template to be in an incomplete state. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] does not offer a "composing" state infrastructure, so controls have to be built with the expectation that such a state might be valid.  
  
    -   Do not throw exceptions when any aspect of a template contract is not followed. Along these lines, panels should not throw exceptions if they have too many or too few children.  
  
-   **Factor peripheral functionality into template helper elements.** Each control should be focused on its core functionality and true value proposition and defined by the control's common usage. To that end, use composition and helper elements within the template to enable peripheral behaviors and visualizations, that is, those behaviors and visualizations that do not contribute to the core functionality of the control. Helper elements fall into three categories:  
  
    -   **Standalone** helper types are public and reusable controls or primitives that are used "anonymously" in a template, meaning that neither the helper element nor the styled control is aware of the other. Technically, any element can be an anonymous type, but in this context the term describes those types that encapsulate specialized functionality to enable targeted scenarios.  
  
    -   **Type-based** helper elements are new types that encapsulate specialized functionality. These elements are typically designed with a narrower range of functionality than common controls or primitives. Unlike standalone helper elements, type-based helper elements are aware of the context in which they are used and typically must share data with the control to whose template they belong.  
  
    -   **Named** helper elements are common controls or primitives that a control expects to find within its template by name. These elements are given a well-known name within the template, making it possible for a control to find the element and interact with it programmatically. There can only be one element with a given name in any template.  
  
     The following table shows helper elements employed by control styles today (this list is not exhaustive):  
  
    |Element|Type|Used by|  
    |-------------|----------|-------------|  
    |<xref:System.Windows.Controls.ContentPresenter>|Type-based|<xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.CheckBox>, <xref:System.Windows.Controls.RadioButton>, <xref:System.Windows.Controls.Frame>, and so on (all <xref:System.Windows.Controls.ContentControl> types)|  
    |<xref:System.Windows.Controls.ItemsPresenter>|Type-based|<xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.ComboBox>, <xref:System.Windows.Controls.Menu>, and so on (all <xref:System.Windows.Controls.ItemsControl> types)|  
    |<xref:System.Windows.Controls.Primitives.ToolBarOverflowPanel>|Named|<xref:System.Windows.Controls.ToolBar>|  
    |<xref:System.Windows.Controls.Primitives.Popup>|Standalone|<xref:System.Windows.Controls.ComboBox>, <xref:System.Windows.Controls.ToolBar>, <xref:System.Windows.Controls.Menu>, <xref:System.Windows.Controls.ToolTip>, and so on|  
    |<xref:System.Windows.Controls.Primitives.RepeatButton>|Named|<xref:System.Windows.Controls.Slider>, <xref:System.Windows.Controls.Primitives.ScrollBar>, and so on|  
    |<xref:System.Windows.Controls.Primitives.ScrollBar>|Named|<xref:System.Windows.Controls.ScrollViewer>|  
    |<xref:System.Windows.Controls.ScrollViewer>|Standalone|<xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.ComboBox>, <xref:System.Windows.Controls.Menu>, <xref:System.Windows.Controls.Frame>, and so on|  
    |<xref:System.Windows.Controls.Primitives.TabPanel>|Standalone|<xref:System.Windows.Controls.TabControl>|  
    |<xref:System.Windows.Controls.TextBox>|Named|<xref:System.Windows.Controls.ComboBox>|  
    |<xref:System.Windows.Controls.Primitives.TickBar>|Type-based|<xref:System.Windows.Controls.Slider>|  
  
-   **Minimize required user-specified bindings or property settings on helper elements**. It is common for a helper element to require certain bindings or property settings in order to function properly within the control template. The helper element and templated control should, as much as possible, establish these settings. When setting properties or establishing bindings, care should be taken to not override values set by the user. Specific best practices are as follows:  
  
    -   Named helper elements should be identified by the parent and the parent should establish any required settings on the helper element.  
  
    -   Type-based helper elements should establish any required settings directly on themselves. Doing this may require the helper element to query for information context in which it is being used, including its `TemplatedParent` (the control type of the template in which it is being used). For example, <xref:System.Windows.Controls.ContentPresenter> automatically binds the `Content` property of its `TemplatedParent` to its <xref:System.Windows.Controls.ContentPresenter.Content%2A> property when used in a <xref:System.Windows.Controls.ContentControl> derived type.  
  
    -   Standalone helper elements cannot be optimized in this way because, by definition, neither the helper element nor the parent knows about the other.  
  
-   **Use the Name property to flag elements within a template**. A control that needs to find an element in its style in order to access it programmatically should do so using the `Name` property and the `FindName` paradigm. A control should not throw an exception when an element is not found, but silently and gracefully disable the functionality which required that element.  
  
-   **Use best practices for expressing control state and behavior in a style.** The following is an ordered list of best practices for expressing control state changes and behavior in a style. You should use the first item on the list that enables your scenario.  
  
    1.  Property binding. Example: binding between <xref:System.Windows.Controls.ComboBox.IsDropDownOpen%2A?displayProperty=nameWithType> and <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A?displayProperty=nameWithType>.  
  
    2.  Triggered property changes or property animations. Example: the hover state of a <xref:System.Windows.Controls.Button>.  
  
    3.  Command. Example: <xref:System.Windows.Controls.Primitives.ScrollBar.LineUpCommand> / <xref:System.Windows.Controls.Primitives.ScrollBar.LineDownCommand> in <xref:System.Windows.Controls.Primitives.ScrollBar>.  
  
    4.  Standalone helper elements. Example: <xref:System.Windows.Controls.Primitives.TabPanel> in <xref:System.Windows.Controls.TabControl>.  
  
    5.  Type-based helper types. Example: <xref:System.Windows.Controls.ContentPresenter> in <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.Primitives.TickBar> in <xref:System.Windows.Controls.Slider>.  
  
    6.  Named helper elements. Example: <xref:System.Windows.Controls.TextBox> in <xref:System.Windows.Controls.ComboBox>.  
  
    7.  Bubbled events from named helper types. If you listen for bubbled events from a style element, you should require that the element generating the event can be uniquely identified. Example: <xref:System.Windows.Controls.Primitives.Thumb> in <xref:System.Windows.Controls.ToolBar>.  
  
    8.  Custom `OnRender` behavior. Example: <xref:Microsoft.Windows.Themes.ButtonChrome> in <xref:System.Windows.Controls.Button>.  
  
-   **Use style triggers (as opposed to template triggers) sparingly**. Triggers that affect properties on elements in the template must be declared in the template. Triggers that affect properties on the control (no `TargetName`) may be declared in the style unless you know that changing the template should also destroy the trigger.  
  
-   **Be consistent with existing styling patterns.** Many times there are multiple ways to solve a problem. Be aware of and, when possible, consistent with existing control styling patterns. This is especially important for controls that derive from the same base type (for example, <xref:System.Windows.Controls.ContentControl>, <xref:System.Windows.Controls.ItemsControl>, <xref:System.Windows.Controls.Primitives.RangeBase>, and so on).  
  
-   **Expose properties to enable common customization scenarios without retemplating**. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] does not support pluggable/customizable parts, so a control user is left with only two methods of customization: setting properties directly or setting properties using styles. With that in mind, it is appropriate to surface a limited number of properties targeted at very common, high-priority customization scenarios which would otherwise require the retemplating. Here are best practices for when and how to enable customization scenarios:  
  
    -   Very common customizations should be exposed as properties on the control and consumed by the template.  
  
    -   Less common (though not rare) customizations should be exposed as attached properties and consumed by the template.  
  
    -   It is acceptable for known but rare customizations to require retemplating.  
  
<a name="Theme_Considerations"></a>   
## Theme Considerations  
  
-   **Theme styles should attempt to have consistent property semantics across all themes, but make no guarantee**. As part of its documentation, your control should have a document describing the control's property semantics, that is, the "meaning" of a property for a control. For example, the <xref:System.Windows.Controls.ComboBox> control should define the meaning of the <xref:System.Windows.Controls.Control.Background%2A> property within <xref:System.Windows.Controls.ComboBox>. The default styles for your control should attempt to follow the semantics defined in that document across all themes. Control users, on the other hand, should be aware that property semantics can change from theme to theme. In certain cases, a given property may not be expressible under the visual constraints required by a particular theme. (The Classic theme, for example, does not have a single border to which `Thickness` can be applied for many controls.)  
  
-   **Theme styles do not need to have consistent trigger semantics across all themes**. The behavior exposed by a control style through triggers or animations may vary from theme to theme. Control users should be aware that a control will not necessarily employ the same mechanism to achieve a particular behavior across all themes. One theme, for example, may use an animation to express hover behavior where another theme uses a trigger. This can result in inconsistencies in behavior preservation on customized controls. (Changing the background property, for example, might not affect the hover state of the control if that state is expressed using a trigger. However, if the hover state is implemented using an animation, changing to background could irreparably break the animation and therefore the state transition.)  
  
-   **Theme styles do not need to have consistent "layout" semantics across all themes**. For example, the default style does not need to guarantee that a control will occupy the same amount of size in all themes or guarantee that a control will have the same content margins / padding across all themes.  
  
## See Also  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md)
