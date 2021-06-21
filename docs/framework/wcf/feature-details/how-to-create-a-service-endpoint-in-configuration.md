---
title: "How to: Create a Service Endpoint in Configuration"
description: Learn how to add endpoints for a WCF service using a configuration file containing both relative and absolute addresses.
ms.date: 06/16/2016
ms.assetid: f474e25d-2a27-4f31-84c5-395c442b8e70
---
# How to: Create a Service Endpoint in Configuration

Endpoints provide clients with access to the functionality a Windows Communication Foundation (WCF) service offers. You can define one or more endpoints for a service by using a combination of relative and absolute endpoint addresses, or if you do not define any service endpoints, the runtime provides some by default for you. This topic shows how to add endpoints using a configuration file that contain both relative and absolute addresses.

## Example 1

 The following service configuration specifies a base address and five endpoints.

```xml
<configuration>

  <appSettings>
    <!-- use appSetting to configure base address provided by host -->
    <add key="baseAddress" value="http://localhost:8000/servicemodelsamples/service" />
  </appSettings>

  <system.serviceModel>
    <services>
    <!-- This section is optional with the default configuration introduced in .NET Framework 4. -->
      <service name="Microsoft.ServiceModel.Samples.CalculatorService">
        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:8000/ServiceModelSamples/service"/>
          </baseAddresses>
        </host>
        <endpoint address=""
                  binding="wsHttpBinding"
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />
        <endpoint address="/test"
                  binding="wsHttpBinding"
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />
        <endpoint address="http://localhost:8001/hello/servicemodelsamples"
                  binding="wsHttpBinding"
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />
        <endpoint address="net.tcp://localhost:9000/servicemodelsamples/service"
                  binding="netTcpBinding"
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />
        <!-- the mex endpoint is another relative address exposed at
             http://localhost:8000/ServiceModelSamples/service/mex -->
        <endpoint address="mex"
                  binding="mexHttpBinding"
                  contract="IMetadataExchange" />
      </service>
    </services>

    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->
    <behaviors>
      <serviceBehaviors>
        <behavior>
          <serviceMetadata httpGetEnabled="True"/>
          <serviceDebug includeExceptionDetailInFaults="False" />
        </behavior>
      </serviceBehaviors>
    </behaviors>

  </system.serviceModel>

</configuration>
```

## Example 2

 The base address is specified using the `add` element, under service/host/baseAddresses, as shown in the following sample.

```xml
<service
    name="Microsoft.ServiceModel.Samples.CalculatorService">
  <host>
    <baseAddresses>
      <add baseAddress="http://localhost:8000/ServiceModelSamples/service"/>
    </baseAddresses>
  </host>
```

## Example 3

 The first endpoint definition shown in the following sample specifies a relative address, which means the endpoint address is a combination of the base address and the relative address following the rules of Uniform Resource Identifier (URI) composition. The relative address is empty (""), so the endpoint address is the same as the base address. The actual endpoint address is `http://localhost:8000/servicemodelsamples/service`.

```xml
<endpoint address=""
    binding="wsHttpBinding"
    contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

## Example 4

 The second endpoint definition also specifies a relative address, as shown in the following sample configuration. The relative address, "test", is appended to the base address. The actual endpoint address is `http://localhost:8000/servicemodelsamples/service/test`.

```xml
<endpoint address="/test"
    binding="wsHttpBinding"
    contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

## Example 5

 The third endpoint definition specifies an absolute address, as shown in the following sample configuration. The base address plays no role in the address. The actual endpoint address is `http://localhost:8001/hello/servicemodelsamples`.

```xml
<endpoint address="http://localhost:8001/hello/servicemodelsamples"
    binding="wsHttpBinding"
    contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

## Example 6

 The fourth endpoint address specifies an absolute address and a different transport—TCP. The base address plays no role in the address. The actual endpoint address is net.tcp://localhost:9000/servicemodelsamples/service.

```xml
<endpoint address="net.tcp://localhost:9000/servicemodelsamples/service"
    binding="netTcpBinding"
    contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

## Example 7

 To use the default endpoints provided by the runtime, do not specify any service endpoints in either the code or the configuration file. In this example, the runtime creates the default endpoints when the service is opened. For more information about default endpoints, bindings, and behaviors, see [Simplified Configuration](../simplified-configuration.md) and [Simplified Configuration for WCF Services](/previous-versions/dotnet/framework/wcf/samples/simplified-configuration-for-wcf-services).

```xml
<configuration>

  <appSettings>
    <!-- use appSetting to configure base address provided by host -->
    <add key="baseAddress" value="http://localhost:8000/servicemodelsamples/service" />
  </appSettings>

  <system.serviceModel>
    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->
    <behaviors>
      <serviceBehaviors>
        <behavior>
          <serviceMetadata httpGetEnabled="True"/>
          <serviceDebug includeExceptionDetailInFaults="False" />
        </behavior>
      </serviceBehaviors>
    </behaviors>

  </system.serviceModel>

</configuration>
```
