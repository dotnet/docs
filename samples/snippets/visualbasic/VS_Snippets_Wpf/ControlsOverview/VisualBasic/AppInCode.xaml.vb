
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
'/ Interaction logic for AppInCode.xaml
'/ </summary>

Partial Class AppInCode
    Inherits System.Windows.Window

    Public Sub New()
        InitializeComponent()

        Height = 300
        Width = 300

        CreateControls()
        SetLabelProperties()

    End Sub 'New


    Sub SetLabelProperties()
        '<Snippet4>
        Dim buttonBrush As New LinearGradientBrush()
        buttonBrush.StartPoint = New Point(0, 0.5)
        buttonBrush.EndPoint = New Point(1, 0.5)
        buttonBrush.GradientStops.Add(New GradientStop(Colors.Green, 0))
        buttonBrush.GradientStops.Add(New GradientStop(Colors.White, 0.9))

        submit.Background = buttonBrush
        submit.FontSize = 14
        submit.FontWeight = FontWeights.Bold
        '</Snippet4>

        '<Snippet8>
        AddHandler submit.Click, AddressOf submit_Click
        '</Snippet8>

    End Sub 'SetLabelProperties

    '<Snippet9>
    Private Sub submit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("Hello, " + firstName.Text + " " + lastName.Text)

    End Sub 'submit_Click
    '</Snippet9>

    '<Snippet2>
    Private firstNameLabel As Label
    Private lastNameLabel As Label
    Private firstName As TextBox
    Private lastName As TextBox
    Private submit As Button
    Private clear As Button

    Sub CreateControls()
        firstNameLabel = New Label()
        firstNameLabel.Content = "Enter your first name:"
        grid1.Children.Add(firstNameLabel)

        firstName = New TextBox()
        firstName.Margin = New Thickness(0, 5, 10, 5)
        Grid.SetColumn(firstName, 1)
        grid1.Children.Add(firstName)

        lastNameLabel = New Label()
        lastNameLabel.Content = "Enter your last name:"
        Grid.SetRow(lastNameLabel, 1)
        grid1.Children.Add(lastNameLabel)

        lastName = New TextBox()
        lastName.Margin = New Thickness(0, 5, 10, 5)
        Grid.SetColumn(lastName, 1)
        Grid.SetRow(lastName, 1)
        grid1.Children.Add(lastName)

        submit = New Button()
        submit.Content = "View message"
        Grid.SetRow(submit, 2)
        grid1.Children.Add(submit)

        clear = New Button()
        clear.Content = "Clear Name"
        Grid.SetRow(clear, 2)
        Grid.SetColumn(clear, 1)
        grid1.Children.Add(clear)


    End Sub 'CreateControls
    '</Snippet2>
End Class 'AppInCode
