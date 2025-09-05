Class MainWindow 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        ShowFormAndMessage()
    End Sub


    ' With...End With Statement (Visual Basic)
    ' 340d5fbb-4f43-48ec-a024-80843c137817

    Private Sub ShowFormAndMessage()
        '<snippet1>
        Dim theWindow As New EntryWindow

        With theWindow
            With .InfoLabel
                .Content = "This is a message."
                .Foreground = Brushes.DarkSeaGreen
                .Background = Brushes.LightYellow
            End With

            .Title = "The Form Title"
            .Show()
        End With
        '</snippet1>
    End Sub


    '<snippet2>
    Private Sub AddCustomer()
        Dim theCustomer As New Customer

        With theCustomer
            .Name = "Coho Vineyard"
            .URL = "http://www.cohovineyard.com/"
            .City = "Redmond"
        End With

        With theCustomer.Comments
            .Add("First comment.")
            .Add("Second comment.")
        End With
    End Sub

    Public Class Customer
        Public Property Name As String
        Public Property City As String
        Public Property URL As String

        Public Property Comments As New List(Of String)
    End Class
    '</snippet2>

    '<snippet3>
    Private Sub DemonstrateStructureWithStatement()
        ' Create an array of structures - this is referenceable
        Dim points(2) As Point

        ' Valid: Array elements are referenceable, so assignments work
        With points(0)
            .X = 10
            .Y = 20
        End With

        ' Create a single structure variable - this is also referenceable
        Dim singlePoint As Point
        With singlePoint
            .X = 30
            .Y = 40
        End With

        ' Invalid: Using parentheses cuts reference ties
        ' With (points(0))
        '     .X = 50  ' This would cause BC30068 error
        '     .Y = 60
        ' End With

        ' Invalid: Function returns by value, not referenceable
        ' With GetPoint()
        '     .X = 70  ' This would cause BC30068 error
        '     .Y = 80
        ' End With
    End Sub

    Private Function GetPoint() As Point
        Return New Point With {.X = 1, .Y = 2}
    End Function

    Private Structure Point
        Public X As Integer
        Public Y As Integer
    End Structure
    '</snippet3>


End Class
