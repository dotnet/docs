---
title: "Configuring Your Application"
ms.date: "03/30/2017"
ms.assetid: a2f995b0-669d-4721-b00f-4561ec7eb6a4
---
# Configuring Your Application
Windows Communication Foundation (WCF) uses the .NET configuration system and allows you to configure services at both the machine and application scope.  
  
 Configuration settings defined by WCF are located in the `<system.serviceModel>` section group. For more information about how to configure a WCF service, see the following topics:  
  
-   [Configuring Services](../../../../docs/framework/wcf/configuring-services.md)  
  
-   [\<system.serviceModel>](../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md)  
  
 Application-defined configurations settings are defined in the `<appSettings>` section group. For more information about application settings in .NET configuration files, see [\<appSettings>](https://go.microsoft.com/fwlink/?LinkId=95159).  
  
## Using the Configuration Editor  
 The WCF [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md) allows administrators and developers to create and modify configuration settings for WCF services using a graphical user interface. With this tool, you can manage settings for WCF bindings, behaviors, services, and diagnostics without directly editing XML configuration files.  
  
## Editing Configuration Files in Visual Studio  
 To edit the configuration file of a WCF service project in Visual Studio, right click it in **Solution Explorer** and choose the **Edit WCF Config** context menu item. This launches the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md).  
  
> [!NOTE]
>  If you edit the configuration file of a WCF Web Service project in Visual Studio by right-clicking it in **Solution Explorer**, notice that the **Edit WCF Config** context menu item is missing. To workaround this issue, click the **Tools** menu, and choose **WCF Service Config Editor**. After that, you can right-click a configuration file and use the **Edit WCF Config** context menu item.  
  
## See also
 [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md)  
 [Configuring Services](../../../../docs/framework/wcf/configuring-services.md)  
 [\<system.serviceModel>](../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md)
