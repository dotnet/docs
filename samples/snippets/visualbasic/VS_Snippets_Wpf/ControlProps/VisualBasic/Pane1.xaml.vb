'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media

'@ <summary>
'@ Interaction logic for Pane1.xaml
'@ </summary>


Partial Public Class Pane1
    Inherits StackPanel


    Dim str As String
    Dim ffamily As FontFamily
    Dim fsize As Double

    ' To use PaneLoaded put Loaded="PaneLoaded" in root element of .xaml file.
    ' Sub PaneLoaded(object sender, EventArgs e) {}
    ' Sample event handler:  
    '<Snippet1>
    Private Sub ChangeBackground(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (Equals(btn.Background, Brushes.Red)) Then

            btn.Background = New LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90)
            btn.Content = "Control background changes from red to a blue gradient."

        Else

            btn.Background = Brushes.Red
            btn.Content = "Background"

        End If
    End Sub
    '</Snippet1>

    '<Snippet2>
    Private Sub ChangeForeground(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (Equals(btn1.Foreground, Brushes.Green)) Then

            btn1.Foreground = Brushes.Black
            btn1.Content = "Foreground"

        Else

            btn1.Foreground = Brushes.Green
            btn1.Content = "Control foreground(text) changes from black to green."
        End If
    End Sub
    '</Snippet2>

    '<Snippet3>
    Private Sub ChangeFontFamily(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        ffamily = btn2.FontFamily
        str = ffamily.ToString()
        If (str = ("Arial Black")) Then

            btn2.FontFamily = New FontFamily("Arial")
            btn2.Content = "FontFamily"

        Else

            btn2.FontFamily = New FontFamily("Arial Black")
            btn2.Content = "Control font family changes from Arial to Arial Black."

        End If
    End Sub
    '</Snippet3>


    '<Snippet4>
    Private Sub ChangeFontSize(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        fsize = btn3.FontSize
        If (fsize = 16.0) Then

            btn3.FontSize = 10.0
            btn3.Content = "FontSize"

        Else

            btn3.FontSize = 16.0
            btn3.Content = "Control font size changes from 10 to 16."
        End If
    End Sub
    '</Snippet4>

    '<Snippet5>
    Private Sub ChangeFontStyle(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (btn4.FontStyle = FontStyles.Italic) Then

            btn4.FontStyle = FontStyles.Normal
            btn4.Content = "FontStyle"

        Else

            btn4.FontStyle = FontStyles.Italic
            btn4.Content = "Control font style changes from Normal to Italic."
        End If
    End Sub
    '</Snippet5>

    '<Snippet6>
    Private Sub ChangeFontWeight(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (btn5.FontWeight = FontWeights.Bold) Then

            btn5.FontWeight = FontWeights.Normal
            btn5.Content = "FontWeight"

        Else

            btn5.FontWeight = FontWeights.Bold
            btn5.Content = "Control font weight changes from Normal to Bold."
        End If
    End Sub
    '</Snippet6>

    '<Snippet7>
    Private Sub ChangeBorderBrush(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (Equals(btn6.BorderBrush, Brushes.Red)) Then

            btn6.BorderBrush = Brushes.Black
            btn6.Content = "Control border brush changes from red to black."

        Else

            btn6.BorderBrush = Brushes.Red
            btn6.Content = "BorderBrush"
        End If
    End Sub
    '</Snippet7>

    '<Snippet8>
    Private Sub ChangeHorizontalContentAlignment(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (btn7.HorizontalContentAlignment = HorizontalAlignment.Left) Then

            btn7.HorizontalContentAlignment = HorizontalAlignment.Right
            btn7.Content = "Control horizontal alignment changes from left to right."

        Else

            btn7.HorizontalContentAlignment = HorizontalAlignment.Left
            btn7.Content = "HorizontalContentAlignment"
        End If
    End Sub
    '</Snippet8>

    '<Snippet9>
    Private Sub ChangeVerticalContentAlignment(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (btn8.VerticalContentAlignment = VerticalAlignment.Top) Then

            btn8.VerticalContentAlignment = VerticalAlignment.Bottom
            btn8.Content = "Control vertical alignment changes from top to bottom."

        Else

            btn8.VerticalContentAlignment = VerticalAlignment.Top
            btn8.Content = "VerticalContentAlignment"
        End If
    End Sub
    '</Snippet9>

End Class
