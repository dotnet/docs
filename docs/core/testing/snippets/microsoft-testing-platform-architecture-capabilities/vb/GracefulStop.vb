Imports System
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.Testing.Platform.Builder
Imports Microsoft.Testing.Platform.Capabilities.TestFramework
Imports Microsoft.Testing.Platform.Extensions
Imports Microsoft.Testing.Platform.Extensions.TestFramework
Imports Microsoft.Testing.Platform.Helpers

Namespace GracefulStopExample
    ' <GracefulStop>
    Public NotInheritable Class GracefulStopCapability
        Implements IGracefulStopTestExecutionCapability

        Private _stopRequested As Integer

        Public ReadOnly Property IsStopRequested As Boolean
            Get
                Return Volatile.Read(_stopRequested) <> 0
            End Get
        End Property

        Public Function StopTestExecutionAsync(cancellationToken As CancellationToken) As Task _
            Implements IGracefulStopTestExecutionCapability.StopTestExecutionAsync

            cancellationToken.ThrowIfCancellationRequested()
            Interlocked.Exchange(_stopRequested, 1)
            Return Task.CompletedTask
        End Function
    End Class
    ' </GracefulStop>

    Public Module FrameworkRegistration
        ' <Registration>
        Public Sub Register(
            builder As ITestApplicationBuilder,
            owner As IExtension,
            createFramework As Func(Of GracefulStopCapability, ITestFramework))

            builder.RegisterTestFramework(
                Function(services) New TestFrameworkCapabilities(New GracefulStopCapability()),
                Function(capabilities, services) createFramework(
                    capabilities.Capabilities.OfType(Of GracefulStopCapability)().Single()))
            builder.AddMaximumFailedTestsService(owner)
        End Sub
        ' </Registration>
    End Module
End Namespace
