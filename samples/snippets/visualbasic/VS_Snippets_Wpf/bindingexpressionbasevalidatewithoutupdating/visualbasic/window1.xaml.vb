'<SnippetWindowLogic>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data


Partial Public Class Window1
    Inherits Window
    Public Sub New()
        InitializeComponent()

        ' Create an object and set it to the window's DataContext.
        Dim item As New LibraryItem("Enter the title", "Enter the call number", DateTime.Now + New TimeSpan(14, 0, 0, 0))

        Me.DataContext = item
    End Sub

    '<SnippetValidateWithoutUpdate>
    ' Check whether the call number is valid when the
    ' TextBox loses foces.
    Private Sub CallNum_LostFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim be As BindingExpression = CallNum.GetBindingExpression(TextBox.TextProperty)

        be.ValidateWithoutUpdate()
    End Sub
    '</SnippetValidateWithoutUpdate>


    ' Show the validation error when one occurs.
    Private Sub CallNum_Error(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
        If e.Action = ValidationErrorEventAction.Added Then
            MessageBox.Show(e.[Error].ErrorContent.ToString())

        End If
    End Sub

    ' Update the source data object when the user clicks
    ' the submit button.
    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim be As BindingExpression = CallNum.GetBindingExpression(TextBox.TextProperty)

        be.UpdateSource()
    End Sub
End Class
'</SnippetWindowLogic>