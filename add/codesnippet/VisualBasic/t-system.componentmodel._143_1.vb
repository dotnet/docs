    
    Private MyVar as Boolean = False
    <DefaultValue(False)> _
    Public Property MyProperty() As Boolean
        Get
            Return MyVar
        End Get
        Set
            MyVar = Value
        End Set 
    End Property
