
Imports System
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Threading

Namespace SDKSample

    Public Class app
        Inherits Application
        Private myWindow As Window


        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()

        End Sub 'OnStartup

        Private Sub CreateAndShowMainWindow()

            ' Create the application's main window
            myWindow = New Window()
            myWindow.Title = "Image Metadata"

            ' <SnippetSetQuery>
            Dim pngStream As New System.IO.FileStream("smiley.png", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            Dim pngDecoder As New PngBitmapDecoder(pngStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim pngFrame As BitmapFrame = pngDecoder.Frames(0)
            Dim pngInplace As InPlaceBitmapMetadataWriter = pngFrame.CreateInPlaceBitmapMetadataWriter()
            If pngInplace.TrySave() = True Then
                pngInplace.SetQuery("/Text/Description", "Have a nice day.")
            End If
            pngStream.Close()
            ' </SnippetSetQuery>
            ' Draw the Image
            Dim myImage As New Image()
            myImage.Source = New BitmapImage(New Uri("smiley.png", UriKind.Relative))
            myImage.Stretch = Stretch.None
            myImage.Margin = New Thickness(20)

            ' <SnippetGetQuery>
            ' Add the metadata of the bitmap image to the text block.
            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "The Description metadata of this image is: " + pngInplace.GetQuery("/Text/Description").ToString()
            ' </SnippetGetQuery>
            ' Define a StackPanel to host Controls
            Dim myStackPanel As New StackPanel()
            myStackPanel.Orientation = Orientation.Vertical
            myStackPanel.Height = 200
            myStackPanel.VerticalAlignment = VerticalAlignment.Top
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Center

            ' Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage)
            myStackPanel.Children.Add(myTextBlock)

            ' Add the StackPanel as the Content of the Parent Window Object
            myWindow.Content = myStackPanel
            myWindow.Show()

        End Sub 'CreateAndShowMainWindow
    End Class 'app

    ' Define a static entry class

    Friend NotInheritable Class EntryClass

        <System.STAThread()> _
        Public Shared Sub Main()
            Dim app As New app()
            app.Run()

        End Sub 'Main
    End Class 'EntryClass
End Namespace 'SDKSample
