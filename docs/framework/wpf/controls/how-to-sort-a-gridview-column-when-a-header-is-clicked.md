---
title: "How to: Sort a GridView Column When a Header Is Clicked"
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
  - "controls [WPF], GridView"
  - "controls [WPF], ListView"
  - "ListView controls [WPF], sorting GridView columns"
  - "GridView controls [WPF], ListView control"
ms.assetid: 4865d720-d147-40ed-83a7-af7587f8aad8
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Sort a GridView Column When a Header Is Clicked
This example shows how to create a <xref:System.Windows.Controls.ListView> control that implements a <xref:System.Windows.Controls.GridView> view mode and sorts the data content when a user clicks a column header.  
  
## Example  
 The following example defines a <xref:System.Windows.Controls.GridView> with three columns that bind to the <xref:System.DateTime.Year%2A>, <xref:System.DateTime.Month%2A>, and <xref:System.DateTime.Day%2A>, properties of the <xref:System.DateTime> structure.  
  
```xaml  
<GridView>  
  <GridViewColumn DisplayMemberBinding="{Binding Path=Year}"   
                  Header="Year"  
                  Width="100"/>  
  <GridViewColumn DisplayMemberBinding="{Binding Path=Month}"   
                  Header="Month"  
                  Width="100"/>  
  <GridViewColumn DisplayMemberBinding="{Binding Path=Day}"   
                  Header="Day"  
                  Width="100"/>  
</GridView>  
```  
  
 The following example shows the data items that are defined as an <xref:System.Collections.ArrayList> of <xref:System.DateTime> objects. The <xref:System.Collections.ArrayList> is defined as the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> for the <xref:System.Windows.Controls.ListView> control.  
  
```xaml  
<ListView.ItemsSource>  
  <s:ArrayList>  
    <p:DateTime>1993/1/1 12:22:02</p:DateTime>  
    <p:DateTime>1993/1/2 13:2:01</p:DateTime>  
    <p:DateTime>1997/1/3 2:1:6</p:DateTime>  
    <p:DateTime>1997/1/4 13:6:55</p:DateTime>  
    <p:DateTime>1999/2/1 12:22:02</p:DateTime>  
    <p:DateTime>1998/2/2 13:2:01</p:DateTime>  
    <p:DateTime>2000/2/3 2:1:6</p:DateTime>  
    <p:DateTime>2002/2/4 13:6:55</p:DateTime>  
    <p:DateTime>2001/3/1 12:22:02</p:DateTime>  
    <p:DateTime>2006/3/2 13:2:01</p:DateTime>  
    <p:DateTime>2004/3/3 2:1:6</p:DateTime>  
    <p:DateTime>2004/3/4 13:6:55</p:DateTime>  
  </s:ArrayList>  
</ListView.ItemsSource>  
```  
  
 The `s` and `p` identifiers in the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] tags refer to namespace mappings that are defined in the metadata of the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] page. The following example shows the metadata definition.  
  
```xaml  
<Window        
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  
    x:Class="ListViewSort.Window1"      
    xmlns:s="clr-namespace:System.Collections;assembly=mscorlib"  
    xmlns:p="clr-namespace:System;assembly=mscorlib">  
```  
  
 To sort the data according to the contents of a column, the example defines an event handler to handle the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event that occurs when you press the column header button. The following example shows how to specify an event handler for the <xref:System.Windows.Controls.GridViewColumnHeader> control.  
  
```xaml  
<ListView x:Name='lv' Height="150" HorizontalAlignment="Center"   
  VerticalAlignment="Center"   
  GridViewColumnHeader.Click="GridViewColumnHeaderClickedHandler"  
 >  
```  
  
 The example defines the event handler so that the sort direction changes between ascending order and descending order each time you press the column header button. The following example shows the event handler.  
  
