Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text.Json
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.Testing.Platform.Builder
Imports Microsoft.Testing.Platform.Capabilities.TestFramework
Imports Microsoft.Testing.Platform.CommandLine
Imports Microsoft.Testing.Platform.Configurations
Imports Microsoft.Testing.Platform.Extensions.Messages
Imports Microsoft.Testing.Platform.Extensions.OutputDevice
Imports Microsoft.Testing.Platform.Extensions.TestFramework
Imports Microsoft.Testing.Platform.Extensions.TestHost
Imports Microsoft.Testing.Platform.Messages
Imports Microsoft.Testing.Platform.OutputDevice
Imports Microsoft.Testing.Platform.Requests
Imports Microsoft.Testing.Platform.Services

Module Program
    Function Main(args As String()) As Integer
        Return RunAsync(args).GetAwaiter().GetResult()
    End Function

    Private Async Function RunAsync(args As String()) As Task(Of Integer)
        Dim builder = Await TestApplication.CreateBuilderAsync(args)
        builder.RegisterTestFramework(
            Function(services) New TestFrameworkCapabilities(),
            Function(capabilities, services) New SampleFramework())

        ' <RegisterCoverage>
        builder.TestHost.AddTestSessionLifetimeHandler(
            Function(services) New CoverageExtension(
                services.GetMessageBus(),
                services.GetConfiguration(),
                services.GetCommandLineOptions(),
                services.GetRequiredPlatformService(Of ITestCoverageCapabilities)(),
                services.GetOutputDevice()))
        builder.TestHost.AddTestHostApplicationLifetime(
            Function(services) New CoverageResultReporter(
                services.GetRequiredPlatformService(Of ITestCoverageResult)(),
                services.GetCommandLineOptions(),
                services.GetOutputDevice()))
        ' </RegisterCoverage>

        Using application = Await builder.BuildAsync()
            Try
                Return Await application.RunAsync()
            Catch exception As ArgumentException
                Console.Error.WriteLine($"Invalid sample coverage configuration: {exception.Message}")
                Return 4
            Catch exception As FormatException
                Console.Error.WriteLine($"Invalid sample coverage configuration: {exception.Message}")
                Return 4
            Catch exception As OverflowException
                Console.Error.WriteLine($"Invalid sample coverage configuration: {exception.Message}")
                Return 4
            End Try
        End Using
    End Function
End Module

