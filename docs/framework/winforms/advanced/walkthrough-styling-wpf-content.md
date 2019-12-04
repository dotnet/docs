---
title: "Walkthrough: Styling WPF Content"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "WPF Designer [Windows Forms], styling WPF content"
  - "interoperability [WDF]"
  - "styles [Windows Forms], WPF content"
ms.assetid: e574aac7-7ea4-4cdb-8034-bab541f000df
author: jillre
ms.author: jillfra
manager: jillfra
---
# Walkthrough: Style WPF content

This article show you how to apply styling to a Windows Presentation Foundation (WPF) control hosted on a Windows Form.

## Prerequisites

You need Visual Studio to complete this walkthrough.

## Create the project

Open Visual Studio and create a new Windows Forms Application project in Visual Basic or Visual C# named `StylingWpfContent`.

> [!NOTE]
> When hosting WPF content, only C# and Visual Basic projects are supported.

## Create the WPF control types

After you add a WPF control type to the project, you can host it in an <xref:System.Windows.Forms.Integration.ElementHost> control.

1. Add a new WPF <xref:System.Windows.Controls.UserControl> project to the solution. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).

2. In Design view, make sure that `UserControl1` is selected.

3. In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties to **200**.

4. Add a <xref:System.Windows.Controls.Button?displayProperty=nameWithType> control to the <xref:System.Windows.Controls.UserControl> and set the value of the <xref:System.Windows.Controls.ContentControl.Content%2A> property to **Cancel**.

5. Add a second <xref:System.Windows.Controls.Button?displayProperty=nameWithType> control to the <xref:System.Windows.Controls.UserControl> and set the value of the <xref:System.Windows.Controls.ContentControl.Content%2A> property to **OK**.

6. Build the project.

## Apply a Style to a WPF Control

You can apply different styling to a WPF control to change its appearance and behavior.

1. Open `Form1` in the Windows Forms Designer.

1. In the **Toolbox**, double-click `UserControl1` to create an instance of `UserControl1` on the form.

   An instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.

1. In the smart tag panel for `elementHost1`, click **Edit Hosted Content** from the drop-down list.

   `UserControl1` opens in the WPF Designer.

1. In XAML view, insert the following XAML after the `<UserControl>` opening tag. This XAML creates a gradient with a contrasting gradient border. When the control is clicked, the gradients are changed to generate a pressed button look. For more information, see [Styling and Templating](../../../desktop-wpf/fundamentals/styles-templates-overview.md).

   ```xaml
   <UserControl.Resources>
    <LinearGradientBrush x:Key="NormalBrush" EndPoint="0,1" StartPoint="0,0">
        <GradientStop Color="#FFF" Offset="0.0"/>
        <GradientStop Color="#CCC" Offset="1.0"/>
    </LinearGradientBrush>
    <LinearGradientBrush x:Key="PressedBrush" EndPoint="0,1" StartPoint="0,0">
        <GradientStop Color="#BBB" Offset="0.0"/>
        <GradientStop Color="#EEE" Offset="0.1"/>
        <GradientStop Color="#EEE" Offset="0.9"/>
        <GradientStop Color="#FFF" Offset="1.0"/>
    </LinearGradientBrush>
    <LinearGradientBrush x:Key="NormalBorderBrush" EndPoint="0,1" StartPoint="0,0">
        <GradientStop Color="#CCC" Offset="0.0"/>
        <GradientStop Color="#444" Offset="1.0"/>
    </LinearGradientBrush>
    <LinearGradientBrush x:Key="BorderBrush" EndPoint="0,1" StartPoint="0,0">
        <GradientStop Color="#CCC" Offset="0.0"/>
        <GradientStop Color="#444" Offset="1.0"/>
    </LinearGradientBrush>
    <LinearGradientBrush x:Key="PressedBorderBrush" EndPoint="0,1" StartPoint="0,0">
        <GradientStop Color="#444" Offset="0.0"/>
        <GradientStop Color="#888" Offset="1.0"/>
    </LinearGradientBrush>

    <Style x:Key="SimpleButton" TargetType="{x:Type Button}" BasedOn="{x:Null}">
        <Setter Property="Background" Value="{StaticResource NormalBrush}"/>
        <Setter Property="BorderBrush" Value="{StaticResource NormalBorderBrush}"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid x:Name="Grid">
                        <Border x:Name="Border" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}"/>
                        <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}" RecognizesAccessKey="True"/>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsPressed" Value="true">
                            <Setter Property="Background" Value="{StaticResource PressedBrush}" TargetName="Border"/>
                            <Setter Property="BorderBrush" Value="{StaticResource PressedBorderBrush}" TargetName="Border"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
   </UserControl.Resources>
   ```

1. Apply the `SimpleButton` style defined in the previous step to the Cancel button by inserting the following XAML in the `<Button>` tag of the **Cancel** button.

   ```xaml
   Style="{StaticResource SimpleButton}
   ```

   Your button declaration will resemble the following XAML:

   ```xaml
   <Button Height="23" Margin="41,52,98,0" Name="button1" VerticalAlignment="Top"
                Style="{StaticResource SimpleButton}">Cancel</Button>
   ```

1. Build the project.

1. Open `Form1` in the Windows Forms Designer.

1. The new style is applied to the button control.

1. From the **Debug** menu, select **Start Debugging** to run the application.

1. Click the **OK** and **Cancel** buttons and view the differences.

## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Migration and Interoperability](../../wpf/advanced/migration-and-interoperability.md)
- [Using WPF Controls](using-wpf-controls.md)
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
- [XAML Overview (WPF)](../../wpf/advanced/xaml-overview-wpf.md)
- [Styling and Templating](../../../desktop-wpf/fundamentals/styles-templates-overview.md)
