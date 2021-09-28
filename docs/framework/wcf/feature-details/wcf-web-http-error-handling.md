---
description: "Learn more about: WCF Web HTTP Error Handling"
title: "WCF Web HTTP Error Handling"
ms.date: "03/30/2017"
ms.assetid: 02891563-0fce-4c32-84dc-d794b1a5c040
---
# WCF Web HTTP Error Handling

Windows Communication Foundation (WCF) Web HTTP error handling enables you to return errors from WCF Web HTTP services that specify an HTTP status code and return error details using the same format as the operation (for example, XML or JSON).  
  
## WCF Web HTTP Error Handling  

 The <xref:System.ServiceModel.Web.WebFaultException> class defines a constructor that allows you to specify an HTTP status code. This status code is then returned to the client. A generic version of the <xref:System.ServiceModel.Web.WebFaultException> class, <xref:System.ServiceModel.Web.WebFaultException%601> enables you to return a user-defined type that contains information about the error that occurred. This custom object is serialized using the format specified by the operation and returned to the client. The following example shows how to return an HTTP status code.  
  
```csharp
public string Operation1()
{
    // Operation logic  
   // ...
   throw new WebFaultException(HttpStatusCode.Forbidden);
}  
```  
  
 The following example shows how to return an HTTP status code and extra information in a user-defined type. `MyErrorDetail` is a user-defined type that contains extra information about the error that occurred.  
  
```csharp
public string Operation2()
{
   // Operation logic  
   // ...
   MyErrorDetail detail = new MyErrorDetail()
   {  
      Message = "Error Message",  
      ErrorCode = 123,  
   }  
   throw new WebFaultException<MyErrorDetail>(detail, HttpStatusCode.Forbidden);  
}  
```  
  
 The preceding code returns an HTTP response with the forbidden status code and a body that contains an instance of the `MyErrorDetails` object. The format of the `MyErrorDetails` object is determined by:  
  
- The value of the `ResponseFormat` parameter of the <xref:System.ServiceModel.Web.WebGetAttribute> or <xref:System.ServiceModel.Web.WebInvokeAttribute> attribute specified on the service operation.  
  
- The value of <xref:System.ServiceModel.Description.WebHttpBehavior.AutomaticFormatSelectionEnabled%2A>.  
  
- The value of the <xref:System.ServiceModel.Web.OutgoingWebResponseContext.Format%2A> property by accessing the <xref:System.ServiceModel.Web.OutgoingWebResponseContext>.  
  
 For more information about how these values affect the formatting of the operation, see [WCF Web HTTP Formatting](wcf-web-http-formatting.md).  
  
 <xref:System.ServiceModel.Web.WebFaultException> is a <xref:System.ServiceModel.FaultException> and therefore can be used as the fault exception programming model for services that expose SOAP endpoints as well as web HTTP endpoints.  
  
## See also

- [WCF Web HTTP Programming Model](wcf-web-http-programming-model.md)
- [WCF Web HTTP Formatting](wcf-web-http-formatting.md)
- [Defining and Specifying Faults](../defining-and-specifying-faults.md)
- [Handling Exceptions and Faults](../extending/handling-exceptions-and-faults.md)
- [Sending and Receiving Faults](../sending-and-receiving-faults.md)
