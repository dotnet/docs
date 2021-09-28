---
description: "Learn more about: System.Web.Routing Integration"
title: "System.Web.Routing Integration"
ms.date: "03/30/2017"
ms.assetid: 31fe2a4f-5c47-4e5d-8ee1-84c524609d41
---
# System.Web.Routing Integration

When hosting a Windows Communication Foundation (WCF) service in Internet Information Service (IIS) you place a .svc file in the virtual directory. This .svc file specifies the service host factory to use as well as the class that implements the service. When making requests to the service you specify the .svc file in the URI, for example: `http://contoso.com/EmployeeServce.svc`. For programmers writing REST services, this type of URI is not optimal. URIs for REST services specify a specific resource and normally do not have any extensions. The <xref:System.Web.Routing> integration feature allows you to host a WCF REST service that responds to URIs without an extension. For more information about routing see [ASP.NET Routing](/previous-versions/aspnet/cc668201(v=vs.100)).  
  
## Using System.Web.Routing Integration  

 To use the <xref:System.Web.Routing> integration feature, you use the <xref:System.ServiceModel.Activation.ServiceRoute> class to create one or more routes and add them to the <xref:System.Web.Routing.RouteTable> in a Global.asax file. These routes specify the relative URIs that the service responds to. The following example shows how to do this.  
  
```aspx-csharp  
<%@ Application Language="C#" %>  
<%@ Import Namespace="System.Web.Routing" %>  
<%@ Import Namespace="System.ServiceModel.Activation" %>  
<%@ Import Namespace="System.ServiceModel.Web " %>  
  
<script RunAt="server">  
    void Application_Start(object sender, EventArgs e)  
    {  
        RegisterRoutes(RouteTable.Routes);  
    }  
  
    private void RegisterRoutes(RouteCollection routes)  
    {  
        routes.Add(new ServiceRoute("Customers", new WebServiceHostFactory(), typeof(Service)));
   }  
</script>  
```  
  
 This routes all requests with a relative URI that begins with Customers to the `Service` service.  
  
 In your Web.config file you must add the `System.Web.Routing.UrlRoutingModule` module, set the `runAllManagedModulesForAllRequests` attribute to `true`, and add the `UrlRoutingHandler` handler to the `<system.webServer>` element as shown in the following example.  
  
```xml  
<system.webServer>  
      <modules runAllManagedModulesForAllRequests="true">  
        <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />  
      </modules>  
      <handlers>  
        <add name="UrlRoutingHandler" preCondition="integratedMode" verb="*" path="UrlRouting.axd"/>  
      </handlers>  
    </system.webServer>  
```  
  
 This loads a module and handler required for routing. For more information, see [Routing](routing.md). You must also set the `aspNetCompatibilityEnabled` attribute to `true` in the `<serviceHostingEnvironment>` element as shown in the following example.  
  
```xml  
<system.serviceModel>  
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true"/>  
        <!-- ... -->  
    </system.serviceModel>  
```  
  
 The class that implements the service must enable ASP.NET compatibility requirements as shown in the following example.  
  
```csharp
[ServiceContract]  
[AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]  
    public class Service  
    {  
        // ...  
    }  
```  
  
## See also

- [WCF Web HTTP Programming Model](wcf-web-http-programming-model.md)
- [ASP.NET Routing](/previous-versions/aspnet/cc668201(v=vs.100))
