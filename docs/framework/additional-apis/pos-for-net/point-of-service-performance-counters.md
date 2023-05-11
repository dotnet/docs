---
title: Point of Service Performance Counters
description: Point of Service Performance Counters (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Point of Service Performance Counters (POS for .NET v1.14 SDK Documentation)

The Point of Service Performance Counters service application helps applications and management tools to monitor device statistics. It is included in the standard Microsoft Point of Service for .NET (POS for .NET) Package Installer. However, it is disabled by default.

Device statistics are supported by POS for .NET **Basic** classes. They contain the code used by Service Object developers to implement statistics. Device statistic values are periodically saved to an XML file where they can be persisted across sessions. The POS for .NET statistics service uses this XML file to expose the statistics as performance counters that can be monitored by management tools and do not require direct interaction with a Service Object. Even if the Service Object is claimed by another POS application, the counters can still be monitored by other tools.

The service application creates a counter for any statistic that is represented by a value that may be cast to an integer.

## To enable Point of Service performance counters

1. On the taskbar, choose **Start**, choose **Control Panel**, and then double-click **Administrative Tools**.

2. Choose **Services** to open the **Services** window.

3. Right-click the **Point of Service Performance Counters** service and choose **Properties**.

4. In the **Point of Service Performance Counters Properties** window, open the **Startup Type** drop-down menu and select when to enable Point of Service Performance Counters. There are three options:

      - **Disabled**. This is the default option. When Performance Counters are disabled, the service cannot run.
      - **Manual**. When Performance Counters are set to **Manual**, the service may be run, but does not automatically do so.
      - **Automatic**. When Performance Counters are set to **Automatic**, the service automatically runs every time that your computer starts or restarts.

5. If you have selected **Manual** or **Automatic** in the **Startup Type** drop-down menu, start the service by choosing **Start the Service**.

## To monitor Point of Service performance counters

1. On the taskbar, choose **Start**, choose **Control Panel**, and then choose **Administrative Tools**.

2. Choose **Performance** to open the **Performance Monitor**.

3. Right-click the **Performance** window and choose **Add Counters**.

4. In the **Add Counters** window, open the **Performance Object** drop-down list and select the POS for .NET device class whose statistics you want to display.

5. Select the counters associated with the device class that you have chosen to monitor. Then choose **Add**.

6. Choose **Close** to return to the **Performance** window.

## See Also

#### Tasks

- [Statistics Sample](statistics-sample.md)
