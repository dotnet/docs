' <TracingConfiguration>
Imports System.Diagnostics
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Diagnostics.Tracing

Module Program
    Sub Main()
        Dim initialData As New Dictionary(Of String, String) From {
            {"Tracing:EnabledTracing:Default", "false"},
            {"Tracing:EnabledTracing:Contoso.Orders:Default", "true"},
            {"Tracing:EnabledTracing:Contoso.Orders:DisabledOperation", "false"}
        }

        Dim configuration As IConfigurationRoot =
            New ConfigurationBuilder().AddInMemoryCollection(initialData).Build()

        Dim services As New ServiceCollection()
        services.AddTracing(
            Sub(tracing)
                tracing.AddListener(
                    "Console",
                    Sub(listener)
                        listener.Sample = AddressOf SampleActivity
                        listener.SampleUsingParentId = AddressOf SampleActivityUsingParentId
                        listener.ActivityStarted =
                            Sub(activity) Console.WriteLine(
                                $"Listener started: {activity.OperationName}")
                    End Sub)
                tracing.AddConfiguration(configuration.GetSection("Tracing"))
            End Sub)

        Using serviceProvider As ServiceProvider = services.BuildServiceProvider()
            Dim factory As ActivitySourceFactory =
                serviceProvider.GetRequiredService(Of ActivitySourceFactory)()

            Using source As ActivitySource = factory.Create("Contoso.Orders")
                Console.WriteLine("Before reload:")
                WriteResult(source, "EnabledOperation")
                WriteResult(source, "DisabledOperation")

                configuration(
                    "Tracing:EnabledTracing:Contoso.Orders:DisabledOperation") = "true"
                configuration.Reload()

                Console.WriteLine("After reload:")
                WriteResult(source, "DisabledOperation")
            End Using
        End Using
    End Sub

    Private Function SampleActivity(
        ByRef options As ActivityCreationOptions(Of ActivityContext)
    ) As ActivitySamplingResult
        Return ActivitySamplingResult.AllData
    End Function

    Private Function SampleActivityUsingParentId(
        ByRef options As ActivityCreationOptions(Of String)
    ) As ActivitySamplingResult
        Return ActivitySamplingResult.AllData
    End Function

    Private Sub WriteResult(source As ActivitySource, operationName As String)
        Using activity As Activity = source.StartActivity(operationName)
            Dim state As String = If(activity Is Nothing, "disabled", "enabled")
            Console.WriteLine($"{operationName}: {state}")
        End Using
    End Sub
End Module
' </TracingConfiguration>
