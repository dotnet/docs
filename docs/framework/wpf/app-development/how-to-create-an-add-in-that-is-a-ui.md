---
title: "How to: Create an Add-In That Is a UI"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "creating an add-in that is a UI [WPF]"
  - "add-ins [WPF], UI"
  - "creating UI add-ins [WPF]"
  - "UI add-ins [WPF], creating"
  - "implementing UI add-ins [WPF]"
  - "pipeline segments [WPF], creating add-ins"
ms.assetid: 86375525-282b-4039-8352-8680051a10ea
---
# How to: Create an Add-In That Is a UI
This example shows how to create an add-in that is a Windows Presentation Foundation (WPF) which is hosted by a WPF standalone application.  
  
 The add-in is a UI that is a WPF user control. The content of the user control is a single button that, when clicked, displays a message box. The WPF standalone application hosts the add-in UI as the content of the main application window.  
  
 **Prerequisites**  
  
 This example highlights the WPF extensions to the .NET Framework add-in model that enable this scenario, and assumes the following:  
  
- Knowledge of the .NET Framework add-in model, including pipeline, add-in, and host development. If you are unfamiliar with these concepts, see [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100)). For a tutorial that demonstrates the implementation of a pipeline, an add-in, and a host application, see [Walkthrough: Creating an Extensible Application](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb788290(v%3dvs.100)).  
  
- Knowledge of the WPF extensions to the .NET Framework add-in model. See [WPF Add-Ins Overview](wpf-add-ins-overview.md).  
  
## Example  
 To create an add-in that is a WPF UI requires specific code for each pipeline segment, the add-in, and the host application.  

<a name="Contract"></a>   
## Implementing the Contract Pipeline Segment

When an add-in is a UI, the contract for the add-in must implement <xref:System.AddIn.Contract.INativeHandleContract>. In the example, `IWPFAddInContract` implements <xref:System.AddIn.Contract.INativeHandleContract>, as shown in the following code.  
  
