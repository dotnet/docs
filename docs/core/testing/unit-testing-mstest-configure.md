---
title: Configure MSTest
description: Learn how to configure MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 04/16/2024
---

# Configure MSTest

MSTest, Microsoft Testing Framework, is a test framework for .NET applications. It allows you to write and execute tests, and provide test suites with integration to Visual Studio and Visual Studio Code Test Explorers, the .NET CLI, and many CI pipelines.

MSTest is a fully supported, open-source and a cross-platform test framework that works with all supported .NET targets (.NET Framework, .NET Core, .NET, UWP, WinUI, and so on) hosted on [GitHub](https://github.com/microsoft/testfx).

## Runsettings

A *.runsettings* file can be used to configure how unit tests are being run. To learn more about the runsettings and the configurations related to the platform, you can check out [VSTest runsettings documentation](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file) or [MSTest runner runsettings documentation](unit-testing-platform-extensions-vstest-bridge.md#runsettings-support).

### MSTest element

The following runsettings entries allows to configure how MSTest behaves.

|Configuration|Default|Values|
|-|-|-|
|**AssemblyCleanupTimeout**|0|Specify globally the timeout to apply on each instance of assembly cleanup method. `[Timeout]` attribute specified on the assembly cleanup method overrides the global timeout .|
|**AssemblyInitializeTimeout**|0|Specify globally the timeout to apply on each instance of assembly initialize method. `[Timeout]` attribute specified on the assembly initialize method overrides the global timeout .|
|**AssemblyResolution**|false|You can specify paths to extra assemblies when finding and running unit tests. For example, use these paths for dependency assemblies that aren't in the same directory as the test assembly. To specify a path, use a **Directory Path** element. Paths can include environment variables.<br /><br />`<AssemblyResolution>  <Directory path="D:\myfolder\bin\" includeSubDirectories="false"/> </AssemblyResolution>`<br /><br />Note that this feature is only being applied when using .NET Framework target.|
|**CaptureTraceOutput**|true|Capture text messages coming from `Console.Write*`, `Trace.Write*`, `Debug.Write*` api that will be associated to the current running test.|
|**ClassCleanupLifecycle**|EndOfClass|If you want the class cleanup to occur at the end of assembly, set it to **EndOfAssembly**. (No longer supported starting from MSTest v4 as EndOfClass is the default and only [ClassCleanup](<xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute>) behavior)|
|**ClassCleanupTimeout**|0|Specify globally the timeout to apply on each instance of class cleanup method. `[Timeout]` attribute specified on the class cleanup method overrides the global timeout .|
|**ClassInitializeTimeout**|0|Specify globally the timeout to apply on each instance of class initialize method. `[Timeout]` attribute specified on the class initialize method overrides the global timeout .|
|**DeleteDeploymentDirectoryAfterTestRunIsComplete**|true|To retain the deployment directory after a test run, set this value to **false**.|
|**DeploymentEnabled**|true|If you set the value to **false**, deployment items that you've specified in your test method aren't copied to the deployment directory.|
|**DeployTestSourceDependencies**|true|A value indicating whether the test source references are to be deployed.|
|**EnableBaseClassTestMethodsFromOtherAssemblies**|true|A value indicating whether to enable discovery of test methods from base classes in a different assembly from the inheriting test class.|
|**ForcedLegacyMode**|false|In older versions of Visual Studio, the MSTest adapter was optimized to make it faster and more scalable. Some behavior, such as the order in which tests are run, might not be exactly as it was in previous editions of Visual Studio. Set the value to **true** to use the older test adapter.<br /><br />For example, you might use this setting if you have an *app.config* file specified for a unit test.<br /><br />We recommend that you consider refactoring your tests to allow you to use the newer adapter.|
|**MapInconclusiveToFailed**|false|If a test completes with an inconclusive status, it's mapped to the skipped status in **Test Explorer**. If you want inconclusive tests to be shown as failed, set the value to **true**.|
|**MapNotRunnableToFailed**|true|A value indicating whether a not runnable result is mapped to failed test.|
|**Parallelize**||Used to set the parallelization settings:<br /><br />**Workers**: The number of threads/workers to be used for parallelization, which is by default **the number of processors on the current machine**.<br /><br />**SCOPE**: The scope of parallelization. You can set it to **MethodLevel**. By default, it's **ClassLevel**.<br /><br />`<Parallelize><Workers>32</Workers><Scope>MethodLevel</Scope></Parallelize>`|
|**SettingsFile**||You can specify a test settings file to use with the MSTest adapter here. You can also specify a test settings file [from the settings menu](#specify-a-run-settings-file-in-the-ide).<br /><br />If you specify this value, you must also set the **ForcedLegacyMode** to **true**.<br /><br />`<ForcedLegacyMode>true</ForcedLegacyMode>`|
|**TestCleanupTimeout**|0|Specify globally the timeout to apply on each instance of test cleanup method. `[Timeout]` attribute specified on the test cleanup method overrides the global timeout .|
|**TestInitializeTimeout**|0|Specify globally the timeout to apply on each instance of test initialize method. `[Timeout]` attribute specified on the test initialize method overrides the global timeout .|
|**TestTimeout**|0|Gets specified global test case timeout.|
|**TreatClassAndAssemblyCleanupWarningsAsErrors**|false|To see your failures in class cleanups as errors, set this value to **true**.|
|**TreatDiscoveryWarningsAsErrors**|false|To report test discovery warnings as errors, set this value to **true**.|

### `TestRunParameter` element

```xml
<TestRunParameters>
    <Parameter name="webAppUrl" value="http://localhost" />
</TestRunParameters>
```

Test run parameters provide a way to define variables and values that are available to the tests at run time. Access the parameters using the MSTest <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.Properties%2A?displayProperty=nameWithType> property:

```csharp
private string _appUrl;
public TestContext TestContext { get; set; }

[TestMethod]
public void HomePageTest()
{
    string _appUrl = TestContext.Properties["webAppUrl"];
}
```

To use test run parameters, add a public <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> property to your test class.

### Example *.runsettings* file

The following XML shows the contents of a typical *.runsettings* file. Copy this code and edit it to suit your needs.

Each element of the file is optional because it has a default value.

```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>

  <!-- Parameters used by tests at run time -->
  <TestRunParameters>
    <Parameter name="webAppUrl" value="http://localhost" />
    <Parameter name="webAppUserName" value="Admin" />
    <Parameter name="webAppPassword" value="Password" />
  </TestRunParameters>

  <!-- MSTest -->
  <MSTest>
    <MapInconclusiveToFailed>True</MapInconclusiveToFailed>
    <CaptureTraceOutput>false</CaptureTraceOutput>
    <DeleteDeploymentDirectoryAfterTestRunIsComplete>False</DeleteDeploymentDirectoryAfterTestRunIsComplete>
    <DeploymentEnabled>False</DeploymentEnabled>
    <AssemblyResolution>
      <Directory path="D:\myfolder\bin\" includeSubDirectories="false"/>
    </AssemblyResolution>
  </MSTest>

</RunSettings>
```
