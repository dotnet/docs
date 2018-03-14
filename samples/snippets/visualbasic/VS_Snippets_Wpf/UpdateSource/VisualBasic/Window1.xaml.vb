Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Markup
    Public Class Window1
        Inherits Window

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Preview(ByVal sender As Object, ByVal args As RoutedEventArgs)
        '<Snippet1>
        Me.itemNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource()
        Me.bidPriceTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource()
        '</Snippet1>
        Me.userdata.Opacity = 1
        Me.Finish.Opacity = 1
    End Sub

    Private Sub Submit(ByVal sender As Object, ByVal args As RoutedEventArgs)
        Dim profile1 As New UserProfile
        profile1 = TryCast(Me.RootElem.DataContext, UserProfile)
        MessageBox.Show(("Thank you for your bid of " & profile1.BidPrice & " on item " & profile1.ItemName))
        Me.userdata.Opacity = 0
        Me.Finish.Opacity = 0
    End Sub


    End Class


