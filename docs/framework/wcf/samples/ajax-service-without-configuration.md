---
description: "Learn more about: AJAX Service Without Configuration"
title: "AJAX Service Without Configuration"
ms.date: "03/30/2017"
ms.assetid: e6db7acd-5679-45d4-b98a-8449c6873838
---
# AJAX Service Without Configuration

The [ConfigFreeAjaxService sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to use Windows Communication Foundation (WCF) to create a basic ASP.NET Asynchronous JavaScript and XML (AJAX) service (a service that you can access by using JavaScript code from a Web browser client) without using any configuration settings. The service uses special syntax in the .svc file to automatically enable an AJAX endpoint.

AJAX support in WCF is optimized for use with ASP.NET AJAX through the `ScriptManager` control. For an example of using WCF with ASP.NET AJAX, see the [Ajax Samples](ajax.md).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample builds upon the AJAX Service Using HTTP POST. As described in the [Basic AJAX Service](basic-ajax-service.md) sample, <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory> is used to host the service.

```text
<%ServiceHost
    language=c#
    Debug="true"
    Service="Microsoft.Ajax.Samples.CalculatorService
    Factory="System.ServiceModel.Activation.WebScriptServiceHostFactory"
%>
```

<xref:System.ServiceModel.Activation.WebScriptServiceHostFactory> automatically adds a <xref:System.ServiceModel.Description.WebScriptEndpoint> to the service. If no configuration changes need to be made to the endpoint, the `<system.ServiceModel>` section can be completely removed from the Web.config file for the service. The Web.config file contains some ASP.NET settings, which are used by ConfigFreeClientPage.aspx. If that were not the case, the entire Web.config file could be removed.

#### To set up, build, and run the sample

1. Ensure that you perform the setup instructions in [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Build the solution ConfigFreeAjaxService.sln as described in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. Navigate to `http://localhost/ServiceModelSamples/ConfigFreeClientPage.aspx` (do not open ConfigFreeClientPage.aspx in the browser from within the project directory).

> [!NOTE]
> When running this sample, please ensure that Anonymous Authentication and Windows Authentication are not enabled simultaneously for the ServiceModelSamples folder in IIS. If that is the case, please disable Windows Authentication. Once you have run the sample, enable Windows Authentication and run "iisreset".

## See also

- [Basic AJAX Service](basic-ajax-service.md)
