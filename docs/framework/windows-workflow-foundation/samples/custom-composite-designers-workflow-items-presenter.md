---
description: "Learn more about: Custom Composite Designers - Workflow Items Presenter"
title: "Custom Composite Designers - Workflow Items Presenter"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 70055c4b-1173-47a3-be80-b5bce6f59e9a
---
# Custom Composite Designers - Workflow Items Presenter

The <xref:System.Activities.Presentation.WorkflowItemsPresenter?displayProperty=nameWithType> is a key type in the WF designer programming model that allows for the editing of a collection of contained elements. This sample shows how to build an activity designer that surfaces such an editable collection.

The [WorkflowItemsPresenter sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/CustomActivities/CustomActivityDesigners/WorkflowItemsPresenter/cs) demonstrates:

- Creating a custom activity designer with a <xref:System.Activities.Presentation.WorkflowItemsPresenter?displayProperty=nameWithType>.

- Creating an activity designer with a "collapsed" and "expanded" view.

- Overriding a default designer in a rehosted application.

## Set up, build, and run the sample

1. Open the **UsingWorkflowItemsPresenter.sln** sample solution for C# or for Visual Basic in Visual Studio.

2. Build and run the solution.

   A rehosted workflow designer application opens, and you can drag activities onto the canvas.

## Sample highlights

The code for this sample shows the following:

- The activity a designer is built for:  `Parallel`

- The creation of a custom activity designer with a <xref:System.Activities.Presentation.WorkflowItemsPresenter?displayProperty=nameWithType>. A few things to point out:

  - Note the use of WPF data binding to bind to `ModelItem.Branches`. `ModelItem` is the property on `WorkflowElementDesigner` that refers to the underlying object the designer is being used for, in this case, our `Parallel`.

  - The <xref:System.Activities.Presentation.WorkflowItemsPresenter.SpacerTemplate?displayProperty=nameWithType> can be used to put a visual to display between the individual items in the collection.

  - <xref:System.Activities.Presentation.WorkflowItemsPresenter.ItemsPanel?displayProperty=nameWithType> is a template that can be provided to determine the layout of the items in the collection. In this case, a horizontal stack panel is used.

  This following example code shows this.

  ```xaml
  <sad:WorkflowItemsPresenter HintText="Drop Activities Here"
                                Items="{Binding Path=ModelItem.Branches}">
      <sad:WorkflowItemsPresenter.SpacerTemplate>
        <DataTemplate>
          <Ellipse Width="10" Height="10" Fill="Black"/>
        </DataTemplate>
      </sad:WorkflowItemsPresenter.SpacerTemplate>
      <sad:WorkflowItemsPresenter.ItemsPanel>
        <ItemsPanelTemplate>
          <StackPanel Orientation="Horizontal"/>
        </ItemsPanelTemplate>
      </sad:WorkflowItemsPresenter.ItemsPanel>
    </sad:WorkflowItemsPresenter>
  ```

- Perform an association of the `DesignerAttribute` to the `Parallel` type and then output the attributes reported.

  - First, register all of the default designers.

    The following is the code example.

    ```csharp
    // register metadata
    (new DesignerMetadata()).Register();
    RegisterCustomMetadata();
    ```

    ```vb
    ' register metadata
    Dim metadata = New DesignerMetadata()
    metadata.Register()
    ' register custom metadata
    RegisterCustomMetadata()
    ```

  - Then, override the parallel in `RegisterCustomMetadata` method.

    The following code shows this in C# and Visual Basic.

    ```csharp
    void RegisterCustomMetadata()
    {
          AttributeTableBuilder builder = new AttributeTableBuilder();
          builder.AddCustomAttributes(typeof(Parallel), new DesignerAttribute(typeof(CustomParallelDesigner)));
          MetadataStore.AddAttributeTable(builder.CreateTable());
    }
    ```

    ```vb
    Sub RegisterCustomMetadata()
       Dim builder As New AttributeTableBuilder()
       builder.AddCustomAttributes(GetType(Parallel), New DesignerAttribute(GetType(CustomParallelDesigner)))
       MetadataStore.AddAttributeTable(builder.CreateTable())
    End Sub
    ```

- Finally, note the use of differing data templates and triggers to select the appropriate template based on the `IsRootDesigner` property.

  The following is the code example.

  ```xaml
  <sad:ActivityDesigner x:Class="Microsoft.Samples.CustomParallelDesigner"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:sad="clr-namespace:System.Activities.Design;assembly=System.Activities.Design"
      xmlns:sadv="clr-namespace:System.Activities.Design.View;assembly=System.Activities.Design">
    <sad:ActivityDesigner.Resources>
      <DataTemplate x:Key="Expanded">
        <StackPanel>
          <TextBlock>This is the Expanded View</TextBlock>
          <sad:WorkflowItemsPresenter HintText="Drop Activities Here"
                                      Items="{Binding Path=ModelItem.Branches}">
            <sad:WorkflowItemsPresenter.SpacerTemplate>
              <DataTemplate>
                <Ellipse Width="10" Height="10" Fill="Black"/>
              </DataTemplate>
            </sad:WorkflowItemsPresenter.SpacerTemplate>
            <sad:WorkflowItemsPresenter.ItemsPanel>
              <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
              </ItemsPanelTemplate>
            </sad:WorkflowItemsPresenter.ItemsPanel>
          </sad:WorkflowItemsPresenter>
        </StackPanel>
      </DataTemplate>
      <DataTemplate x:Key="Collapsed">
        <TextBlock>This is the Collapsed View</TextBlock>
      </DataTemplate>
      <Style x:Key="ExpandOrCollapsedStyle" TargetType="{x:Type ContentPresenter}">
        <Setter Property="ContentTemplate" Value="{DynamicResource Collapsed}"/>
        <Style.Triggers>
          <DataTrigger Binding="{Binding Path=IsRootDesigner}" Value="true">
            <Setter Property="ContentTemplate" Value="{DynamicResource Expanded}"/>
          </DataTrigger>
        </Style.Triggers>
      </Style>
    </sad: ActivityDesigner.Resources>
    <Grid>
      <ContentPresenter Style="{DynamicResource ExpandOrCollapsedStyle}" Content="{Binding}"/>
    </Grid>
  </sad: ActivityDesigner>
  ```

## See also

- <xref:System.Activities.Presentation.WorkflowItemsPresenter>
- [Developing Applications with the Workflow Designer](/visualstudio/workflow-designer/developing-applications-with-the-workflow-designer)
