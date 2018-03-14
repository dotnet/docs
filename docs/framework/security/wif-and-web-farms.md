---
title: "WIF and Web Farms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fc3cd7fa-2b45-4614-a44f-8fa9b9d15284
caps.latest.revision: 9
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# WIF and Web Farms
When you use Windows Identity Foundation (WIF) to secure the resources of a relying party (RP) application that is deployed in a web farm, you must take specific steps to ensure that WIF can process tokens from instances of the RP application running on different computers in the farm. This processing includes validating session token signatures, encrypting and decrypting session tokens, caching session tokens, and detecting replayed security tokens.  
  
 In the typical case, when WIF is used to secure resources of an RP application – whether the RP is running on a single computer or in a web farm -- a session is established with the client based on the security token that was obtained from the security token service (STS). This is to avoid forcing the client to have to authenticate at the STS for every application resource that is secured using WIF. For more information about how WIF handles sessions, see [WIF Session Management](../../../docs/framework/security/wif-session-management.md).  
  
 When default settings are used, WIF does the following:  
  
-   It uses an instance of the <xref:System.IdentityModel.Tokens.SessionSecurityTokenHandler> class to read and write a session token (an instance of the <xref:System.IdentityModel.Tokens.SessionSecurityToken> class) that carries the claims and other information about the security token that was used for authentication as well as information about the session itself. The session token is packaged and stored in a session cookie. By default, <xref:System.IdentityModel.Tokens.SessionSecurityTokenHandler> uses the <xref:System.IdentityModel.ProtectedDataCookieTransform> class, which uses the Data Protection API (DPAPI), to protect the session token. The DPAPI provides protection by using the user or machine credentials and stores the key data in the user profile.  
  
-   It uses a default, in-memory implementation of the <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache> class to store and process the session token.  
  
 These default settings work in scenarios in which the RP application is deployed on a single computer; however, when deployed in a web farm, each HTTP request may be sent to and processed by a different instance of the RP application running on a different computer. In this scenario, the default WIF settings described above will not work because both token protection and token caching are dependent on a specific computer.  
  
 To deploy an RP application in a web farm, you must ensure that the processing of session tokens (as well as of replayed tokens) is not dependent on the application running on a specific computer. One way to do this is to implement your RP application so that it uses the functionality provided by the ASP.NET `<machineKey>` configuration element and provides distributed caching for processing session tokens and replayed tokens. The `<machineKey>` element allows you to specify the keys needed to validate, encrypt, and decrypt tokens in a configuration file, which enables you to specify the same keys on different computers in the web farm. WIF provides a specialized session token handler, the <xref:System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler>, that protects tokens by using the keys specified in the `<machineKey>` element. To implement this strategy, you can follow these guidelines:  
  
-   Use the ASP.NET `<machineKey>` element in configuration to explicitly specify signing and encryption keys that can be used across computers in the farm. The following XML shows the specification of the `<machineKey>` element under the `<system.web>` element in a configuration file.  
  
    ```xml  
    <machineKey compatibilityMode="Framework45" decryptionKey="CC510D … 8925E6" validationKey="BEAC8 … 6A4B1DE" />  
    ```  
  
-   Configure the application to use the <xref:System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler> by adding it to the token handler collection. You must first remove the <xref:System.IdentityModel.Tokens.SessionSecurityTokenHandler> (or any handler derived from the <xref:System.IdentityModel.Tokens.SessionSecurityTokenHandler> class) from the token handler collection if such a handler is present. The <xref:System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler> uses the <xref:System.IdentityModel.Services.MachineKeyTransform> class, which protects the session cookie data by using the cryptographic material specified in the `<machineKey>` element. The following XML shows how to add the <xref:System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler> to a token handler collection.  
  
    ```xml  
    <securityTokenHandlers>  
      <remove type="System.IdentityModel.Tokens.SessionSecurityTokenHandler, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
      <add type="System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
    </securityTokenHandlers>  
    ```  
  
