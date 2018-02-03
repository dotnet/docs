---
title: "Control Authoring Overview"
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
  - "controls [WPF], authoring overview"
  - "authoring overview for controls [WPF]"
ms.assetid: 3d864748-cff0-4e63-9b23-d8e5a635b28f
caps.latest.revision: 32
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Control Authoring Overview
The extensibility of the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] control model greatly reduces the need to create a new control. However, in certain cases you may still need to create a custom control. This topic discusses the features that minimize your need to create a custom control and the different control authoring models in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)]. This topic also demonstrates how to create a new control.  
  
 
  
<a name="when_to_write_a_new_control"></a>   
## Alternatives to Writing a New Control  
 Historically, if you wanted to get a customized experience from an existing control, you were limited to changing the standard properties of the control, such as background color, border width, and font size. If you wished to extend the appearance or behavior of a control beyond these predefined parameters, you would need to create a new control, usually by inheriting from an existing control and overriding the method responsible for drawing the control.  Although that is still an option, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] enables to you customize existing controls by using its rich content model, styles, templates, and triggers. The following list gives examples of how these features can be used to create custom and consistent experiences without having to create a new control.  
  
-   **Rich Content.** Many of the standard [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls support rich content. For example, the content property of a <xref:System.Windows.Controls.Button> is of type <xref:System.Object>, so theoretically anything can be displayed on a <xref:System.Windows.Controls.Button>.  To have a button display an image and text, you can add an image and a <xref:System.Windows.Controls.TextBlock> to a <xref:System.Windows.Controls.StackPanel> and assign the <xref:System.Windows.Controls.StackPanel> to the <xref:System.Windows.Controls.ContentControl.Content%2A> property. Because the controls can display [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] visual elements and arbitrary data, there is less need to create a new control or to modify an existing control to support a complex visualization. For more information about the content model for <xref:System.Windows.Controls.Button> and other content models in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], see [WPF Content Model](../../../../docs/framework/wpf/controls/wpf-content-model.md).  
  
-   **Styles.** A <xref:System.Windows.Style> is a collection of values that represent properties for a control. By using styles, you can create a reusable representation of a desired control appearance and behavior without writing a new control. For example, assume that you want all of your <xref:System.Windows.Controls.TextBlock> controls to have red, Arial font with a font size of 14. You can create a style as a resource and set the appropriate properties accordingly. Then every <xref:System.Windows.Controls.TextBlock> that you add to your application will have the same appearance.  
  
-   **Data Templates.** A <xref:System.Windows.DataTemplate> enables you to customize how data is displayed on a control. For example, a <xref:System.Windows.DataTemplate> can be used to specify how data is displayed in a <xref:System.Windows.Controls.ListBox>.  For an example of this, see [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md).  In addition to customizing the appearance of data, a <xref:System.Windows.DataTemplate> can include UI elements, which gives you a lot of flexibility in custom UIs.  For example, by using a <xref:System.Windows.DataTemplate>, you can create a <xref:System.Windows.Controls.ComboBox> in which each item contains a check box.  
  
-   **Control Templates.** Many controls in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] use a <xref:System.Windows.Controls.ControlTemplate> to define the control's structure and appearance, which separates the appearance of a control from the functionality of the control. You can drastically change the appearance of a control by redefining its <xref:System.Windows.Controls.ControlTemplate>.  For example, suppose you want a control that looks like a stoplight. This control has a simple user interface and functionality.  The control is three circles, only one of which can be lit up at a time. After some reflection, you might realize that a <xref:System.Windows.Controls.RadioButton> offers the functionality of only one being selected at a time, but the default appearance of the <xref:System.Windows.Controls.RadioButton> looks nothing like the lights on a stoplight.  Because the <xref:System.Windows.Controls.RadioButton> uses a control template to define its appearance, it is easy to redefine the <xref:System.Windows.Controls.ControlTemplate> to fit the requirements of the control, and use radio buttons to make your stoplight.  
  
    > [!NOTE]
    >  Although a <xref:System.Windows.Controls.RadioButton> can use a <xref:System.Windows.DataTemplate>, a <xref:System.Windows.DataTemplate> is not sufficient in this example.  The <xref:System.Windows.DataTemplate> defines the appearance of the content of a control. In the case of a <xref:System.Windows.Controls.RadioButton>, the content is whatever appears to the right of the circle that indicates whether the <xref:System.Windows.Controls.RadioButton> is selected.  In the example of the stoplight, the radio button needs just be a circle that can "light up." Because the appearance requirement for the stoplight is so different than the default appearance of the <xref:System.Windows.Controls.RadioButton>, it is necessary to redefine the <xref:System.Windows.Controls.ControlTemplate>.  In general a <xref:System.Windows.DataTemplate> is used for defining the content (or data) of a control, and a <xref:System.Windows.Controls.ControlTemplate> is used for defining how a control is structured.  
  
