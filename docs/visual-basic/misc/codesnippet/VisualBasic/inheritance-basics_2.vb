    Class DerivedClass
        Inherits BaseClass
        Public Overrides Function CalculateShipping( 
            ByVal Dist As Double, 
            ByVal Rate As Double) As Double

            ' Call the method in the base class and modify the return value.
            Return MyBase.CalculateShipping(Dist, Rate) * 2
        End Function
    End Class