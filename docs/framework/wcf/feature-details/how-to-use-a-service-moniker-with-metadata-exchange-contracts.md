---
title: "How to: Use a Service Moniker with Metadata Exchange Contracts"
ms.date: "03/30/2017"
ms.assetid: c41a07e5-cb9d-45d6-9ea4-34511e227faf
---
# How to: Use a Service Moniker with Metadata Exchange Contracts
After developing some new WCF services, you may decide that you want to be able to call these services from a script or a Visual Basic 6.0 application. One method would be to generate a WCF client assembly, register the assembly with COM, install the assembly in the GAC, and then reference the COM types from your Visual Basic code. When you distribute the application, you will have to distribute the WCF Client assembly as well. The user will then have to register the WCF client assembly with COM and place it in the GAC. WCF COM Interop also allows you to make the same service calls without relying on a WCF client assembly. The WCF moniker allows you to call any WCF service from any COM-compatible language (Visual Basic, VBScript, Visual Basic for Applications (VBA), and so on) by specifying a metadata exchange (Mex) endpoint URI that the service moniker uses to extract type information about the service. This topic describes how to call the Getting Started WCF sample using a WCF moniker that specifies a Mex endpoint.  
  
> [!NOTE]
>  The types defined by the WCF client assembly are never actually instantiated. The assembly is used only for metadata.  
  
### Using the service moniker with a Mex address  
  
1.  Build the Getting Started sample and use Internet Explorer to browse to its URL (http://localhost/ServiceModelSamples/Service.svc) to ensure that the service is working.  
  
2.  Create a Visual Basic script or Visual Basic application that contains the following code:  
  
    ```  
    monString = "service:mexaddress=http://localhost/ServiceModelSamples/Service.svc/MEX"  
    monString = monString + ", address=http://localhost/ServiceModelSamples/Service.svc"  
    monString = monString + ", contract=ICalculator, contractNamespace=http://Microsoft.ServiceModel.Samples"  
    monString = monString + ", binding=WSHttpBinding_ICalculator, bindingNamespace=http://Microsoft.ServiceModel.Samples"  
  
    Set calc = GetObject(monString)  
    MsgBox calc.Add(3, 4)  
    ```  
  
3.  Run the Visual Basic application or script.  
  
    > [!NOTE]
    >  The service you are calling must expose a Mex endpoint for the moniker to be able to read the metadata from the service. For more information, see [How to: Publish Metadata for a Service Using a Configuration File](../../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md).  
  
    > [!NOTE]
    >  If the moniker is malformed or if the service is unavailable, the call to `GetObject` will return an error saying "Invalid Syntax."  If you receive this error, make sure the moniker you are using is correct and the service is available.  
  
## See also

- [How to: Use the Windows Communication Foundation Service Moniker without Registration](../../../../docs/framework/wcf/feature-details/use-the-wcf-service-moniker-without-registration.md)
- [How to: Use a Service Moniker with WSDL Contracts](../../../../docs/framework/wcf/feature-details/how-to-use-a-service-moniker-with-wsdl-contracts.md)