-   **Triggers.** A <xref:System.Windows.Trigger> allows you to dynamically change the appearance and behavior of a control without creating a new control. For example, suppose you have multiple <xref:System.Windows.Controls.ListBox> controls in your application and want the items in each <xref:System.Windows.Controls.ListBox> to be bold and red when they are selected. Your first instinct might be to create a class that inherits from <xref:System.Windows.Controls.ListBox> and override the <xref:System.Windows.Controls.Primitives.Selector.OnSelectionChanged%2A> method to change the appearance of the selected item, but a better approach is to add a trigger to a style of a <xref:System.Windows.Controls.ListBoxItem> that changes the appearance of the selected item. A trigger enables you to change property values or take actions based on the value of a property. An <xref:System.Windows.EventTrigger> enables you to take actions when an event occurs.  
  
 For more information about styles, templates, and triggers, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
 In general, if your control mirrors the functionality of an existing control, but you want the control to look different, you should first consider whether you can use any of the methods discussed in this section to change the existing control's appearance.  
  
<a name="models_for_control_authoring"></a>   
## Models for Control Authoring  
 The rich content model, styles, templates, and triggers minimize the need for you to create a new control. However, if you do need to create a new control, it is important to understand the different control authoring models in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides three general models for creating a control, each of which provides a different set of features and level of flexibility. The base classes for the three models are <xref:System.Windows.Controls.UserControl>, <xref:System.Windows.Controls.Control>, and <xref:System.Windows.FrameworkElement>.  
  
### Deriving from UserControl  
 The simplest way to create a control in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is to derive from <xref:System.Windows.Controls.UserControl>. When you build a control that inherits from <xref:System.Windows.Controls.UserControl>, you add existing components to the <xref:System.Windows.Controls.UserControl>, name the components, and reference event handlers in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)]. You can then reference the named elements and define the event handlers in code. This development model is very similar to the model used for application development in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
 If built correctly, a <xref:System.Windows.Controls.UserControl> can take advantage of the benefits of rich content, styles, and triggers. However, if your control inherits from <xref:System.Windows.Controls.UserControl>, people who use your control will not be able to use a <xref:System.Windows.DataTemplate> or <xref:System.Windows.Controls.ControlTemplate> to customize its appearance.  It is necessary to derive from the <xref:System.Windows.Controls.Control> class or one of its derived classes (other than <xref:System.Windows.Controls.UserControl>) to create a custom control that supports templates.  
  
#### Benefits of Deriving from UserControl  
 Consider deriving from <xref:System.Windows.Controls.UserControl> if all of the following apply:  
  
-   You want to build your control similarly to how you build an application.  
  
-   Your control consists only of existing components.  
  
-   You don't need to support complex customization.  
  
