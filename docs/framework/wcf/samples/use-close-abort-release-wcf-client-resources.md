---
title: "Use Close and Abort to release WCF client resources"
description: "Dispose can fail and throw exceptions when the network fails. That can cause unwanted behavior. Instead, use Close and Abort to release client resources when the network has failed."
ms.date: "11/12/2018"
ms.assetid: aff82a8d-933d-4bdc-b0c2-c2f7527204fb
---

# Close and Abort release resources safely when network connections have dropped

The [UsingUsing sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates using the `Close` and `Abort` methods to clean up resources when using a typed client. The `using` statement causes exceptions when the network connection is not robust. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample shows two of the common problems that occur when using the C# "using" statement with typed clients, as well as code that correctly cleans up after exceptions.

The C# "using" statement results in a call to `Dispose`(). This is the same as `Close`(), which may throw exceptions when a network error occurs. Because the call to `Dispose`() happens implicitly at the closing brace of the "using" block, this source of exceptions is likely to go unnoticed both by people writing the code and reading the code. This represents a potential source of application errors.

The first problem, illustrated in the `DemonstrateProblemUsingCanThrow` method, is that the closing brace throws an exception and the code after the closing brace does not execute:

```csharp
using (CalculatorClient client = new CalculatorClient())
{
    ...
} // <-- this line might throw
Console.WriteLine("Hope this code wasn't important, because it might not happen.");
```

Even if nothing inside the using block throws an exception or all exceptions inside the using block are caught, the `Console.WriteLine` might not happen because the implicit `Dispose`() call at the closing brace might throw an exception.

The second problem, illustrated in the `DemonstrateProblemUsingCanThrowAndMask` method, is another implication of the closing brace throwing an exception:

```csharp
using (CalculatorClient client = new CalculatorClient())
{
    ...
    throw new ApplicationException("Hope this exception was not important, because "+
                                   "it might be masked by the Close exception.");
} // <-- this line might throw an exception.
```

Because the `Dispose`() occurs inside a "finally" block, the `ApplicationException` is never seen outside the using block if the `Dispose`() fails. If the code outside must know about when the `ApplicationException` occurs, the "using" construct may cause problems by masking this exception.

Finally, the sample demonstrates how to clean up correctly when exceptions occur in `DemonstrateCleanupWithExceptions`. This uses a try/catch block to report errors and call `Abort`. See the [Expected Exceptions](expected-exceptions.md) sample for more details about catching exceptions from client calls.

```csharp
try
{
    ...
    client.Close();
}
catch (CommunicationException e)
{
    ...
    client.Abort();
}
catch (TimeoutException e)
{
    ...
    client.Abort();
}
catch (Exception e)
{
    ...
    client.Abort();
    throw;
}
```

> [!NOTE]
> The using statement and ServiceHost: Many self-hosting applications do little more than host a service, and ServiceHost.Close rarely throws an exception, so such applications can safely use the using statement with ServiceHost. However, be aware that ServiceHost.Close can throw a `CommunicationException`, so if your application continues after closing the ServiceHost, you should avoid the using statement and follow the pattern previously given.

When you run the sample, the operation responses and exceptions are displayed in the client console window.

The client process runs three scenarios, each of which attempts to call `Divide`. The first scenario demonstrates code being skipped because of an exception from `Dispose`(). The second scenario demonstrates an important exception being masked because of an exception from `Dispose`(). The third scenario demonstrates correct clean up.

The expected output from the client process is:

```console
=
= Demonstrating problem:  closing brace of using statement can throw.
=
Got System.ServiceModel.CommunicationException from Divide.
Got System.ServiceModel.Security.MessageSecurityException
=
= Demonstrating problem:  closing brace of using statement can mask other Exceptions.
=
Got System.ServiceModel.CommunicationException from Divide.
Got System.ServiceModel.Security.MessageSecurityException
=
= Demonstrating cleanup with Exceptions.
=
Calling client.Add(0.0, 0.0);
        client.Add(0.0, 0.0); returned 0
Calling client.Divide(0.0, 0.0);
Got System.ServiceModel.CommunicationException from Divide.

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
