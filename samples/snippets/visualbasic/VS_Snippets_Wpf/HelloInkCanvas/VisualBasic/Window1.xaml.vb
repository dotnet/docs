
Imports System
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
    Inherits Window

    Public Sub New() 
        'InitializeComponent()
    
    End Sub 'New
    
    
    '<Snippet2>
    ' Set the EditingMode to ink input.
    Private Sub Ink(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
        
        ' Set the DefaultDrawingAttributes for a red pen.
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Red
        inkCanvas1.DefaultDrawingAttributes.IsHighlighter = False
        inkCanvas1.DefaultDrawingAttributes.Height = 2
    
    End Sub 'Ink

    ' Set the EditingMode to highlighter input.
    Private Sub Highlight(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
        
        ' Set the DefaultDrawingAttributes for a highlighter pen.
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Yellow
        inkCanvas1.DefaultDrawingAttributes.IsHighlighter = True
        inkCanvas1.DefaultDrawingAttributes.Height = 25
    
    End Sub 'Highlight
    
    
    ' Set the EditingMode to erase by stroke.
    Private Sub EraseStroke(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke
    
    End Sub 'EraseStroke
    
    ' Set the EditingMode to selection.
    Private Sub [Select](ByVal sender As Object, ByVal e As RoutedEventArgs) 

        inkCanvas1.EditingMode = InkCanvasEditingMode.Select
    
    End Sub 'Select
    '</Snippet2>
End Class 'Window1 
