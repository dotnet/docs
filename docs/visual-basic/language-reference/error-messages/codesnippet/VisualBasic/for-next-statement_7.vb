    Private Class Distance
        Public Property Number() As Double

        Public Sub New(ByVal number As Double)
            Me.Number = number
        End Sub

        ' Define operator overloads to support For...Next statements.
        Public Shared Operator +(ByVal op1 As Distance, ByVal op2 As Distance) As Distance
            Return New Distance(op1.Number + op2.Number)
        End Operator

        Public Shared Operator -(ByVal op1 As Distance, ByVal op2 As Distance) As Distance
            Return New Distance(op1.Number - op2.Number)
        End Operator

        Public Shared Operator >=(ByVal op1 As Distance, ByVal op2 As Distance) As Boolean
            Return (op1.Number >= op2.Number)
        End Operator

        Public Shared Operator <=(ByVal op1 As Distance, ByVal op2 As Distance) As Boolean
            Return (op1.Number <= op2.Number)
        End Operator
    End Class


    Public Sub ListDistances()
        Dim distFrom As New Distance(10)
        Dim distTo As New Distance(25)
        Dim distStep As New Distance(4)

        For dist As Distance = distFrom To distTo Step distStep
            Debug.Write(dist.Number.ToString & " ")
        Next
        Debug.WriteLine("")

        ' Output: 10 14 18 22 
    End Sub