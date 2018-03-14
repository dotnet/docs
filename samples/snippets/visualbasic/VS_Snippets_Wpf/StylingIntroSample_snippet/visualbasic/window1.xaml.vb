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


Namespace StylingIntroSample
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class Window1
        Inherits System.Windows.Window
        Private Photos As PhotoList

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Photos = CType((TryCast(Me.Resources("MyPhotos"), ObjectDataProvider)).Data, PhotoList)
            Photos.Path = "...\...\Images"
        End Sub

        Private Sub SetNewStyle(ByVal sender As Object, ByVal e As RoutedEventArgs)
            'Dim TextBlockStyle2 As New Style(GetType(TextBlock), CType(Me.Resources("TitleText"), Style))
            'TextBlockStyle2.Setters.Add(New Setter(TextBlock.FontWeightProperty, FontWeights.Bold))
            'textblock1.Style = TextBlockStyle2
        End Sub

        Private Sub UnsetStyle(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetCode>
            textblock1.Style = CType(Me.Resources("TitleText"), Style)
            '</SnippetCode>
        End Sub
    End Class
End Namespace