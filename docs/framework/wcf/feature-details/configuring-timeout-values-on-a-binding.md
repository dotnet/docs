---
title: "Configuring Timeout Values on a Binding"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b5c825a2-b48f-444a-8659-61751ff11d34
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring Timeout Values on a Binding
There are a number of timeout settings available in WCF bindings. Setting these timeout settings correctly can improve not only your service’s performance but also play a role in the usability and security of your service. The following timeouts are available on WCF bindings:  
  
1.  OpenTimeout  
  
2.  CloseTimeout  
  
3.  SendTimeout  
  
4.  ReceiveTimeout  
  
## WCF Binding Timeouts  
 Each of the settings discussed in this topic are made on the binding itself, either in code or configuration. The following code shows how to programmatically set timeouts on a WCF binding in the context of a self-hosted service.  
  
```csharp  
public static void Main()
{
    Uri baseAddress = new Uri("http://localhost/MyServer/MyService");
    
    try
    {
        ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService));
        
        WSHttpBinding binding = new WSHttpBinding();
        binding.OpenTimeout = new TimeSpan(0, 10, 0);
        binding.CloseTimeout = new TimeSpan(0, 10, 0);
        binding.SendTimeout = new TimeSpan(0, 10, 0);
        binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
        
        serviceHost.AddServiceEndpoint("ICalculator", binding, baseAddress);
        serviceHost.Open();
        
        // The service can now be accessed.
        Console.WriteLine("The service is ready.");
        Console.WriteLine("Press <ENTER> to terminate service.");
        Console.WriteLine();
        Console.ReadLine();
    }
    catch (CommunicationException ex)
    {
        // Handle exception ...
    }
}
```  
  
 The following example shows how to configure timeouts on a binding in a configuration file.  
  
```xml  
<configuration>
  <system.serviceModel>
    <bindings>
      <wsHttpBinding>
        <binding openTimeout="00:10:00" 
                 closeTimeout="00:10:00" 
                 sendTimeout="00:10:00" 
                 receiveTimeout="00:10:00">
        </binding>
      </wsHttpBinding>
    </bindings>
  </system.serviceModel>
</configuration>
```  
  
 More information about these settings can be found in the documentation for the <xref:System.ServiceModel.Channels.Binding> class.  
  
### Client-side Timeouts  
 On the client side:  
  
1.  SendTimeout – used to initialize the OperationTimeout, which governs the whole process of sending a message, including receiving a reply message for a request/reply service operation. This timeout also applies when sending reply messages from a callback contract method.  
  
2.  OpenTimeout – used when opening channels when no explicit timeout value is specified.  
  
3.  CloseTimeout – used when closing channels when no explicit timeout value is specified.  
  
4.  ReceiveTimeout – is not used.  
  
### Service-side Timeouts  
 On the service side:  
  
1.  SendTimeout, OpenTimeout, CloseTimeout are the same as on the client.  
  
2.  ReceiveTimeout – used by the Service Framework Layer to initialize the session-idle timeout which controls how long a session can be idle before timing out.
