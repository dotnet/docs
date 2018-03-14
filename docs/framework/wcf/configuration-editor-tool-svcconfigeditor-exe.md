---
title: "Configuration Editor Tool (SvcConfigEditor.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "configuration files, creating"
  - "configuration files"
  - "Configuration file"
  - "configuration file schema"
ms.assetid: 2db21a57-5f64-426f-89df-fb0dc2d2def5
caps.latest.revision: 45
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuration Editor Tool (SvcConfigEditor.exe)
The [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] Service Configuration Editor (SvcConfigEditor.exe) allows administrators and developers to create and modify configuration settings for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services using a graphical user interface. With this tool, you can manage settings for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] bindings, behaviors, services, and diagnostics without having to directly edit XML configuration files.  
  
 Service Configuration Editor can be found in the C:\Program Files\Microsoft SDKs\Windows\v6.0\Bin folder.  
  
## The WCF Configuration Editor  
 Service Configuration Editor comes with a wizard that guides you through all the steps in configuring a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service or client. You are strongly advised to use the wizard instead of the editor directly.  
  
 If you already have some configuration files that comply with the standard System.Configuration schema, you can manage specific settings for bindings, behavior, services, and diagnostics with the user interface. The Service Configuration Editor enables you to manage the settings for existing [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration files as well as executable files, COM+ services, and Web-hosted services. When opening a Web-hosted service with Service Configuration Editor, both the service’s own configuration and inherited configurations sections of upper level nodes are shown.  
  
 Because [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration settings are located in the `<system.serviceModel>` section of the configuration file, the editor operates exclusively on the content of this element and does not access other elements in the same file. You can navigate to existing configuration files directly or you can select an assembly that contains a service, virtual directory, or COM+ service. The editor loads the configuration file for that particular service and allows the user to either add new elements or edit existing elements nested in the `<system.serviceModel>` section of the configuration file.  
  
 The editor supports IntelliSense and enforces schema compliance. The resulting output is guaranteed to comply with the schema of the configuration file and to have syntactically correct data values. However, the editor does not guarantee that the configuration file is semantically valid. In other words, the editor does not guarantee that the configuration file can work with the service it configures.  
  
> [!CAUTION]
>  The editor cannot purge a configuration element from the configuration file once you have modified the element. For example, if you use the editor to set the endpoint name to a non-empty string and save it, the configuration file has the following content, as shown in the following example.  
>   
>  `<endpoint binding="basicHttpBinding" name="somename" />`  
>   
>  If you attempt to remove the name by setting it to an empty string and save the file, the configuration file still contains the `name` attribute, as shown in the following example.  
>   
>  `<endpoint binding="basicHttpBinding" name="" />`  
>   
>  To purge the attribute, you must manually edit the element using another text editor.  
>   
>  You should be especially careful with this issue when you use the `issueToken` element of the `clientCredential` Endpoint behavior. Specifically, the `address` attribute of its `localIssuer` sub-element must not be an empty string. If you have modified the `address` attribute using the Configuration Editor and want to remove it completely, you should do so using a tool other than the Editor. Otherwise, the attribute contains an empty string and your application throws an exception.  
  
## Using the Configuration Editor  
 The Service Configuration Editor can be found at the following Windows SDK installation location:  
  
 C:\Program Files\Microsoft SDKs\Windows\v6.0\Bin\SvcConfigEditor.exe  
  
 After you launch the Service Configuration Editor, you can use the **File/Open** menu to browse for the service or assembly you want to manage. You can open configuration files directly, browse for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] /COM+ services, and open configuration files for Web-hosted services.  
  
 The Service Configuration Editor's user interface is divided into the following areas:  
  
-   Tree View Pane, which displays configuration elements in a tree structure on the left. You can perform operations in the tree by right-clicking the nodes.  
  
-   Task Pane, which displays common tasks for current elements on the lower-left of the window  
  
-   Detail Pane, which displays detailed settings of the configuration node selected in the Tree View on the right.  
  
### Opening a Configuration File  
  
1.  Start Service Configuration Editor by using a command window to navigate to your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] installation location, and then type `SvcConfigEditor.exe`.  
  
2.  From the **File** menu, select **Open** and click the type of file you want to manage.  
  
