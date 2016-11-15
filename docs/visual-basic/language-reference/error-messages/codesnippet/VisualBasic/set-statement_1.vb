        Class propClass
            Private propVal As Integer
            Property prop1() As Integer
                Get
                    Return propVal
                End Get
                Set(ByVal value As Integer)
                    propVal = value
                End Set
            End Property
        End Class