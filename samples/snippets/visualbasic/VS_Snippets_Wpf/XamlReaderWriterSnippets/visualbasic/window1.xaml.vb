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
Imports System.Windows.Markup
Imports System.IO
Imports System.Xml
Imports System.ComponentModel

Namespace XamlReaderWriterSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Button1Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ButtonRoundTripSyncStream()
        End Sub

        Public Sub ButtonRoundTripSyncString()
            '<SnippetXamlReaderLoadXmlReader>
            ' Create the Button.
            Dim originalButton As New Button()
            originalButton.Height = 50
            originalButton.Width = 100
            originalButton.Background = Brushes.AliceBlue
            originalButton.Content = "Click Me"

            ' Save the Button to a string.
            Dim savedButton As String = XamlWriter.Save(originalButton)

            ' Load the button
            Dim stringReader As New StringReader(savedButton)
            Dim xmlReader As XmlReader = XmlReader.Create(stringReader)
            Dim readerLoadButton As Button = CType(XamlReader.Load(xmlReader), Button)
            '</SnippetXamlReaderLoadXmlReader>

            StackArea.Children.Add(readerLoadButton)

        End Sub

        Public Sub ButtonRoundTripSyncStream()
            '<SnippetXamlReaderLoadStream>
            ' Create the Button.
            Dim originalButton As New Button()
            originalButton.Height = 50
            originalButton.Width = 100
            originalButton.Background = Brushes.AliceBlue
            originalButton.Content = "Click Me"

            ' Save the Button to a string.
            Dim savedButton As Stream = New MemoryStream()
            XamlWriter.Save(originalButton, savedButton)

            ' Reset the position of the Stream.
            savedButton.Position = 0

            ' Load the button.
            Dim readerLoadButton As Button = CType(XamlReader.Load(savedButton), Button)
            '</SnippetXamlReaderLoadStream>

            StackArea.Children.Add(readerLoadButton)
        End Sub

        ' Not being Snippeted right now
        Public Sub ButtonRoundTripASyncStream()
            ' Create the Button
            'Dim originalButton As Button = New Button
            'With originalButton
            '    .Height = 50
            '    .Width = 100
            '    .Background = Brushes.AliceBlue
            '    .Content = "Click Me"
            'End With

            ' Serialize the Button to a string
            'Dim seralizedButton As Stream = New MemoryStream
            'XamlWriter.Save(originalButton, seralizedButton)

            ' Reset the position of the Stream
            'seralizedButton.Position = 0

            ' Load the button
            'Dim xmlReasder As XmlReader = XmlReader.Create("F:\\Test\\seralizedButton.xaml")
            'Dim xreader As New XamlReader()

            'Dim deserializedButton As Button = CType(xreader.LoadAsync(xmlReasder), Button)

            'Me.Background = Brushes.AliceBlue
            'StackArea.Children.Add(deserializedButton)
        End Sub

        Private Sub xReader_LoadCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
            If e.Cancelled <> True Then
                ' Load new button

            End If
        End Sub
        Private Sub OnSerializeChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim source As RadioButton = TryCast(e.Source, RadioButton)
            If source IsNot Nothing Then
                Select Case source.Name
                    Case "RB1"
                        ButtonRoundTripSyncString()
                    Case "RB2"
                        ButtonRoundTripSyncStream()
                    Case "RB3"

                    Case "RB4"
                        ButtonRoundTripASyncStream()
                    Case Else

                End Select
            End If
        End Sub
	End Class
End Namespace