3.  In the **Open** dialog box, navigate to the specific file you want to manage and double-click it.  
  
 The viewer automatically follows the configuration merge path and creates a view of the merged configuration. For example, the actual configuration of a non-hosted service is a combination of Machine.config and App.config. Any changes are applied to the active file in the SvcConfigEditor. If you want to edit a specific file in the configuration merge path, you should open it directly.  
  
> [!NOTE]
>  Configuration Editor reloads the currently opened configuration file when the latter has been modified outside the Editor. When this happens, all the changes that are not durably saved inside the Editor are lost. If reloading happens consistently, the most likely cause is a service that constantly accesses the configuration file, for example, an antivirus software running in the background. To resolve this, ensure that Configuration Editor is the only process that can access the file when it is opened.  
  
### Services  
 The **Services** node displays all of the services currently assigned in the configuration file. Each sub-node in the tree corresponds to a sub-element of the <`services`> element in the configuration file.  
  
 When you click the **Services** node, you can view or perform tasks on the service Summary Page in the **Detail** Pane.  
  
#### Creating a new Service Configuration  
 You can create a new service configuration in the following ways:  
  
-   Using a Wizard: Click the link **Create a New Service…** on the Task Pane or Summary Page to launch the wizard. You can also do so in the **File** menu -> **Add New Item**.  
  
-   Create manually: You can right-click the **Services** node and choose **New Service**.  
  
#### Creating a new Service Endpoint Configuration  
 You can create a new service endpoint configuration in the following ways:  
  
-   Create using a Wizard: click the link **Create a New Service Endpoint…** on the Task Pane or Summary Page to launch the wizard. You can also do so in the **File** menu -> **Add New Item**.  
  
-   Create manually: Once you created a Service, you can right-click the **Endpoints** node and choose "**New Service Endpoint**".  
  
#### Editing a Service Configuration  
  
1.  Click a **Service** node.  
  
2.  Edit the settings in the property grids.  
  
#### Editing a Service Endpoint Configuration  
  
1.  Click a **Service Endpoint** node.  
  
2.  Edit the settings in the property grids.  
  
#### Adding a Base Address  
  
1.  Click the **Host** node.  
  
2.  Click the **New…** button in the **Base Addresses** section.  
  
3.  Type in the base address URI in the dialog box.  
  
4.  Click **OK**.  
  
> [!NOTE]
>  You cannot edit the value of [\<baseAddressPrefixFilters>](../../../docs/framework/configure-apps/file-schema/wcf/baseaddressprefixfilters.md) inside this tool. To add or modify this element, you should use a text editor or [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
### Client  
 The **Client** node displays all of the client endpoints in the configuration file. Every sub-node in the tree corresponds to a sub-element of the <`client`> element in the configuration file.  
  
 When you click the **Client** node, you can view or perform tasks on the client **Summary Page** in the **Detail Pane**.  
  
#### Creating a new Client Endpoint Configuration  
 You can create a new client endpoint configuration in the following ways:  
  
-   Create by Wizard: Click the link **Create a New Client…** on the **Task Pane** on the lower-left of the window, or **Summary Page** to launch the wizard. You can also do so in the **File** menu -> **Add New Item**. The wizard prompts you to point to the location of the service configuration, from which the client configuration is generated. You can then choose the service endpoint to connect to.  
  
-   Create manually: Right-click the **Endpoints** node under **Client**, and choose **New Client Endpoint**.  
  
#### Editing a Client Endpoint Configuration  
  
1.  Click a **Client Endpoint** node.  
  
2.  Edit the settings in the property grids.  
  
### Standard Endpoint  
 Standard endpoints are specialized endpoints that have one or more aspects of the address, contract and binding set to default values.  
  
 Such configuration settings are stored in the **Standard Endpoint** node. The **Standard Endpoint** node displays all of the standard endpoint settings in the configuration file. Every sub-node in the tree corresponds to a sub-element in the `<standardEndpoints>` element in the configuration file.  
  
 When you click the **Standard Endpoint** node, you can view or perform tasks on the standard endpoint **Summary Page** in the **Detail Pane**.  
  
#### Creating a New Standard Endpoint Configuration  
 You can create a new standard endpoint configuration in the following ways:  
  
-   Right-click the **Standard Endpoint** node and select **New Standard Endpoint Configuration…** Select the binding type in the dialog box and click **OK**.  
  
-   Select the **Standard Endpoint** node and click **New Standard Endpoint Configuration…** in the **Task Pane** on the lower-left of the window.  
  
 The **Creating a New Standard Endpoint** dialog box displays and lists all registered standard endpoint types.  
  
#### Viewing and Editing a Standard Endpoint Configuration  
 You can open a standard endpoint configuration for viewing and editing in the following ways:  
  
-   Click to expand the **Standard Endpoint** node and click the respective endpoint sub-node.  
  
-   Click the **Standard Endpoint** node and click the respective endpoint on the Detail pane.  
  
 Attributes for the endpoint are shown in the right pane for editing.  
  
#### Deleting a Standard Endpoint Configuration  
 You can delete a standard endpoint configuration in the following ways:  
  
-   Click to expand the **Standard Endpoint** node and right-click the respective endpoint sub-node. Use the context command **Delete Standard Endpoint Configuration** to delete the endpoint.  
  
-   Click the **Standard Endpoint** node. In the **Task** pane, click **Delete Standard Endpoint Configuration**.  
  
 If the standard endpoint is in used, a warning message is displayed when you attempt to delete it: **The standard endpoint is in use. If you delete it now, please be sure to delete all of its references in other parts of the configuration (for example, in the service endpoint or client endpoint). Otherwise, the configuration will be invalid and cannot be opened next time. Are you sure you want to delete the standard endpoint?"**  
  
### Binding  
 Binding configurations are used to configure bindings on endpoints. Such configuration settings are stored in the **Binding** node. Endpoints reference binding configurations by name and multiple endpoints can reference a single binding configuration.  
  
 The **Bindings** node displays all of the binding settings in the configuration file. Every sub-node in the tree corresponds to a sub-element in the <`bindings`> element in the configuration file.  
  
 When you click the **Bindings** node, you can view or perform tasks on the binding **Summary Page** in the **Detail Pane**.  
  
#### Creating a New Binding Configuration  
 You can create a new binding configuration in the following ways.  
  
-   Right-click the **Bindings** node and select **New Binding Configuration**… Select the binding type in the dialog box and click **OK**.  
  
-   Select the **Bindings** node and click **New Binding Configuration**… in the **Task Pane** on the lower-left of the window.  
  
-   In the service or client summary page, click **Click to Create** in the **Binding Configuration** field to create a binding configuration for the corresponding endpoint.  
  
#### Adding Binding Element Extensions to a Custom Binding  
  
1.  Select the binding you want to add an extension element to.  
  
2.  Click **Add**.  
  
3.  From the list of available extensions, select the binding element extension you want to add. To select multiple items, press the CTRL key simultaneously.  
  
4.  Click **Add**.  
  
#### Adjusting the Extension Position in a Custom Binding  
 A custom binding is a collection of binding elements that form a stack. Each binding element on the stack has its own configuration settings. The order of the binding element extensions in a custom binding indicates their positions in the stack. Elements at the top of the stack are applied first. To change the ordering:  
  
1.  Select the custom binding node.  
  
2.  Select one binding extension element in the **Binding Element Extension Position** section.  
  
3.  Use the **Up** or **Down** button on the left side of the list to change the position of the selected element.  
  
#### Editing the Configuration of Binding Element Extensions in a Custom Binding  
  
1.  Select the binding node in the tree.  
  
2.  Select the custom binding that contains the element you want to edit.  
  
3.  Select the binding element extension you want to edit. The settings of the element appear in the right pane, where they can be edited.  
  
### Diagnostics  
 The **Diagnostics** node displays all of the diagnostic settings in the configuration file. It enables you to turn performance counters on or off, enable or disable Windows Management Instrumentation (WMI), configure [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] tracing, and configure [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] message logging. The settings in the **Diagnostics** node correspond to the <`system.diagnostics`> section, and `<diagnostics>` section in `<system.serviceModel>` in the configuration file.  
  
 When you click the **Diagnostics** node, you can view or perform tasks on the diagnostics **Summary Page** in the **Detail Pane**.  
  
#### Configuring performance counters and WMI  
  
1.  Click the **Diagnostics** node.  
  
2.  Click **Toggle Performance Counters**. The performance counter has three states: Off (default), ServiceOnly, and All. Clicking the link toggles the setting among these three states.  
  
#### Configuring WMI Provider  
  
1.  Click the **Diagnostics** node.  
  
2.  To enable WMI provider, click the **Enable WMI Provider** link.  
  
#### Enabling WCF Tracing  
 You can create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] trace file with standard properties or set up a custom trace file.  
  
