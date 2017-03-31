
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Ink


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Partial Class Window1
    Inherits Window '

    Private adorner As RotatingStrokesAdorner
    Private adornerLayer As AdornerLayer


    Public Sub New()
        InitializeComponent()

    End Sub 'New

    '<Snippet3>
    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Add the rotating strokes adorner to the InkPresenter.
        adornerLayer = adornerLayer.GetAdornerLayer(inkPresenter1)
        adorner = New RotatingStrokesAdorner(inkPresenter1)

        adornerLayer.Add(adorner)

    End Sub 'Window_Loaded
    '</Snippet3>
End Class 'Window1 
