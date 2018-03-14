---
title: "How to: Create a Transactional Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1bd2e4ed-a557-43f9-ba98-4c70cb75c154
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Transactional Service
This sample demonstrates various aspects of creating a transactional service and the use of a client-initiated transaction to coordinate service operations.  
  
### Creating a transactional service  
  
1.  Create a service contract and annotate the operations with the desired setting from the <xref:System.ServiceModel.TransactionFlowOption> enumeration to specify the incoming transaction requirements. Note that you can also place the <xref:System.ServiceModel.TransactionFlowAttribute> on the service class being implemented. This allows for a single implementation of an interface to use these transaction settings, instead of every implementation.  
  
    ```  
    [ServiceContract]  
    public interface ICalculator  
    {  
        [OperationContract]  
        // Use this to require an incoming transaction  
        [TransactionFlow(TransactionFlowOption.Mandatory)]  
        double Add(double n1, double n2);  
        [OperationContract]  
        // Use this to permit an incoming transaction  
        [TransactionFlow(TransactionFlowOption.Allowed)]  
        double Subtract(double n1, double n2);  
    }  
    ```  
  
2.  Create an implementation class, and use the <xref:System.ServiceModel.ServiceBehaviorAttribute> to optionally specify a <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionIsolationLevel%2A> and a <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionTimeout%2A>. You should note that in many cases, the default <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionTimeout%2A> of 60 seconds and the default <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionIsolationLevel%2A> of `Unspecified` are appropriate. For each operation, you can use the <xref:System.ServiceModel.OperationBehaviorAttribute> attribute to specify whether work performed within the method should occur within the scope of a transaction scope according to the value of the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> attribute. In this case, the transaction used for the `Add` method is the same as the mandatory incoming transaction that is flowed from the client, and the transaction used for the `Subtract` method is either the same as the incoming transaction if one was flowed from the client, or a new implicitly and locally created transaction.  
  
    ```  
    [ServiceBehavior(  
        TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,  
        TransactionTimeout = "00:00:45")]  
    public class CalculatorService : ICalculator  
    {  
        [OperationBehavior(TransactionScopeRequired = true)]  
        public double Add(double n1, double n2)  
        {  
            // Perform transactional operation  
            RecordToLog(String.Format("Adding {0} to {1}", n1, n2));  
            return n1 + n2;  
        }  
  
        [OperationBehavior(TransactionScopeRequired = true)]  
        public double Subtract(double n1, double n2)  
        {  
            // Perform transactional operation  
            RecordToLog(String.Format("Subtracting {0} from {1}", n2, n1));  
            return n1 - n2;  
        }  
  
        private static void RecordToLog(string recordText)  
        {  
            // Database operations omitted for brevity  
            // This is where the transaction provides specific benefit  
            // - changes to the database will be committed only when  
            // the transaction completes.  
        }  
    }  
    ```  
  
