  Public Structure veryLong
      Dim highOrder As Long
      Dim lowOrder As Long
      Public Shared Operator +(ByVal v As veryLong, 
                               ByVal w As veryLong) As veryLong
          Dim sum As New veryLong
          sum = v
          Try
              sum.lowOrder += w.lowOrder
          Catch ex As System.OverflowException
              sum.lowOrder -= (Long.MaxValue - w.lowOrder + 1)
              sum.highOrder += 1
          End Try
          sum.highOrder += w.highOrder
          Return sum
      End Operator
  End Structure