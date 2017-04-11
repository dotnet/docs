Imports System
    Public Class MyDataSource
        ' Methods
        Public Sub New()
            Me.Age = 0
            Me.Age2 = 0
        End Sub


        ' Properties
        Public Property Age As Integer
            Get
                Return Me._age
            End Get
            Set(ByVal value As Integer)
                Me._age = value
            End Set
        End Property

        Public Property Age2 As Integer
            Get
                Return Me._age2
            End Get
            Set(ByVal value As Integer)
                Me._age2 = value
            End Set
        End Property

        Public Property Age3 As Integer
            Get
                Return Me._age3
            End Get
            Set(ByVal value As Integer)
                Me._age3 = value
            End Set
        End Property


        ' Fields
        Private _age As Integer
        Private _age2 As Integer
        Private _age3 As Integer
    End Class

