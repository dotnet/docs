---
title: "Hosting Workflow Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2d55217e-8697-4113-94ce-10b60863342e
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting Workflow Services
A workflow service must be hosted for it to respond to incoming messages. Workflow services use the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] messaging infrastructure and are therefore hosted in similar ways. Like [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services, workflow services can be hosted in any managed application, under Internet Information Services (IIS), or under Windows Process Activation Services (WAS). In addition workflow services can be hosted under Windows Server App Fabric. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] Windows Server App Fabric see [Windows Server App Fabric documentation](http://go.microsoft.com/fwlink/?LinkId=193037), [AppFabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=196494), and [AppFabric Hosting Concepts](http://go.microsoft.com/fwlink/?LinkId=196495). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the various ways to host [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services see [Hosting Services](../../../../docs/framework/wcf/hosting-services.md).  
  
## Hosting in a managed application  
 To host a workflow service in a managed application, use the <xref:System.ServiceModel.Activities.WorkflowServiceHost> class. The <xref:System.ServiceModel.Activities.WorkflowServiceHost> constructor allows you to specify a singleton workflow service instance, a workflow service definition, or an activity that uses the workflow messaging activities. Calling <<!--zz xref:System.ServiceModel.Activities.WorkflowServiceHost.Open%2A--> `System.ServiceModel.Activities.WorkflowServiceHost.Open`> causes the service to start listening for incoming messages.  
  
## Hosting under IIS or WAS  
 Hosting a workflow service under IIS or WAS involves creating a virtual directory and placing files in the virtual directory that define the service and its behavior. When hosting a workflow service under IIS or WAS there are several possibilities:  
  
-   Place a .xamlx file that defines the workflow service in an IIS/WAS virtual directory along with a Web.config file that specifies the service behaviors, endpoints, and other configuration elements.  
  
-   Place a .xamlx file that defines the workflow service in an IIS/WAS virtual directory. The .xamlx file specifies the endpoints to expose. Endpoints are specified in a `WorkflowService.Endpoints` element as shown in the following example.  
  
    ```xml  
    <WorkflowService xmlns="http://schemas.microsoft.com/netfx/2009/xaml/servicemodel"  xmlns:p1="http://schemas.microsoft.com/netfx/2009/xaml/activities" xmlns:sad="clr-namespace:System.Activities.Debugger;assembly=System.Activities" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">  
      <WorkflowService.Endpoints>  
        <Endpoint ServiceContractName="IWorkFlowEchoService" AddressUri="">  
          <Endpoint.Binding>  
            <BasicHttpBinding />  
          </Endpoint.Binding>  
        </Endpoint>  
      </WorkflowService.Endpoints>  
    <!-- ... -->  
    </WorkflowService>  
    ```  
  
    > [!NOTE]
    >  Behaviors cannot be specified in a .xamlx file, so you must use a Web.config if you need to specify behavior settings.  
  
-   Place a .xamlx file that defines the workflow service in an IIS/WAS virtual directory. In addition, place a .svc file in the virtual directory. The .svc file allows you to specify a custom Web service host factory, apply custom behavior, or load configuration from a custom location.  
  
-   Place an assembly in the IIS/WAS virtual directory that contains an activity that uses the WCF messaging activities.  
  
 A .xamlx file that defines a workflow service must contain a <`Service`> root element or a root element that contains any type derived from <xref:System.Workflow.ComponentModel.Activity>. When using the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Activity template a .xamlx file is created. When using the WCF Workflow Service template a .xamlx file is created.  
  
## Hosting Workflow Services under Windows Server App Fabric  
 Hosting a workflow service under Windows Server App Fabric is done in the same way as hosting under IIS/WAS. The only difference is the fact that Windows Server App Fabric is installed. Windows Server App Fabric provides tools that are added to Internet Information Services Manager, as well as powershell commandlets. These tools simplify deploying, managing, and tracking of workflow services and WCF services. . [!INCLUDE[crabout](../../../../includes/crabout-md.md)] Windows Server App Fabric see [Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkId=193037)  
  
## Referencing Custom Activities  
 References to custom activities must be added to the <`Assemblies`> section under <`System.Web.Compilation`> so that they are loaded into the Application Domain and the XAML deserializer is able to locate the types. These settings can be made at the application level or in the root Web.config if the settings should be applied to all applications on the machine.  
  
## Deployment  
 The Web Deployment tool has been created to make the job of deployment easier. The tool allows you to migrate applications between IIS 6.0 and IIS 7.0, synchronize server farms, and package, archive and deploy Web applications. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [MS Deployment Tool](http://go.microsoft.com/fwlink/?LinkId=178690)  
  
## See Also  
 [Workflow Service Host Internals](../../../../docs/framework/wcf/feature-details/workflow-service-host-internals.md)  
 [Configuring WorkflowServiceHost](../../../../docs/framework/wcf/feature-details/configuring-workflowservicehost.md)
