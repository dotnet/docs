---
title: "How to: Host a WCF Service in a Managed Application"
ms.date: 09/17/2018
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 5eb29db0-b6dc-4e77-8c68-0a62f79d743b
---
# How to: Host a WCF service in a managed app

To host a service inside a managed application, embed the code for the service inside the managed application code, define an endpoint for the service either imperatively in code, declaratively through configuration, or using default endpoints, and then create an instance of <xref:System.ServiceModel.ServiceHost>.

To start receiving messages, call <xref:System.ServiceModel.ICommunicationObject.Open%2A> on <xref:System.ServiceModel.ServiceHost>. This creates and opens the listener for the service. Hosting a service in this way is often referred to as "self-hosting" because the managed application is doing the hosting work itself. To close the service, call <xref:System.ServiceModel.Channels.CommunicationObject.Close%2A?displayProperty=nameWithType> on <xref:System.ServiceModel.ServiceHost>.

A service can also be hosted in a managed Windows service, in Internet Information Services (IIS), or in Windows Process Activation Service (WAS). For more information about hosting options for a service, see [Hosting Services](../../../docs/framework/wcf/hosting-services.md).

Hosting a service in a managed application is the most flexible option because it requires the least infrastructure to deploy. For more information about hosting services in managed applications, see [Hosting in a Managed Application](../../../docs/framework/wcf/feature-details/hosting-in-a-managed-application.md).

The following procedure demonstrates how to implement a self-hosted service in a console application.

## Create a self-hosted service

1. Create a new console application:

   1. Open Visual Studio and select **New** > **Project** from the **File** menu.

   2. In the **Installed Templates** list, select **Visual C#** or **Visual Basic**, and then select **Windows Desktop**.

   3. Select the **Console App** template. Type `SelfHost` in the **Name** box and then choose **OK**.

2. Right-click **SelfHost** in **Solution Explorer** and select **Add Reference**. Select **System.ServiceModel** from the **.NET** tab and then choose **OK**.

    > [!TIP]
    > If the **Solution Explorer** window is not visible, select **Solution Explorer** from the **View** menu.

3. Double-click **Program.cs** or **Module1.vb** in **Solution Explorer** to open it in the code window, if it's not already open. Add the following statements at the top of the file:

     [!code-csharp[CFX_SelfHost4#1](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_selfhost4/cs/program.cs#1)]
     [!code-vb[CFX_SelfHost4#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/cfx_selfhost4/vb/module1.vb#1)]

4. Define and implement a service contract. This example defines a `HelloWorldService` that returns a message based on the input to the service.

     [!code-csharp[CFX_SelfHost4#2](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_selfhost4/cs/program.cs#2)]
     [!code-vb[CFX_SelfHost4#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/cfx_selfhost4/vb/module1.vb#2)]

    > [!NOTE]
    > For more information about how to define and implement a service interface, see [How to: Define a Service Contract](../../../docs/framework/wcf/how-to-define-a-wcf-service-contract.md) and [How to: Implement a Service Contract](../../../docs/framework/wcf/how-to-implement-a-wcf-contract.md).

5. At the top of the `Main` method, create an instance of the <xref:System.Uri> class with the base address for the service.

     [!code-csharp[CFX_SelfHost4#3](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_selfhost4/cs/program.cs#3)]
     [!code-vb[CFX_SelfHost4#3](../../../samples/snippets/visualbasic/VS_Snippets_CFX/cfx_selfhost4/vb/module1.vb#3)]

6. Create an instance of the <xref:System.ServiceModel.ServiceHost> class, passing a <xref:System.Type> that represents the service type and the base address Uniform Resource Identifier (URI) to the <xref:System.ServiceModel.ServiceHost.%23ctor%28System.Type%2CSystem.Uri%5B%5D%29>. Enable metadata publishing, and then call the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method on the <xref:System.ServiceModel.ServiceHost> to initialize the service and prepare it to receive messages.

     [!code-csharp[CFX_SelfHost4#4](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_selfhost4/cs/program.cs#4)]
     [!code-vb[CFX_SelfHost4#4](../../../samples/snippets/visualbasic/VS_Snippets_CFX/cfx_selfhost4/vb/module1.vb#4)]

    > [!NOTE]
    > This example uses default endpoints, and no configuration file is required for this service. If no endpoints are configured, then the runtime creates one endpoint for each base address for each service contract implemented by the service. For more information about default endpoints, see [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).

7. Press **Ctrl**+**Shift**+**B** to build the solution.

## Test the service

1. Press **Ctrl**+**F5** to run the service.

2. Open **WCF Test Client**.

    > [!TIP]
    > To open **WCF Test Client**, open Developer Command Prompt for Visual Studio and execute **WcfTestClient.exe**.

3. Select **Add Service** from the **File** menu.

4. Type `http://localhost:8080/hello` into the address box and click **OK**.

    > [!TIP]
    > Make sure the service is running or else this step fails. If you have changed the base address in the code, then use the modified base address in this step.

5. Double-click **SayHello** under the **My Service Projects** node. Type your name into the **Value** column in the **Request** list, and click **Invoke**.

   A reply message appears in the **Response** list.

## Example

The following example creates a <xref:System.ServiceModel.ServiceHost> object to host a service of type `HelloWorldService`, and then calls the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method on <xref:System.ServiceModel.ServiceHost>. A base address is provided in code, metadata publishing is enabled, and default endpoints are used.

[!code-csharp[CFX_SelfHost4#5](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_selfhost4/cs/program.cs#5)]
[!code-vb[CFX_SelfHost4#5](../../../samples/snippets/visualbasic/VS_Snippets_CFX/cfx_selfhost4/vb/module1.vb#5)]

## See also

- <xref:System.Uri>
- <xref:System.Configuration.ConfigurationManager.AppSettings%2A>
- <xref:System.Configuration.ConfigurationManager>
- [How to: Host a WCF Service in IIS](../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-iis.md)
- [Self-Host](../../../docs/framework/wcf/samples/self-host.md)
- [Hosting Services](../../../docs/framework/wcf/hosting-services.md)
- [How to: Define a Service Contract](../../../docs/framework/wcf/how-to-define-a-wcf-service-contract.md)
- [How to: Implement a Service Contract](../../../docs/framework/wcf/how-to-implement-a-wcf-contract.md)
- [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
- [Using Bindings to Configure Services and Clients](../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md)
- [System-Provided Bindings](../../../docs/framework/wcf/system-provided-bindings.md)
