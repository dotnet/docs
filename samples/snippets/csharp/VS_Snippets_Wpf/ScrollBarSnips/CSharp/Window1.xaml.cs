using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ScrollBarSnips
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void InitializeScrollBar(object sender, EventArgs e)
        {

            //bool ScrollActive = myScrollBar.IsEnabledCore;
            //MessageBox.Show(ScrollActive.ToString());
            //<SnippetOrientation>
            myScrollBar.Orientation = Orientation.Horizontal;
            //</SnippetOrientation>

            //<SnippetTrack>
            Track myScrollBarTrack = new Track();
            myScrollBarTrack = myScrollBar.Track;
            //</SnippetTrack>

            //<SnippetViewport>
            myScrollBarViewport.ViewportSize = 10;
            //</SnippetViewport>

           //<SnippetCreateScrollBar>
           ScrollBar aScrollBar = new ScrollBar();
           aScrollBar.Orientation = Orientation.Vertical;
           aScrollBar.Width = 200;
           aScrollBar.Scroll += OnScroll;
           aScrollBar.Minimum = 0;
	       aScrollBar.Maximum = 50;
     	   //</SnippetCreateScrollBar>

        }

        
        //<SnippetScrollHandler>
        private void OnScroll(object sender, RoutedEventArgs e)
        {
           //Things to do when the Scroll event occurs
        }
        //</SnippetScrollHandler>
 
    }
}