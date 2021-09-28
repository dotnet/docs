---
description: "Learn more about: LINQ Message Query Correlation"
title: "LINQ Message Query Correlation"
ms.date: "03/30/2017"
ms.assetid: b746872e-57b1-4514-b337-53398a0e0deb
---
# LINQ Message Query Correlation

The [LinqMessageQueryCorrelation sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/Services/LinqMessageQueryCorrelation/CS) demonstrates how to do content-based correlation using a custom <xref:System.ServiceModel.Dispatcher.MessageQuery> implementation as opposed to the system-provided <xref:System.ServiceModel.XPathMessageQuery>.

## Demonstrates

 Custom <xref:System.ServiceModel.Dispatcher.MessageQuery>, Content-Based Correlation.

## Discussion

 This sample shows how to extend from the <xref:System.ServiceModel.Dispatcher.MessageQuery> base class for the purposes of correlation. The custom implementation, `LinqMessageQuery`, allows users to provide an XName to find within the message using XLinq. The data retrieved by the query is used to form the correlation key to dispatch messages to the appropriate workflow instance.

## To set up, build, and run the sample

1. This sample exposes a workflow service using HTTP endpoints. To run this sample, proper URL ACLs must be added (see [Configuring HTTP and HTTPS](../../wcf/feature-details/configuring-http-and-https.md) for details), either by running Visual Studio as Administrator or by executing the following command at an elevated prompt to add the appropriate ACLs. Ensure that your Domain and Username are substituted.

    ```console
    netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%
    ```

2. Once the URL ACLs are added, use the following steps.

    1. Build the solution.

    2. Set multiple start-up projects by right-clicking the solution and selecting **Set Startup Projects**. Add **Service** and **Client** (in that order) as multiple start-up projects.

    3. Run the application. The client console shows a workflow  sending an order and receiving the purchase order id and then subsequently confirming the order. The Service window will show the requests being processed.
