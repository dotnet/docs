//<SnippetSetImageSourceCODEBEHIND1>
using System;
//</SnippetSetImageSourceCODEBEHIND1>
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace ResourcesSample
{
    public partial class ImageSourceSnippetWindow : Window
    {
        public ImageSourceSnippetWindow()
        {
            InitializeComponent();
            //<SnippetSetImageSourceCODEBEHIND2>
            // Create Uri that maps to a resource
            Uri uri = new Uri("EmbeddedOrLooseResource.bmp", UriKind.Relative);
            // Load embedded resource
            this.resourceImage.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
            //</SnippetSetImageSourceCODEBEHIND2>
        }
    }
}
