---
title: Styles and templates
description: Learn about XAML resources in Windows Presentation Foundation (WPF) for .NET Core. Understand the types of XAML resources related to styles and themes.
author: thraka
ms.author: adegeo
ms.date: 09/09/2019
dev_langs: 
  - "csharp"
  - "vb"
---

# Styles and templates in WPF

Windows Presentation Foundation (WPF) styling and templating refer to a suite of features that let developers and designers create visually compelling effects and a consistent appearance for their product. When customizing the appearance of an app, you want a strong styling and templating model that enables maintenance and sharing of appearance within and among apps. WPF provides that model.

Another feature of the WPF styling model is the separation of presentation and logic. Designers can work on the appearance of an app by using only XAML at the same time that developers work on the programming logic by using C# or Visual Basic.

This overview focuses on the styling and templating aspects of the app and doesn't discuss any data-binding concepts. For information about data binding, see [Data Binding Overview](../data/data-binding-overview.md).

It's important to understand resources, which are what enable styles and templates to be reused. For more information about resources, see [XAML Resources](xaml-resources-define.md).

[!INCLUDE [desktop guide under construction](../../../includes/desktop-guide-preview-note.md)]

## Sample

The sample code provided in this overview is based on a [simple photo browsing application](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating) shown in the following illustration.

![Styled ListView](./media/styles-and-templates-overview/stylingintro-triggers.png "StylingIntro_triggers")

This simple photo sample uses styling and templating to create a visually compelling user experience. The sample has two <xref:System.Windows.Controls.TextBlock> elements and a <xref:System.Windows.Controls.ListBox> control that is bound to a list of images.

For the complete sample, see [Introduction to Styling and Templating Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).

## Styles

You can think of a <xref:System.Windows.Style> as a convenient way to apply a set of property values to multiple elements. You can use a style on any element that derives from <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> such as a <xref:System.Windows.Window> or a <xref:System.Windows.Controls.Button>.

The most common way to declare a style is as a resource in the `Resources` section in a XAML file. Because styles are resources, they obey the same scoping rules that apply to all resources. Put simply, where you declare a style affects where the style can be applied. For example, if you declare the style in the root element of your app definition XAML file, the style can be used anywhere in your app.

For example, the following XAML code declares two styles for a `TextBlock`, one automatically applied to all `TextBlock` elements, and another that must be explicitly referenced.

