---
title: "Windows Communication Foundation Tools"
description: Learn about the WCF tools that are designed to make it easier for you to create, deploy, and manage WCF applications. Run these tools from a command prompt.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WCF, tools"
  - "Windows Communication Foundation, tools"
ms.topic: reference
---
# Windows Communication Foundation Tools

Microsoft Windows Communication Foundation (WCF) tools are designed to make it easier for you to create, deploy, and manage WCF applications. This section contains detailed information about the tools. Please note that the tools are not supported.  
  
 You can run all the tools from the command line.  
  
 The following table lists these tools and provides a brief description.  
  
|Tool|Description|  
|----------|-----------------|  
|[ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md)|Generates service model code from metadata documents and metadata documents from service model code.|  
|[Find Private Key Tool (FindPrivateKey.exe)](find-private-key-tool-findprivatekey-exe.md)|Retrieves the private key from a specified store.|  
|[ServiceModel Registration Tool (ServiceModelReg.exe)](servicemodelreg-exe.md)|Manages the registration and un-registration of ServiceModel on a single machine.|  
|[COM+ Service Model Configuration Tool (ComSvcConfig.exe)](com-service-model-configuration-tool-comsvcconfig-exe.md)|Configures COM+ interfaces to be exposed as Web services.|  
|[Configuration Editor Tool (SvcConfigEditor.exe)](configuration-editor-tool-svcconfigeditor-exe.md)|Creates and modifies configuration settings for WCF services.|  
|[Service Trace Viewer Tool (SvcTraceViewer.exe)](service-trace-viewer-tool-svctraceviewer-exe.md)|Helps you view, group, and filter trace messages so that you can diagnose, repair, and verify issues with WCF services.|  
|[WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](ws-atomictransaction-configuration-utility-wsatconfig-exe.md)|Configures basic WS-AtomicTransaction support settings using a command line tool.|  
|[WS-AtomicTransaction Configuration MMC Snap-in](ws-atomictransaction-configuration-mmc-snap-in.md)|Configures basic WS-AtomicTransaction support settings using a MMC snap-in.|  
|[WorkFlow Service Registration Tool (WFServicesReg.exe)](workflow-service-registration-tool-wfservicesreg-exe.md)|Registers a Windows Workflow service.|  
|[WCF Service Host (WcfSvcHost.exe)](wcf-service-host-wcfsvchost-exe.md)|Hosts WCF services contained in libraries (*.dll) files|  
|[WCF Test Client (WcfTestClient.exe)](wcf-test-client-wcftestclient-exe.md)|A GUI tool that allows you to input parameters of arbitrary types, submit that input to the service, and view the response the service sends back.|  
|[Contract-First Tool](contract-first-tool.md)|A Visual Studio build task that creates code classes from XSD data contracts.|  
  
 All the preceding tools except ServiceModelReg.exe, WsatConfig.exe and ComSvcConfig.exe ship with the Windows SDK, and can be found under the C:\Program Files\Microsoft SDKs\Windows\v6.0\Bin folder.  The specific 3 tools can be found under C:\Windows\Microsoft.NET\Framework\v3.0\Windows Communication Foundation.
