using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            // Creating the main panel
            StackPanel MainStackPanel = new StackPanel();
            this.AddChild(MainStackPanel);

            //<SnippetCommandHandlerButtonCommandSource>
            // Button used to invoke the command
            Button CommandButton = new Button();
            CommandButton.Command = ApplicationCommands.Open;
            CommandButton.Content = "Open (KeyBindings: Ctrl-R, Ctrl-0)";
            MainStackPanel.Children.Add(CommandButton);
            //</SnippetCommandHandlerButtonCommandSource>

            //<SnippetCommandHandlerBindingInit>
            // Creating CommandBinding and attaching an Executed and CanExecute handler
            CommandBinding OpenCmdBinding = new CommandBinding(
                ApplicationCommands.Open,
                OpenCmdExecuted,
                OpenCmdCanExecute);

            this.CommandBindings.Add(OpenCmdBinding);
            //</SnippetCommandHandlerBindingInit>

            //<SnippetCommandHandlerKeyBindingCodeBehind>
            // Creating a KeyBinding between the Open command and Ctrl-R
            KeyBinding OpenCmdKeyBinding = new KeyBinding(
                ApplicationCommands.Open,
                Key.R,
                ModifierKeys.Control);

            this.InputBindings.Add(OpenCmdKeyBinding);
            //</SnippetCommandHandlerKeyBindingCodeBehind>
        }

        //<SnippetCommandHandlerExecutedHandler>
        void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("The command has been invoked.");
        }
        //</SnippetCommandHandlerExecutedHandler>

        //<SnippetCommandHandlerCanExecuteHandler>
        void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        //</SnippetCommandHandlerCanExecuteHandler>
    }
}