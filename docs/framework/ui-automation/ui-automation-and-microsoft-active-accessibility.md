---
title: "UI Automation and Microsoft Active Accessibility"
description: Understand the differences between UI Automation and Microsoft Active Accessibility, the previous solution for making applications accessible.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Active Accessibility"
  - "UI Automation, Active Accessibility compared to"
  - "UI Automation, Microsoft Active Accessibility"
  - "Active Accessibility, UI Automation compared to"
ms.assetid: 87bee662-0a3e-4232-a421-20e7a5968321
---
# UI Automation and Microsoft Active Accessibility

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 Microsoft Active Accessibility was the earlier solution for making applications accessible. Microsoft UI Automation is the new accessibility model for Microsoft Windows and is intended to address the needs of assistive technology products and automated testing tools. UI Automation offers many improvements over Active Accessibility.

 This topic includes the main features of UI Automation and explains how these features differ from Active Accessibility.

<a name="Programming_Languages_compare"></a>

## Programming Languages

Active Accessibility is based on the Component Object Model (COM) with support for dual interfaces, and is therefore programmable in C/C++, Microsoft Visual Basic 6.0, and scripting languages. UI Automation (including the client-side provider library for standard controls) is written in managed code, and UI Automation client applications are most easily programmed using C# or Visual Basic .NET. UI Automation providers, which are interface implementations, can be written in managed code or in C/C++.

<a name="Support_in_Windows_Presentation_Foundation_"></a>

## Support in Windows Presentation Foundation

 Windows Presentation Foundation (WPF) is the new model for creating user interfaces. WPF elements do not contain native support for Active Accessibility; however, they do support UI Automation, which includes bridging support for Active Accessibility clients. Only clients written specifically for UI Automation can take full advantage of the accessibility features of WPF, such as the rich support for text.

<a name="Servers_and_Clients_compare"></a>

## Servers and Clients

 In Active Accessibility, servers and clients communicate directly, largely through the server's implementation of `IAccessible`.

 In UI Automation, a core service lies between the server (called a provider) and the client. The core service makes calls to the interfaces implemented by providers and provides additional services such as generating unique runtime identifiers for elements. Client applications use library functions to call the UI Automation service.

 UI Automation providers can provide information to Active Accessibility clients, and Active Accessibility servers can provide information to UI Automation client applications. However, because Active Accessibility does not expose as much information as UI Automation, the two models are not fully compatible.

<a name="UI_Elements_compare"></a>

## UI Elements

 Active Accessibility presents UI elements either as an `IAccessible` interface or as a child identifier. It is difficult to compare two `IAccessible` pointers to determine if they refer to the same element.

 In UI Automation, every element is represented as an <xref:System.Windows.Automation.AutomationElement> object. Comparison is done by using the equality operator or the <xref:System.Windows.Automation.AutomationElement.Equals%2A> method, both of which compare the unique runtime identifiers of the elements.

<a name="Tree_Views_and_Navigation_compare"></a>

## Tree Views and Navigation

 The user interface (UI) elements on the screen can be seen as a tree structure with the desktop as the root, application windows as immediate children, and elements within applications as further descendants.

 In Active Accessibility, many automation elements that are irrelevant to end users are exposed in the tree. Client applications have to look at all the elements to determine which are meaningful.

 UI Automation client applications see the UI through a filtered view. The view contains only elements of interest: those that give information to the user or enable interaction. Predefined views of only control elements and only content elements are available; in addition, applications can define custom views. UI Automation simplifies the task of describing the UI to the user and helping the user interact with the application.

 Navigation between elements, in Active Accessibility, is either spatial (for example, moving to the element that lies to the left on the screen), logical (for example, moving to the next menu item, or the next item in the tab order within a dialog box), or hierarchical (for example, moving the first child in a container, or from the child to its parent). Hierarchical navigation is complicated by the fact that child elements are not always objects that implement `IAccessible`.

 In UI Automation, all UI elements are <xref:System.Windows.Automation.AutomationElement> objects that support the same basic functionality. (From the standpoint of the provider, they are objects that implement an interface inherited from <xref:System.Windows.Automation.Provider.IRawElementProviderSimple>.) Navigation is mainly hierarchical: from parents to children, and from one sibling to the next. (Navigation between siblings has a logical element, as it may follow the tab order.) You can navigate from any starting-point, using any filtered view of the tree, by using the <xref:System.Windows.Automation.TreeWalker> class. You can also navigate to particular children or descendants by using <xref:System.Windows.Automation.AutomationElement.FindFirst%2A> and <xref:System.Windows.Automation.AutomationElement.FindAll%2A>; for example, it is very easy to retrieve all elements within a dialog box that support a specified control pattern.

 Navigation in UI Automation is more consistent than in Active Accessibility. Some elements such as drop-down lists and pop-up windows appear twice in the Active Accessibility tree, and navigation from them may have unexpected results. It is actually impossible to properly implement Active Accessibility for a rebar control. UI Automation enables reparenting and repositioning, so that an element can be placed anywhere in the tree despite the hierarchy imposed by ownership of windows.

