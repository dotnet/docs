---
title: "UI Automation of a WPF Custom Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "custom controls [WPF], applying UI automation"
  - "accessibility [WPF], applying to custom controls"
  - "custom controls [WPF], improving accessibility"
  - "UI Automation [WPF], using with custom controls"
ms.assetid: 47b310fc-fbd5-4ce2-a606-22d04c6d4911
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# UI Automation of a WPF Custom Control
[!INCLUDE[TLA#tla_uiautomation](../../../../includes/tlasharptla-uiautomation-md.md)] provides a single, generalized interface that automation clients can use to examine or operate the user interfaces of a variety of platforms and frameworks. [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] enables both quality-assurance (test) code and accessibility applications such as screen readers to examine user-interface elements and simulate user interaction with them from other code. For information about [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] across all platforms, see Accessibility.  
  
 This topic describes how to implement a server-side UI Automation provider for a custom control that runs in a WPF application. WPF supports [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] through a tree of peer automation objects that parallels the tree of user interface elements. Test code and applications that provide accessibility features can use automation peer objects directly (for in-process code) or through the generalized interface provided by [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)].  
  
 
  
<a name="AutomationPeerClasses"></a>   
## Automation Peer Classes  
 WPF controls support [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] through a tree of peer classes that derive from <xref:System.Windows.Automation.Peers.AutomationPeer>. By convention, peer class names begin with the control class name and end with "AutomationPeer". For example, <xref:System.Windows.Automation.Peers.ButtonAutomationPeer> is the peer class for the <xref:System.Windows.Controls.Button> control class. The peer classes are roughly equivalent to [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] control types but are specific to [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] elements. Automation code that accesses WPF applications through the [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] interface does not use automation peers directly, but automation code in the same process space can use automation peers directly.  
  
<a name="BuiltInAutomationPeerClasses"></a>   
## Built-in Automation Peer Classes  
 Elements implement an automation peer class if they accept interface activity from the user, or if they contain information needed by users of screen-reader applications. Not all WPF visual elements have automation peers. Examples of classes that implement automation peers are <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.TextBox>, and <xref:System.Windows.Controls.Label>. Examples of classes that do not implement automation peers are classes that derive from <xref:System.Windows.Controls.Decorator>, such as <xref:System.Windows.Controls.Border>, and classes based on <xref:System.Windows.Controls.Panel>, such as <xref:System.Windows.Controls.Grid> and <xref:System.Windows.Controls.Canvas>.  
  
 The base <xref:System.Windows.Controls.Control> class does not have a corresponding peer class. If you need a peer class to correspond to a custom control that derives from <xref:System.Windows.Controls.Control>, you should derive the custom peer class from <xref:System.Windows.Automation.Peers.FrameworkElementAutomationPeer>.  
  
<a name="SecurityConsiderations"></a>   
## Security Considerations for Derived Peers  
 Automation peers must run in a partial-trust environment. Code in the UIAutomationClient assembly is not configured to run in a partial-trust environment, and automation peer code should not reference that assembly. Instead, you should use the classes in the UIAutomationTypes assembly. For example, you should use the <xref:System.Windows.Automation.AutomationElementIdentifiers> class from the UIAutomationTypes assembly, which corresponds to the <xref:System.Windows.Automation.AutomationElement> class in the UIAutomationClient assembly. It is safe to reference the UIAutomationTypes assembly in automation peer code.  
  
<a name="PeerNavigation"></a>   
## Peer Navigation  
 After locating an automation peer, in-process code can navigate the peer tree by calling the object's <xref:System.Windows.Automation.Peers.AutomationPeer.GetChildren%2A> and <xref:System.Windows.Automation.Peers.AutomationPeer.GetParent%2A> methods. Navigation among [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] elements within a control is supported by the peer's implementation of the <xref:System.Windows.Automation.Peers.AutomationPeer.GetChildrenCore%2A> method. The UI Automation system calls this method to build up a tree of subelements contained within a control; for example, list items in a list box. The default <xref:System.Windows.Automation.Peers.UIElementAutomationPeer.GetChildrenCore%2A?displayProperty=nameWithType> method traverses the visual tree of elements to build the tree of automation peers. Custom controls override this method to expose children elements to automation clients, returning the automation peers of elements that convey information or allow user interaction.  
  
<a name="Customizations"></a>   
## Customizations in a Derived Peer  
 All classes that derive from <xref:System.Windows.UIElement> and <xref:System.Windows.ContentElement> contain the protected virtual method <xref:System.Windows.UIElement.OnCreateAutomationPeer%2A>. WPF calls <xref:System.Windows.UIElement.OnCreateAutomationPeer%2A> to get the automation peer object for each control. Automation code can use the peer to get information about a control’s characteristics and features and to simulate interactive use. A custom control that supports automation must override <xref:System.Windows.UIElement.OnCreateAutomationPeer%2A> and return an instance of a class that derives from <xref:System.Windows.Automation.Peers.AutomationPeer>. For example, if a custom control derives from the <xref:System.Windows.Controls.Primitives.ButtonBase> class, then the object returned by <xref:System.Windows.UIElement.OnCreateAutomationPeer%2A> should derive from <xref:System.Windows.Automation.Peers.ButtonBaseAutomationPeer>.  
  
 When implementing a custom control, you must override the "Core" methods from the base automation peer class that describe behavior unique and specific to your custom control.  
  
### Override OnCreateAutomationPeer  
 Override the <xref:System.Windows.UIElement.OnCreateAutomationPeer%2A> method for your custom control so that it returns your provider object, which must derive directly or indirectly from <xref:System.Windows.Automation.Peers.AutomationPeer>.  
  
### Override GetPattern  
 Automation peers simplify some implementation aspects of server-side [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] providers, but custom control automation peers must still handle pattern interfaces. Like non-WPF providers, peers support control patterns by providing implementations of interfaces in the <xref:System.Windows.Automation.Provider?displayProperty=nameWithType> namespace, such as <xref:System.Windows.Automation.Provider.IInvokeProvider>. The control pattern interfaces can be implemented by the peer itself or by another object. The peer's implementation of <xref:System.Windows.Automation.Peers.AutomationPeer.GetPattern%2A> returns the object that supports the specified pattern. [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] code calls the <xref:System.Windows.Automation.Peers.UIElementAutomationPeer.GetPattern%2A> method and specifies a <xref:System.Windows.Automation.Peers.PatternInterface> enumeration value. Your override of <xref:System.Windows.Automation.Peers.UIElementAutomationPeer.GetPattern%2A> should return the object that implements the specified pattern. If your control does not have a custom implementation of a pattern, you can call the base type's implementation of <xref:System.Windows.Automation.Peers.AutomationPeer.GetPattern%2A> to retrieve either its implementation or null if the pattern is not supported for this control type. For example, a custom NumericUpDown control can be set to a value within a range, so its [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] peer would implement the <xref:System.Windows.Automation.Provider.IRangeValueProvider> interface. The following example shows how the peer's <xref:System.Windows.Automation.Peers.UIElementAutomationPeer.GetPattern%2A> method is overridden to respond to a <xref:System.Windows.Automation.Peers.PatternInterface.RangeValue?displayProperty=nameWithType> value.  
  
 [!code-csharp[CustomControlNumericUpDown#GetPattern](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CustomControlNumericUpDown/CSharp/CustomControlLibrary/NumericUpDown.cs#getpattern)]
 [!code-vb[CustomControlNumericUpDown#GetPattern](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CustomControlNumericUpDown/visualbasic/customcontrollibrary/numericupdown.vb#getpattern)]  
  
 A <xref:System.Windows.Automation.Peers.UIElementAutomationPeer.GetPattern%2A> method can also specify a subelement as a pattern provider. The following code shows how <xref:System.Windows.Controls.ItemsControl> transfers scroll pattern handling to the peer of its internal <xref:System.Windows.Controls.ScrollViewer> control.  
  
```csharp  
public override object GetPattern(PatternInterface patternInterface)  
{  
    if (patternInterface == PatternInterface.Scroll)  
    {  
        ItemsControl owner = (ItemsControl) base.Owner;  
  
        // ScrollHost is internal to the ItemsControl class  
        if (owner.ScrollHost != null)  
        {  
            AutomationPeer peer = UIElementAutomationPeer.CreatePeerForElement(owner.ScrollHost);  
            if ((peer != null) && (peer is IScrollProvider))  
            {  
                peer.EventsSource = this;  
                return (IScrollProvider) peer;  
            }  
        }  
    }  
    return base.GetPattern(patternInterface);  
}  
```  
  
```vb  
Public Class Class1  
    Public Overrides Function GetPattern(ByVal patternInterface__1 As PatternInterface) As Object  
        If patternInterface1 = PatternInterface.Scroll Then  
            Dim owner As ItemsControl = DirectCast(MyBase.Owner, ItemsControl)  
  
            ' ScrollHost is internal to the ItemsControl class  
            If owner.ScrollHost IsNot Nothing Then  
                Dim peer As AutomationPeer = UIElementAutomationPeer.CreatePeerForElement(owner.ScrollHost)  
                If (peer IsNot Nothing) AndAlso (TypeOf peer Is IScrollProvider) Then  
                    peer.EventsSource = Me  
                    Return DirectCast(peer, IScrollProvider)  
                End If  
            End If  
        End If  
        Return MyBase.GetPattern(patternInterface1)  
    End Function  
End Class  
```  
  
 To specify a subelement for pattern handling, this code gets the subelement object, creates a peer by using the <xref:System.Windows.Automation.Peers.UIElementAutomationPeer.CreatePeerForElement%2A> method, sets the <xref:System.Windows.Automation.Peers.AutomationPeer.EventsSource%2A> property of the new peer to the current peer, and returns the new peer. Setting <xref:System.Windows.Automation.Peers.AutomationPeer.EventsSource%2A> on a subelement prevents the subelement from appearing in the automation peer tree and designates all events raised by the subelement as originating from the control specified in <xref:System.Windows.Automation.Peers.AutomationPeer.EventsSource%2A>. The <xref:System.Windows.Controls.ScrollViewer> control does not appear in the automation tree, and scrolling events that it generates appear to originate from the <xref:System.Windows.Controls.ItemsControl> object.  
  
### Override "Core" Methods  
 Automation code gets information about your control by calling public methods of the peer class. To provide information about your control, override each method whose name ends with "Core" when your control implementation differs from that of that provided by the base automation peer class. At a minimum, your control must implement the <xref:System.Windows.Automation.Peers.AutomationPeer.GetClassNameCore%2A> and <xref:System.Windows.Automation.Peers.AutomationPeer.GetAutomationControlTypeCore%2A> methods, as shown in the following example.  
  
 [!code-csharp[CustomControlNumericUpDown#CoreOverrides](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CustomControlNumericUpDown/CSharp/CustomControlLibrary/NumericUpDown.cs#coreoverrides)]
 [!code-vb[CustomControlNumericUpDown#CoreOverrides](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CustomControlNumericUpDown/visualbasic/customcontrollibrary/numericupdown.vb#coreoverrides)]  
  
 Your implementation of <xref:System.Windows.Automation.Peers.AutomationPeer.GetAutomationControlTypeCore%2A> describes your control by returning a <xref:System.Windows.Automation.ControlType> value. Although you can return <xref:System.Windows.Automation.ControlType.Custom?displayProperty=nameWithType>, you should return one of the more specific control types if it accurately describes your control. A return value of <xref:System.Windows.Automation.ControlType.Custom?displayProperty=nameWithType> requires extra work for the provider to implement [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)], and [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] client products are unable to anticipate the control structure, keyboard interaction, and possible control patterns.  
  
 Implement the <xref:System.Windows.Automation.Peers.AutomationPeer.IsContentElementCore%2A> and <xref:System.Windows.Automation.Peers.AutomationPeer.IsControlElementCore%2A> methods to indicate whether your control contains data content or fulfills an interactive role in the user interface (or both). By default, both methods return `true`. These settings improve the usability of automation tools such as screen readers, which may use these methods to filter the automation tree. If your <xref:System.Windows.Automation.Peers.AutomationPeer.GetPattern%2A> method transfers pattern handling to a subelement peer, the subelement peer's <xref:System.Windows.Automation.Peers.AutomationPeer.IsControlElementCore%2A> method can return false to hide the subelement peer from the automation tree. For example, scrolling in a <xref:System.Windows.Controls.ListBox> is handled by a <xref:System.Windows.Controls.ScrollViewer>, and the automation peer for <xref:System.Windows.Automation.Peers.PatternInterface.Scroll?displayProperty=nameWithType> is returned by the <xref:System.Windows.Automation.Peers.AutomationPeer.GetPattern%2A> method of the <xref:System.Windows.Automation.Peers.ScrollViewerAutomationPeer> that is associated with the <xref:System.Windows.Automation.Peers.ListBoxAutomationPeer>.Therefore, the <xref:System.Windows.Automation.Peers.AutomationPeer.IsControlElementCore%2A> method of the <xref:System.Windows.Automation.Peers.ScrollViewerAutomationPeer> returns `false`, so that the <xref:System.Windows.Automation.Peers.ScrollViewerAutomationPeer> does not appear in the automation tree.  
  
 Your automation peer should provide appropriate default values for your control. Note that XAML that references your control can override your peer implementations of core methods by including <xref:System.Windows.Automation.AutomationProperties> attributes. For example, the following XAML creates a button that has two customized [!INCLUDE[TLA2#tla_uiautomation](../../../../includes/tla2sharptla-uiautomation-md.md)] properties.  
  
```xaml  
<Button AutomationProperties.Name="Special"   
    AutomationProperties.HelpText="This is a special button."/>  
```  
  
### Implement Pattern Providers  
 The interfaces implemented by a custom provider are explicitly declared if the owning element derives directly from <xref:System.Windows.Controls.Control>. For example, the following code declares a peer for a <xref:System.Windows.Controls.Control> that implements a range value.  
  
```csharp  
public class RangePeer1 : FrameworkElementAutomationPeer, IRangeValueProvider { }  
```  
  
```vb  
Public Class RangePeer1  
    Inherits FrameworkElementAutomationPeer  
    Implements IRangeValueProvider  
End Class  
```  
  
 If the owning control derives from a specific type of control such as <xref:System.Windows.Controls.Primitives.RangeBase>, the peer can be derived from an equivalent derived peer class. In this case, the peer would derive from <xref:System.Windows.Automation.Peers.RangeBaseAutomationPeer>, which supplies a base implementation of <xref:System.Windows.Automation.Provider.IRangeValueProvider>. The following code shows the declaration of such a peer.  
  
```csharp  
public class RangePeer2 : RangeBaseAutomationPeer { }  
```  
  
```vb  
Public Class RangePeer2  
    Inherits RangeBaseAutomationPeer  
End Class  
```  
  
 For an example implementation, see [NumericUpDown Custom Control with Theme and UI Automation Support Sample](http://go.microsoft.com/fwlink/?LinkID=160025).  
  
### Raise Events  
 Automation clients can subscribe to automation events. Custom controls must report changes to control state by calling the <xref:System.Windows.Automation.Peers.AutomationPeer.RaiseAutomationEvent%2A> method. Similarly, when a property value changes, call the <xref:System.Windows.Automation.Peers.AutomationPeer.RaisePropertyChangedEvent%2A> method. The following code shows how to get the peer object from within the control code and call a method to raise an event. As an optimization, the code determines if there are any listeners for this event type. Raising the event only when there are listeners avoids unnecessary overhead and helps the control remain responsive.  
  
 [!code-csharp[CustomControlNumericUpDown#RaiseEventFromControl](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CustomControlNumericUpDown/CSharp/CustomControlLibrary/NumericUpDown.cs#raiseeventfromcontrol)]
 [!code-vb[CustomControlNumericUpDown#RaiseEventFromControl](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CustomControlNumericUpDown/visualbasic/customcontrollibrary/numericupdown.vb#raiseeventfromcontrol)]  
  
## See Also  
 [UI Automation Overview](../../../../docs/framework/ui-automation/ui-automation-overview.md)  
 [NumericUpDown Custom Control with Theme and UI Automation Support Sample](http://go.microsoft.com/fwlink/?LinkID=160025)  
 [Server-Side UI Automation Provider Implementation](../../../../docs/framework/ui-automation/server-side-ui-automation-provider-implementation.md)
