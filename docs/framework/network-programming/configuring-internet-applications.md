---
title: "Configuring Internet Applications"
description: Learn how to use the <system.Net> element to configure internet applications in the .NET Framework. This article contains example code.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "downloading Internet resources, default proxy"
  - "sending data, default proxy"
  - "receiving data, default proxy"
  - "downloading Internet resources, configuring Internet applications"
  - "protocol-specific modules"
  - "custom authentication modules"
  - "receiving data, configuring Internet applications"
  - "configuration settings [.NET Framework], Internet applications"
  - "requesting data from Internet, configuring Internet applications"
  - "requesting data from Internet, default proxy"
  - "response to Internet request, default proxy"
  - "Internet, configuring Internet applications"
  - "response to Internet request, configuring Internet applications"
  - "default proxy"
  - "network resources, default proxy"
  - "sending data, configuring Internet applications"
  - "network resources, configuring Internet applications"
  - "Internet, default proxy"
ms.topic: how-to
---
# Configuring Internet Applications

The [\<system.Net> Element (Network Settings)](../configure-apps/file-schema/network/system-net-element-network-settings.md) configuration element contains network configuration information for applications. Using the [\<system.Net> Element (Network Settings)](../configure-apps/file-schema/network/system-net-element-network-settings.md) element, you can set proxy servers, set connection management parameters, and include custom authentication and request modules in your application.  
  
 The [\<defaultProxy> Element (Network Settings)](../configure-apps/file-schema/network/defaultproxy-element-network-settings.md) element defines the proxy server returned by the `GlobalProxySelection` class. Any <xref:System.Net.HttpWebRequest> that does not have its own <xref:System.Net.HttpWebRequest.Proxy%2A> property set to a specific value uses the default proxy. In addition to setting the proxy address, you can create a list of server addresses that will not use the proxy, and you can indicate that the proxy should not be used for local addresses.  
  
 It is important to note that the Microsoft Internet Explorer settings are combined with the configuration settings, with the latter taking precedence.  
  
 The following example sets the default proxy server address to `http://proxyserver`, indicates that the proxy should not be used for local addresses, and specifies that all requests to servers located in the contoso.com domain should bypass the proxy.  
  
```xml  
<configuration>  
    <system.net>  
        <defaultProxy>  
            <proxy  
                usesystemdefault = "false"  
                proxyaddress = "http://proxyserver:80"  
                bypassonlocal = "true"  
            />  
            <bypasslist>  
                <add address="http://[a-z]+\.contoso\.com/" />  
            </bypasslist>  
        </defaultProxy>  
    </system.net>  
</configuration>  
```  
  
 Use the [\<connectionManagement> Element (Network Settings)](../configure-apps/file-schema/network/connectionmanagement-element-network-settings.md) element to configure the number of persistent connections that can be made to a specific server or to all other servers. The following example configures the application to use two persistent connections to the server `www.contoso.com`, four persistent connections to the server with the IP address 192.168.1.2, and one persistent connection to all other servers.  
  
```xml  
<configuration>  
    <system.net>  
        <connectionManagement>  
            <add address="http://www.contoso.com" maxconnection="2" />  
            <add address="192.168.1.2" maxconnection="4" />  
            <add address="*" maxconnection="1" />  
        </connectionManagement>  
    </system.net>  
</configuration>  
```  
  
 Custom authentication modules are configured with the [\<authenticationModules> Element (Network Settings)](../configure-apps/file-schema/network/authenticationmodules-element-network-settings.md) element. Custom authentication modules must implement the <xref:System.Net.IAuthenticationModule> interface.  
  
 The following example configures a custom authentication module.  
  
```xml  
<configuration>  
    <system.net>  
        <authenticationModules>  
            <add type="MyAuthModule, MyAuthModule.dll" />  
        </authenticationModules>  
    </system.net>  
</configuration>  
```  
  
 You can use the [\<webRequestModules> Element (Network Settings)](../configure-apps/file-schema/network/webrequestmodules-element-network-settings.md) element to configure your application to use custom protocol-specific modules to request information from Internet resources. The specified modules must implement the <xref:System.Net.IWebRequestCreate> interface. You can override the default HTTP, HTTPS, and file request modules by specifying your custom module in the configuration file, as in the following example.  
  
```xml  
<configuration>  
    <system.net>  
        <webRequestModules>  
            <add  
                prefix="HTTP"  
                type = "MyHttpRequest.dll, MyHttpRequestCreator"  
            />  
        </webRequestModules>  
    </system.net>  
</configuration>  
```  
  
## See also

- [Network Programming in the .NET Framework](index.md)
- [Network Settings Schema](../configure-apps/file-schema/network/index.md)
- [\<system.Net> Element (Network Settings)](../configure-apps/file-schema/network/system-net-element-network-settings.md)