<a name="Roles_and_Control_Types"></a>

## Roles and Control Types

 Active Accessibility uses the `accRole` property (`IAccessible::get_actRole`) to retrieve a description of the element's role in the UI, such as ROLE_SYSTEM_SLIDER or ROLE_SYSTEM_MENUITEM. The role of an element is the main clue to its available functionality. Interaction with a control is achieved by using fixed methods such as `IAccessible::accSelect` and `IAccessible::accDoDefaultAction`. The interaction between the client application and the UI is limited to what can be done through `IAccessible`.

 In contrast, UI Automation largely decouples the control type of the element (described by the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.ControlType%2A> property) from its expected functionality. Functionality is determined by the control patterns that are supported by the provider through its implementation of specialized interfaces. Control patterns can be combined to describe the full set of functionality supported by a particular UI element. Some providers are required to support a particular control pattern; for example, the provider for a check box must support the Toggle control pattern. Other providers are required to support one or more of a set of control patterns; for example, a button must support either Toggle or Invoke. Still others support no control patterns at all; for example, a pane that cannot be moved, resized, or docked does not have any control patterns.

 UI Automation supports custom controls, which are identified by the <xref:System.Windows.Automation.ControlType.Custom> property and can be described by the <xref:System.Windows.Automation.AutomationElement.LocalizedControlTypeProperty> property.

 The following table shows the mapping of Active Accessibility roles to UI Automation control types.

|Active Accessibility role|UI Automation control type|
|----------------------------------------------------------------------|----------------------------------------------------------------------------------------|
|ROLE_SYSTEM_PUSHBUTTON|Button|
|ROLE_SYSTEM_CLIENT|Calendar|
|ROLE_SYSTEM_CHECKBUTTON|Check box|
|ROLE_SYSTEM_COMBOBOX|Combo box|
|ROLE_SYSTEM_CLIENT|Custom|
|ROLE_SYSTEM_LIST|Data grid|
|ROLE_SYSTEM_LISTITEM|Data item|
|ROLE_SYSTEM_DOCUMENT|Document|
|ROLE_SYSTEM_TEXT|Edit|
|ROLE_SYSTEM_GROUPING|Group|
|ROLE_SYSTEM_LIST|Header|
|ROLE_SYSTEM_COLUMNHEADER|Header item|
|ROLE_SYSTEM_LINK|Hyperlink|
|ROLE_SYSTEM_GRAPHIC|Image|
|ROLE_SYSTEM_LIST|List|
|ROLE_SYSTEM_LISTITEM|List item|
|ROLE_SYSTEM_MENUPOPUP|Menu|
|ROLE_SYSTEM_MENUBAR|Menu bar|
|ROLE_SYSTEM_MENUITEM|Menu item|
|ROLE_SYSTEM_PANE|Pane|
|ROLE_SYSTEM_PROGRESSBAR|Progress bar|
|ROLE_SYSTEM_RADIOBUTTON|Radio button|
|ROLE_SYSTEM_SCROLLBAR|Scroll bar|
|ROLE_SYSTEM_SEPARATOR|Separator|
|ROLE_SYSTEM_SLIDER|Slider|
|ROLE_SYSTEM_SPINBUTTON|Spinner|
|ROLE_SYSTEM_SPLITBUTTON|Split button|
|ROLE_SYSTEM_STATUSBAR|Status bar|
|ROLE_SYSTEM_PAGETABLIST|Tab|
|ROLE_SYSTEM_PAGETAB|Tab item|
|ROLE_SYSTEM_TABLE|Table|
|ROLE_SYSTEM_STATICTEXT|Text|
|ROLE_SYSTEM_INDICATOR|Thumb|
|ROLE_SYSTEM_TITLEBAR|Title bar|
|ROLE_SYSTEM_TOOLBAR|Tool bar|
|ROLE_SYSTEM_TOOLTIP|ToolTip|
|ROLE_SYSTEM_OUTLINE|Tree|
|ROLE_SYSTEM_OUTLINEITEM|Tree item|
|ROLE_SYSTEM_WINDOW|Window|

 For more information about the different control types, see [UI Automation Control Types](ui-automation-control-types.md).

<a name="States_and_Properties"></a>

## States and Properties

 In Active Accessibility, elements support a common set of properties, and some properties (such as `accState`) must describe very different things, depending on the element's role. Servers must implement all methods of `IAccessible` that return a property, even those that are not relevant to the element.

 UI Automation defines many more properties, some of which correspond to states in Active Accessibility. Some are common to all elements, but others are specific to control types and control patterns. Properties are distinguished by unique identifiers, and most properties can be retrieved by using a single method, <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A> or <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A>. Many properties are also easily retrievable from the <xref:System.Windows.Automation.AutomationElement.Current%2A> and <xref:System.Windows.Automation.AutomationElement.Cached%2A> property accessors.

 A UI Automation provider does not have to implement irrelevant properties, but can simply return a `null` value for any properties it does not support. Also, the UI Automation core service can obtain some properties from the default window provider, and these are amalgamated with properties explicitly implemented by the provider.

 As well as supporting many more properties, UI Automation supplies better performance by allowing multiple properties to be retrieved with a single cross-process call.

 The following table shows the correspondence between properties in the two models.

|Active Accessibility property accessor|UI Automation property ID|Remarks|
|-----------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|-------------|
|`get_accKeyboardShortcut`|<xref:System.Windows.Automation.AutomationElement.AccessKeyProperty> or <xref:System.Windows.Automation.AutomationElement.AcceleratorKeyProperty>|`AccessKeyProperty` takes precedence if both are present.|
|`get_accName`|<xref:System.Windows.Automation.AutomationElement.NameProperty>||
|`get_accRole`|<xref:System.Windows.Automation.AutomationElement.ControlTypeProperty>|See the previous table for mapping of roles to control types.|
|`get_accValue`|<xref:System.Windows.Automation.ValuePattern.ValueProperty?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.RangeValuePattern.ValueProperty?displayProperty=nameWithType>|Valid only for control types that support ValuePattern or RangeValuePattern. RangeValue values are normalized to 0-100, to be consistent with MSAA behavior. Value items use a string.|
|`get_accHelp`|<xref:System.Windows.Automation.AutomationElement.HelpTextProperty>||
|`accLocation`|<xref:System.Windows.Automation.AutomationElement.BoundingRectangleProperty>||
|`get_accDescription`|Not supported in UI Automation|`accDescription` did not have a clear specification within MSAA, which resulted in providers placing different pieces of information in this property.|
|`get_accHelpTopic`|Not supported in UI Automation||

 The following table shows which UI Automation properties correspond to Active Accessibility state constants.

