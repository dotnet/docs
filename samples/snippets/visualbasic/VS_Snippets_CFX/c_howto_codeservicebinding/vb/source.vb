Imports System
Imports System.ServiceModel

Namespace Samples
    '<snippet1>
    <ServiceContract()> _
  Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Double, _
                     ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, ByVal _
                          n2 As Double) As Double

        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, _
                          ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Divide(ByVal n1 As Double, _
                        ByVal n2 As Double) As Double

    End Interface

    '</snippet1>

    '<snippet2>
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, _
                            ByVal n2 As Double) As Double Implements ICalculator.Add
            Return n1 + n2
        End Function

        Public Function Subtract(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Return n1 - n2
        End Function

        Public Function Multiply(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Return n1 * n2
        End Function

        Public Function Divide(ByVal n1 As Double, _
                               ByVal n2 As Double) As Double Implements ICalculator.Divide
            Return n1 / n2
        End Function

    End Class

    '</snippet2>
    Public Class Test

        Public Shared Sub Snippets()

            Dim baseAddress = "http://localhost/CalculatorService"

            '<snippet7>
            Dim host As New ServiceHost(GetType(CalculatorService), New Uri(baseAddress))
            '</snippet7>

        End Sub
        Public Shared Sub Main()
            '<snippet3>

            ' Specify a base address for the service
            Dim baseAddress = "http://localhost/CalculatorService"
            ' Create the binding to be used by the service.

            Dim binding1 As New BasicHttpBinding()
            '</snippet3>		
            '<snippet5>

            Dim modifiedCloseTimeout As New TimeSpan(0, 2, 0)
            binding1.CloseTimeout = modifiedCloseTimeout
            '</snippet5>

            '<snippet4>

            '<snippet6>

            Using host As New ServiceHost(GetType(CalculatorService))
                With host
                    .AddServiceEndpoint(GetType(ICalculator), _
                                            binding1, _
                                            baseAddress)

                    '</snippet6>
                    host.Open()
                End With
            End Using
            '</snippet4>
            Console.WriteLine("Press <ENTER> to close...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace
