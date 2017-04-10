' Interaction logic for Window1.xaml
Imports System.Text

Partial Public Class Window1
    Inherits System.Windows.Window

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub infoBtn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
    '<Snippet4>

        If TypeOf tabCtrl1.SelectedContent Is Person Then

            Dim selectedPerson As Person = tabCtrl1.SelectedContent

            Dim personInfo As StringBuilder = New StringBuilder()

            personInfo.Append(selectedPerson.FirstName)
            personInfo.Append(" ")
            personInfo.Append(selectedPerson.LastName)
            personInfo.Append(", ")
            personInfo.Append(selectedPerson.HomeTown)
            MessageBox.Show(personInfo.ToString())
        End If
    '</Snippet4>
    End Sub

End Class

'<Snippet3>
Public Class PersonTemplateSelector
    Inherits DataTemplateSelector

    Public Overrides Function SelectTemplate(ByVal item As Object, _
                     ByVal container As DependencyObject) As DataTemplate

        ' The content of each TabItem is a Person object.
        If TypeOf item Is Person Then

            Dim person As Person = item

            Dim win As Window = Application.Current.MainWindow

            ' Select one of the DataTemplate objects, based on the 
            ' person's home town.
            If person.HomeTown = "Seattle" Then
                Return win.FindResource("SeattleTemplate")
            Else
                Return win.FindResource("DetailTemplate")

            End If
        End If

        Return Nothing
    End Function

End Class
'</Snippet3>


