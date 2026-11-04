Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.Testing.Platform.Builder
Imports Microsoft.Testing.Platform.Capabilities.TestFramework
Imports Microsoft.Testing.Platform.Extensions.Messages
Imports Microsoft.Testing.Platform.Extensions.TestFramework
Imports Microsoft.Testing.Platform.Requests

Module Program
    Function Main(args As String()) As Integer
        Return RunAsync(args).GetAwaiter().GetResult()
    End Function

    Private Async Function RunAsync(args As String()) As Task(Of Integer)
        Dim builder = Await TestApplication.CreateBuilderAsync(args)
        builder.RegisterTestFramework(
            Function(services) New TestFrameworkCapabilities(),
            Function(capabilities, services) New SampleFramework())
        Using application = Await builder.BuildAsync()
            Return Await application.RunAsync()
        End Using
    End Function
End Module

Friend NotInheritable Class SampleFramework
    Implements ITestFramework, IDataProducer

    Private Shared ReadOnly s_tests As (Uid As String, Name As String)() = {
        ("sample.first", "FirstTest"),
        ("sample.second", "SecondTest")
    }

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
            Return "Sample framework"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements ITestFramework.Description
        Get
            Return "Demonstrates UID filters and per-test output."
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

    ' <HandleFilters>
    Public Async Function ExecuteRequestAsync(context As ExecuteRequestContext) As Task Implements ITestFramework.ExecuteRequestAsync
        If Not TypeOf context.Request Is DiscoverTestExecutionRequest AndAlso
            Not TypeOf context.Request Is RunTestExecutionRequest Then
            Throw New NotSupportedException("The request type isn't supported.")
        End If

        Dim request = DirectCast(context.Request, TestExecutionRequest)
        For Each test In s_tests
            context.CancellationToken.ThrowIfCancellationRequested()
            Dim uid As New TestNodeUid(test.Uid)
            If Not MatchesFilter(request.Filter, uid) Then
                Continue For
            End If

            If TypeOf request Is DiscoverTestExecutionRequest Then
                Await context.MessageBus.PublishAsync(Me, New TestNodeUpdateMessage(
                    request.Session.SessionUid,
                    New TestNode With {
                        .Uid = uid,
                        .DisplayName = test.Name,
                        .Properties = New PropertyBag(DiscoveredTestNodeStateProperty.CachedInstance)
                    }))
            Else
                Await PublishResultAsync(context, request, uid, test.Name)
            End If
        Next

        context.Complete()
    End Function
    ' </HandleFilters>

    ' <MatchFilter>
    Private Shared Function MatchesFilter(filter As ITestExecutionFilter, uid As TestNodeUid) As Boolean
        If TypeOf filter Is NopFilter Then
            Return True
        End If

        Dim uidFilter = TryCast(filter, TestNodeUidListFilter)
        If uidFilter IsNot Nothing Then
            Return uidFilter.TestNodeUids.Any(
                Function(candidate) String.Equals(candidate.Value, uid.Value, StringComparison.Ordinal))
        End If

        Throw New NotSupportedException($"Filter '{filter.GetType().FullName}' isn't supported.")
    End Function
    ' </MatchFilter>

    Private Async Function PublishResultAsync(
        context As ExecuteRequestContext, request As TestExecutionRequest, uid As TestNodeUid, name As String) As Task
        ' <CapturedOutput>
        Dim testNode As New TestNode With {
            .Uid = uid,
            .DisplayName = name,
            .Properties = New PropertyBag(
                PassedTestNodeStateProperty.CachedInstance,
                New StandardOutputProperty($"Output from {name}."),
                New StandardErrorProperty($"Diagnostic from {name}."))
        }

        Await context.MessageBus.PublishAsync(
            Me, New TestNodeUpdateMessage(request.Session.SessionUid, testNode))
        ' </CapturedOutput>
    End Function
End Class
