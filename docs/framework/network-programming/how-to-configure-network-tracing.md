---
title: "How to: Configure Network Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "formatting [.NET Framework], network tracing"
  - "network tracing, configuring"
  - "level attribute"
  - "app.config files, network tracing"
  - "configuration files [.NET Framework], network tracing"
  - "protocol-level trace output"
  - "application configuration files, network tracing"
  - "sockets, trace output"
ms.assetid: 5ef9fe4b-8d3d-490e-9259-1d014b2181af
caps.latest.revision: 23
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Configure Network Tracing
The application or computer configuration file holds the settings that determine the format and content of network traces. Before performing this procedure, be sure tracing is enabled. For information about enabling tracing, see [Enabling Network Tracing](../../../docs/framework/network-programming/enabling-network-tracing.md).  
  
 The computer configuration file, machine.config, is stored in the %Windir%\Microsoft.NET\Framework folder in the directory where Windows was installed. There is a separate machine.config file in the folders under %Windir%\Microsoft.NET\Framework for each version of the .NET Framework installed on the computer (for example, C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\machine.config or C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\machine.config.).  
  
 These settings can also be made in the configuration file for the application, which has precedence over the computer configuration file.  
  
### To configure network tracing  
  
-   Add the following lines to the appropriate configuration file. The values and options for these settings are described in the tables below.  
  
    ```xml  
    <configuration>  
      <system.diagnostics>  
        <sources>  
          <source name="System.Net" tracemode="includehex" maxdatasize="1024">  
            <listeners>  
              <add name="System.Net"/>  
            </listeners>  
          </source>  
          <source name="System.Net.Cache">  
            <listeners>  
              <add name="System.Net"/>  
            </listeners>  
          </source>  
          <source name="System.Net.Http">  
            <listeners>  
              <add name="System.Net"/>  
            </listeners>  
          </source>  
          <source name="System.Net.Sockets">  
            <listeners>  
              <add name="System.Net"/>  
            </listeners>  
          </source>  
          <source name="System.Net.WebSockets">  
            <listeners>  
              <add name="System.Net"/>  
            </listeners>  
          </source>  
        </sources>  
        <switches>  
          <add name="System.Net" value="Verbose"/>  
          <add name="System.Net.Cache" value="Verbose"/>  
          <add name="System.Net.Http" value="Verbose"/>  
          <add name="System.Net.Sockets" value="Verbose"/>  
          <add name="System.Net.WebSockets" value="Verbose"/>  
        </switches>  
        <sharedListeners>  
          <add name="System.Net"  
            type="System.Diagnostics.TextWriterTraceListener"  
            initializeData="network.log"  
          />  
        </sharedListeners>  
        <trace autoflush="true"/>  
      </system.diagnostics>  
    </configuration>  
    ```  
  
 When you add a name to the `<switches>` block, the trace output includes information from some methods related to the name. The following table describes the output.  
  
|Name|Output from|  
|----------|-----------------|  
|`System.Net.Sockets`|Some public methods of the <xref:System.Net.Sockets.Socket>, <xref:System.Net.Sockets.TcpListener>, <xref:System.Net.Sockets.TcpClient>, and <xref:System.Net.Dns> classes|  
|`System.Net`|Some public methods of the <xref:System.Net.HttpWebRequest>, <xref:System.Net.HttpWebResponse>, <xref:System.Net.FtpWebRequest>, and <xref:System.Net.FtpWebResponse> classes, and SSL debug information (invalid certificates, missing issuers list, and client certificate errors.)|  
|`System.Net.HttpListener`|Some public methods of the <xref:System.Net.HttpListener>, <xref:System.Net.HttpListenerRequest>, and <xref:System.Net.HttpListenerResponse> classes.|  
|`System.Net.Cache`|Some private and internal methods in `System.Net.Cache`.|  
|`System.Net.Http`|Some public methods of the  <xref:System.Net.Http.HttpClient>,  <xref:System.Net.Http.DelegatingHandler>,  <xref:System.Net.Http.HttpClientHandler>, <xref:System.Net.Http.HttpMessageHandler>,  <xref:System.Net.Http.MessageProcessingHandler>, and  <xref:System.Net.Http.WebRequestHandler> classes.|  
|`System.Net.WebSockets.WebSocket`|Some public methods of the <xref:System.Net.WebSockets.ClientWebSocket> and <xref:System.Net.WebSockets.WebSocket> classes.|  
  
 The attributes listed in the following table configure trace output.  
  
|Attribute name|Attribute value|  
|--------------------|---------------------|  
|`Value`|Required <xref:System.String> attribute. Sets the verbosity of the output. Legitimate values are `Critical`, `Error`, `Verbose`, `Warning`, and `Information`.<br /><br /> This attribute must be set on the \<add name> element of the \<switches> element as shown in the example. An exception is thrown if this attribute is set on the \<source> element.|  
|`maxdatasize`|Optional <xref:System.Int32> attribute. Sets the maximum number of bytes of network data included in each line trace. The default value is 1024.<br /><br /> This attribute must be set on the \<source> element as shown in the example. An exception is thrown if this attribute is set on an element under the \<switches> element.|  
|`Tracemode`|Optional <xref:System.String> attribute. Set to `includehex` to show protocol traces in hexadecimal and text format. Set to `protocolonly` to show only text. The default value is `includehex`.<br /><br /> This attribute must be set on the \<switches> element as shown in the example. An exception is thrown if this attribute is set on an element under the \<source> element.|  
  
## See Also  
 [Interpreting Network Tracing](../../../docs/framework/network-programming/interpreting-network-tracing.md)  
 [Network Tracing in the .NET Framework](../../../docs/framework/network-programming/network-tracing.md)  
 [Enabling Network Tracing](../../../docs/framework/network-programming/enabling-network-tracing.md)  
 [Introduction to Instrumentation and Tracing](http://msdn.microsoft.com/library/e924e57c-33cf-4b0e-9e7f-a45d13e38f2c)