### Deriving from Control  
 Deriving from the <xref:System.Windows.Controls.Control> class is the model used by most of the existing [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls. When you create a control that inherits from the <xref:System.Windows.Controls.Control> class, you define its appearance by using templates. By doing so, you separate the operational logic from the visual representation. You can also ensure the decoupling of the UI and logic by using commands and bindings instead of events and avoiding referencing elements in the <xref:System.Windows.Controls.ControlTemplate> whenever possible.  If the UI and logic of your control are properly decoupled, a user of your control can redefine the control's <xref:System.Windows.Controls.ControlTemplate> to customize its appearance. Although building a custom <xref:System.Windows.Controls.Control> is not as simple as building a <xref:System.Windows.Controls.UserControl>, a custom <xref:System.Windows.Controls.Control> provides the most flexibility.  
  
#### Benefits of Deriving from Control  
 Consider deriving from <xref:System.Windows.Controls.Control> instead of using the <xref:System.Windows.Controls.UserControl> class if any of the following apply:  
  
-   You want the appearance of your control to be customizable via the <xref:System.Windows.Controls.ControlTemplate>.  
  
-   You want your control to support different themes.  
  
### Deriving from FrameworkElement  
 Controls that derive from <xref:System.Windows.Controls.UserControl> or <xref:System.Windows.Controls.Control> rely upon composing existing elements. For many scenarios, this is an acceptable solution, because any object that inherits from <xref:System.Windows.FrameworkElement> can be in a <xref:System.Windows.Controls.ControlTemplate>. However, there are times when a control's appearance requires more than the functionality of simple element composition. For these scenarios, basing a component on <xref:System.Windows.FrameworkElement> is the right choice.  
  
 There are two standard methods for building <xref:System.Windows.FrameworkElement>-based components: direct rendering and custom element composition. Direct rendering involves overriding the <xref:System.Windows.UIElement.OnRender%2A> method of <xref:System.Windows.FrameworkElement> and providing <xref:System.Windows.Media.DrawingContext> operations that explicitly define the component visuals. This is the method used by <xref:System.Windows.Controls.Image> and <xref:System.Windows.Controls.Border>. Custom element composition involves using objects of type <xref:System.Windows.Media.Visual> to compose the appearance of your component. For an example, see [Using DrawingVisual Objects](../../../../docs/framework/wpf/graphics-multimedia/using-drawingvisual-objects.md). <xref:System.Windows.Controls.Primitives.Track> is an example of a control in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] that uses custom element composition. It is also possible to mix direct rendering and custom element composition in the same control.  
  
#### Benefits of Deriving from FrameworkElement  
 Consider deriving from <xref:System.Windows.FrameworkElement> if any of the following apply:  
  
-   You want to have precise control over the appearance of your control beyond what is provided by simple element composition.  
  
-   You want to define the appearance of your control by defining your own render logic.  
  
-   You want to compose existing elements in novel ways that go beyond what is possible with <xref:System.Windows.Controls.UserControl> and <xref:System.Windows.Controls.Control>.  
  
<a name="control_authoring_basics"></a>   
## Control Authoring Basics  
 As discussed earlier, one of the most powerful features of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is the ability to go beyond setting basic properties of a control to change its appearance and behavior, yet still not needing to create a custom control. The styling, data binding, and trigger features are made possible by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system and the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] event system. The following sections describe some practices that you should follow, regardless of the model you use to create the custom control, so that users of your custom control can use these features just as they would for a control that is included with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
### Use Dependency Properties  
 When a property is a dependency property, it is possible to do the following:  
  
-   Set the property in a style.  
  
-   Bind the property to a data source.  
  
-   Use a dynamic resource as the property's value.  
  
-   Animate the property.  
  
 If you want a property of your control to support any of this functionality, you should implement it as a dependency property. The following example defines a dependency property named `Value` by doing the following:  
  
-   Define a <xref:System.Windows.DependencyProperty> identifier named `ValueProperty` as a `public` `static` `readonly` field.  
  
-   Register the property name with the property system, by calling <xref:System.Windows.DependencyProperty.Register%2A?displayProperty=nameWithType>, to specify the following:  
  
    -   The name of the property.  
  
    -   The type of the property.  
  
    -   The type that owns the property.  
  
    -   The metadata for the property. The metadata contains the property's default value, a <xref:System.Windows.CoerceValueCallback> and a <xref:System.Windows.PropertyChangedCallback>.  
  
