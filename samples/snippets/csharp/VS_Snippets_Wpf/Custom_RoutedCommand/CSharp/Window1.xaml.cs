using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        // The custom command.
        // Note, the command binding is done in XAML.
        //<SnippetCustom_RoutedCommandDefinition>
        public static RoutedCommand ColorCmd = new RoutedCommand();
        //</SnippetCustom_RoutedCommandDefinition>


        public Window1()
        {
            InitializeComponent();
        }

        //<SnippetCustom_RoutedCommandHandlers>
        // ExecutedRoutedEventHandler for the custom color command.
        private void ColorCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Panel target = e.Source as Panel;
            if (target != null)
            {
                if (target.Background == Brushes.AliceBlue)
                {
                    target.Background = Brushes.LemonChiffon;
                }
                else
                {
                    target.Background = Brushes.AliceBlue;
                }

            }
        }

        // CanExecuteRoutedEventHandler for the custom color command.
        private void ColorCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Source is Panel)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        //</SnippetCustom_RoutedCommandHandlers>



    }
}