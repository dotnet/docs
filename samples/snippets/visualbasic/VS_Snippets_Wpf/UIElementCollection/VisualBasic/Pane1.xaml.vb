Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Input

Namespace ElemCollMethodsVB

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        ' To add a handler for the Loaded event, put Loaded="OnLoaded" in root element of .xaml file.
        ' Private Sub OnLoaded(ByVal sender As Object, ByVal e As EventArg)
        ' End Sub

        ' Sample event handler:  
        ' Private Sub ButtonClick(ByVal sender As Object, ByVal e As ClickEventArgs)
        ' End Sub
        Dim btn, btn1, btn2, btn3 As System.Windows.Controls.Button
        ' <Snippet3>
        Private Sub AddButton(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            sp1.Children.Clear()
            btn = New Button()
            btn.Content = "New Button"
            sp1.Children.Add(btn)
        End Sub
        ' </Snippet3>
        ' <Snippet8>
        Private Sub RemoveButton(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If (sp1.Children.IndexOf(btn) >= 0) Or (sp1.Children.IndexOf(btn1) >= 0) Or (sp1.Children.IndexOf(btn2) >= 0) Or (sp1.Children.IndexOf(btn3) >= 0) Then
                sp1.Children.RemoveAt(0)
            End If
        End Sub
        ' </Snippet8>

        Private Sub InsertButton(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            sp1.Children.Clear()
            btn = New Button()
            btn.Content = "Click to insert button"
            sp1.Children.Add(btn)
            AddHandler btn.Click, AddressOf Me.InsertControls
            btn1 = New Button()
            btn1.Content = "Click to insert button"
            sp1.Children.Add(btn1)
            AddHandler btn1.Click, AddressOf Me.InsertControls
        End Sub
        
        ' <Snippet4>
        Private Sub InsertControls(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn2 = New Button()
            btn2.Content = "Inserted Button"
            sp1.Children.Insert(1, btn2)
        End Sub
        ' </Snippet4>
        Private Sub ShowIndex(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            sp1.Children.Clear()
            btn = New Button()
            btn.Content = "Click for index"
            AddHandler btn.Click, AddressOf Me.PrintIndex
            sp1.Children.Add(btn)

            btn1 = New Button()
            btn1.Content = "Click for index"
            sp1.Children.Add(btn1)
            AddHandler btn1.Click, AddressOf Me.PrintIndex1

            btn2 = New Button()
            btn2.Content = "Click for index"
            sp1.Children.Add(btn2)
            AddHandler btn2.Click, AddressOf Me.PrintIndex2

            btn3 = New Button()
            btn3.Content = "Click for index"
            sp1.Children.Add(btn3)
            AddHandler btn3.Click, AddressOf Me.PrintIndex3
        End Sub

        Private Sub PrintIndex(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn.Content = ((sp1.Children.IndexOf(btn)).ToString())
        End Sub
        Private Sub PrintIndex1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn1.Content = ((sp1.Children.IndexOf(btn1)).ToString())
        End Sub
        Private Sub PrintIndex2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn2.Content = ((sp1.Children.IndexOf(btn2)).ToString())
        End Sub
        Private Sub PrintIndex3(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn3.Content = ((sp1.Children.IndexOf(btn3)).ToString())
        End Sub
        ' <Snippet10>
        Private Sub ClearButtons(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            sp1.Children.Clear()
            btn = New Button()
            btn.Content = "Click to clear"
            sp1.Children.Add(btn)
            AddHandler btn.Click, AddressOf Me.ClearControls
            btn1 = New Button()
            btn1.Content = "Click to clear"
            sp1.Children.Add(btn1)
            AddHandler btn1.Click, AddressOf Me.ClearControls
            btn2 = New Button()
            btn2.Content = "Click to clear"
            sp1.Children.Add(btn2)
            AddHandler btn2.Click, AddressOf Me.ClearControls
            btn3 = New Button()
            btn3.Content = "Click to clear"
            sp1.Children.Add(btn3)
            AddHandler btn3.Click, AddressOf Me.ClearControls
        End Sub
        
        Private Sub ClearControls(ByVal sender As Object, ByVal e As RoutedEventArgs)
            sp1.Children.Clear()
        End Sub
        ' </Snippet10>

    End Class

End Namespace