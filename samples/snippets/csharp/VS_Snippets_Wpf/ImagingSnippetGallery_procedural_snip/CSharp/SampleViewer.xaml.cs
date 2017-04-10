using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace SDKSample
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();

            MyChainedBitmapSourcesExampleFrame.Content = new ChainedBitmapSourcesExample();
            MyCroppedBitmapExampleFrame.Content = new CroppedBitmapExample();
            MyFormatConvertedBitmapExampleFrame.Content = new FormatConvertedBitmapExample();
            MyFormatConvertedBitmapExample2Frame.Content = new FormatConvertedBitmapExample2();
            MyTransformedBitmapExampleFrame.Content = new TransformedBitmapExample();
            MyPixelFormatsExampleFrame.Content = new PixelFormatsExample();
            MyColorConvertedBitmapExampleFrame.Content = new ColorConvertedBitmapExample();
            MyRenderTargetBitmapExampleFrame.Content = new RenderTargetBitmapExample();
            MyRenderTargetBitmapEncodeExampleFrame.Content = new RenderTargetBitmapExample_Encode();
            MyBitmapSourceExampleFrame.Content = new BitmapSourceExample();
            MyBitmapDecoderExampleFrame.Content = new BitmapDecoderExample();
        }
        
    }

 
}
