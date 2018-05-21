    ''' <summary>
    ''' Resets the value the <c>Counter</c> field.
    ''' </summary>
    Public Sub ResetCounter()
        counterValue = 0
    End Sub
    Private counterValue As Integer = 0
    ''' <summary>
    ''' Returns the number of times Counter was called.
    ''' </summary>
    ''' <value>Number of times Counter was called.</value>
    Public ReadOnly Property Counter() As Integer
        Get
            counterValue += 1
            Return counterValue
        End Get
    End Property