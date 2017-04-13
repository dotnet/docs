
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Input


'/ <summary>
'/ Interaction logic for Window2.xaml
'/ </summary>

Class Window2
    Inherits Window '
    'ToDo: Error processing original source shown below
    '
    '    public partial class Window2 : Window
    '------------^--- 'class', 'struct', 'interface' or 'delegate' expected
    '
    'ToDo: Error processing original source shown below
    '
    '    public partial class Window2 : Window
    '--------------------^--- Syntax error: ';' expected
    'ScaleTransform buttonTransform = new ScaleTransform(1.5, 1.5);
    Private textbox1 As New TextBox()
    Private button1 As New Button()
    Private clearText As New Button()
    Private output As New TextBox()
    Private recordMoveCheckBox As New CheckBox()
    
    
    'InkCanvas inkCanvas1;
    Public Sub New() 
        InitializeComponent()

        Canvas.SetTop(textbox1, 0)
        Canvas.SetLeft(textbox1, 0)
        
        textbox1.Width = 200
        textbox1.Background = Brushes.DarkBlue
        'myCanvas.Children.Add(textbox1);
        Canvas.SetTop(button1, 0)
        Canvas.SetLeft(button1, 0)
        button1.Content = "Move me"
        
        AddHandler myCanvas.MouseMove, AddressOf myCanvas_MouseMove
        myCanvas.Children.Add(button1)
        button1.RenderTransform = Nothing
        AddHandler button1.Click, AddressOf button1_Click
        
        Canvas.SetTop(clearText, 25)
        Canvas.SetLeft(clearText, 0)
        clearText.Content = "Clear text"
        AddHandler clearText.Click, AddressOf clearText_Click
        myCanvas.Children.Add(clearText)
        
        
        
        
        Canvas.SetTop(output, 100)
        output.Width = 1000
        output.Height = 1000
        output.Background = Brushes.White
        
        myCanvas.Children.Add(output)
        
        AddHandler myCanvas.KeyDown, AddressOf myCanvas_KeyDown
        
        AnimateButton()
    
    End Sub 'New
    
    '<Snippet24>
    Sub AnimateButton() 
        Dim buttonTransform As New TranslateTransform(0, 0)
        button1.RenderTransform = buttonTransform
        
        ' Animate the Button's position.
        Dim myDoubleAnimation As New DoubleAnimation()
        myDoubleAnimation.From = 0
        myDoubleAnimation.By = 100
        myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
        myDoubleAnimation.AutoReverse = True
        myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever
        
        buttonTransform.BeginAnimation(TranslateTransform.XProperty, myDoubleAnimation)
    
    End Sub 'AnimateButton
    '</Snippet24>

    '<Snippet25>
    Sub SynchronizeStylus()

        Stylus.Synchronize()
        Dim element As UIElement = CType(Stylus.DirectlyOver, UIElement)
        output.Text += "The stylus is over " + element.ToString() & vbCr & vbLf

    End Sub 'SynchronizeStylus
    '</Snippet25>

    '<Snippet26>
    Sub SynchronizeCurrentStylus()

        Dim currentStylus As StylusDevice = Stylus.CurrentStylusDevice

        currentStylus.Synchronize()
        Dim element As UIElement = CType(currentStylus.DirectlyOver, UIElement)
        output.Text += "The stylus is over " + element.ToString() + vbCr + vbLf

    End Sub 'SynchronizeCurrentStylus
    '</Snippet26>

    
    Sub SynchronizeMouse() 
        Mouse.Synchronize()
        Dim element As UIElement = CType(Mouse.DirectlyOver, UIElement)
        output.Text += "The stylus is over " + element.ToString() + vbCr + vbLf
    
    End Sub 'SynchronizeMouse
    
    
    Private Sub myCanvas_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.R Then
            recordMouseMove = Not recordMouseMove
            output.Text += "Record MouseMove: " + recordMouseMove.ToString() + vbLf
            Return
        End If
        If e.Key = Key.M Then
            SynchronizeCurrentStylus()
        End If

    End Sub 'myCanvas_KeyDown
     
    
    Private Sub clearText_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        output.Text = ""
        recordMouseMove = False

    End Sub 'clearText_Click
    
    Private i As Integer = 0
    Private recordMouseMove As Boolean = False
    
    Private Sub myCanvas_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Not recordMouseMove Then
            Return
        End If
        'output.Text += "MouseMove: "
        'output.Text += Mouse.DirectlyOver.ToString() + ", " + Stylus.DirectlyOver.ToString() + " " + i.ToString() + vbCr + vbLf
        'i += 1
        'If i > 3 Then
        '    i = 0
        'End If

    End Sub 'myCanvas_MouseMove
     'Stylus.Synchronize();
    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

    End Sub 'button1_Click
    
    'recordMouseMove = true;
    'double buttonPos = Canvas.GetLeft(button1);
    'if (buttonPos == 0)
    '{
    '    Canvas.SetLeft(button1, 100);
    '}
    'else
    '{
    '    Canvas.SetLeft(button1, 0);
    '}
    'if (button1.LayoutTransform == null)
    '{
    '    //button1.LayoutTransform = buttonTransform;
    '}
    'else
    '{
    '    //button1.LayoutTransform = null;
    '}
    'UIElement elementBeforeSynchronize = (UIElement)Stylus.DirectlyOver;
    'Stylus.Synchronize();
    'UIElement elementAfterSynchronize = (UIElement)Stylus.DirectlyOver;
    'MessageBox.Show("Before Stylus.Synchronize: " + elementBeforeSynchronize.ToString() + "\r\n" +
    '"After Stylus.Synchronize: " + elementAfterSynchronize.ToString());
    'UIElement elementBeforeSynchronize = (UIElement)Mouse.DirectlyOver;
    'Mouse.Synchronize();
    'UIElement elementAfterSynchronize = (UIElement)Mouse.DirectlyOver;
    'MessageBox.Show("Before Mouse.Synchronize: " + elementBeforeSynchronize.ToString() + "\r\n" +
    '    "After Mouse.Synchronize: " + elementAfterSynchronize.ToString());
    
    
    
    Private Sub inkCanvas1_StylusDown(ByVal sender As Object, ByVal e As StylusDownEventArgs)
        Dim points As StylusPointCollection = e.StylusDevice.GetStylusPoints(inkCanvas1)

    End Sub 'inkCanvas1_StylusDown
    
    
    ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
    ' private void WindowLoaded(object sender, EventArgs e) {}
    ' Sample event handler:  
    ' private void ButtonClick(object sender, RoutedEventArgs e) {}
    '<Snippet18>
    Private Sub inkCanvas1_StylusInRange(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles inkCanvas1.StylusInRange

        If e.StylusDevice.Inverted = True Then
            inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke
            inkCanvas1.Cursor = System.Windows.Input.Cursors.Hand
        Else
            inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
            inkCanvas1.Cursor = System.Windows.Input.Cursors.Pen
        End If

    End Sub 'inkCanvas1_StylusInRange

    '</Snippet18>

    '<Snippet19>
    Private Sub inkCanvas1_StylusOutOfRange(ByVal sender As Object, ByVal e As StylusEventArgs) _
        Handles inkCanvas1.StylusOutOfRange

        inkCanvas1.Cursor = System.Windows.Input.Cursors.Arrow

    End Sub 'inkCanvas1_StylusOutOfRange
    '</Snippet19>

End Class 'Window2 
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected