Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Markup

    Public Class DirectionalBinding
        Inherits Grid
    '<SnippetOnRentRaise>
    Private Sub OnRentRaise(ByVal sender As Object, ByVal args As RoutedEventArgs)
        Dim _random As New System.Random()
        Dim num1 As Double = _random.Next(10)
        Dim expression1 As BindingExpression = BindingOperations.GetBindingExpression(Me.SavingsText, TextBlock.TextProperty)
        Dim income1 As NetIncome = DirectCast(expression1.DataItem, NetIncome)
        income1.Rent = CInt(((1 + (num1 / 100)) * income1.Rent))
    End Sub
    '</SnippetOnRentRaise>

    Private Sub OnTargetUpdated(ByVal sender As Object, ByVal args As DataTransferEventArgs)
        Dim element1 As FrameworkElement = TryCast(sender, FrameworkElement)
        Me.infoText.Text = ""
        Me.infoText.Text = (Me.infoText.Text & args.Property.Name & " property of a " & args.Property.OwnerType.Name)
        Me.infoText.Text = (Me.infoText.Text & " element (")
        Me.infoText.Text = (Me.infoText.Text & element1.Name)
        Me.infoText.Text = (Me.infoText.Text & ") updated...")
        Me.infoText.Text = (Me.infoText.Text & DateTime.Now.ToLongDateString)
        Me.infoText.Text = (Me.infoText.Text & " at ")
        Me.infoText.Text = (Me.infoText.Text & DateTime.Now.ToLongTimeString)
    End Sub
    End Class


