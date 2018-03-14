---
title: "Caching Support for WCF Web HTTP Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7f8078e0-00d9-415c-b8ba-c1b6d5c31799
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Caching Support for WCF Web HTTP Services
[!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] enables you to use the declarative caching mechanism already available in ASP.NET in your WCF Web HTTP services. This allows you to cache responses from your WCF Web HTTP service operations. When a user sends an HTTP GET to your service that is configured for caching, ASP.NET sends back the cached response and the service method is not called. When the cache expires, the next time a user sends an HTTP GET, your service method is called and the response is once again cached. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] ASP.NET caching, see [ASP.NET Caching Overview](http://go.microsoft.com/fwlink/?LinkId=152534)  
  
## Basic Web HTTP Service Caching  
 To enable WEB HTTP service caching you must first enable ASP.NET compatibility by applying the <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute> to the service setting <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute.RequirementsMode%2A> to <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed> or <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Required>.  
  
 [!INCLUDE[netfx40_short](../../../../includes/netfx40-short-md.md)] introduces a new attribute called <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute> that allows you to specify a cache profile name. This attribute is applied to a service operation. The following example applies the <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute> to a service to enable ASP.NET compatibility and configures the `GetCustomer` operation for caching. The <!--zz<xref:System.ServiceModel.Activation.AspNetCacheProfileAttribute>--> `System.ServiceModel.Activation.AspNetCacheProfileAttribute` attribute specifies a cache profile that contains the cache settings to be used.  
  
```csharp
[ServiceContract] 
[AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
public class Service
{
    [WebGet(UriTemplate = "{id}")]
    [AspNetCacheProfile("CacheFor60Seconds")]
    public Customer GetCustomer(string id)
    {
        // ...
    }
}
```  
  
 You must also turn on ASP.NET compatibility mode in the Web.config file as shown in the following example.  
  
```xml
<system.serviceModel>
  <serviceHostingEnvironment aspNetCompatibilityEnabled="true" />
</system.serviceModel>
```
  
> [!WARNING]
>  If ASP.NET compatibility mode is not turned on and the <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute> is used an exception is thrown.  
  
 The cache profile name specified by the <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute> identifies a cache profile that is added to your Web.config configuration file. The cache profile is defined with in a <`outputCacheSetting`> element as shown in the following configuration example.  
  
```xml
<!-- ...  -->
<system.web>  
   <caching>  
      <outputCacheSettings>  
         <outputCacheProfiles>  
            <add name="CacheFor60Seconds" duration="60" varyByParam="none" sqlDependency="MyTestDatabase:MyTable"/>  
         </outputCacheProfiles>  
      </outputCacheSettings>  
   </caching>  
   <!-- ... -->  
</system.web>  
```  
  
 This is the same configuration element that is available to ASP.NET applications. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] ASP.NET cache profiles, see <xref:System.Web.Configuration.OutputCacheProfile>. For Web HTTP services, the most important attributes in the cache profile are: `cacheDuration` and `varyByParam`. Both of these attributes are required. `cacheDuration` sets the amount of time a response should be cached in seconds. `varyByParam` allows you to specify a query string parameter that is used to cache responses. All requests made with different query string parameter values are cached separately. For example, once an initial request is made to http://MyServer/MyHttpService/MyOperation?param=10 all subsequent requests made with the same URI would be returned the cached response (so long as the cache duration has not elapsed). Responses for a similar request that is the same but has a different value for the parameter query string parameter are cached separately. If you do not want this separate caching behavior, set `varyByParam` to "none".  
  
## SQL Cache Dependency  
 Web HTTP service responses can also be cached with a SQL cache dependency. If your WCF Web HTTP service depends on data stored in a SQL database, you may want to cache the service's response and invalidate the cached response when data in the SQL database table changes. This behavior is configured completely within the Web.config file. You must first define a connection string in the <`connectionStrings`> element.  
  
```xml
<connectionStrings>
  <add name="connectString"
       connectionString="Data Source=MyService;Initial Catalog=MyTestDatabase;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```  
  
 Then you must enable SQL cache dependency within a <`caching`> element within the <`system.web`> element as shown in the following config example.  
  
```xml  
<system.web>
  <caching>
    <sqlCacheDependency enabled="true" pollTime="1000">
      <databases>
        <add name="MyTestDatabase" connectionStringName="connectString" />
      </databases>
    </sqlCacheDependency>
    <!-- ... -->
  </caching>
  <!-- ... -->
</system.web>
```  
  
 Here SQL cache dependency is enabled and a polling time of 1000 milliseconds is set. Each time the polling time elapses the database table is checked for updates. If changes are detected the contents of the cache are removed and the next time the service operation is invoked a new response is cached. Within the <`sqlCacheDependency`> element add the databases and reference the connection strings within the <`databases`> element as shown in the following example.  
  
```xml  
<system.web>
  <caching>
    <sqlCacheDependency enabled="true" pollTime="1000">
      <databases>
        <add name="MyTestDatabase" connectionStringName="connectString" />
      </databases>  
    </sqlCacheDependency>  
    <!-- ... -->  
  </caching>  
  <!-- ... -->  
</system.web>  
```  
  
 Next you must configure the output cache settings within the <`caching`> element as shown in the following example.  
  
```xml
<system.web>
  <caching>  
    <!-- ...  -->
    <outputCacheSettings>
      <outputCacheProfiles>
        <add name="CacheFor60Seconds" duration="60" varyByParam="none" sqlDependency="MyTestDatabase:MyTable" />
      </outputCacheProfiles>
    </outputCacheSettings>
  </caching>
  <!-- ... -->
</system.web>
```  
  
 Here the cache duration is set to 60 seconds, `varyByParam` is set to none and `sqlDependency` is set to a semicolon delimited list of database name/table pairs separated by colons. When data in `MyTable` is changed the cached response for the service operation is removed and when the operation is invoked a new response is generated (by calling the service operation), cached, and returned to the client.  
  
> [!IMPORTANT]
>  For ASP.NET to access a SQL database, you must use the [ASP.NET SQL Server Registration Tool](http://go.microsoft.com/fwlink/?LinkId=152536). In addition you must allow the appropriate user account access to the database and table. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Accessing SQL Server from a Web Application](http://go.microsoft.com/fwlink/?LinkId=178988).  
  
## Conditional HTTP GET Based Caching  
 In Web HTTP scenarios a conditional HTTP GET is often used by services to implement intelligent HTTP caching as described in the [HTTP Specification](http://go.microsoft.com/fwlink/?LinkId=165800). To do this the service must set the value of the ETag header in the HTTP response. It also must check the If-None-Match header in the HTTP request to see whether any of the ETag specified matches the current ETag.  
  
 For GET and HEAD requests, <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> takes an ETag value and checks it against the If-None-Match header of the request. If the header is present and there is a match, a <xref:System.ServiceModel.Web.WebFaultException> with a HTTP status code 304 (Not Modified) is thrown and an ETag header is added to the response with the matching ETag.  
  
 One overload of the <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> method takes a last modified date and checks it against the If-Modified-Since header of the request. If the header is present and the resource has not been modified since, a <xref:System.ServiceModel.Web.WebFaultException> with an HTTP status code 304 (Not Modified) is thrown.  
  
 For PUT, POST, and DELETE requests, <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> takes the current ETag value of a resource. If the current ETag value is null, the method checks that the If-None- Match header has a value of "*".  If the current ETag value is not a default value, then the method checks the current ETag value against the If- Match header of the request. In either case, the method throws a <xref:System.ServiceModel.Web.WebFaultException> with an HTTP status code 412 (Precondition Failed) if the expected header is not present in the request or its value does not satisfy the conditional check and sets the ETag header of the response to the current ETag value.  
  
 Both the `CheckConditional` methods and the <xref:System.ServiceModel.Web.OutgoingWebResponseContext.SetETag%2A> method ensures that the ETag value set on the response header is a valid ETag according to the HTTP specification. This includes surrounding the ETag value in double quotes if they are not already present and properly escaping any internal double quote characters. Weak ETag comparison is not supported.  
  
 The following example shows how to use these methods.  
  
```csharp
[WebGet(UriTemplate = "{id}"), Description("Returns the specified customer from customers collection. Returns NotFound if there is no such customer. Supports conditional GET.")]
public Customer GetCustomer(string id)
{
    lock (writeLock)
    {
        // return NotFound if there is no item with the specified id.
        object itemEtag = customerEtags[id];
        if (itemEtag == null)
        {
            throw new WebFaultException(HttpStatusCode.NotFound);
        }
  
        // return NotModified if the client did a conditional GET and the customer item has not changed
        // since when the client last retrieved it
        WebOperationContext.Current.IncomingRequest.CheckConditionalRetrieve((long)itemEtag);
        Customer result = this.customers[id] as Customer;
        
        // set the customer etag before returning the result
        WebOperationContext.Current.OutgoingResponse.SetETag((long)itemEtag);
        return result;
    }
}
```  
  
## Security Considerations  
 Requests that require authorization should not have their responses cached, because the authorization is not performed when the response is served from the cache.  Caching such responses would introduce a serious security vulnerability.  Usually, requests that require authorization provide user-specific data and therefore server-side caching is not even beneficial.  In such situations, client-side caching or simply not caching at all will be more appropriate.
