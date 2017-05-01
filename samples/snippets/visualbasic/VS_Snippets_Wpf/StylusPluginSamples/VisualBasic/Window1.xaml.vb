
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Threading


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '

    Public inkSurface As StylusControl
    Private timer As DispatcherTimer
    
    
    
    Public Sub New() 
        InitializeComponent()
        AddHandler toggleFilter.Click, AddressOf toggleFilter_Click
        AddHandler addRemovePlugin.Click, AddressOf addRemovePlugin_Click
        AddHandler clearInk.Click, AddressOf clearInk_Click
        AddHandler isPluginActive.Click, AddressOf isPluginActive_Click
        AddHandler EnableElement.Click, AddressOf EnableElement_Click
        AddHandler KeyDown, AddressOf Window1_KeyDown
        
        inkSurface = New StylusControl()
        inkSurface.Background = Brushes.Yellow
        Me.root.Children.Add(inkSurface)
        
        Me.WindowState = WindowState.Maximized
    
    End Sub 'New


    Private Sub EnableElement_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If inkSurface.Visibility = Visibility.Visible Then
            inkSurface.Visibility = Visibility.Hidden
        Else
            inkSurface.Visibility = Visibility.Visible
        End If

    End Sub 'EnableElement_Click
     
    
    Private Sub Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.Title = inkSurface.IsFilterPluginActive.ToString()

    End Sub 'Tick
    
    
    Private Sub isPluginActive_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show(inkSurface.IsFilterPluginActive.ToString())

    End Sub 'isPluginActive_Click
    
    
    Private Sub Window1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs)
        If e.Key = System.Windows.Input.Key.T Then
            inkSurface.ToggleSelect()
        End If

        If e.Key = System.Windows.Input.Key.C Then
            inkSurface.ChangeDAOnCustomDR()
        End If

    End Sub 'Window1_KeyDown
    
    
    
    Private Sub clearInk_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        inkSurface.ClearInk()

    End Sub 'clearInk_Click
    
    
    Private Sub addRemovePlugin_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If inkSurface.AddRemoveFilterPlugin() Then
            addRemovePlugin.Content = "plugin added"
        Else
            addRemovePlugin.Content = "plugin removed"
        End If

    End Sub 'addRemovePlugin_Click
    
    
    Private Sub toggleFilter_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        inkSurface.FilterEnabled = Not inkSurface.FilterEnabled

        If inkSurface.FilterEnabled Then
            toggleFilter.Content = "filter is on"
        Else
            toggleFilter.Content = "filter is off"
        End If

    End Sub 'toggleFilter_Click 
End Class 'Window1 
