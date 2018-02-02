---
title: "Focus Overview"
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
  - "applications [WPF], focus"
  - "focus in applications [WPF]"
ms.assetid: 0230c4eb-0c8a-462b-ac4b-ae3e511659f4
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Focus Overview
In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] there are two main concepts that pertain to focus: keyboard focus and logical focus.  Keyboard focus refers to the element that receives keyboard input and logical focus refers to the element in a focus scope that has focus.  These concepts are discussed in detail in this overview.  Understanding the difference in these concepts is important for creating complex applications that have multiple regions where focus can be obtained.  
  
 The major classes that participate in focus management are the <xref:System.Windows.Input.Keyboard> class, the <xref:System.Windows.Input.FocusManager> class, and the base element classes, such as <xref:System.Windows.UIElement> and <xref:System.Windows.ContentElement>.  For more information about the base elements, see the [Base Elements Overview](../../../../docs/framework/wpf/advanced/base-elements-overview.md).  
  
 The <xref:System.Windows.Input.Keyboard> class is concerned primarily with keyboard focus and the <xref:System.Windows.Input.FocusManager> is concerned primarily with logical focus, but this is not an absolute distinction.  An element that has keyboard focus will also have logical focus, but an element that has logical focus does not necessarily have keyboard focus.  This is apparent when you use the <xref:System.Windows.Input.Keyboard> class to set the element that has keyboard focus, for it also sets logical focus on the element.  
  

  