Friend NotInheritable Class CoverageExtension
    Implements IDataProducer, ITestSessionLifetimeHandler, IOutputDeviceDataProducer

    Private ReadOnly _messageBus As IMessageBus
    Private ReadOnly _options As ICommandLineOptions
    Private ReadOnly _capabilities As ITestCoverageCapabilities
    Private ReadOnly _outputDevice As IOutputDevice
    Private ReadOnly _covered As Long
    Private ReadOnly _coverable As Long
    Private ReadOnly _required As Double
    Private ReadOnly _treatNoDataAsFailure As Boolean

    Public Sub New(
        messageBus As IMessageBus, configuration As IConfiguration, options As ICommandLineOptions,
        capabilities As ITestCoverageCapabilities, outputDevice As IOutputDevice)
        Dim coveredCount = Long.Parse(
            If(configuration("sampleCoverage:covered"), "8"), CultureInfo.InvariantCulture)
        Dim coverableCount = Long.Parse(
            If(configuration("sampleCoverage:coverable"), "10"), CultureInfo.InvariantCulture)
        Dim requiredPercentage = Double.Parse(
            If(configuration("sampleCoverage:requiredPercentage"), "75"), CultureInfo.InvariantCulture)
        ArgumentOutOfRangeException.ThrowIfNegative(coverableCount)
        ArgumentOutOfRangeException.ThrowIfNegative(coveredCount)
        ArgumentOutOfRangeException.ThrowIfGreaterThan(coveredCount, coverableCount)
        If Not Double.IsFinite(requiredPercentage) OrElse requiredPercentage < 0 OrElse requiredPercentage > 100 Then
            Throw New ArgumentException(
                "The sampleCoverage:requiredPercentage setting must be finite and between 0 and 100.",
                NameOf(configuration))
        End If

        _messageBus = messageBus
        _options = options
        _capabilities = capabilities
        _outputDevice = outputDevice
        _covered = coveredCount
        _coverable = coverableCount
        _required = requiredPercentage
        _treatNoDataAsFailure = Boolean.Parse(
            If(configuration("sampleCoverage:treatNoDataAsFailure"), "true"))
    End Sub

    Public ReadOnly Property Uid As String Implements IDataProducer.Uid
        Get
            Return NameOf(CoverageExtension)
        End Get
    End Property

    Public ReadOnly Property Version As String Implements IDataProducer.Version
        Get
            Return "1.0.0"
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements IDataProducer.DisplayName
        Get
            Return "Sample coverage extension"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IDataProducer.Description
        Get
            Return "Publishes synthetic coverage measurements."
        End Get
    End Property

    ' <CoverageDataTypes>
    Public ReadOnly Property DataTypesProduced As Type() Implements IDataProducer.DataTypesProduced
        Get
            Return {
                GetType(TestCoverageMessage),
                GetType(TestCoverageThresholdMessage),
                GetType(TestCoverageReportMessage),
                GetType(SessionFileArtifact)
            }
        End Get
    End Property
    ' </CoverageDataTypes>

    Public Function IsEnabledAsync() As Task(Of Boolean) Implements IDataProducer.IsEnabledAsync
        Return Task.FromResult(Not _options.IsOptionSet("list-tests"))
    End Function

    ' <ReadCoverageCapabilities>
    Public Function OnTestSessionStartingAsync(context As ITestSessionContext) As Task Implements ITestSessionLifetimeHandler.OnTestSessionStartingAsync
        Return _outputDevice.DisplayAsync(Me, New TextOutputDeviceData(
            $"Coverage messages supported: {_capabilities.SupportsTestCoverageMessages}. " &
            $"Enabled producers: {String.Join(", ", _capabilities.EnabledProducerUids)}."),
            context.CancellationToken)
    End Function
    ' </ReadCoverageCapabilities>

    Public Async Function OnTestSessionFinishingAsync(context As ITestSessionContext) As Task Implements ITestSessionLifetimeHandler.OnTestSessionFinishingAsync
        context.CancellationToken.ThrowIfCancellationRequested()
        Dim arguments As String() = Nothing
        Dim resultsDirectory = If(
            _options.TryGetOptionArgumentList("results-directory", arguments),
            arguments(0), Path.Combine(AppContext.BaseDirectory, "TestResults"))
        Dim report As New FileInfo(Path.Combine(resultsDirectory, "sample-coverage.json"))
        report.Directory.Create()
        Await File.WriteAllTextAsync(
            report.FullName,
            JsonSerializer.Serialize(New With {.covered = _covered, .coverable = _coverable}),
            context.CancellationToken)

        ' <PublishCoverage>
        Dim measurement As New TestCoverageMessage(
            context.SessionUid, CoverageScope.Overall, CoverageMetric.Line,
            _covered, _coverable, producerId:=Uid)
        Await _messageBus.PublishAsync(Me, measurement)

        Dim threshold As New TestCoverageThresholdMessage(
            context.SessionUid, CoverageScope.Overall, CoverageMetric.Line,
            CoverageAggregation.None, measurement.Percentage, _required,
            measurement.HasCoverableData, producerId:=Uid,
            treatNoDataAsFailure:=_treatNoDataAsFailure)
        Await _messageBus.PublishAsync(Me, threshold)

        Await _messageBus.PublishAsync(Me, New TestCoverageReportMessage(
            context.SessionUid, report.FullName, CoverageReportFormat.Custom,
            producerId:=Uid, customFormatName:="sample-json"))
        Await _messageBus.PublishAsync(Me, New SessionFileArtifact(
            context.SessionUid, report, "Sample coverage", "Synthetic coverage counts."))
        ' </PublishCoverage>
    End Function
End Class

