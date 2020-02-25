---
title: Create a style for a control
description: Learn how to create and reference a control style in Windows Presentation Foundation and .NET Core.
author: thraka
ms.author: adegeo
ms.date: 09/12/2019
dev_langs:
  - "csharp"
  - "vb"
#no-loc: [TextBlock, Setter]
---

# Create a style for a control in WPF

With Windows Presentation Foundation (WPF), you can customize an existing control's appearance with your own reusable style. Styles can be applied globally to your app, windows and pages, or directly to controls.

[!INCLUDE [desktop guide under construction](../../../includes/desktop-guide-preview-note.md)]

## Create a style

You can think of a <xref:System.Windows.Style> as a convenient way to apply a set of property values to one or more elements. You can use a style on any element that derives from <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> such as a <xref:System.Windows.Window> or a <xref:System.Windows.Controls.Button>.

The most common way to declare a style is as a resource in the `Resources` section in a XAML file. Because styles are resources, they obey the same scoping rules that apply to all resources. Put simply, where you declare a style affects where the style can be applied. For example, if you declare the style in the root element of your app definition XAML file, the style can be used anywhere in your app.

[!code-xaml[AppResources](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/App.xaml#AppResources)]

If you declare the style in one of the app's XAML files, the style can be used only in that XAML file. For more information about scoping rules for resources, see [XAML Resources](xaml-resources-define.md).

[!code-xaml[AppResources](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/WindowSingleResource.xaml#WindowResources)]

A style is made up of `<Setter>` child elements that set properties on the elements the style is applied to. In the example above, notice that the style is set to apply to `TextBlock` types through the `TargetType` attribute. The style will set the <xref:System.Windows.Controls.Control.FontSize%2A> to `15` and the <xref:System.Windows.Controls.Control.FontWeight%2A> to `ExtraBold`. Add a `<Setter>` for each property the style changes.

## Apply a style implicitly

A <xref:System.Windows.Style> is a convenient way to apply a set of property values to more than one element. For example, consider the following <xref:System.Windows.Controls.TextBlock> elements and their default appearance in a window.

[!code-xaml[TextBlocks](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window1.xaml#SnippetTextBlocks)]

![Styling sample screenshot](./media/styles-and-templates-overview/stylingintro-textblocksbefore.png "StylingIntro_TextBlocksBefore")

You can change the default appearance by setting properties, such as <xref:System.Windows.Controls.Control.FontSize%2A> and <xref:System.Windows.Controls.Control.FontFamily%2A>, on each <xref:System.Windows.Controls.TextBlock> element directly. However, if you want your <xref:System.Windows.Controls.TextBlock> elements to share some properties, you can create a <xref:System.Windows.Style> in the `Resources` section of your XAML file, as shown here.

[!code-xaml[DefaultTextBlockStyle](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window1.xaml#SnippetDefaultTextBlockStyle)]

When you set the <xref:System.Windows.Style.TargetType%2A> of your style to the <xref:System.Windows.Controls.TextBlock> type and omit the `x:Key` attribute, the style is applied to all the <xref:System.Windows.Controls.TextBlock> elements scoped to the style, which is generally the XAML file itself.

Now the <xref:System.Windows.Controls.TextBlock> elements appear as follows.

![Styling sample screenshot](./media/styles-and-templates-overview/stylingintro-textblocksbasestyle.png "StylingIntro_TextBlocksBaseStyle")

## Apply a style explicitly

If you add an `x:Key` attribute with value to the style, the style is no longer implicitly applied to all elements of <xref:System.Windows.Style.TargetType%2A>. Only elements that explicitly reference the style will have the style applied to them.

Here is the style from the previous section, but declared with the `x:Key` attribute.

[!code-xaml[ExplicitStyleDeclare](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/WindowExplicitStyle.xaml#ExplicitStyleDeclare)]

To apply the style, set the <xref:System.Windows.FrameworkElement.Style%2A> property on the element to the `x:Key` value, using a [StaticResource markup extension](../../framework/wpf/advanced/staticresource-markup-extension.md), as shown here.

[!code-xaml[ExplicitStyleReference](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/WindowExplicitStyle.xaml#ExplicitStyleReference)]

Notice that the first <xref:System.Windows.Controls.TextBlock> element has the style applied to it while the second TextBlock element remains unchanged. The implicit style from the previous section was changed to a style that declared the `x:Key` attribute, meaning, the only element affected by the style is the one that referenced the style directly.

![Styling sample screenshot](./media/styles-and-templates-overview/create-a-style-explicit-textblock.png "create-a-style-explicit-textblock")

Once a style is applied, explicitly or implicitly, it becomes sealed and can't be changed. If you want to change a style that has been applied, create a new style to replace the existing one. For more information, see the <xref:System.Windows.Style.IsSealed%2A> property.

You can create an object that chooses a style to apply based on custom logic. For an example, see the example provided for the <xref:System.Windows.Controls.StyleSelector> class.

## Apply a style programmatically

To assign a named style to an element programmatically, get the style from the resources collection and assign it to the element's <xref:System.Windows.FrameworkElement.Style%2A> property. The items in a resources collection are of type <xref:System.Object>. Therefore, you must cast the retrieved style to a <xref:System.Windows.Style?displayProperty=fullName> before assigning it to the `Style` property. For example, the following code sets the style of a `TextBlock` named `textblock1` to the defined style `TitleText`.

[!code-csharp[SetStyleCode](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window2.xaml.cs#SnippetSetStyleCode)]
[!code-vb[SetStyleCode](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/vb/MainWindow.xaml.vb#SnippetSetStyleCode)]

## Extend a style

Perhaps you want your two <xref:System.Windows.Controls.TextBlock> elements to share some property values, such as the <xref:System.Windows.Controls.Control.FontFamily%2A> and the centered <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A>. But you also want the text **My Pictures** to have some additional properties. You can do that by creating a new style that is based on the first style, as shown here.

[!code-xaml[DefaultTextBlockStyleBasedOn](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window2.xaml#SnippetDefaultTextBlockStyleBasedOn)]

[!code-xaml[TextBlocksExplicit](~/samples/snippets/desktop-guide/wpf/styles-and-templates-intro/csharp/Window2.xaml#SnippetTextBlocksExplicit)]

This `TextBlock` style is now centered, uses a `Comic Sans MS` font with a size of `26`, and the foreground color set to the <xref:System.Windows.Media.LinearGradientBrush> shown in the example. Notice that it overrides the <xref:System.Windows.Controls.Control.FontSize%2A> value of the base style. If there's more than one <xref:System.Windows.Setter> pointing to the same property in a <xref:System.Windows.Style>, the `Setter` that is declared last takes precedence.

The following shows what the <xref:System.Windows.Controls.TextBlock> elements now look like:

![Styled TextBlocks](./media/styles-and-templates-overview/stylingintro-textblocks.png "StylingIntro_TextBlocks")

This `TitleText` style extends the style that has been created for the <xref:System.Windows.Controls.TextBlock> type, referenced with `BasedOn="{StaticResource {x:Type TextBlock}}"`. You can also extend a style that has an `x:Key` by using the `x:Key` of the style. For example, if there was a style named `Header1` and you wanted to extend that style, you would use `BasedOn="{StaticResource Header1}"`.

## Relationship of the TargetType property and the x:Key attribute

As previously shown, setting the <xref:System.Windows.Style.TargetType%2A> property to `TextBlock` without assigning the style an `x:Key` causes the style to be applied to all <xref:System.Windows.Controls.TextBlock> elements. In this case, the `x:Key` is implicitly set to `{x:Type TextBlock}`. This means that if you explicitly set the `x:Key` value to anything other than `{x:Type TextBlock}`, the <xref:System.Windows.Style> isn't applied to all `TextBlock` elements automatically. Instead, you must apply the style (by using the `x:Key` value) to the `TextBlock` elements explicitly. If your style is in the resources section and you don't set the `TargetType` property on your style, then you must set the `x:Key` attribute.

In addition to providing a default value for the `x:Key`, the `TargetType` property specifies the type to which setter properties apply. If you don't specify a `TargetType`, you must qualify the properties in your <xref:System.Windows.Setter> objects with a class name by using the syntax `Property="ClassName.Property"`. For example, instead of setting `Property="FontSize"`, you must set <xref:System.Windows.Setter.Property%2A> to `"TextBlock.FontSize"` or `"Control.FontSize"`.

Also note that many WPF controls consist of a combination of other WPF controls. If you create a style that applies to all controls of a type, you might get unexpected results. For example, if you create a style that targets the <xref:System.Windows.Controls.TextBlock> type in a <xref:System.Windows.Window>, the style is applied to all `TextBlock` controls in the window, even if the `TextBlock` is part of another control, such as a <xref:System.Windows.Controls.ListBox>.

## See also

<!-- - [Create a style for a control](styles-templates-create-apply-template.md) -->
- [Overview of XAML Resources](xaml-resources-define.md)
- [XAML overview (WPF & .NET Core)](xaml.md)