[!code-csharp[SimpleAddInIsAUISample#ContractCode](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/Contracts/IWPFAddInContract.cs#contractcode)]
[!code-vb[SimpleAddInIsAUISample#ContractCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/Contracts/IWPFAddInContract.vb#contractcode)]

<a name="AddInViewPipeline"></a>   
## Implementing the Add-In View Pipeline Segment

Because the add-in is implemented as a subclass of the <xref:System.Windows.FrameworkElement> type, the add-in view must also subclass <xref:System.Windows.FrameworkElement>. The following code shows the add-in view of the contract, implemented as the `WPFAddInView` class.  
  
[!code-csharp[SimpleAddInIsAUISample#AddInViewCode](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/AddInViews/WPFAddInView.cs#addinviewcode)]  
[!code-vb[SimpleAddInIsAUISample#AddInViewCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/AddInViews/WPFAddInView.vb#AddInViewCode)]  
  
Here, the add-in view is derived from <xref:System.Windows.Controls.UserControl>. Consequently, the add-in UI should also derive from <xref:System.Windows.Controls.UserControl>.  
  
<a name="AddInSideAdapter"></a>
## Implementing the Add-In-Side Adapter Pipeline Segment

While the contract is an <xref:System.AddIn.Contract.INativeHandleContract>, the add-in is a <xref:System.Windows.FrameworkElement> (as specified by the add-in view pipeline segment). Therefore, the <xref:System.Windows.FrameworkElement> must be converted to an <xref:System.AddIn.Contract.INativeHandleContract> before crossing the isolation boundary. This work is performed by the add-in-side adapter by calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A>, as shown in the following code.  
  
[!code-csharp[SimpleAddInIsAUISample#AddInSideAdapterCode](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/AddInSideAdapters/WPFAddIn_ViewToContractAddInSideAdapter.cs#addinsideadaptercode)]  
[!code-vb[SimpleAddInIsAUISample#AddInSideAdapterCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/AddInSideAdapters/WPFAddIn_ViewToContractAddInSideAdapter.vb#addinsideadaptercode)]

In the add-in model where an add-in returns a UI (see [Create an Add-In That Returns a UI](how-to-create-an-add-in-that-returns-a-ui.md)), the add-in adapter converted the <xref:System.Windows.FrameworkElement> to an <xref:System.AddIn.Contract.INativeHandleContract> by calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A>. <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> must also be called in this model, although you need to implement a method from which to write the code to call it. You do this by overriding <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> and implementing the code that calls <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> if the code that is calling <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> is expecting an <xref:System.AddIn.Contract.INativeHandleContract>. In this case, the caller will be the host-side adapter, which is covered in a subsequent subsection.  
  
> [!NOTE]
> You also need to override <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> in this model to enable tabbing between host application UI and add-in UI. For more information, see "WPF Add-In Limitations" in [WPF Add-Ins Overview](wpf-add-ins-overview.md).  
  
Because the add-in-side adapter implements an interface that derives from <xref:System.AddIn.Contract.INativeHandleContract>, you also need to implement <xref:System.AddIn.Contract.INativeHandleContract.GetHandle%2A>, although this is ignored when <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> is overridden.  
  
<a name="HostViewPipeline"></a>   
## Implementing the Host View Pipeline Segment

In this model, the host application typically expects the host view to be a <xref:System.Windows.FrameworkElement> subclass. The host-side adapter must convert the <xref:System.AddIn.Contract.INativeHandleContract> to a <xref:System.Windows.FrameworkElement> after the <xref:System.AddIn.Contract.INativeHandleContract> crosses the isolation boundary. Because a method isn't being called by the host application to get the <xref:System.Windows.FrameworkElement>, the host view must "return" the <xref:System.Windows.FrameworkElement> by containing it. Consequently, the host view must derive from a subclass of <xref:System.Windows.FrameworkElement> that can contain other UIs, such as <xref:System.Windows.Controls.UserControl>. The following code shows the host view of the contract, implemented as the `WPFAddInHostView` class.  

[!code-csharp[WPFAddInHostView class](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/HostViews/WPFAddInHostView.cs#HostViewCode)]
[!code-vb[WPFAddInHostView class](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/HostViews/WPFAddInHostView.vb#HostViewCode)]

<a name="HostSideAdapter"></a>   
## Implementing the Host-Side Adapter Pipeline Segment

While the contract is an <xref:System.AddIn.Contract.INativeHandleContract>, the host application expects a <xref:System.Windows.Controls.UserControl> (as specified by the host view). Consequently, the <xref:System.AddIn.Contract.INativeHandleContract> must be converted to a <xref:System.Windows.FrameworkElement> after crossing the isolation boundary, before being set as content of the host view (which derives from <xref:System.Windows.Controls.UserControl>).  
  
This work is performed by the host-side adapter, as shown in the following code.  

[!code-csharp[Host-side adapter](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/HostSideAdapters/WPFAddIn_ContractToViewHostSideAdapter.cs#HostSideAdapterCode)]
[!code-vb[Host-side adapter](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/HostSideAdapters/WPFAddIn_ContractToViewHostSideAdapter.vb#HostSideAdapterCode)]

As you can see, the host-side adapter acquires the <xref:System.AddIn.Contract.INativeHandleContract> by calling the add-in-side adapter's <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> method (this is the point where the <xref:System.AddIn.Contract.INativeHandleContract> crosses the isolation boundary).  
  
The host-side adapter then converts the <xref:System.AddIn.Contract.INativeHandleContract> to a <xref:System.Windows.FrameworkElement> by calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A>. Finally, the <xref:System.Windows.FrameworkElement> is set as the content of the host view.  
  
<a name="AddIn"></a>   
## Implementing the Add-In

With the add-in-side adapter and add-in view in place, the add-in can be implemented by deriving from the add-in view, as shown in the following code.  

[!code-csharp[Add-in implementation](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/WPFAddIn1/AddInUI.xaml.cs#AddInCodeBehind)]
[!code-vb[Add-in implementation](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/WPFAddIn1/AddInUI.xaml.vb#AddInCodeBehind)]

From this example, you can see one interesting benefit of this model: add-in developers only need to implement the add-in (since it is the UI as well), rather than both an add-in class and an add-in UI.  
  
<a name="HostApp"></a>
## Implementing the Host Application

With the host-side adapter and host view created, the host application can use the .NET Framework add-in model to open the pipeline and acquire a host view of the add-in. These steps are shown in the following code.  

[!code-csharp[Acquiring a host view of the add-in](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleAddInIsAUISample/CSharp/Host/MainWindow.xaml.cs#GetUICode)]
[!code-vb[Acquiring a host view of the add-in](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleAddInIsAUISample/VisualBasic/Host/MainWindow.xaml.vb#GetUICode)]

The host application uses typical .NET Framework add-in model code to activate the add-in, which implicitly returns the host view to the host application. The host application subsequently displays the host view (which is a <xref:System.Windows.Controls.UserControl>) from a <xref:System.Windows.Controls.Grid>.  
  
 The code for processing interactions with the add-in UI runs in the add-in's application domain. These interactions include the following:  
  
- Handling the <xref:System.Windows.Controls.Button><xref:System.Windows.Controls.Primitives.ButtonBase.Click> event.  
  
- Showing the <xref:System.Windows.MessageBox>.  
  
 This activity is completely isolated from the host application.  
  
## See also

- [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100))
- [WPF Add-Ins Overview](wpf-add-ins-overview.md)
