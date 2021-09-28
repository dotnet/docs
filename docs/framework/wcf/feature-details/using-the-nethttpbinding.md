---
description: "Learn more about: Using the NetHttpBinding"
title: "Using the NetHttpBinding"
ms.date: "03/30/2017"
ms.assetid: fe134acf-ceca-49de-84a9-05a37e3841f1
---
# Using the NetHttpBinding

<xref:System.ServiceModel.NetHttpBinding> is a binding designed for consuming HTTP or WebSocket services and uses binary encoding by default. <xref:System.ServiceModel.NetHttpBinding> will detect whether it is used with a request-reply contract or duplex contract and change its behavior to match - it will use HTTP for request-reply contracts and WebSockets for duplex contracts. This behavior can be overridden using the <xref:System.ServiceModel.Channels.WebSocketTransportUsage> setting:  
  
1. <xref:System.ServiceModel.Channels.WebSocketTransportUsage.Always> - This forces WebSockets to be used even for request-reply contracts.  
  
2. <xref:System.ServiceModel.Channels.WebSocketTransportUsage.Never> - This prevents WebSockets from being used. Attempting to use a duplex contract with this setting will result in an exception.  
  
3. <xref:System.ServiceModel.Channels.WebSocketTransportUsage.WhenDuplex> - This is the default value and behaves as described above.  
  
 <xref:System.ServiceModel.NetHttpBinding> supports reliable sessions in both HTTP mode and WebSocket mode. In WebSocket mode sessions are provided by the transport.  
  
> [!WARNING]
> When using the <xref:System.ServiceModel.NetHttpBinding> and the binding’s TransferMode is set to TransferMode.Streamed, large streams may cause a deadlock and the call will timeout. To work around this issue send smaller messages or use TransferMode.Buffered.  
  
## Configuring a Service to use NetHttpBinding  

 The <xref:System.ServiceModel.NetHttpBinding> can be configured the same as any other binding. The following configuration snippet illustrates how to configure a WCF service with <xref:System.ServiceModel.NetHttpBinding>.  
  
```xml  
<system.serviceModel>  
    <services>  
      <service name="WcfService1.Service1">  
        <endpoint address=""  
                  binding="netHttpBinding"  
                  contract="WcfService1.IService1"/>  
        <endpoint address="mex"  
                  binding="mexHttpBinding"  
                  contract="IMetadataExchange"/>  
      </service>  
    </services>  
    <bindings>  
      <netHttpBinding>  
        <binding name="My_NetHttpBindingConfig">  
          <webSocketSettings transportUsage="WhenDuplex"/>  
        </binding>  
      </netHttpBinding>  
    </bindings>  
    ...
  </system.serviceModel>  
```  
  
 The following code snippet shows how to add the <xref:System.ServiceModel.NetHttpBinding> in code.  
  
```csharp  
ServiceHost svchost = new ServiceHost(typeof(Service1), baseAddress);  
            NetHttpBinding binding = new NetHttpBinding();  
            svchost.AddServiceEndpoint(typeof(IService1), binding, address);
        }  
```  
  
## See also

- [Configuring Bindings for Services](../configuring-bindings-for-wcf-services.md)
- [Bindings](bindings.md)
- [System-Provided Bindings](../system-provided-bindings.md)
- [Duplex Services](duplex-services.md)
