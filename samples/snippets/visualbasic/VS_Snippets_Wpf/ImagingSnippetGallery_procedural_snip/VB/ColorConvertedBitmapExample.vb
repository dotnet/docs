
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel

Namespace SDKSample

    Class ColorConvertedBitmapExample
        Inherits Page
 
        Public Sub New()


            'How to use ColorConvertedBitmap
            Dim jpegFile As String = "sampleImages/WaterLilies.jpg"
            Dim imageStream As FileStream = New FileStream(jpegFile, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim bsrc As BitmapSource = BitmapFrame.Create(imageStream)
            Dim bsrcFrame As BitmapFrame = CType(bsrc, BitmapFrame)
            'ColorContext sourceColorContext = (ColorContext)bsrcFrame.ColorContexts;
            Dim sourceColorContext As New ColorContext(PixelFormats.Indexed1)
            ' Get the ColorContext from the BitmapFrame if there is one.
            Dim myColorContextCollection As ReadOnlyCollection(Of ColorContext)
            myColorContextCollection = bsrcFrame.ColorContexts
            If Not (myColorContextCollection Is Nothing) Then
                Dim myColorContext As ColorContext
                For Each myColorContext In myColorContextCollection
                    sourceColorContext = myColorContext
                Next myColorContext
            End If

            ' sourceColorContext= bsrcFrame.ColorContext;
            ' ColorContext sourceColorContext = new ColorContext();

            Dim destColorContext As New ColorContext(System.Windows.Media.PixelFormats.Indexed1)
            Dim ccb As New ColorConvertedBitmap(bsrc, sourceColorContext, destColorContext, PixelFormats.Bgr24)

            ' Create Image Element
            Dim myImage As New Image()
            myImage.Width = 200
            'set image source
            myImage.Source = ccb

            ' Add Image to the UI
            Dim myStackPanel As New StackPanel()
            'myStackPanel.Children.Add(myImage);
            'TextBlock tb = new TextBlock();
            'tb.Text = s;
            myStackPanel.Children.Add(myImage)
            Me.Content = myStackPanel

        End Sub
    End Class
End Namespace 'ImagingSnippetGallery