<a name="Keyboard_Focus"></a>   
## Keyboard Focus  
 Keyboard focus refers to the element that is currently receiving keyboard input.  There can be only one element on the whole desktop that has keyboard focus.  In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], the element that has keyboard focus will have <xref:System.Windows.IInputElement.IsKeyboardFocused%2A> set to `true`.  The static property <xref:System.Windows.Input.Keyboard.FocusedElement%2A> on the <xref:System.Windows.Input.Keyboard> class gets the element that currently has keyboard focus.  
  
 In order for an element to obtain keyboard focus, the <xref:System.Windows.UIElement.Focusable%2A> and the <xref:System.Windows.UIElement.IsVisible%2A> properties on the base elements must be set to `true`.  Some classes, such as the <xref:System.Windows.Controls.Panel> base class, have <xref:System.Windows.UIElement.Focusable%2A> set to `false` by default; therefore, you must set <xref:System.Windows.UIElement.Focusable%2A> to `true` if you want such an element to be able to obtain keyboard focus.  
  
 Keyboard focus can be obtained through user interaction with the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)], such as tabbing to an element or clicking the mouse on certain elements.  Keyboard focus can also be obtained programmatically by using the <xref:System.Windows.Input.Keyboard.Focus%2A> method on the <xref:System.Windows.Input.Keyboard> class.  The <xref:System.Windows.Input.Keyboard.Focus%2A> method attempts to give the specified element keyboard focus.  The returned element is the element that has keyboard focus, which might be a different element than requested if either the old or new focus object block the request.  
  
 The following example uses the <xref:System.Windows.Input.Keyboard.Focus%2A> method to set keyboard focus on a <xref:System.Windows.Controls.Button>.  
  
 [!code-csharp[focussample#FocusSampleSetFocus](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FocusSample/CSharp/Window1.xaml.cs#focussamplesetfocus)]
 [!code-vb[focussample#FocusSampleSetFocus](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FocusSample/visualbasic/window1.xaml.vb#focussamplesetfocus)]  
  
 The <xref:System.Windows.UIElement.IsKeyboardFocused%2A> property on the base element classes gets a value indicating whether the element has keyboard focus.  The <xref:System.Windows.UIElement.IsKeyboardFocusWithin%2A> property on the base element classes gets a value indicating whether the element or any one of its visual child elements has keyboard focus.  
  
 When setting initial focus at application startup, the element to receive focus must be in the visual tree of the initial window loaded by the application, and the element must have <xref:System.Windows.UIElement.Focusable%2A> and <xref:System.Windows.UIElement.IsVisible%2A> set to `true`.  The recommended place to set initial focus is in the <xref:System.Windows.FrameworkElement.Loaded> event handler.  A <xref:System.Windows.Threading.Dispatcher> callback can also be used by calling <xref:System.Windows.Threading.Dispatcher.Invoke%2A> or <xref:System.Windows.Threading.Dispatcher.BeginInvoke%2A>.  
  
<a name="Logical_Focus"></a>   
## Logical Focus  
 Logical focus refers to the <xref:System.Windows.Input.FocusManager.FocusedElement%2A?displayProperty=nameWithType> in a focus scope.  A focus scope is an element that keeps track of the <xref:System.Windows.Input.FocusManager.FocusedElement%2A> within its scope.  When keyboard focus leaves a focus scope, the focused element will lose keyboard focus but will retain logical focus.  When keyboard focus returns to the focus scope, the focused element will obtain keyboard focus.  This allows for keyboard focus to be changed between multiple focus scopes but ensures that the focused element in the focus scope regains keyboard focus when focus returns to the focus scope.  
  
 There can be multiple elements that have logical focus in an application, but there may only be one element that has logical focus in a particular focus scope.  
  
 An element that has keyboard focus has logical focus for the focus scope it belongs to.  
  
 An element can be turned into a focus scope in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] by setting the <xref:System.Windows.Input.FocusManager> attached property <xref:System.Windows.Input.FocusManager.IsFocusScope%2A> to `true`.  In code, an element can be turned into a focus scope by calling <xref:System.Windows.Input.FocusManager.SetIsFocusScope%2A>.  
  
 The following example makes a <xref:System.Windows.Controls.StackPanel> into a focus scope by setting the <xref:System.Windows.Input.FocusManager.IsFocusScope%2A> attached property.  
  
 [!code-xaml[MarkupSnippets#MarkupIsFocusScopeXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MarkupSnippets/CSharp/Window1.xaml#markupisfocusscopexaml)]  
  
 [!code-csharp[FocusSnippets#FocusSetIsFocusScope](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FocusSnippets/CSharp/Window1.xaml.cs#focussetisfocusscope)]
 [!code-vb[FocusSnippets#FocusSetIsFocusScope](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FocusSnippets/visualbasic/window1.xaml.vb#focussetisfocusscope)]  
  
 <xref:System.Windows.Input.FocusManager.GetFocusScope%2A> returns the focus scope for the specified element.  
  
 Classes in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] which are focus scopes by default are <xref:System.Windows.Window>, <xref:System.Windows.Controls.MenuItem>, <xref:System.Windows.Controls.ToolBar>, and <xref:System.Windows.Controls.ContextMenu>.  
  
 <xref:System.Windows.Input.FocusManager.GetFocusedElement%2A> gets the focused element for the specified focus scope.  <xref:System.Windows.Input.FocusManager.SetFocusedElement%2A> sets the focused element in the specified focus scope.  <xref:System.Windows.Input.FocusManager.SetFocusedElement%2A> is typically used to set the initial focused element.  
  
 The following example sets the focused element on a focus scope and gets the focused element of a focus scope.  
  
 [!code-csharp[FocusSnippets#FocusGetSetFocusedElement](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FocusSnippets/CSharp/Window1.xaml.cs#focusgetsetfocusedelement)]
 [!code-vb[FocusSnippets#FocusGetSetFocusedElement](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FocusSnippets/visualbasic/window1.xaml.vb#focusgetsetfocusedelement)]  
  
<a name="Keyboard_Navigation"></a>   
## Keyboard Navigation  
 The <xref:System.Windows.Input.KeyboardNavigation> class is responsible for implementing default keyboard focus navigation when one of the navigation keys is pressed.  The navigation keys are: TAB, SHIFT+TAB, CTRL+TAB, CTRL+SHIFT+TAB, UPARROW, DOWNARROW, LEFTARROW, and RIGHTARROW keys.  
  
 The navigation behavior of a navigation container can be changed by setting the attached <xref:System.Windows.Input.KeyboardNavigation> properties <xref:System.Windows.Input.KeyboardNavigation.TabNavigation%2A>, <xref:System.Windows.Input.KeyboardNavigation.ControlTabNavigation%2A>, and <xref:System.Windows.Input.KeyboardNavigation.DirectionalNavigation%2A>.  These properties are of type <xref:System.Windows.Input.KeyboardNavigationMode> and the possible values are <xref:System.Windows.Input.KeyboardNavigationMode.Continue>, <xref:System.Windows.Input.KeyboardNavigationMode.Local>, <xref:System.Windows.Input.KeyboardNavigationMode.Contained>, <xref:System.Windows.Input.KeyboardNavigationMode.Cycle>, <xref:System.Windows.Input.KeyboardNavigationMode.Once>, and <xref:System.Windows.Input.KeyboardNavigationMode.None>.  The default value is <xref:System.Windows.Input.KeyboardNavigationMode.Continue>, which means the element is not a navigation container.  
  
 The following example creates a <xref:System.Windows.Controls.Menu> with a number of <xref:System.Windows.Controls.MenuItem> objects.  The <xref:System.Windows.Input.KeyboardNavigation.TabNavigation%2A> attached property is set to <xref:System.Windows.Input.KeyboardNavigationMode.Cycle> on the <xref:System.Windows.Controls.Menu>.  When focus is changed using the tab key within the <xref:System.Windows.Controls.Menu>, focus will move from each element and when the last element is reached focus will return to the first element.  
  
 [!code-xaml[MarkupSnippets#MarkupKeyboardNavigationTabNavigationXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MarkupSnippets/CSharp/Window1.xaml#markupkeyboardnavigationtabnavigationxaml)]  
  
 [!code-csharp[MarkupSnippets#MarkupKeyboardNavigationTabNavigationCODE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MarkupSnippets/CSharp/Window1.xaml.cs#markupkeyboardnavigationtabnavigationcode)]
 [!code-vb[MarkupSnippets#MarkupKeyboardNavigationTabNavigationCODE](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/MarkupSnippets/visualbasic/window1.xaml.vb#markupkeyboardnavigationtabnavigationcode)]  
  
<a name="Manipulating_Focus_Programmatically"></a>   
## Navigating Focus Programmatically  
 Additional [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)] to work with focus are <xref:System.Windows.UIElement.MoveFocus%2A> and <xref:System.Windows.UIElement.PredictFocus%2A>.  
  
 <xref:System.Windows.FrameworkElement.MoveFocus%2A> changes focus to the next element in the application.  A <xref:System.Windows.Input.TraversalRequest> is used to specify the direction.   The <xref:System.Windows.Input.FocusNavigationDirection> passed to <xref:System.Windows.UIElement.MoveFocus%2A> specifies the different directions focus can be moved, such as <xref:System.Windows.Input.FocusNavigationDirection.First>, <xref:System.Windows.Input.FocusNavigationDirection.Last>, <xref:System.Windows.Input.FocusNavigationDirection.Up> and <xref:System.Windows.Input.FocusNavigationDirection.Down>.  
  
 The following example uses <xref:System.Windows.FrameworkElement.MoveFocus%2A> to change the focused element.  
  
 [!code-csharp[focussample#FocusSampleMoveFocus](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FocusSample/CSharp/Window1.xaml.cs#focussamplemovefocus)]
 [!code-vb[focussample#FocusSampleMoveFocus](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FocusSample/visualbasic/window1.xaml.vb#focussamplemovefocus)]  
  
 <xref:System.Windows.FrameworkElement.PredictFocus%2A> returns the object which would receive focus if focus were to be changed.  Currently, only <xref:System.Windows.Input.FocusNavigationDirection.Up>, <xref:System.Windows.Input.FocusNavigationDirection.Down>, <xref:System.Windows.Input.FocusNavigationDirection.Left>, and <xref:System.Windows.Input.FocusNavigationDirection.Right> are supported by <xref:System.Windows.FrameworkElement.PredictFocus%2A>.  
  
<a name="Focus_Events"></a>   
## Focus Events  
 The events related to keyboard focus are <xref:System.Windows.Input.Keyboard.PreviewGotKeyboardFocus>, <xref:System.Windows.Input.Keyboard.GotKeyboardFocus> and <xref:System.Windows.Input.Keyboard.PreviewLostKeyboardFocus>, <xref:System.Windows.Input.Keyboard.LostKeyboardFocus>.  The events are defined as attached events on the <xref:System.Windows.Input.Keyboard> class, but are more readily accessible as equivalent routed events on the base element classes.  For more information about events, see the [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
 <xref:System.Windows.Input.Keyboard.GotKeyboardFocus> is raised when the element obtains keyboard focus.  <xref:System.Windows.Input.Keyboard.LostKeyboardFocus> is raised when the element loses keyboard focus.  If the <xref:System.Windows.Input.Keyboard.PreviewGotKeyboardFocus> event or the <xref:System.Windows.Input.Keyboard.PreviewLostKeyboardFocusEvent> event is handled and <xref:System.Windows.RoutedEventArgs.Handled%2A> is set to `true`, then focus will not change.  
  
 The following example attaches <xref:System.Windows.UIElement.GotKeyboardFocus> and <xref:System.Windows.UIElement.LostKeyboardFocus> event handlers to a <xref:System.Windows.Controls.TextBox>.  
  
 [!code-xaml[keyboardsample#KeyboardSampleXAMLHandlerHookup](../../../../samples/snippets/csharp/VS_Snippets_Wpf/KeyboardSample/CSharp/Window1.xaml#keyboardsamplexamlhandlerhookup)]  
  
 When the <xref:System.Windows.Controls.TextBox> obtains keyboard focus, the <xref:System.Windows.Controls.Control.Background%2A> property of the <xref:System.Windows.Controls.TextBox> is changed to <xref:System.Windows.Media.Brushes.LightBlue%2A>.  
  
 [!code-csharp[keyboardsample#KeyboardSampleGotFocus](../../../../samples/snippets/csharp/VS_Snippets_Wpf/KeyboardSample/CSharp/Window1.xaml.cs#keyboardsamplegotfocus)]
 [!code-vb[keyboardsample#KeyboardSampleGotFocus](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/KeyboardSample/visualbasic/window1.xaml.vb#keyboardsamplegotfocus)]  
  
 When the <xref:System.Windows.Controls.TextBox> loses keyboard focus, the <xref:System.Windows.Controls.Control.Background%2A> property of the <xref:System.Windows.Controls.TextBox> is changed back to white.  
  
 [!code-csharp[keyboardsample#KeyboardSampleLostFocus](../../../../samples/snippets/csharp/VS_Snippets_Wpf/KeyboardSample/CSharp/Window1.xaml.cs#keyboardsamplelostfocus)]
 [!code-vb[keyboardsample#KeyboardSampleLostFocus](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/KeyboardSample/visualbasic/window1.xaml.vb#keyboardsamplelostfocus)]  
  
 The events related to logical focus are <xref:System.Windows.UIElement.GotFocus> and <xref:System.Windows.UIElement.LostFocus>.  These events are defined on the <xref:System.Windows.Input.FocusManager> as attached events, but the <xref:System.Windows.Input.FocusManager> does not expose CLR event wrappers.  <xref:System.Windows.UIElement> and <xref:System.Windows.ContentElement> expose these events more conveniently.  
  
## See Also  
 <xref:System.Windows.Input.FocusManager>  
 <xref:System.Windows.UIElement>  
 <xref:System.Windows.ContentElement>  
 [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md)  
 [Base Elements Overview](../../../../docs/framework/wpf/advanced/base-elements-overview.md)