3.  Configure the bindings in the configuration file, specifying that the transaction context should be flowed, and the protocols to be used to do so. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [ServiceModel Transaction Configuration](../../../../docs/framework/wcf/feature-details/servicemodel-transaction-configuration.md). Specifically, the binding type is specified in the endpoint element’s `binding` attribute. The [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element contains a `bindingConfiguration` attribute that references a binding configuration named `transactionalOleTransactionsTcpBinding`, as shown in the following sample configuration.  
  
    ```xml  
    <service name="CalculatorService">  
      <endpoint address="net.tcp://localhost:8008/CalcService"  
        binding="netTcpBinding"  
        bindingConfiguration="transactionalOleTransactionsTcpBinding"  
        contract="ICalculator"  
        name="OleTransactions_endpoint" />  
    </service>  
    ```  
  
     Transaction flow is enabled at the configuration level by using the `transactionFlow` attribute, and the transaction protocol is specified using the `transactionProtocol` attribute, as shown in the following configuration.  
  
    ```xml  
    <bindings>  
      <netTcpBinding>  
        <binding name="transactionalOleTransactionsTcpBinding"  
          transactionFlow="true"  
          transactionProtocol="OleTransactions"/>  
      </netTcpBinding>  
    </bindings>  
    ```  
  
### Supporting multiple transaction protocols  
  
1.  For optimal performance, you should use the OleTransactions protocol for scenarios involving a client and service written using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. However, the WS-AtomicTransaction (WS-AT) protocol is useful for scenarios when interoperability with third-party protocol stacks is required. You can configure [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services to accept both protocols by providing multiple endpoints with appropriate protocol-specific bindings, as shown in the following sample configuration.  
  
    ```xml  
    <service name="CalculatorService">  
      <endpoint address="http://localhost:8000/CalcService"  
        binding="wsHttpBinding"  
        bindingConfiguration="transactionalWsatHttpBinding"  
        contract="ICalculator"  
        name="WSAtomicTransaction_endpoint" />  
      <endpoint address="net.tcp://localhost:8008/CalcService"  
        binding="netTcpBinding"  
        bindingConfiguration="transactionalOleTransactionsTcpBinding"  
        contract="ICalculator"  
        name="OleTransactions_endpoint" />  
    </service>  
    ```  
  
     The transaction protocol is specified using the `transactionProtocol` attribute. However, this attribute is absent from the system-provided `wsHttpBinding`, because this binding can only use the WS-AT protocol.  
  
    ```xml  
    <bindings>  
      <wsHttpBinding>  
        <binding name="transactionalWsatHttpBinding"  
          transactionFlow="true" />  
      </wsHttpBinding>  
      <netTcpBinding>  
        <binding name="transactionalOleTransactionsTcpBinding"  
          transactionFlow="true"  
          transactionProtocol="OleTransactions"/>  
      </netTcpBinding>  
    </bindings>  
    ```  
  
### Controlling the completion of a transaction  
  
1.  By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] operations automatically complete transactions if no unhandled exceptions are thrown. You can modify this behavior by using the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionAutoComplete%2A> property and the <xref:System.ServiceModel.OperationContext.SetTransactionComplete%2A> method. When an operation is required to occur within the same transaction as another operation (for example, a debit and credit operation), you can disable the autocomplete behavior by setting the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionAutoComplete%2A> property to `false` as shown in the following `Debit` operation example. The transaction the `Debit` operation uses is not completed until a method with the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionAutoComplete%2A> property set to `true` is called, as shown in the operation `Credit1`, or when the <xref:System.ServiceModel.OperationContext.SetTransactionComplete%2A> method is called to explicitly mark the transaction as complete, as shown in the operation `Credit2`. Note that the two credit operations are shown for illustration purposes, and that a single credit operation would be more typical.  
  
    ```  
    [ServiceBehavior]  
    public class CalculatorService : IAccount  
    {  
        [OperationBehavior(  
            TransactionScopeRequired = true, TransactionAutoComplete = false)]  
        public void Debit(double n)  
        {  
            // Perform debit operation  
  
            return;  
        }  
  
        [OperationBehavior(  
            TransactionScopeRequired = true, TransactionAutoComplete = true)]  
        public void Credit1(double n)  
        {  
            // Perform credit operation  
  
            return;  
        }  
  
        [OperationBehavior(  
            TransactionScopeRequired = true, TransactionAutoComplete = false)]  
        public void Credit2(double n)  
        {  
            // Perform alternate credit operation  
  
            OperationContext.Current.SetTransactionComplete();  
            return;  
        }  
    }  
    ```  
  
2.  For the purposes of transaction correlation, setting the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionAutoComplete%2A> property to `false` requires the use of a sessionful binding. This requirement is specified with the `SessionMode` property on the <xref:System.ServiceModel.ServiceContractAttribute>.  
  
    ```  
    [ServiceContract(SessionMode = SessionMode.Required)]  
    public interface IAccount  
    {  
        [OperationContract]  
        [TransactionFlow(TransactionFlowOption.Allowed)]  
        void Debit(double n);  
        [OperationContract]  
        [TransactionFlow(TransactionFlowOption.Allowed)]  
        void Credit1(double n);  
        [OperationContract]  
        [TransactionFlow(TransactionFlowOption.Allowed)]  
        void Credit2(double n);  
    }  
    ```  
  
### Controlling the lifetime of a transactional service instance  
  
1.  [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the <xref:System.ServiceModel.ServiceBehaviorAttribute.ReleaseServiceInstanceOnTransactionComplete%2A> property to specify whether the underlying service instance is released when a transaction completes. Since this defaults to `true`, unless configured otherwise, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] exhibits an efficient and predictable "just-in-time" activation behavior. Calls to a service on a subsequent transaction are assured a new service instance with no remnants of the previous transaction's state. While this is often useful, sometimes you may want to maintain state within the service instance beyond the transaction completion. Examples of this would be when required state or handles to resources are expensive to retrieve or reconstitute. You can do this by setting the <xref:System.ServiceModel.ServiceBehaviorAttribute.ReleaseServiceInstanceOnTransactionComplete%2A> property to `false`. With that setting, the instance and any associated state will be available on subsequent calls. When using this, give careful consideration to when and how state and transactions will be cleared and completed. The following sample demonstrates how to do this by maintaining the instance with the `runningTotal` variable.  
  
    ```  
    [ServiceBehavior(TransactionIsolationLevel = [ServiceBehavior(  
        ReleaseServiceInstanceOnTransactionComplete = false)]  
    public class CalculatorService : ICalculator  
    {  
        double runningTotal = 0;  
  
        [OperationBehavior(TransactionScopeRequired = true)]  
        public double Add(double n)  
        {  
            // Perform transactional operation  
            RecordToLog(String.Format("Adding {0} to {1}", n, runningTotal));  
            runningTotal = runningTotal + n;  
            return runningTotal;  
        }  
  
        [OperationBehavior(TransactionScopeRequired = true)]  
        public double Subtract(double n)  
        {  
            // Perform transactional operation  
            RecordToLog(String.Format("Subtracting {0} from {1}", n, runningTotal));  
            runningTotal = runningTotal - n;  
            return runningTotal;  
        }  
  
        private static void RecordToLog(string recordText)  
        {  
            // Database operations omitted for brevity  
        }  
    }  
    ```  
  
    > [!NOTE]
    >  Since the instance lifetime is a behavior that is internal to the service, and controlled through the <xref:System.ServiceModel.ServiceBehaviorAttribute> property, no modification to the service configuration or service contract is required to set the instance behavior. In addition, the wire will contain no representation of this.
