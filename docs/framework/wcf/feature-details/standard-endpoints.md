---
title: "Standard Endpoints"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3fcb4225-addc-44f2-935d-30e4943a8812
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Standard Endpoints
Endpoints are defined by specifying an address, a binding, and a contract. Other parameters that may be set on an endpoint include behavior configuration, headers, and listen URIs.  For certain types of endpoints these values do not change. For example, metadata exchange endpoints always use the <xref:System.ServiceModel.Description.IMetadataExchange> contract. Other endpoints, such as <xref:System.ServiceModel.Description.WebHttpEndpoint> always require a specified endpoint behavior. The usability of an endpoint can be improved by having endpoints with default values for commonly used endpoint properties. Standard endpoints enable a developer to define an endpoint that has default values or where one or more endpoint’s properties does not change.  These endpoints allow you to use such an endpoint without having to specify information of a static nature. Standard endpoints can be used for infrastructure and application endpoints.  
  
## Infrastructure Endpoints  
 A service may expose endpoints with some of the properties not explicitly implemented by the service author. For example, the metadata exchange endpoint exposes the <xref:System.ServiceModel.Description.IMetadataExchange> contract but as a service author you do not implement that interface, it is implemented by WCF. Such infrastructure endpoints have default values for one or more endpoint properties, some of which may be unalterable. The <xref:System.ServiceModel.Description.ServiceEndpoint.Contract%2A> property of the metadata exchange endpoint must be <xref:System.ServiceModel.Description.IMetadataExchange>, while other properties like binding can be supplied by the developer. Infrastructure endpoints are identified by setting the <xref:System.ServiceModel.Description.ServiceEndpoint.IsSystemEndpoint%2A> property to `true`.  
  
## Application Endpoints  
 Application developers can define their own standard endpoints which specify default values for the address, binding, or contract. You define a standard endpoint by deriving a class from <xref:System.ServiceModel.Description.ServiceEndpoint> and setting the appropriate endpoint properties. You can provide default values for properties that can be changed. Some other properties will have static values that cannot change. The following example shows how to implement a standard endpoint.  
  
```csharp
public class CustomEndpoint : ServiceEndpoint
{
    public CustomEndpoint()
        : this(string.Empty)
    { }  
    
    public CustomEndpoint(string address)
        : this(address, ContractDescription.GetContract(typeof(ICalculator)))
    { }  
    
    // Create the custom endpoint with a fixed binding
    public CustomEndpoint(string address, ContractDescription contract)
        : base(contract)
    {
        this.Binding = new BasicHttpBinding();
        this.IsSystemEndpoint = false;
    }
    
    // Definition of the additional property of this endpoint
    public bool Property { get; set; }
}
```
  
 To use a user-defined custom endpoint in a configuration file you must derive a class from <xref:System.ServiceModel.Configuration.StandardEndpointElement>, derive a class from <xref:System.ServiceModel.Configuration.StandardEndpointCollectionElement%602>, and register the new standard endpoint in the extensions section in app.config or machine.config.  The <xref:System.ServiceModel.Configuration.StandardEndpointElement> provides configuration support for the standard endpoint, as shown in the following example.  
  
```csharp
public class CustomEndpointElement : StandardEndpointElement
{
    // Definition of the additional property for the standard endpoint element
    public bool Property
    {
        get { return (bool)base["property"]; }
        set { base["property"] = value; }
    }

    // The additional property needs to be added to the properties of the standard endpoint element
    protected override ConfigurationPropertyCollection Properties
    {
        get
        {
            ConfigurationPropertyCollection properties = base.Properties;
            properties.Add(new ConfigurationProperty("property", typeof(bool), false, ConfigurationPropertyOptions.None));
            return properties;
        }
    }

    // Return the type of this standard endpoint
    protected override Type EndpointType
    {
        get { return typeof(CustomEndpoint); }
    }

    // Create the custom service endpoint
    protected override ServiceEndpoint CreateServiceEndpoint(ContractDescription contract)
    {
        return new CustomEndpoint();
    }

    // Read the value given to the property in config and save it
    protected override void OnApplyConfiguration(ServiceEndpoint endpoint, ServiceEndpointElement serviceEndpointElement)
    {
        CustomEndpoint customEndpoint = (CustomEndpoint)endpoint;
        customEndpoint.Property = this.Property;
    }

    // Read the value given to the property in config and save it
    protected override void OnApplyConfiguration(ServiceEndpoint endpoint, ChannelEndpointElement channelEndpointElement)
    {
        CustomEndpoint customEndpoint = (CustomEndpoint)endpoint;
        customEndpoint.Property = this.Property;
    }

    // No validation in this sample
    protected override void OnInitializeAndValidate(ServiceEndpointElement serviceEndpointElement)
    {
    }

    // No validation in this sample
    protected override void OnInitializeAndValidate(ChannelEndpointElement channelEndpointElement)
    {
    }
}
```  
  
 The <xref:System.ServiceModel.Configuration.StandardEndpointCollectionElement%602> provides the backing type for the collection that appears under the <`standardEndpoints`> section in the configuration for the standard endpoint.  The following example shows how to implement this class.  
  
