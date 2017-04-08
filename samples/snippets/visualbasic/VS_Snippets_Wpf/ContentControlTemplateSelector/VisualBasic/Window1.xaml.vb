
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits System.Windows.Window

    Public Sub New() 
        InitializeComponent()
    
    End Sub 'New 
End Class 'Window1



'<Snippet2>
Public Class NumderDataTemplateSelector
    Inherits DataTemplateSelector

    Public Overrides Function SelectTemplate(ByVal item As Object, _
                    ByVal container As DependencyObject) As DataTemplate

        Dim numberStr As String = item '

        If Not (numberStr Is Nothing) Then
            Dim num As Integer
            Dim win As Window = Application.Current.MainWindow

            Try
                num = Convert.ToInt32(numberStr)
            Catch
                Return Nothing
            End Try

            ' Select one of the DataTemplate objects, based on the 
            ' value of the selected item in the ComboBox.
            If num < 5 Then
                Return win.FindResource("numberTemplate") '

            Else
                Return win.FindResource("largeNumberTemplate") '
            End If
        End If

        Return Nothing

    End Function 'SelectTemplate
End Class 'NumderDataTemplateSelector 
'</Snippet2>
