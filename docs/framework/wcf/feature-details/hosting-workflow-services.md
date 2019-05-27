---
title: "Hosting Workflow Services"
ms.date: "03/30/2017"
ms.assetid: 2d55217e-8697-4113-94ce-10b60863342e
---
# Hosting Workflow Services
A workflow service must be hosted for it to respond to incoming messages. Workflow services use the WCF messaging infrastructure and are therefore hosted in similar ways. Like WCF services, workflow services can be hosted in any managed application, under Internet Information Services (IIS), or under Windows Process Activation Services (WAS). In addition, workflow services can be hosted under Windows Server App Fabric. For more information about Windows Server App Fabric see [Windows Server App Fabric documentation](https://go.microsoft.com/fwlink/?LinkId=193037), [AppFabric Hosting Features](https://go.microsoft.com/fwlink/?LinkId=196494), and [AppFabric Hosting Concepts](https://go.microsoft.com/fwlink/?LinkId=196495). For more information about the various ways to host WCF services see [Hosting Services](../../../../docs/framework/wcf/hosting-services.md).

## Hosting in a managed application
 To host a workflow service in a managed application, use the <xref:System.ServiceModel.Activities.WorkflowServiceHost> class. The <xref:System.ServiceModel.Activities.WorkflowServiceHost> constructor allows you to specify a singleton workflow service instance, a workflow service definition, or an activity that uses the workflow messaging activities. Calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> causes the service to start listening for incoming messages.

## Hosting under IIS or WAS
 Hosting a workflow service under IIS or WAS involves creating a virtual directory and placing files in the virtual directory that define the service and its behavior. When hosting a workflow service under IIS or WAS there are several possibilities:

- Place a .xamlx file that defines the workflow service in an IIS/WAS virtual directory along with a Web.config file that specifies the service behaviors, endpoints, and other configuration elements.

- Place a .xamlx file that defines the workflow service in an IIS/WAS virtual directory. The .xamlx file specifies the endpoints to expose. Endpoints are specified in a `WorkflowService.Endpoints` element as shown in the following example.

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
    > Behaviors cannot be specified in a .xamlx file, so you must use a Web.config if you need to specify behavior settings.

- Place a .xamlx file that defines the workflow service in an IIS/WAS virtual directory. In addition, place a .svc file in the virtual directory. The .svc file allows you to specify a custom Web service host factory, apply custom behavior, or load configuration from a custom location.

- Place an assembly in the IIS/WAS virtual directory that contains an activity that uses the WCF messaging activities.

 A .xamlx file that defines a workflow service must contain a <`Service`> root element or a root element that contains any type derived from <xref:System.Workflow.ComponentModel.Activity>. When using the Visual Studio activity template, a .xamlx file is created. When using the WCF Workflow Service template, a .xamlx file is created.

## Hosting Workflow Services under Windows Server App Fabric
 Hosting a workflow service under Windows Server App Fabric is done in the same way as hosting under IIS/WAS. The only difference is the fact that Windows Server App Fabric is installed. Windows Server App Fabric provides tools that are added to Internet Information Services Manager, as well as powershell commandlets. These tools simplify deploying, managing, and tracking of workflow services and WCF services.

## Referencing Custom Activities
 References to custom activities must be added to the <`Assemblies`> section under <`System.Web.Compilation`> so that they are loaded into the Application Domain and the XAML deserializer is able to locate the types. These settings can be made at the application level or in the root Web.config if the settings should be applied to all applications on the machine.

## Deployment
 The Web Deployment tool has been created to make the job of deployment easier. The tool allows you to migrate applications between IIS 6.0 and IIS 7.0, synchronize server farms, and package, archive and deploy Web applications. For more information, see [MS Deployment Tool](https://go.microsoft.com/fwlink/?LinkId=178690).

## See also

- [Workflow Service Host Internals](../../../../docs/framework/wcf/feature-details/workflow-service-host-internals.md)
- [Configuring WorkflowServiceHost](../../../../docs/framework/wcf/feature-details/configuring-workflowservicehost.md)
