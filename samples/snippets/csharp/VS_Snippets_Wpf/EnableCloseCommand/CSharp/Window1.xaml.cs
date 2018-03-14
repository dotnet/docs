using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;


namespace WCSamples
{

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            //<SnippetCloseCommandBindingCodeBehind>
            // Create ui elements.
            StackPanel CloseCmdStackPanel = new StackPanel();
            Button CloseCmdButton = new Button();
            CloseCmdStackPanel.Children.Add(CloseCmdButton);

            // Set Button's properties.
            CloseCmdButton.Content = "Close File";
            CloseCmdButton.Command = ApplicationCommands.Close;

            // Create the CommandBinding.
            CommandBinding CloseCommandBinding = new CommandBinding(
                ApplicationCommands.Close, CloseCommandHandler, CanExecuteHandler);

            // Add the CommandBinding to the root Window.
            RootWindow.CommandBindings.Add(CloseCommandBinding);
            //</SnippetCloseCommandBindingCodeBehind>

            MainStackPanel.Children.Add(CloseCmdStackPanel);
        }

        //<SnippetCloseCommandHandler>
        // Executed event handler.
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // Calls a method to close the file and release resources.
            CloseFile();
        }

        // CanExecute event handler.
        private void CanExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            // Call a method to determine if there is a file open.
            // If there is a file open, then set CanExecute to true.
            if (IsFileOpened())
            {
                e.CanExecute = true;
            }
            // if there is not a file open, then set CanExecute to false.
            else
            {
                e.CanExecute = false;
            }
        }
        //</SnippetCloseCommandHandler>

        public void CloseFile()
        {
            MessageBox.Show("File is Closed");
        }

        public bool IsFileOpened()
        {
            return true;
        }
       

    }
}