```csharp
public class CustomEndpointCollectionElement : StandardEndpointCollectionElement<CustomEndpoint, CustomEndpointElement>
{
    // ...
}
```

The following example shows how to register a standard endpoint in the extensions section.

```xml  
<extensions>  
      <standardEndpointExtensions>  
        <add  
          name="customStandardEndpoint"  
          type="CustomEndpointCollectionElement, Example.dll,  
                Version=1.0.0.0, Culture=neutral, PublicKeyToken=ffffffffffffffff"/>  
```  
  
## Configuring a Standard Endpoint  
 Standard endpoints can be added in code or in configuration.  To add a standard endpoint in code simply instantiate the appropriate standard endpoint type and add it to the service host as shown in the following example:  
  
```csharp  
serviceHost.AddServiceEndpoint(new CustomEndpoint());  
```  
  
 To add a standard endpoint in configuration, add an <`endpoint`> element to the <`service`> element and any needed configuration settings in the <`standardEndpoints`> element. The following example shows how to add a <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint>, one of the standard endpoints that ships with [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)].  
  
```xml  
<services>  
  <service>  
    <endpoint isSystemEndpoint="true" kind="udpDiscoveryEndpoint" />  
  </service>  
</services>  
<standardEndpoints>    
  <udpDiscoveryEndpoint>  
     <standardEndpoint multicastAddress="soap.udp://239.255.255.250:3702" />
  </udpDiscoveryEndpoint>
</standardEndpoints>
```  
  
 The type of standard endpoint is specified using the kind attribute in the <`endpoint`> element. The endpoint is configured within the <`standardEndpoints`> element. In the example above, a <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> endpoint is added and configured. The <`udpDiscoveryEndpoint`> element contains a <`standardEndpoint`> that sets the <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint.MulticastAddress%2A> property of the <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint>.  
  
## Standard Endpoints Shipped with the .NET Framework  
 The following table lists the standard endpoints shipped with [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)].  
  
 `Mex Endpoint`  
 A standard endpoint that is used to expose service metadata.  
  
 <xref:System.ServiceModel.Discovery.AnnouncementEndpoint>  
 A standard endpoint that is used by services to send announcement messages.  
  
 <xref:System.ServiceModel.Discovery.DiscoveryEndpoint>  
 A standard endpoint that is used by services to send discovery messages.  
  
 <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint>  
 A standard endpoint that is pre-configured for discovery operations over a UDP multicast binding.  
  
 <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint>  
 A standard endpoint that is used by services to send announcement messages over a UDP binding.  
  
 <xref:System.ServiceModel.Discovery.DynamicEndpoint>  
 A standard endpoint that uses WS-Discovery to find the endpoint address dynamically at runtime.  
  
 <xref:System.ServiceModel.Description.ServiceMetadataEndpoint>  
 A standard endpoint for metadata exchange.  
  
 <xref:System.ServiceModel.Description.WebHttpEndpoint>  
 A standard endpoint with a <xref:System.ServiceModel.WebHttpBinding> binding that automatically adds the <xref:System.ServiceModel.Description.WebHttpBehavior> behavior  
  
 <xref:System.ServiceModel.Description.WebScriptEndpoint>  
 A standard endpoint with a <xref:System.ServiceModel.WebHttpBinding> binding that automatically adds the <xref:System.ServiceModel.Description.WebScriptEnablingBehavior> behavior.  
  
 <xref:System.ServiceModel.Description.WebServiceEndpoint>  
 A standard endpoint with a <xref:System.ServiceModel.WebHttpBinding> binding.  
  
 <xref:System.ServiceModel.Activities.WorkflowControlEndpoint>  
 A standard endpoint that enables you to call control operations on workflow instances.  
  
 <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint>  
 A standard endpoint that supports workflow creation and bookmark resumption.
