---
title: "How to: Define a Windows Communication Foundation Service Contract"
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
  - "service contracts [WCF], defining"
ms.assetid: 67bf05b7-1d08-4911-83b7-a45d0b036fc3
caps.latest.revision: 58
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Define a Windows Communication Foundation Service Contract
This is the first of six tasks required to create a basic [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] application. For an overview of all six of the tasks, see the [Getting Started Tutorial](../../../docs/framework/wcf/getting-started-tutorial.md) topic.  
  
 When creating a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service, the first task is to define a service contract. The service contract specifies what operations the service supports. An operation can be thought of as a Web service method. Contracts are created by defining a C++, C#, or Visual Basic (VB) interface. Each method in the interface corresponds to a specific service operation. Each interface must have the <xref:System.ServiceModel.ServiceContractAttribute> applied to it and each operation must have the <xref:System.ServiceModel.OperationContractAttribute> attribute applied to it. If a method within an interface that has the <xref:System.ServiceModel.ServiceContractAttribute> attribute does not have the <xref:System.ServiceModel.OperationContractAttribute> attribute, that method is not exposed by the service.  
  
 The code used for this task is provided in the example following the procedure.  
  
### To define a service contract  
  
1.  Open  [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)] as an administrator by right-clicking the program in the **Start** menu and selecting **Run as administrator**.  
  
2.  Create a WCF Service Library project by clicking the **File** menu and selecting **New**, **Project**. In the **New Project** dialog, on the left-hand side of the dialog expand **Visual C#** for a C# project or **Other Languages** and then **Visual Basic** for a Visual Basic project. Under the language selected select **WCF** and a list of project templates will be displayed on the center section of the dialog. Select **WCF Service Library**, and type `GettingStartedLib` in the **Name** textbox and `GettingStarted` in the **Solution name** textbox at the bottom of the dialog.  
  
3.  Visual Studio will create the project which contains 3 files: IService1.cs (or IService1.vb), Service1.cs (or Service1.vb), and App.config.  The IService1 file contains a default service contract.  The Service1 file contains a default implementation of the service contract. The App.config file contains configuration needed to load the default service with the Visual Studio WCF Service Host. For more information about the WCF Service Host tool, see [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
  
4.  Open the IService1.cs or IService1.vb file and delete the code within the namespace declaration leaving the namespace declaration. Inside the namespace declaration define a new interface called `ICalculator` as shown in the code below.  
  
    ```  
    // IService.cs  
    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Runtime.Serialization;  
    using System.ServiceModel;  
    using System.Text;  
  
    namespace GettingStartedLib  
    {  
            [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]  
            public interface ICalculator  
            {  
                [OperationContract]  
                double Add(double n1, double n2);  
                [OperationContract]  
                double Subtract(double n1, double n2);  
                [OperationContract]  
                double Multiply(double n1, double n2);  
                [OperationContract]  
                double Divide(double n1, double n2);  
            }  
    }  
    ```  
  
    ```  
    ‘IService.vb  
    Imports System  
    Imports System.ServiceModel  
  
    Namespace GettingStartedLib  
  
        <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _  
        Public Interface ICalculator  
  
            <OperationContract()> _  
            Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double  
            <OperationContract()> _  
            Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double  
            <OperationContract()> _  
            Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double  
            <OperationContract()> _  
            Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double  
        End Interface  
    End Namespace  
    ```  
  
     This contract defines an online calculator. Notice the `ICalculator` interface is marked with the <xref:System.ServiceModel.ServiceContractAttribute> attribute. This attribute defines a namespace that is used to disambiguate the contract name. Each calculator operation is marked with the <xref:System.ServiceModel.OperationContractAttribute> attribute.  
  
    > [!NOTE]
    >  When using attributes to annotate an interface, member, or class, you can drop the "Attribute" part from the attribute name. So <xref:System.ServiceModel.ServiceContractAttribute> becomes `[ServiceContract]` in C#, or `<ServiceContract>` in Visual Basic.  
  
## See Also  
 <xref:System.ServiceModel.ServiceContractAttribute>  
 <xref:System.ServiceModel.OperationContractAttribute>  
 [How to: Implement a Service Contract](../../../docs/framework/wcf/how-to-implement-a-wcf-contract.md)  
 [Getting Started](../../../docs/framework/wcf/samples/getting-started-sample.md)  
 [Self-Host](../../../docs/framework/wcf/samples/self-host.md)
