Imports System.Activities.DurableInstancing
Imports System.Activities.Statements
Imports System.ServiceModel
Imports System.ServiceModel.Activities
Imports System.ServiceModel.Activities.Description
Namespace ConsoleX

    Class Program

        Shared Sub Main(ByVal args As String())

            ' host As WorkflowServiceHost

            Static Dim connectionString As String =
            "..."
            ' The Throw class derives from the Activity class, needed to
            ' construct a WorkflowServiceHost.
            Dim throwError As [Throw] = New [Throw]()

            Dim host As WorkflowServiceHost = New WorkflowServiceHost(throwError,
               New Uri("http://microsoft/services/"))
            '<snippet1>
            ' Code to create a WorkflowServiceHost not shown here.
            ' Note that SqlWorkflowInstanceStore is in the System.Activities.DurableInstancing.dll
            host.DurableInstancingOptions.InstanceStore = New SqlWorkflowInstanceStore(connectionString)
            ' Create a new workflow behavior.
            Dim alteredBehavior As WorkflowIdleBehavior = New WorkflowIdleBehavior()

            ' Alter the time to persist and unload.
            alteredBehavior.TimeToPersist = New TimeSpan(0, 4, 0)
            alteredBehavior.TimeToUnload = New TimeSpan(0, 5, 0)
            ' Remove the existing behavior and add the new one.
            host.Description.Behaviors.Remove(Of WorkflowIdleBehavior)()
            host.Description.Behaviors.Add(alteredBehavior)
            '</snippet1>
            Console.WriteLine(alteredBehavior.TimeToUnload.Minutes.ToString())
            'wfsh.Open()
            Console.WriteLine("closed")
            Console.ReadLine()
        End Sub

    End Class

    <ServiceContract()> Interface ICalculator
        <OperationContract()> Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
    End Interface

    Public Class Calculator
        Implements ICalculator

        Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICalculator.Add
            Return a + b
        End Function

    End Class

End Namespace