[!code-xaml[SnippetDefaultTextBlockStyleBasedOn](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window2.xaml#SnippetDefaultTextBlockStyleBasedOn)]

Here is an example of the styles declared above being used.

[!code-xaml[SnippetTextBlocksExplicit](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window2.xaml#SnippetTextBlocksExplicit)]

![Styled textblocks](./media/styles-and-templates-overview/stylingintro-textblocks.png)

For more information, see [Create a style for a control](styles-templates-create-apply-style.md).

## ControlTemplates

In WPF, the <xref:System.Windows.Controls.ControlTemplate> of a control defines the appearance of the control. You can change the structure and appearance of a control by defining a new <xref:System.Windows.Controls.ControlTemplate> and assigning it to a control. In many cases, templates give you enough flexibility so that you do not have to write your own custom controls.

Each control has a default template assigned to the [Control.Template](xref:System.Windows.Controls.Control.Template) property. The template connects the visual presentation of the control with the control's capabilities. Because you define a template in XAML, you can change the control's appearance without writing any code. Each template is designed for a specific control, such as a <xref:System.Windows.Controls.Button>.

Commonly you declare a template as a resource on the `Resources` section of a XAML file. As with all resources, scoping rules apply.

Control templates are a lot more involved than a style. This is because the control template rewrites the visual appearance of the entire control, while a style simply applies property changes to the existing control. However, since the template of a control is applied by setting the [Control.Template](xref:System.Windows.Controls.Control.Template) property, you can use a style to define or set a template.

Designers generally allow you to create a copy of an existing template and modify it. For example, in the Visual Studio WPF designer, select a `CheckBox` control, and then right-click and select **Edit template** > **Create a copy**. This command generates a *style that defines a template*.

```xaml
<Style x:Key="CheckBoxStyle1" TargetType="{x:Type CheckBox}">
    <Setter Property="FocusVisualStyle" Value="{StaticResource FocusVisual1}"/>
    <Setter Property="Background" Value="{StaticResource OptionMark.Static.Background1}"/>
    <Setter Property="BorderBrush" Value="{StaticResource OptionMark.Static.Border1}"/>
    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
    <Setter Property="BorderThickness" Value="1"/>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type CheckBox}">
                <Grid x:Name="templateRoot" Background="Transparent" SnapsToDevicePixels="True">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Border x:Name="checkBoxBorder" Background="{TemplateBinding Background}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="1" VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                        <Grid x:Name="markGrid">
                            <Path x:Name="optionMark" Data="F1 M 9.97498,1.22334L 4.6983,9.09834L 4.52164,9.09834L 0,5.19331L 1.27664,3.52165L 4.255,6.08833L 8.33331,1.52588e-005L 9.97498,1.22334 Z " Fill="{StaticResource OptionMark.Static.Glyph1}" Margin="1" Opacity="0" Stretch="None"/>
                            <Rectangle x:Name="indeterminateMark" Fill="{StaticResource OptionMark.Static.Glyph1}" Margin="2" Opacity="0"/>
                        </Grid>
                    </Border>
                    <ContentPresenter x:Name="contentPresenter" Grid.Column="1" Focusable="False" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                </Grid>
                <ControlTemplate.Triggers>
                    <Trigger Property="HasContent" Value="true">
                        <Setter Property="FocusVisualStyle" Value="{StaticResource OptionMarkFocusVisual1}"/>
                        <Setter Property="Padding" Value="4,-1,0,0"/>

... content removed to save space ...
```

Editing a copy of a template is a great way to learn how templates work. Instead of creating a new blank template, it's easier to edit a copy and change a few aspects of the visual presentation.

For an example, see [Create a template for a control](../themes/how-to-create-apply-template.md).

### TemplateBinding

You may have noticed that the template resource defined in the previous section uses the [TemplateBinding Markup Extension](../../framework/wpf/advanced/templatebinding-markup-extension.md). A `TemplateBinding` is an optimized form of a binding for template scenarios, analogous to a binding constructed with `{Binding RelativeSource={RelativeSource TemplatedParent}}`. `TemplateBinding` is useful for binding parts of the template to properties of the control. For example, each control has a <xref:System.Windows.Controls.Control.BorderThickness> property. Use a `TemplateBinding` to manage which element in the template is affected by this control setting.

### ContentControl and ItemsControl

If a <xref:System.Windows.Controls.ContentPresenter> is declared in the <xref:System.Windows.Controls.ControlTemplate> of a <xref:System.Windows.Controls.ContentControl>, the <xref:System.Windows.Controls.ContentPresenter> will automatically bind to the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> and <xref:System.Windows.Controls.ContentControl.Content%2A> properties. Likewise, an <xref:System.Windows.Controls.ItemsPresenter> that is in the <xref:System.Windows.Controls.ControlTemplate> of an <xref:System.Windows.Controls.ItemsControl> will automatically bind to the <xref:System.Windows.Controls.ItemsControl.Items%2A> and <xref:System.Windows.Controls.ItemsPresenter> properties.

## DataTemplates

In this sample app, there is a <xref:System.Windows.Controls.ListBox> control that is bound to a list of photos.

[!code-xaml[ListBox](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window3.xaml#SnippetListBox)]

This <xref:System.Windows.Controls.ListBox> currently looks like the following.

![ListBox before applying template](./media/styles-and-templates-overview/stylingintro-listboxbefore.png "StylingIntro_ListBoxBefore")

Most controls have some type of content, and that content often comes from data that you are binding to. In this sample, the data is the list of photos. In WPF, you use a <xref:System.Windows.DataTemplate> to define the visual representation of data. Basically, what you put into a <xref:System.Windows.DataTemplate> determines what the data looks like in the rendered app.

In our sample app, each custom `Photo` object has a `Source` property of type string that specifies the file path of the image. Currently, the photo objects appear as file paths.

[!code-csharp[PhotoClass](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Photo.cs#PhotoClass)]
[!code-vb[PhotoClass](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/vb/Photo.vb#PhotoClass)]

For the photos to appear as images, you create a <xref:System.Windows.DataTemplate> as a resource.

[!code-xaml[DataTemplate](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window4.xaml#SnippetDataTemplate)]

Notice that the <xref:System.Windows.DataTemplate.DataType%2A> property is similar to the <xref:System.Windows.Style.TargetType%2A> property of the <xref:System.Windows.Style>. If your <xref:System.Windows.DataTemplate> is in the resources section, when you specify the <xref:System.Windows.DataTemplate.DataType%2A> property to a type and omit an `x:Key`, the <xref:System.Windows.DataTemplate> is applied whenever that type appears. You always have the option to assign the <xref:System.Windows.DataTemplate> with an `x:Key` and then set it as a `StaticResource` for properties that take <xref:System.Windows.DataTemplate> types, such as the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> property or the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> property.

Essentially, the <xref:System.Windows.DataTemplate> in the above example defines that whenever there is a `Photo` object, it should appear as an <xref:System.Windows.Controls.Image> within a <xref:System.Windows.Controls.Border>. With this <xref:System.Windows.DataTemplate>, our app now looks like this.

![Photo image](./media/styles-and-templates-overview/stylingintro-photosasimages.png "StylingIntro_PhotosAsImages")

The data templating model provides other features. For example, if you are displaying collection data that contains other collections using a <xref:System.Windows.Controls.HeaderedItemsControl> type such as a <xref:System.Windows.Controls.Menu> or a <xref:System.Windows.Controls.TreeView>, there is the <xref:System.Windows.HierarchicalDataTemplate>. Another data templating feature is the <xref:System.Windows.Controls.DataTemplateSelector>, which allows you to choose a <xref:System.Windows.DataTemplate> to use based on custom logic. For more information, see [Data Templating Overview](../../framework/wpf/data/data-templating-overview.md), which provides a more in-depth discussion of the different data templating features.

## Triggers

A trigger sets properties or starts actions, such as an animation, when a property value changes or when an event is raised. <xref:System.Windows.Style>, <xref:System.Windows.Controls.ControlTemplate>, and <xref:System.Windows.DataTemplate> all have a `Triggers` property that can contain a set of triggers. There are several types of triggers.

### PropertyTriggers

A <xref:System.Windows.Trigger> that sets property values or starts actions based on the value of a property is called a property trigger.

To demonstrate how to use property triggers, you can make each <xref:System.Windows.Controls.ListBoxItem> partially transparent unless it is selected. The following style sets the <xref:System.Windows.UIElement.Opacity%2A> value of a <xref:System.Windows.Controls.ListBoxItem> to `0.5`. When the <xref:System.Windows.Controls.ListBoxItem.IsSelected%2A> property is `true`, however, the <xref:System.Windows.UIElement.Opacity%2A> is set to `1.0`.

[!code-xaml[PropertyTrigger](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window5.xaml#SnippetPropertyTrigger)]

This example uses a <xref:System.Windows.Trigger> to set a property value, but note that the <xref:System.Windows.Trigger> class also has the <xref:System.Windows.TriggerBase.EnterActions%2A> and <xref:System.Windows.TriggerBase.ExitActions%2A> properties that enable a trigger to perform actions.

Notice that the <xref:System.Windows.FrameworkElement.MaxHeight%2A> property of the <xref:System.Windows.Controls.ListBoxItem> is set to `75`. In the following illustration, the third item is the selected item.

![Styled ListView](./media/styles-and-templates-overview/stylingintro-triggers.png "StylingIntro_triggers")

### EventTriggers and Storyboards

Another type of trigger is the <xref:System.Windows.EventTrigger>, which starts a set of actions based on the occurrence of an event. For example, the following <xref:System.Windows.EventTrigger> objects specify that when the mouse pointer enters the <xref:System.Windows.Controls.ListBoxItem>, the <xref:System.Windows.FrameworkElement.MaxHeight%2A> property animates to a value of `90` over a `0.2` second period. When the mouse moves away from the item, the property returns to the original value over a period of `1` second. Note how it is not necessary to specify a <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> value for the <xref:System.Windows.ContentElement.MouseLeave> animation. This is because the animation is able to keep track of the original value.

[!code-xaml[StyleEventTriggers](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window6.xaml#SnippetStyleEventTriggers)]

For more information, see the [Storyboards overview](../../framework/wpf/graphics-multimedia/storyboards-overview.md).

In the following illustration, the mouse is pointing to the third item.

![Styling sample screenshot](./media/styles-and-templates-overview/stylingintro-eventtriggers.png "StylingIntro_EventTriggers")

### MultiTriggers, DataTriggers, and MultiDataTriggers

In addition to <xref:System.Windows.Trigger> and <xref:System.Windows.EventTrigger>, there are other types of triggers. <xref:System.Windows.MultiTrigger> allows you to set property values based on multiple conditions. You use <xref:System.Windows.DataTrigger> and <xref:System.Windows.MultiDataTrigger> when the property of your condition is data-bound.

## Visual States

Controls are always in a specific **state**. For example, when the mouse moves over the surface of a control, the control is considered to be in a common state of `MouseOver`. A control without a specific state is considered to be in the common `Normal` state. States are broken into groups, and the previously mentioned states are part of the state group `CommonStates`. Most controls have two state groups: `CommonStates` and `FocusStates`. Of each state group applied to a control, a control is always in one state of each group, such as `CommonStates.MouseOver` and `FocusStates.Unfocused`. However, a control can't be in two different states within the same group, such as `CommonStates.Normal` and `CommonStates.Disabled`. Here is a table of states most controls recognize and use.

| VisualState Name | VisualStateGroup Name | Description |
| ---------------- | --------------------- | ----------- |
| Normal           | CommonStates          | The default state. |
| MouseOver        | CommonStates          | The mouse pointer is positioned over the control. |
| Pressed          | CommonStates          | The control is pressed. |
| Disabled         | CommonStates          | The control is disabled. |
| Focused          | FocusStates           | The control has focus. |
| Unfocused        | FocusStates           | The control does not have focus. |

By defining a <xref:System.Windows.VisualStateManager?displayProperty=fullName> on the root element of a control template, you can trigger animations when a control enters a specific state. The `VisualStateManager` declares which combinations of <xref:System.Windows.VisualStateGroup> and <xref:System.Windows.VisualState> to watch. When the control enters a watched state, the animation defined by the `VisaulStateManager` is started.

For example, the following XAML code watches the `CommonStates.MouseOver` state to animate the fill color of the element named `backgroundElement`. When the control returns to the `CommonStates.Normal` state, the fill color of the element named `backgroundElement` is restored.

```xaml
<ControlTemplate x:Key="roundbutton" TargetType="Button">
    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup Name="CommonStates">
                <VisualState Name="Normal">
                    <ColorAnimation Storyboard.TargetName="backgroundElement" 
                                    Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)"
                                    To="{TemplateBinding Background}"
                                    Duration="0:0:0.3"/>
                </VisualState>
                <VisualState Name="MouseOver">
                    <ColorAnimation Storyboard.TargetName="backgroundElement" 
                                    Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)" 
                                    To="Yellow" 
                                    Duration="0:0:0.3"/>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        ...
```

For more information about storyboards, see [Storyboards Overview](../../framework/wpf/graphics-multimedia/storyboards-overview.md).

## Shared resources and themes

A typical WPF app might have multiple UI resources that are applied throughout the app. Collectively, this set of resources can be considered the theme for the app. WPF provides support for packaging UI resources as a theme by using a resource dictionary that is encapsulated as the <xref:System.Windows.ResourceDictionary> class.

WPF themes are defined by using the styling and templating mechanism that WPF exposes for customizing the visuals of any element.

WPF theme resources are stored in embedded resource dictionaries. These resource dictionaries must be embedded within a signed assembly, and can either be embedded in the same assembly as the code itself or in a side-by-side assembly. For PresentationFramework.dll, the assembly that contains WPF controls, theme resources are in a series of side-by-side assemblies.

The theme becomes the last place to look when searching for the style of an element. Typically, the search will begin by walking up the element tree searching for an appropriate resource, then look in the app resource collection and finally query the system. This gives app developers a chance to redefine the style for any object at the tree or app level before reaching the theme.

You can define resource dictionaries as individual files that enable you to reuse a theme across multiple apps. You can also create swappable themes by defining multiple resource dictionaries that provide the same types of resources but with different values. Redefining these styles or other resources at the app level is the recommended approach for skinning an app.

To share a set of resources, including styles and templates, across apps, you can create a XAML file and define a <xref:System.Windows.ResourceDictionary> that includes reference to a `shared.xaml` file.

```xaml
<ResourceDictionary.MergedDictionaries>
  <ResourceDictionary Source="Shared.xaml" />
</ResourceDictionary.MergedDictionaries>
```

It is the sharing of `shared.xaml`, which itself defines a <xref:System.Windows.ResourceDictionary> that contains a set of style and brush resources, that enables the controls in an app to have a consistent look.

For more information, see [Merged resource dictionaries](../../framework/wpf/advanced/merged-resource-dictionaries.md).

If you are creating a theme for your custom control, see the External control library section of the [Control authoring overview](../../framework/wpf/controls/control-authoring-overview.md).

## See also

- [Pack URIs in WPF](../../framework/wpf/app-development/pack-uris-in-wpf.md)
- [How to: Find ControlTemplate-Generated Elements](../../framework/wpf/controls/how-to-find-controltemplate-generated-elements.md)
- [Find DataTemplate-Generated Elements](../../framework/wpf/data/how-to-find-datatemplate-generated-elements.md)
