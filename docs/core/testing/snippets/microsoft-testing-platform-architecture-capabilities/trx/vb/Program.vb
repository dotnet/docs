Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.Testing.Extensions
Imports Microsoft.Testing.Extensions.TrxReport.Abstractions
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
        ' <RegisterTrxCapability>
        Dim trxCapability As New TrxCapability()
        Dim builder = Await TestApplication.CreateBuilderAsync(args)
        builder.RegisterTestFramework(
            Function(services) New TestFrameworkCapabilities(trxCapability),
            Function(capabilities, services) New ReportFramework(trxCapability))
        builder.AddTrxReportProvider()
        ' </RegisterTrxCapability>

        Using application = Await builder.BuildAsync()
            Return Await application.RunAsync()
        End Using
    End Function
End Module

' <TrxCapability>
Friend NotInheritable Class TrxCapability
    Implements ITrxReportCapability

    Public ReadOnly Property IsSupported As Boolean Implements ITrxReportCapability.IsSupported
        Get
            Return True
        End Get
    End Property

    Public Property IsEnabled As Boolean
        Get
            Return _isEnabled
        End Get
        Private Set(value As Boolean)
            _isEnabled = value
        End Set
    End Property

    Private _isEnabled As Boolean

    Public Sub Enable() Implements ITrxReportCapability.Enable
        IsEnabled = True
    End Sub
End Class
' </TrxCapability>

Friend NotInheritable Class ReportFramework
    Implements ITestFramework, IDataProducer

    Private ReadOnly _trxCapability As TrxCapability
    Private Shared ReadOnly s_tests As (Uid As String, Name As String, Body As Action)() = {
        ("trx.pass", "PassingTest", Sub()
                                    End Sub),
        ("trx.fail", "FailingTest", Sub()
                                        Throw New InvalidOperationException("The sample assertion failed.")
                                    End Sub)
    }

    Public Sub New(trxCapability As TrxCapability)
        _trxCapability = trxCapability
    End Sub

    Public ReadOnly Property Uid As String Implements ITestFramework.Uid
        Get
            Return NameOf(ReportFramework)
        End Get
    End Property

    Public ReadOnly Property Version As String Implements ITestFramework.Version
        Get
            Return "1.0.0"
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements ITestFramework.DisplayName
        Get
            Return "TRX sample framework"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements ITestFramework.Description
        Get
            Return "Demonstrates TRX capability activation and metadata."
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
        For Each test In s_tests
            context.CancellationToken.ThrowIfCancellationRequested()
            Dim selected As Boolean
            If TypeOf request.Filter Is NopFilter Then
                selected = True
            ElseIf TypeOf request.Filter Is TestNodeUidListFilter Then
                selected = DirectCast(request.Filter, TestNodeUidListFilter).TestNodeUids.Any(
                    Function(uid) String.Equals(uid.Value, test.Uid, StringComparison.Ordinal))
            Else
                Throw New NotSupportedException("The filter type isn't supported.")
            End If

            If Not selected Then
                Continue For
            End If

            Dim testNode As New TestNode With {
                .Uid = New TestNodeUid(test.Uid),
                .DisplayName = test.Name
            }
            If TypeOf request Is DiscoverTestExecutionRequest Then
                testNode.Properties.Add(DiscoveredTestNodeStateProperty.CachedInstance)
            Else
                Dim failure As Exception = Nothing
                Try
                    test.Body()
                Catch exception As InvalidOperationException
                    failure = exception
                End Try

                If failure Is Nothing Then
                    testNode.Properties.Add(PassedTestNodeStateProperty.CachedInstance)
                Else
                    testNode.Properties.Add(New FailedTestNodeStateProperty(failure))
                End If

                ' <EnrichTrxResult>
                If _trxCapability.IsEnabled Then
                    testNode.Properties.Add(
                        New TrxFullyQualifiedTypeNameProperty("Contoso.CalculatorTests"))
                    testNode.Properties.Add(New TrxCategoriesProperty({"Unit"}))
                    testNode.Properties.Add(New TrxMessagesProperty(
                        {New StandardOutputTrxMessage($"Captured output for {test.Name}.")}))
                    If failure IsNot Nothing Then
                        testNode.Properties.Add(
                            New TrxExceptionProperty(failure.Message, failure.StackTrace))
                    End If
                End If
                ' </EnrichTrxResult>
            End If

            Await context.MessageBus.PublishAsync(
                Me, New TestNodeUpdateMessage(request.Session.SessionUid, testNode))
        Next

        context.Complete()
    End Function
End Class
