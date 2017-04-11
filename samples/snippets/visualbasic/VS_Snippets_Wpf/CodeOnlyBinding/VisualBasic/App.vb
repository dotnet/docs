Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data

Class MyApp
    Inherits Application

    ' Methods
    '<Snippet2>
    Private Sub OnClick(ByVal obj As Object, ByVal args As RoutedEventArgs)
        Dim element1 As FrameworkElement = DirectCast(obj, FrameworkElement)
        Select Case element1.Name
            Case "Clear"
                '<SnippetClearBinding>
                BindingOperations.ClearBinding(Me.myText, TextBlock.TextProperty)
                '</SnippetClearBinding>
            Case "Refresh"
                BindingOperations.ClearBinding(Me.myText, TextBlock.TextProperty)
                '<Snippet1>
                Dim data1 As New MyData(DateTime.Now)
                Dim binding1 As New Binding("MyDataProperty")
                binding1.Source = data1
                Me.myText.SetBinding(TextBlock.TextProperty, binding1)
                '</Snippet1>
        End Select
    End Sub
    '</Snippet2>

    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        Dim handler1 As RoutedEventHandler = New RoutedEventHandler(AddressOf Me.OnClick)
        Dim window1 As New Window
        window1.Width = 250
        window1.Height = 200
        Dim panel1 As New DockPanel
        window1.Content = panel1
        panel1.Width = 200
        panel1.Height = 150
        Me.dp = New DockPanel
        DockPanel.SetDock(Me.dp, Dock.Top)
        panel1.Children.Add(Me.dp)
        Me.button = New Button
        Me.button.Name = "Clear"
        Me.button.Content = "Clear Binding"
        Me.button.Width = 120
        Me.button.Height = 30
        AddHandler Me.button.Click, handler1
        DockPanel.SetDock(Me.button, Dock.Top)
        Me.dp.Children.Add(Me.button)
        Me.button2 = New Button
        Me.button2.Name = "Refresh"
        Me.button2.Content = "Refresh Binding"
        Me.button2.Width = 120
        Me.button2.Height = 30
        AddHandler Me.button2.Click, handler1
        DockPanel.SetDock(Me.button2, Dock.Top)
        Me.dp.Children.Add(Me.button2)
        Me.myText = New TextBlock
        Me.myText.Text = "no binding yet..."
        Me.myText.Height = 35
        Me.myText.HorizontalAlignment = HorizontalAlignment.Center
        DockPanel.SetDock(Me.myText, Dock.Top)
        Me.dp.Children.Add(Me.myText)

        Me.button3 = New Button()
        Me.button3.Content = "BindingOperations"
        Me.button3.Width = 120
        Me.button3.Height = 30
        AddHandler Me.button3.Click, New RoutedEventHandler(AddressOf Me.BindingOperationsClick)
        DockPanel.SetDock(Me.button3, Dock.Top)
        Me.dp.Children.Add(Me.button3)

        window1.Show()
    End Sub

    Private Sub BindingOperationsClick(ByVal obj As Object, ByVal args As RoutedEventArgs)
        BindingOperations.ClearBinding(Me.myText, TextBlock.TextProperty)

        '<SnippetBOSetBinding>
        Dim myDataObject As New MyData(DateTime.Now)
        Dim myBinding As New Binding("MyDataProperty")
        myBinding.Source = myDataObject
        BindingOperations.SetBinding(myText, TextBlock.TextProperty, myBinding)
        '</SnippetBOSetBinding>

    End Sub

    ' Fields
    Public button As Button
    Public button2 As Button
    Public button3 As Button
    Public dp As DockPanel
    Public myBinding As Binding
    Public myDataObject As MyData
    Public myText As TextBlock
End Class


