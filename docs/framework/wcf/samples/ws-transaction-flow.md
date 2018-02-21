---
title: "WS Transaction Flow"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Transactions"
ms.assetid: f8eecbcf-990a-4dbb-b29b-c3f9e3b396bd
caps.latest.revision: 43
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WS Transaction Flow
This sample demonstrates the use of a client-coordinated transaction and the client and server options for transaction flow using either the WS-Atomic Transaction or OleTransactions protocol. This sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md) that implements a calculator service but the operations are attributed to demonstrate the use of the `TransactionFlowAttribute` with the **TransactionFlowOption** enumeration to determine to what degree transaction flow is enabled. Within the scope of the flowed transaction, a log of the requested operations is written to a database and persists until the client coordinated transaction has completed - if the client transaction does not complete, the Web service transaction ensures that the appropriate updates to the database are not committed.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 After initiating a connection to the service and a transaction, the client accesses several service operations. The contract for the service is defined as follows with each of the operations demonstrating a different setting for the `TransactionFlowOption`.  
  
```  
[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]  
public interface ICalculator  
{  
    [OperationContract]  
    [TransactionFlow(TransactionFlowOption.Mandatory)]  
    double Add(double n1, double n2);  
    [OperationContract]  
    [TransactionFlow(TransactionFlowOption.Allowed)]  
    double Subtract(double n1, double n2);  
    [OperationContract]  
    [TransactionFlow(TransactionFlowOption.NotAllowed)]  
    double Multiply(double n1, double n2);  
    [OperationContract]  
    double Divide(double n1, double n2);   
}  
```  
  
 This defines the operations in the order they are to be processed:  
  
-   An `Add` operation request must include a flowed transaction.  
  
-   A `Subtract` operation request may include a flowed transaction.  
  
-   A `Multiply` operation request must not include a flowed transaction through the explicit NotAllowed setting.  
  
-   A `Divide` operation request must not include a flowed transaction through the omission of a `TransactionFlow` attribute.  
  
 To enable transaction flow, bindings with the [\<transactionFlow>](../../../../docs/framework/configure-apps/file-schema/wcf/transactionflow.md) property enabled must be used in addition to the appropriate operation attributes. In this sample, the service's configuration exposes a TCP endpoint and an HTTP endpoint in addition to a Metadata Exchange endpoint. The TCP endpoint and the HTTP endpoint use the following bindings, both of which have the [\<transactionFlow>](../../../../docs/framework/configure-apps/file-schema/wcf/transactionflow.md) property enabled.  
  
```xml  
<bindings>  
  <netTcpBinding>  
    <binding name="transactionalOleTransactionsTcpBinding"  
             transactionFlow="true"  
             transactionProtocol="OleTransactions"/>  
  </netTcpBinding>  
  <wsHttpBinding>  
    <binding name="transactionalWsatHttpBinding"  
             transactionFlow="true" />  
  </wsHttpBinding>  
</bindings>  
```  
  
> [!NOTE]
>  The system-provided netTcpBinding allows specification of the transactionProtocol whereas the system-provided wsHttpBinding uses only the more interoperable WSAtomicTransactionOctober2004 protocol. The OleTransactions protocol is only available for use by [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] clients.  
  
 For the class that implements the `ICalculator` interface, all of the methods are attributed with <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> property set to `true`. This setting declares that all actions taken within the method occur within the scope of a transaction. In this case, the actions taken include recording to the log database. If the operation request includes a flowed transaction then the actions occur within the scope of the incoming transaction or a new transaction scope is automatically generated.  
  
> [!NOTE]
>  The <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> property defines behavior local to the service method implementations and does not define the client's ability to or requirement for flowing a transaction.  
  
