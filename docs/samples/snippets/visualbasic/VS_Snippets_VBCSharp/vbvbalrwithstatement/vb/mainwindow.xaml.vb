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


End Class
