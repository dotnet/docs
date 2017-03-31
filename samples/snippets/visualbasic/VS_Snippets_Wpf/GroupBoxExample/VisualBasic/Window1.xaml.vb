Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1_xaml.xaml
    '@ </summary>
    Partial Class Window1
        '<Snippet2>
        Private Sub OnLoad(ByVal Sender As Object, ByVal e As RoutedEventArgs)
             displayData()
        End Sub


        Private Sub updateSummary(ByVal Sender As Object, _
                                  ByVal e As SelectionChangedEventArgs)
            If (GroupBoxPage.IsLoaded) Then
                displayData()
            End If
        End Sub


        Private Sub displayData()
            Dim lbi As ListBoxItem = empName.SelectedItem

            emp.Text = "Name: " + lbi.Content.ToString
            lbi = job.SelectedItem
            ejob.Text = "Job: " + lbi.Content.ToString
            lbi = skills.SelectedItem
            eskill.Text = "Strongest Skill: " + lbi.Content.ToString

        End Sub

        Private Sub showSummaryPanel(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            Summary.IsSelected = True
            displayData()

        End Sub
        '</Snippet2>

    End Class

End Namespace


