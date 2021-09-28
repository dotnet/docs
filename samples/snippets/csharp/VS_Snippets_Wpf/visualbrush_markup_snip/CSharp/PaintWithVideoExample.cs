using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
namespace SDKSample
{
    public partial class PaintWithVideoExample : Page
    {
        public PaintWithVideoExample()
        {
            TextBlock myTextBlock1 = ReturnTextBlockWithMedia1();
            TextBlock myTextBlock2 = ReturnTextBlockWithMedia2();
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myTextBlock1);
            myStackPanel.Children.Add(myTextBlock2);

            this.Content = myStackPanel;
        }

        private TextBlock ReturnTextBlockWithMedia1()
        {
            // <SnippetGraphicsMMVideoAsTextBackgroundInline>
            MediaElement myMediaElement = new MediaElement();
            myMediaElement.Source = new Uri("sampleMedia\\xbox.wmv", UriKind.Relative);
            myMediaElement.IsMuted = true;

            VisualBrush myVisualBrush = new VisualBrush();
            myVisualBrush.Visual = myMediaElement;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.FontSize = 150;
            myTextBlock.Text = "Some Text";
            myTextBlock.FontWeight = FontWeights.Bold;

            myTextBlock.Foreground = myVisualBrush;
            // </SnippetGraphicsMMVideoAsTextBackgroundInline>
            return myTextBlock;
        }

        private TextBlock ReturnTextBlockWithMedia2()
        {
            // <SnippetGraphicsMMVideoAsTextBackgroundTiledInline>
            MediaElement myMediaElement = new MediaElement();
            myMediaElement.Source = new Uri("sampleMedia\\xbox.wmv", UriKind.Relative);
            myMediaElement.IsMuted = true;

            VisualBrush myVisualBrush = new VisualBrush();
            myVisualBrush.Viewport = new Rect(0, 0, 0.5, 0.5);
            myVisualBrush.TileMode = TileMode.Tile;
            myVisualBrush.Visual = myMediaElement;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.FontSize = 150;
            myTextBlock.Text = "Some Text";
            myTextBlock.FontWeight = FontWeights.Bold;

            myTextBlock.Foreground = myVisualBrush;
            // </SnippetGraphicsMMVideoAsTextBackgroundTiledInline>
            return myTextBlock;
        }
    }
}