Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Markup

    Public Class Window1
        Inherits Window
        ' Methods
        Public Sub New()
            Me.InitializeComponent()
        End Sub

    Private Sub DisableCustomHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim binding1 As Binding = BindingOperations.GetBinding(Me.textBox3, TextBox.TextProperty)
        binding1.UpdateSourceExceptionFilter = Nothing
        BindingOperations.GetBindingExpression(Me.textBox3, TextBox.TextProperty).UpdateSource()
    End Sub

    Private Function ReturnExceptionHandler(ByVal bindingExpression As Object, ByVal exception As Exception) As Object
        Return "This is from the UpdateSourceExceptionFilterCallBack."
    End Function

    Private Sub UseCustomHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim expression1 As BindingExpression = Me.textBox3.GetBindingExpression(TextBox.TextProperty)
        expression1.ParentBinding.UpdateSourceExceptionFilter = New UpdateSourceExceptionFilterCallback(AddressOf Me.ReturnExceptionHandler)
        expression1.UpdateSource()
    End Sub
End Class

