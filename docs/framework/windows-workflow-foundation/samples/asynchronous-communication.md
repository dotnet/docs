---
description: "Learn more about: Asynchronous Communication"
title: "Asynchronous Communication"
ms.date: "03/30/2017"
ms.assetid: 128dc092-9eb2-4e33-9470-9a7f62b60df6
---
# Asynchronous Communication

The [AsynchronousCommunication sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/Services/AsynchronousCommunication/CS) demonstrates how the communication between two different Windows Workflow Foundation (WF) services is done asynchronously by default.

## Demonstrates

 Asynchronous communication between WF services.

## Discussion

 This sample shows how the communication between WF applications is done asynchronously by using the messaging activities provided by .NET Framework.

 This sample consists of the following three projects.

 CreditCheckService\
 This service receives the credit score of a particular person or the value of the item to acquire, and then decides whether the credit is given to the person.

 RentalApprovalService\
 This service receives an application from a person who is in need of some credit. This service communicates asynchronously with the `CreditCheckService` to decide whether the credit application is valid.

 Client\
 The client communicates synchronously with the `RentalApprovalService` to know whether the credit is approved.

## Set up, build, and run the sample

1. Right-click the **AsynchronousCommunication** solution and select **Properties**.

2. In **Common Properties**, select **Startup Project**, and select **Multiple Startup Projects**.

3. Move **RentalApprovalService** to the first position in the list, followed by **CreditCheckService**, followed by **Client**. Set the **Start** action on all three projects.

4. Click **OK**, and press **F5** to run the sample.
