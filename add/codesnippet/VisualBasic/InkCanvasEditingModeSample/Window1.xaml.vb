
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports System.Windows.Input


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

'<Snippet1>
Class Window1
    Inherits Window

    Private inkEditingMode As RadioButton
    Private selectEditingMode As RadioButton
    Private eraseByStrokeEditingMode As RadioButton
    Private eraseByPointEditingMode As RadioButton
    
    Private inkCanvas1 As InkCanvas
    Private stackPanel1 As StackPanel
    Private root As DockPanel
    
    Public Sub New() 
        InitializeComponent()
    
    End Sub 'New
    
    
    Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        root = New DockPanel()
        Me.Content = root

        stackPanel1 = New StackPanel()
        root.Children.Add(stackPanel1)
        
        inkEditingMode = New RadioButton()
        inkEditingMode.Content = "Ink"
        stackPanel1.Children.Add(inkEditingMode)
        AddHandler inkEditingMode.Click, AddressOf inkEditingMode_Click
        inkEditingMode.IsChecked = True
        
        selectEditingMode = New RadioButton()
        selectEditingMode.Content = "Select"
        stackPanel1.Children.Add(selectEditingMode)
        AddHandler selectEditingMode.Click, AddressOf selectEditingMode_Click
        
        eraseByStrokeEditingMode = New RadioButton()
        eraseByStrokeEditingMode.Content = "Erase by Stroke"
        stackPanel1.Children.Add(eraseByStrokeEditingMode)
        AddHandler eraseByStrokeEditingMode.Click, AddressOf eraseByStrokeEditingMode_Click
        
        eraseByPointEditingMode = New RadioButton()
        eraseByPointEditingMode.Content = "Erase by Point"
        stackPanel1.Children.Add(eraseByPointEditingMode)
        AddHandler eraseByPointEditingMode.Click, AddressOf eraseByPointEditingMode_Click
        
        inkCanvas1 = New InkCanvas()
        root.Children.Add(inkCanvas1)
    
    End Sub 'WindowLoaded
    
    
    Private Sub eraseByPointEditingMode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByPoint

    End Sub 'eraseByPointEditingMode_Click
    
    
    Private Sub eraseByStrokeEditingMode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke

    End Sub 'eraseByStrokeEditingMode_Click
    
    
    Private Sub selectEditingMode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        inkCanvas1.EditingMode = InkCanvasEditingMode.Select

    End Sub 'selectEditingMode_Click
    
    
    Private Sub inkEditingMode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink

    End Sub 'inkEditingMode_Click
End Class 'Window1
'</Snippet1>
