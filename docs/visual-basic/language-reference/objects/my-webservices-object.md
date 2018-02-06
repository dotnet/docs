---
title: "My.WebServices Object"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "My.WebServices"
  - "My.MyProject.WebServices"
helpviewer_keywords: 
  - "My.WebServices object"
ms.assetid: f188dc05-2c75-41b6-bb68-122d1c3110a2
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# My.WebServices Object
Provides properties for creating and accessing a single instance of each XML Web service referenced by the current project.  
  
## Remarks  
 The `My.WebServices` object provides an instance of each Web service referenced by the current project. Each instance is instantiated on demand. You can access these Web services through the properties of the `My.WebServices` object. The name of the property is the same as the name of the Web service that the property accesses. Any class that inherits from <xref:System.Web.Services.Protocols.SoapHttpClientProtocol> is a Web service. For information about adding Web services to a project, see [Accessing Application Web Services](../../../visual-basic/developing-apps/programming/accessing-application-web-services.md).  
  
 The `My.WebServices` object exposes only the Web services associated with the current project. It does not provide access to Web services declared in referenced DLLs. To access a Web service that a DLL provides, you must use the qualified name of the Web service, in the form *DllName*.*WebServiceName*. For more information, see [Accessing Application Web Services](../../../visual-basic/developing-apps/programming/accessing-application-web-services.md).  
  
 The object and its properties are not available for Web applications.  
  
## Properties  
 Each property of the `My.WebServices` object provides access to an instance of a Web service referenced by the current project. The name of the property is the same as the name of the Web service that the property accesses, and the property type is the same as the Web service's type.  
  
> [!NOTE]
>  If there is a name collision, the property name for accessing a Web service is *RootNamespace*_*Namespace*\_*ServiceName*. For example, consider two Web services named `Service1`. If one of these services is in the root namespace `WindowsApplication1` and in the namespace `Namespace1`, you would access that service by using `My.WebServices.WindowsApplication1_Namespace1_Service1`.  
  
 When you first access one of the `My.WebServices` object's properties, it creates a new instance of the Web service and stores it. Subsequent accesses of that property return that instance of the Web service.  
  
 You can dispose of a Web service by assigning `Nothing` to the property for that Web service. The property setter assigns `Nothing` to the stored value. If you assign any value other than `Nothing` to the property, the setter throws an <xref:System.ArgumentException> exception.  
  
 You can test whether a property of the `My.WebServices` object stores an instance of the Web service by using the `Is` or `IsNot` operator. You can use those operators to check if the value of the property is `Nothing`.  
  
> [!NOTE]
>  Typically, the `Is` or `IsNot` operator has to read the value of the property to perform the comparison. However, if the property currently stores `Nothing`, the property creates a new instance of the Web service and then returns that instance. However, the Visual Basic compiler treats the properties of the `My.WebServices` object specially, and allows the `Is` or `IsNot` operator to check the status of the property without altering its value.  
  
## Example  
 This example calls the `FahrenheitToCelsius` method of the `TemperatureConverter` XML Web service, and returns the result.  
  
 [!code-vb[VbVbalrMyWebService#1](../../../visual-basic/language-reference/objects/codesnippet/VisualBasic/my-webservices-object_1.vb)]  
  
 For this example to work, your project must reference a Web service named `Converter`, and that Web service must expose the `ConvertTemperature` method. For more information, see [Accessing Application Web Services](../../../visual-basic/developing-apps/programming/accessing-application-web-services.md).  
  
 This code does not work in a Web application project.  
  
## Requirements  
  
### Availability by Project Type  
  
|Project type|Available|  
|---|---|  
|Windows Application|**Yes**|  
|Class Library|**Yes**|  
|Console Application|**Yes**|  
|Windows Control Library|**Yes**|  
|Web Control Library|**Yes**|  
|Windows Service|**Yes**|  
|Web Site|No|  
  
## See Also  
 <xref:System.Web.Services.Protocols.SoapHttpClientProtocol>  
 <xref:System.ArgumentException>  
 [Accessing Application Web Services](../../../visual-basic/developing-apps/programming/accessing-application-web-services.md)
