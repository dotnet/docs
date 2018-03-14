---
title: "Walkthrough: Binding to Data in Hybrid Applications"
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
  - "hybrid applications [WPF interoperability]"
  - "data binding [WPF interoperability]"
ms.assetid: 18997e71-745a-4425-9c69-2cbce1d8669e
caps.latest.revision: 39
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Binding to Data in Hybrid Applications
Binding a data source to a control is essential for providing users with access to underlying data, whether you are using [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] or [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. This walkthrough shows how you can use data binding in hybrid applications that include both [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Creating the project.  
  
-   Defining the data template.  
  
-   Specifying the form layout.  
  
-   Specifying data bindings.  
  
-   Displaying data by using interoperation.  
  
-   Adding the data source to the project.  
  
-   Binding to the data source.  
  
 For a complete code listing of the tasks illustrated in this walkthrough, see [Data Binding in Hybrid Applications Sample](http://go.microsoft.com/fwlink/?LinkID=159983).  
  
 When you are finished, you will have an understanding of data binding features in hybrid applications.  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev10_long](../../../../includes/vs-dev10-long-md.md)].  
  
-   Access to the Northwind sample database running on Microsoft SQL Server.  
  
## Creating the Project  
  
#### To create and set up the project  
  
1.  Create a WPF Application project named `WPFWithWFAndDatabinding`.  
  
2.  In Solution Explorer, add references to the following assemblies.  
  
    -   WindowsFormsIntegration  
  
    -   System.Windows.Forms  
  
3.  Open MainWindow.xaml in the [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)].  
  
4.  In the <xref:System.Windows.Window> element, add the following [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] namespaces mapping.  
  
    ```xaml  
    xmlns:wf="clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms"  
    ```  
  
