---
title: "Controlling .NET Framework Logging"
description: Use event tracing for Windows (ETW) to control .NET logging and record common language runtime (CLR) events. Use tools such as Logman, Tracerpt, and Xperf.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "CLR ETW events, logging"
ms.assetid: ce13088e-3095-4f0e-9f6b-fad30bbd3d41
---
# Controlling .NET Framework Logging

You can use event tracing for Windows (ETW) to record common language runtime (CLR) events. You can create and view traces by using the following tools:

- The [Logman](/windows-server/administration/windows-commands/logman) and [Tracerpt](/windows-server/administration/windows-commands/tracerpt_1) command-line tools, which are included with the Windows operating system.

- The [Xperf](/windows-hardware/test/wpt/xperf-command-line-reference) tools in the [Windows Performance Toolkit](/windows-hardware/test/wpt/). For more information about Xperf, see the [Windows Performance blog](/archive/blogs/pigscanfly/).

To capture CLR event information, the CLR provider must be installed on your computer. To confirm that the provider is installed, type `logman query providers` at the command prompt. A list of providers is displayed. This list should contain an entry for the CLR provider, as follows.

```output
Provider                                 GUID
-------------------------------------------------------------------------------
.NET Common Language Runtime    {E13C0D23-CCBC-4E12-931B-D9CC2EEE27E4}.
```

If the CLR provider is not listed, you can install it on Windows Vista and later operating systems by using the Windows [Wevtutil](/windows-server/administration/windows-commands/wevtutil) command-line tool. Open the Command Prompt window as an administrator. Change the prompt directory to the .NET Framework 4 folder (%WINDIR%\Microsoft.NET\Framework[64]\v4.\<.NET version>\ ). This folder contains the CLR-ETW.man file. At the command prompt, type the following command to install the CLR provider:

`wevtutil im CLR-ETW.man`

## Capturing CLR ETW Events

You can use the [Logman](/windows-server/administration/windows-commands/logman) and [Xperf](/windows-hardware/test/wpt/xperf-command-line-reference) command-line tools to capture ETW events, and the [Tracerpt](/windows-server/administration/windows-commands/tracerpt_1) and [Xperf](/windows-hardware/test/wpt/xperf-command-line-reference) tools to decode the trace events.

To turn on logging, a user must specify three things:

- The provider to communicate to.

- A 64-bit number that represents a set of keywords. Each keyword represents a set of events that the provider can turn on. The number represents a combined set of keywords to turn on.

- A small number representing the level (verbosity) to log at. Level 1 is the least verbose, and level 5 is the most verbose. Level 0 is a default whose meaning is provider-specific.

### To capture CLR ETW events using Logman

1. At the command prompt, type:

     `logman start clrevents -p {e13c0d23-ccbc-4e12-931b-d9cc2eee27e4} 0x1CCBD 0x5 -ets -ct perf`

     where:

    - The `-p` parameter identifies the provider GUID.

    - `0x1CCBD` specifies the categories of events that will be raised.

    - `0x5` sets the level of logging (in this case, verbose (5)).

    - The `-ets` parameter instructs Logman to send commands to event tracing sessions.

    - The `-ct perf` parameter specifies that the `QueryPerformanceCounter` function will be used to log the time stamp for each event.

2. To stop logging the events, type:

     `logman stop clrevents -ets`

     This command creates a binary trace file named clrevents.etl.

### To capture CLR ETW events using Xperf

1. At the command prompt, type:

     `xperf -start clr -on e13c0d23-ccbc-4e12-931b-d9cc2eee27e4:0x1CCBD:5 -f clrevents.etl`

     where the GUID is the CLR ETW provider GUID, and `0x1CCBD:5` traces everything at and below level 5 (verbose).

2. To stop tracing, type:

     `Xperf -stop clr`

     This command creates a trace file named clrevents.etl.

## Viewing CLR ETW Events

Use the commands listed below to view the CLR ETW events. For a description of the events, see [CLR ETW Events](clr-etw-events.md).

### To view CLR ETW events using Tracerpt

- At the command prompt, type:

     `tracerpt clrevents.etl`

     This command creates two files: dumpfile.xml and summary.txt. The dumpfile.xml file lists all the events, and summary.txt provides a summary of the events.

### To view CLR ETW events using Xperf

- At the command prompt, type:

     `xperf clrevents.etl`

     This command opens the Xperf ETL file viewer. In this viewer, the CLR events show up in the **Generic Events** view. To display a data grid of events categorized by type, select a region of time in this view, and then right-click and select **Summary**.

### To convert the .etl file to a comma-separated value file

- At the command prompt, type:

     `xperf -i clrevents.etl -f clrevents.csv`

     This command causes XPerf to dump the events as a comma separated value (CSV) file that you can view. Because different events have different fields, this CSV file is contains more than one header line before the data. The first field of every line is the event type, which indicates which header should be used to determine the rest of the fields.

## See also

- [Windows Performance Toolkit](/windows-hardware/test/wpt/)
- [ETW Events in the Common Language Runtime](etw-events-in-the-common-language-runtime.md)