1.  Click the **Diagnostics** node.  
  
2.  Click **Enable Tracing**.  
  
3.  Click the **Trace Level** link to adjust the trace level. There are six trace levels: Off, Critical, Error, Warning, Information, and Verbose. The **Activity Tracing** and **Propagate Activity** option enable you to use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] activity tracing feature.  
  
4.  Click the trace listener name to specify the trace file and options.  
  
#### Enabling WCF Logging  
 You can create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] trace file with standard properties or set up a custom trace file.  
  
1.  Click the **Diagnostics** node.  
  
2.  Click **Enable Message Logging**.  
  
3.  Click the **Log Level** link to adjust the log level. There are three log levels: Malformed, Service, and Transport.  
  
4.  Click the listener name to specify the log file and options.  
  
> [!NOTE]
>  If you want the trace and message logs to be flushed automatically when your application is closed, enable the **Auto Flush** option.  
  
 The **Diagnostics** **Summary Page** enables you to accomplish the most common tasks in configuring diagnostics. However, if you want to manually edit the Listeners and Sources settings, you must expand the **Diagnostics** node and edit settings in **Message Logging**, **Listeners** and **Sources** node.  
  
#### Enabling WCF Custom Tracing or Message Logging  
  
1.  Click the **Diagnostics** node, and expand it.  
  
2.  Right-click the **Listeners** node and select **New Listener**.  
  
3.  Type in the trace file name in the **InitData** field. You can click the "…" button to browse to a path.  
  
4.  Clicking the **TypeName** line displays a "…" button. Click this button to open the **Trace Listener Type Browser**, which you can use to find pre-configured trace listeners that are already installed.  
  
5.  Note the **Source** section. Click **Add** in this section to open a dialog box with a drop-down menu, which lists available tracing sources. Select a tracing source and click **OK**.  
  
6.  To edit Message Logging settings, click the **Message Logging** node. You can edit the settings in the property grid.  
  
### Advanced  
  
#### Behaviors  
 The **Behaviors** node displays the behaviors that are currently defined in the configuration file.  
  
 Behavior configurations are used to configure behaviors of endpoints and services. Such configuration settings are stored in the **Advanced** node under **Service Behaviors** and **Endpoint Behaviors**. Service behaviors are used by services; whereas endpoint behaviors by endpoints.  
  
 Behaviors are a collection of extension elements that for a stack. The element at the top of the stack is applied first. Each extension element can have its own configuration.  
  
##### Creating a new Behavior Configuration  
 You can create a new behavior configuration in two ways.  
  
-   Right-click one of the behavior nodes and select "**New Behavior Configuration…**  
  
-   Select one of the behavior nodes and click the **New Behavior Configuration**… in the **Task Pane** on the lower-left of the window.  
  
##### Adding Behavior Element Extensions to a Behavior  
  
1.  Select one of the behavior nodes.  
  
2.  Select the behavior you want edit.  
  
3.  Click **Add**.  
  
4.  From the list of available extensions, select the behavior element extension you want to add.  
  
5.  Click **Add**.  
  
##### Adjusting the Extension Position in a Behavior  
 Behaviors are collections of elements that form a stack. Each element on the stack has its own configuration. The order of the behavior element extensions in a behavior indicates their positions in the stack. Elements at the top of the stack are applied first. To change the ordering:  
  
1.  Select one of the behavior nodes.  
  
2.  Select the behavior you want edit.  
  
3.  Select a behavior extension element in the **Behavior Element Extension Position** section.  
  
4.  Use the **Up** or **Down** button on the left side of the list to change the position of the selected element.  
  
##### Editing the Configuration of Behavior Element Extensions  
  
1.  Select one of the behavior nodes in the tree.  
  
2.  Select the behavior that contains the element you want to edit.  
  
3.  Select the behavior element extension you want to edit. The settings of the element appear in the right pane where they can be edited.  
  
#### ProtocolMapping  
 This section allows you to set default binding types for different protocols such as http, tcp, MSMQ or net.pipe through defined mapping between protocol address schemes and the possible bindings. You can also add new mappings to other protocols.  
  
