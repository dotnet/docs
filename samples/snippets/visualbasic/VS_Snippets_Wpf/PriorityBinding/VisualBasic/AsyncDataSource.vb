Imports System
Imports System.Threading

'<Snippet1>
    Public Class AsyncDataSource
        ' Properties
        Public Property FastDP As String
            Get
                Return Me._fastDP
            End Get
            Set(ByVal value As String)
                Me._fastDP = value
            End Set
        End Property

        Public Property SlowerDP As String
            Get
                Thread.Sleep(3000)
                Return Me._slowerDP
            End Get
            Set(ByVal value As String)
                Me._slowerDP = value
            End Set
        End Property

        Public Property SlowestDP As String
            Get
                Thread.Sleep(5000)
                Return Me._slowestDP
            End Get
            Set(ByVal value As String)
                Me._slowestDP = value
            End Set
        End Property


        ' Fields
        Private _fastDP As String
        Private _slowerDP As String
        Private _slowestDP As String
    End Class
'</Snippet1>
