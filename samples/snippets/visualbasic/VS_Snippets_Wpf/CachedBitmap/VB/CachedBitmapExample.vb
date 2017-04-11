
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Threading

Namespace SDKSamples

    Public Class MyApp
        Inherits Application
        Private theWindow As Window


        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()

        End Sub 'OnStartup

        Private Sub CreateAndShowMainWindow()

            ' Create the application's main window
            theWindow = New Window()
            theWindow.Title = "CachedBitmap Imaging Sample"

            ' Create a BitmapSource using a Uri
            Dim [source] As BitmapSource = BitmapFrame.Create(New Uri("tulipfarm.jpg", UriKind.RelativeOrAbsolute))

            ' Create a new BitmapSource by scaling the original one.
            '<Snippet1>
            Dim scaledSource As New TransformedBitmap()
            scaledSource.BeginInit()
            scaledSource.Source = [source]
            scaledSource.Transform = New ScaleTransform(5, 5, 25, 25)
            scaledSource.EndInit()
            '</Snippet1>
            ' Create a cache for the scaled BitmapSource
            ' OnLoad will create the cache as soon as the new BitmapSource is created.
            '<Snippet4>
            '<Snippet2>
            Dim cachedSource As New CachedBitmap(scaledSource, BitmapCreateOptions.None, BitmapCacheOption.OnLoad)
            '</Snippet2>
            '<Snippet3>
            ' Create a new BitmapSource using a different format than the original one.
            Dim newFormatSource As New FormatConvertedBitmap()
            newFormatSource.BeginInit()
            newFormatSource.Source = cachedSource
            newFormatSource.DestinationFormat = PixelFormats.Gray32Float
            newFormatSource.EndInit()
            '</Snippet3>
            '</Snippet4>
            ' Define an Image Control to host the FormatConvertedImage
            Dim myImage As New Image()
            myImage.Source = newFormatSource

            ' Define a StackPanel to host Content
            Dim myStackPanel As New StackPanel()
            myStackPanel.Orientation = Orientation.Vertical
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch

            ' Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage)

            ' Add the StackPanel as the Content of the Parent Window Object
            theWindow.Content = myStackPanel
            theWindow.Show()

        End Sub 'CreateAndShowMainWindow
    End Class 'MyApp

    ' Define a static entry class

    Friend NotInheritable Class EntryClass

        <System.STAThread()> _
        Public Shared Sub Main()
            Dim app As New MyApp()
            app.Run()

        End Sub 'Main
    End Class 'EntryClass
End Namespace 'SDKSamples
