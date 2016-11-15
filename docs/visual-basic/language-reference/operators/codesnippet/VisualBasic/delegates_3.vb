Module Module1

    Sub Main()
        ' Create an instance of InOrderClass and assign values to the properties.
        ' InOrderClass method ShowInOrder displays the numbers in ascending 
        ' or descending order, depending on the comparison method you specify.
        Dim inOrder As New InOrderClass
        inOrder.Num1 = 5
        inOrder.Num2 = 4

        ' Use AddressOf to send a reference to the comparison function you want
        ' to use.
        inOrder.ShowInOrder(AddressOf GreaterThan)
        inOrder.ShowInOrder(AddressOf LessThan)

        ' Use lambda expressions to do the same thing.
        inOrder.ShowInOrder(Function(m, n) m > n)
        inOrder.ShowInOrder(Function(m, n) m < n)
    End Sub

    Function GreaterThan(ByVal num1 As Integer, ByVal num2 As Integer) As Boolean
        Return num1 > num2
    End Function

    Function LessThan(ByVal num1 As Integer, ByVal num2 As Integer) As Boolean
        Return num1 < num2
    End Function

    Class InOrderClass
        ' Define the delegate function for the comparisons.
        Delegate Function CompareNumbers(ByVal num1 As Integer, ByVal num2 As Integer) As Boolean
        ' Display properties in ascending or descending order.
        Sub ShowInOrder(ByVal compare As CompareNumbers)
            If compare(_num1, _num2) Then
                Console.WriteLine(_num1 & "  " & _num2)
            Else
                Console.WriteLine(_num2 & "  " & _num1)
            End If
        End Sub

        Private _num1 As Integer
        Property Num1() As Integer
            Get
                Return _num1
            End Get
            Set(ByVal value As Integer)
                _num1 = value
            End Set
        End Property

        Private _num2 As Integer
        Property Num2() As Integer
            Get
                Return _num2
            End Get
            Set(ByVal value As Integer)
                _num2 = value
            End Set
        End Property
    End Class
End Module