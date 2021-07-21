---
description: "Learn more about: Expected Exceptions"
title: "Expected Exceptions"
ms.date: "03/30/2017"
ms.assetid: 299a6987-ae6b-43c6-987f-12b034b583ae
---
# Expected Exceptions

The [ExpectedExceptions sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to catch expected exceptions when using a typed client. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample demonstrates catching and handling the two expected exception types that correct programs must handle: `TimeoutException` and `CommunicationException`.

Exceptions that are thrown from communication methods on a Windows Communication Foundation (WCF) client are either expected or unexpected. Unexpected exceptions include catastrophic failures like `OutOfMemoryException` and programming errors like `ArgumentNullException` or `InvalidOperationException`. Typically there is no useful way to handle unexpected errors, so typically you should not catch them when calling a WCF client communication method.

Expected exceptions from communication methods on a WCF client include `TimeoutException`, `CommunicationException`, and any derived class of `CommunicationException`. These indicate a problem during communication that can be safely handled by aborting the WCF client and reporting a communication failure. Because external factors can cause these errors in any application, correct applications must catch these exceptions and recover when they occur.

There are several derived classes of `CommunicationException` that a client can throw. In some cases, applications also catch some of these to do special handling, but let the others be handled as a `CommunicationException`. This can be accomplished by catching the more specific exception type first and then catching `CommunicationException` in a later catch-clause.

Code that calls a client communication method must catch the `TimeoutException` and `CommunicationException`. One way to handle such errors is to abort the client and report the communication failure.

```csharp
try
{
    ...
    double result = client.Add(value1, value2);
    ...
    client.Close();
}
catch (TimeoutException exception)
{
    Console.WriteLine("Got {0}", exception.GetType());
    client.Abort();
}
catch (CommunicationException exception)
{
    Console.WriteLine("Got {0}", exception.GetType());
    client.Abort();
}
```

If an expected exception occurs, the client may or may not be usable afterwards. To determine if the client is still usable, check that the `State` property is `CommunicationState`.Opened. If it is still opened, then it is still usable. Otherwise you should abort the client and release all references to it.

> [!CAUTION]
> You may observe that clients that have a session are often no longer usable after an exception, and clients that do not have a session are often still usable after an exception. However, neither of these is guaranteed, so if you want to try to continue using the client after an exception your application should check the `State` property to verify the client is still opened.

When you run the sample, the operation responses and exceptions are displayed in the client console window.

The client process runs two scenarios, each of which attempts to call `Add` followed by `Divide`. The first scenario simulates a network issue by aborting the client before making the call to `Divide`. The second scenario causes a timeout condition by setting the timeout too short for the method to complete. The expected output from the client process is:

```output
Add(100,15.99) = 115.99
Simulated network problem occurs...
Got System.ServiceModel.CommunicationObjectAbortedException
Add(100,15.99) = 115.99
Set timeout too short for method to complete...
Got System.TimeoutException
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
