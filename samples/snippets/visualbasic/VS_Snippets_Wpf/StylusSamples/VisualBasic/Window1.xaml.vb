
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Input


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '

    Private textBoxContextMenu As ContextMenu
    Private onTabletMenu As ContextMenu
    
    '<Snippet6>
    Public Sub New() 
        InitializeComponent()
        '</Snippet6>    
        Me.WindowState = WindowState.Maximized
        textbox1.Background = Brushes.LightPink
        
        'AddHandler textbox1.StylusDown, AddressOf textbox1_StylusDown
        'AddHandler textbox1.StylusMove, AddressOf textbox1_StylusMove
        'AddHandler textbox1.StylusUp, AddressOf textbox1_StylusUp

        'AddHandler textbox1.PreviewStylusDown, AddressOf textbox1_PreviewStylusDown
        'AddHandler textbox1.PreviewStylusUp, AddressOf textbox1_PreviewStylusUp
        'AddHandler textbox1.StylusSystemGesture, AddressOf textbox1_StylusSystemGesture

        'AddHandler textbox1.GotStylusCapture, AddressOf textbox1_GotStylusCapture
        'AddHandler textbox1.LostStylusCapture, AddressOf textbox1_LostStylusCapture

        'AddHandler textbox1.StylusButtonDown, AddressOf textbox1_StylusButtonDown
        'AddHandler textbox1.StylusButtonUp, AddressOf textbox1_StylusButtonUp

        'AddHandler textbox1.PreviewStylusButtonDown, AddressOf textbox1_PreviewStylusButtonDown
        'AddHandler textbox1.PreviewStylusButtonUp, AddressOf textbox1_PreviewStylusButtonUp
        'AddHandler textbox1.PreviewStylusMove, AddressOf textbox1_PreviewStylusMove
        'AddHandler textbox1.PreviewStylusSystemGesture, AddressOf textbox1_PreviewStylusSystemGesture

        'AddHandler textbox1.PreviewStylusInRange, AddressOf textbox1_PreviewStylusInRange
        'AddHandler textbox1.PreviewStylusOutOfRange, AddressOf textbox1_PreviewStylusOutOfRange

        '        AddHandler Me.StylusInAirMove, AddressOf Window1_StylusInAirMove
        'AddHandler Me.PreviewStylusInAirMove, AddressOf Window1_PreviewStylusInAirMove
        'AddHandler Me.PreviewStylusDown, AddressOf Window1_PreviewStylusDown

        'AddHandler button1.StylusEnter, AddressOf button1_StylusEnter
        'AddHandler button1.StylusLeave, AddressOf button1_StylusLeave
        
        textBoxContextMenu = New ContextMenu()
        onTabletMenu = New ContextMenu()
        Dim airMenu As New MenuItem()
        airMenu.Header = "In Air"
        textBoxContextMenu.Items.Add(airMenu)
        
        Dim touchingMenu As New MenuItem()
        touchingMenu.Header = "On digitizer"
        onTabletMenu.Items.Add(touchingMenu)
    
    '<Snippet7>
    End Sub 'New
    '</Snippet7>

    '<Snippet22>
    Private Sub textbox1_PreviewStylusUp(ByVal sender As Object, _
        ByVal e As StylusEventArgs) Handles textbox1.PreviewStylusUp

        Dim pos As Point = e.GetPosition(textbox1)
        textbox1.AppendText("X: " & pos.X & " Y: " & pos.Y & vbLf)

    End Sub 'textbox1_PreviewStylusUp
    '</Snippet22>

    '<Snippet20>
    Private Sub textbox1_PreviewStylusOutOfRange(ByVal sender As Object, _
        ByVal e As StylusEventArgs) Handles textbox1.PreviewStylusOutOfRange

        If e.StylusDevice.Inverted Then
            textbox1.AppendText("Pen is inverted" & vbLf)
        Else
            textbox1.AppendText("Pen is not inverted" & vbLf)
        End If

    End Sub 'textbox1_PreviewStylusOutOfRange
    
    '</Snippet20>
    '<Snippet21>
    Private Sub textbox1_PreviewStylusInRange(ByVal sender As Object, _
        ByVal e As StylusEventArgs) Handles textbox1.PreviewStylusInRange

        If e.StylusDevice.Inverted Then
            textbox1.AppendText("Pen is inverted" & vbLf)
        Else
            textbox1.AppendText("Pen is not inverted" & vbLf)
        End If

    End Sub 'textbox1_PreviewStylusInRange
    '</Snippet21>

    '<Snippet17>
    Private Sub textbox1_PreviewStylusSystemGesture(ByVal sender As Object, _
        ByVal e As StylusSystemGestureEventArgs) Handles textbox1.PreviewStylusSystemGesture

        textbox1.AppendText(e.SystemGesture.ToString() & vbLf)

    End Sub 'textbox1_PreviewStylusSystemGesture
    '</Snippet17>

    '<Snippet16>
    Private Sub textbox1_PreviewStylusMove(ByVal sender As Object, _
        ByVal e As StylusEventArgs) Handles textbox1.PreviewStylusMove

        Dim pos As Point = e.GetPosition(textbox1)
        textbox1.AppendText("X: " & pos.X & " Y: " & pos.Y & vbLf)

    End Sub 'textbox1_PreviewStylusMove
    
    '</Snippet16>
    '<Snippet15>
    Private Sub Window1_PreviewStylusInAirMove(ByVal sender As Object, _
        ByVal e As StylusEventArgs) Handles Me.PreviewStylusInAirMove

        Dim element As Object
        element = CType(Stylus.DirectlyOver, Object)
        textbox1.AppendText(element.ToString() & vbLf)

    End Sub 'Window1_PreviewStylusInAirMove
    
    '</Snippet15>

    '<Snippet14>
    Private Sub textbox1_PreviewStylusButtonUp(ByVal sender As Object, _
        ByVal e As StylusButtonEventArgs) Handles textbox1.PreviewStylusButtonUp

        textbox1.AppendText(e.StylusButton.Name & vbLf)

    End Sub 'textbox1_PreviewStylusButtonUp
    '</Snippet14>

    '<Snippet13>
    Private Sub textbox1_PreviewStylusButtonDown(ByVal sender As Object, _
        ByVal e As StylusButtonEventArgs) Handles textbox1.PreviewStylusButtonDown

        textbox1.AppendText(e.StylusButton.Name & vbLf)

    End Sub 'textbox1_PreviewStylusButtonDown
    '</Snippet13>
    
    '<Snippet12>
    Private Sub textbox1_StylusSystemGesture(ByVal sender As Object, _
        ByVal e As StylusSystemGestureEventArgs) Handles textbox1.StylusSystemGesture

        textbox1.AppendText(e.SystemGesture.ToString() & vbLf)

    End Sub 'textbox1_StylusSystemGesture
    '</Snippet12>

    '<Snippet11>
    Private Sub textbox1_StylusButtonUp(ByVal sender As Object, ByVal e As StylusButtonEventArgs) _
        Handles textbox1.StylusButtonUp

        If e.StylusButton.Guid <> StylusPointProperties.BarrelButton.Id Then
            Return
        End If

        If textbox1.SelectedText = "" Then
            Return
        End If

        Clipboard.SetDataObject(textbox1.SelectedText)

    End Sub 'textbox1_StylusButtonUp
    '</Snippet11>

    '<snippet10>
    Private Sub textbox1_LostStylusCapture(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles textbox1.LostStylusCapture

        textbox1.Background = Brushes.White

    End Sub 'textbox1_LostStylusCapture
    
    
    Private Sub textbox1_GotStylusCapture(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles textbox1.GotStylusCapture

        textbox1.Background = Brushes.Red

    End Sub 'textbox1_GotStylusCapture
    
    '</snippet10>
    Private Sub PressAndHoldSnippets() 
        '<Snippet9>
        If Not Stylus.GetIsPressAndHoldEnabled(horizontalSlider1) Then
            Stylus.SetIsPressAndHoldEnabled(horizontalSlider1, True)
        End If
        '</Snippet9>
    End Sub 'PressAndHoldSnippets 
    
    '<Snippet4>
    Private originalColor As Brush
    
    Private Sub button1_StylusLeave(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles button1.StylusLeave

        button1.Background = originalColor

    End Sub 'button1_StylusLeave
    
    Private Sub button1_StylusEnter(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles button1.StylusEnter

        originalColor = button1.Background
        button1.Background = Brushes.Gray

    End Sub 'button1_StylusEnter
    '</Snippet4>

    '<Snippet5>
    Private Sub Window1_PreviewStylusDown(ByVal sender As Object, ByVal e As StylusDownEventArgs) _
        Handles Me.PreviewStylusDown

        Dim capturedElement As IInputElement = Stylus.Captured

        If Not (capturedElement Is Nothing) Then
            capturedElement.ReleaseStylusCapture()
        End If

    End Sub 'Window1_PreviewStylusDown
    '</Snippet5>

    '<Snippet3>
    Private Sub Window1_StylusInAirMove(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles Me.StylusInAirMove

        Dim element As Object
        element = CType(Stylus.DirectlyOver, Object)
        textbox1.AppendText(element.ToString() & vbLf)

    End Sub 'Window1_StylusInAirMove
    '</Snippet3>

    '<Snippet2>
    ' Show or hide a shortcut menu when the user clicks the barrel button.
    Private Sub textbox1_StylusButtonDown(ByVal sender As Object, ByVal e As StylusButtonEventArgs) _
        Handles textbox1.StylusButtonDown

        If e.StylusButton.Guid <> StylusPointProperties.BarrelButton.Id Then
            Return
        End If

        If textbox1.ContextMenu Is Nothing Then
            textbox1.ContextMenu = textBoxContextMenu
        Else
            textbox1.ContextMenu = Nothing
        End If

    End Sub 'textbox1_StylusButtonDown
    
    '</Snippet2>
    ' Close the context menu when the user taps on another part of the
    ' TextBox.
    Private Sub textbox1_PreviewStylusDown(ByVal sender As Object, ByVal e As StylusEventArgs)

        textbox1.ContextMenu = Nothing

    End Sub 'textbox1_PreviewStylusDown
    
    
    '<Snippet1>
    Private Sub textbox1_StylusDown(ByVal sender As Object, ByVal e As System.Windows.Input.StylusDownEventArgs) _
        Handles textbox1.StylusDown

        Stylus.Capture(textbox1)

    End Sub 'textbox1_StylusDown
    
    
    Private Sub textbox1_StylusMove(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles textbox1.StylusMove

        Dim pos As Point = e.GetPosition(textbox1)
        textbox1.AppendText("X: " & pos.X.ToString() & " Y: " & pos.Y.ToString() & vbLf)

    End Sub 'textbox1_StylusMove


    Private Sub textbox1_StylusUp(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles textbox1.StylusUp

        Stylus.Capture(textbox1, CaptureMode.None)

    End Sub 'textbox1_StylusUp

    '</Snippet1>
    '<Snippet8>
    Private Sub TextBoxStylusUp(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles textbox1.StylusUp

        Dim currentStylus As StylusDevice = Stylus.CurrentStylusDevice

        If currentStylus.Inverted Then
            Dim selectedText As String = textbox1.SelectedText
            textbox1.SelectedText = ""
        End If

    End Sub 'TextBoxStylusUp

    '</Snippet8>
    Private Sub WriteEventName(ByVal name As String)
        textbox1.AppendText(name & vbLf)
        textbox1.ScrollToEnd()

    End Sub 'WriteEventName
    'this.CaretIndex = this.Text.Length - 1;

    '<Snippet23>
    Private Sub textbox1_StylusInRange(ByVal sender As Object, ByVal e As StylusEventArgs)

        Dim buttons As StylusButtonCollection = e.StylusDevice.StylusButtons

        Dim barrelButton As StylusButton = buttons.GetStylusButtonByGuid(StylusPointProperties.BarrelButton.Id)

        If Not barrelButton Is Nothing Then
            textbox1.AppendText(barrelButton.StylusButtonState.ToString())
        End If

        textbox1.AppendText(vbCr & vbLf)

    End Sub
    '</Snippet23>

    ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
    ' private void WindowLoaded(object sender, EventArgs e) {}
    ' Sample event handler:  
    ' private void ButtonClick(object sender, RoutedEventArgs e) {}
    Private Sub Button1Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.textbox1.Text = ""

    End Sub 'Button1Click 
End Class 'Window1 
'Stylus.Capture(textbox1);
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected