
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Namespace SDKSample

    Partial Class SampleViewer
        Inherits Page

        Public Sub New()
            InitializeComponent()

            MyChainedBitmapSourcesExampleFrame.Content = New ChainedBitmapSourcesExample()
            MyCroppedBitmapExampleFrame.Content = New CroppedBitmapExample()
            MyFormatConvertedBitmapExampleFrame.Content = New FormatConvertedBitmapExample()
            MyFormatConvertedBitmapExample2Frame.Content = New FormatConvertedBitmapExample2()
            MyTransformedBitmapExampleFrame.Content = New TransformedBitmapExample()
            MyPixelFormatsExampleFrame.Content = New PixelFormatsExample()
            MyColorConvertedBitmapExampleFrame.Content = New ColorConvertedBitmapExample()
            MyRenderTargetBitmapExampleFrame.Content = New RenderTargetBitmapExample()
            MyRenderTargetBitmapEncodeExampleFrame.Content = New RenderTargetBitmapExample_Encode()
            MyBitmapSourceExampleFrame.Content = New BitmapSourceExample()
            MyBitmapDecoderExampleFrame.Content = New BitmapDecoderExample()

        End Sub 'New
    End Class 'SampleViewer 
End Namespace 'ImagingSnippetGallery
