using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace InputCommandBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //<SnippetInitializeCommand>
        public SimpleDelegateCommand ChangeColorCommand
        {
            get { return changeColorCommand; }
        }

        private SimpleDelegateCommand changeColorCommand;

        private void InitializeCommand()
        {
            originalColor = this.Background;

            changeColorCommand = new SimpleDelegateCommand(x => this.ChangeColor(x));

            DataContext = this;
            changeColorCommand.GestureKey = Key.C;
            changeColorCommand.GestureModifier = ModifierKeys.Control;
            ChangeColorCommand.MouseGesture = MouseAction.RightClick;
        }

        private Brush originalColor, alternateColor;

        // Switch the Background color between
        // the original and selected color.
        private void ChangeColor(object colorString)
        {
            if (colorString == null)
            {
                return;
            }

            Color newColor = 
                (Color)ColorConverter.ConvertFromString((String)colorString);
            
            alternateColor = new SolidColorBrush(newColor);

            if (this.Background == originalColor)
            {
                this.Background = alternateColor;
            }
            else
            {
                this.Background = originalColor;
            }
        }
        //</SnippetInitializeCommand>

        public MainWindow()
        {
            InitializeComponent();

            InitializeCommand();
        }

    }

    //<SnippetDelegateCommand>
     // Create a class that implements ICommand and accepts a delegate.
    public class SimpleDelegateCommand : ICommand
    {
        // Specify the keys and mouse actions that invoke the command. 
        public Key GestureKey { get; set; }
        public ModifierKeys GestureModifier { get; set; }
        public MouseAction MouseGesture { get; set; }

        Action<object> _executeDelegate;

        public SimpleDelegateCommand(Action<object> executeDelegate)
        {
            _executeDelegate = executeDelegate;
        }

        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }

        public bool CanExecute(object parameter) { return true; }
        public event EventHandler CanExecuteChanged;
    }
    //</SnippetDelegateCommand>



}