-   Define a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] wrapper property named `Value`, which is the same name that is used to register the dependency property, by implementing the property's `get` and `set` accessors. Note that the `get` and `set` accessors only call <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> respectively. It is recommended that the accessors of dependency properties not contain additional logic because clients and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] can bypass the accessors and call <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> directly. For example, when a property is bound to a data source, the property's `set` accessor is not called.  Instead of adding additional logic to the get and set accessors, use the <xref:System.Windows.ValidateValueCallback>, <xref:System.Windows.CoerceValueCallback>, and <xref:System.Windows.PropertyChangedCallback> delegates to respond to or check the value when it changes.  For more information on these callbacks, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md).  
  
-   Define a method for the <xref:System.Windows.CoerceValueCallback> named `CoerceValue`. `CoerceValue` ensures that `Value` is greater or equal to `MinValue` and less than or equal to `MaxValue`.  
  
-   Define a method for the <xref:System.Windows.PropertyChangedCallback>, named `OnValueChanged`. `OnValueChanged` creates a <xref:System.Windows.RoutedPropertyChangedEventArgs%601> object and prepares to raise the `ValueChanged` routed event. Routed events are discussed in the next section.  
  
 [!code-csharp[UserControlNumericUpDown#DependencyProperty](../../../../samples/snippets/csharp/VS_Snippets_Wpf/UserControlNumericUpDown/CSharp/NumericUpDown.xaml.cs#dependencyproperty)]
 [!code-vb[UserControlNumericUpDown#DependencyProperty](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UserControlNumericUpDown/visualbasic/numericupdown.xaml.vb#dependencyproperty)]  
  
 For more information, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md).  
  
### Use Routed Events  
 Just as dependency properties extend the notion of [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] properties with additional functionality, routed events extend the notion of standard [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] events. When you create a new [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control, it is also good practice to implement your event as a routed event because a routed event supports the following behavior:  
  
-   Events can be handled on a parent of multiple controls. If an event is a bubbling event, a single parent in the element tree can subscribe to the event. Then application authors can use one handler to respond to the event of multiple controls. For example, if your control is a part of each item in a <xref:System.Windows.Controls.ListBox> (because it is included in a <xref:System.Windows.DataTemplate>), the application developer can define the event handler for your control's event on the <xref:System.Windows.Controls.ListBox>. Whenever the event occurs on any of the controls, the event handler is called.  
  
-   Routed events can be used in an <xref:System.Windows.EventSetter>, which enables application developers to specify the handler of an event within a style.  
  
-   Routed events can be used in an <xref:System.Windows.EventTrigger>, which is useful for animating properties by using [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]. For more information, see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
 The following example defines a routed event by doing the following:  
  
-   Define a <xref:System.Windows.RoutedEvent> identifier named `ValueChangedEvent` as a `public` `static` `readonly` field.  
  
-   Register the routed event by calling the <xref:System.Windows.EventManager.RegisterRoutedEvent%2A?displayProperty=nameWithType> method. The example specifies the following information when it calls <xref:System.Windows.EventManager.RegisterRoutedEvent%2A>:  
  
    -   The name of the event is `ValueChanged`.  
  
    -   The routing strategy is <xref:System.Windows.RoutingStrategy.Bubble>, which means that an event handler on the source (the object that raises the event) is called first, and then event handlers on the source's parent elements are called in succession, starting with the event handler on the closest parent element.  
  
    -   The type of the event handler is <xref:System.Windows.RoutedPropertyChangedEventHandler%601>, constructed with a <xref:System.Decimal> type.  
  
    -   The owning type of the event is `NumericUpDown`.  
  
-   Declare a public event named `ValueChanged` and includes event-accessor declarations. The example calls <xref:System.Windows.UIElement.AddHandler%2A> in the `add` accessor declaration and <xref:System.Windows.UIElement.RemoveHandler%2A> in the `remove` accessor declaration to use the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] event services.  
  
-   Create a protected, virtual method named `OnValueChanged` that raises the `ValueChanged` event.  
  
 [!code-csharp[UserControlNumericUpDown#RoutedEvent](../../../../samples/snippets/csharp/VS_Snippets_Wpf/UserControlNumericUpDown/CSharp/NumericUpDown.xaml.cs#routedevent)]
 [!code-vb[UserControlNumericUpDown#RoutedEvent](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UserControlNumericUpDown/visualbasic/numericupdown.xaml.vb#routedevent)]  
  
 For more information, see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md) and [Create a Custom Routed Event](../../../../docs/framework/wpf/advanced/how-to-create-a-custom-routed-event.md).  
  
### Use Binding  
 To decouple the UI of your control from its logic, consider using data binding. This is particularly important if you define the appearance of your control by using a <xref:System.Windows.Controls.ControlTemplate>. When you use data binding, you might be able to eliminate the need to reference specific parts of the UI from the code. It's a good idea to avoid referencing elements that are in the <xref:System.Windows.Controls.ControlTemplate> because when the code references elements that are in the <xref:System.Windows.Controls.ControlTemplate> and the <xref:System.Windows.Controls.ControlTemplate> is changed, the referenced element needs to be included in the new <xref:System.Windows.Controls.ControlTemplate>.  
  
 The following example updates the <xref:System.Windows.Controls.TextBlock> of the `NumericUpDown` control, assigning a name to it and referencing the textbox by name in code.  
  
 [!code-xaml[UserControlNumericUpDownSimple#UIRefMarkup](../../../../samples/snippets/csharp/VS_Snippets_Wpf/UserControlNumericUpDownSimple/CSharp/NumericUpDown.xaml#uirefmarkup)]  
  
 [!code-csharp[UserControlNumericUpDownSimple#UIRefCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/UserControlNumericUpDownSimple/CSharp/NumericUpDown.xaml.cs#uirefcode)]
 [!code-vb[UserControlNumericUpDownSimple#UIRefCode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UserControlNumericUpDownSimple/VisualBasic/NumericUpDown.xaml.vb#uirefcode)]  
  
 The following example uses binding to accomplish the same thing.  
  
 [!code-xaml[UserControlNumericUpDown#Binding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/UserControlNumericUpDown/CSharp/NumericUpDown.xaml#binding)]  
  
 For more information about data binding, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
### Design for Designers  
 To receive support for custom WPF controls in the [!INCLUDE[wpfdesigner_current_long](../../../../includes/wpfdesigner-current-long-md.md)] (for example, property editing with the Properties window), follow these guidelines.  For more information on developing for the [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)], see [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26).  
  
#### Dependency Properties  
 Be sure to implement [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] `get` and `set` accessors as described earlier, in "Use Dependency Properties." Designers may use the wrapper to detect the presence of a dependency property, but they, like [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and clients of the control, are not required to call the accessors when getting or setting the property.  
  
#### Attached Properties  
 You should implement attached properties on custom controls using the following guidelines:  
  
-   Have a `public` `static` `readonly` <xref:System.Windows.DependencyProperty> of the form *PropertyName*`Property` that was creating using the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method. The property name that is passed to <xref:System.Windows.DependencyProperty.RegisterAttached%2A> must match *PropertyName*.  
  
-   Implement a pair of `public` `static` CLR methods named `Set`*PropertyName* and `Get`*PropertyName*. Both methods should accept a class derived from <xref:System.Windows.DependencyProperty> as their first argument. The `Set`*PropertyName* method also accepts an argument whose type matches the registered data type for the property. The `Get`*PropertyName* method should return a value of the same type. If the `Set`*PropertyName* method is missing, the property is marked read-only.  
  
-   `Set` *PropertyName* and `Get`*PropertyName* must route directly to the <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> methods on the target dependency object, respectively. Designers may access the attached property by calling through the method wrapper or making a direct call to the target dependency object.  
  
 For more information on attached properties, see [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md).  
  
### Define and Use Shared Resources  
 You can include your control in the same assembly as your application, or you can package your control in a separate assembly that can be used in multiple applications. For the most part, the information discussed in this topic applies regardless of the method you use.  There is one difference worth noting, however.  When you put a control in the same assembly as an application, you are free to add global resources to the App.xaml file. But an assembly that contains only controls does not have an <xref:System.Windows.Application> object associated with it, so an App.xaml file is not available.  
  
 When an application looks for a resource, it looks at three levels in the following order:  
  
1.  The element level.  
  
     The system starts with the element that references the resource and then searches resources of the logical parent and so forth until the root element is reached.  
  
2.  The application level.  
  
     Resources defined by the <xref:System.Windows.Application> object.  
  
3.  The theme level.  
  
     Theme-level dictionaries are stored in a subfolder named Themes.  The files in the Themes folder correspond to themes.  For example, you might have Aero.NormalColor.xaml, Luna.NormalColor.xaml, Royale.NormalColor.xaml, and so on.  You can also have a file named generic.xaml.  When the system looks for a resource at the themes level, it first looks for it in the theme-specific file and then looks for it in generic.xaml.  
  
 When your control is in an assembly that is separate from the application, you must put your global resources at the element level or at the theme level. Both methods have their advantages.  
  
#### Defining Resources at the Element Level  
 You can define shared resources at the element level by creating a custom resource dictionary and merging it with your control’s resource dictionary.  When you use this method, you can name your resource file anything you want, and it can be in the same folder as your controls. Resources at the element level can also use simple strings as keys. The following example creates a <xref:System.Windows.Media.LinearGradientBrush> resource file named Dictionary1.xaml.  
  
 [!code-xaml[SharedResources#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SharedResources/CS/Dictionary1.xaml#1)]  
  
 Once you have defined your dictionary, you need to merge it with your control's resource dictionary.  You can do this by using [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] or code.  
  
 The following example merges a resource dictionary by using [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
 [!code-xaml[SharedResources#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SharedResources/CS/ShapeResizer.xaml#2)]  
  
 The disadvantage to this approach is that a <xref:System.Windows.ResourceDictionary> object is created each time you reference it.  For example, if you have 10 custom controls in your library and merge the shared resource dictionaries for each control by using XAML, you create 10 identical <xref:System.Windows.ResourceDictionary> objects.  You can avoid this by creating a static class that merges the resources in code and returns the resulting <xref:System.Windows.ResourceDictionary>.  
  
 The following example creates a class that returns a shared <xref:System.Windows.ResourceDictionary>.  
  
 [!code-csharp[SharedResources#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SharedResources/CS/SharedDictionaryManager.cs#3)]  
  
 The following example merges the shared resource with the resources of a custom control in the control's constructor before it calls `InitializeComponent`.  Because the `SharedDictionaryManager.SharedDictionary` is a static property, the <xref:System.Windows.ResourceDictionary> is created only once. Because the resource dictionary was merged before `InitializeComponent` was called, the resources are available to the control in its [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file.  
  
 [!code-csharp[SharedResources#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SharedResources/CS/ShapeResizer.xaml.cs#4)]  
  
#### Defining Resources at the Theme Level  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] enables you to create resources for different Windows themes.  As a control author, you can define a resource for a specific theme to change your control's appearance depending on what theme is in use. For example, the appearance of a <xref:System.Windows.Controls.Button> in the Windows Classic theme (the default theme for Windows 2000) differs from a <xref:System.Windows.Controls.Button> in the Windows Luna theme (the default theme for Windows XP) because the <xref:System.Windows.Controls.Button> uses a different <xref:System.Windows.Controls.ControlTemplate> for each theme.  
  
 Resources that are specific to a theme are kept in a resource dictionary with a specific file name. These files must be in a folder named `Themes` that is a subfolder of the folder that contains the control. The following table lists the resource dictionary files and the theme that is associated with each file:  
  
|Resource dictionary file name|Windows theme|  
|-----------------------------------|-------------------|  
|`Classic.xaml`|Classic Windows 9x/2000 look on Windows XP|  
|`Luna.NormalColor.xaml`|Default blue theme on Windows XP|  
|`Luna.Homestead.xaml`|Olive theme on Windows XP|  
|`Luna.Metallic.xaml`|Silver theme on Windows XP|  
|`Royale.NormalColor.xaml`|Default theme on Windows XP Media Center Edition|  
|`Aero.NormalColor.xaml`|Default theme on Windows Vista|  
  
 You do not need to define a resource for every theme. If a resource is not defined for a specific theme, then the control checks `Classic.xaml` for the resource. If the resource is not defined in the file that corresponds to the current theme or in `Classic.xaml`, the control uses the generic resource, which is in a resource dictionary file named `generic.xaml`.  The `generic.xaml` file is located in the same folder as the theme-specific resource dictionary files. Although `generic.xaml` does not correspond to a specific Windows theme, it is still a theme-level dictionary.  
  
 [NumericUpDown Custom Control with Theme and UI Automation Support Sample](http://go.microsoft.com/fwlink/?LinkID=160025) contains two resource dictionaries for the `NumericUpDown` control: one is in generic.xaml and one is in Luna.NormalColor.xaml.  You can run the application and switch between the Silver theme in Windows XP and another theme to see the difference between the two control templates. (If you are running Windows Vista, you can rename Luna.NormalColor.xaml to Aero.NormalColor.xaml and switch between two themes, such as Windows Classic and the default theme for Windows Vista.)  
  
 When you put a <xref:System.Windows.Controls.ControlTemplate> in any of the theme-specific resource dictionary files, you must create a static constructor for your control and call the <xref:System.Windows.DependencyProperty.OverrideMetadata%28System.Type%2CSystem.Windows.PropertyMetadata%29> method on the <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A>, as shown in the following example.  
  
 [!code-csharp[CustomControlNumericUpDownOneProject#StaticConstructor](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CustomControlNumericUpDownOneProject/CSharp/NumericUpDown.cs#staticconstructor)]
 [!code-vb[CustomControlNumericUpDownOneProject#StaticConstructor](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CustomControlNumericUpDownOneProject/visualbasic/numericupdown.vb#staticconstructor)]  
  
##### Defining and Referencing Keys for Theme Resources  
 When you define a resource at the element level, you can assign a string as its key and access the resource via the string. When you define a resource at the theme level, you must use a <xref:System.Windows.ComponentResourceKey> as the key.  The following example defines a resource in generic.xaml.  
  
 [!code-xaml[ThemeResourcesControlLibrary#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ThemeResourcesControlLibrary/CS/Themes/generic.xaml#5)]  
  
 The following example references the resource by specifying the <xref:System.Windows.ComponentResourceKey> as the key.  
  
 [!code-xaml[ThemeResourcesControlLibrary#6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ThemeResourcesControlLibrary/CS/NumericUpDown.xaml#6)]  
  
##### Specifying the Location of Theme Resources  
 To find the resources for a control, the hosting application needs to know that the assembly contains control-specific resources. You can accomplish that by adding the <xref:System.Windows.ThemeInfoAttribute> to the assembly that contains the control. The <xref:System.Windows.ThemeInfoAttribute> has a <xref:System.Windows.ThemeInfoAttribute.GenericDictionaryLocation%2A> property that specifies the location of generic resources, and a <xref:System.Windows.ThemeInfoAttribute.ThemeDictionaryLocation%2A> property that specifies the location of the theme-specific resources.  
  
 The following example sets the <xref:System.Windows.ThemeInfoAttribute.GenericDictionaryLocation%2A> and <xref:System.Windows.ThemeInfoAttribute.ThemeDictionaryLocation%2A> properties to <xref:System.Windows.ResourceDictionaryLocation.SourceAssembly>, to specify that the generic and theme-specific resources are in the same assembly as the control.  
  
 [!code-csharp[CustomControlNumericUpDown#ThemesSection](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CustomControlNumericUpDown/CSharp/CustomControlLibrary/Properties/AssemblyInfo.cs#themessection)]
 [!code-vb[CustomControlNumericUpDown#ThemesSection](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CustomControlNumericUpDown/visualbasic/customcontrollibrary/my project/assemblyinfo.vb#themessection)]  
  
## See Also  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)  
 [Pack URIs in WPF](../../../../docs/framework/wpf/app-development/pack-uris-in-wpf.md)  
 [Control Customization](../../../../docs/framework/wpf/controls/control-customization.md)
