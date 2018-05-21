    ''' <exception cref="System.OverflowException">
    ''' Thrown when <paramref name="denominator"/><c> = 0</c>.
    ''' </exception>
    Public Function IntDivide( 
            ByVal numerator As Integer, 
            ByVal denominator As Integer 
    ) As Integer
        Return numerator \ denominator
    End Function