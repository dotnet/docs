---
description: "Learn more about: How to: Use Configuration to Add an ASP.NET AJAX Endpoint"
title: "How to: Use Configuration to Add an ASP.NET AJAX Endpoint"
ms.date: "03/30/2017"
ms.assetid: 7cd0099e-dc3a-47e4-a38c-6e10f997f6ea
---
# How to: Use Configuration to Add an ASP.NET AJAX Endpoint

Windows Communication Foundation (WCF) allows you to create a service that makes an ASP.NET AJAX-enabled endpoint available that can be called from JavaScript on a client Web site. To create such an endpoint, you can either use a configuration file, as with all other Windows Communication Foundation (WCF) endpoints, or use a method that does not require any configuration elements. This topic demonstrates the configuration approach.  
  
 The part of the procedure that enables the service endpoint to become ASP.NET AJAX-enabled consists of configuring the endpoint to use the <xref:System.ServiceModel.WebHttpBinding> and to add the [\<enableWebScript>](../../configure-apps/file-schema/wcf/enablewebscript.md) endpoint behavior. After configuring the endpoint, the steps to implement and host the service are similar to those used by any WCF service. For a working example, see the [AJAX Service Using HTTP POST](../samples/ajax-service-using-http-post.md).  
  
 For more information about how to configure an ASP.NET AJAX endpoint without using configuration, see [How to: Add an ASP.NET AJAX Endpoint Without Using Configuration](how-to-add-an-aspnet-ajax-endpoint-without-using-configuration.md).  
  
## To create a basic WCF service  
  
1. Define a basic WCF service contract with an interface marked with the <xref:System.ServiceModel.ServiceContractAttribute> attribute. Mark each operation with the <xref:System.ServiceModel.OperationContractAttribute>. Be sure to set the <xref:System.ServiceModel.ServiceContractAttribute.Namespace%2A> property.  
  
    ```csharp
    [ServiceContract(Namespace = "MyService")]  
    public interface ICalculator  
    {  
        [OperationContract]  
         // This operation returns the sum of d1 and d2.  
        double Add(double n1, double n2);  
  
        //Other operations omitted…  
  
    }  
    ```  
  
2. Implement the `ICalculator` service contract with a `CalculatorService`.  
  
    ```csharp
    public class CalculatorService : ICalculator  
    {  
        public double Add(double n1, double n2)  
        {  
            return n1 + n2;  
        }
        // Other operations omitted…
    }
    ```  
  
3. Define a namespace for the `ICalculator` and `CalculatorService` implementations by wrapping them in a namespace block.  
  
    ```csharp
    namespace Microsoft.Ajax.Samples
    {  
        //Include the code for ICalculator and Caculator here.  
    }  
    ```  
  
## To create an ASP.NET AJAX endpoint for the service  
  
1. Create a behavior configuration and specify the [\<enableWebScript>](../../configure-apps/file-schema/wcf/enablewebscript.md) behavior for ASP.NET AJAX-enabled endpoints of the service.  
  
    ```xml  
    <system.serviceModel>  
        <behaviors>  
            <endpointBehaviors>  
                <behavior name="AspNetAjaxBehavior">  
                    <enableWebScript />  
                </behavior>  
            </endpointBehaviors>  
        </behaviors>  
    </system.serviceModel>  
    ```  
  
2. Create an endpoint for the service that uses the <xref:System.ServiceModel.WebHttpBinding> and the ASP.NET AJAX behavior defined in the previous step.  
  
    ```xml  
    <system.serviceModel>  
        <services>  
            <service name="Microsoft.Ajax.Samples.CalculatorService">  
                <endpoint address=""  
                    behaviorConfiguration="AspNetAjaxBehavior"
                    binding="webHttpBinding"  
                    contract="Microsoft.Ajax.Samples.ICalculator" />  
            </service>  
        </services>  
    </system.serviceModel>
    ```  
  
## To host the service in IIS  
  
1. To host the service in IIS, create a new file named service with a .svc extension in the application. Edit this file by adding the appropriate [\@ServiceHost](../../configure-apps/file-schema/wcf-directive/servicehost.md) directive information for the service. For example, the content in the service file for the `CalculatorService` sample contains the following information.  
  
    ```aspx-csharp
    <%@ServiceHost
    language=c#
    Debug="true"
    Service="Microsoft.Ajax.Samples.CalculatorService"  
    %>  
    ```  
  
2. For more information about hosting in IIS, see [How to: Host a WCF Service in IIS](how-to-host-a-wcf-service-in-iis.md).  
  
## To call the service  
  
1. The endpoint is configured at an empty address relative to the .svc file, so the service is now available and can be invoked by sending requests to service.svc/\<operation> - for example, service.svc/Add for the `Add` operation. You can use it by entering the endpoint URL into the Scripts collection of the ASP.NET AJAX Script Manager control. For an example, see the [AJAX Service Using HTTP POST](../samples/ajax-service-using-http-post.md).  
  
## See also

- [Creating WCF Services for ASP.NET AJAX](creating-wcf-services-for-aspnet-ajax.md)
- [How to: Migrate AJAX-Enabled ASP.NET Web Services to WCF](how-to-migrate-ajax-enabled-aspnet-web-services-to-wcf.md)
