---
title: "Custom Composite Designers - Workflow Item Presenter"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f85224cf-9e30-44a5-9a81-3bc438a34364
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Composite Designers - Workflow Item Presenter
The <xref:System.Activities.Presentation.WorkflowItemPresenter> is a key type in the WF designer programming model that allows for the creation of a "drop zone" where an arbitrary activity can be placed. This sample shows how to build an activity designer that surfaces such a "drop zone."  
  
 This sample demonstrates:  
  
## Demonstrates  
  
-   Creating a custom activity designer with a <xref:System.Activities.Presentation.WorkflowItemPresenter>.  
  
-   Registering the custom designer using the metadata store.  
  
-   Programming the rehosted toolbox declaratively and imperatively.  
  
## Sample Details  
 The code for this sample shows:  
  
-   The custom activity designer is built for the `SimpleNativeActivity` class.  
  
-   The creation of a custom activity designer with a <xref:System.Activities.Presentation.WorkflowItemPresenter>.  
  
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
  
#### To setup, build, and run the sample  
  
1.  Open the solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Press F5 to compile and run the application.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\CustomActivities\CustomActivityDesigners\WorkflowItemPresenter`  
  
## See Also  
 <xref:System.Activities.Presentation.WorkflowItemPresenter>  
 [Developing Applications with the Workflow Designer](/visualstudio/workflow-designer/developing-applications-with-the-workflow-designer)
