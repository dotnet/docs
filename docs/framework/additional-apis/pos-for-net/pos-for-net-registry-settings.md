---
title: POS for .NET Registry Settings
description: POS for .NET Registry Settings (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# POS for .NET Registry Settings (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) stores certain configuration information in the system registry. During installation, default values are written to the registry. The POS for .NET values are stored under the key **\\HKLM\\SOFTWARE\\POSfor.NET**. Below is a list of registry keys and their values that POS for .NET uses.

## POSfor.NET Key

This key contains the following values.

| Name           | Description                                                       | Data Type | Default value                                                                                                      |
|----------------|-------------------------------------------------------------------|-----------|--------------------------------------------------------------------------------------------------------------------|
| Configuration  | Name of the configuration file written by the POS Device Manager. | REG_SZ    | C:\Documents and Settings\All Users\Application Data\Microsoft\Point Of Service\Configuration\Configuration.xml    |
| StatisticsFile | Name of the file used to record POS for .NET statistics.          | REG_SZ    | C:\Documents and Settings\All Users\Application Data\Microsoft\Point Of Service\Statistics\PosDeviceStatistics.xml |

The **POSfor.NET** registry key has three subkeys:

- ControlAssemblies
- ControlConfigs
- Logging

## POSfor.NET\\ControlAssemblies Key

This key may contain any number of values of type REG\_SZ, each of which contains the name of a directory. <xref:Microsoft.PointOfService.PosExplorer> will iterate through the entire list of values, searching each directory. Therefore, the names of the values are not important.

These values will need to be modified during system configuration so that they point to the locations appropriate for the specific requirements of the installation.

The following table shows the default values that are written during the POS for .NET SDK setup process.

| Name       | Default Values                                                                      |
|------------|-------------------------------------------------------------------------------------|
| (Default)  | C:\Program Files\Common Files\Microsoft Shared\Point Of Service\Control Assemblies\ |
| ExampleSOs | C:\Program Files\Microsoft Point Of Service\SDK\Samples\Example Service Objects\    |
| Simulators | C:\Program Files\Microsoft Point Of Service\SDK\Samples\Simulator Service Objects\  |

## POSfor.NET\\ControlConfigs Key

In most cases, POS devices are paired with specific Service Objects using the <xref:Microsoft.PointOfService.DeviceInfo.HardwareId> attribute, but in some rare situations, a Service Object provider may need the ability to assign a different device to a Service Object without redistributing the entire assembly.

To accommodate these situations, POS for .NET supports the ability to associate the device to a Service Object in a [Plug and Play XML Configuration](plug-and-play-xml-configuration.md) file.

This key contains a value which points to the location of these Plug and Play configuration files.

| Name      | Default Value                                                                           |
|-----------|-----------------------------------------------------------------------------------------|
| (Default) | C:\Program Files\Common Files\Microsoft Shared\Point Of Service\Control Configurations\ |

## POSfor.NET\\Logging Key

This key contains values which dictate how POS for .NET handles log files. Both POS for .NET and applications, using the <xref:Microsoft.PointOfService.Logger> object, may write to the log file.

The following table shows the values of this key.

| Name             | Description                                                                                                     | Data Type | Default         |
|------------------|-----------------------------------------------------------------------------------------------------------------|-----------|-----------------|
| Enabled          | Set to true if logging is enabled.                                                                              | REG_DWORD | 0 (not enabled) |
| Location         | The location where the log files will be written.                                                               | REG_SZ    | %TEMP%          |
| MaxLogFileSizeMB | The maximum allowed log size, in megabytes.                                                                     | REG_DWORD | 10              |
| Name             | The Base name of the log file. Date and time information follows the file name. The .txt extension is appended. | REG_SZ    | CCL             |

## See Also

#### Reference

- <xref:Microsoft.PointOfService.Logger>

#### Concepts

- [Log Files](log-files.md)
- [Plug and Play XML Configuration](plug-and-play-xml-configuration.md)
- [Plug and Play Support](plug-and-play-support.md)

#### Other Resources

- [System Configuration](system-configuration.md)
