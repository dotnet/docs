---
description: "Learn more about: Reliable Secure Profile"
title: "Reliable Secure Profile"
ms.date: "03/30/2017"
ms.assetid: 921edc41-e91b-40f9-bde9-b6148b633e61
---
# Reliable Secure Profile

The [ReliableSecureProfile sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to compose WCF and [Reliable Secure Profile (RSP)](http://www.ws-i.org/Profiles/ReliableSecureProfile-1.0.html). This sample demonstrates the implementation of a [Make Connection](http://docs.oasis-open.org/ws-rx/wsmc/200702/wsmc-1.0-spec-cs-01.pdf) channel, which can be composed together with Reliable Messaging and optionally a secure channel to create a Reliable Secure Binding based on the RSP specification.

## Discussion

This sample demonstrates a reliable asynchronous two-way message exchange scenario. The service has a duplex contract and the client implements the duplex callback contract. The client initiates a request to a service, for which a response is expected on a separate connection. The request message is sent reliably. The client does not want to open a listening endpoint at its end. Thus, it polls the service with 'Make Connection' requests for the service to send back the response on the back channel of this 'Make Connection' request. This sample demonstrates how to have secure reliable duplex communication over HTTP without the client exposing a listening endpoint (and creating a firewall exception).

## To set up, build, and run the sample

1. Open the **ReliableSecureProfile** solution.

2. Right click the **Service** project in **Solution Explorer**, select **Debug**, **Start new instance** from the context menu. This starts up the service host.

3. Right click the **Client** project in **Solution Explorer**, select **Debug**, **Start new instance** from the context menu. This starts up the client.

4. Type in any string in the prompt on the client console window and click ENTER.This sends the input string to the service, which computes a hash of this string.

5. View the result on the client windows when the service calls back the duplex callback contract operation to display the result on the client console window. There is an intentional delay on the service to simulate a long running operation of processing the data.

6. Monitoring the HTTP traffic (by any of the online network monitoring tools like Network Monitor, Fiddler and so on) shows that a sequence for communication is established between the client and the service as laid down by the Reliable Secure Profile, and how the client polls the service with 'Make Connection' requests. When the service gets ready to send back the processed response, it uses the back channel of the last 'Make Connection' request to send back the results.

7. Press ENTER on the service console window to close the service. Press ENTER on the client console window to close the client.
