
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '

    Private selector As New InkSelector()
    
    
    Public Sub New() 
        InitializeComponent()
        selector.Background = Brushes.Blue
        Me.root.Children.Add(selector)
        Me.WindowState = WindowState.Maximized
    
    End Sub
    
    
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Input.KeyEventArgs) 
        MyBase.OnKeyDown(e)
        
        If e.Key = System.Windows.Input.Key.S Then
            If selector.Mode = InkMode.Ink Then
                selector.Mode = InkMode.Select
            Else
                selector.Mode = InkMode.Ink
            End If
        End If 
        If e.Key = System.Windows.Input.Key.C Then
            If selector.InkDrawingAttributes.Color = Colors.Black Then
                selector.InkDrawingAttributes.Color = Colors.Yellow
            Else
                selector.InkDrawingAttributes.Color = Colors.Black
            End If
        End If
    
    End Sub
End Class
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected