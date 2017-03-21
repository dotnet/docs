using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace WCSamples
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
        //<SnippetCommandHandlerBothHandlers>

        //<SnippetCommandHandlerExecutedHandler>
        void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            String command, targetobj;
            command = ((RoutedCommand)e.Command).Name;
            targetobj = ((FrameworkElement)target).Name;
            MessageBox.Show("The " + command +  " command has been invoked on target object " + targetobj);
        }
        //</SnippetCommandHandlerExecutedHandler>
        //<SnippetCommandHandlerCanExecuteHandler>
        void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        //</SnippetCommandHandlerCanExecuteHandler>

        //</SnippetCommandHandlerBothHandlers>
    }
}