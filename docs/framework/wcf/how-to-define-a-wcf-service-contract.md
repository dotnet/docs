---
title: "Tutorial: Define a Windows Communication Foundation service contract"
ms.date: 01/15/2019
helpviewer_keywords:
  - "service contracts [WCF], defining"
dev_langs:
 - CSharp
 - VB
ms.assetid: 67bf05b7-1d08-4911-83b7-a45d0b036fc3
---
# Tutorial: Define a Windows Communication Foundation service contract

This tutorial describes the first of six tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Getting started tutorial](getting-started-tutorial.md).

When you create a WCF service, your first task is to define a service contract. The service contract specifies what operations the service supports. An operation can be thought of as a Web service method. You create service contracts by defining a C++, C#, or Visual Basic (VB) interface. An interface has the following characteristics:

- Each method in the interface corresponds to a specific service operation. 
- For each interface, you must apply the <xref:System.ServiceModel.ServiceContractAttribute> attribute.
- For each operation/method, you must apply the <xref:System.ServiceModel.OperationContractAttribute> attribute. 


## Define a service contract 

1. Open Visual Studio as an administrator. To do so, right-click the Visual Studio program in the **Start** menu and select **More** > **Run as administrator**.

2. Create a WCF Service Library project.

   1. From the **File** menu, select **New** > **Project**.

   2. In the **New Project** dialog, on the left-hand side, expand **Visual C#** or **Visual Basic**, and then select the **WCF** category. Visual Studio displays a list of project templates in the center section of the window. Select **WCF Service Library**.

      > [!NOTE]
      > If you don't see the **WCF** project template category, you may need to install the **Windows Communication Foundation** component of Visual Studio. In the **New Project** dialog box, select the **Open Visual Studio Installer** link on the left side. Select the **Individual components** tab, and then find and select **Windows Communication Foundation** under the **Development activities** category. Choose **Modify** to begin installing the component.

   3. In the bottom section of the window, enter *GettingStartedLib* for the **Name** and *GettingStarted* for the **Solution name**. For **Solution**, verify you've selected **Create new solution**.

   4. Select **OK**.

   Visual Studio creates the project, which has three files: IService1.cs (or IService1.vb), Service1.cs (or Service1.vb), and App.config. Visual Studio defines these files as follows: 
   - The IService1 file contains the default service contract. 
   - The Service1 file contains the default implementation of the service contract. 
   - The App.config file contains the configuration info needed to load the default service with the Visual Studio WCF Service Host tool. For more info about the WCF Service Host tool, see [WCF Service Host (WcfSvcHost.exe)](wcf-service-host-wcfsvchost-exe.md).

3. Open the IService1.cs (or IService1.vb) file. Delete the code within the `GettingStartedLib` namespace declaration and add the `ICalculator` interface as follows:

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

> [!div class="nextstepaction"]
> [Tutorial: Implement a service contract](../../../docs/framework/wcf/how-to-implement-a-wcf-contract.md)

## See also

- <xref:System.ServiceModel.ServiceContractAttribute>
- <xref:System.ServiceModel.OperationContractAttribute>
- [Tutorial: Implement a WCF service contract](how-to-implement-a-wcf-contract.md)
- [Getting started sample](samples/getting-started-sample.md)
- [Self-Host](samples/self-host.md)