#### Extensions  
 New binding extensions, binding element extensions, standard endpoint extensions and behavior extensions can be registered for use in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration. Extensions are name/type pairs. The name defines the name of the extension in configuration, whereas the type implements the extension. There are four types of extensions:  
  
-   Binding extensions define an entire binding type. Example: `basicHttpBinding`.  
  
-   Binding element extensions define an element of a binding. Example: `textMessageEncoding`.  
  
-   Standard endpoint extensions define an entire standard endpoint. Example: `discoveryEndpoint`.  
  
-   Behavior element extensions define an element of a behavior. Example: `clientVia`.  
  
 Extensions that have been registered in configuration can be used like any other [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] component of the same type.  
  
##### Adding a new extension  
 Select one of the extension nodes in the advanced nodes:  
  
1.  Click **New**.  
  
2.  Enter a name and type.  
  
3.  Click **OK**.  
  
4.  The extension now appears in the appropriate place in the Editor. For example, if you add a behavior element extension, it appears in the list of available extensions.  
  
#### Hosting Environment  
 This section allows you to define instantiation settings for the service hosting environment.  
  
### Creating a Configuration File Using the Wizard  
 One way to create a new configuration file is to use the New Service Element Wizard. The wizard finds the installed service types and other elements compatible with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] on the computer, including COM+ and Web-hosted virtual directories, and loads them to make creating the configuration much more streamlined.  
  
#### Creating a Configuration File  
  
1.  Start Service Configuration Editor by using a command window to navigate to your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] installation location, and then type `SvcConfigEditor.exe`.  
  
2.  From the **File** menu, select **Open** and click **Executable**, **COM+ Service**, or **WebHosted Service**, depending on the type of configuration file you want to create.  
  
3.  In the **Open** dialog box, navigate to the specific file you want to create a configuration file for and double-click it.  
  
4.  In the **File** menu, point to **Add New Item** and click **Service**. The New Service Element Wizard opens.  
  
5.  Follow the steps in the wizard to create the new service.  
  
> [!NOTE]
>  If you want to use the NetPeerTcpBinding from the configuration file generated by the Wizard, you have to manually add a binding configuration element and modify the `mode` attribute of its `security` element to "None".  
  
## Configuring COM+  
 The Service Configuration Editor enables you to create a new configuration file for an existing COM+ application, or edit an existing COM+ configuration. The **COM Contract** node is only visible when the <`comContract`> section exists in the configuration file.  
  
### Creating a New COM+ Configuration  
 Before creating a new COM+ configuration, make sure that your COM+ application is installed in Component Services, and registered in the Global Assembly Cache (GAC).  
  
1.  Select **File** menu -> **Integrate** -> **COM+ Application.** This operation closes the current opened file. If there is unsaved data in the current file, a Save dialog appears. The **COM+ Integration Wizard** is then launched.  
  
2.  In the first page, select the COM+ application from the tree. If you cannot find your COM+ application in the tree, verify that it is installed in the Component Services and registered in the Global Assembly Cache (GAC).  
  
3.  In the next page, select which method(s) you want to expose as [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services. All the supported methods in the COM+ application are displayed and selected by default.  
  
4.  Choose a hosting method.  
  
5.  Configure other settings according to the guides in the wizard.  
  
6.  Service Configuration Editor utilizes ComSvcConfig.exe in the background to generate configuration file. After this is completed, you can view a summary and exit the wizard. The generated configuration file is opened so that you can edit it directly.  
  
### Editing an Existing COM+ Configuration  
  
1.  Select **File** menu -> **Open** -> **COM+ Service**…  
  
2.  Select the COM+ Service you want to edit from the list.  
  
3.  Edit configuration settings in the **COM Contracts** node.  
  
    > [!NOTE]
    >  You can also directly open and edit a configuration file that contains COM contracts.  
  
## Security  
 A service configuration file generated by the Configuration Editor is not guaranteed to be secure. Please refer to the [Security](../../../docs/framework/wcf/feature-details/security.md) documentation to find out how to secure your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services.  
  
 In addition, the Configuration Editor can only be used to read and write valid [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration elements. The tool ignores schema-compliant, user-defined elements. It also does not attempt remove these elements from the configuration file or determine their effects on the known [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] elements. It is the user’s responsibility to determine whether these elements pose a threat to the application or the system.
