---
description: "Learn more about: SOAP and HTTP Endpoints"
title: "SOAP and HTTP Endpoints"
ms.date: "03/30/2017"
ms.assetid: e3c8be75-9dda-4afa-89b6-a82cb3b73cf8
---
# SOAP and HTTP Endpoints

The [SoapAndHttpEndpoints sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to implement an RPC-based service and expose it in the SOAP format and the "Plain Old XML" (POX) format using the WCF Web Programming model. See the [Basic HTTP Service](basic-http-service.md) sample for more details about the HTTP binding for the service. This sample focuses on the details that pertain to exposing the same service over SOAP and HTTP using different bindings.

## Demonstrates

Exposing an RPC service over SOAP and HTTP using WCF.

## Discussion

This sample consists of two components: a Web Application project (Service) that contains a WCF service and a console application (Client) that invokes service operations using SOAP and HTTP bindings.

The WCF service exposes 2 operations –`GetData` and `PutData` – that echo the string that was passed as input. The service operations are annotated with <xref:System.ServiceModel.Web.WebGetAttribute> and <xref:System.ServiceModel.Web.WebInvokeAttribute>. These attributes control the HTTP projection of these operations. In addition, they are annotated with <xref:System.ServiceModel.OperationContractAttribute>, which enables them to be exposed over SOAP bindings. The service's `PutData` method throws a <xref:System.ServiceModel.Web.WebFaultException>, which gets sent back over HTTP using the HTTP status code and gets sent back over SOAP as a SOAP fault.

The Web.config file configures the WCF service with 3 endpoints:

- The ~/service.svc/mex endpoint that exposes the service metadata for access by SOAP-based clients.

- The ~/service.svc/http endpoint that enables clients to access the service using the HTTP binding.

- The ~/service.svc/soap endpoint that allows the clients to access the service using the SOAP over HTTP binding.

The HTTP endpoint is configured with a <`webHttp`> standard endpoint which has `helpEnabled` set to `true`. As a result, the service exposes an XHTML based help page at ~/service.svc/http/help that HTTP-based clients can use to access the service.

The client project demonstrates accessing the service using a SOAP proxy (generated through **Add Service Reference**) and accessing the service using <xref:System.Net.WebClient>.

The sample consists of a Web-hosted service and a console application. As the console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.

#### To run the sample

1. Open the solution for the SOAP and HTTP Endpoints Sample.

2. Press **Ctrl**+**Shift**+**B** to build the solution.

3. If it is not already open, press CTRL+W, S to open the **Solution Explorer** window.

4. From the **Solution Explorer** window, right-click the **Service** project and place the cursor over the **Debug** context menu option so that the **Start New Instance** context menu appears. Click **Start New Instance**. This launches the ASP.NET development server, which hosts the service.

5. From the Solution Explorer windows, right-click the Client project and place the cursor over the **Debug** context menu option so that the **Start New Instance** context menu appears. Click **Start New Instance**.

6. The client console window appears and provides the URI of the running service and the URI of the HTML help page for the running service. At any point in time you can view the HTML help page by typing the URI of the help page in a browser.

7. As the sample runs, the client writes the status of the current activity.

8. Press any key to terminate the client console application.

9. Press SHIFT+F5 to stop debugging the service.

10. In the Windows Notification Area, right-click the ASP.NET development server icon and select **Stop** from the context menu.
