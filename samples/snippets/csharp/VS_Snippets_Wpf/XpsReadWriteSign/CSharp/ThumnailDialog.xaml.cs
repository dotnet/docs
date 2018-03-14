using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.IO;
using System.IO.Packaging;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for ThumnailDialog.xaml
    /// </summary>

    public partial class ThumnailDialog : Window
    {

        public ThumnailDialog(XpsDocument xpsDocument)
        {
            InitializeComponent();
            _xpsDocument = xpsDocument;
            if (xpsDocument.Thumbnail != null)
            {
                thumbnailDisplay.Fill =new ImageBrush(BitmapFrame.Create(xpsDocument.Thumbnail.GetStream()));
                addThumbnailButton.IsEnabled = false;
            }
        }

        private void AddThumbnail( object sender, RoutedEventArgs e )
        {
            FixedDocumentSequence docSeq =  _xpsDocument.GetFixedDocumentSequence();
            DocumentPaginator paginator = docSeq.DocumentPaginator;
            DocumentPage page = paginator.GetPage(0);
            // Create a rendertarget for the glyphs element. Round up width and height
            RenderTargetBitmap rt = new RenderTargetBitmap((int)page.Size.Width,
                                                        (int)page.Size.Height,
                                                        96, 96,
                                                        PixelFormats.Default);

            
            FixedPage fixedPage = (FixedPage)page.Visual;
            fixedPage.Measure(new Size(page.Size.Width, page.Size.Height) );
            fixedPage.Arrange(new Rect( new Size(page.Size.Width, page.Size.Height)) );
            rt.Render(fixedPage);
            JpegBitmapEncoder jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add( BitmapFrame.Create( (BitmapSource)rt ));
            Stream stream = new MemoryStream();
            jpegEncoder.Save( stream );
            XpsThumbnail thumbnail = _xpsDocument.AddThumbnail(XpsImageType.JpegImageType);
            Stream dstStream = thumbnail.GetStream();
            byte[] thumbnailData = new byte[stream.Length];
            // let's read the whole block into our buffer 
            int totalBytesRead = 0;
            int requestedCount = (int)stream.Length;
            stream.Position = 0;
            while (totalBytesRead < requestedCount)
            {
                int bytesRead = stream.Read(thumbnailData,
                                totalBytesRead,
                                requestedCount - totalBytesRead);
                if (bytesRead == 0)
                {
                    break;
                }
                totalBytesRead += bytesRead;
            }
            dstStream.Write(thumbnailData, 0, (int)stream.Length);
            dstStream.Close();
            thumbnail.Commit();
            _xpsDocument.Close();
            stream.Position = 0;
            ImageBrush imageBrush = new ImageBrush(BitmapFrame.Create(stream));
            imageBrush.Stretch = Stretch.Uniform;
            thumbnailDisplay.Fill = imageBrush;

            // Once a thumbnail is set disable the "Add Thumbnail" button.
            addThumbnailButton.IsEnabled = false;
       }
        private XpsDocument _xpsDocument;

    }
}