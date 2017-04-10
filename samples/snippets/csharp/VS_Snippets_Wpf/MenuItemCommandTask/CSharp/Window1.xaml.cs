using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace SDKSamples
{
    public partial class Window1 : Window
    {
        //<SnippetMenuItemCommandingCodeBehind>
        // Window1 constructor
        public Window1()
        {
            InitializeComponent();
 
            // Instantiating UIElements.
            DockPanel mainPanel = new DockPanel();
            Menu mainMenu = new Menu();
            MenuItem pasteMenuItem = new MenuItem();
            TextBox mainTextBox = new TextBox();

            // Associating the MenuItem with the Paste command.
            pasteMenuItem.Command = ApplicationCommands.Paste;

            // Setting properties on the TextBox.
            mainTextBox.Text =
                "The MenuItem will not be enabled until this TextBox receives keyboard focus.";
            mainTextBox.Margin = new Thickness(25);
            mainTextBox.BorderBrush = Brushes.Black;
            mainTextBox.BorderThickness = new Thickness(2);
            mainTextBox.TextWrapping = TextWrapping.Wrap;

            // Attaching UIElements to the Window.
            this.AddChild(mainPanel);
            mainMenu.Items.Add(pasteMenuItem);
            mainPanel.Children.Add(mainMenu);
            mainPanel.Children.Add(mainTextBox);

            // Defining DockPanel layout.
            DockPanel.SetDock(mainMenu, Dock.Top);
            DockPanel.SetDock(mainTextBox, Dock.Bottom);
        }
        //</SnippetMenuItemCommandingCodeBehind>

    }
}