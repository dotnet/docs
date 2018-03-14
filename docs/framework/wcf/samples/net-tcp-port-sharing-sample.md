---
title: "Net.TCP Port Sharing Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 03da5959-0574-4e91-8a53-05854b6c55dc
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Net.TCP Port Sharing Sample
The TCP/IP protocol uses a 16-bit number, called a port, to differentiate connections to multiple network applications running on the same machine. If an application is listening on a port, then all TCP traffic for that port goes to that application. Other applications cannot listen on that port at the same time.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\Net\TCP\PortSharing`  
  
 Many protocols have a standard or default port number that they use. For example, the HTTP protocol typically uses TCP port 80. Internet Information Services (IIS) has a listener to share a port between multiple HTTP applications. IIS listens on the port directly and forwards messages to the appropriate application based on information inside the message stream. This allows multiple HTTP applications to use the same port number without having to compete to reserve the port for receiving messages.  
  
 NetTcp Port Sharing is a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]feature that similarly allows multiple network applications to share a single port. The NetTcp Port Sharing Service accepts connections using the net.tcp protocol and forwards messages based on their destination address.  
  
 The NetTcp Port Sharing Service is not enabled by default. Before running this sample, you must manually enable the service. For more information, see [How to: Enable the Net.TCP Port Sharing Service](../../../../docs/framework/wcf/feature-details/how-to-enable-the-net-tcp-port-sharing-service.md). If the service is disabled, an exception is thrown when the server application is started.  
  
```  
Unhandled Exception: System.ServiceModel.CommunicationException: The TransportManager failed to listen on the supplied URI using the NetTcpPortSharing service: failed to start the service because it is disabled. An administrator can enable it by running 'sc.exe config NetTcpPortSharing start= demand'.. ---> System.InvalidOperationException: Cannot start service NetTcpPortSharing on computer '.'. ---> System.ComponentModel.Win32Exception: The service cannot be started, either because it is disabled or because it has no enabled devices associated with it  
```  
  
 Port sharing is enabled on the server by setting the <xref:System.ServiceModel.NetTcpBinding.PortSharingEnabled%2A> property of the <xref:System.ServiceModel.NetTcpBinding> binding or the <xref:System.ServiceModel.Channels.TcpTransportBindingElement> binding element. The client does not have to know how port sharing has been configured to use it on the server.  
  
## Enabling Port Sharing  
 The following code demonstrates enabling port sharing on the server. It starts an instance of the `ICalculator` service on a fixed port with a random URI path. Even though two services can share the same port, their overall endpoint addresses still must be unique so that the NetTcp Port Sharing Service can route messages to the correct application.  
  
```  
// Configure a binding with TCP port sharing enabled  
NetTcpBinding binding = new NetTcpBinding();  
binding.PortSharingEnabled = true;  
  
// Start a service on a fixed TCP port  
ServiceHost host = new ServiceHost(typeof(CalculatorService));  
ushort salt = (ushort)new Random().Next();  
string address =  
   String.Format("net.tcp://localhost:9000/calculator/{0}", salt);  
host.AddServiceEndpoint(typeof(ICalculator), binding, address);  
host.Open();  
```  
  
 With port sharing enabled, you can run the service multiple times without having a conflict over the port number. If you change the code to disable port sharing, starting up two copies of the service results in the second failing with an <xref:System.ServiceModel.AddressAlreadyInUseException>.  
  
```  
Unhandled Exception: System.ServiceModel.AddressAlreadyInUseException: There is already a listener on IP endpoint 0.0.0.0:9000.  Make sure that you are not trying to use this endpoint multiple times in your application and that there are no other applications listening on this endpoint. ---> System.Net.Sockets.SocketException: Only one usage of each socket address (protocol/network address/port) is normally permitted  
```  
  
## Running the Sample  
 You can use the test client to check that messages are correctly routed to services sharing the port.  
  
```  
class client  
{  
   static void Main(string[] args)  
   {  
      Console.Write("Enter the service number to test: ");  
      ushort salt = ushort.Parse(Console.ReadLine());  
      string address = String.Format("net.tcp://localhost:9000/calculator/{0}", salt);  
      ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>(new NetTcpBinding());  
      ICalculator proxy = factory.CreateChannel(new EndpointAddress(address));  
  
      // Call the Add service operation.  
      double value1 = 100.00D;  
      double value2 = 15.99D;  
      double result = proxy.Add(value1, value2);  
      Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);  
  
      // Call the Subtract service operation.  
      value1 = 145.00D;  
      value2 = 76.54D;  
      result = proxy.Subtract(value1, value2);  
      Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);  
  
      // Call the Multiply service operation.  
      value1 = 9.00D;  
      value2 = 81.25D;  
      result = proxy.Multiply(value1, value2);  
      Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);  
  
      // Call the Divide service operation.  
      value1 = 22.00D;  
      value2 = 7.00D;  
      result = proxy.Divide(value1, value2);  
      Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);  
  
      Console.WriteLine();  
      Console.WriteLine("Press <ENTER> to terminate client.");  
      Console.ReadLine();  
  
      factory.Close();  
   }  
}  
```  
  
 Each instance of the service prints out its unique number and address. For instance, you may see the following text when you run service.exe.  
  
```  
Service #4381 listening on net.tcp://localhost:9000/calculator/4381.  
Press <ENTER> to terminate service.  
```  
  
 Enter the service number you see here when you run client.exe.  
  
```  
Enter the service number to test: 4381  
Add(100,15.99) = 115.99  
Subtract(145,76.54) = 68.46  
Multiply(9,81.25) = 731.25  
Divide(22,7) = 3.14285714285714  
  
Press <ENTER> to terminate client.  
```  
  
 This sample can be run in a cross-machine configuration by changing the generated address that the client uses. In the Client.cs, change the endpoint address format string to match the new address of your service. Replace any references to "localhost" with the IP address of the server machine. You must recompile the sample after making this change.  
  
#### To set up, build, and run the sample  
  
1.  Install [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] 4.0 using the following command.  
  
    ```  
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable  
    ```  
  
2.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
3.  Enable the NetTcp Port Sharing Service as previously described in the introduction section.  
  
4.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
5.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md). Specific details for running this sample are included previously in the Running the Sample section.  
  
## See Also
