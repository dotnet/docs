Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace BindingGroupSnippets
    ''' <summary>
    ''' Interaction logic for Window3.xaml
    ''' </summary>
    Partial Public Class Window3
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetUpdateSourcesClick>
        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            sp1.BindingGroup.UpdateSources()
        End Sub
        '</SnippetUpdateSourcesClick>

        Private Sub ItemError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
            If e.Action = ValidationErrorEventAction.Added Then
                MessageBox.Show(e.Error.ErrorContent.ToString())

            End If
        End Sub
    End Class

    '<SnippetBindingGroupNameValidationRule>
    Public Class Type1
        Public Property PropertyA() As String

        Public Sub New()
            PropertyA = "Default Value"
        End Sub
    End Class

    Public Class Type2
        Public Property PropertyB() As String

        Public Sub New()
        End Sub
    End Class

    Public Class BindingGroupValidationRule
        Inherits ValidationRule
        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As System.Globalization.CultureInfo) As ValidationResult
            Dim bg As BindingGroup = TryCast(value, BindingGroup)

            Dim object1 As Type1 = Nothing
            Dim object2 As Type2 = Nothing

            For Each item As Object In bg.Items
                If TypeOf item Is Type1 Then
                    object1 = TryCast(item, Type1)
                End If

                If TypeOf item Is Type2 Then
                    object2 = TryCast(item, Type2)
                End If
            Next item

            If object1 Is Nothing OrElse object2 Is Nothing Then
                Return New ValidationResult(False, "BindingGroup did not find source object.")
            End If

            Dim string1 As String = TryCast(bg.GetValue(object1, "PropertyA"), String)
            Dim string2 As String = TryCast(bg.GetValue(object2, "PropertyB"), String)

            If string1 <> string2 Then
                Return New ValidationResult(False, "The two strings must be identical.")
            End If

            Return ValidationResult.ValidResult

        End Function

    End Class
    '</SnippetBindingGroupNameValidationRule>

    '<SnippetValueIsNotNull>
    Public Class ValueIsNotNull
        Inherits ValidationRule
        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As System.Globalization.CultureInfo) As ValidationResult
            Dim str As String = TryCast(value, String)

            If Not String.IsNullOrEmpty(str) Then
                Return ValidationResult.ValidResult
            Else
                Return New ValidationResult(False, "Value must not be null")
            End If
        End Function
    End Class
    '</SnippetValueIsNotNull>

End Namespace
