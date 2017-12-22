---
title: "Hierarchical Configuration Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 28dcc698-226c-4b77-9e51-8bf45a36216c
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hierarchical Configuration Model
This sample demonstrates how to implement a hierarchy of configuration files for services. It also shows how bindings, service behaviors, and endpoint behaviors are inherited from higher levels in the hierarchy.  
  
## Sample details  
 One of the features developed for [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] in [!INCLUDE[netfx40_long](../../../../includes/netfx40-long-md.md)] is the improvement in the hierarchical configuration model. An example of a hierarchical configuration model would be the one defined by Machine.config -> Rootweb.config -> Web.config. In [!INCLUDE[netfx40_short](../../../../includes/netfx40-short-md.md)], those bindings and behaviors that are defined in upper levels in the configuration hierarchy are added to your services with no explicit configuration. This sample shows how it is possible to simplify your service configuration by relying on configuration elements defined at the computer or the application level.  
  
 This sample consists of nine services, defined in three levels of hierarchy. `Service1` is at the root. `Service2` and `Service3` inherit the default elements from `Service1`. `Service4`, `Service5`, `Service6` and `Service7` are defined at a third level of the hierarchy, inheriting the default elements from `Service3`. Finally `Service10` and `Service11` are at a fourth level of the hierarchy.  
  
 All the services implement the `IDesc` contract. The following is the definition of the `IDesc` interface that shows the methods exposed in this interface. The `IDesc` interface is defined in Service1.cs.  
  
```  
// Define a service contract  
[ServiceContract(Namespace="http://Microsoft.Samples.ConfigHierarchicalModel")]  
public interface IDesc  
{  
    [OperationContract]  
    List<string> ListEndpoints();  
    [OperationContract]  
    List<string> ListServiceBehaviors();  
    [OperationContract]  
    List<string> ListEndpointBehaviors();  
}  
```  
  
 The implementation of these methods by the services is straightforward. `ListEndpoints` iterates through all the service endpoints and returns a list of all the endpoints that the service has. `ListServiceBehaviors` iterates through all the behaviors added to the service and returns the list of all the service behaviors associated with the service. `ListEndpointBehaviors` behaves in a similar way to `ListServiceBehaviors`, but it returns the list of endpoint behaviors instead.  
  
 This implementation allows the client to know how many endpoints the service is exposing and which service behaviors and endpoint behaviors have been added to the service. The client that has been implemented as part of the sample adds a service reference to all the services in the solution and shows these elements for each one of the services.  
  
## To use this sample  
  
#### To run the client  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the ConfigHierarchicalModel.sln file.  
  
2.  The client project is not already set up as the start-up project, follow these steps.  
  
    1.  In **Solution Explorer**, right-click the solution and then select **Properties**.  
  
    2.  In **Common Properties**, select **Startup Project**, and then click **Single startup project**.  
  
    3.  From the **Single startup project** drop-down, select **Client**.  
  
    4.  Click **OK** to close the dialog.  
  
3.  To build the sample, press CTRL+SHIFT+B.  
  
4.  To run the client, press Ctrl+F5.  
  
> [!NOTE]
>  If these steps do not work, then make sure that your environment has been properly set up, using the following steps.  
>   
>  1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
> 2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
> 3.  To run the sample in a single or multiple computer configurations, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Services\ConfigHierarchicalModel`  
  
## See Also  
 [AppFabric Management Samples](http://go.microsoft.com/fwlink/?LinkId=193960)
