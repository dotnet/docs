---
title: "Tutorial: Host and run a basic Windows Communication Foundation service"
ms.date: 01/22/2019
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

The next task for creating a WCF application is to host a WCF service in a console application. After you create a console application project, you then run code to host the service. This code has the following steps:

1. Create a URI for the base address.

2. Create a ServiceHost instance.

3. Create a service endpoint.

4. Enable metadata exchange.

5. Open the service host to listen for incoming messages.

A complete listing of the code for this task is provided in the code example following the console application procedure.

## Create a console application for hosting the service

1. Create a console application project in Visual Studio. 
 
    1. From the **File** menu, select **Open** > **Project/Solution** and browse to the **GettingStarted** solution you previously created (*GettingStarted.sln*). Select **Open**.

    2. From the **View** menu, select **Solution Explorer**.
    
    3. In the **Solution Explorer** window, select the **GettingStarted** solution (top node), and then select **Add** > **New Project** from the shortcut menu. 

    4. In the **Add New Project** window, on the left side, select the **Windows Desktop** category under **Visual C#** or **Visual Basic**. 

    5. Select the **Console App (.NET Framework)** template, and enter *GettingStartedHost* for the **Name**. Select **OK**.

2. Add a reference in the **GettingStartedHost** project to the **GettingStartedLib** project. 

    1. In the **Solution Explorer** window, select the **References** folder under the **GettingStartedHost** project, and then select **Add Reference** from the shortcut menu. 

    2. In the **Add Reference** dialog, under **Projects** on the left side of the window, select **Solution**. 
 
    3. Select **GettingStartedLib** in the center section of the window, and then choose **OK**. This action makes the types defined in the **GettingStartedLib** project available to the **GettingStartedHost** project.

3. Add a reference in the **GettingStartedHost** project to the <xref:System.ServiceModel> assembly. 

    1. In the **Solution Explorer** window, select the **References** folder under the **GettingStartedHost** project, and then select **Add Reference** from the shortcut menu.
    
    2. In the **Add Reference** window, under **Assemblies** on the left side of the window, select **Framework**. 

    3. Find and select **System.ServiceModel**, and then choose **OK**. 
    
    4. Save the solution by selecting **File** > **Save All**.

## Host the service

1. Open the *Program.cs* (or *Module1.vb*) file in the **GettingStartedHost** project and replace its code with the following code:

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

                    // Step 5: Start (and then stop) the service.
                    selfHost.Open();
                    Console.WriteLine("The service is ready.");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();

                    // Close the ServiceHostBase to stop the service.
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

                    ' Step 5: Start (and then stop) the service.
                    selfHost.Open()
                    Console.WriteLine("The service is ready.")
                    Console.WriteLine("Press <ENTER> to terminate service.")
                    Console.WriteLine()
                    Console.ReadLine()

                    ' Close the ServiceHostBase to stop the service.
                    selfHost.Close()

                Catch ce As CommunicationException
                    Console.WriteLine("An exception occurred: {0}", ce.Message)
                    selfHost.Abort()
                End Try
            End Sub
        End Class

    End Module
    ```

2. Edit *App.config* in **GettingStartedLib**:
- For Visual C# projects, edit *App.config* to reflect the changes you made to *Program.cs*:
    - Change line 14 to `<service name="GettingStartedLib.CalculatorService">`.
    - Change line 17 to `<add baseAddress = "http://localhost:8000/GettingStarted/CalculatorService" />`.
   - Change line 22 to `<endpoint address="" binding="wsHttpBinding" contract="GettingStartedLib.ICalculator">`.

- For Visual Basic projects, edit *App.config* to reflect the changes you made to *Module1.vb*:
    - Change line 14 to `<service name="GettingStartedLib.GettingStartedLib.CalculatorService">`.
   - Change line 17 to `<add baseAddress = "http://localhost:8000/GettingStarted/CalculatorService" />`.
   - Change line 22 to `<endpoint address="" binding="wsHttpBinding" contract="GettingStartedLib.GettingStartedLib.ICalculator">`.

3. For Visual Basic projects, make the following change:

   1. In the **Solution Explorer** window, select the **GettingStartedHost** folder, and then select **Properties** from the shortcut menu.

   2. In the **GettingStartedHost** window, for **Startup object**, select **Service.Program** from the list. 

   3. From the main menu, select **File** > **Save All**.


The steps in the code example are described as follows:

- **Step 1**: Create an instance of the `Uri` class to hold the base address of the service. A URL that contains a base address has an optional URI that identifies a service. The base address is formatted as follows: `<transport>://<machine-name or domain><:optional port #>/<optional URI segment>`. The base address for the calculator service uses the HTTP transport, localhost, port 8000, and the URI segment, GettingStarted.