Friend NotInheritable Class CoverageResultReporter
    Implements ITestHostApplicationLifetime, IOutputDeviceDataProducer

    Private ReadOnly _result As ITestCoverageResult
    Private ReadOnly _options As ICommandLineOptions
    Private ReadOnly _outputDevice As IOutputDevice

    Public Sub New(result As ITestCoverageResult, options As ICommandLineOptions, outputDevice As IOutputDevice)
        _result = result
        _options = options
        _outputDevice = outputDevice
    End Sub

    Public ReadOnly Property Uid As String Implements ITestHostApplicationLifetime.Uid
        Get
            Return NameOf(CoverageResultReporter)
        End Get
    End Property

    Public ReadOnly Property Version As String Implements ITestHostApplicationLifetime.Version
        Get
            Return "1.0.0"
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements ITestHostApplicationLifetime.DisplayName
        Get
            Return "Sample coverage result reporter"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements ITestHostApplicationLifetime.Description
        Get
            Return "Reads coverage results after the test session."
        End Get
    End Property

    Public Function IsEnabledAsync() As Task(Of Boolean) Implements ITestHostApplicationLifetime.IsEnabledAsync
        Return Task.FromResult(Not _options.IsOptionSet("list-tests"))
    End Function

    Public Function BeforeRunAsync(cancellationToken As CancellationToken) As Task Implements ITestHostApplicationLifetime.BeforeRunAsync
        Return Task.CompletedTask
    End Function

    ' <ReadCoverageResult>
    Public Async Function AfterRunAsync(exitCode As Integer, cancellationToken As CancellationToken) As Task Implements ITestHostApplicationLifetime.AfterRunAsync
        For Each scope In _result.Scopes
            For Each metric In scope.Metrics
                Dim percentage = metric.Percentage.ToString("F1", CultureInfo.InvariantCulture)
                Dim text = $"Coverage result: {metric.CoveredCount}/{metric.CoverableCount} " &
                    $"{metric.Metric} ({percentage}%). Producer: {metric.ProducerId}."
                Await _outputDevice.DisplayAsync(
                    Me, New TextOutputDeviceData(text), cancellationToken)
            Next
        Next

        Await _outputDevice.DisplayAsync(Me, New TextOutputDeviceData(
            $"Coverage threshold failure: {_result.HasThresholdFailure}. " &
            $"Coverage reports: {_result.Reports.Count}. Exit code: {exitCode}."),
            cancellationToken)
    End Function
    ' </ReadCoverageResult>
End Class

Friend NotInheritable Class SampleFramework
    Implements ITestFramework, IDataProducer

    Public ReadOnly Property Uid As String Implements ITestFramework.Uid
        Get
            Return NameOf(SampleFramework)
        End Get
    End Property

    Public ReadOnly Property Version As String Implements ITestFramework.Version
        Get
            Return "1.0.0"
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements ITestFramework.DisplayName
        Get
            Return "Coverage sample framework"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements ITestFramework.Description
        Get
            Return "Supplies one test for the coverage extension example."
        End Get
    End Property

    Public ReadOnly Property DataTypesProduced As Type() Implements IDataProducer.DataTypesProduced
        Get
            Return {GetType(TestNodeUpdateMessage)}
        End Get
    End Property

    Public Function IsEnabledAsync() As Task(Of Boolean) Implements ITestFramework.IsEnabledAsync
        Return Task.FromResult(True)
    End Function

    Public Function CreateTestSessionAsync(context As CreateTestSessionContext) As Task(Of CreateTestSessionResult) Implements ITestFramework.CreateTestSessionAsync
        Return Task.FromResult(New CreateTestSessionResult With {.IsSuccess = True})
    End Function

    Public Function CloseTestSessionAsync(context As CloseTestSessionContext) As Task(Of CloseTestSessionResult) Implements ITestFramework.CloseTestSessionAsync
        Return Task.FromResult(New CloseTestSessionResult With {.IsSuccess = True})
    End Function

    Public Async Function ExecuteRequestAsync(context As ExecuteRequestContext) As Task Implements ITestFramework.ExecuteRequestAsync
        If Not TypeOf context.Request Is DiscoverTestExecutionRequest AndAlso
            Not TypeOf context.Request Is RunTestExecutionRequest Then
            Throw New NotSupportedException("The request type isn't supported.")
        End If

        Dim request = DirectCast(context.Request, TestExecutionRequest)
        Dim selected As Boolean
        If TypeOf request.Filter Is NopFilter Then
            selected = True
        ElseIf TypeOf request.Filter Is TestNodeUidListFilter Then
            selected = DirectCast(request.Filter, TestNodeUidListFilter).TestNodeUids.Any(
                Function(uid) String.Equals(uid.Value, "coverage.test", StringComparison.Ordinal))
        Else
            Throw New NotSupportedException("The filter type isn't supported.")
        End If

        If selected Then
            context.CancellationToken.ThrowIfCancellationRequested()
            Dim state As TestNodeStateProperty = If(
                TypeOf request Is DiscoverTestExecutionRequest,
                DirectCast(DiscoveredTestNodeStateProperty.CachedInstance, TestNodeStateProperty),
                PassedTestNodeStateProperty.CachedInstance)
            Await context.MessageBus.PublishAsync(Me, New TestNodeUpdateMessage(
                request.Session.SessionUid,
                New TestNode With {
                    .Uid = New TestNodeUid("coverage.test"),
                    .DisplayName = "CoverageTest",
                    .Properties = New PropertyBag(state)
                }))
        End If

        context.Complete()
    End Function
End Class