5.  Name the default <xref:System.Windows.Controls.Grid> element `mainGrid` by assigning the <xref:System.Windows.FrameworkElement.Name%2A> property.  
  
     [!code-xaml[WPFWithWFAndDatabinding#8](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml#8)]  
  
## Defining the Data Template  
 The master list of customers is displayed in a <xref:System.Windows.Controls.ListBox> control. The following code example defines a <xref:System.Windows.DataTemplate> object named `ListItemsTemplate` that controls the visual tree of the <xref:System.Windows.Controls.ListBox> control. This <xref:System.Windows.DataTemplate> is assigned to the <xref:System.Windows.Controls.ListBox> control's <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> property.  
  
#### To define the data template  
  
-   Copy the following XAML into the <xref:System.Windows.Controls.Grid> element's declaration.  
  
     [!code-xaml[WPFWithWFAndDatabinding#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml#3)]  
  
## Specifying the Form Layout  
 The layout of the form is defined by a grid with three rows and three columns. <xref:System.Windows.Controls.Label> controls are provided to identify each column in the Customers table.  
  
#### To set up the Grid layout  
  
-   Copy the following XAML into the <xref:System.Windows.Controls.Grid> element's declaration.  
  
     [!code-xaml[WPFWithWFAndDatabinding#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml#4)]  
  
#### To set up the Label controls  
  
-   Copy the following XAML into the <xref:System.Windows.Controls.Grid> element's declaration.  
  
     [!code-xaml[WPFWithWFAndDatabinding#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml#5)]  
  
## Specifying Data Bindings  
 The master list of customers is displayed in a <xref:System.Windows.Controls.ListBox> control. The attached `ListItemsTemplate` binds a <xref:System.Windows.Controls.TextBlock> control to the `ContactName` field from the database.  
  
 The details of each customer record are displayed in several <xref:System.Windows.Controls.TextBox> controls.  
  
#### To specify data bindings  
  
-   Copy the following XAML into the <xref:System.Windows.Controls.Grid> element's declaration.  
  
     The <xref:System.Windows.Data.Binding> class binds the <xref:System.Windows.Controls.TextBox> controls to the appropriate fields in the database.  
  
     [!code-xaml[WPFWithWFAndDatabinding#6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml#6)]  
  
## Displaying Data by Using Interoperation  
 The orders corresponding to the selected customer are displayed in a <xref:System.Windows.Forms.DataGridView?displayProperty=nameWithType> control named `dataGridView1`. The `dataGridView1` control is bound to the data source in the code-behind file. A <xref:System.Windows.Forms.Integration.WindowsFormsHost> control is the parent of this [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control.  
  
#### To display data in the DataGridView control  
  
-   Copy the following XAML into the <xref:System.Windows.Controls.Grid> element's declaration.  
  
     [!code-xaml[WPFWithWFAndDatabinding#7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml#7)]  
  
## Adding the Data Source to the Project  
 With [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)], you can easily add a data source to your project. This procedure adds a strongly typed data set to your project. Several other support classes, such as table adapters for each of the chosen tables, are also added.  
  
#### To add the data source  
  
1.  From the **Data** menu, select **Add New Data Source**.  
  
2.  In the **Data Source Configuration Wizard**, create a connection to the Northwind database by using a dataset. For more information, see [How to: Connect to Data in a Database](http://msdn.microsoft.com/library/6c56e54e-8834-4297-85aa-cc1a443ba556).  
  
3.  When you are prompted by the **Data Source Configuration Wizard**, save the connection string as `NorthwindConnectionString`.  
  
4.  When you are prompted to choose your database objects, select the `Customers` and `Orders` tables, and name the generated data set `NorthwindDataSet`.  
  
## Binding to the Data Source  
 The <xref:System.Windows.Forms.BindingSource?displayProperty=nameWithType> component provides a uniform interface for the application's data source. Binding to the data source is implemented in the code-behind file.  
  
#### To bind to the data source  
  
1.  Open the code-behind file, which is named MainWindow.xaml.vb or MainWindow.xaml.cs.  
  
2.  Copy the following code into the `MainWindow` class definition.  
  
     This code declares the <xref:System.Windows.Forms.BindingSource> component and associated helper classes that connect to the database.  
  
     [!code-csharp[WPFWithWFAndDatabinding#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml.cs#11)]
     [!code-vb[WPFWithWFAndDatabinding#11](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFWithWFAndDatabinding/VisualBasic/WPFWithWFAndDatabinding/Window1.xaml.vb#11)]  
  
3.  Copy the following code into the constructor.  
  
     This code creates and initializes the <xref:System.Windows.Forms.BindingSource> component.  
  
     [!code-csharp[WPFWithWFAndDatabinding#12](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml.cs#12)]
     [!code-vb[WPFWithWFAndDatabinding#12](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFWithWFAndDatabinding/VisualBasic/WPFWithWFAndDatabinding/Window1.xaml.vb#12)]  
  
4.  Open MainWindow.xaml.  
  
5.  In Design view or XAML view, select the <xref:System.Windows.Window> element.  
  
6.  In the Properties window, click the **Events** tab.  
  
7.  Double-click the <xref:System.Windows.FrameworkElement.Loaded> event.  
  
8.  Copy the following code into the <xref:System.Windows.FrameworkElement.Loaded> event handler.  
  
     This code assigns the <xref:System.Windows.Forms.BindingSource> component as the data context and populates the `Customers` and `Orders` adapter objects.  
  
     [!code-csharp[WPFWithWFAndDatabinding#13](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml.cs#13)]
     [!code-vb[WPFWithWFAndDatabinding#13](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFWithWFAndDatabinding/VisualBasic/WPFWithWFAndDatabinding/Window1.xaml.vb#13)]  
  
9. Copy the following code into the `MainWindow` class definition.  
  
     This method handles the <xref:System.Windows.Data.CollectionView.CurrentChanged> event and updates the current item of the data binding.  
  
     [!code-csharp[WPFWithWFAndDatabinding#14](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFWithWFAndDatabinding/CSharp/WPFWithWFAndDatabinding/Window1.xaml.cs#14)]
     [!code-vb[WPFWithWFAndDatabinding#14](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFWithWFAndDatabinding/VisualBasic/WPFWithWFAndDatabinding/Window1.xaml.vb#14)]  
  
10. Press F5 to build and run the application.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)  
 [Data Binding in Hybrid Applications Sample](http://go.microsoft.com/fwlink/?LinkID=159983)  
 [Walkthrough: Hosting a Windows Forms Composite Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)  
 [Walkthrough: Hosting a WPF Composite Control in Windows Forms](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
