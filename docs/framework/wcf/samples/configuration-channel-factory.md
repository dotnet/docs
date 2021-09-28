---
description: "Learn more about: Configuration Channel Factory"
title: "Configuration Channel Factory"
ms.date: "03/30/2017"
ms.assetid: 3b749493-bd8a-4ccb-893e-5948901a1486
---
# Configuration Channel Factory

The [ConfigurationChannelFactory sample](https://github.com/dotnet/samples/tree/main/framework/wcf) covers the usage of the <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601>. The <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> allows central management of WCF client configuration. This can also be useful in scenarios in which configuration is selected or changed after the application domain load time.

## Demonstrates

 <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601>

## Discussion

This sample shows how to use <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> to add a particular configuration file to a client application, without having to use the default application configuration file.

The sample consists of two projects. The first project is a simple service that runs to reply to messages coming from the clients. The second project is a client application that builds two <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> objects using a <xref:System.Configuration.ExeConfigurationFileMap> for the Test.config configuration file and uses them to communicate with the service. Both clients communicate with the service using the configuration specified in Test.config.

The following code adds a custom configuration file to a client application.

```csharp
ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
fileMap.ExeConfigFilename = "Test.config";
Configuration newConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

ConfigurationChannelFactory<ICalculatorChannel> factory1 = new ConfigurationChannelFactory<ICalculatorChannel>("endpoint1", newConfiguration, new EndpointAddress("http://localhost:8000/servicemodelsamples/service"));
ICalculatorChannel client1 = factory1.CreateChannel();
```

#### To set up, build, and run the sample

1. Open Visual Studio with administrator privileges.

2. Right-click the ConfigurationChannelFactory solution (2 projects) and then select **Properties**.

3. In **Common Properties**, select **Startup Project**, and then click **Multiple startup projects**.

4. Move the **Service** project to the beginning of the list, with the **Action 'Start'**, and then move the **Client** project after the **Service** project, also with the **Action 'Start'**, so the **Client** project is executed after the **Service** project.

5. Click **OK**, and then press **F5** (or **Ctrl**+**F5**) to run the sample.
