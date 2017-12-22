---
title: "How To: Enable WIF for a WCF Web Service Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bfc64b3d-64e9-4093-a6a4-72e933917af7
caps.latest.revision: 6
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Enable WIF for a WCF Web Service Application
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   Microsoft® Windows® Communication Foundation (WCF)  
  
## Summary  
 This How-To provides detailed step-by-step procedures for enabling WIF in a WCF web service. It also provides instructions for how to test the application to verify that the web service is correctly presenting claims when the application is run. This How-To does not have detailed instructions for creating a Security Token Service (STS), and instead uses the Development STS that comes with the Identity and Access tool. The Development STS does not perform real authentication and is intended for testing purposes only. You will need to install the Identity and Access tool to complete this How-To. It can be downloaded from the following location: [Identity and Access Tool](http://go.microsoft.com/fwlink/?LinkID=245849)  
  
## Contents  
  
-   Objectives  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple WCF Service  
  
-   Step 2 – Create a Client Application for the WCF Service  
  
-   Step 3 – Test Your Solution  
  
## Objectives  
  
-   Create a WCF service that requires issued tokens  
  
-   Create a WCF client that requests a token from an STS and passes it to the WCF service  
  
## Overview  
 This How-To is intended to demonstrate how a developer can use federated authentication when developing WCF services. Some of the benefits of using federation in WCF services include:  
  
1.  Factoring authentication logic out of WCF service code  
  
2.  Re-using existing identity management solutions  
  
3.  Interoperability with other identity solutions  
  
4.  Flexibility and resilience to future changes  
  
 WIF and the associated Identity and Access tool make it easier to develop and test a WCF service using federated authentication, as the following steps demonstrate.  
  
## Summary of Steps  
  
-   Step 1 – Create a Simple WCF Service  
  
-   Step 2 – Create a Client Application for the WCF Service  
  
-   Step 3 – Test Your Solution  
  
## Step 1 – Create a Simple WCF Service  
 In this step, you will create a new WCF service that uses the Development STS that is included with the Identity and Access tool.  
  
#### To create a simple WCF service  
  
1.  Start Visual Studio in elevated mode as administrator.  
  
2.  In Visual Studio, click **File**, click **New**, and then click **Project**.  
  
3.  In the **New Project** window, click **WCF Service Application**.  
  
4.  In **Name**, enter `TestService` and press **OK**.  
  
5.  Right-click the **TestService** project under **Solution Explorer**, then select **Identity and Access**.  
  
6.  The **Identity and Access** window appears. Under **Providers**, select **Test your application with the Local Development STS**, then click **Apply**. The Identity and Access Tool configures the service to use WIF and to outsource authentication to the local development STS (**LocalSTS**) by adding configuration elements to the *Web.config* file.  
  
7.  In the *Service1.svc.cs* file, add a `using` directive for the **System.Security.Claims** namespace and replace the existing code with the following, then save the file:  
  
    ```csharp  
    public class Service1 : IService1  
    {  
        public string ComputeResponse(string input)  
        {  
            // Get the caller's identity from ClaimsPrincipal.Current  
            ClaimsPrincipal claimsPrincipal = OperationContext.Current.ClaimsPrincipal;  
  
            // Start generating the output  
            StringBuilder builder = new StringBuilder();  
            builder.AppendLine("Computed by ClaimsAwareWebService");  
            builder.AppendLine("Input received from client:" + input);  
  
            if (claimsPrincipal != null)  
            {  
                // Display the claims from the caller. Do not use this code in a production application.  
                ClaimsIdentity identity = claimsPrincipal.Identity as ClaimsIdentity;  
                builder.AppendLine("Client Name:" + identity.Name);  
                builder.AppendLine("IsAuthenticated:" + identity.IsAuthenticated);  
                builder.AppendLine("The service received the following issued claims of the client:");  
  
                // Iterate over the caller’s claims and append to the output  
                foreach (Claim claim in claimsPrincipal.Claims)  
                {  
                    builder.AppendLine("ClaimType :" + claim.Type + "   ClaimValue:" + claim.Value);  
                }  
            }  
  
            return builder.ToString();  
        }  
    }  
    ```  
  
     The `ComputeResponse` method displays the properties of various claims that are issued by **LocalSTS**.  
  
8.  In the *IService1.cs* file, replace the existing code with the following, then save the file:  
  
    ```csharp  
    [ServiceContract]  
    public interface IService1  
    {  
        [OperationContract]  
        string ComputeResponse(string input);  
    }  
    ```  
  
9. Build the project.  
  
10. Press **Ctrl-F5** to run the service without starting the debugger. A Web page should open for the service and you can verify that **LocalSTS** is running by looking in the notification area (system tray).  
  
    > [!IMPORTANT]
    >  Both **TestService** and **LocalSTS** must be running when you add the service reference to the client application in the next step.  
  
## Step 2 – Create a Client Application for the WCF Service  
 In this step, you will create a console application that uses the Development STS to authenticate with the WCF service you created in the previous step.  
  
#### To create a client application  
  
1.  In Visual Studio, right-click on the solution, click **Add**, and then click **New Project**.  
  
2.  In the **Add New Project** window, select **Console Application** from the **Visual C#** templates list, enter `Client`, and then press **OK**. The new project will be created in your solution folder.  
  
3.  Right-click on **References** under the **Client** project, and then click **Add Service Reference**.  
  
4.  In the **Add Service Reference** window, click the drop-down arrow on the **Discover** button and click **Services in Solution**. The **Address** will automatically populate with the WCF service you created earlier, and the **Namespace** will be set to **ServiceReference1**. Click **OK**.  
  
    > [!IMPORTANT]
    >  Both **TestService** and **LocalSTS** must be running when you add the service reference to the client.  
  
5.  Visual Studio will generate proxy classes for the WCF service, and add all of the necessary reference information. It will also add elements to the *App.config* file to configure the client to get a token from the STS to authenticate with the service. When this process is finished, the **Program.cs** file will open. Add a `using` directive for **System.ServiceModel** and another for **Client.ServiceReference1**, replace the **Main** method with the following code, then save the file:  
  
    ```csharp  
    static void Main(string[] args)  
    {  
        // Create the client for the service  
        Service1Client client = new Service1Client();  
        Console.WriteLine("-------------WCF Client Application--------------\n");  
  
        while (!ShouldQuitApplication())  
        {  
            try  
            {  
                Console.WriteLine(client.ComputeResponse("Hello World"));  
            }  
            catch (CommunicationException e)  
            {  
                Console.WriteLine(e.Message);  
                Console.WriteLine(e.StackTrace);  
                Exception ex = e.InnerException;  
                while (ex != null)  
                {  
                    Console.WriteLine("===========================");  
                    Console.WriteLine(ex.Message);  
                    Console.WriteLine(ex.StackTrace);  
                    ex = ex.InnerException;  
                }  
            }  
            catch (TimeoutException)  
            {  
                Console.WriteLine("Timed out...");  
            }  
            catch (Exception e)  
            {  
                Console.WriteLine("An unexpected exception occurred.");  
                Console.WriteLine(e.StackTrace);  
            }  
        }  
  
        client.Close();  
  
        if (client != null)  
        {  
            client.Abort();  
        }  
    }  
  
    static bool ShouldQuitApplication()  
    {  
        Console.WriteLine("---------------------------------------------------------------------");  
        Console.WriteLine("Press Enter key to invoke service, any other key to quit application:");  
        Console.WriteLine("----------------------------------------------------------------------");  
  
        ConsoleKeyInfo keyInfo = Console.ReadKey();  
        if (keyInfo.Key == ConsoleKey.Enter)  
            return false;  
        return true;  
    }  
    ```  
  
6.  Open the *App.config* file and add the following XML as the first child element under the `<system.serviceModel>` element, then save the file:  
  
    ```xml  
    <behaviors>  
       <endpointBehaviors>  
         <behavior>  
           <clientCredentials>  
             <serviceCertificate>  
               <authentication certificateValidationMode="None"/>  
             </serviceCertificate>  
           </clientCredentials>  
         </behavior>  
       </endpointBehaviors>  
     </behaviors>  
    ```  
  
     This disables certificate validation.  
  
7.  Right-click the **TestService** solution and click on **Set StartUp Projects**. The **Startup Project** property page opens. In the **Startup Project** property page, select **Multiple startup projects** then click in the **Action** field for each project and select **Start** from the drop-down menu. Click **OK** to save the settings.  
  
8.  Build the solution.  
  
## Step 3 – Test Your Solution  
 In this step you will test your WIF-enabled WCF application and verify that claims are presented.  
  
#### To test your WIF-enabled WCF application for claims  
  
1.  Press **F5** to build and run the application. You should be presented with a console window, and the following text: **Press Enter key to invoke service, any other key to quit application:**  
  
2.  Press **Enter**, and the following claims information should appear in the console:  
  
    ```  
    Computed by Service1  
    Input received from client: Hello World  
    Client Name: Terry  
    IsAuthenticated: True  
    The service received the following issued claims of the client:  
    ClaimType :http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name    ClaimValue:Terry  
    ClaimType :http://schema.xmlsoap.org/ws/2005/05/identity/claims/surname    ClaimValue:Adams  
    ClaimType :http://schemas.microsoft.com/ws/2008/06/identity/claims/role    ClaimValue:developer  
    ClaimType :http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress    ClaimValue:terry@contoso.com  
    ```  
  
    > [!IMPORTANT]
    >  Both **TestService** and **LocalSTS** must be running before you press **Enter**. A Web page should open for the service and you can verify that **LocalSTS** is running by looking in the notification area (system tray).  
  
3.  If these claims appear in the console, you have successfully authenticated with the STS to display claims from the WCF service.
