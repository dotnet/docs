---
description: "Learn more about: WCF Services and Event Tracing for Windows"
title: "WCF Services and Event Tracing for Windows"
ms.date: "03/30/2017"
ms.assetid: eda4355d-0bd0-4dc9-80a2-d2c832152272
---
# WCF Services and Event Tracing for Windows

The [ETWTracing sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to use the analytic tracing in Windows Communication Foundation (WCF) to emit events in Event Tracing for Windows (ETW). The analytic traces are events emitted at key points in the WCF stack that allow troubleshooting of WCF services in production environment.

Analytic trace in WCF services is tracing that can be turned on in a production environment with minimal impact on performance. These traces are emitted as events to an ETW session.

This sample includes a basic WCF service in which events are emitted from the service to the event log, which can be viewed using Event Viewer. It is also possible to start a dedicated ETW session that listens for events from the WCF service. The sample includes a script to create a dedicated ETW session that stores events in a binary file that can be read using Event Viewer.

#### To use this sample

1. Using Visual Studio, open the EtwAnalyticTraceSample.sln solution file.

2. To build the solution, press **Ctrl**+**Shift**+**B**.

3. To run the solution, press **Ctrl**+**F5**.

     In the Web browser, click **Calculator.svc**. The URI of the WSDL document for the service should appear in the browser. Copy that URI.

     By default, the service starts listening for requests on port 1378 `http://localhost:1378/Calculator.svc`.

4. Run the WCF test client (WcfTestClient.exe).

     The WCF test client (WcfTestClient.exe) is located at `\<Visual Studio Install Dir>\Common7\IDE\WcfTestClient.exe`.

5. Within the WCF test client, add the service by selecting **File**, and then **Add Service**.

     Add the endpoint address in the input box. The default is `http://localhost:1378/Calculator.svc`.

6. Open the Event Viewer application.

     Before invoking the service, start Event Viewer and ensure that the event log is listening for tracking events emitted from the WCF service.

7. From the **Start** menu, select **Administrative Tools**, and then **Event Viewer**. Enable the **Analytic** and **Debug** logs.

8. In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application Server-Applications**. Right-click **Application Server-Applications**, select **View**, and then **Show Analytic and Debug Logs**.

     Ensure that the **Show Analytic and Debug Logs** option is checked.

9. Enable the **Analytic** log.

     In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application Server-Applications**. Right-click **Analytic** and select **Enable Log**.

#### To test the service

1. Switch back to WCF test client and double-click `Divide` and keep the default values, which specify a denominator of 0.

     If the denominator is 0, then the service throws a fault.

2. Observe the events emitted from the service.

     Switch back to Event Viewer and navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application Server-Applications**. Right-click **Analytic** and select **Refresh**.

     The WCF analytic trace events are displayed in the event viewer. Notice that because a fault was thrown by the service an error trace event is displayed in the event viewer.

3. Repeat steps 1 and 2, but with valid inputs. The value of the `N2` parameter can be any number other than 0.

     Refresh the analytic channel to view the WCF events do not include any error events.

The sample demonstrates the analytic trace events emitted from a WCF service.

#### To cleanup (Optional)

1. Open Event Viewer.

2. Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application-Server-Applications**. Right-click **Analytic** and select **Disable Log**.

3. Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application-Server-Applications**. Right-click **Analytic** and select **Clear Log**.

4. Choose the **Clear** option to clear the events.

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
