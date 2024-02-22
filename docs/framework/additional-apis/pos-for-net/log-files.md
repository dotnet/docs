---
title: Log Files
description: Log Files (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Log Files (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) includes a logging feature for recording POS for .NET, Service Objects, and application events. Logging parameters are read from the POS for .NET registry key, **\\HKLM\\SOFTWARE\\POSfor.NET\\Logging**, and entries are written using the <xref:Microsoft.PointOfService.Logger> class.

## Enabling Logging

Logging is enabled when the registry key **\\HKLM\\SOFTWARE\\POSfor.NET\\Logging\\Enabled** is set to any non-zero value.

## Log File Size

The maximum log file size is specified in the registry key **\\HKLM\\SOFTWARE\\POSfor.NET\\Logging\\MaxLogFileSizeMB**. If this file size is exceeded while logging is enabled, logging will stop. There will be no exception or error returned to the application.

By default, the maximum log file size is 10 megabyte (MB).

## Log File Location

The registry key **\\HKLM\\SOFTWARE\\POSfor.NET\\Logging\\location** is used to determine where log files will be written.

By default, this location is set to the environment variable **%TEMP%** which, in Windows, defaults to the directory **C:\\Documents and Settings\\(username)\\Local Settings\\temp**. This is a per-user directory.

## Log File Names

Log file names are composed of three elements:

- The base file name contained in the registry key **\\HKLM\\SOFTWARE\\POSfor.NET\\Logging\\Name**. The default for this value is **PosFor.Net**.
- A timestamp in this format: **(yyyy-mm-dd hh-mm-ssZ)**
- The file extension **.txt**.

This is an example of a typical log file name:

**PosFor.Net(2006-08-10 18-33-29Z).txt**

## Log File Header

A header containing information such as the user, OS, calling thread, and process is written to each log file when it is created. This header includes the following fields:

- **Current user:** The name of the current user.
- **Computer name:** The name of the computer creating the log.
- **OS version:** The version of Windows that is being run, including service packs.
- **.Net runtime:** The version of the .NET runtime.
- **Process Id:** The PID of the process that created the log file.
- **Thread Id:** The thread that created the log.
- **Max log file size:** The maximum file size to be used for this log file.
- **File:** The name of the executable that created the log file.
- **InternalName:** The internal name of the executable.
- **OriginalFilename:** The original name of the executable.
- **FileVersion:** The version information stored in the executable.
- **FileDescription:** The description stored in the executable.
- **Product:** The product description stored in the executable.
- **ProductVersion:** The file version stored in the executable.
- **Debug:** Debug flag.
- **Patched:** Patched file.
- **PreRelease:** Pre-release flag.
- **PrivateBuild:** Private build flag.
- **SpecialBuild:** Special build flag.
- **Language:** The language used to create the log file.

## Log File Entries

Log entries can be created by POS for .NET or by either the application or the Service Object. Entries are created by calling the appropriate method on an instance of the **Logger** class.

Each entry contains the following fields:

- Timestamp.

- Thread ID that created the entry.

- Importance level. Each log entry is marked with its level of importance which is determined by which **Logger** method is involved.

    | Importance Tag in Log Entries | Corresponding Logger Method |
    |-------------------------------|-----------------------------|
    | INFO                          | Logger.Info                 |
    | WARNING                       | Logger.Warning              |
    | ERROR                         | Logger.Error                |

- Name string specified by the code that called the **Logger** method. This string is specified when the **Logger** method is invoked and may not necessarily contain the name of the executable.

- For example, a typical entry in the log file would look like this:
    **\[8/10/2006 6:12:14 PM 2936 INFO PosExplorer\] Entering LoadExplorer()**

### Comments

If there is a log file open, and the application calls the <xref:Microsoft.PointOfService.PosExplorer.Refresh> method, the file is closed and a new one created with the updated time stamp.

## See Also

#### Reference

- <xref:Microsoft.PointOfService.Logger>

#### Concepts

- [POS for .NET Registry Settings](pos-for-net-registry-settings.md)
- [Plug and Play Support](plug-and-play-support.md)

#### Other Resources

- [System Configuration](system-configuration.md)
