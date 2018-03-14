---
title: "Anticipating Adopting the Windows Communication Foundation: Easing Future Migration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f49664d9-e9e0-425c-a259-93f0a569d01b
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Anticipating Adopting the Windows Communication Foundation: Easing Future Migration
To ensure an easier future migration of new ASP.NET applications to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], follow the preceding recommendations as well as the following recommendations.  
  
## Protocols  
 Disable ASP.NET 2.0’s support for SOAP 1.2:  
  
```xml  
<configuration>  
     <system.web>  
      <webServices >  
          <protocols>  
           <remove name="HttpSoap12"/>  
          </protocols>    
      </webServices>  
     </system.web>   
</configuration>  
```  
  
 Doing so is advisable because [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] requires messages conforming to different protocols, like SOAP 1.1 and SOAP 1.2, to go by using different endpoints. If an ASP.NET 2.0 Web service is configured to support both SOAP 1.1 and SOAP 1.2, which is the default configuration, then it cannot be migrated forward to a single [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint at the original address that would be certainly be compatible with all of the ASP.NET Web service’s existing clients. Also choosing SOAP 1.2 instead of 1.1 will more severely restrict the clientele of the service.  
  
## Service Development  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows you to define service contracts by applying the <xref:System.ServiceModel.ServiceContractAttribute> either to interfaces or to classes. It is recommended to apply the attribute to an interface rather than to a class, because doing so creates a definition of a contract that can be variously implemented by any number of classes. ASP.NET 2.0 supports the option of applying the <xref:System.Web.Services.WebService> attribute to interfaces as well as classes. However, as mentioned already, there is a defect in ASP.NET 2.0, by which the Namespace parameter of the <xref:System.Web.Services.WebService> attribute has no effect when that attribute is applied to an interface rather than a class. Since it is generally advisable to modify the namespace of a service from the default value, http://tempuri.org, using the Namespace parameter of the <xref:System.Web.Services.WebService> attribute, one should continue defining ASP.NET Web Services by applying the <xref:System.ServiceModel.ServiceContractAttribute> attribute either to interfaces or to classes.  
  
-   Have as little code as possible in the methods by which those interfaces are defined. Have them delegate their work to other classes. New [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service types could then also delegate their substantive work to those classes.  
  
-   Provide explicit names for the operations of a service using the `MessageName` parameter of the <xref:System.Web.Services.WebMethodAttribute>.  
  
    ```  
    [WebMethod(MessageName="ExplicitName")]  
    string Echo(string input);  
    ```  
  
     Doing so is important, because the default names for operations in ASP.NET are different from the default names supplied by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. By providing explicit names, you avoid relying on the default ones.  
  
-   Do not implement ASP.NET Web service operations with polymorphic methods, because [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support implementing operations with polymorphic methods.  
  
-   Use the <xref:System.Web.Services.Protocols.SoapDocumentMethodAttribute> to provide explicit values for the SOAPAction HTTP headers by which HTTP requests will be routed to methods.  
  
    ```  
    [WebMethod]  
    [SoapDocumentMethod(RequestElementName="ExplicitAction")]  
    string Echo(string input);  
    ```  
  
     Taking this approach will circumvent having to rely on the default SOAPAction values used by ASP.NET and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] being the same.  
  
-   Avoid using SOAP extensions. If SOAP extensions are required, then determine whether the purpose for which they are being considered is a feature that is already provided by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. If that is indeed the case, then reconsider the choice to not adopt [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] right away.  
  
## State Management  
 Avoid having to maintain state in services. Not only does maintaining state tend to compromise the scalability of an application, but the state management mechanisms of ASP.NET and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are very different, although [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does support the ASP.NET mechanisms in ASP.NET compatibility mode.  
  
## Exception Handling  
 In designing the structures of the data types to be sent and received by a service, also design structures to represent the various types of exceptions that might occur within a service that one might wish to convey to a client.  
  
```  
[Serializable]  
[XmlRoot(  
     Namespace="ExplicitNamespace", IsNullable=true)]  
    public partial class AnticipatedException {  
  
     private string anticipatedExceptionInformationField;  
  
     public string AnticipatedExceptionInformation {  
      get {  
          return this.anticipatedExceptionInformationField;  
          }  
      set {  
          this.anticipatedExceptionInformationField = value;  
          }  
     }  
}  
```  
  
 Give such classes the ability to serialize themselves to XML:  
  
```  
public XmlNode ToXML()  
{  
     XmlSerializer serializer = new XmlSerializer(  
      typeof(AnticipatedException));  
     MemoryStream memoryStream = new MemoryStream();  
     XmlTextWriter writer = new XmlTextWriter(  
     memoryStream, UnicodeEncoding.UTF8);  
     serializer.Serialize(writer, this);  
     XmlDocument document = new XmlDocument();  
     document.LoadXml(new string(  
     UnicodeEncoding.UTF8.GetChars(  
     memoryStream.GetBuffer())).Trim());  
    return document.DocumentElement;  
}  
```  
  
 The classes can then be used to provide the details for explicitly thrown <xref:System.Web.Services.Protocols.SoapException> instances:  
  
```  
AnctipatedException exception = new AnticipatedException();  
exception.AnticipatedExceptionInformation = "…";  
throw new SoapException(  
     "Fault occurred",  
     SoapException.ClientFaultCode,  
     Context.Request.Url.AbsoluteUri,  
     exception.ToXML());  
```  
  
 These exception classes will be readily reusable with the[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]<xref:System.ServiceModel.FaultException%601> class to throw a new `FaultException<AnticipatedException>(anticipatedException);`  
  
## Security  
 The following are some security recommendations.  
  
-   Avoid using ASP.NET 2.0 Profiles, as using them would restrict the use of ASP.NET Integration Mode if the service was migrated to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
-   Avoid using ACLs to control access to services, as ASP.NET Web services supports ACLs using Internet Information Services (IIS), [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not—because ASP.NET Web services depend on IIS for hosting, and WCF does not necessarily have to be hosted in IIS.  
  
-   Do consider using ASP.NET 2.0 Role Providers for authorizing access to the resources of a service.  
  
## See Also  
 [Anticipating Adopting the Windows Communication Foundation: Easing Future Integration](../../../../docs/framework/wcf/feature-details/anticipating-adopting-the-wcf-easing-future-integration.md)
