---
title: "WPF Add-Ins Overview"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "add-ins and XAML browser applications [WPF]"
  - "add-ins overview [WPF]"
  - "add-ins [WPF], performance"
  - "add-ins [WPF], benefits"
  - ".NET Framework add-in model [WPF]"
  - "add-ins [WPF], user interface"
  - "add-ins and the user interface [WPF]"
  - "add-ins [WPF], architecture"
  - "add-ins [WPF], limitations"
ms.assetid: 00b4c776-29a8-4dba-b603-280a0cdc2ade
---
# WPF Add-Ins Overview

<a name="Introduction"></a> The .NET Framework includes an add-in model that developers can use to create applications that support add-in extensibility. This add-in model allows the creation of add-ins that integrate with and extend application functionality. In some scenarios, applications also need to display user interfaces that are provided by add-ins. This topic shows how WPF augments the .NET Framework add-in model to enable these scenarios, the architecture behind it, its benefits, and its limitations.

<a name="Requirements"></a>

## Prerequisites

Familiarity with the .NET Framework add-in model is required. For more information, see [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100)).

<a name="AddInsOverview"></a>

## Add-Ins Overview

In order to avoid the complexities of application recompilation and redeployment to incorporate new functionality, applications implement extensibility mechanisms that allow developers (both first-party and third-party) to create other applications that integrate with them. The most common way to support this type of extensibility is through the use of add-ins (also known as "add-ons" and "plug-ins"). Examples of real-world applications that expose extensibility with add-ins include:

- Internet Explorer add-ons.

- Windows Media Player plug-ins.

- Visual Studio add-ins.

For example, the Windows Media Player add-in model allows third-party developers to implement "plug-ins" that extend Windows Media Player in a variety of ways, including creating decoders and encoders for media formats that are not supported natively by Windows Media Player (for example, DVD, MP3), audio effects, and skins. Each add-in model is built to expose the functionality that is unique to an application, although there are several entities and behaviors that are common to all add-in models.

The three main entities of typical add-in extensibility solutions are *contracts*, *add-ins*, and *host applications*. Contracts define how add-ins integrate with host applications in two ways:

- Add-ins integrate with functionality that is implemented by host applications.

- Host applications expose functionality for add-ins to integrate with.

In order for add-ins to be used, host applications need to find them and load them at run time. Consequently, applications that support add-ins have the following additional responsibilities:

- **Discovery**: Finding add-ins that adhere to contracts supported by host applications.

- **Activation**: Loading, running, and establishing communication with add-ins.

- **Isolation**: Using either application domains or processes to establish isolation boundaries that protect applications from potential security and execution problems with add-ins.

- **Communication**: Allowing add-ins and host applications to communicate with each other across isolation boundaries by calling methods and passing data.

- **Lifetime Management**: Loading and unloading application domains and processes in a clean, predictable manner (see [Application Domains](../../app-domains/application-domains.md)).

- **Versioning**: Ensuring that host applications and add-ins can still communicate when new versions of either are created.

Ultimately, developing a robust add-in model is a non-trivial undertaking. For this reason, the .NET Framework provides an infrastructure for building add-in models.

> [!NOTE]
> For more detailed information on add-ins, see [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100)).

<a name="NETFrameworkAddInModelOverview"></a>

## .NET Framework Add-In Model Overview

The .NET Framework add-in model, found in the <xref:System.AddIn> namespace, contains a set of types that are designed to simplify the development of add-in extensibility. The fundamental unit of the .NET Framework add-in model is the *contract*, which defines how a host application and an add-in communicate with each other. A contract is exposed to a host application using a host-application-specific *view* of the contract. Likewise, an add-in-specific *view* of the contract is exposed to the add-in. An *adapter* is used to allow a host application and an add-in to communicate between their respective views of the contract. Contracts, views, and adapters are referred to as segments, and a set of related segments constitutes a *pipeline*. Pipelines are the foundation upon which the .NET Framework add-in model supports discovery, activation, security isolation, execution isolation (using both application domains and processes), communication, lifetime management, and versioning.

