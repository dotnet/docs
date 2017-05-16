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

        '<Snippet3>
        Private Sub ChangeExpandDirection(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            If (ExpandDown.IsChecked) Then
                myExpander.ExpandDirection = ExpandDirection.Down
            ElseIf (ExpandUp.IsChecked) Then
                myExpander.ExpandDirection = ExpandDirection.Up
            ElseIf (ExpandLeft.IsChecked) Then
                myExpander.ExpandDirection = ExpandDirection.Left
            ElseIf (ExpandRight.IsChecked) Then
                myExpander.ExpandDirection = ExpandDirection.Right
            End If

            'Expand myExpander so it is easier to see the effect of changing 
            'the ExpandDirection property for My Expander
            myExpander.IsExpanded = True
        End Sub
        '</Snippet3>
    End Class

End Namespace

