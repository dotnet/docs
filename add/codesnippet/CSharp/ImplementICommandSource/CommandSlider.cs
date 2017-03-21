using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace SDKSamples
{
    //<SnippetImplementICommandSourceClassDefinition>
    public class CommandSlider : Slider, ICommandSource
    {
        public CommandSlider() : base()
        {

        }
    //</SnippetImplementICommandSourceClassDefinition>

        // ICommand Interface Memembers
        //<SnippetImplementICommandSourceCommandPropertyDefinition>
        // Make Command a dependency property so it can use databinding.
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(CommandSlider),
                new PropertyMetadata((ICommand)null,
                new PropertyChangedCallback(CommandChanged)));

        public ICommand Command
        {
            get 
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set 
            {
                SetValue(CommandProperty, value);
            }
        }
        //</SnippetImplementICommandSourceCommandPropertyDefinition>
        // Make CommandTarget a dependency property so it can use databinding.
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register(
                "CommandTarget",
                typeof(IInputElement),
                typeof(CommandSlider),
                new PropertyMetadata((IInputElement)null));

        public IInputElement CommandTarget
        {
            get
            {
                return (IInputElement)GetValue(CommandTargetProperty);
            }
            set
            {
                SetValue(CommandTargetProperty, value);
            }
        }

        // Make CommandParameter a dependency property so it can use databinding.
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter",
                typeof(object),
                typeof(CommandSlider),
                new PropertyMetadata((object)null));

        public object CommandParameter
        {
            get
            {
                return (object)GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        //<SnippetImplementICommandSourceCommandChanged>
        // Command dependency property change callback.
        private static void CommandChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            CommandSlider cs = (CommandSlider)d;
            cs.HookUpCommand((ICommand)e.OldValue,(ICommand)e.NewValue);
        }
        //</SnippetImplementICommandSourceCommandChanged>
        //<SnippetImplementICommandSourceHookUnHookCommands>
        // Add a new command to the Command Property.
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            // If oldCommand is not null, then we need to remove the handlers.
            if (oldCommand != null)
            {
                RemoveCommand(oldCommand, newCommand);
            }
            AddCommand(oldCommand, newCommand);
        }

        // Remove an old command from the Command Property.
        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }

        // Add the command.
        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            canExecuteChangedHandler = handler;
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += canExecuteChangedHandler;
            }
        }
        //</SnippetImplementICommandSourceHookUnHookCommands>
        //<SnippetImplementICommandCanExecuteChanged>
        private void CanExecuteChanged(object sender, EventArgs e)
        {

            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;

                // If a RoutedCommand.
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
                // If a not RoutedCommand.
                else
                {
                    if (Command.CanExecute(CommandParameter))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
            }
        }
        //</SnippetImplementICommandCanExecuteChanged>

        //<SnippetImplementICommandExecute>
        // If Command is defined, moving the slider will invoke the command;
        // Otherwise, the slider will behave normally.
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            if (this.Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;

                if (command != null)
                {
                    command.Execute(CommandParameter, CommandTarget);
                }
                else
                {
                    ((ICommand)Command).Execute(CommandParameter);
                }
            }
        }
        //</SnippetImplementICommandExecute>

        //<SnippetImplementICommandHandlerReference>
        // Keep a copy of the handler so it doesn't get garbage collected.
        private static EventHandler canExecuteChangedHandler;
        //</SnippetImplementICommandHandlerReference>
    }
}