|Active Accessibility state|UI Automation property|Triggers State Change?|
|-----------------------------------------------------------------------|------------------------------------------------------------------------------------|----------------------------|
|STATE_SYSTEM_CHECKED|For check box, <xref:System.Windows.Automation.TogglePattern.ToggleStateProperty><br /><br /> For radio button, <xref:System.Windows.Automation.SelectionItemPattern.IsSelectedProperty>|Y|
|STATE_SYSTEM_COLLAPSED|<xref:System.Windows.Automation.ExpandCollapsePattern.ExpandCollapsePatternInformation.ExpandCollapseState%2A> = <xref:System.Windows.Automation.ExpandCollapseState.Collapsed>|Y|
|STATE_SYSTEM_EXPANDED|<xref:System.Windows.Automation.ExpandCollapsePattern.ExpandCollapsePatternInformation.ExpandCollapseState%2A> = <xref:System.Windows.Automation.ExpandCollapseState.Expanded> or <xref:System.Windows.Automation.ExpandCollapseState.PartiallyExpanded>|Y|
|STATE_SYSTEM_FOCUSABLE|<xref:System.Windows.Automation.AutomationElement.IsKeyboardFocusableProperty>|N|
|STATE_SYSTEM_FOCUSED|<xref:System.Windows.Automation.AutomationElement.HasKeyboardFocusProperty>|N|
|STATE_SYSTEM_HASPOPUP|<xref:System.Windows.Automation.ExpandCollapsePattern> for menu items|N|
|STATE_SYSTEM_INVISIBLE|<xref:System.Windows.Automation.AutomationElement.IsOffscreenProperty> = True and <xref:System.Windows.Automation.AutomationElement.GetClickablePoint%2A> causes <xref:System.Windows.Automation.NoClickablePointException>|N|
|STATE_SYSTEM_LINKED|<xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> =<br /><br /> <xref:System.Windows.Automation.ControlType.Hyperlink>|N|
|STATE_SYSTEM_MIXED|<xref:System.Windows.Automation.TogglePattern.TogglePatternInformation.ToggleState%2A> = <xref:System.Windows.Automation.ToggleState.Indeterminate>|N|
|STATE_SYSTEM_MOVEABLE|<xref:System.Windows.Automation.TransformPattern.CanMoveProperty>|N|
|STATE_SYSTEM_MUTLISELECTABLE|<xref:System.Windows.Automation.SelectionPattern.CanSelectMultipleProperty>|N|
|STATE_SYSTEM_OFFSCREEN|<xref:System.Windows.Automation.AutomationElement.IsOffscreenProperty> = True|N|
|STATE_SYSTEM_PROTECTED|<xref:System.Windows.Automation.AutomationElement.IsPasswordProperty>|N|
|STATE_SYSTEM_READONLY|<xref:System.Windows.Automation.RangeValuePattern.IsReadOnlyProperty?displayProperty=nameWithType> and <xref:System.Windows.Automation.ValuePattern.IsReadOnlyProperty?displayProperty=nameWithType>|N|
|STATE_SYSTEM_SELECTABLE|<xref:System.Windows.Automation.SelectionItemPattern> is supported|N|
|STATE_SYSTEM_SELECTED|<xref:System.Windows.Automation.SelectionItemPattern.IsSelectedProperty>|N|
|STATE_SYSTEM_SIZEABLE|<xref:System.Windows.Automation.TransformPattern.TransformPatternInformation.CanResize%2A>|N|
|STATE_SYSTEM_UNAVAILABLE|<xref:System.Windows.Automation.AutomationElement.IsEnabledProperty>|Y|

 The following states either were not implemented by most Active Accessibility control servers or have no equivalent in UI Automation.

|Active Accessibility state|Remarks|
|-----------------------------------------------------------------------|-------------|
|STATE_SYSTEM_BUSY|Not available in UI Automation|
|STATE_SYSTEM_DEFAULT|Not available in UI Automation|
|STATE_SYSTEM_ANIMATED|Not available in UI Automation|
|STATE_SYSTEM_EXTSELECTABLE|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_MARQUEED|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_SELFVOICING|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_TRAVERSED|Not available in UI Automation|
|STATE_SYSTEM_ALERT_HIGH|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_ALERT_MEDIUM|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_ALERT_LOW|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_FLOATING|Not widely implemented by Active Accessibility servers|
|STATE_SYSTEM_HOTTRACKED|Not available in UI Automation|
|STATE_SYSTEM_PRESSED|Not available in UI Automation|

 For a complete list of UI Automation property identifiers, see [UI Automation Properties Overview](ui-automation-properties-overview.md).

<a name="uiautomation_events_compare"></a>

