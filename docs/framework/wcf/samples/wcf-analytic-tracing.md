---
description: "Learn more about: WCF Analytic Tracing"
title: "WCF Analytic Tracing"
ms.date: "03/30/2017"
ms.assetid: 6029c7c7-3515-4d36-9d43-13e8f4971790
---
# WCF Analytic Tracing

The [WCFAnalyticTracingExtensibility sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Management/AnalyticTraceExtensibility/CS) demonstrates how to add your own tracing events into the stream of analytic traces that Windows Communication Foundation (WCF) writes to ETW in .NET Framework. Analytic traces are meant to make it easy to get visibility into your services without paying a high performance penalty. This sample shows how to use the <xref:System.Diagnostics.Eventing?displayProperty=nameWithType> APIs to write events that integrate with WCF services.

For more information about the <xref:System.Diagnostics.Eventing?displayProperty=nameWithType> APIs, see <xref:System.Diagnostics.Eventing?displayProperty=nameWithType>.

To learn more about event tracing in Windows, see [Improve Debugging and Performance Tuning with ETW](/archive/msdn-magazine/2007/april/event-tracing-improve-debugging-and-performance-tuning-with-etw).

## Disposing EventProvider

This sample uses the <xref:System.Diagnostics.Eventing.EventProvider?displayProperty=nameWithType> class, which implements <xref:System.IDisposable?displayProperty=nameWithType>. When implementing tracing for a WCF service, it is likely that you may use the <xref:System.Diagnostics.Eventing.EventProvider>'s resources for the lifetime of the service. For this reason, and for readability, this sample never disposes of the wrapped <xref:System.Diagnostics.Eventing.EventProvider>. If for some reason your service has different requirements for tracing and you must dispose of this resource, then you should modify this sample in accordance with the best practices for disposing of unmanaged resources. For more information about disposing unmanaged resources, see [Implementing a Dispose Method](../../../standard/garbage-collection/implementing-dispose.md).

## Self-Hosting vs. Web Hosting

For Web-hosted services, WCF's analytic traces provide a field, called "HostReference", which is used to identify the service that is emitting the traces. The extensible user traces can participate in this model and this sample demonstrates best practices for doing so. The format of a Web host reference when the pipe '&#124;' character actually appears in the resulting string can be any one of the following:

- If the application is not at the root.

     \<SiteName>\<ApplicationVirtualPath>&#124;\<ServiceVirtualPath>&#124;\<ServiceName>

- If the application is at the root.

     \<SiteName>&#124;\<ServiceVirtualPath>&#124;\<ServiceName>

For self-hosted services, WCF's analytic traces do not populate the "HostReference" field. The `WCFUserEventProvider` class in this sample behaves consistently when used by a self-hosted service.

## Custom Event Details

WCF's ETW Event Provider manifest defines three events that are designed to be emitted by WCF service authors from within service code. The following table shows a breakdown of the three events.

|Event|Description|Event ID|
|-----------|-----------------|--------------|
|UserDefinedInformationEventOccurred|Emit this event when something of note happens in your service that is not a problem. For example, you might emit an event after successfully making a call to a database.|301|
|UserDefinedWarningOccurred|Emit this event when a problem occurs that may result in a failure in the future. For example, you may emit a warning event when a call to a database fails but you were able to recover by falling back to a redundant data store.|302|
|UserDefinedErrorOccurred|Emit this event when your service fails to behave as expected. For example, you might emit an event if a call to a database fails and you could not retrieve the data from elsewhere.|303|

#### To use this sample

1. Using Visual Studio, open the WCFAnalyticTracingExtensibility.sln solution file.

2. To build the solution, press **Ctrl**+**Shift**+**B**.

3. To run the solution, press **Ctrl**+**F5**.

     In the Web browser, click **Calculator.svc**. The URI of the WSDL document for the service should appear in the browser. Copy that URI.

4. Run the WCF test client (WcfTestClient.exe).

     The WCF test client (WcfTestClient.exe) is located at `\<Visual Studio Install Dir>\Common7\IDE\WcfTestClient.exe`.

5. Within the WCF test client, add the service by selecting **File**, and then **Add Service**.

     Add the endpoint address in the input box.

6. Click **OK** to close the dialog.

     The ICalculator service is added in the left pane under **My Service Projects**.

7. Open the Event Viewer application.

     Before invoking the service, start Event Viewer and ensure that the event log is listening for tracking events emitted from the WCF service.

8. From the **Start** menu, select **Administrative Tools**, and then **Event Viewer**. Enable the **Analytic** and **Debug** logs.

9. In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application Server-Applications**. Right-click **Application Server-Applications**, select **View**, and then **Show Analytic and Debug Logs**.

     Ensure that the **Show Analytic and Debug Logs** option is checked. Enable the **Analytic** log.

     In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**, and then **Analytic**. Right-click **Analytic** and select **Enable Log**.

10. Test the service using the WCF Test Client.

    1. In the WCF Test Client, double-click **Add()** under the ICalculator service node.

         The **Add()** method appears in the right pane with two parameters.

    2. Type in 2 for the first parameter and 3 for the second parameter.

    3. Click **Invoke** to invoke the method.

11. Go to the **Event Viewer** window that you have already opened. Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**.

12. Right-click the **Analytic** node and select **Refresh**.

     The events appear in the right pane.

13. Locate the event with the ID of 303 and double-click it to open it up and inspect its contents.

     This event was emitted by the `Add()` method of the ICalculator service and has a payload equal to "2+3=5".

#### To clean up (Optional)

1. Open **Event Viewer**.

2. Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application-Server-Applications**. Right-click **Analytic** and select **Disable Log**.

3. Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application-Server-Applications**, and then **Analytic**. Right-click **Analytic** and select **Clear Log**.

4. Click **Clear** to clear the events.

## Known Issue

There is a known issue in the **Event Viewer** where it may fail to decode ETW events. You may see an error message that says: "The description for Event ID \<id> from source Microsoft-Windows-Application Server-Applications cannot be found. Either the component that raises this event is not installed on your local computer or the installation is corrupted. You can install or repair the component on the local computer." If you encounter this error, select **Refresh** from the **Actions** menu. The event should then decode properly.

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
