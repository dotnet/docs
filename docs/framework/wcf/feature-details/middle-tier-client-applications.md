---
description: "Learn more about: Middle-Tier Client Applications"
title: "Middle-Tier Client Applications"
ms.date: "03/30/2017"
ms.assetid: f9714a64-d0ae-4a98-bca0-5d370fdbd631
---
# Middle-Tier Client Applications

This topic discusses various issues specific to middle-tier client applications that use Windows Communication Foundation (WCF).  
  
## Increasing Middle-Tier Client Performance  

 Compared to previous communications technologies, such as Web services using ASP.NET, the creation of a WCF client instance can be more complex due to the rich feature set of WCF. For example, when a <xref:System.ServiceModel.ChannelFactory%601> object is opened it can establish a secure session with the service, a procedure that increases the startup time for the client instance. Typically, these additional feature capabilities do not affect client applications greatly since the WCF client makes several calls, and then closes.  
  
 Middle-tier client applications, however, can create many WCF client objects quickly and, as a result, experience increased initialization requirements. There are two main approaches to increasing the performance of middle-tier applications when calling services:  
  
- Cache the WCF client object and reuse it for subsequent calls where possible.  
  
- Create a <xref:System.ServiceModel.ChannelFactory%601> object and then use that object to create new WCF client channel objects for each call.  
  
 Issues to consider when using these approaches include:  
  
- If the service is maintaining a client-specific state by using a session, then you cannot reuse the middle-tier WCF client with multiple-client tier requests because the service's state is tied to that of the middle-tier client.  
  
- If the service must perform authentication on a per-client basis, you must create a new client for each incoming request on the middle tier instead of reusing the middle-tier WCF client (or WCF client channel object) because the client credentials of the middle tier cannot be modified after the WCF client (or <xref:System.ServiceModel.ChannelFactory%601>) has been created.  
  
- While channels and clients created by the channels are thread-safe, they might not support writing more than one message to the wire concurrently. If you are sending large messages, particularly if streaming, the send operation might block waiting for another send to complete. This causes two sorts of problems: a lack of concurrency and the possibility of deadlock if the flow of control returns to the service reusing the channel (that is, the shared client calls a service whose code path results in a callback to the shared client). This is true regardless of the type of WCF client you reuse.  
  
- You must handle faulted channels regardless of whether you share the channel. When channels are reused, however, a faulting channel can take down more than one pending request or send.  
  
 For an example that demonstrates best practices for reusing a client for multiple requests, see [Data Binding in an ASP.NET Client](../samples/data-binding-in-an-aspnet-client.md).  
  
 In addition, you can increase the startup performance for those clients that use data types that are serializable using the <xref:System.Xml.Serialization.XmlSerializer> generate and compile serialization code for those data types at runtime, which can result in slow start-up performance. The [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) can improve start-up performance for these applications by generating the necessary serialization code from the compiled assemblies for the application. For more information, see [How to: Improve the Startup Time of WCF Client Applications using the XmlSerializer](startup-time-of-wcf-client-applications-using-the-xmlserializer.md).  
  
## See also

- [Accessing Services Using a WCF Client](accessing-services-using-a-client.md)
