---
title: Create a template in WPF - .NET Desktop
description: Learn how to create and reference a control template in Windows Presentation Foundation and .NET Core.
author: thraka
ms.author: adegeo
ms.date: 11/15/2019
no-loc: ["<Window>", "<ControlTemplate>", "<Ellipse>", "<ContentPresenter>", "<Trigger>", "<Setter>", "<PropertyTrigger>", "<Grid>", "<VisualStateManager.VisualStateGroups>", "<VisualStateGroup>", "<VisualState>", "<Storyboard>", "SizeToContent", "MinWidth", "TargetType", "Title"]
helpviewer_keywords: 
  - "control contract [WPF]"
  - "controls [WPF], visual structure changes"
  - "ControlTemplate [WPF], customizing for existing controls"
  - "skinning controls [WPF]"
  - "controls [WPF], appearance specified by state"
  - "templates [WPF], custom for existing controls"
---

# Create a template for a control

With Windows Presentation Foundation (WPF), you can customize an existing control's visual structure and behavior with your own reusable template. Templates can be applied globally to your application, windows and pages, or directly to controls. Most scenarios that require you to create a new control can be covered by instead creating a new template for an existing control.

[!INCLUDE [desktop guide under construction](../../../includes/desktop-guide-preview-note.md)]

In this article, you'll explore creating a new <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Button> control.

## When to create a ControlTemplate

Controls have many properties, such as <xref:System.Windows.Controls.Border.Background%2A>, <xref:System.Windows.Controls.Control.Foreground%2A>, and <xref:System.Windows.Controls.Control.FontFamily%2A>. These properties control different aspects of the control's appearance, but the changes that you can make by setting these properties are limited. For example, you can set the <xref:System.Windows.Controls.Control.Foreground%2A> property to blue and <xref:System.Windows.Controls.Control.FontStyle%2A> to italic on a <xref:System.Windows.Controls.CheckBox>. When you want to customize the control's appearance beyond what setting the other properties on the control can do, you create a <xref:System.Windows.Controls.ControlTemplate>.

In most user interfaces, a button has the same general appearance: a rectangle with some text. If you wanted to create a rounded button, you could create a new control that inherits from the button or recreates the functionality of the button. In addition, the new user control would provide the circular visual.

You can avoid creating new controls by customizing the visual layout of an existing control. With a rounded button, you create a <xref:System.Windows.Controls.ControlTemplate> with the desired visual layout.

On the other hand, if you need a control with new functionality, different properties, and new settings, you would create a new <xref:System.Windows.Controls.UserControl>.

## Prerequisites

Create a new WPF application and in *MainWindow.xaml* (or another window of your choice) set the following properties on the **\<Window>** element:

|     |     |
| --- | --- |
| **Title**         | `Template Intro Sample` |
| **SizeToContent** | `WidthAndHeight` |
| **MinWidth**      | `250` |

Set the content of the **\<Window>** element to the following XAML:

[!code-xaml[Initial](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window1.xaml#Initial)]

In the end, the *MainWindow.xaml* file should look similar to the following:

[!code-xaml[InitialWhole](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window1.xaml#InitialWhole)]

If you run the application, it looks like the following:

![WPF window with two unstyled buttons](media/create-apply-template/unstyled-button.png)

## Create a ControlTemplate

The most common way to declare a <xref:System.Windows.Controls.ControlTemplate> is as a resource in the `Resources` section in a XAML file. Because templates are resources, they obey the same scoping rules that apply to all resources. Put simply, where you declare a template affects where the template can be applied. For example, if you declare the template in the root element of your application definition XAML file, the template can be used anywhere in your application. If you define the template in a window, only the controls in that window can use the template.

To start with, add a `Window.Resources` element to your *MainWindow.xaml* file:

[!code-xaml[WindowResStart](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window2.xaml#WindowResStart)]

Create a new **\<ControlTemplate>** with the following properties set:

|     |     |
| --- | --- |
| **x:Key**         | `roundbutton` |
| **TargetType**    | `Button` |

This control template will be simple:

- a root element for the control, a <xref:System.Windows.Controls.Grid>
- an <xref:System.Windows.Shapes.Ellipse> to draw the rounded appearance of the button
- a <xref:System.Windows.Controls.ContentPresenter> to display the user-specified button content

[!code-xaml[ControlTemplate](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window3.xaml#ControlTemplate)]

### TemplateBinding

When you create a new <xref:System.Windows.Controls.ControlTemplate>, you still might want to use the public properties to change the control's appearance. The [TemplateBinding](../../framework/wpf/advanced/templatebinding-markup-extension.md) markup extension binds a property of an element that is in the <xref:System.Windows.Controls.ControlTemplate> to a public property that is defined by the control. When you use a [TemplateBinding](../../framework/wpf/advanced/templatebinding-markup-extension.md), you enable properties on the control to act as parameters to the template. That is, when a property on a control is set, that value is passed on to the element that has the [TemplateBinding](../../framework/wpf/advanced/templatebinding-markup-extension.md) on it.

### Ellipse

Notice that the **:::no-loc text="Fill":::** and **:::no-loc text="Stroke":::** properties of the **\<Ellipse>** element are bound to the control's <xref:System.Windows.Controls.Control.Foreground> and <xref:System.Windows.Controls.Control.Background> properties.

### ContentPresenter

A [\<ContentPresenter>](xref:System.Windows.Controls.ContentPresenter) element is also added to the template. Because this template is designed for a button, take into consideration that the button inherits from <xref:System.Windows.Controls.ContentControl>. The button presents the content of the element. You can set anything inside of the button, such as plain text or even another control. Both of the following are valid buttons:

```xaml
<Button>My Text</Button>

<!-- and -->

<Button>
    <CheckBox>Checkbox in a button</CheckBox>
</Button>
```

In both of the previous examples, the text and the checkbox are set as the [Button.Content](xref:System.Windows.Controls.ContentControl.Content) property. Whatever is set as the content can be presented through a **\<ContentPresenter>**, which is what the template does.

If the <xref:System.Windows.Controls.ControlTemplate> is applied to a <xref:System.Windows.Controls.ContentControl> type, such as a `Button`, a <xref:System.Windows.Controls.ContentPresenter> is searched for in the element tree. If the `ContentPresenter` is found, the template automatically binds the control's <xref:System.Windows.Controls.ContentControl.Content> property to the `ContentPresenter`.

## Use the template

Find the buttons that were declared at the start of this article.

[!code-xaml[Initial](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window1.xaml#Initial)]

Set the second button's <xref:System.Windows.Controls.Control.Template> property to the `roundbutton` resource:

[!code-xaml[StyledButton](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window3.xaml#StyledButton)]

If you run the project and look at the result, you'll see that the button has a rounded background.

![WPF window with one template oval button](media/create-apply-template/styled-button.png)

You may have noticed that the button isn't a circle but is skewed. Because of the way the **\<Ellipse>** element works, it always expands to fill the available space. Make the circle uniform by changing the button's  **:::no-loc text="width":::** and **:::no-loc text="height":::** properties to the same value:

[!code-xaml[StyledButtonSize](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window3.xaml#StyledButtonSize)]

![WPF window with one template circular button](media/create-apply-template/styled-uniform-button.png)

## Add a Trigger

Even though a button with a template applied looks different, it behaves the same as any other button. If you press the button, the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event fires. However, you may have noticed that when you move your mouse over the button, the button's visuals don't change. These visual interactions are all defined by the template.

With the dynamic event and property systems that WPF provides, you can watch a specific property for a value and then restyle the template when appropriate. In this example, you'll watch the button's <xref:System.Windows.UIElement.IsMouseOver> property. When the mouse is over the control, style the **\<Ellipse>** with a new color. This type of trigger is known as a *PropertyTrigger*.

For this to work, you'll need to add a name to the **\<Ellipse>** that you can reference. Give it the name of **backgroundElement**.

[!code-xaml[EllipseName](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window4.xaml#EllipseName)]

Next, add a new <xref:System.Windows.Trigger> to the [ControlTemplate.Triggers](xref:System.Windows.Controls.ControlTemplate.Triggers) collection. The trigger will watch the `IsMouseOver` event for the value `true`.

[!code-xaml[ControlTemplate](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window4.xaml?name=ControlTemplate&highlight=6-10)]

Next, add a **\<Setter>** to the **\<Trigger>** that changes the **Fill** property of the **\<Ellipse>** to a new color.

[!code-xaml[MouseOver](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window5.xaml#MouseOver)]

Run the project. Notice that when you move the mouse over the button, the color of the **\<Ellipse>** changes.

![mouse moves over WPF button to change the fill color](media/create-apply-template/mouse-move-over-button.gif)

## Use a VisualState

Visual states are defined and triggered by a control. For example, when the mouse is moved on top of the control, the `CommonStates.MouseOver` state is triggered. You can animate property changes based on the current state of the control. In the previous section, a **\<PropertyTrigger>** was used to change the foreground of the button to `AliceBlue` when the `IsMouseOver` property was `true`. Instead, create a visual state that animates the change of this color, providing a smooth transition. For more information about *VisualStates*, see [Styles and templates in WPF](../fundamentals/styles-templates-overview.md#visual-states).

To convert the **\<PropertyTrigger>** to an animated visual state, First, remove the **\<ControlTemplate.Triggers>** element from your template.

[!code-xaml[CleanTemplate](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window5.xaml#CleanTemplate)]

Next, in the **\<Grid>** root of the control template, add the **\<VisualStateManager.VisualStateGroups>** element with a **\<VisualStateGroup>** for `CommonStates`. Define two states, `Normal` and `MouseOver`.

[!code-xaml[VisualState](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window6.xaml#VisualState)]

Any animations defined in a **\<VisualState>** are applied when that state is triggered. Create animations for each state. Animations are put inside of a **\<Storyboard>** element. For more information about storyboards, see [Storyboards Overview](../../framework/wpf/graphics-multimedia/storyboards-overview.md).

- Normal

  This state animates the ellipse fill, restoring it to the control's `Background` color.

  [!code-xaml[NormalState](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window6.xaml#NormalState)]

- MouseOver

  This state animates the ellipse `Background` color to a new color: `Yellow`.

  [!code-xaml[MouseOverState](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window6.xaml#MouseOverState)]

The **\<ControlTemplate>** should now look like the following.

[!code-xaml[FinalTemplate](~/samples/snippets/desktop-guide/wpf/styles-templates-create-apply-template/csharp/Window7.xaml#FinalTemplate)]

Run the project. Notice that when you move the mouse over the button, the color of the **\<Ellipse>** animates.

![mouse moves over WPF button to change the fill color](media/create-apply-template/mouse-move-over-button-visualstate.gif)

## Next steps

- [Create a style for a control in WPF](../fundamentals/styles-templates-create-apply-style.md)
- [Styles and templates in WPF](../fundamentals/styles-templates-overview.md)
- [Overview of XAML Resources](../fundamentals/xaml-resources-define.md)
