Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Collections.ObjectModel

Partial Public Class Window1
    Inherits Window


    Private Sub GetThirdCity_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Dim itemCollection As ObservableCollection(Of String) = _
            CType(Me.FindResource("myCities"), ObservableCollection(Of String))

        If itemCollection Is Nothing Then
            MessageBox.Show("myCities not found")
            Return
        End If

        Dim objectInCollection As Object = itemCollection(2)

        Dim cbi As ComboBoxItem = _
               CType(cb.ItemContainerGenerator.ContainerFromItem(objectInCollection), ComboBoxItem)

    End Sub

    Private Sub GetComboBoxItem(ByVal index As Integer)
        Dim cbi As ComboBoxItem = _
                CType(cb.ItemContainerGenerator.ContainerFromIndex(index), ComboBoxItem)

        cbi.IsSelected = True
        Info.Content = "I visited " & _
             (cbi.Content.ToString()) & "."
    End Sub

    Private Sub GetCity(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)

        Dim index As Integer = Convert.ToInt32(rb.Content.ToString())

        GetComboBoxItem(index)
    End Sub

End Class

Public Class Cities
    Inherits ObservableCollection(Of String)

    Public Sub New()
        Add("Spain - First stop")
        Add("France - Second stop")
        Add("Peru - Third stop")
        Add("Mexico - Fourth stop")

    End Sub
End Class


'<SnippetData>
Class VacationSpots
    Inherits ObservableCollection(Of String)
    Public Sub New()

        Add("Spain")
        Add("France")
        Add("Peru")
        Add("Mexico")
        Add("Italy")
    End Sub
End Class
'</SnippetData>