-   Derive from <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache> and implement distributed caching, that is, a cache that is accessible from all computers in the farm on which the RP might run. Configure the RP to use your distributed cache by specifying the [\<sessionSecurityTokenCache>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/sessionsecuritytokencache.md) element in the configuration file. You can override the <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache.LoadCustomConfiguration%2A?displayProperty=nameWithType> method in your derived class to implement child elements of the `<sessionSecurityTokenCache>` element if they are required.  
  
    ```xml  
    <caches>  
      <sessionSecurityTokenCache type="MyCacheLibrary.MySharedSessionSecurityTokenCache, MyCacheLibrary">  
        <!—optional child configuration elements, if implemented by the derived class -->  
      </sessionSecurityTokenCache>  
    </caches>  
    ```  
  
     One way to implement distributed caching is to provide a WCF front end for your custom cache. For more information about implementing a WCF caching service, see [The WCF Caching Service](#BKMK_TheWCFCachingService). For more information about implementing a WCF client that the RP application can use to call the caching service, see [The WCF Caching Client](#BKMK_TheWCFClient).  
  
-   If your application detects replayed tokens you must follow a similar distributed caching strategy for the token replay cache by deriving from <xref:System.IdentityModel.Tokens.TokenReplayCache> and pointing to your token replay caching service in the [\<tokenReplayCache>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/tokenreplaycache.md) configuration element.  
  
> [!IMPORTANT]
>  All of the example XML and code in this topic is taken from the [ClaimsAwareWebFarm](http://go.microsoft.com/fwlink/?LinkID=248408) (http://go.microsoft.com/fwlink/?LinkID=248408) sample.  
  
> [!IMPORTANT]
>  The examples in this topic are provided as-is and are not intended to be used in production code without modification.  
  
<a name="BKMK_TheWCFCachingService"></a>   
## The WCF Caching Service  
 The following interface defines the contract between the WCF caching service and the WCF client used by the relying party application to communicate with it. It essentially exposes the methods of the <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache> class as service operations.  
  
```  
[ServiceContract()]  
public interface ISessionSecurityTokenCacheService  
{  
    [OperationContract]  
    void AddOrUpdate(string endpointId, string contextId, string keyGeneration, SessionSecurityToken value, DateTime expiryTime);  
  
    [OperationContract]  
    IEnumerable<SessionSecurityToken> GetAll(string endpointId, string contextId);  
  
    [OperationContract]  
    SessionSecurityToken Get(string endpointId, string contextId, string keyGeneration);  
  
    [OperationContract(Name = "RemoveAll")]  
    void RemoveAll(string endpointId, string contextId);  
  
    [OperationContract(Name = "RemoveAllByEndpointId")]  
    void RemoveAll(string endpointId);  
  
    [OperationContract]  
    void Remove(string endpointId, string contextId, string keyGeneration);  
}  
```  
  
 The following code shows the implementation of the WCF caching service. In this example, the default, in-memory session token cache implemented by WIF is used. Alternatively, you could implement a durable cache backed by a database. `ISessionSecurityTokenCacheService` defines the interface shown above. In this example, not all of the methods required to implement the interface are shown for brevity.  
  
```  
using System;  
using System.Collections.Generic;  
using System.IdentityModel.Configuration;  
using System.IdentityModel.Tokens;  
using System.ServiceModel;  
using System.Xml;  
  
namespace WcfSessionSecurityTokenCacheService  
{  
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]  
    public class SessionSecurityTokenCacheService : ISessionSecurityTokenCacheService  
    {  
        SessionSecurityTokenCache internalCache;  
  
        // sets the internal cache used by the service to the default WIF in-memory cache.  
        public SessionSecurityTokenCacheService()  
        {  
            internalCache = new IdentityModelCaches().SessionSecurityTokenCache;  
        }  
  
        ...  
  
        public SessionSecurityToken Get(string endpointId, string contextId, string keyGeneration)  
        {  
            // Delegates to the default, in-memory MruSessionSecurityTokenCache used by WIF  
            SessionSecurityToken token = internalCache.Get(new SessionSecurityTokenCacheKey(endpointId, GetContextId(contextId), GetKeyGeneration(keyGeneration)));  
            return token;  
        }  
  
        ...  
  
        private static UniqueId GetContextId(string contextIdString)  
        {  
            return contextIdString == null ? null : new UniqueId(contextIdString);  
        }  
  
        private static UniqueId GetKeyGeneration(string keyGenerationString)  
        {  
            return keyGenerationString == null ? null : new UniqueId(keyGenerationString);  
        }  
    }  
}  
```  
  
<a name="BKMK_TheWCFClient"></a>   
## The WCF Caching Client  
 This section shows the implementation of a class that derives from <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache> and that delegates calls to the caching service. You configure the RP application to use this class through the [\<sessionSecurityTokenCache>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/sessionsecuritytokencache.md) element as in the following XML  
  
```xml  
<caches>  
  <sessionSecurityTokenCache type="CacheLibrary.SharedSessionSecurityTokenCache, CacheLibrary">  
    <!--cacheServiceAddress points to the centralized session security token cache service running in the web farm.-->  
    <cacheServiceAddress url="http://localhost:4161/SessionSecurityTokenCacheService.svc" />  
  </sessionSecurityTokenCache>  
</caches>  
```  
  
 The class overrides the <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache.LoadCustomConfiguration%2A> method to get the service endpoint from the custom `<cacheServiceAddress>` child element of the `<sessionSecurityTokenCache>` element. It uses this endpoint to initialize an `ISessionSecurityTokenCacheService` channel over which it can communicate with the service.  In this example, not all of the methods required to implement the <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache> class are shown for brevity.  
  
```  
using System;  
using System.Configuration;  
using System.IdentityModel.Configuration;  
using System.IdentityModel.Tokens;  
using System.ServiceModel;  
using System.Xml;  
  
namespace CacheLibrary  
{  
    /// <summary>  
    /// This class acts as a proxy to the WcfSessionSecurityTokenCacheService.  
    /// </summary>  
    public class SharedSessionSecurityTokenCache : SessionSecurityTokenCache, ICustomIdentityConfiguration  
    {  
        private ISessionSecurityTokenCacheService WcfSessionSecurityTokenCacheServiceClient;  
  
        internal SharedSessionSecurityTokenCache()  
        {  
        }  
  
        /// <summary>  
        /// Creates a client channel to call the service host.  
        /// </summary>  
        protected void Initialize(string cacheServiceAddress)  
        {  
            if (this.WcfSessionSecurityTokenCacheServiceClient != null)  
            {  
                return;  
            }  
  
            ChannelFactory<ISessionSecurityTokenCacheService> cf = new ChannelFactory<ISessionSecurityTokenCacheService>(  
                new WS2007HttpBinding(SecurityMode.None),  
                new EndpointAddress(cacheServiceAddress));  
            this.WcfSessionSecurityTokenCacheServiceClient = cf.CreateChannel();  
        }  
  
        #region SessionSecurityTokenCache Members  
        // Delegates the following operations to the centralized session security token cache service in the web farm.  
  
        ...  
  
        public override SessionSecurityToken Get(SessionSecurityTokenCacheKey key)  
        {  
            return this.WcfSessionSecurityTokenCacheServiceClient.Get(key.EndpointId, GetContextIdString(key), GetKeyGenerationString(key));  
        }  
  
        ...  
  
        #endregion  
  
        #region ICustomIdentityConfiguration Members  
        // Called from configuration infrastructure to load custom elements  
        public void LoadCustomConfiguration(XmlNodeList nodeList)  
        {  
            // Retrieve the endpoint address of the centralized session security token cache service running in the web farm  
            if (nodeList.Count == 0)  
            {  
                throw new ConfigurationException("No child config element found under <sessionSecurityTokenCache>.");  
            }  
  
            XmlElement cacheServiceAddressElement = nodeList.Item(0) as XmlElement;  
            if (cacheServiceAddressElement.LocalName != "cacheServiceAddress")  
            {  
                throw new ConfigurationException("First child config element under <sessionSecurityTokenCache> is expected to be <cacheServiceAddress>.");  
            }  
  
            string cacheServiceAddress = null;  
            if (cacheServiceAddressElement.Attributes["url"] != null)  
            {  
                cacheServiceAddress = cacheServiceAddressElement.Attributes["url"].Value;  
            }  
            else  
            {  
                throw new ConfigurationException("<cacheServiceAddress> is expected to contain a 'url' attribute.");  
            }  
  
            // Initialize the proxy to the WebFarmSessionSecurityTokenCacheService  
            this.Initialize(cacheServiceAddress);  
        }  
        #endregion  
  
        private static string GetKeyGenerationString(SessionSecurityTokenCacheKey key)  
        {  
            return key.KeyGeneration == null ? null : key.KeyGeneration.ToString();  
        }  
  
        private static string GetContextIdString(SessionSecurityTokenCacheKey key)  
        {  
            return GetContextIdString(key.ContextId);  
        }  
  
        private static string GetContextIdString(UniqueId contextId)  
        {  
            return contextId == null ? null : contextId.ToString();  
        }  
    }  
}  
```  
  
## See Also  
 <xref:System.IdentityModel.Tokens.SessionSecurityTokenCache>  
 <xref:System.IdentityModel.Tokens.SessionSecurityTokenHandler>  
 <xref:System.IdentityModel.Services.Tokens.MachineKeySessionSecurityTokenHandler>  
 [WIF Session Management](../../../docs/framework/security/wif-session-management.md)