The sum of this support allows developers to build add-ins that integrate with the functionality of a host application. However, some scenarios require host applications to display user interfaces provided by add-ins. Because each presentation technology in the .NET Framework has its own model for implementing user interfaces, the .NET Framework add-in model does not support any particular presentation technology. Instead, WPF extends the .NET Framework add-in model with UI support for add-ins.

<a name="WPFAddInModel"></a>

## WPF Add-Ins

WPF, in conjunction with the .NET Framework add-in model, allows you to address a wide variety of scenarios that require host applications to display user interfaces from add-ins. In particular, these scenarios are addressed by WPF with the following two programming models:

1. **The add-in returns a UI**. An add-in returns a UI to the host application via a method call, as defined by the contract. This scenario is used in the following cases:

    - The appearance of a UI that is returned by an add-in is dependent on either data or conditions that exist only at run time, such as dynamically generated reports.

    - The UI for services provided by an add-in differs from the UI of the host applications that can use the add-in.

    - The add-in primarily performs a service for the host application, and reports status to the host application with a UI.

2. **The add-in is a UI**. An add-in is a UI, as defined by the contract. This scenario is used in the following cases:

    - An add-in doesn't provide services other than being displayed, such as an advertisement.

    - The UI for services provided by an add-in is common to all host applications that can use that add-in, such as a calculator or color picker.

These scenarios require that UI objects can be passed between host application and add-in application domains. Since the .NET Framework add-in model relies on remoting to communicate between application domains, the objects that are passed between them must be remotable.

A remotable object is an instance of a class that does one or more of the following:

- Derives from the <xref:System.MarshalByRefObject> class.

- Implements the <xref:System.Runtime.Serialization.ISerializable> interface.

- Has the <xref:System.SerializableAttribute> attribute applied.

> [!NOTE]
> For more information regarding the creation of remotable .NET Framework objects, see [Making Objects Remotable](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/wcf3swha(v=vs.100)).

The WPF UI types are not remotable. To solve the problem, WPF extends the .NET Framework add-in model to enable WPF UI created by add-ins to be displayed from host applications. This support is provided by WPF by two types: the <xref:System.AddIn.Contract.INativeHandleContract> interface and two static methods implemented by the <xref:System.AddIn.Pipeline.FrameworkElementAdapters> class: <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A> and <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A>. At a high level, these types and methods are used in the following manner:

1. WPF requires that user interfaces provided by add-ins are classes that derive directly or indirectly from <xref:System.Windows.FrameworkElement>, such as shapes, controls, user controls, layout panels, and pages.

2. Wherever the contract declares that a UI will be passed between the add-in and the host application, it must be declared as an <xref:System.AddIn.Contract.INativeHandleContract> (not a <xref:System.Windows.FrameworkElement>); <xref:System.AddIn.Contract.INativeHandleContract> is a remotable representation of the add-in UI that can be passed across isolation boundaries.

3. Before being passed from the add-in's application domain, a <xref:System.Windows.FrameworkElement> is packaged as an <xref:System.AddIn.Contract.INativeHandleContract> by calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A>.

4. After being passed to the host application's application domain, the <xref:System.AddIn.Contract.INativeHandleContract> must be repackaged as a <xref:System.Windows.FrameworkElement> by calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A>.

How <xref:System.AddIn.Contract.INativeHandleContract>, <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A>, and <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> are used depends on the specific scenario. The following sections provide details for each programming model.

<a name="ReturnUIFromAddInContract"></a>

## Add-In Returns a User Interface

For an add-in to return a UI to a host application, the following are required:

1. The host application, add-in, and pipeline must be created, as described by the .NET Framework [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100)) documentation.

2. The contract must implement <xref:System.AddIn.Contract.IContract> and, to return a UI, the contract must declare a method with a return value of type <xref:System.AddIn.Contract.INativeHandleContract>.

3. The UI that is passed between the add-in and the host application must directly or indirectly derive from <xref:System.Windows.FrameworkElement>.

4. The UI that is returned by the add-in must be converted from a <xref:System.Windows.FrameworkElement> to an <xref:System.AddIn.Contract.INativeHandleContract> before crossing the isolation boundary.

5. The UI that is returned must be converted from an <xref:System.AddIn.Contract.INativeHandleContract> to a <xref:System.Windows.FrameworkElement> after crossing the isolation boundary.

6. The host application displays the returned <xref:System.Windows.FrameworkElement>.

For an example that demonstrates how to implement an add-in that returns a UI, see [Create an Add-In That Returns a UI](how-to-create-an-add-in-that-returns-a-ui.md).

<a name="AddInIsAUI"></a>

## Add-In Is a User Interface

When an add-in is a UI, the following are required:

1. The host application, add-in, and pipeline must be created, as described by the .NET Framework [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100)) documentation.

2. The contract interface for the add-in must implement <xref:System.AddIn.Contract.INativeHandleContract>.

3. The add-in that is passed to the host application must directly or indirectly derive from <xref:System.Windows.FrameworkElement>.

4. The add-in must be converted from a <xref:System.Windows.FrameworkElement> to an <xref:System.AddIn.Contract.INativeHandleContract> before crossing the isolation boundary.

5. The add-in must be converted from an <xref:System.AddIn.Contract.INativeHandleContract> to a <xref:System.Windows.FrameworkElement> after crossing the isolation boundary.

6. The host application displays the returned <xref:System.Windows.FrameworkElement>.

For an example that demonstrates how to implement an add-in that is a UI, see [Create an Add-In That Is a UI](how-to-create-an-add-in-that-is-a-ui.md).

<a name="ReturningMultipleUIsFromAnAddIn"></a>

## Returning Multiple UIs from an Add-In

Add-ins often provide multiple user interfaces for host applications to display. For example, consider an add-in that is a UI that also provides status information to the host application, also as a UI. An add-in like this can be implemented by using a combination of techniques from both the [Add-In Returns a User Interface](#ReturnUIFromAddInContract) and [Add-In Is a User Interface](#AddInIsAUI) models.

<a name="AddInsAndXBAPs"></a>

## Add-Ins and XAML Browser Applications

In the examples so far, the host application has been an installed standalone application. But XAML browser applications (XBAPs) can also host add-ins, albeit with the following additional build and implementation requirements:

- The XBAP application manifest must be configured specially to download the pipeline (folders and assemblies) and add-in assembly to the ClickOnce application cache on the client machine, in the same folder as the XBAP.

- The XBAP code to discover and load add-ins must use the ClickOnce application cache for the XBAP as the pipeline and add-in location.

- The XBAP must load the add-in into a special security context if the add-in references loose files that are located at the site of origin; when hosted by XBAPs, add-ins can only reference loose files that are located at the host application's site of origin.

These tasks are described in detail in the following subsections.

### Configuring the Pipeline and Add-In for ClickOnce Deployment

XBAPs are downloaded to and run from a safe folder in the ClickOnce deployment cache. In order for an XBAP to host an add-in, the pipeline and add-in assembly must also be downloaded to the safe folder. To achieve this, you need to configure the application manifest to include both the pipeline and add-in assembly for download. This is most easily done in Visual Studio, although the pipeline and add-in assembly needs to be in the host XBAP project's root folder in order for Visual Studio to detect the pipeline assemblies.

Consequently, the first step is to build the pipeline and add-in assembly to the XBAP project's root by setting the build output of each pipeline assembly and add-in assembly projects. The following table shows the build output paths for pipeline assembly projects and add-in assembly project that are in the same solution and root folder as the host XBAP project.

Table 1: Build Output Paths for the Pipeline Assemblies That Are Hosted by an XBAP

|Pipeline assembly project|Build output path|
|-------------------------------|-----------------------|
|Contract|`..\HostXBAP\Contracts\`|
|Add-In View|`..\HostXBAP\AddInViews\`|
|Add-In-Side Adapter|`..\HostXBAP\AddInSideAdapters\`|
|Host-Side Adapter|`..\HostXBAP\HostSideAdapters\`|
|Add-In|`..\HostXBAP\AddIns\WPFAddIn1`|

The next step is to specify the pipeline assemblies and add-in assembly as the XBAPs content files in Visual Studio by doing the following:

1. Including the pipeline and add-in assembly in the project by right-clicking each pipeline folder in Solution Explorer and choosing **Include In Project**.

2. Setting the **Build Action** of each pipeline assembly and add-in assembly to **Content** from the **Properties** window.

The final step is to configure the application manifest to include the pipeline assembly files and add-in assembly file for download. The files should be located in folders at the root of the folder in the ClickOnce cache that the XBAP application occupies. The configuration can be achieved in Visual Studio by doing the following:

1. Right-click the XBAP project, click **Properties**, click **Publish**, and then click the **Application Files** button.

2. In the **Application Files** dialog, set the **Publish Status** of each pipeline and add-in DLL to **Include (Auto)**, and set the **Download Group** for each pipeline and add-in DLL to **(Required)**.

### Using the Pipeline and Add-In from the Application Base

When the pipeline and add-in are configured for ClickOnce deployment, they are downloaded to the same ClickOnce cache folder as the XBAP. To use the pipeline and add-in from the XBAP, the XBAP code must get them from the application base. The various types and members of the .NET Framework add-in model for using pipelines and add-ins provide special support for this scenario. Firstly, the path is identified by the <xref:System.AddIn.Hosting.PipelineStoreLocation.ApplicationBase> enumeration value. You use this value with overloads of the pertinent add-in members for using pipelines that include the following:

- <xref:System.AddIn.Hosting.AddInStore.FindAddIns%28System.Type%2CSystem.AddIn.Hosting.PipelineStoreLocation%29?displayProperty=nameWithType>

- <xref:System.AddIn.Hosting.AddInStore.FindAddIns%28System.Type%2CSystem.AddIn.Hosting.PipelineStoreLocation%2CSystem.String%5B%5D%29?displayProperty=nameWithType>

- <xref:System.AddIn.Hosting.AddInStore.Rebuild%28System.AddIn.Hosting.PipelineStoreLocation%29?displayProperty=nameWithType>

- <xref:System.AddIn.Hosting.AddInStore.Update%28System.AddIn.Hosting.PipelineStoreLocation%29?displayProperty=nameWithType>

### Accessing the Host's Site of Origin

To ensure that an add-in can reference files from the site of origin, the add-in must be loaded with security isolation that is equivalent to the host application. This security level is identified by the <xref:System.AddIn.Hosting.AddInSecurityLevel.Host?displayProperty=nameWithType> enumeration value, and passed to the <xref:System.AddIn.Hosting.AddInToken.Activate%2A> method when an add-in is activated.

<a name="WPFAddInModelArchitecture"></a>

## WPF Add-In Architecture

At the highest level, as we've seen, WPF enables .NET Framework add-ins to implement user interfaces (that derive directly or indirectly from <xref:System.Windows.FrameworkElement>) using <xref:System.AddIn.Contract.INativeHandleContract>, <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> and <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A>. The result is that the host application is returned a <xref:System.Windows.FrameworkElement> that is displayed from UI in the host application.

For simple UI add-in scenarios, this is as much detail as a developer needs. For more complex scenarios, particularly those that try to utilize additional WPF services such as layout, resources, and data binding, more detailed knowledge of how WPF extends the .NET Framework add-in model with UI support is required to understand its benefits and limitations.

Fundamentally, WPF doesn't pass a UI from an add-in to a host application; instead, WPF passes the Win32 window handle for the UI by using WPF interoperability. As such, when a UI from an add-in is passed to a host application, the following occurs:

- On the add-in side, WPF acquires a window handle for the UI that will be displayed by the host application. The window handle is encapsulated by an internal WPF class that derives from <xref:System.Windows.Interop.HwndSource> and implements <xref:System.AddIn.Contract.INativeHandleContract>. An instance of this class is returned by <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> and is marshaled from the add-in's application domain to the host application's application domain.

- On the host application side, WPF repackages the <xref:System.Windows.Interop.HwndSource> as an internal WPF class that derives from <xref:System.Windows.Interop.HwndHost> and consumes <xref:System.AddIn.Contract.INativeHandleContract>. An instance of this class is returned by <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A> to the host application.

<xref:System.Windows.Interop.HwndHost> exists to display user interfaces, identified by window handles, from WPF user interfaces. For more information, see [WPF and Win32 Interoperation](../advanced/wpf-and-win32-interoperation.md).

In summary, <xref:System.AddIn.Contract.INativeHandleContract>, <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A>, and <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A> exist to allow the window handle for a WPF UI to be passed from an add-in to a host application, where it is encapsulated by a <xref:System.Windows.Interop.HwndHost> and displayed the host application's UI.

> [!NOTE]
> Because the host application gets an <xref:System.Windows.Interop.HwndHost>, the host application cannot convert the object that is returned by <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ContractToViewAdapter%2A> to the type it is implemented as by the add-in (for example, a <xref:System.Windows.Controls.UserControl>).

By its nature, <xref:System.Windows.Interop.HwndHost> has certain limitations that affect how host applications can use them. However, WPF extends <xref:System.Windows.Interop.HwndHost> with several capabilities for add-in scenarios. These benefits and limitations are described below.

<a name="WPFAddInModelBenefits"></a>

## WPF Add-In Benefits

Because WPF add-in user interfaces are displayed from host applications using an internal class that derives from <xref:System.Windows.Interop.HwndHost>, those user interfaces are constrained by the capabilities of <xref:System.Windows.Interop.HwndHost> with respect to WPF UI services such as layout, rendering, data binding, styles, templates, and resources. However, WPF augments its internal <xref:System.Windows.Interop.HwndHost> subclass with additional capabilities that include the following:

- Tabbing between a host application's UI and an add-in's UI. Note that the "add-in is a UI" programming model requires the add-in-side adapter to override <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> to enable tabbing, whether the add-in is fully trusted or partially trusted.

- Honoring accessibility requirements for add-in user interfaces that are displayed from host application user interfaces.

- Enabling WPF applications to run safely in multiple application domain scenarios.

- Preventing illegal access to add-in UI window handles when add-ins run with security isolation (that is, a partial-trust security sandbox). Calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> ensures this security:

  - For the "add-in returns a UI" programming model, the only way to pass the window handle for an add-in UI across the isolation boundary is to call <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A>.

  - For the "add-in is a UI" programming model, overriding <xref:System.AddIn.Pipeline.ContractBase.QueryContract%2A> on the add-in-side adapter and calling <xref:System.AddIn.Pipeline.FrameworkElementAdapters.ViewToContractAdapter%2A> (as shown in the preceding examples) is required, as is calling the add-in-side adapter's `QueryContract` implementation from the host-side adapter.

- Providing multiple application domain execution protection. Due to limitations with application domains, unhandled exceptions that are thrown in add-in application domains cause the entire application to crash, even though the isolation boundary exists. However, WPF and the .NET Framework add-in model provide a simple way to work around this problem and improve application stability. A WPF add-in that displays a UI creates a <xref:System.Windows.Threading.Dispatcher> for the thread that the application domain runs on, if the host application is a WPF application. You can detect all unhandled exceptions that occur in the application domain by handling the <xref:System.Windows.Threading.Dispatcher.UnhandledException> event of the WPF add-in's <xref:System.Windows.Threading.Dispatcher>. You can get the <xref:System.Windows.Threading.Dispatcher> from the <xref:System.Windows.Threading.Dispatcher.CurrentDispatcher%2A> property.

<a name="WPFAddInModelLimitations"></a>

## WPF Add-In Limitations

Beyond the benefits that WPF adds to the default behaviors supplied by <xref:System.Windows.Interop.HwndSource>, <xref:System.Windows.Interop.HwndHost>, and window handles, there are also limitations for add-in user interfaces that are displayed from host applications:

- Add-in user interfaces displayed from a host application do not respect the host application's clipping behavior.

- The concept of *airspace* in interoperability scenarios also applies to add-ins (see [Technology Regions Overview](../advanced/technology-regions-overview.md)).

- A host application's UI services, such as resource inheritance, data binding, and commanding, are not automatically available to add-in user interfaces. To provide these services to the add-in, you need to update the pipeline.

- An add-in UI cannot be rotated, scaled, skewed, or otherwise affected by a transformation (see [Transforms Overview](../graphics-multimedia/transforms-overview.md)).

- Content inside add-in user interfaces that is rendered by drawing operations from the <xref:System.Drawing> namespace can include alpha blending. However, both an add-in UI and the host application UI that contains it must be 100% opaque; in other words, the `Opacity` property on both must be set to 1.

- If the <xref:System.Windows.Window.AllowsTransparency%2A> property of a window in the host application that contains an add-in UI is set to `true`, the add-in is invisible. This is true even if the add-in UI is 100% opaque (that is, the `Opacity` property has a value of 1).

- An add-in UI must appear on top of other WPF elements in the same top-level window.

- No portion of an add-in's UI can be rendered using a <xref:System.Windows.Media.VisualBrush>. Instead, the add-in may take a snapshot of the generated UI to create a bitmap that can be passed to the host application using methods defined by the contract.

- Media files cannot be played from a <xref:System.Windows.Controls.MediaElement> in an add-in UI.

- Mouse events generated for the add-in UI are neither received nor raised by the host application, and the `IsMouseOver` property for host application UI has a value of `false`.

- When focus shifts between controls in an add-in UI, the `GotFocus` and `LostFocus` events are neither received nor raised by the host application.

- The portion of a host application that contains an add-in UI appears white when printed.

- All dispatchers (see <xref:System.Windows.Threading.Dispatcher>) created by the add-in UI must be shut down manually before the owner add-in is unloaded if the host application continues execution. The contract can implement methods that allow the host application to signal the add-in before the add-in is unloaded, thereby allowing the add-in UI to shut down its dispatchers.

- If an add-in UI is an <xref:System.Windows.Controls.InkCanvas> or contains an <xref:System.Windows.Controls.InkCanvas>, you cannot unload the add-in.

<a name="PerformanceOptimization"></a>

## Performance Optimization

By default, when multiple application domains are used, the various .NET Framework assemblies required by each application are all loaded into that application's domain. As a result, the time required for creating new application domains and starting applications in them might affect performance. However, the .NET Framework provides a way for you to reduce start times by instructing applications to share assemblies across application domains if they are already loaded. You do this by using the <xref:System.LoaderOptimizationAttribute> attribute, which must be applied to the entry point method (`Main`). In this case, you must use only code to implement your application definition (see [Application Management Overview](application-management-overview.md)).

## See also

- <xref:System.LoaderOptimizationAttribute>
- [Add-ins and Extensibility](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb384200(v%3dvs.100))
- [Application Domains](../../app-domains/application-domains.md)
- [.NET Framework Remoting Overview](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/kwdt6w2k(v=vs.100))
- [Making Objects Remotable](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/wcf3swha(v=vs.100))
- [How-to Topics](how-to-topics.md)
