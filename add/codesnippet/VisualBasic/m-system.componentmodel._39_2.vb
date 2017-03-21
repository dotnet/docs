Public Class CalculatePrimeCompletedEventArgs
    Inherits AsyncCompletedEventArgs
    Private numberToTestValue As Integer = 0
    Private firstDivisorValue As Integer = 1
    Private isPrimeValue As Boolean


    Public Sub New( _
    ByVal numberToTest As Integer, _
    ByVal firstDivisor As Integer, _
    ByVal isPrime As Boolean, _
    ByVal e As Exception, _
    ByVal canceled As Boolean, _
    ByVal state As Object)

        MyBase.New(e, canceled, state)
        Me.numberToTestValue = numberToTest
        Me.firstDivisorValue = firstDivisor
        Me.isPrimeValue = isPrime

    End Sub


    Public ReadOnly Property NumberToTest() As Integer
        Get
            ' Raise an exception if the operation failed 
            ' or was canceled.
            RaiseExceptionIfNecessary()

            ' If the operation was successful, return 
            ' the property value.
            Return numberToTestValue
        End Get
    End Property


    Public ReadOnly Property FirstDivisor() As Integer
        Get
            ' Raise an exception if the operation failed 
            ' or was canceled.
            RaiseExceptionIfNecessary()

            ' If the operation was successful, return 
            ' the property value.
            Return firstDivisorValue
        End Get
    End Property


    Public ReadOnly Property IsPrime() As Boolean
        Get
            ' Raise an exception if the operation failed 
            ' or was canceled.
            RaiseExceptionIfNecessary()

            ' If the operation was successful, return 
            ' the property value.
            Return isPrimeValue
        End Get
    End Property
End Class