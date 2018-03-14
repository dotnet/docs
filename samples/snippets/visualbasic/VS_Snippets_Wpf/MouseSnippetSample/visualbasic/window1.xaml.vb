Namespace WCSamples
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class Window1
        Inherits Window
        Public Shared CaptureMouseCommand As RoutedCommand

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            AddHandler MouseMove, AddressOf MouseMoveHighlightCapture
            AddHandler MouseDown, AddressOf MyMouseDown
            AddHandler GotMouseCapture, AddressOf MyGotMouseCapture
            AddHandler LostMouseCapture, AddressOf MyLostMouseCapture

            CaptureMouseCommand = New RoutedCommand()


            Dim CaptureMouseGesture As New MouseGesture(MouseAction.WheelClick, ModifierKeys.Control)
            Dim CaptureMouseCommandKeyGesture As New KeyGesture(Key.A, ModifierKeys.Alt)

            Dim CaptureMouseCommandBinding As New CommandBinding(CaptureMouseCommand, AddressOf CaptureMouseCommandExecuted, AddressOf CaptureMouseCommandCanExecute)

            Dim CaptureMouseCommandInputBinding As New InputBinding(CaptureMouseCommand, CaptureMouseGesture)
            Dim CaptureMouseCommandKeyBinding As New InputBinding(CaptureMouseCommand, CaptureMouseCommandKeyGesture)

            Me.CommandBindings.Add(CaptureMouseCommandBinding)
            Me.InputBindings.Add(CaptureMouseCommandInputBinding)
            Me.InputBindings.Add(CaptureMouseCommandKeyBinding)
        End Sub
        '<SnippetIsMouseCaptured>
        Private Sub CaptureMouseCommandExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
            MessageBox.Show("Mouse Command")
            Dim target As IInputElement = Mouse.DirectlyOver

            target = TryCast(target, Control)
            If target IsNot Nothing Then
                If Not target.IsMouseCaptured Then
                    Mouse.Capture(target)
                Else
                    Mouse.Capture(Nothing)
                End If
            End If
        End Sub
        '</SnippetIsMouseCaptured>
        Private Sub CaptureMouseCommandCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
            e.CanExecute = True
        End Sub


        '<SnippetMouseEventArgsPosition>
        Private Sub GetMousePosition(ByVal sender As Object, ByVal e As MouseEventArgs)
            ' Casting the MouseEventArgs.OriginalSource as an IInputElement.
            Dim source As IInputElement = TryCast(e.OriginalSource, IInputElement)

            ' If souce is not null, get the position.
            If source IsNot Nothing Then
                Dim position As Point = e.GetPosition(source)

                ' Updates a textbox with the current postion of the mouse,
                ' relative to the object which raised the event.
                txtBox.Text = position.ToString()
            End If
        End Sub
        '</SnippetMouseEventArgsPosition>

        '<SnippetMouseEventArgsMouseButton>
        Private Sub MouseDownHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
            '<SnippetMouseEventArgsRightButtonDown>
            If e.RightButton = MouseButtonState.Pressed Then
                MessageBox.Show("The Right Mouse Button is pressed")
            End If
            '</SnippetMouseEventArgsRightButtonDown>

            '<SnippetMouseEventArgsLeftButtonDown>
            If e.LeftButton = MouseButtonState.Pressed Then
                MessageBox.Show("The Left Mouse Button is pressed")
            End If
            '</SnippetMouseEventArgsLeftButtonDown>

            '<SnippetMouseEventArgsMiddleButtonDown>
            If e.MiddleButton = MouseButtonState.Pressed Then

                MessageBox.Show("The Middle Mouse Button is pressed")
            End If
            '</SnippetMouseEventArgsMiddleButtonDown>

            '<SnippetMouseEventArgsXButton1ButtonDown>
            If e.XButton1 = MouseButtonState.Pressed Then
                MessageBox.Show("The XButton1 Mouse Button is pressed")
            End If
            '</SnippetMouseEventArgsXButton1ButtonDown>

            '<SnippetMouseEventArgsXButton2ButtonDown>
            If e.XButton2 = MouseButtonState.Pressed Then
                MessageBox.Show("The XButton2 Mouse Button is pressed")
            End If
            '</SnippetMouseEventArgsXButton2ButtonDown>
        End Sub
        '</SnippetMouseEventArgsMouseButton>


        Private Sub GetDevices(ByVal sender As Object, ByVal e As MouseEventArgs)
            '<SnippetMouseEventArgsMouseDevice>
            Dim mouseDevice As MouseDevice = e.MouseDevice
            '</SnippetMouseEventArgsMouseDevice>

            '<SnippetMouseEventArgsStylusDevice>
            Dim stylusDevice As StylusDevice = e.StylusDevice
            '</SnippetMouseEventArgsStylusDevice>

        End Sub

        Private Sub btn1Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.Background = Brushes.WhiteSmoke

        End Sub

        '<SnippetMouseEventArgsChangedButton>
        Private Sub MouseButtonDownHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            Dim src As Control = TryCast(e.Source, Control)

            If src IsNot Nothing Then
                Select Case e.ChangedButton
                    Case MouseButton.Left
                        src.Background = Brushes.Green
                    Case MouseButton.Middle
                        src.Background = Brushes.Red
                    Case MouseButton.Right
                        src.Background = Brushes.Yellow
                    Case MouseButton.XButton1
                        src.Background = Brushes.Brown
                    Case MouseButton.XButton2
                        src.Background = Brushes.Purple
                    Case Else
                End Select
            End If
        End Sub
        '</SnippetMouseEventArgsChangedButton>

        '<SnippetMouseEventArgsClickCount>
        Private Sub ClickCount(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            Dim source As Label = TryCast(sender, Label)

            If source IsNot Nothing Then
                source.Content = e.ClickCount.ToString()
            End If
        End Sub
        '</SnippetMouseEventArgsClickCount>

        '<SnippetMouseEventArgsButtonStatePressed>
        Private Sub MouseButtonEventHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If e.ButtonState = MouseButtonState.Pressed Then
                Me.Background = Brushes.BurlyWood
            End If

            If e.ButtonState = MouseButtonState.Released Then
                Me.Background = Brushes.Ivory
            End If
        End Sub
        '</SnippetMouseEventArgsButtonStatePressed>

        '<SnippetMouseEventArgsButtonStateReleased>
        Private Sub MouseUpHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If e.ButtonState = MouseButtonState.Released Then
                Me.Background = Brushes.Ivory
            End If
        End Sub
        '</SnippetMouseEventArgsButtonStateReleased>


        '<SnippetMouseWheelDelta>
        ' Moves the TextBox named box when the mouse wheel is rotated.
        ' The TextBox is on a Canvas named MainCanvas.
        Private Sub MouseWheelHandler(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
            ' If the mouse wheel delta is positive, move the box up.
            If e.Delta > 0 Then
                If Canvas.GetTop(box) >= 1 Then
                    Canvas.SetTop(box, Canvas.GetTop(box) - 1)
                End If
            End If

            ' If the mouse wheel delta is negative, move the box down.
            If e.Delta < 0 Then
                If (Canvas.GetTop(box) + box.Height) <= MainCanvas.Height Then
                    Canvas.SetTop(box, Canvas.GetTop(box) + 1)
                End If
            End If

        End Sub
        '</SnippetMouseWheelDelta>


        '<SnippetMouseClickCountDoubleClick>
        Private Sub OnMouseDownClickCount(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            ' Checks the number of clicks.
            If e.ClickCount = 1 Then
                ' Single Click occurred.
                lblClickCount.Content = "Single Click"
            End If
            If e.ClickCount = 2 Then
                ' Double Click occurred.
                lblClickCount.Content = "Double Click"
            End If
            If e.ClickCount >= 3 Then
                ' Triple Click occurred.
                lblClickCount.Content = "Triple Click"
            End If
        End Sub
        '</SnippetMouseClickCountDoubleClick>



        Private Sub CaptureMouseOnMouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim mDevice As MouseDevice = e.MouseDevice
            Dim captureResult As Boolean

            captureResult = mDevice.Capture(captureTarget)

            If captureResult = True Then
                captureTarget.BorderBrush = Brushes.Red
            End If
        End Sub

        Private Sub MouseMoveHighlightCapture(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim sourceElement As IInputElement = e.MouseDevice.Captured
            If sourceElement IsNot Nothing Then
                captureTarget.Content = CType(sourceElement, Object).ToString()
            Else
                captureTarget.Content = "NULL"
            End If
            Dim sourceControl As Control = TryCast(sourceElement, Control)

            If sourceControl IsNot Nothing Then
                sourceControl.Background = Brushes.Blue
            End If
        End Sub

        Private Sub MyMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim sourceElement As IInputElement = e.MouseDevice.Captured
            If sourceElement IsNot Nothing Then
                captureButton.Content = CType(sourceElement, Object).ToString()
            Else
                captureButton.Content = "NULL"
            End If
        End Sub

        '<SnippetMouseSnippetsGotLostMouseCapture>
        Private Sub MyGotMouseCapture(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim source As Control = TryCast(e.Source, Control)

            If source IsNot Nothing Then
                source.Height += 50
                source.Width += 50
            End If

        End Sub
        Private Sub MyLostMouseCapture(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim source As Control = TryCast(e.Source, Control)

            If source IsNot Nothing Then
                source.Height -= 50
                source.Width -= 50
            End If

        End Sub
        '</SnippetMouseSnippetsGotLostMouseCapture>
    End Class


End Namespace