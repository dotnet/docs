using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace SDKSamples
{
    public partial class Window1 : Window
    {
        //<SnippetCommandingOverviewCommandDefinition>
        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();
        //</SnippetCommandingOverviewCommandDefinition>

        public Window1()
        {
            InitializeComponent();

            //<SnippetCommandingOverviewKeyBinding>
            KeyGesture OpenKeyGesture = new KeyGesture(
                Key.B,
                ModifierKeys.Control);

            KeyBinding OpenCmdKeybinding = new KeyBinding(
                ApplicationCommands.Open,
                OpenKeyGesture);

            this.InputBindings.Add(OpenCmdKeybinding);
            //</SnippetCommandingOverviewKeyBinding>

            //<SnippetCommandingOverviewKeyGestureOnCmd>
            KeyGesture OpenCmdKeyGesture = new KeyGesture(
                Key.B,
                ModifierKeys.Control);

            ApplicationCommands.Open.InputGestures.Add(OpenCmdKeyGesture);
            //</SnippetCommandingOverviewKeyGestureOnCmd>

            //<SnippetCommandingOverviewCommandTargetCodeBehind>
            // Creating the UI objects
            StackPanel mainStackPanel = new StackPanel();
            TextBox pasteTextBox = new TextBox();
            Menu stackPanelMenu = new Menu();
            MenuItem pasteMenuItem = new MenuItem();

            // Adding objects to the panel and the menu
            stackPanelMenu.Items.Add(pasteMenuItem);
            mainStackPanel.Children.Add(stackPanelMenu);
            mainStackPanel.Children.Add(pasteTextBox);

            // Setting the command to the Paste command
            pasteMenuItem.Command = ApplicationCommands.Paste;

            // Setting the command target to the TextBox
            pasteMenuItem.CommandTarget = pasteTextBox;
            //</SnippetCommandingOverviewCommandTargetCodeBehind>

            //<SnippetCommandingOverviewCustomCommandSourceCodeBehind>
            // create the ui
            StackPanel CustomCommandStackPanel = new StackPanel();
            Button CustomCommandButton = new Button();
            CustomCommandStackPanel.Children.Add(CustomCommandButton);

            CustomCommandButton.Command = CustomRoutedCommand;
            //</SnippetCommandingOverviewCustomCommandSourceCodeBehind>

            //<SnippetCommandingOverviewCustomCommandBindingCodeBehind>
            CommandBinding customCommandBinding = new CommandBinding(
                CustomRoutedCommand, ExecutedCustomCommand, CanExecuteCustomCommand);

            // attach CommandBinding to root window
            this.CommandBindings.Add(customCommandBinding);
            //</SnippetCommandingOverviewCustomCommandBindingCodeBehind>

            sp.Children.Add(mainStackPanel);
            pasteTextBox.Background = Brushes.Bisque;

            sp.Children.Add(CustomCommandStackPanel);

            //<SnippetCommandingOverviewCmdSource>
            StackPanel cmdSourcePanel = new StackPanel();
            ContextMenu cmdSourceContextMenu = new ContextMenu();
            MenuItem cmdSourceMenuItem = new MenuItem();

            // Add ContextMenu to the StackPanel.
            cmdSourcePanel.ContextMenu = cmdSourceContextMenu;
            cmdSourcePanel.ContextMenu.Items.Add(cmdSourceMenuItem);

            // Associate Command with MenuItem.
            cmdSourceMenuItem.Command = ApplicationCommands.Properties;
            //</SnippetCommandingOverviewCmdSource>

            cmdSourcePanel.Background = Brushes.Black;
            cmdSourcePanel.Height = 100;
            cmdSourcePanel.Width = 100;
            mainStackPanel.Children.Add(cmdSourcePanel);
        }

        private void AddCommand(object sender, RoutedEventArgs e)
        {
            // <SnippetCommandingOverviewCmdManagerAddHandlers>
            CommandManager.AddExecutedHandler(helpButton, HelpCmdExecuted);
            CommandManager.AddCanExecuteHandler(helpButton, HelpCmdCanExecute);
            // </SnippetCommandingOverviewCmdManagerAddHandlers>
        }
        private void RemoveCommand(object sender, RoutedEventArgs e)
        {
            // <SnippetCommandingOverviewCmdManagerRemoveHandlers>
            CommandManager.RemoveExecutedHandler(helpButton, HelpCmdExecuted);
            CommandManager.RemoveCanExecuteHandler(helpButton, HelpCmdCanExecute);
            // </SnippetCommandingOverviewCmdManagerRemoveHandlers>
        }

        // <SnippetCommandingOverviewCmdManagerExecutedHandler>
        private void HelpCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // OpenHelpFile opens the help file
            OpenHelpFile();
        }
        // </SnippetCommandingOverviewCmdManagerExecutedHandler>

        // <SnippetCommandingOverviewCmdManagerCanExecuteHandler>
        private void HelpCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // HelpFilesExists() determines if the help file exists
            if (HelpFileExists() == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        // </SnippetCommandingOverviewCmdManagerCanExecuteHandler>

        private void OpenHelpFile()
        {
            MessageBox.Show("The Help File");
        }

        private bool HelpFileExists()
        {
            return true;
        }

        private void MyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command Executed");
        }

        //<SnippetCommandingOverviewExecuted>
        private void ExecutedCustomCommand(object sender,
            ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Custom Command Executed");
        }
        //</SnippetCommandingOverviewExecuted>

        //<SnippetCommandingOverviewCanExecute>
        // CanExecuteRoutedEventHandler that only returns true if
        // the source is a control.
        private void CanExecuteCustomCommand(object sender,
            CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if(target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        //</SnippetCommandingOverviewCanExecute>

        //<SnippetCommandingOverviewMultipleCmdHandler>
        private void ExecutedDisplayCommand(object sender,
            ExecutedRoutedEventArgs e)
        {
            RoutedCommand command = e.Command as RoutedCommand;

            if(command != null)
            {
                if(command == MediaCommands.Pause)
                {
                       MyPauseMethod();
                }
                if(command == MediaCommands.Play)
                {
                       MyPlayMethod();
                }
                if(command == MediaCommands.Stop)
                {
                       MyStopMethod();
                }
            }
        }
        //</SnippetCommandingOverviewMultipleCmdHandler>

        //<SnippetCommandingOverviewMultipleCanExecute>
        private void CanExecuteDisplayCommand(object sender,
            CanExecuteRoutedEventArgs e)
        {
            RoutedCommand command = e.Command as RoutedCommand;

            if (command != null)
            {
                if (command == MediaCommands.Play)
                {
                    if (IsPlaying() == false)
                    {
                        e.CanExecute = true;
                    }
                    else
                    {
                        e.CanExecute = false;
                    }
                }

                if (command == MediaCommands.Stop)
                {
                    if (IsPlaying() == true)
                    {
                        e.CanExecute = true;
                    }
                    else
                    {
                        e.CanExecute = false;
                    }
                }
            }
        }
        //</SnippetCommandingOverviewMultipleCanExecute>

        public void MyPlayMethod()
        {
            MessageBox.Show("Play");
        }
        public void MyPauseMethod()
        {
            MessageBox.Show("Pause");
        }
        public void MyStopMethod()
        {
            MessageBox.Show("Stop");
        }
        public bool IsPlaying()
        {
            return true;
        }

        public void CodeBehindSnippets()
        {

            MenuItem pasteMenuItem = new MenuItem();
            pasteMenuItem.Command = ApplicationCommands.Paste;

            //set the CommandTarget to the
            pasteMenuItem.CommandTarget = mainTextBox;
        }
    }

    //***********************************************************************
    //**
    //** This snippets are for the Threading Article from the Architect
    //** After Beta2 I'll create a new sniphost sample for them.
    //**
    //***********************************************************************

    //<SnippetThreadingArticleWeatherComponent1>
    public class WeatherComponent : Component
    {
        //gets weather: Synchronous
        public string GetWeather()
        {
            string weather = "";

            //predict the weather

            return weather;
        }

        //get weather: Asynchronous
        public void GetWeatherAsync()
        {
            //get the weather
        }

        public event GetWeatherCompletedEventHandler GetWeatherCompleted;
    }

    public class GetWeatherCompletedEventArgs : AsyncCompletedEventArgs
    {
        public GetWeatherCompletedEventArgs(Exception error, bool canceled,
            object userState, string weather)
            :
            base(error, canceled, userState)
        {
            _weather = weather;
        }

        public string Weather
        {
            get { return _weather; }
        }
        private string _weather;
    }

    public delegate void GetWeatherCompletedEventHandler(object sender,
        GetWeatherCompletedEventArgs e);
    //</SnippetThreadingArticleWeatherComponent1>

    //<SnippetThreadingArticleWeatherComponent2>
    public class WeatherComponent2 : Component
    {
        public string GetWeather()
        {
            return fetchWeatherFromServer();
        }

        private DispatcherSynchronizationContext requestingContext = null;

        public void GetWeatherAsync()
        {
            if (requestingContext != null)
                throw new InvalidOperationException("This component can only handle 1 async request at a time");

            requestingContext = (DispatcherSynchronizationContext)DispatcherSynchronizationContext.Current;

            NoArgDelegate fetcher = new NoArgDelegate(this.fetchWeatherFromServer);

            // Launch thread
            fetcher.BeginInvoke(null, null);
        }

        private void RaiseEvent(GetWeatherCompletedEventArgs e)
        {
            if (GetWeatherCompleted != null)
                GetWeatherCompleted(this, e);
        }

        private string fetchWeatherFromServer()
        {
            // do stuff
            string weather = "";

            GetWeatherCompletedEventArgs e =
                new GetWeatherCompletedEventArgs(null, false, null, weather);

            SendOrPostCallback callback = new SendOrPostCallback(DoEvent);
            requestingContext.Post(callback, e);
            requestingContext = null;

            return e.Weather;
        }

        private void DoEvent(object e)
        {
            //do stuff
        }

        public event GetWeatherCompletedEventHandler GetWeatherCompleted;
        public delegate string NoArgDelegate();
    }
    //</SnippetThreadingArticleWeatherComponent2>
}
