---
description: "Learn more about: How to: Use a Service Moniker with WSDL Contracts"
title: "How to: Use a Service Moniker with WSDL Contracts"
ms.date: "03/30/2017"
ms.assetid: a88d9650-bb50-4f48-8c85-12f5ce98a83a
---
# How to: Use a Service Moniker with WSDL Contracts

There are situations when you may want to have a completely self-contained COM Interop client. The service you want to call may not expose a MEX endpoint, and the WCF client DLL may not be registered for COM interop. In these cases, you can create a WSDL file that describes the service and pass it into the WCF service moniker. This topic describes how to call the Getting Started WCF sample using a WCF WSDL moniker.  
  
### Using the WSDL service moniker  
  
1. Open and build the GettingStarted sample solution.  
  
2. Open Internet Explorer and browse to `http://localhost/ServiceModelSamples/Service.svc` to make sure that the service is working.  
  
3. In the Service.cs file, add the following attribute on the CalculatorService class:  
  
     [!code-csharp[S_WSDL_Client#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_wsdl_client/cs/service.cs#0)]  
  
4. Add a binding namespace to the service App.config:  

5. Create a WSDL file for the application to read. Because the namespaces were added in steps 3 and 4, you can use IE to query for the entire WSDL description of the service by browsing to `http://localhost/ServiceModelSamples/Service.svc?wsdl`. You can then save the file from Internet Explorer as serviceWSDL.xml. If you do not specify the namespaces in steps 3 and 4, the WSDL document returned from querying the above URL will not be the complete WSDL. The WSDL document returned will include several import statements that import other WSDL documents. You will have to go through each import statement and build the complete WSDL document, combining the WSDL returned from the service with the WSDL imported.  
  
6. Open Visual Basic 6.0 and create a new Standard .exe file. Add a button to the form and double-click the button to add the following code to the Click handler:  
  
    ```vb
    ' Open the WSDL contract file and read it all into the wsdlContract string.  
    Const ForReading = 1  
    Set objFSO = CreateObject("Scripting.FileSystemObject")  
    Set objFile = objFSO.OpenTextFile("c:\serviceWsdl.xml", ForReading)  
    wsdlContract = objFile.ReadAll  
    objFile.Close  
  
    ' Create a string for the service moniker including the content of the WSDL contract file.  
    wsdlMonikerString = "service4:address='http://localhost/ServiceModelSamples/service.svc'"  
    wsdlMonikerString = wsdlMonikerString + ", wsdl='" & wsdlContract & "'"  
    wsdlMonikerString = wsdlMonikerString + ", binding=WSHttpBinding_ICalculator, bindingNamespace='http://Microsoft.ServiceModel.Samples'"  
    wsdlMonikerString = wsdlMonikerString + ", contract=ICalculator, contractNamespace='http://Microsoft.ServiceModel.Samples'"  
  
    ' Create the service moniker object.  
    Set wsdlServiceMoniker = GetObject(wsdlMonikerString)  
  
    ' Call the service operations using the moniker object.  
    MsgBox "WSDL service moniker: 145 - 76.54 = " & wsdlServiceMoniker.Subtract(145, 76.54)  
    ```  
  
    > [!NOTE]
    > If the moniker is malformed or if the service is unavailable the call to `GetObject` will return an error saying "Invalid Syntax".  If you receive this error, make sure the moniker you are using is correct and the service is available.  
  
7. Run the Visual Basic application. A message box will be displayed with the results of calling Subtract(145, 76.54).  
  
## See also

- [Getting Started](/previous-versions/dotnet/framework/wcf/samples/getting-started-sample)
- [Integrating with COM Applications Overview](integrating-with-com-applications-overview.md)
