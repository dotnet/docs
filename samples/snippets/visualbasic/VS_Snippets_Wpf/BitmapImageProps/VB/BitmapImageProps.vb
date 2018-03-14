
Imports System
Imports System.Collections.ObjectModel
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
            theWindow.Title = "BitmapImage Sample"

            '<Snippet1>
            ' Define a BitmapImage.
            Dim myImage As New Image()
            Dim bi As New BitmapImage()

            ' Begin initialization.
            bi.BeginInit()

            ' Set properties.
            bi.CacheOption = BitmapCacheOption.OnDemand
            bi.CreateOptions = BitmapCreateOptions.DelayCreation
            bi.DecodePixelHeight = 125
            bi.DecodePixelWidth = 125
            bi.Rotation = Rotation.Rotate90
            MessageBox.Show(bi.IsDownloading.ToString())
            bi.UriSource = New Uri("smiley.png", UriKind.Relative)

            ' End initialization.
            bi.EndInit()
            myImage.Source = bi
            myImage.Stretch = Stretch.None
            myImage.Margin = New Thickness(5)
            '</Snippet1>
            'Define a Second BitmapImage and Source
            Dim myImage2 As New Image()
            Dim bi2 As New BitmapImage()
            bi2.BeginInit()
            bi2.DecodePixelHeight = 75
            bi2.DecodePixelWidth = 75
            bi2.CacheOption = BitmapCacheOption.None
            bi2.CreateOptions = BitmapCreateOptions.PreservePixelFormat
            bi2.Rotation = Rotation.Rotate180
            bi2.UriSource = New Uri("smiley.png", UriKind.Relative)
            bi2.EndInit()
            myImage2.Source = bi2
            myImage2.Stretch = Stretch.None
            myImage2.Margin = New Thickness(5)

            '<Snippet2>
            Dim imageStream As New FileStream("tulipfarm.jpg", FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim myBitmapSource As BitmapSource = BitmapFrame.Create(imageStream)
            Dim myBitmapSourceFrame As BitmapFrame = CType(myBitmapSource, BitmapFrame)
            Dim sourceColorContext As ColorContext = myBitmapSourceFrame.ColorContexts(0)
            Dim destColorContext As New ColorContext(PixelFormats.Bgra32)
            Dim ccb As New ColorConvertedBitmap(myBitmapSource, sourceColorContext, destColorContext, PixelFormats.Pbgra32)
            Dim myImage3 As New Image()
            myImage3.Source = ccb
            myImage3.Stretch = Stretch.None
            imageStream.Close()
            '</Snippet2>
            'Show ColorConvertedBitmap Properties
            Dim imageStream2 As New FileStream("tulipfarm.jpg", FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim myBitmapSource2 As BitmapSource = System.Windows.Media.Imaging.BitmapFrame.Create(imageStream2)
            Dim myBitmapSourceFrame2 As BitmapFrame = CType(myBitmapSource, BitmapFrame)
            '<Snippet3>
            Dim myColorConvertedBitmap As New ColorConvertedBitmap()
            myColorConvertedBitmap.BeginInit()
            myColorConvertedBitmap.SourceColorContext = myBitmapSourceFrame2.ColorContexts(0)
            myColorConvertedBitmap.Source = myBitmapSource2
            myColorConvertedBitmap.DestinationFormat = PixelFormats.Pbgra32
            myColorConvertedBitmap.DestinationColorContext = New ColorContext(PixelFormats.Bgra32)
            myColorConvertedBitmap.EndInit()
            '</Snippet3>

            'Define a StackPanel
            Dim myStackPanel As New StackPanel()

            ' Add the images to the parent StackPanel
            myStackPanel.Children.Add(myImage)
            myStackPanel.Children.Add(myImage2)
            myStackPanel.Children.Add(myImage3)

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