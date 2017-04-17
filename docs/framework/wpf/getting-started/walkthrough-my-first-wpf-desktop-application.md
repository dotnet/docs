---
title: "Walkthrough: My First WPF Desktop Application1 | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "getting started, WPF"
  - "WPF, getting started"
ms.assetid: b96bed40-8946-4285-8fe4-88045ab854ed
caps.latest.revision: 71
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
---
# Walkthrough: My First WPF Desktop Application
<a name="introduction"></a> This walkthrough provides an introduction to the development of a              [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] application that includes the elements that are common to most              [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications:              [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] markup, code-behind, application definitions, controls, layout, data binding, and styles.  
  
 This walkthrough guides you through the development of a simple              [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application using the following steps.  
  
-   Defining                      [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] to design the appearance of the application's                      [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)].  
  
-   Writing code to build the application's behavior.  
  
-   Creating an application definition to manage the application.  
  
-   Adding controls and creating the layout to compose the application                      [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)].  
  
-   Creating styles to create a consistent appearance throughout an application's                      [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)].  
  
-   Binding the                      [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] to data to both populate the                      [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] from data and keep the data and                      [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] synchronized.  
  
 By the end of the walkthrough, you will have built a standalone              [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] application that allows users to view expense reports for selected people. The application will be composed of several              [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] pages that are hosted in a browser-style window.  
  
 The sample code that is used to build this walkthrough is available for both              [!INCLUDE[TLA#tla_visualb](../../../../includes/tlasharptla-visualb-md.md)] and              [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)] at              [Introduction to Building WPF Applications](http://go.microsoft.com/fwlink/?LinkID=160008).  
  
<a name="Requirements"></a>   
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev11_long](../../../../includes/vs-dev11-long-md.md)]  
  
 For more information about installing                  [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)], see                  [Installing Visual Studio](http://msdn.microsoft.com/library/da049020-cfda-40d7-8ff4-7492772b620f).  
  
<a name="Create_The_Application_Code_Files"></a>   
## Creating the Application Project  
 In this section, you create the application infrastructure, which includes an application definition, two pages, and an image.  
  
1.  Create a new WPF Application project in Visual Basic or Visual C# named                          `ExpenseIt`. For more information, see                          [How to: Create a New WPF Application Project](http://msdn.microsoft.com/en-us/1f6aea7a-33e1-4d3f-8555-1daa42e95d82).  
  
    > [!NOTE]
    >  This                              walkthrough uses the                              <xref:System.Windows.Controls.DataGrid> control that is available in the .NET Framework 4. Be sure that your project targets the .NET Framework 4. For more information, see                              [How to: Target a Version of the .NET Framework](http://msdn.microsoft.com/library/dea62d25-3d1b-492e-a6cc-b5154489800a).  
  
2.  Open Application.xaml (Visual Basic) or App.xaml (C#).  
  
     This                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file defines a                          [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application and any application resources. You also use this file to specify the                          [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] that automatically shows when the application starts; in this case, MainWindow.xaml.  
  
     Your                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] should look like this in Visual Basic:  
  
     [!code-xml[ExpenseIt#1_A](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/Application.xaml#1_a)]  
  
     Or like this in C#:  
  
     [!code-xml[ExpenseIt#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt/App.xaml#1)]  
  
3.  Open MainWindow.xaml.  
  
     This                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file is the main window of your application and displays content created in pages. The                          <xref:System.Windows.Window> class defines the properties of a window, such as its title, size, or icon, and handles events, such as closing or hiding.  
  
4.  Change the                          <xref:System.Windows.Window> element to a                          <xref:System.Windows.Navigation.NavigationWindow>.  
  
     This application will navigate to different content depending on the user interaction. Therefore, the main                          <xref:System.Windows.Window> needs to be changed to a                          <xref:System.Windows.Navigation.NavigationWindow>.                          <xref:System.Windows.Navigation.NavigationWindow> inherits all the properties of                          <xref:System.Windows.Window>. The                          <xref:System.Windows.Navigation.NavigationWindow> element in the XAML file creates an instance of the                          <xref:System.Windows.Navigation.NavigationWindow> class. For more information, see                          [Navigation Overview](../../../../docs/framework/wpf/app-development/navigation-overview.md).  
  
5.  Change the following properties on the                          <xref:System.Windows.Navigation.NavigationWindow> element:  
  
    -   Set the                                  <xref:System.Windows.Window.Title%2A> property to "ExpenseIt".  
  
    -   Set the                                  <xref:System.Windows.FrameworkElement.Width%2A> property to 500 pixels.  
  
    -   Set the                                  <xref:System.Windows.FrameworkElement.Height%2A> property to 350 pixels.  
  
    -   Remove the                                  <xref:System.Windows.Controls.Grid> elements between the                                  <xref:System.Windows.Navigation.NavigationWindow> tags.  
  
     Your                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] should look like this in Visual Basic:  
  
     [!code-xml[ExpenseIt#2_A](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt/MainWindow.xaml#2_a)]  
  
     Or like this in C#:  
  
     [!code-xml[ExpenseIt#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt/MainWindow.xaml#2)]  
  
6.  Open MainWindow.xaml.vb or MainWindow.xaml.cs.  
  
     This file is a code-behind file that contains code to handle the events declared in MainWindow.xaml. This file contains a partial class for the window defined in XAML.  
  
7.  If you are using C#, change the                          `MainWindow` class to derive from                          <xref:System.Windows.Navigation.NavigationWindow>.  
  
     In Visual Basic, this happens automatically when you change the window in XAML.  
  
     Your code should look like this.  
  
     [!code-csharp[ExpenseIt#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt/MainWindow.xaml.cs#3)]
     [!code-vb[ExpenseIt#3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/MainWindow.xaml.vb#3)]  
  
<a name="add_files_to_the_application"></a>   
## Adding Files to the Application  
 In this section, you add two pages and an image to the application.  
  
1.  Add a new Page (WPF) to the project named                          `ExpenseItHome.xaml`. For more information, see                          [How to: Add New Items to a WPF Project](http://msdn.microsoft.com/en-us/17e6b238-fc32-4385-98ef-2f66ca09d9ad).  
  
     This page is the first page that is displayed when the application is launched. It will show a list of people from which a user can select a person to show an expense report for.  
  
2.  Open ExpenseItHome.xaml.  
  
3.  Set the                          <xref:System.Windows.Controls.Page.Title%2A> to "ExpenseIt - Home".  
  
     Your                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] should look like this in Visual Basic:  
  
     [!code-xml[ExpenseIt#6_A](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/ExpenseItHome.xaml#6_a)]  
  
     Or this in C#:  
  
     [!code-xml[ExpenseIt#6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt2/ExpenseItHome.xaml#6)]  
  
4.  Open MainWindow.xaml.  
  
5.  Set the                          <xref:System.Windows.Navigation.NavigationWindow.Source%2A> property on the                          <xref:System.Windows.Navigation.NavigationWindow> to "ExpenseItHome.xaml".  
  
     This sets ExpenseItHome.xaml to be the first page opened when the application starts. Your                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] should look like this in Visual Basic:  
  
     [!code-xml[ExpenseIt#7_A](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/MainWindow.xaml#7_a)]  
  
     Or this in C#:  
  
     [!code-xml[ExpenseIt#7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt2/MainWindow.xaml#7)]  
  
6.  Add a new Page (WPF) to the project named                          `ExpenseReportPage.xaml`.  
  
     This page will show the expense report for the person that is selected on ExpenseItHome.xaml.  
  
7.  Open ExpenseReportPage.xaml.  
  
8.  Set the                          <xref:System.Windows.Controls.Page.Title%2A> to "ExpenseIt - View Expense".  
  
     Your                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] should look like this in Visual Basic:  
  
     [!code-xml[ExpenseIt#4_A](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/ExpenseReportPage.xaml#4_a)]  
  
     Or this in C#:  
  
     [!code-xml[ExpenseIt#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt/ExpenseReportPage.xaml#4)]  
  
9. Open ExpenseItHome.xaml.vb and ExpenseReportPage.xaml.vb, or ExpenseItHome.xaml.cs and ExpenseReportPage.xaml.cs.  
  
     When you create a new Page file, Visual Studio automatically creates a code behind file. These code-behind files handle the logic for responding to user input.  
  
     Your code should look like this.  
  
     [!code-csharp[ExpenseIt#2_5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt2/ExpenseItHome.xaml.cs#2_5)]
     [!code-vb[ExpenseIt#2_5](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/ExpenseItHome.xaml.vb#2_5)]  
  
     [!code-csharp[ExpenseIt#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt/ExpenseReportPage.xaml.cs#5)]
     [!code-vb[ExpenseIt#5](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt1_A/ExpenseReportPage.xaml.vb#5)]  
  
10. Add an image named watermark.png to the project. You can either create your own image, or copy the file from the sample code. For more information, see                          [NIB:How to: Add Existing Items to a Project](http://msdn.microsoft.com/en-us/15f4cfb7-78ab-457f-9f14-099a25a6a2d3).  
  
<a name="Build_The_Application"></a>   
## Building and Running the Application  
 In this section, you build and run the application.  
  
1.  Build and run the application by pressing F5 or select                          **Start Debugging** from the                          **Debug** menu.  
  
     The following illustration shows the application with the                          <xref:System.Windows.Navigation.NavigationWindow> buttons.  
  
     ![ExpenseIt sample screen shot](../../../../docs/framework/wpf/getting-started/media/gettingstartedfigure1.png "GettingStartedFigure1")  
  
2.  Close the application to return to                          [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)].  
  
<a name="Add_Layout"></a>   
## Creating the Layout  
 Layout provides an ordered way to place                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements, and also manages the size and position of those elements when a                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] is resized. You typically create a layout with one of the following layout controls:  
  
-   <xref:System.Windows.Controls.Canvas>  
  
-   <xref:System.Windows.Controls.DockPanel>  
  
-   <xref:System.Windows.Controls.Grid>  
  
-   <xref:System.Windows.Controls.StackPanel>  
  
-   <xref:System.Windows.Controls.VirtualizingStackPanel>  
  
-   <xref:System.Windows.Controls.WrapPanel>  
  
 Each of these layout controls supports a special type of layout for its child elements. ExpenseIt pages can be resized, and each page has elements that are arranged horizontally and vertically alongside other elements. Consequently, the                  <xref:System.Windows.Controls.Grid> is the ideal layout element for the application.  
  
> [!NOTE]
>  For more information about                      <xref:System.Windows.Controls.Panel> elements, see                      [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md). For more information about layout, see                      [Layout](../../../../docs/framework/wpf/advanced/layout.md).  
  
 In the section, you create a single-column table with three rows and a 10-pixel margin by adding column and row definitions to the                  <xref:System.Windows.Controls.Grid> in ExpenseItHome.xaml.  
  
1.  Open ExpenseItHome.xaml.  
  
2.  Set the                          <xref:System.Windows.FrameworkElement.Margin%2A> property on the                          <xref:System.Windows.Controls.Grid> element to "10,0,10,10" which corresponds to left, top, right and bottom margins.  
  
3.  Add the following                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] between the                          <xref:System.Windows.Controls.Grid> tags to create the row and column definitions.  
  
     [!code-xml[ExpenseIt#8](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt3/ExpenseItHome.xaml#8)]  
  
     The                          <xref:System.Windows.Controls.RowDefinition.Height%2A> of two rows is set to                          <xref:System.Windows.GridLength.Auto%2A> which means that the rows will be sized base on the content in the rows. The default                          <xref:System.Windows.Controls.RowDefinition.Height%2A> is                          <xref:System.Windows.GridUnitType> sizing, which means that the row will be a weighted proportion of the available space. For example if two rows each have a height of "*", they will each have a height that is half of the available space.  
  
     Your                          <xref:System.Windows.Controls.Grid> should now look like the following XAML:  
  
     [!code-xml[ExpenseIt#9](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt3/ExpenseItHome.xaml#9)]  
  
<a name="Add_Controls"></a>   
## Adding Controls  
 In this section, the home page                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] is updated to show a list of people that users can select from to show the expense report for a selected person. Controls are UI objects that allow users to interact with your application. For more information, see                  [Controls](../../../../docs/framework/wpf/controls/index.md).  
  
 To create this                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)], the following elements are added to ExpenseItHome.xaml:  
  
-   <xref:System.Windows.Controls.ListBox> (for the list of people).  
  
-   <xref:System.Windows.Controls.Label> (for the list header).  
  
-   <xref:System.Windows.Controls.Button> (to click to view the expense report for the person that is selected in the list).  
  
 Each control is placed in a row of the                  <xref:System.Windows.Controls.Grid> by setting the                  <xref:System.Windows.Controls.Grid.Row%2A?displayProperty=fullName> attached property. For more information about attached properties, see                  [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md).  
  
1.  Open ExpenseItHome.xaml.  
  
2.  Add the following                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] between the                          <xref:System.Windows.Controls.Grid> tags.  
  
     [!code-xml[ExpenseIt#10](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt4/ExpenseItHome.xaml#10)]  
  
3.  Build and run the application.  
  
 The following illustration shows the controls that are created by the XAML in this section.  
  
 ![ExpenseIt sample screen shot](../../../../docs/framework/wpf/getting-started/media/gettingstartedfigure2.png "GettingStartedFigure2")  
  
<a name="Add_an_Image"></a>   
## Adding an Image and a Title  
 In this section, the home page                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] is updated with an image and a page title.  
  
1.  Open ExpenseItHome.xaml.  
  
2.  Add another column to the                          <xref:System.Windows.Controls.Grid.ColumnDefinitions%2A> with a fixed                          <xref:System.Windows.Controls.ColumnDefinition.Width%2A> of 230 pixels.  
  
     [!code-xml[ExpenseIt#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt5/ExpenseItHome.xaml#11)]  
  
3.  Add another row to the                          <xref:System.Windows.Controls.Grid.RowDefinitions%2A>.  
  
     [!code-xml[ExpenseIt#11b](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt5/ExpenseItHome.xaml#11b)]  
  
4.  Move the controls to the second column by setting                          <xref:System.Windows.Controls.Grid.Column%2A?displayProperty=fullName> to 1. Move each control down a row, by increasing the                          <xref:System.Windows.Controls.Grid.Row%2A?displayProperty=fullName> by 1.  
  
     [!code-xml[ExpenseIt#12](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt5/ExpenseItHome.xaml#12)]  
  
5.  Set the                          <xref:System.Windows.Controls.Panel.Background%2A> of the                          <xref:System.Windows.Controls.Grid> to be the watermark.png image file.  
  
     [!code-xml[ExpenseIt#14](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt5/ExpenseItHome.xaml#14)]  
  
6.  Before the                          <xref:System.Windows.Controls.Border>, add a                          <xref:System.Windows.Controls.Label> with the content "View Expense Report" to be the title of the page.  
  
     [!code-xml[ExpenseIt#13](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt5/ExpenseItHome.xaml#13)]  
  
7.  Build and run the application.  
  
 The following illustration shows the results of this section.  
  
 ![ExpenseIt sample screen shot](../../../../docs/framework/wpf/getting-started/media/gettingstartedfigure3.png "GettingStartedFigure3")  
  
<a name="Add_Code_to_Process_Events"></a>   
## Adding Code to Handle Events  
  
1.  Open ExpenseItHome.xaml.  
  
2.  Add a                          <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler to the                          <xref:System.Windows.Controls.Button> element. For more information, see                          [How to: Create a Simple Event Handler](http://msdn.microsoft.com/en-us/b1456e07-9dec-4354-99cf-18666b64f480).  
  
     [!code-xml[ExpenseIt#15](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt6/ExpenseItHome.xaml#15)]  
  
3.  Open ExpenseItHome.xaml.vb or ExpenseItHome.xaml.cs.  
  
4.  Add the following code to the                          <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler, which causes the window to navigate to the ExpenseReportPage.xaml file.  
  
     [!code-csharp[ExpenseIt#16](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt6/ExpenseItHome.xaml.cs#16)]
     [!code-vb[ExpenseIt#16](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt6/ExpenseItHome.xaml.vb#16)]  
  
<a name="Create_the_UI_for_Pane2"></a>   
## Creating the UI for ExpenseReportPage  
 ExpenseReportPage.xaml displays the expense report for the person that was selected on the ExpenseItHome.xaml. This section adds controls and creates the                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] for ExpenseReportPage.xaml. This section also adds background and fill colors to the various                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements.  
  
1.  Open ExpenseReportPage.xaml.  
  
2.  Add the following XAML between the                          <xref:System.Windows.Controls.Grid> tags.  
  
     This UI is similar to the UI created on ExpenseItHome.xaml except the report data is displayed in a                          <xref:System.Windows.Controls.DataGrid>.  
  
     [!code-xml[ExpenseIt#17](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt6/ExpenseReportPage.xaml#17)]  
  
3.  Build and run the application.  
  
    > [!NOTE]
    >  If you get an error that the                              <xref:System.Windows.Controls.DataGrid> was not found or does not exist, make sure that your project targets the .NET Framework 4. For more information, see                              [How to: Target a Version of the .NET Framework](http://msdn.microsoft.com/library/dea62d25-3d1b-492e-a6cc-b5154489800a).  
  
4.  Click the                          **View** button.  
  
     The expense report page appears.  
  
 The following illustration shows the                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements added to ExpenseReportPage.xaml. Notice that the back navigation button is enabled.  
  
 ![ExpenseIt sample screen shot](../../../../docs/framework/wpf/getting-started/media/gettingstartedfigure4.png "GettingStartedFigure4")  
  
<a name="Add_Code_to_Style_a_Control"></a>   
## Styling Controls  
 The appearance of various elements can often be the same for all elements of the same type in a                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)].                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] uses styles to make appearances reusable across multiple elements. The reusability of styles helps to simplify                  [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] creation and management. For more information about styles, see                  [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md). This section replaces the per-element attributes that were defined in previous steps with styles.  
  
1.  Open Application.xaml or App.xaml.  
  
2.  Add the following XAML between the                          <xref:System.Windows.Application.Resources%2A?displayProperty=fullName> tags:  
  
     [!code-xml[ExpenseIt#18](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt7/App.xaml#18)]  
  
     This                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] adds the following styles:  
  
    -   `headerTextStyle`: To format the page title                                  <xref:System.Windows.Controls.Label>.  
  
    -   `labelStyle`: To format the                                  <xref:System.Windows.Controls.Label> controls.  
  
    -   `columnHeaderStyle`: To format the                                  <xref:System.Windows.Controls.Primitives.DataGridColumnHeader>.  
  
    -   `listHeaderStyle`: To format the list header                                  <xref:System.Windows.Controls.Border> controls.  
  
    -   `listHeaderTextStyle`: To format the list header                                  <xref:System.Windows.Controls.Label>.  
  
    -   `buttonStyle`: To format the                                  <xref:System.Windows.Controls.Button> on ExpenseItHome.xaml.  
  
     Notice that the styles are resources and children of the                          <xref:System.Windows.Application.Resources%2A?displayProperty=fullName> property element. In this location, the styles are applied to all the elements in an application. For an example of using resources in a                          [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] application, see                          [Use Application Resources](../../../../docs/framework/wpf/advanced/how-to-use-application-resources.md).  
  
3.  Open ExpenseItHome.xaml.  
  
4.  Replace everything between the                          <xref:System.Windows.Controls.Grid> elements with the following XAML.  
  
     [!code-xml[ExpenseIt#19](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt7/ExpenseItHome.xaml#19)]  
  
     The properties such as                          <xref:System.Windows.VerticalAlignment> and                          <xref:System.Windows.Media.FontFamily> that define the look of each control are removed and replaced by applying the styles. For example, the                          `headerTextStyle` is applied to the "View Expense Report"                          <xref:System.Windows.Controls.Label>.  
  
5.  Open ExpenseReportPage.xaml.  
  
6.  Replace everything between the                          <xref:System.Windows.Controls.Grid> elements with the following XAML.  
  
     [!code-xml[ExpenseIt#20](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt7/ExpenseReportPage.xaml#20)]  
  
     This adds styles to the                          <xref:System.Windows.Controls.Label> and                          <xref:System.Windows.Controls.Border> elements.  
  
7.  Build and run the application.  
  
     After adding the                          [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] in this section, the application looks the same as it did before being updated with styles.  
  
<a name="Bind_Data_to_a_Control"></a>   
## Binding Data to a Control  
 In this section, you create the                  [!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] data that is bound to various controls.  
  
1.  Open ExpenseItHome.xaml.  
  
2.  After                          the opening                          <xref:System.Windows.Controls.Grid> element, add the following XAML to create an                          <xref:System.Windows.Data.XmlDataProvider> that contains the data for each person.  
  
     The data is created as a                          <xref:System.Windows.Controls.Grid> resource. Normally this would be loaded as a file, but for simplicity the data is added inline.  
  
     [!code-xml[ExpenseIt#21](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#21)]  
    [!code-xml[ExpenseIt#23](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#23)]  
    [!code-xml[ExpenseIt#22](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#22)]  
  
3.  In the                          <xref:System.Windows.Controls.Grid> resource, add the following                          <xref:System.Windows.DataTemplate>, which defines how to display the data in the                          <xref:System.Windows.Controls.ListBox>. For more information about data templates, see                          [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md).  
  
     [!code-xml[ExpenseIt#21](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#21)]  
    [!code-xml[ExpenseIt#24](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#24)]  
    [!code-xml[ExpenseIt#22](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#22)]  
  
4.  Replace the existing                          <xref:System.Windows.Controls.ListBox> with the following XAML.  
  
     [!code-xml[ExpenseIt#25](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml#25)]  
  
     This XAML binds the                          <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property of the                          <xref:System.Windows.Controls.ListBox> to the data source and applies the data template as the                          <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A>.  
  
<a name="Connect_Data_to_Controls"></a>   
## Connecting Data to Controls  
 In this section, you write the code that retrieves the current item that is selected in the list of people on the ExpenseItHome.xaml page, and passes its reference to the constructor of                  `ExpenseReportPage` during instantiation.                  `ExpenseReportPage` sets its data context with the passed item, which is what the controls defined in ExpenseReportPage.xaml will bind to.  
  
1.  Open ExpenseReportPage.xaml.vb or ExpenseReportPage.xaml.cs.  
  
2.  Add a constructor that takes an object so you can pass the expense report data of the selected person.  
  
     [!code-csharp[ExpenseIt#26](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseReportPage.xaml.cs#26)]
     [!code-vb[ExpenseIt#26](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt8/ExpenseReportPage.xaml.vb#26)]  
  
3.  Open ExpenseItHome.xaml.vb or ExpenseItHome.xaml.cs.  
  
4.  Change the                          <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler to call the new constructor passing the expense report data of the selected person.  
  
     [!code-csharp[ExpenseIt#27](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt8/ExpenseItHome.xaml.cs#27)]
     [!code-vb[ExpenseIt#27](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ExpenseIt/VB/ExpenseIt8/ExpenseItHome.xaml.vb#27)]  
  
<a name="Add_Style_to_Data"></a>   
## Styling Data with Data Templates  
 In this section, you update the                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] for each item in the data bound lists by using data templates.  
  
1.  Open ExpenseReportPage.xaml.  
  
2.  Bind the content of the "Name" and "Department"                          <xref:System.Windows.Controls.Label> elements to the appropriate data source property. For more information about data binding, see                          [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
     [!code-xml[ExpenseIt#31](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt9/ExpenseReportPage.xaml#31)]  
  
3.  After the opening                          <xref:System.Windows.Controls.Grid> element, add the following data templates, which define how to display the expense report data.  
  
     [!code-xml[ExpenseIt#30](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt9/ExpenseReportPage.xaml#30)]  
  
4.  Apply the templates to the                          <xref:System.Windows.Controls.DataGrid> columns that display the expense report data.  
  
     [!code-xml[ExpenseIt#32](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ExpenseIt/CSharp/ExpenseIt9/ExpenseReportPage.xaml#32)]  
  
5.  Build and run the application.  
  
6.  Select a person and click the                          **View** button.  
  
 The following illustration shows both pages of the ExpenseIt application with controls, layout, styles, data binding, and data templates applied.  
  
 ![ExpenseIt sample screen shots](../../../../docs/framework/wpf/getting-started/media/gettingstartedfigure5.png "GettingStartedFigure5")  
  
<a name="Best_Practices"></a>   
## Best Practices  
 This sample demonstrates a specific feature of WPF and, consequently, does not follow application development best practices. For comprehensive coverage of                  [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and the                  [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] application development best practices, see the following topics as appropriate:  
  
-   Accessibility -                          [Accessibility Best Practices](../../../../docs/framework/ui-automation/accessibility-best-practices.md)  
  
-   Security -                          [Security](../../../../docs/framework/wpf/security-wpf.md)  
  
-   Localization -                          [WPF Globalization and Localization Overview](../../../../docs/framework/wpf/advanced/wpf-globalization-and-localization-overview.md)  
  
-   Performance -                          [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
  
<a name="Whats_Next"></a>   
## What's Next  
 You now have a number of techniques at your disposal for creating a                  [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] using                  [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)]. You should now have a broad understanding of the basic building blocks of a data-bound                  [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] application. This topic is by no means exhaustive, but hopefully you also now have a sense of some of the possibilities you might discover on your own beyond the techniques in this topic.  
  
 For more information about the WPF architecture and programming models, see the following topics:  
  
-   [WPF Architecture](../../../../docs/framework/wpf/advanced/wpf-architecture.md)  
  
-   [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
  
-   [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
  
-   [Layout](../../../../docs/framework/wpf/advanced/layout.md)  
  
 For more information about creating applications, see the following topics:  
  
-   [Application Development](../../../../docs/framework/wpf/app-development/index.md)  
  
-   [Controls](../../../../docs/framework/wpf/controls/index.md)  
  
-   [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
  
-   [Graphics and Multimedia](../../../../docs/framework/wpf/graphics-multimedia/index.md)  
  
-   [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
  
## See Also  
 [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md)   
 [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md)   
 [Building a WPF Application](../../../../docs/framework/wpf/app-development/building-a-wpf-application-wpf.md)   
 [Styles and Templates](../../../../docs/framework/wpf/controls/styles-and-templates.md)