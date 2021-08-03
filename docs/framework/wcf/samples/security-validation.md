---
description: "Learn more about: Security validation"
title: "Security Validation"
ms.date: "03/30/2017"
ms.assetid: 48dcd496-0c4f-48ce-8b9b-0e25b77ffa58
---
# Security validation

The [ServiceValidation sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to use a custom behavior to validate services on a computer to ensure they meet specific criteria. In this sample, services are validated by the custom behavior by scanning through each endpoint on the service and checking to see whether they contain secure binding elements. This sample is based on the [Getting Started](getting-started-sample.md).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

## Endpoint Validation Custom Behavior

By adding user code to the `Validate` method contained in the <xref:System.ServiceModel.Description.IServiceBehavior> interface, custom behavior can be given to a service or endpoint to perform user-defined actions. The following code is used to loop through each endpoint contained in a service, which searches through their binding collections for secure bindings.

```csharp
public void Validate(ServiceDescription serviceDescription,
                                       ServiceHostBase serviceHostBase)
{
    // Loop through each endpoint individually, gathering their
    // binding elements.
    foreach (ServiceEndpoint endpoint in serviceDescription.Endpoints)
    {
        secureElementFound = false;

        // Retrieve the endpoint's binding element collection.
        BindingElementCollection bindingElements =
            endpoint.Binding.CreateBindingElements();

        // Look to see if the binding elements collection contains any
        // secure binding elements. Transport, Asymmetric, and Symmetric
        // binding elements are all derived from SecurityBindingElement.
        if ((bindingElements.Find<SecurityBindingElement>() != null) || (bindingElements.Find<HttpsTransportBindingElement>() != null) || (bindingElements.Find<WindowsStreamSecurityBindingElement>() != null) || (bindingElements.Find<SslStreamSecurityBindingElement>() != null))
        {
            secureElementFound = true;
        }

    // Send a message to the system event viewer when an endpoint is deemed insecure.
    if (!secureElementFound)
        throw new Exception(System.DateTime.Now.ToString() + ": The endpoint \"" + endpoint.Name + "\" has no secure bindings.");
    }
}
```

Adding the following code to Web.config file adds the `serviceValidate` behavior extension for the service to recognize.

```xml
<system.serviceModel>
    <extensions>
        <behaviorExtensions>
            <add name="endpointValidate" type="Microsoft.ServiceModel.Samples.EndpointValidateElement, endpointValidate, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null" />
        </behaviorExtensions>
    </extensions>
    ...
</system.serviceModel>
```

Once the behavior extension is added to the service, it is now possible to add the `endpointValidate` behavior to the list of behaviors in the Web.config file and thus, to the service.

```xml
<behaviors>
    <serviceBehaviors>
        <behavior name="CalcServiceSEB1">
            <serviceMetadata httpGetEnabled="true" />
            <endpointValidate />
        </behavior>
    </serviceBehaviors>
</behaviors>
```

Behaviors and their extensions that are added to the Web.config file apply behavior to individual services, while when added to the Machine.config file apply behavior to every service active on the computer.

> [!NOTE]
> When adding behavior to all services, it is suggested to backup the Machine.config file before making any change.

Now run the client provided in the client\bin directory of this sample. An exception is thrown with the following message: "The requested service, 'http://localhost/servicemodelsamples/service.svc' could not be activated." This is expected because an endpoint is considered insecure by the endpoint validating behavior and prevents the service from being started. The behavior also throws an internal exception that describes which endpoint is insecure and writes a message to the system Event Viewer under the "System.ServiceModel 4.0.0.0" source and the "WebHost" category. It is also possible to turn on tracing on the service in this sample. This allows the user to view the exceptions thrown by endpoint validating behavior by opening the resulting service traces using the Service Trace Viewer tool.

### View failed endpoint validation exception messages in the Event Viewer

1. Click the **Start** menu and select **Run…**.

2. Type `eventvwr` and click **OK**.

3. In the Event Viewer window, click **Application**.

4. Double-click the recently added "System.ServiceModel 4.0.0.0" event under the "WebHost" category in the **Application** window to view insecure endpoint messages.

## Set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