```  
// Service class that implements the service contract.  
[ServiceBehavior(TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable)]  
public class CalculatorService : ICalculator  
{  
    [OperationBehavior(TransactionScopeRequired = true)]  
    public double Add(double n1, double n2)  
    {  
        RecordToLog(String.Format(CultureInfo.CurrentCulture, "Adding {0} to {1}", n1, n2));  
        return n1 + n2;  
    }  
  
    [OperationBehavior(TransactionScopeRequired = true)]  
    public double Subtract(double n1, double n2)  
    {  
        RecordToLog(String.Format(CultureInfo.CurrentCulture, "Subtracting {0} from {1}", n2, n1));  
        return n1 - n2;  
    }  
  
    [OperationBehavior(TransactionScopeRequired = true)]  
    public double Multiply(double n1, double n2)  
    {  
        RecordToLog(String.Format(CultureInfo.CurrentCulture, "Multiplying {0} by {1}", n1, n2));  
        return n1 * n2;  
    }  
  
    [OperationBehavior(TransactionScopeRequired = true)]  
    public double Divide(double n1, double n2)  
    {  
        RecordToLog(String.Format(CultureInfo.CurrentCulture, "Dividing {0} by {1}", n1, n2));  
        return n1 / n2;  
    }  
  
    // Logging method omitted for brevity  
}  
```  
  
 On the client, the service's `TransactionFlowOption` settings on the operations are reflected in the client's generated definition of the `ICalculator` interface. Also, the service's `transactionFlow` property settings are reflected in the client's application configuration. The client can select the transport and protocol by selecting the appropriate `endpointConfigurationName`.  
  
```  
// Create a client using either wsat or oletx endpoint configurations  
CalculatorClient client = new CalculatorClient("WSAtomicTransaction_endpoint");  
// CalculatorClient client = new CalculatorClient("OleTransactions_endpoint");  
```  
  
> [!NOTE]
>  The observed behavior of this sample is the same no matter which protocol or transport is chosen.  
  
 Having initiated the connection to the service, the client creates a new `TransactionScope` around the calls to the service operations.  
  
```  
// Start a transaction scope  
using (TransactionScope tx =  
            new TransactionScope(TransactionScopeOption.RequiresNew))  
{  
    Console.WriteLine("Starting transaction");  
  
    // Call the Add service operation  
    //  - generatedClient will flow the required active transaction  
    double value1 = 100.00D;  
    double value2 = 15.99D;  
    double result = client.Add(value1, value2);  
    Console.WriteLine("  Add({0},{1}) = {2}", value1, value2, result);  
  
    // Call the Subtract service operation  
    //  - generatedClient will flow the allowed active transaction  
    value1 = 145.00D;  
    value2 = 76.54D;  
    result = client.Subtract(value1, value2);  
    Console.WriteLine("  Subtract({0},{1}) = {2}", value1, value2, result);  
  
    // Start a transaction scope that suppresses the current transaction  
    using (TransactionScope txSuppress =  
                new TransactionScope(TransactionScopeOption.Suppress))  
    {  
        // Call the Subtract service operation  
        //  - the active transaction is suppressed from the generatedClient  
        //    and no transaction will flow  
        value1 = 21.05D;  
        value2 = 42.16D;  
        result = client.Subtract(value1, value2);  
        Console.WriteLine("  Subtract({0},{1}) = {2}", value1, value2, result);  
  
        // Complete the suppressed scope  
        txSuppress.Complete();  
    }  
  
    // Call the Multiply service operation  
    // - generatedClient will not flow the active transaction  
    value1 = 9.00D;  
    value2 = 81.25D;  
    result = client.Multiply(value1, value2);  
    Console.WriteLine("  Multiply({0},{1}) = {2}", value1, value2, result);  
  
    // Call the Divide service operation.  
    // - generatedClient will not flow the active transaction  
    value1 = 22.00D;  
    value2 = 7.00D;  
    result = client.Divide(value1, value2);  
    Console.WriteLine("  Divide({0},{1}) = {2}", value1, value2, result);  
  
    // Complete the transaction scope  
    Console.WriteLine("  Completing transaction");  
    tx.Complete();  
}  
  
Console.WriteLine("Transaction committed");  
```  
  
 The calls to the operations are as follows:  
  
-   The `Add` request flows the required transaction to the service and the service's actions occur within the scope of the client's transaction.  
  
-   The first `Subtract` request also flows the allowed transaction to the service and again the service's actions occur within the scope of the client's transaction.  
  
-   The second `Subtract` request is performed within a new transaction scope declared with the `TransactionScopeOption.Suppress` option. This suppresses the client's initial outer transaction and the request does not flow a transaction to the service. This approach allows a client to explicitly opt-out of and protect against flowing a transaction to a service when that is not required. The service's actions occur within the scope of a new and unconnected transaction.  
  
-   The `Multiply` request does not flow a transaction to the service because the client's generated definition of the `ICalculator` interface includes a <xref:System.ServiceModel.TransactionFlowAttribute> set to <xref:System.ServiceModel.TransactionFlowOption>`NotAllowed`.  
  
-   The `Divide` request does not flow a transaction to the service because again the client's generated definition of the `ICalculator` interface does not include a `TransactionFlowAttribute`. The service's actions again occur within the scope of another new and unconnected transaction.  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.  
  
