using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AdvancedInkInputSemples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        //StefansStylusControl stylusControl;
        public StylusControl inkSurface;
        DispatcherTimer timer;


        public Window1()
        {
            InitializeComponent();
            toggleFilter.Click += new RoutedEventHandler(toggleFilter_Click);
            addRemovePlugin.Click += new RoutedEventHandler(addRemovePlugin_Click);
            clearInk.Click += new RoutedEventHandler(clearInk_Click);
            isPluginActive.Click += new RoutedEventHandler(isPluginActive_Click);
            EnableElement.Click += new RoutedEventHandler(EnableElement_Click);
            KeyDown += new System.Windows.Input.KeyEventHandler(Window1_KeyDown);

            inkSurface = new StylusControl();
            inkSurface.Background = Brushes.Yellow;
            this.root.Children.Add(inkSurface);

            this.WindowState = WindowState.Maximized;
            //timer = new DispatcherTimer(TimeSpan.FromSeconds(2d), DispatcherPriority.Normal, new EventHandler(Tick), this.Dispatcher);

        }

        void EnableElement_Click(object sender, RoutedEventArgs e)
        {
            if (inkSurface.Visibility == Visibility.Visible)
            {
                inkSurface.Visibility = Visibility.Hidden;
            }
            else
            {
                inkSurface.Visibility = Visibility.Visible;
            }

            //inkSurface.IsEnabled = !inkSurface.IsEnabled;
        }

        void Tick(object sender, EventArgs e)
        {
            this.Title = inkSurface.IsFilterPluginActive.ToString();
        }

        void isPluginActive_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(inkSurface.IsFilterPluginActive.ToString());
        }

        void Window1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.T)
            {
                inkSurface.ToggleSelect();
            }

            if (e.Key == System.Windows.Input.Key.C)
            {
                inkSurface.ChangeDAOnCustomDR();
            }
        }


        void clearInk_Click(object sender, RoutedEventArgs e)
        {
            inkSurface.ClearInk();
        }

        void addRemovePlugin_Click(object sender, RoutedEventArgs e)
        {

            if (inkSurface.AddRemoveFilterPlugin())
            {
                addRemovePlugin.Content = "plugin added";
            }
            else
            {
                addRemovePlugin.Content = "plugin removed";
            }
        }

        void toggleFilter_Click(object sender, RoutedEventArgs e)
        {
            inkSurface.FilterEnabled = !inkSurface.FilterEnabled;

            if (inkSurface.FilterEnabled)
            {
                toggleFilter.Content = "filter is on";
            }
            else
            {
                toggleFilter.Content = "filter is off";
            }
            

        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, RoutedEventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }
}