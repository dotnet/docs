using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace WindowsApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

      private void WindowLoaded(object sender, EventArgs e)
      {
        MakeExpander();
      }

//<Snippet1>

      void MakeExpander()
      {
        //Create containing stack panel and assign to Grid row/col
        StackPanel sp = new StackPanel();
        Grid.SetRow(sp, 0);
        Grid.SetColumn(sp, 1);
        sp.Background = Brushes.LightSalmon;

        //Create column title
        TextBlock colTitle = new TextBlock();
        colTitle.Text = "EXPANDER CREATED FROM CODE";
        colTitle.HorizontalAlignment= HorizontalAlignment.Center;
        colTitle.Margin.Bottom.Equals(20);
        sp.Children.Add(colTitle);

        //<SnippetCreateExpanderCode>
        //Create Expander object
        Expander exp = new Expander();

        //Create Bullet Panel for Expander Header
	//<SnippetBulletDecorator>
        BulletDecorator bp = new BulletDecorator();
        Image i = new Image();
        BitmapImage bi= new BitmapImage();
        bi.UriSource = new Uri(@"pack://application:,,/images/icon.jpg");
        i.Source = bi;
        i.Width = 10;
        bp.Bullet = i;
        TextBlock tb = new TextBlock();
        tb.Text = "My Expander";
        tb.Margin = new Thickness(20,0,0,0);
        bp.Child = tb;
        //</SnippetBulletDecorator>
        exp.Header = bp;

        //Create TextBlock with ScrollViewer for Expander Content
        StackPanel spScroll = new StackPanel();
        TextBlock tbc = new TextBlock();
        tbc.Text =
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit," +
                "sed do eiusmod tempor incididunt ut labore et dolore magna" +
                "aliqua. Ut enim ad minim veniam, quis nostrud exercitation" +
                "ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                "Duis aute irure dolor in reprehenderit in voluptate velit" +
                "esse cillum dolore eu fugiat nulla pariatur. Excepteur sint" +
                "occaecat cupidatat non proident, sunt in culpa qui officia" +
                "deserunt mollit anim id est laborum.";
        tbc.TextWrapping = TextWrapping.Wrap;

        spScroll.Children.Add(tbc);
        ScrollViewer scr = new ScrollViewer();
        scr.Content = spScroll;
        scr.Height = 50;
        exp.Content = scr;

        exp.Width=200;
        exp.HorizontalContentAlignment= HorizontalAlignment.Stretch;
        //</SnippetCreateExpanderCode>
        //Insert Expander into the StackPanel and add it to the
        //Grid
        sp.Children.Add(exp);
        myGrid.Children.Add(sp);
      }
      //</Snippet1>
  }
}