## Events

 The event mechanism in UI Automation, unlike that in Active Accessibility, does not rely on Windows event routing (which is closely tied in with window handles) and does not require the client application to set up hooks. Subscriptions to events can be fine-tuned not just to particular events but to particular parts of the tree. Providers can also fine-tune their raising of events by keeping track of what events are being listened for.

 It is also easier for clients to retrieve the elements that raise events, as these are passed directly to the event callback. Properties of the element are automatically prefetched if a cache request was active when the client subscribed to the event.

 The following table shows the correspondence of Active Accessibility WinEvents and UI Automation events.

|WinEvent|UI Automation event identifier|
|--------------|--------------------------------------------------------------------------------------------|
|EVENT_OBJECT_ACCELERATORCHANGE|<xref:System.Windows.Automation.AutomationElement.AcceleratorKeyProperty> property change|
|EVENT_OBJECT_CONTENTSCROLLED|<xref:System.Windows.Automation.ScrollPattern.VerticalScrollPercentProperty> or <xref:System.Windows.Automation.ScrollPattern.HorizontalScrollPercentProperty> property change on the associated scroll bars|
|EVENT_OBJECT_CREATE|<xref:System.Windows.Automation.AutomationElement.StructureChangedEvent>|
|EVENT_OBJECT_DEFACTIONCHANGE|No equivalent|
|EVENT_OBJECT_DESCRIPTIONCHANGE|No exact equivalent; perhaps <xref:System.Windows.Automation.AutomationElement.HelpTextProperty> or <xref:System.Windows.Automation.AutomationElement.LocalizedControlTypeProperty> property change|
|EVENT_OBJECT_DESTROY|<xref:System.Windows.Automation.AutomationElement.StructureChangedEvent>|
|EVENT_OBJECT_FOCUS|<xref:System.Windows.Automation.AutomationElement.AutomationFocusChangedEvent>|
|EVENT_OBJECT_HELPCHANGE|<xref:System.Windows.Automation.AutomationElement.HelpTextProperty> change|
|EVENT_OBJECT_HIDE|<xref:System.Windows.Automation.AutomationElement.StructureChangedEvent>|
|EVENT_OBJECT_LOCATIONCHANGE|<xref:System.Windows.Automation.AutomationElement.BoundingRectangleProperty> property change|
|EVENT_OBJECT_NAMECHANGE|<xref:System.Windows.Automation.AutomationElement.NameProperty> property change|
|EVENT_OBJECT_PARENTCHANGE|<xref:System.Windows.Automation.AutomationElement.StructureChangedEvent>|
|EVENT_OBJECT_REORDER|Not consistently used in Active Accessibility. No directly corresponding event is defined in UI Automation.|
|EVENT_OBJECT_SELECTION|<xref:System.Windows.Automation.SelectionItemPattern.ElementSelectedEvent>|
|EVENT_OBJECT_SELECTIONADD|<xref:System.Windows.Automation.SelectionItemPattern.ElementAddedToSelectionEvent>|
|EVENT_OBJECT_SELECTIONREMOVE|<xref:System.Windows.Automation.SelectionItemPattern.ElementRemovedFromSelectionEvent>|
|EVENT_OBJECT_SELECTIONWITHIN|No equivalent|
|EVENT_OBJECT_SHOW|<xref:System.Windows.Automation.AutomationElement.StructureChangedEvent>|
|EVENT_OBJECT_STATECHANGE|Various property-changed events|
|EVENT_OBJECT_VALUECHANGE|<xref:System.Windows.Automation.RangeValuePattern.ValueProperty?displayProperty=nameWithType> and <xref:System.Windows.Automation.ValuePattern.ValueProperty?displayProperty=nameWithType> changed|
|EVENT_SYSTEM_ALERT|No equivalent|
|EVENT_SYSTEM_CAPTUREEND|No equivalent|
|EVENT_SYSTEM_CAPTURESTART|No equivalent|
|EVENT_SYSTEM_CONTEXTHELPEND|No equivalent|
|EVENT_SYSTEM_CONTEXTHELPSTART|No equivalent|
|EVENT_SYSTEM_DIALOGEND|<xref:System.Windows.Automation.WindowPattern.WindowClosedEvent>|
|EVENT_SYSTEM_DIALOGSTART|<xref:System.Windows.Automation.WindowPattern.WindowOpenedEvent>|
|EVENT_SYSTEM_DRAGDROPEND|No equivalent|
|EVENT_SYSTEM_DRAGDROPSTART|No equivalent|
|EVENT_SYSTEM_FOREGROUND|<xref:System.Windows.Automation.AutomationElement.AutomationFocusChangedEvent>|
|EVENT_SYSTEM_MENUEND|<xref:System.Windows.Automation.AutomationElement.MenuClosedEvent>|
|EVENT_SYSTEM_MENUPOPUPEND|<xref:System.Windows.Automation.AutomationElement.MenuClosedEvent>|
|EVENT_SYSTEM_MENUPOPUPSTART|<xref:System.Windows.Automation.AutomationElement.MenuOpenedEvent>|
|EVENT_SYSTEM_MENUSTART|<xref:System.Windows.Automation.AutomationElement.MenuOpenedEvent>|
|EVENT_SYSTEM_MINIMIZEEND|<xref:System.Windows.Automation.WindowPattern.WindowVisualStateProperty> property change|
|EVENT_SYSTEM_MINIMIZESTART|<xref:System.Windows.Automation.WindowPattern.WindowVisualStateProperty> property change|
|EVENT_SYSTEM_MOVESIZEEND|<xref:System.Windows.Automation.AutomationElement.BoundingRectangleProperty> property change|
|EVENT_SYSTEM_MOVESIZESTART|<xref:System.Windows.Automation.AutomationElement.BoundingRectangleProperty> property change|
|EVENT_SYSTEM_SCROLLINGEND|<xref:System.Windows.Automation.ScrollPattern.VerticalScrollPercentProperty> or <xref:System.Windows.Automation.ScrollPattern.HorizontalScrollPercentProperty> property change|
|EVENT_SYSTEM_SCROLLINGSTART|<xref:System.Windows.Automation.ScrollPattern.VerticalScrollPercentProperty> or <xref:System.Windows.Automation.ScrollPattern.HorizontalScrollPercentProperty> property change|
|EVENT_SYSTEM_SOUND|No equivalent|
|EVENT_SYSTEM_SWITCHEND|No equivalent, but an <xref:System.Windows.Automation.AutomationElement.AutomationFocusChangedEvent> event signals that a new application has received the focus|
|EVENT_SYSTEM_SWITCHSTART|No equivalent|
|No equivalent|<xref:System.Windows.Automation.MultipleViewPattern.CurrentViewProperty> property change|
|No equivalent|<xref:System.Windows.Automation.ScrollPattern.HorizontallyScrollableProperty> property change|
|No equivalent|<xref:System.Windows.Automation.ScrollPattern.VerticallyScrollableProperty> property change|
|No equivalent|<xref:System.Windows.Automation.ScrollPattern.HorizontalScrollPercentProperty> property change|
|No equivalent|<xref:System.Windows.Automation.ScrollPattern.VerticalScrollPercentProperty> property change|
|No equivalent|<xref:System.Windows.Automation.ScrollPattern.HorizontalViewSizeProperty> property change|
|No equivalent|<xref:System.Windows.Automation.ScrollPattern.VerticalViewSizeProperty> property change|
|No equivalent|<xref:System.Windows.Automation.TogglePattern.ToggleStateProperty> property change|
|No equivalent|<xref:System.Windows.Automation.WindowPattern.WindowVisualStateProperty> property change|
|No equivalent|<xref:System.Windows.Automation.AutomationElement.AsyncContentLoadedEvent> event|
|No equivalent|<xref:System.Windows.Automation.AutomationElement.ToolTipOpenedEvent>|

<a name="Security_compare"></a>

## Security

 Some `IAccessible` customization scenarios require wrapping a base `IAccessible` and calling through to it. This has security implications, since a partially trusted component should not be an intermediary on a code path.

 The UI Automation model removes the need for providers to call through to other provider code. The UI Automation core service does all the necessary aggregation.

## See also

- [UI Automation Fundamentals](index.md)
