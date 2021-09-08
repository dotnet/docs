---
description: "Learn more about: Custom Composite Designers - Workflow Item Presenter"
title: "Custom Composite Designers - Workflow Item Presenter"
ms.date: "03/30/2017"
ms.assetid: f85224cf-9e30-44a5-9a81-3bc438a34364
---
# Custom Composite Designers - Workflow Item Presenter

The <xref:System.Activities.Presentation.WorkflowItemPresenter> is a key type in the WF designer programming model that allows for the creation of a "drop zone" where an arbitrary activity can be placed. This sample shows how to build an activity designer that surfaces such a "drop zone."

The [WorkflowItemPresenter sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/CustomActivities/CustomActivityDesigners/WorkflowItemPresenter/cs) demonstrates:

- Creating a custom activity designer with a <xref:System.Activities.Presentation.WorkflowItemPresenter>.

- Registering the custom designer using the metadata store.

- Programming the rehosted toolbox declaratively and imperatively.

## Sample Details

The code for this sample shows:

- The custom activity designer is built for the `SimpleNativeActivity` class.

- The creation of a custom activity designer with a <xref:System.Activities.Presentation.WorkflowItemPresenter>.

```xaml
<sap:ActivityDesigner x:Class="Microsoft.Samples.UsingWorkflowItemPresenter.SimpleNativeDesigner"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:sap="clr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation"
    xmlns:sapv="clr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation">
    <sap:ActivityDesigner.Resources>
        <DataTemplate x:Key="Collapsed">
            <StackPanel>
                <TextBlock>This is the collapsed view</TextBlock>
            </StackPanel>
        </DataTemplate>
        <DataTemplate x:Key="Expanded">
            <StackPanel>
                <TextBlock>Custom Text</TextBlock>
                <sap:WorkflowItemPresenter Item="{Binding Path=ModelItem.Body, Mode=TwoWay}"
                                        HintText="Please drop an activity here" />
            </StackPanel>
        </DataTemplate>
        <Style x:Key="ExpandOrCollapsedStyle" TargetType="{x:Type ContentPresenter}">
            <Setter Property="ContentTemplate" Value="{DynamicResource Collapsed}"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding Path=ShowExpanded}" Value="true">
                    <Setter Property="ContentTemplate" Value="{DynamicResource Expanded}"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </sap:ActivityDesigner.Resources>
    <Grid>
        <ContentPresenter Style="{DynamicResource ExpandOrCollapsedStyle}" Content="{Binding}" />
    </Grid>
</sap:ActivityDesigner>
```

 Note the use of WPF data binding to bind to `ModelItem.Body`. `ModelItem` is the property on <xref:System.Activities.Presentation.ActivityDesigner> that refers to the underlying object the designer is being used for, in this case, **SimpleNativeActivity**.

## Set up, build, and run the sample

1. Open the solution in Visual Studio.

2. Press **F5** to compile and run the application.

## See also

- <xref:System.Activities.Presentation.WorkflowItemPresenter>
- [Developing Applications with the Workflow Designer](/visualstudio/workflow-designer/developing-applications-with-the-workflow-designer)
