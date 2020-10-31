Imports System

Namespace ca1044

    Public Class BadClassWithWriteOnlyProperty

        Dim someName As String

        ' Violates rule PropertiesShouldNotBeWriteOnly.
        WriteOnly Property Name As String
            Set
                someName = Value
            End Set
        End Property

    End Class

    Public Class GoodClassWithReadWriteProperty

        Property Name As String

    End Class

End Namespace
