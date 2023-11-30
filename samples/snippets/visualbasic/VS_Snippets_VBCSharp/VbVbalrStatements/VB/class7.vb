Public Class Class7
    ' f5fc0d51-67ce-4c36-9f09-31c9a91c94e9
    ' For...Next Statement (Visual Basic)

    Public Sub Process()

        '<Snippet111>
        For index As Integer = 1 To 5
            Debug.Write(index.ToString & " ")
        Next
        Debug.WriteLine("")
        ' Output: 1 2 3 4 5
        '</Snippet111>

        '<Snippet112>
        For number As Double = 2 To 0 Step -0.25
            Debug.Write(number.ToString & " ")
        Next
        Debug.WriteLine("")
        ' Output: 2 1.75 1.5 1.25 1 0.75 0.5 0.25 0 
        '</Snippet112>

        '<Snippet113>
        For indexA = 1 To 3
            ' Create a new StringBuilder, which is used
            ' to efficiently build strings.
            Dim sb As New System.Text.StringBuilder()

            ' Append to the StringBuilder every third number
            ' from 20 to 1 descending.
            For indexB = 20 To 1 Step -3
                sb.Append(indexB.ToString)
                sb.Append(" ")
            Next indexB

            ' Display the line.
            Debug.WriteLine(sb.ToString)
        Next indexA
        ' Output:
        '  20 17 14 11 8 5 2
        '  20 17 14 11 8 5 2
        '  20 17 14 11 8 5 2
        '</Snippet113>


        '<Snippet114>
        Dim lst As New List(Of Integer) From {10, 20, 30, 40}

        For index As Integer = lst.Count - 1 To 0 Step -1
            lst.RemoveAt(index)
        Next

        Debug.WriteLine(lst.Count.ToString)
        ' Output: 0
        '</Snippet114>


        '<Snippet115>
        For index As Integer = 1 To 100000
            ' If index is between 5 and 7, continue
            ' with the next iteration.
            If index >= 5 AndAlso index <= 8 Then
                Continue For
            End If

            ' Display the index.
            Debug.Write(index.ToString & " ")

            ' If index is 10, exit the loop.
            If index = 10 Then
                Exit For
            End If
        Next
        Debug.WriteLine("")
        ' Output: 1 2 3 4 9 10
        '</Snippet115>
    End Sub

    '<Snippet116>
    Public Enum Mammals
        Buffalo
        Gazelle
        Mongoose
        Rhinoceros
        Whale
    End Enum

    Public Sub ListSomeMammals()
        For mammal As Mammals = Mammals.Gazelle To Mammals.Rhinoceros
            Debug.Write(mammal.ToString & " ")
        Next
        Debug.WriteLine("")
        ' Output: Gazelle Mongoose Rhinoceros
    End Sub
    '</Snippet116>

    '<Snippet117>
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
    '</Snippet117>

End Class
