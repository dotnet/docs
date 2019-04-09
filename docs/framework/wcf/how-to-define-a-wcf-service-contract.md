---
title: "Tutorial: Define a Windows Communication Foundation service contract"
ms.date: 03/19/2019
helpviewer_keywords:
  - "service contracts [WCF], defining"
dev_langs:
 - CSharp
 - VB
ms.assetid: 67bf05b7-1d08-4911-83b7-a45d0b036fc3
---
# Tutorial: Define a Windows Communication Foundation service contract

This tutorial describes the first of five tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

When you create a WCF service, your first task is to define a service contract. The service contract specifies what operations the service supports. An operation can be thought of as a Web service method. You create service contracts by defining a Visual C# or Visual Basic (VB) interface. An interface has the following characteristics:

- Each method in the interface corresponds to a specific service operation. 
- For each interface, you must apply the <xref:System.ServiceModel.ServiceContractAttribute> attribute.
- For each operation/method, you must apply the <xref:System.ServiceModel.OperationContractAttribute> attribute. 

In this tutorial, you learn how to:
> [!div class="checklist"]
> - Create a **WCF Service Library** project.
> - Define a service contract interface.

## Create a WCF Service Library project and define a service contract interface

1. Open Visual Studio as an administrator. To do so, select the Visual Studio program in the **Start** menu, and then select **More** > **Run as administrator** from the shortcut menu.

2. Create a **WCF Service Library** project.

   1. From the **File** menu, select **New** > **Project**.

   2. In the **New Project** dialog, on the left-hand side, expand **Visual C#** or **Visual Basic**, and then select the **WCF** category. Visual Studio displays a list of project templates in the center section of the window. Select **WCF Service Library**.

      > [!NOTE]
      > If you don't see the **WCF** project template category, you may need to install the **Windows Communication Foundation** component of Visual Studio. In the **New Project** dialog box, select the **Open Visual Studio Installer** link on the left side. Select the **Individual components** tab, and then find and select **Windows Communication Foundation** under the **Development activities** category. Choose **Modify** to begin installing the component.

   3. In the bottom section of the window, enter *GettingStartedLib* for the **Name** and *GettingStarted* for the **Solution name**. 

   4. Select **OK**.

      Visual Studio creates the project, which has three files: *IService1.cs* (or *IService1.vb* for a Visual Basic project), *Service1.cs* (or *Service1.vb* for a Visual Basic project), and *App.config*. Visual Studio defines these files as follows: 
      - The *IService1* file contains the default definition of the service contract. 
      - The *Service1* file contains the default implementation of the service contract. 
      - The *App.config* file contains the configuration info needed to load the default service with the Visual Studio WCF Service Host tool. For more information about the WCF Service Host tool, see [WCF Service Host (WcfSvcHost.exe)](wcf-service-host-wcfsvchost-exe.md).

      > [!NOTE]
      > If you installed Visual Studio with Visual Basic developer environment settings, the solution might be hidden. If this is the case, select **Options** from the **Tools** menu, then select **Projects and Solutions** > **General** in the **Options** window. Select **Always show solution**. Also, verify that **Save new projects when created** is selected.

3. From **Solution Explorer**, open the **IService1.cs** or **IService1.vb** file, and replace its code with the following code:

    ```csharp
    using System;
    using System.ServiceModel;

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

    ```vb
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

     This contract defines an online calculator. Notice the `ICalculator` interface is marked with the <xref:System.ServiceModel.ServiceContractAttribute> attribute (simplified as `ServiceContract`). This attribute defines a namespace to disambiguate the contract name. The code marks each calculator operation with the <xref:System.ServiceModel.OperationContractAttribute> attribute (simplified as `OperationContract`).

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> - Create a WCF Service Library project.
> - Define a service contract interface.

Advance to the next tutorial to learn how to implement the WCF service contract.

> [!div class="nextstepaction"]
> [Tutorial: Implement a WCF service contract](how-to-implement-a-wcf-contract.md)
