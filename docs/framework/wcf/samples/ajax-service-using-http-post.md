---
description: "Learn more about: AJAX Service Using HTTP POST"
title: "AJAX Service Using HTTP POST"
ms.date: "03/30/2017"
ms.assetid: 1ac80f20-ac1c-4ed1-9850-7e49569ff44e
---
# AJAX Service Using HTTP POST

The [PostAjaxService sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to use Windows Communication Foundation (WCF) to create an ASP.NET Asynchronous JavaScript and XML (AJAX) service that uses HTTP POST. An AJAX service is one that you can access by using basic JavaScript code from a Web browser client. This sample builds on the [Basic AJAX Service](basic-ajax-service.md) sample; the only difference between the two samples is the use of HTTP POST instead of HTTP GET.

AJAX support in Windows Communication Foundation (WCF) is optimized for use with ASP.NET AJAX through the `ScriptManager` control. For an example of using WCF with ASP.NET AJAX, see the [Ajax Samples](ajax-service-using-http-post.md).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The service in the following sample is a WCF service with no AJAX-specific code.

If the <xref:System.ServiceModel.Web.WebInvokeAttribute> attribute is applied on an operation, or the <xref:System.ServiceModel.Web.WebGetAttribute> attribute is not applied, the default HTTP verb ("POST") is used. POST requests are harder to construct than GET requests, but they are not cached; use POST requests for all operations where caching is not appropriate.

```csharp
[ServiceContract(Namespace = "PostAjaxService")]
public interface ICalculator
{
    [WebInvoke]
    double Add(double n1, double n2);
    //Other operations omitted…
}
```

Create an AJAX endpoint on the service by using the <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory>, just as in the Basic AJAX Service sample.

Unlike GET requests, you cannot invoke POST services from the browser. For example, navigating to `http://localhost/ServiceModelSamples/service.svc/Add?n1=100&n2=200` results in an error, because the POST service expects the `n1` and `n2` parameters to be sent in the message body in the JSON format, and not in the URL.

The client Web page PostAjaxClientPage.aspx contains ASP.NET code to invoke the service whenever the user clicks one of the operation buttons on the page. The service responds in the same way as in the [Basic AJAX Service](basic-ajax-service.md) sample, with the GET request.

## To set up, build, and run the sample

1. Ensure that you perform the setup instructions [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Build the solution PostAjaxService.sln as described in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. Navigate to `http://localhost/ServiceModelSamples/PostAjaxClientPage.aspx` (do not open PostAjaxClientPage.aspx in the browser from the project directory).
