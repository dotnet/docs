 ' <SnippetMediaElementCSharpExampleWholePage>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Input


Namespace SDKSample

    Partial Class StretchMediaElementExample
        Inherits Page
        ' Change the Stretch property to the selected value.
        Sub OnClickChangeStretch(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Dim btn As Button = CType(sender, Button)
            myMediaElement.Stretch = Stretch.Fill
            txt1.Text = btn.Name.ToString()
            Select Case btn.Name.ToString()
                Case "btnFill"
                    myMediaElement.Stretch = Stretch.Fill
                Case "btnNone"
                    myMediaElement.Stretch = Stretch.None
                Case "btnUniform"
                    myMediaElement.Stretch = Stretch.Uniform
                Case "btnUniformToFill"
                    myMediaElement.Stretch = Stretch.UniformToFill
            End Select

        End Sub 'OnClickChangeStretch
    End Class 'StretchMediaElementExample 
End Namespace 'SDKSample
' </SnippetMediaElementCSharpExampleWholePage>