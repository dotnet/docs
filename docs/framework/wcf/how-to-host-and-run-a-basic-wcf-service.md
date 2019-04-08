---
title: "Tutorial: Host and run a basic Windows Communication Foundation service"
ms.date: 03/19/2019
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "WCF services [WCF]"
  - "WCF services [WCF], running"
ms.assetid: 31774d36-923b-4e2d-812e-aa190127266f
---
# Tutorial: Host and run a basic Windows Communication Foundation service

This tutorial describes the third of five tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

The next task for creating a WCF application is to host a WCF service in a console application. A WCF service exposes one or more *endpoints*, each of which exposes one or more service operations. A service endpoint specifies the following information: 
- An address where you can find the service.
- A binding that contains the information that describes how a client must communicate with the service. 
- A contract that defines the functionality that the service provides to its clients.

In this tutorial, you learn how to:
> [!div class="checklist"]
> - Create and configure a console app project for hosting a WCF service.
> - Add code to host the WCF service.
> - Update the configuration file.
> - Start the WCF service and verify it's running.

## Create and configure a console app project for hosting the service

1. Create a console app project in Visual Studio: 
 
    1. From the **File** menu, select **Open** > **Project/Solution** and browse to the **GettingStarted** solution you previously created (*GettingStarted.sln*). Select **Open**.

    2. From the **View** menu, select **Solution Explorer**.
    
    3. In the **Solution Explorer** window, select the **GettingStarted** solution (top node), and then select **Add** > **New Project** from the shortcut menu. 

    4. In the **Add New Project** window, on the left side, select the **Windows Desktop** category under **Visual C#** or **Visual Basic**. 

    5. Select the **Console App (.NET Framework)** template, and enter *GettingStartedHost* for the **Name**. Select **OK**.

2. Add a reference in the **GettingStartedHost** project to the **GettingStartedLib** project: 

    1. In the **Solution Explorer** window, select the **References** folder under the **GettingStartedHost** project, and then select **Add Reference** from the shortcut menu. 

    2. In the **Add Reference** dialog, under **Projects** on the left side of the window, select **Solution**. 
 
    3. Select **GettingStartedLib** in the center section of the window, and then select **OK**. 

       This action makes the types defined in the **GettingStartedLib** project available to the **GettingStartedHost** project.

3. Add a reference in the **GettingStartedHost** project to the <xref:System.ServiceModel> assembly: 

    1. In the **Solution Explorer** window, select the **References** folder under the **GettingStartedHost** project, and then select **Add Reference** from the shortcut menu.
    
    2. In the **Add Reference** window, under **Assemblies** on the left side of the window, select **Framework**. 

    3. Select **System.ServiceModel**, and then select **OK**. 
    
    4. Save the solution by selecting **File** > **Save All**.

## Add code to host the service

To host the service, you add code to do the following steps: 
   1. Create a URI for the base address.
   2. Create a class instance for hosting the service.
   3. Create a service endpoint.
   4. Enable metadata exchange.
   5. Open the service host to listen for incoming messages.
  
Make the following changes to the code:

1. Open the **Program.cs** or **Module1.vb** file in the **GettingStartedHost** project and replace its code with the following code:

    ```csharp
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using GettingStartedLib;

    namespace GettingStartedHost
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Step 1: Create a URI to serve as the base address.
                Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

                // Step 2: Create a ServiceHost instance.
                ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

                try
                {
                    // Step 3: Add a service endpoint.
                    selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                    // Step 4: Enable metadata exchange.
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    selfHost.Description.Behaviors.Add(smb)    ;

                    // Step 5: Start the service.
                    selfHost.Open();
                    Console.WriteLine("The service is ready.");

                    // Close the ServiceHost to stop the service.
                    Console.WriteLine("Press <Enter> to terminate the service.");
                    Console.WriteLine();
                    Console.ReadLine();
                    selfHost.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    selfHost.Abort();
                }
            }
        }
    }
    ```

    ```vb
    Imports System.ServiceModel
    Imports System.ServiceModel.Description
    Imports GettingStartedLib.GettingStartedLib

    Module Service

        Class Program
            Shared Sub Main()
                ' Step 1: Create a URI to serve as the base address.
                Dim baseAddress As New Uri("http://localhost:8000/GettingStarted/")

                ' Step 2: Create a ServiceHost instance.
                Dim selfHost As New ServiceHost(GetType(CalculatorService), baseAddress)
               Try

                    ' Step 3: Add a service endpoint.
                    selfHost.AddServiceEndpoint( _
                        GetType(ICalculator), _
                        New WSHttpBinding(), _
                        "CalculatorService")

                    ' Step 4: Enable metadata exchange.
                    Dim smb As New ServiceMetadataBehavior()
                    smb.HttpGetEnabled = True
                    selfHost.Description.Behaviors.Add(smb)

                    ' Step 5: Start the service.
                    selfHost.Open()
                    Console.WriteLine("The service is ready.")

                    ' Close the ServiceHost to stop the service.
                    Console.WriteLine("Press <Enter> to terminate the service.")
                    Console.WriteLine()
                    Console.ReadLine()
                    selfHost.Close()

                Catch ce As CommunicationException
                    Console.WriteLine("An exception occurred: {0}", ce.Message)
                    selfHost.Abort()
                End Try
            End Sub
        End Class

    End Module
    ```
    
    For information about how this code works, see [Service hosting program steps](#service-hosting-program-steps).

2. Update the project properties:

   1. In the **Solution Explorer** window, select the **GettingStartedHost** folder, and then select **Properties** from the shortcut menu.

   2. On the **GettingStartedHost** properties page, select the **Application** tab:

      - For C# projects, select **GettingStartedHost.Program** from the **Startup object** list.

      - For Visual Basic projects, select **Service.Program** from the **Startup object** list.

   3. From the **File** menu, select **Save All**.

## Verify the service is working

1. Build the solution, and then run the **GettingStartedHost** console application from inside Visual Studio. 

    The service must be run with administrator privileges. Because you opened Visual Studio with administrator privileges, when you run **GettingStartedHost** in Visual Studio, the application is run with administrator privileges as well. As an alternative, you can open a new command prompt as an administrator (select **More** > **Run as administrator** from the shortcut menu) and run **GettingStartedHost.exe** within it.

2. Open a web browser and browse to the service's page at `http://localhost:8000/GettingStarted/CalculatorService`.
   
   > [!NOTE]
   > Services such as this one require the proper permission to register HTTP addresses on the machine for listening. Administrator accounts have this permission, but non-administrator accounts must be granted permission for HTTP namespaces. For more information about how to configure namespace reservations, see [Configuring HTTP and HTTPS](feature-details/configuring-http-and-https.md). 

## Service hosting program steps

The steps in the code you added to host the service are described as follows:

- **Step 1**: Create an instance of the `Uri` class to hold the base address of the service. A URL that contains a base address has an optional URI that identifies a service. The base address is formatted as follows: `<transport>://<machine-name or domain><:optional port #>/<optional URI segment>`. The base address for the calculator service uses the HTTP transport, localhost, port 8000, and the URI segment, GettingStarted.

- **Step 2**: Create an instance of the <xref:System.ServiceModel.ServiceHost> class, which you use to host the service. The constructor takes two parameters: the type of the class that implements the service contract and the base address of the service.

- **Step 3**: Create a <xref:System.ServiceModel.Description.ServiceEndpoint> instance. A service endpoint is composed of an address, a binding, and a service contract. The <xref:System.ServiceModel.Description.ServiceEndpoint> constructor is composed of the service contract interface type, a binding, and an address. The service contract is `ICalculator`, which you defined and implement in the service type. The binding for this sample is <xref:System.ServiceModel.WSHttpBinding>, which is a built-in binding and connects to endpoints that conform to the WS-* specifications. For more information about WCF bindings, see [WCF bindings overview](bindings-overview.md). You append the address to the base address to identify the endpoint. The code specifies the address as CalculatorService and the fully qualified address for the endpoint as `http://localhost:8000/GettingStarted/CalculatorService`.

    > [!IMPORTANT]
    > For .NET Framework Version 4 and later, adding a service endpoint is optional. For these versions, if you don't add your code or configuration, WCF adds one default endpoint for each combination of base address and contract implemented by the service. For more information about default endpoints, see [Specifying an endpoint address](specifying-an-endpoint-address.md). For more information about default endpoints, bindings, and behaviors, see [Simplified configuration](simplified-configuration.md) and [Simplified configuration for WCF services](samples/simplified-configuration-for-wcf-services.md).

- **Step 4**: Enable metadata exchange. Clients use metadata exchange to generate proxies for calling the service operations. To enable metadata exchange, create a <xref:System.ServiceModel.Description.ServiceMetadataBehavior> instance, set its <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpGetEnabled> property to `true`, and add the `ServiceMetadataBehavior` object to the <xref:System.ServiceModel.Description.ServiceDescription.Behaviors%2A> collection of the <xref:System.ServiceModel.ServiceHost> instance.

- **Step 5**: Open <xref:System.ServiceModel.ServiceHost> to listen for incoming messages. The application waits for you to press **Enter**. After the application instantiates <xref:System.ServiceModel.ServiceHost>, it executes a try/catch block. For more information about safely catching exceptions thrown by <xref:System.ServiceModel.ServiceHost>, see [Use Close and Abort to release WCF client resources](samples/use-close-abort-release-wcf-client-resources.md).

> [!IMPORTANT]
> When you add a WCF service library, Visual Studio hosts it for you if you debug it by starting a service host. To avoid conflicts, you can prevent Visual Studio from hosting the WCF service library. 
> 1. Select the **GettingStartedLib** project in **Solution Explorer** and choose **Properties** from the shortcut menu.
> 2. Select **WCF Options** and uncheck **Start WCF Service Host when debugging another project in the same solution**.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> - Create and configure a console app project for hosting a WCF service.
> - Add code to host the WCF service.
> - Update the configuration file.
> - Start the WCF service and verify it's running.

Advance to the next tutorial to learn how to create a WCF client.

> [!div class="nextstepaction"]
> [Tutorial: Create a WCF client](how-to-create-a-wcf-client.md)