- **Step 2**: Create an instance of the <xref:System.ServiceModel.ServiceHost> class, which you use to host the service. The constructor takes two parameters: the type of the class that implements the service contract and the base address of the service.

- **Step 3**: Create a <xref:System.ServiceModel.Description.ServiceEndpoint> instance. A service endpoint is composed of an address, a binding, and a service contract. The <xref:System.ServiceModel.Description.ServiceEndpoint> constructor is composed of the service contract interface type, a binding, and an address. The service contract is `ICalculator`, which you defined and implement in the service type. The binding for this sample is <xref:System.ServiceModel.WSHttpBinding>, which is a built-in binding and connects to endpoints that conform to the WS-* specifications. For more information about WCF bindings, see [WCF bindings overview](bindings-overview.md). You append the address to the base address to identify the endpoint. The code specifies the address as CalculatorService and the fully qualified address for the endpoint as `http://localhost:8000/GettingStarted/CalculatorService`.

    > [!IMPORTANT]
    > For .NET Framework Version 4 and later, adding a service endpoint is optional. For these versions, if you don't add your code or configuration, WCF adds one default endpoint for each combination of base address and contract implemented by the service. For more information about default endpoints, see [Specifying an endpoint address](specifying-an-endpoint-address.md). For more information about default endpoints, bindings, and behaviors, see [Simplified configuration](simplified-configuration.md) and [Simplified configuration for WCF services](samples/simplified-configuration-for-wcf-services.md).

- **Step 4**: Enable metadata exchange. Clients use metadata exchange to generate proxies for calling the service operations. To enable metadata exchange, create a <xref:System.ServiceModel.Description.ServiceMetadataBehavior> instance, set its <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpGetEnabled> property to `true`, and add the `ServiceMetadataBehavior` object to the <!--zz <xref:System.ServiceModel.ServiceHost.Behaviors%2A>  -->`System.ServiceModel.ServiceHost.Behaviors` collection of the <xref:System.ServiceModel.ServiceHost> instance.

- **Step 5**: Open the <xref:System.ServiceModel.ServiceHost> to listen for incoming messages. The code waits for the user to press **Enter**. If you don't press **Enter**, the app closes immediately and the service shuts down. Also, the code uses a try/catch block. After the <xref:System.ServiceModel.ServiceHost> is instantiated, the rest of the code is placed in a try/catch block. For more information about safely catching exceptions thrown by <xref:System.ServiceModel.ServiceHost>, see [Use Close and Abort to release WCF client resources](samples/use-close-abort-release-wcf-client-resources.md).


## Verify the service is working

1. Build the solution, and then run the **GettingStartedHost** console application from inside Visual Studio. As an alternative, you can open a new command prompt by using **Run as administrator** and run *GettingStartedHost.exe* within it. 
2. 
3. 
4. To compile this code with a command-line compiler, compile *IService1.cs* and *Service1.cs* (or *IService1.vb and Service1.vb*) into a class library that references `System.ServiceModel.dll`. Compile *Program.cs* (or *Module1.vb*) as a console application.


2. Open a web browser and browse to the service's page at `http://localhost:8000/GettingStarted/CalculatorService`.

> [!NOTE]
> Services such as this one require the proper permission to register HTTP addresses on the machine for listening. Administrator accounts have this permission, but non-administrator accounts must be granted permission for HTTP namespaces. For more information about how to configure namespace reservations, see [Configuring HTTP and HTTPS](feature-details/configuring-http-and-https.md). If you're running the service under Visual Studio, you must run *GettingStartedHost.exe* with administrator privileges.


## Next steps

The service is now running. In the next task, you create a WCF client.

> [!div class="nextstepaction"]
> [Tutorial: Create a WCF client](how-to-create-a-wcf-client.md)

For troubleshooting info, see [Troubleshooting the get started tutorial](troubleshooting-the-getting-started-tutorial.md).

## See also

- [Getting started sample](samples/getting-started-sample.md)
- [Self-Host](samples/self-host.md)