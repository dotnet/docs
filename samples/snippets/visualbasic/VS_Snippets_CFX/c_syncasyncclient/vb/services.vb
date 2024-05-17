' <snippet1>
' <snippet2>

Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Text
Imports System.Threading

Namespace Microsoft.WCF.Documentation
    <ServiceContractAttribute(Namespace:="http://microsoft.wcf.documentation")> _
    Public Interface ISampleService

        <OperationContractAttribute> _
        Function SampleMethod(ByVal msg As String) As String

        <OperationContractAttribute(AsyncPattern:=True)> _
        Function BeginSampleMethod(ByVal msg As String, ByVal callback As AsyncCallback, ByVal asyncState As Object) As IAsyncResult

        'Note: There is no OperationContractAttribute for the end method.
        Function EndSampleMethod(ByVal result As IAsyncResult) As String

        ' <snippet6>
        <OperationContractAttribute(AsyncPattern:=True)> _
        Function BeginServiceAsyncMethod(ByVal msg As String, ByVal callback As AsyncCallback, ByVal asyncState As Object) As IAsyncResult

        ' Note: There is no OperationContractAttribute for the end method.
        Function EndServiceAsyncMethod(ByVal result As IAsyncResult) As String
    End Interface
    ' </snippet6>
    ' </snippet2>

    Public Class SampleService
        Implements ISampleService
#Region "ISampleService Members"

        Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
            Console.WriteLine("Called synchronous sample method with ""{0}""", msg)
            Return "The synchronous service greets you: " & msg
        End Function

        ' This asynchronously implemented operation is never called because
        ' there is a synchronous version of the same method.
        Public Function BeginSampleMethod(ByVal msg As String, ByVal callback As AsyncCallback, ByVal asyncState As Object) As IAsyncResult Implements ISampleService.BeginSampleMethod
            Console.WriteLine("BeginSampleMethod called with: " & msg)
            Return New CompletedAsyncResult(Of String)(msg)
        End Function

        Public Function EndSampleMethod(ByVal r As IAsyncResult) As String Implements ISampleService.EndSampleMethod
            Dim result As CompletedAsyncResult(Of String) = TryCast(r, CompletedAsyncResult(Of String))
            Console.WriteLine("EndSampleMethod called with: " & result.Data)
            Return result.Data
        End Function

        ' <snippet3>
        Public Function BeginServiceAsyncMethod(ByVal msg As String, ByVal callback As AsyncCallback, ByVal asyncState As Object) As IAsyncResult Implements ISampleService.BeginServiceAsyncMethod
            Console.WriteLine("BeginServiceAsyncMethod called with: ""{0}""", msg)
            Return New CompletedAsyncResult(Of String)(msg)
        End Function

        Public Function EndServiceAsyncMethod(ByVal r As IAsyncResult) As String Implements ISampleService.EndServiceAsyncMethod
            Dim result As CompletedAsyncResult(Of String) = TryCast(r, CompletedAsyncResult(Of String))
            Console.WriteLine("EndServiceAsyncMethod called with: ""{0}""", result.Data)
            Return result.Data
        End Function
        ' </snippet3>
#End Region
    End Class

    ' Simple async result implementation.
    Friend Class CompletedAsyncResult(Of T)
        Implements IAsyncResult
        Private data_Renamed As T

        Public Sub New(ByVal data As T)
            Me.data_Renamed = data
        End Sub

        Public ReadOnly Property Data() As T
            Get
                Return data_Renamed
            End Get
        End Property

#Region "IAsyncResult Members"
        Public ReadOnly Property AsyncState() As Object Implements IAsyncResult.AsyncState
            Get
                Return CObj(data_Renamed)
            End Get
        End Property

        Public ReadOnly Property AsyncWaitHandle() As WaitHandle Implements IAsyncResult.AsyncWaitHandle
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Public ReadOnly Property CompletedSynchronously() As Boolean Implements IAsyncResult.CompletedSynchronously
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property IsCompleted() As Boolean Implements IAsyncResult.IsCompleted
            Get
                Return True
            End Get
        End Property
#End Region
    End Class
End Namespace
' </snippet1>
