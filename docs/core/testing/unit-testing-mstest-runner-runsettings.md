---
title: MSTest runner runsettings
description: Learn how to use runsettings with MSTest runner to configure MSTest test framework.
author: nohwnd
ms.author: jajares
ms.date: 01/03/2024
---


# Using runsettings with MSTest runner

MSTest runner allows you to provide a [VSTest *.runsettings* file](https://learn.microsoft.com/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file), but not all options in this file are picked up by the runner. This article will teach you about the supported and unsupported settings, and configuration options. This article will show you alternatives for the most used VSTest configuration options.

## RunConfiguration

The **RunConfiguration** element can include the following elements. None of these settings are respected by the MSTest runner:

|Node|Description|Reason / workaround |
|-|-|-|
|**MaxCpuCount**|This setting controls the level of parallelism on process-level. Use 0 to enable the maximum process-level parallelism.| When MSTest runner is used with MSBuild, this option is [offloaded to MSBuild]. When a single executable is run, this option has no meaning for MSTest runner.
|**ResultsDirectory**|The directory where test results are placed. The path is relative to the directory that contains .runsettings file.| Use the commandline option `--results-directory` to determine the directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is TestResults in the directory that contains the test application.
|**TargetFrameworkVersion**| This setting defines the framework version, or framework family to use to run tests.| This option is ignored. The `<TargetFramework>` or `<TargetFrameworks>` MSBuild property determines the target framework of the application. The tests are hosted in the final application.
|**TargetPlatform**|This setting defines the architecture to use to run tests. | `<RuntimeIdentifier>` determines the architecture of the final application that hosts the tests.
|**TreatTestAdapterErrorsAsWarnings**|Suppresses test adapter errors to become warnings. | MSTest runner allows only one type of tests to be run from a single assembly, and failure to load the test framework or other parts of infrastructure will become an unskippable error, because it signifies that some tests could not be discovered or run.
|**TestAdaptersPaths**| One or more paths to the directory where the TestAdapters are located| MSTest runner does not use the concept of test adapters and does not allow dynamic loading of extensions unless they are part of the build, and are registered in Program.cs, either automatically via build targets or manually. |
|**TestCaseFilter**| A filter to limit tests which will run. | To filter tests use `--vstest-filter` commandline option.
|**TestSessionTimeout**|Allows users to terminate a test session when it exceeds a given timeout.| There is no alternative option. |
|**DotnetHostPath**|Specify a custom path to dotnet host that is used to run the testhost. | MSTest runner is not doing any additional resolving of dotnet. It depends fully on how dotnet resolves itself, which can be controlled by environment variables such as [`DOTNET_HOST_PATH`](https://learn.microsoft.com/dotnet/core/tools/dotnet-environment-variables#dotnet_host_path)
|**TreatNoTestsAsError**| Exit with non-zero exit code when no tests are discovered. | MSTest runner will error by default when no tests are discovered or run in a test application. You can set how many tests you expect to find in the assembly by using `--minimum-expected-tests` command line parameter, which defaults to 1.

DataCollectionRunSettings?

LoggerRunSettings?

MSTest?

**WILL DELETE** Example runsettings:
```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <!-- Configurations that affect the Test Framework -->
  <RunConfiguration>
    <!-- Use 0 for maximum process-level parallelization. This does not force parallelization within the test DLL (on the thread-level). You can also change it from the Test menu; choose "Run tests in parallel". Unchecked = 1 (only 1), checked = 0 (max). -->
    <MaxCpuCount>1</MaxCpuCount>
    <!-- Path relative to directory that contains .runsettings file-->
    <ResultsDirectory>.\TestResults</ResultsDirectory>

    <!-- Omit the whole tag for auto-detection. -->
    <!-- [x86] or x64, ARM, ARM64, s390x  -->
    <!-- You can also change it from the Test menu; choose "Processor Architecture for AnyCPU Projects" -->
    <TargetPlatform>x86</TargetPlatform>

    <!-- Any TargetFramework moniker or omit the whole tag for auto-detection. -->
    <!-- net48, [net40], net6.0, net5.0, netcoreapp3.1, uap10.0 etc. -->
    <TargetFrameworkVersion>net40</TargetFrameworkVersion>

    <!-- Path to Test Adapters -->
    <TestAdaptersPaths>%SystemDrive%\Temp\foo;%SystemDrive%\Temp\bar</TestAdaptersPaths>

    <!-- TestCaseFilter expression -->
    <TestCaseFilter>(TestCategory != Integration) &amp; (TestCategory != UnfinishedFeature)</TestCaseFilter>

    <!-- TestSessionTimeout was introduced in Visual Studio 2017 version 15.5 -->
    <!-- Specify timeout in milliseconds. A valid value should be greater than 0 -->
    <TestSessionTimeout>10000</TestSessionTimeout>

    <!-- true or false -->
    <!-- Value that specifies the exit code when no tests are discovered -->
    <TreatNoTestsAsError>true</TreatNoTestsAsError>
  </RunConfiguration>

  <!-- Configurations for data collectors -->
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="Code Coverage" uri="datacollector://Microsoft/CodeCoverage/2.0" assemblyQualifiedName="Microsoft.VisualStudio.Coverage.DynamicCoverageDataCollector, Microsoft.VisualStudio.TraceCollector, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a">
        <Configuration>
          <CodeCoverage>
            <ModulePaths>
              <Exclude>
                <ModulePath>.*CPPUnitTestFramework.*</ModulePath>
              </Exclude>
            </ModulePaths>

            <!-- We recommend you do not change the following values: -->
            <UseVerifiableInstrumentation>True</UseVerifiableInstrumentation>
            <AllowLowIntegrityProcesses>True</AllowLowIntegrityProcesses>
            <CollectFromChildProcesses>True</CollectFromChildProcesses>
            <CollectAspDotNet>False</CollectAspDotNet>

          </CodeCoverage>
        </Configuration>
      </DataCollector>

      <DataCollector uri="datacollector://microsoft/VideoRecorder/1.0" assemblyQualifiedName="Microsoft.VisualStudio.TestTools.DataCollection.VideoRecorder.VideoRecorderDataCollector, Microsoft.VisualStudio.TestTools.DataCollection.VideoRecorder, Version=15.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" friendlyName="Screen and Voice Recorder">
        <!--Video data collector was introduced in Visual Studio 2017 version 15.5 -->
        <Configuration>
          <!-- Set "sendRecordedMediaForPassedTestCase" to "false" to add video attachments to failed tests only -->
          <MediaRecorder sendRecordedMediaForPassedTestCase="true"  xmlns="">           ​
            <ScreenCaptureVideo bitRate="512" frameRate="2" quality="20" />​
          </MediaRecorder>​
        </Configuration>
      </DataCollector>

      <!-- Configuration for blame data collector -->
      <DataCollector friendlyName="blame" enabled="True">
      </DataCollector>

    </DataCollectors>
  </DataCollectionRunSettings>

  <!-- Parameters used by tests at run time -->
  <TestRunParameters>
    <Parameter name="webAppUrl" value="http://localhost" />
    <Parameter name="webAppUserName" value="Admin" />
    <Parameter name="webAppPassword" value="Password" />
  </TestRunParameters>

  <!-- Configuration for loggers -->
  <LoggerRunSettings>
    <Loggers>
      <Logger friendlyName="console" enabled="True">
        <Configuration>
            <Verbosity>quiet</Verbosity>
        </Configuration>
      </Logger>
      <Logger friendlyName="trx" enabled="True">
        <Configuration>
          <LogFileName>foo.trx</LogFileName>
        </Configuration>
      </Logger>
      <Logger friendlyName="html" enabled="True">
        <Configuration>
          <LogFileName>foo.html</LogFileName>
        </Configuration>
      </Logger>
      <Logger friendlyName="blame" enabled="True" />
    </Loggers>
  </LoggerRunSettings>

  <!-- Adapter Specific sections -->

  <!-- MSTest adapter -->
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
