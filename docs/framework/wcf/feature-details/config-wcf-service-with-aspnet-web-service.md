---
description: "Learn more about: How to: Configure WCF Service to Interoperate with ASP.NET Web Service Clients"
title: "How to: Configure WCF Service to Interoperate with ASP.NET Web Service Clients"
ms.date: "03/30/2017"
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
---
# How to: Configure WCF Service to Interoperate with ASP.NET Web Service Clients

To configure a Windows Communication Foundation (WCF) service endpoint to be interoperable with ASP.NET Web service clients, use the <xref:System.ServiceModel.BasicHttpBinding?displayProperty=nameWithType> type as the binding type for your service endpoint.  
  
 You can optionally enable support for HTTPS and transport-level client authentication on the binding. ASP.NET Web service clients do not support MTOM message encoding, so the <xref:System.ServiceModel.BasicHttpBinding.MessageEncoding%2A?displayProperty=nameWithType> property should be left as its default value, which is <xref:System.ServiceModel.WSMessageEncoding.Text?displayProperty=nameWithType>. ASP.NET Web Service clients do not support WS-Security, so the <xref:System.ServiceModel.BasicHttpBinding.Security%2A?displayProperty=nameWithType> should be set to <xref:System.ServiceModel.BasicHttpSecurityMode.Transport>.  
  
 To make the metadata for a WCF service available to ASP.NET Web service proxy generation tools (that is, [Web Services Description Language Tool (Wsdl.exe)](/previous-versions/dotnet/netframework-4.0/7h3ystb6(v=vs.100)), [Web Services Discovery Tool (Disco.exe)](/previous-versions/dotnet/netframework-4.0/cy2a3ybs(v=vs.100)), and the **Add Web Reference** feature in Visual Studio), you should expose an HTTP/GET metadata endpoint.  
  
## Add an endpoint in code  
  
1. Create a new <xref:System.ServiceModel.BasicHttpBinding> instance  
  
2. Optionally enable transport security for this service endpoint binding by setting the security mode for the binding to <xref:System.ServiceModel.BasicHttpSecurityMode.Transport>. For details, see [Transport Security](transport-security.md).  
  
3. Add a new application endpoint to your service host using the binding instance that you just created. For details about how to add a service endpoint in code, see the [How to: Create a Service Endpoint in Code](how-to-create-a-service-endpoint-in-code.md).  
  
4. Enable an HTTP/GET metadata endpoint for your service. For details see [How to: Publish Metadata for a Service Using Code](how-to-publish-metadata-for-a-service-using-code.md).  
  
## Add an endpoint in a configuration file  
  
1. Create a new <xref:System.ServiceModel.BasicHttpBinding> binding configuration. For details, see the [How to: Specify a Service Binding in Configuration](../how-to-specify-a-service-binding-in-configuration.md).  
  
2. Optionally enable transport security for this service endpoint binding configuration by setting the security mode for the binding to <xref:System.ServiceModel.BasicHttpSecurityMode.Transport>. For details, see [Transport Security](transport-security.md).  
  
3. Configure a new application endpoint for your service using the binding configuration that you just created. For details about how to add a service endpoint in a configuration file, see the [How to: Create a Service Endpoint in Configuration](how-to-create-a-service-endpoint-in-configuration.md).  
  
4. Enable an HTTP/GET metadata endpoint for your service. For details see the [How to: Publish Metadata for a Service Using a Configuration File](how-to-publish-metadata-for-a-service-using-a-configuration-file.md).  
  
## Example  

 The following example code demonstrates how to add a WCF endpoint that is compatible with ASP.NET Web service clients in code and alternatively in configuration files.  
  
 [!code-csharp[C_HowTo-WCFServiceAndASMXClient#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto-wcfserviceandasmxclient/cs/program.cs#0)]
 [!code-vb[C_HowTo-WCFServiceAndASMXClient#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto-wcfserviceandasmxclient/vb/program.vb#0)]
 [!code-xml[C_HowTo-WCFServiceAndASMXClient#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto-wcfserviceandasmxclient/common/app.config#1)]
  
## See also

- [How to: Create a Service Endpoint in Code](how-to-create-a-service-endpoint-in-code.md)
- [How to: Publish Metadata for a Service Using Code](how-to-publish-metadata-for-a-service-using-code.md)
- [How to: Specify a Service Binding in Configuration](../how-to-specify-a-service-binding-in-configuration.md)
- [How to: Create a Service Endpoint in Configuration](how-to-create-a-service-endpoint-in-configuration.md)
- [How to: Publish Metadata for a Service Using a Configuration File](how-to-publish-metadata-for-a-service-using-a-configuration-file.md)
- [Transport Security](transport-security.md)
- [Using Metadata](using-metadata.md)