```  
Starting transaction  
  Add(100,15.99) = 115.99  
  Subtract(145,76.54) = 68.46  
  Subtract(21.05,42.16) = -21.11  
  Multiply(9,81.25) = 731.25  
  Divide(22,7) = 3.14285714285714  
  Completing transaction  
Transaction committed  
Press <ENTER> to terminate client.  
```  
  
 The logging of the service operation requests are displayed in the service's console window. Press ENTER in the client window to shut down the client.  
  
```  
Press <ENTER> to terminate the service.  
  Writing row to database: Adding 100 to 15.99  
  Writing row to database: Subtracting 76.54 from 145  
  Writing row to database: Subtracting 42.16 from 21.05  
  Writing row to database: Multiplying 9 by 81.25  
  Writing row to database: Dividing 22 by 7  
```  
  
 After a successful execution, the client's transaction scope completes and all actions taken within that scope are committed. Specifically, the noted 5 records are persisted in the service's database. The first 2 of these have occurred within the scope of the client's transaction.  
  
 If an exception occurred anywhere within the client's `TransactionScope` then the transaction cannot complete. This causes the records logged within that scope to not be committed to the database. This effect can be observed by repeating the sample run after commenting out the call to complete the outer `TransactionScope`. On such a run, only the last 3 actions (from the second `Subtract`, the `Multiply` and the `Divide` requests) are logged because the client transaction did not flow to those.  
  
### To set up, build, and run the sample  
  
1.  To build the C# or Visual Basic .NET version of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md)  
  
2.  Ensure that you have installed SQL Server Express Edition or SQL Server, and that the connection string has been correctly set in the service’s application configuration file. To run the sample without using a database, set the `usingSql` value in the service’s application configuration file to `false`  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
    > [!NOTE]
    >  For cross-machine configuration, enable the Distributed Transaction Coordinator using the instructions below, and use the WsatConfig.exe tool from the Windows SDK to enable WCF Transactions network support. See [Configuring WS-Atomic Transaction Support](http://go.microsoft.com/fwlink/?LinkId=190370) for information on setting up WsatConfig.exe.  
  
 Whether you run the sample on the same computer or on different computers, you must configure the Microsoft Distributed Transaction Coordinator (MSDTC) to enable network transaction flow and use the WsatConfig.exe tool to enable [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transactions network support.  
  
### To configure the Microsoft Distributed Transaction Coordinator (MSDTC) to support running the sample  
  
1.  On a service machine running Windows Server 2003 or Windows XP, configure MSDTC to allow incoming network transactions by following these instructions.  
  
    1.  From the **Start** menu, navigate to **Control Panel**, then **Administrative Tools**, and then **Component Services**.  
  
    2.  Expand **Component Services**. Open the **Computers** folder.  
  
    3.  Right-click **My Computer** and select **Properties**.  
  
    4.  On the **MSDTC** tab, click **Security Configuration**.  
  
    5.  Check **Network DTC Access** and **Allow Inbound**.  
  
    6.  Click **OK**, then click **Yes** to restart the MSDTC service.  
  
    7.  Click **OK** to close the dialog box.  
  
2.  On a service machine running Windows Server 2008 or Windows Vista, configure MSDTC to allow incoming network transactions by following these instructions.  
  
    1.  From the **Start** menu, navigate to **Control Panel**, then **Administrative Tools**, and then **Component Services**.  
  
    2.  Expand **Component Services**. Open the **Computers** folder. Select **Distributed Transaction Coordinator**.  
  
    3.  Right-click **DTC Coordinator** and select **Properties**.  
  
    4.  On the **Security** tab, check **Network DTC Access** and **Allow Inbound**.  
  
    5.  Click **OK**, then click **Yes** to restart the MSDTC service.  
  
    6.  Click **OK** to close the dialog box.  
  
3.  On the client machine, configure MSDTC to allow outgoing network transactions:  
  
    1.  From the **Start** menu, navigate to `Control Panel`, then **Administrative Tools**, and then **Component Services**.  
  
    2.  Right-click **My Computer** and select **Properties**.  
  
    3.  On the **MSDTC** tab, click **Security Configuration**.  
  
    4.  Check **Network DTC Access** and **Allow Outbound**.  
  
    5.  Click **OK**, then click **Yes** to restart the MSDTC service.  
  
    6.  Click **OK** to close the dialog box.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\WS\TransactionFlow`
