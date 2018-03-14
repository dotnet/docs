Namespace SDKSample

Public Class FontDialogBox
    Inherits Window

    ' Methods
    Public Sub New()
        Me.InitializeComponent()
        Me.fontFamilyListBox.ItemsSource = FontPropertyLists.FontFaces
        Me.fontStyleListBox.ItemsSource = FontPropertyLists.FontStyles
        Me.fontWeightListBox.ItemsSource = FontPropertyLists.FontWeights
        Me.fontSizeListBox.ItemsSource = FontPropertyLists.FontSizes
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MyBase.DialogResult = New Nullable(Of Boolean)(False)
    End Sub

    Private Sub fontFamilyTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Me.FontFamily = New FontFamily(Me.fontFamilyTextBox.Text)
    End Sub

    Private Sub fontSizeTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Dim size As Double
        If Double.TryParse(Me.fontSizeTextBox.Text, size) Then
            Me.FontSize = size
        End If
    End Sub

    Private Sub fontStyleTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        If FontPropertyLists.CanParseFontStyle(Me.fontStyleTextBox.Text) Then
            Me.FontStyle = FontPropertyLists.ParseFontStyle(Me.fontStyleTextBox.Text)
        End If
    End Sub

    Private Sub fontWeightTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        If FontPropertyLists.CanParseFontWeight(Me.fontWeightTextBox.Text) Then
            Me.FontWeight = FontPropertyLists.ParseFontWeight(Me.fontWeightTextBox.Text)
        End If
    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MyBase.DialogResult = New Nullable(Of Boolean)(True)
    End Sub

    Public Overloads Property FontFamily() As FontFamily
        Get
            Return DirectCast(Me.fontFamilyListBox.SelectedItem, FontFamily)
        End Get
        Set(ByVal value As FontFamily)
            Me.fontFamilyListBox.SelectedItem = value
            Me.fontFamilyListBox.ScrollIntoView(value)
        End Set
    End Property

    Public Overloads Property FontSize() As Double
        Get
            Return CDbl(Me.fontSizeListBox.SelectedItem)
        End Get
        Set(ByVal value As Double)
            Me.fontSizeListBox.SelectedItem = value
            Me.fontSizeListBox.ScrollIntoView(value)
        End Set
    End Property

    Public Overloads Property FontStyle() As FontStyle
        Get
            Return DirectCast(Me.fontStyleListBox.SelectedItem, FontStyle)
        End Get
        Set(ByVal value As FontStyle)
            Me.fontStyleListBox.SelectedItem = value
            Me.fontStyleListBox.ScrollIntoView(value)
        End Set
    End Property

    Public Overloads Property FontWeight() As FontWeight
        Get
            Return DirectCast(Me.fontWeightListBox.SelectedItem, FontWeight)
        End Get
        Set(ByVal value As FontWeight)
            Me.fontWeightListBox.SelectedItem = value
            Me.fontWeightListBox.ScrollIntoView(value)
        End Set
    End Property

End Class
End Namespace