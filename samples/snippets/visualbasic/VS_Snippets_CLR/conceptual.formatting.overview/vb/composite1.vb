' Visual Basic .NET Document
Option Strict On

Public Class Product
    Private productName As String
    Private onHand As Integer
    Private cost As Decimal

    Public Sub New(name As String)
        Me.productName = name
    End Sub

    Public Property Quantity As Integer
        Get
            Return Me.onHand
        End Get
        Set
            Me.onHand = value
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return Me.cost
        End Get
        Set
            Me.cost = value
        End Set
    End Property

    Public ReadOnly Property Value As Decimal
        Get
            Return Me.cost * Me.onHand
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return Me.productName
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.productName
    End Function
End Class

Module Example2
    Public Sub Main2()
        Dim item1 As New Product("WidgetA")
        item1.Quantity = 17
        item1.Price = 6.32D
        Dim thatDate As DateTime = #5/1/2009#
        Dim result As String
        ' <Snippet14>
        result = String.Format("On {0:d}, the inventory of {1} was worth {2:C2}.",
                               thatDate, item1, item1.Value)
        Console.WriteLine(result)
        ' The example displays output like the following if run on a system
        ' whose current culture is en-US:
        '       On 5/1/2009, the inventory of WidgetA was worth $107.44.
        ' </Snippet14>
    End Sub
End Module

