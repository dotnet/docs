' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Option Strict On

Imports System.IO
Imports System.ServiceModel
Imports System.Runtime.Serialization

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Integer, ByVal n2 As Integer) As Integer

        <OperationContract()> _
        Function Subtract(ByVal n1 As Integer, ByVal n2 As Integer) As Integer

        <OperationContract()> _
        Function Multiply(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        '<snippet1>
        <OperationContract()> _
        <FaultContract(GetType(MathFault))> _
        Function Divide(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        '</snippet1>

    End Interface

    '<snippet2>
    ' Define a math fault data contract
    <DataContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Class MathFault

        Private m_operation As String
        Private m_problemType As String

        <DataMember()> _
        Public Property Operation() As String

            Get

                Return m_operation

            End Get

            Set(ByVal value As String)

                m_operation = value

            End Set

        End Property

        <DataMember()> _
        Public Property ProblemType() As String

            Get

                Return m_problemType

            End Get

            Set(ByVal value As String)

                m_problemType = value

            End Set

        End Property

    End Class
    '</snippet2>

    ' Service class which implements the service contract.
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Integer, ByVal n2 As Integer) As Integer Implements ICalculator.Add

            Return n1 + n2

        End Function

        Public Function Subtract(ByVal n1 As Integer, ByVal n2 As Integer) As Integer Implements ICalculator.Subtract

            Return n1 - n2

        End Function

        Public Function Multiply(ByVal n1 As Integer, ByVal n2 As Integer) As Integer Implements ICalculator.Multiply

            Return n1 * n2

        End Function

        Public Function Divide(ByVal n1 As Integer, ByVal n2 As Integer) As Integer Implements ICalculator.Divide

            Try

                Return n1 \ n2

            Catch e As DivideByZeroException

                Dim mf As New MathFault()
                mf.Operation = "division"
                mf.ProblemType = "divide by zero"
                Throw New FaultException(Of MathFault)(mf)

            End Try

        End Function

    End Class

End Namespace