```csharp  
public partial class Window1 : Window  
{  
    public Window1()  
    {  
        InitializeComponent();  
    }  
  
    GridViewColumnHeader _lastHeaderClicked = null;  
    ListSortDirection _lastDirection = ListSortDirection.Ascending;  
  
    void GridViewColumnHeaderClickedHandler(object sender,  
                                            RoutedEventArgs e)  
    {  
        var headerClicked = e.OriginalSource as GridViewColumnHeader;  
        ListSortDirection direction;  
  
        if (headerClicked != null)  
        {  
            if (headerClicked.Role != GridViewColumnHeaderRole.Padding)  
            {  
                if (headerClicked != _lastHeaderClicked)  
                {  
                    direction = ListSortDirection.Ascending;  
                }  
                else  
                {  
                    if (_lastDirection == ListSortDirection.Ascending)  
                    {  
                        direction = ListSortDirection.Descending;  
                    }  
                    else  
                    {  
                        direction = ListSortDirection.Ascending;  
                    }  
                }  
  
                var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                Sort(sortBy, direction);
  
                if (direction == ListSortDirection.Ascending)  
                {  
                    headerClicked.Column.HeaderTemplate =  
                      Resources["HeaderTemplateArrowUp"] as DataTemplate;  
                }  
                else  
                {  
                    headerClicked.Column.HeaderTemplate =  
                      Resources["HeaderTemplateArrowDown"] as DataTemplate;  
                }  
  
                // Remove arrow from previously sorted header  
                if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)  
                {  
                    _lastHeaderClicked.Column.HeaderTemplate = null;  
                }  
  
                _lastHeaderClicked = headerClicked;  
                _lastDirection = direction;  
            }  
        }  
    }
}
```  
  
```vb  
Partial Public Class Window1  
	Inherits Window
	Public Sub New()  
		InitializeComponent()  
	End Sub  
  
	Private _lastHeaderClicked As GridViewColumnHeader = Nothing  
	Private _lastDirection As ListSortDirection = ListSortDirection.Ascending  
  
	Private Sub GridViewColumnHeaderClickedHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)  
		Dim headerClicked = TryCast(e.OriginalSource, GridViewColumnHeader)  
		Dim direction As ListSortDirection  
  
		If headerClicked IsNot Nothing Then  
			If headerClicked.Role <> GridViewColumnHeaderRole.Padding Then  
				If headerClicked IsNot _lastHeaderClicked Then  
					direction = ListSortDirection.Ascending  
				Else  
					If _lastDirection = ListSortDirection.Ascending Then  
						direction = ListSortDirection.Descending  
					Else  
						direction = ListSortDirection.Ascending  
					End If  
				End If  

				Dim columnBinding = TryCast(headerClicked.Column.DisplayMemberBinding, Binding)
				Dim sortBy = If(columnBinding?.Path.Path, TryCast(headerClicked.Column.Header, String))

				Sort(sortBy, direction)  

				If direction = ListSortDirection.Ascending Then
					headerClicked.Column.HeaderTemplate = TryCast(Resources("HeaderTemplateArrowUp"), DataTemplate)  
				Else  
					headerClicked.Column.HeaderTemplate = TryCast(Resources("HeaderTemplateArrowDown"), DataTemplate)  
				End If  
  
				' Remove arrow from previously sorted header  
				If _lastHeaderClicked IsNot Nothing AndAlso _lastHeaderClicked IsNot headerClicked Then  
					_lastHeaderClicked.Column.HeaderTemplate = Nothing  
				End If  
  
				_lastHeaderClicked = headerClicked  
				_lastDirection = direction  
			End If  
		End If  
	End Sub
End Class
```  
  
 The following example shows the sorting algorithm that is called by the event handler to sort the data. The sort is performed by creating a new <xref:System.ComponentModel.SortDescription> structure.  
  
```csharp  
private void Sort(string sortBy, ListSortDirection direction)  
{  
    ICollectionView dataView =  
      CollectionViewSource.GetDefaultView(lv.ItemsSource);  
  
    dataView.SortDescriptions.Clear();  
    SortDescription sd = new SortDescription(sortBy, direction);  
    dataView.SortDescriptions.Add(sd);  
    dataView.Refresh();  
}  
```  
  
```vb  
Private Sub Sort(ByVal sortBy As String, ByVal direction As ListSortDirection)  
	Dim dataView As ICollectionView = CollectionViewSource.GetDefaultView(lv.ItemsSource)  
  
	dataView.SortDescriptions.Clear()  
	Dim sd As New SortDescription(sortBy, direction)  
	dataView.SortDescriptions.Add(sd)  
	dataView.Refresh()  
End Sub  
```  
  
## See Also  
 <xref:System.Windows.Controls.ListView>  
 <xref:System.Windows.Controls.GridView>  
 [ListView Overview](../../../../docs/framework/wpf/controls/listview-overview.md)  
 [GridView Overview](../../../../docs/framework/wpf/controls/gridview-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/listview-how-to-topics.md)
