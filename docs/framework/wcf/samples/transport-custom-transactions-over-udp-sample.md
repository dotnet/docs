---
description: "Learn more about: Transport: Custom Transactions over UDP Sample"
title: "Transport: Custom Transactions over UDP Sample"
ms.date: "03/30/2017"
ms.assetid: 6cebf975-41bd-443e-9540-fd2463c3eb23
---
# Transport: Custom Transactions over UDP Sample

The [TransactionMessagePropertyUDPTransport sample](https://github.com/dotnet/samples/tree/main/framework/wcf) is based on the [Transport: UDP](transport-udp.md) sample in the Windows Communication Foundation (WCF)[Transport Extensibility](transport-extensibility.md). It extends the UDP Transport sample to support custom transaction flow and demonstrates the use of the <xref:System.ServiceModel.Channels.TransactionMessageProperty> property.

## Code Changes in the UDP Transport Sample

To demonstrate transaction flow, the sample changes the service contract for `ICalculatorContract` to require a transaction scope for `CalculatorService.Add()`. The sample also adds an extra `System.Guid` parameter to the contract of the `Add` operation. This parameter is used to pass the identifier of the client transaction to the service.

```csharp
class CalculatorService : IDatagramContract, ICalculatorContract
{
    [OperationBehavior(TransactionScopeRequired=true)]
    public int Add(int x, int y, Guid clientTransactionId)
    {
        if(Transaction.Current.TransactionInformation.DistributedIdentifier == clientTransactionId)
    {
        Console.WriteLine("The client transaction has flowed to the service");
    }
    else
    {
     Console.WriteLine("The client transaction has NOT flowed to the service");
    }

    Console.WriteLine("   adding {0} + {1}", x, y);
    return (x + y);
    }

    [...]
}
```

The [Transport: UDP](transport-udp.md) sample uses UDP packets to pass messages between a client and a service. The [Transport: Custom Transport Sample](transport-custom-transactions-over-udp-sample.md) uses the same mechanism to transport messages, but when a transaction is flowed, it is inserted into the UDP packet along with the encoded message.

```csharp
byte[] txmsgBuffer = TransactionMessageBuffer.WriteTransactionMessageBuffer(txPropToken, messageBuffer);

int bytesSent = this.socket.SendTo(txmsgBuffer, 0, txmsgBuffer.Length, SocketFlags.None, this.remoteEndPoint);
```

 `TransactionMessageBuffer.WriteTransactionMessageBuffer` is a helper method that contains new functionality to merge the propagation token for the current transaction with the message entity and place it into a buffer.

For custom transaction flow transport, the client implementation must know what service operations require transaction flow and to pass this information to WCF. There should also be a mechanism for transmitting the user transaction to the transport layer. This sample uses "WCF message inspectors" to obtain this information. The client message inspector implemented here, which is called `TransactionFlowInspector`, performs the following tasks:

- Determines whether a transaction must be flowed for a given message action (this takes place in `IsTxFlowRequiredForThisOperation()`).

- Attaches the current ambient transaction to the message using `TransactionFlowProperty`, if a transaction is required to be flowed (this is done in `BeforeSendRequest()`).

```csharp
public class TransactionFlowInspector : IClientMessageInspector
{
   void IClientMessageInspector.AfterReceiveReply(ref           System.ServiceModel.Channels.Message reply, object correlationState)
  {
  }

   public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
   {
       // obtain the tx propagation token
       byte[] propToken = null;
       if (Transaction.Current != null && IsTxFlowRequiredForThisOperation(request.Headers.Action))
       {
           try
           {
               propToken = TransactionInterop.GetTransmitterPropagationToken(Transaction.Current);
           }
           catch (TransactionException e)
           {
              throw new CommunicationException("TransactionInterop.GetTransmitterPropagationToken failed.", e);
           }
       }

      // set the propToken on the message in a TransactionFlowProperty
       TransactionFlowProperty.Set(propToken, request);

       return null;
    }
  }

  static bool IsTxFlowRequiredForThisOperation(String action)
 {
       // In general, this should contain logic to identify which operations (actions)      require transaction flow.
      [...]
 }
}
```

The `TransactionFlowInspector` itself is passed to the framework using a custom behavior: the `TransactionFlowBehavior`.

```csharp
public class TransactionFlowBehavior : IEndpointBehavior
{
       public void AddBindingParameters(ServiceEndpoint endpoint,            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
      {
      }

       public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
      {
            TransactionFlowInspector inspector = new TransactionFlowInspector();
            clientRuntime.MessageInspectors.Add(inspector);
      }

      public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
     {
     }

      public void Validate(ServiceEndpoint endpoint)
      {
      }
}
```

With the preceding mechanism in place, the user code creates a `TransactionScope` before calling the service operation. The message inspector ensures that the transaction is passed to the transport in case it is required to be flowed to the service operation.

```csharp
CalculatorContractClient calculatorClient = new CalculatorContractClient("SampleProfileUdpBinding_ICalculatorContract");
calculatorClient.Endpoint.Behaviors.Add(new TransactionFlowBehavior());

try
{
       for (int i = 0; i < 5; ++i)
      {
              // call the 'Add' service operation under a transaction scope
             using (TransactionScope ts = new TransactionScope())
             {
        [...]
        Console.WriteLine(calculatorClient.Add(i, i * 2));
         }
      }
       calculatorClient.Close();
}
catch (TimeoutException)
{
    calculatorClient.Abort();
}
catch (CommunicationException)
{
    calculatorClient.Abort();
}
catch (Exception)
{
    calculatorClient.Abort();
    throw;
}
```

Upon receiving a UDP packet from the client, the service deserializes it to extract the message and possibly a transaction.

```csharp
count = listenSocket.EndReceiveFrom(result, ref dummy);

// read the transaction and message                       TransactionMessageBuffer.ReadTransactionMessageBuffer(buffer, count, out transaction, out msg);
```

 `TransactionMessageBuffer.ReadTransactionMessageBuffer()` is the helper method that reverses the serialization process performed by `TransactionMessageBuffer.WriteTransactionMessageBuffer()`.

If a transaction was flowed in, it is appended to the message in the `TransactionMessageProperty`.

```csharp
message = MessageEncoderFactory.Encoder.ReadMessage(msg, bufferManager);

if (transaction != null)
{
       TransactionMessageProperty.Set(transaction, message);
}
```

This ensures that the dispatcher picks up the transaction at dispatch time and uses it when calling the service operation addressed by the message.

#### To set up, build, and run the sample

1. To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

2. The current sample should be run similarly to the [Transport: UDP](transport-udp.md) sample. To run it, start the service with UdpTestService.exe. If you are running Windows Vista, you must start the service with elevated privileges. To do so, right-click UdpTestService.exe in File Explorer and click **Run as administrator**.

3. This produces the following output.

    ```console
    Testing Udp From Code.
    Service is started from code...
    Press <ENTER> to terminate the service and start service from config...
    ```

4. At this time, you can start the client by running UdpTestClient.exe. The output produced by the client is as follows.

    ```console
    0
    3
    6
    9
    12
    Press <ENTER> to complete test.
    ```

5. The service output is as follows.

    ```console
    Hello, world!
    Hello, world!
    Hello, world!
    Hello, world!
    Hello, world!
    The client transaction has flowed to the service
       adding 0 + 0
    The client transaction has flowed to the service
       adding 1 + 2
    The client transaction has flowed to the service
       adding 2 + 4
    The client transaction has flowed to the service
       adding 3 + 6
    The client transaction has flowed to the service
       adding 4 + 8
    ```

6. The service application displays the message `The client transaction has flowed to the service` if it can match the transaction identifier sent by the client, in the `clientTransactionId` parameter of the `CalculatorService.Add()` operation, to the identifier of the service transaction. A match is obtained only if the client transaction has flowed to the service.

7. To run the client application against endpoints published using configuration, press ENTER on the service application window and then run the test client again. You should see the following output on the service.

    ```console
    Testing Udp From Config.
    Service is started from config...
    Press <ENTER> to terminate the service and exit...
    ```

8. Running the client against the service now produces similar output as before.

9. To regenerate the client code and configuration using Svcutil.exe, start the service application and then run the following Svcutil.exe command from the root directory of the sample.

    ```console
    svcutil http://localhost:8000/udpsample/ /reference:UdpTransport\bin\UdpTransport.dll /svcutilConfig:svcutil.exe.config
    ```

10. Note that Svcutil.exe does not generate the binding extension configuration for the `sampleProfileUdpBinding`; you must add it manually.

    ```xml
    <configuration>
        <system.serviceModel>
            …
            <extensions>
                <!-- This was added manually because svcutil.exe does not add this extension to the file -->
                <bindingExtensions>
                    <add name="sampleProfileUdpBinding" type="Microsoft.ServiceModel.Samples.SampleProfileUdpBindingCollectionElement, UdpTransport" />
                </bindingExtensions>
            </extensions>
        </system.serviceModel>
    </configuration>
    ```

## See also

- [Transport: UDP](transport-udp.md)
