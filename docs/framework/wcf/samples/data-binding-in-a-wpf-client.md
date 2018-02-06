---
title: "Data Binding in a Windows Presentation Foundation Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bb8c8293-5973-4aef-9b07-afeff5d3293c
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Binding in a Windows Presentation Foundation Client
This sample demonstrates the use of data binding in a Windows Presentation Foundation (WPF) client. The sample uses a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service that randomly generates an array of albums to return to the client. Each album has a name, a price, and a list of album tracks. The album tracks have a name and duration. The information that is returned by the service is automatically bound to the user interface (UI) provided by the [!INCLUDE[avalon1](../../../../includes/avalon1-md.md)] client.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 Data binding allows a data source to be automatically bound to a UI. This simplifies the programming model because it does not require that you programmatically update each UI element with the data from a data object or an array of data objects. You can bind an object to a single UI element or an array to a control that takes multiple inputs, such as a `ListBox`. The following code shows how to bind data to the `DataContext` of a UI element.  
  
```  
// Event handler executed when call is complete  
void client_GetAlbumListCompleted(object sender, GetAlbumListCompletedEventArgs e)  
{  
    // This is on the UI thread, myPanel can be accessed directly  
    myPanel.DataContext = e.Result;   
}  
```  
  
 In the previous sample, the `DataContext` for the `grid` layout element named `myPanel` is set to the data returned by the `GetAlbumList` method. The `DataContext` allows elements to inherit information from their parent elements about the data source that is used for binding, as well as other characteristics of the binding such as the path. The line of code must be executed every time the data on the server is updated. For example, it is executed when the window is initialized and when a new album is added.  
  
 In the following sample XAML code, the `ListBox` specifies `ItemsSource="{Binding }"`.  
  
```xml  
<ListBox   
          ItemTemplate="{StaticResource AlbumStyle}"  
          ItemsSource="{Binding }"   
          IsSynchronizedWithCurrentItem="true" />  
```  
  
 This specifies that the data bound to the top-level UI element is also bound to this control (that is, the array of Albums). In addition, `ItemTemplate="{StaticResource AlbumStyle}"` specifies the data template to be used for each item in the `ListBox`. You can also define data templates to specify how the data should be formatted. These data templates can be reused for other UI elements in the application, the advantage is that the data template is defined and maintained in one place.  
  
 The `AlbumStyle` data template lays out a grid with two `TextBlock`s side by side. One specifies the name of the Album and the other the number of Tracks in the album.  
  
```xaml  
<DataTemplate x:Key="AlbumStyle">  
    <Grid>  
        <Grid.ColumnDefinitions>  
            <ColumnDefinition Width="260" />  
            <ColumnDefinition Width="60" />  
        </Grid.ColumnDefinitions>  
        <TextBlock Grid.Column="0" TextContent="{Binding Path=Title}" />  
        <TextBlock Grid.Column="1" TextContent="{Binding Path=Tracks#.Count}" HorizontalAlignment="Right" />  
    </Grid>  
</DataTemplate>  
```  
  
 The following XAML code creates a second `ListBox`.  
  
```xaml  
<ListBox Grid.Row="2"   
            Grid.ColumnSpan="2"   
            ItemTemplate="{StaticResource TrackStyle}"  
            ItemsSource="{Binding Path=Tracks}" />  
```  
  
 The code specifies a path for the `ItemsSource`. This indicates that the data bound to this control is not the top-level data but a property of the top-level data named `Tracks`. This property represents the array of tracks contained within the album. In addition, a different `DataTemplate` named `TrackStyle` is specified. The layout of the `TrackStyle` template is similar to that of the `AlbumStyle` template, but the `TextBlock`s are bound to different properties. This is because the two templates are used with different data objects.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Scenario\DataBinding\WPFDataBinding`  
  
## See Also
